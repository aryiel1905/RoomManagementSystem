Imports System.Data.OleDb
Imports System.Globalization

Partial Public Class CheckOut
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly PH As CultureInfo = CultureInfo.GetCultureInfo("en-PH")
    Private ReadOnly clockTimer As New Timer()
    Private SelectedStayID As Integer = -1
    Private SelectedBookingID As Integer = -1
    Private SelectedRoomID As Integer = -1
    Private Const PaymentPrefix As String = "₱"
    Private PaymentTextInternalUpdate As Boolean = False
    Private CurrentRemaining As Decimal = 0D

    Private Sub CheckOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyGridStyle(dgvGuestStay)
        ApplyGridStyle(dgvSummary)
        SetPaymentPlaceholder()
        InitHeaderLabels()
        LoadGuestStays()
        UpdateClearFilterState()
    End Sub
    Private Sub CheckOut_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ApplyNavState(btnCheckingOut)
    End Sub

    Private Sub ApplyNavState(activeButton As Button)
        Dim navButtons = New Button() {btnReservation, btnCheckingIn, btnCheckingOut, btnGuestStay}
        For Each b In navButtons
            If b Is Nothing Then Continue For
            b.Enabled = True
            b.UseVisualStyleBackColor = True
            b.BackColor = SystemColors.Control
            b.ForeColor = Color.Teal
            b.Tag = Nothing
        Next

        If activeButton Is Nothing Then Return
        activeButton.UseVisualStyleBackColor = False
        activeButton.BackColor = Color.DarkSlateGray
        activeButton.ForeColor = Color.White
        activeButton.Tag = "active"
    End Sub

    ' ---- Bottom Navigation ----
    Private Sub btnReservation_Click(sender As Object, e As EventArgs) Handles btnReservation.Click
        If btnReservation.Tag IsNot Nothing Then Return
        frmReservations.ReloadData()
        frmReservations.Show()
        Me.Hide()
    End Sub

    Private Sub btnCheckingIn_Click(sender As Object, e As EventArgs) Handles btnCheckingIn.Click
        If btnCheckingIn.Tag IsNot Nothing Then Return
        frmCheckIn.ReloadData()
        frmCheckIn.Show()
        Me.Hide()
    End Sub

    Private Sub btnGuestStay_Click(sender As Object, e As EventArgs) Handles btnGuestStay.Click
        If btnGuestStay.Tag IsNot Nothing Then Return
        frmGuest_Stay.ReloadData()
        frmGuest_Stay.Show()
        Me.Hide()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadGuestStays()
        UpdateClearFilterState()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        LoadGuestStays()
        UpdateClearFilterState()
    End Sub

    Private Sub UpdateClearFilterState()
        If btnClearFilter Is Nothing Then Return
        btnClearFilter.Enabled = (txtSearch.Text.Trim() <> "")
    End Sub

    Private Sub InitHeaderLabels()
        If lblOperator IsNot Nothing Then
            Dim name = AppSession.CurrentUserName
            If String.IsNullOrWhiteSpace(name) Then
                lblOperator.Text = "WELCOME, --------"
            Else
                lblOperator.Text = $"WELCOME, {name.ToUpperInvariant()}"
            End If
        End If

        UpdateDateTimeLabel()

        clockTimer.Interval = 1000
        AddHandler clockTimer.Tick, Sub()
                                        UpdateDateTimeLabel()
                                    End Sub
        clockTimer.Start()
    End Sub

    Private Sub UpdateDateTimeLabel()
        If lblDateTime Is Nothing Then Return
        lblDateTime.Text = Date.Now.ToString("dddd, MMM dd, yyyy  hh:mm tt").ToUpperInvariant()
    End Sub

    Private Sub dgvGuestStay_SelectionChanged(sender As Object, e As EventArgs) Handles dgvGuestStay.SelectionChanged
        If dgvGuestStay.CurrentRow Is Nothing Then Return
        If dgvGuestStay.CurrentRow.Cells("StayID").Value Is Nothing Then Return

        SelectedStayID = CInt(dgvGuestStay.CurrentRow.Cells("StayID").Value)
        SelectedBookingID = SafeInt(dgvGuestStay.CurrentRow.Cells("BookingID").Value)
        SelectedRoomID = SafeInt(dgvGuestStay.CurrentRow.Cells("RoomID").Value)

        UpdateHeaderFromRow(dgvGuestStay.CurrentRow)
        LoadSummaryGrid(SelectedStayID, SelectedBookingID)
        RefreshTotals(SelectedStayID, SelectedBookingID)
    End Sub

    Private Sub btnCollectPayment_Click(sender As Object, e As EventArgs) Handles btnCollectPayment.Click
        If SelectedBookingID <= 0 Then
            MessageBox.Show("Please select a guest stay first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim amount As Decimal
        Dim raw As String = TextBox1.Text.Trim().Replace(PaymentPrefix, "").Replace(",", "")
        If Not Decimal.TryParse(raw, amount) OrElse amount <= 0D Then
            MessageBox.Show("Enter a valid payment amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Focus()
            Return
        End If

        Dim method As String = "Cash"
        Dim changeDue As Decimal = 0D
        If CurrentRemaining > 0D AndAlso amount > CurrentRemaining Then
            changeDue = amount - CurrentRemaining
            amount = CurrentRemaining
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "INSERT INTO tblPayments (BookingID, [Payment Date], Amount, Method, CreatedAt) VALUES (?,?,?,?,?);", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = amount
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = method
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to add payment. " & ex.Message, "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        SetPaymentPlaceholder()
        LoadSummaryGrid(SelectedStayID, SelectedBookingID)
        RefreshTotals(SelectedStayID, SelectedBookingID)
        If changeDue > 0D Then
            Label1.Text = FormatPeso(changeDue)
            MessageBox.Show("Change due: " & FormatPeso(changeDue), "Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        MessageBox.Show("Payment added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnConfirmCheckout_Click(sender As Object, e As EventArgs) Handles btnConfirmCheckout.Click
        If SelectedStayID <= 0 OrElse SelectedBookingID <= 0 OrElse SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a guest stay first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If CurrentRemaining > 0D Then
            MessageBox.Show("Remaining balance must be settled before check out.", "Balance Due", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm = MessageBox.Show("Confirm check out for this guest?", "Confirm Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Using cmdStay As New OleDbCommand(
                        "UPDATE tblStays SET [Stay Status]='Checked Out', [Actual Check Out]=? WHERE StayID=? AND [Stay Status]='Checked In';",
                        conn, tx)
                        cmdStay.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdStay.Parameters.Add("?", OleDbType.Integer).Value = SelectedStayID
                        Dim rows = cmdStay.ExecuteNonQuery()
                        If rows = 0 Then
                            tx.Rollback()
                            MessageBox.Show("Status changed. Refresh and try again.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    End Using

                    Using cmdBook As New OleDbCommand(
                        "UPDATE tblBookings SET [Booking Status]='Checked Out', UpdatedAt=? WHERE BookingID=?;",
                        conn, tx)
                        cmdBook.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdBook.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                        cmdBook.ExecuteNonQuery()
                    End Using

                    Using cmdRoom As New OleDbCommand(
                        "UPDATE tblRooms SET [Room Status]='Dirty' WHERE RoomID=? AND [Room Status] NOT IN ('Maintenance','Inactive');",
                        conn, tx)
                        cmdRoom.Parameters.Add("?", OleDbType.Integer).Value = SelectedRoomID
                        cmdRoom.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to confirm check out. " & ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        MessageBox.Show("Guest checked out successfully.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadGuestStays()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Print invoice is not configured yet.", "Print Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadGuestStays()
        Try
            Dim search As String = txtSearch.Text.Trim()
            Dim sql As String =
                "SELECT s.StayID, s.BookingID, s.RoomID, b.[Reservation No], b.[Guest Name], r.[Room No], r.[Room Type], r.[Class], " &
                "b.[Check In], b.[Check Out], s.[Stay Status] " &
                "FROM (tblStays AS s " &
                "INNER JOIN tblBookings AS b ON s.BookingID=b.BookingID) " &
                "INNER JOIN tblRooms AS r ON s.RoomID=r.RoomID " &
                "WHERE s.[Stay Status]='Checked In' "

            If search <> "" Then
                sql &= "AND (b.[Guest Name] LIKE ? OR r.[Room No] LIKE ?) "
            End If
            sql &= "ORDER BY s.StayID DESC;"

            Dim dt As New DataTable()
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(sql, conn)
                    If search <> "" Then
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & search & "%"
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & search & "%"
                    End If
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvGuestStay.DataSource = dt
            If dgvGuestStay.Columns.Contains("StayID") Then dgvGuestStay.Columns("StayID").HeaderText = "Stay ID"
            If dgvGuestStay.Columns.Contains("Guest Name") Then dgvGuestStay.Columns("Guest Name").HeaderText = "Guest"
            If dgvGuestStay.Columns.Contains("Room No") Then dgvGuestStay.Columns("Room No").HeaderText = "Room"

            For Each col As DataGridViewColumn In dgvGuestStay.Columns
                Dim name As String = col.Name
                If name = "StayID" OrElse name = "Guest Name" OrElse name = "Room No" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next

            dgvGuestStay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvGuestStay.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If dgvGuestStay.Rows.Count > 0 Then
                dgvGuestStay.Rows(0).Selected = True
            Else
                ClearHeader()
                LoadSummaryGrid(-1, -1)
                RefreshTotals(-1, -1)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to load guest stays. " & ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub ReloadData()
        LoadGuestStays()
    End Sub

    Private Sub UpdateHeaderFromRow(row As DataGridViewRow)
        If row Is Nothing Then Return
        lblGuestName.Text = SafeText(row.Cells("Guest Name").Value)
        lblResNo.Text = SafeText(row.Cells("Reservation No").Value)
        lblRoomNo.Text = SafeText(row.Cells("Room No").Value)
        Dim roomType As String = SafeText(row.Cells("Room Type").Value)
        Dim roomClass As String = SafeText(row.Cells("Class").Value)
        lblTypeClass.Text = FormatTypeClass(roomType, roomClass)

        Dim ci As Date
        If Date.TryParse(SafeText(row.Cells("Check In").Value), ci) Then
            lblCheckIn.Text = ci.ToString("MMM d, yyyy")
        Else
            lblCheckIn.Text = "--------"
        End If
        Dim co As Date
        If Date.TryParse(SafeText(row.Cells("Check Out").Value), co) Then
            lblCheckOut.Text = co.ToString("MMM d, yyyy")
        Else
            lblCheckOut.Text = "--------"
        End If
    End Sub

    Private Sub ClearHeader()
        lblGuestName.Text = "--------"
        lblResNo.Text = "--------"
        lblRoomNo.Text = "--------"
        lblTypeClass.Text = "--------"
        lblCheckIn.Text = "--------"
        lblCheckOut.Text = "--------"
    End Sub

    Private Sub LoadSummaryGrid(stayId As Integer, bookingId As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("Category", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Qty", GetType(String))
        dt.Columns.Add("Rate", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))

        If stayId <= 0 OrElse bookingId <= 0 Then
            dgvSummary.DataSource = dt
            Return
        End If

        Try
            Dim totalAmount As Decimal = 0D
            Dim nights As Integer = 0
            Dim checkInDate As Date = Date.Today
            Dim extraPaxQty As Integer = 0
            Dim extraMattressQty As Integer = 0
            Dim baseRate As Decimal = 0D
            Dim extraPaxRate As Decimal = 0D
            Dim extraMattressRate As Decimal = 0D

            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "SELECT b.[Total Amount], b.[Nights], b.[Check In], b.[Extra Pax Qty], b.[Extra Mattress Qty], " &
                    "r.[Base Rate], r.[Extra Pax Rate], r.[Extra Mattress Rate] " &
                    "FROM tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID WHERE b.BookingID=?;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            totalAmount = SafeDec(rd(0))
                            nights = SafeInt(rd(1))
                            If Not IsDBNull(rd(2)) Then
                                checkInDate = CDate(rd(2))
                            End If
                            extraPaxQty = SafeInt(rd(3))
                            extraMattressQty = SafeInt(rd(4))
                            baseRate = SafeDec(rd(5))
                            extraPaxRate = SafeDec(rd(6))
                            extraMattressRate = SafeDec(rd(7))
                        End If
                    End Using
                End Using

                If nights < 1 Then nights = 1

                ' Room charge (base rate * nights)
                Dim roomCharge As Decimal = Math.Round(baseRate * nights, 2, MidpointRounding.AwayFromZero)
                Dim roomRate As Decimal = 0D
                If nights > 0 Then roomRate = baseRate
                dt.Rows.Add(checkInDate.ToString("MMM d, yyyy"), "Room", "Room Charge", nights.ToString(), FormatPeso(roomRate), roomCharge)

                ' Extra Pax
                If extraPaxQty > 0 AndAlso extraPaxRate > 0D Then
                    Dim paxAmt As Decimal = Math.Round(extraPaxQty * extraPaxRate, 2, MidpointRounding.AwayFromZero)
                    dt.Rows.Add(checkInDate.ToString("MMM d, yyyy"), "Extra Pax", "Extra Pax", extraPaxQty.ToString(), FormatPeso(extraPaxRate), paxAmt)
                End If

                ' Extra Mattress
                If extraMattressQty > 0 AndAlso extraMattressRate > 0D Then
                    Dim matAmt As Decimal = Math.Round(extraMattressQty * extraMattressRate, 2, MidpointRounding.AwayFromZero)
                    dt.Rows.Add(checkInDate.ToString("MMM d, yyyy"), "Extra Mattress", "Extra Mattress", extraMattressQty.ToString(), FormatPeso(extraMattressRate), matAmt)
                End If

                Using cmd As New OleDbCommand(
                    "SELECT [Charge Date Time], [Charge Category], [Description], [Qty], [Unit Price], [Amount] " &
                    "FROM tblCharges WHERE StayID=? AND IIf(IsNull([Is Voided]),0,[Is Voided])=0 " &
                    "ORDER BY [Charge Date Time] DESC;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim d As String = ""
                            If Not IsDBNull(rd(0)) Then d = CDate(rd(0)).ToString("MMM d, yyyy")
                            Dim cat As String = SafeText(rd(1))
                            Dim desc As String = SafeText(rd(2))
                            Dim qty As String = SafeText(rd(3))
                            Dim unit As String = FormatPeso(SafeDec(rd(4)))
                            Dim amt As Decimal = SafeDec(rd(5))
                            dt.Rows.Add(d, cat, desc, qty, unit, amt)
                        End While
                    End Using
                End Using
            End Using

            dgvSummary.DataSource = dt
            dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If dgvSummary.Columns.Contains("Amount") Then
                dgvSummary.Columns("Amount").DefaultCellStyle.Format = "₱#,##0.00"
                dgvSummary.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            For Each col As DataGridViewColumn In dgvSummary.Columns
                Dim name As String = col.Name
                If name = "Date" OrElse name = "Category" OrElse name = "Description" OrElse name = "Qty" OrElse name = "Rate" OrElse name = "Amount" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Unable to load summary. " & ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RefreshTotals(stayId As Integer, bookingId As Integer)
        If stayId <= 0 OrElse bookingId <= 0 Then
            lblTotalCharges.Text = FormatPeso(0D)
            lblTotalPaid.Text = FormatPeso(0D)
            lblRemainingBalance.Text = FormatPeso(0D)
            CurrentRemaining = 0D
            UpdatePaymentControls()
            Return
        End If

        Try
            Dim roomTotal As Decimal = 0D
            Dim chargesTotal As Decimal = 0D
            Dim paid As Decimal = 0D
            Dim refunded As Decimal = 0D

            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                Using cmdRoom As New OleDbCommand("SELECT IIf(IsNull([Total Amount]),0,[Total Amount]) FROM tblBookings WHERE BookingID=?;", conn)
                    cmdRoom.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    roomTotal = SafeDec(cmdRoom.ExecuteScalar())
                End Using

                Using cmdCharges As New OleDbCommand(
                    "SELECT IIf(IsNull(SUM([Amount])),0,SUM([Amount])) FROM tblCharges WHERE StayID=? AND IIf(IsNull([Is Voided]),0,[Is Voided])=0;", conn)
                    cmdCharges.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    chargesTotal = SafeDec(cmdCharges.ExecuteScalar())
                End Using

                Using cmdPaid As New OleDbCommand(
                    "SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblPayments WHERE BookingID=?;", conn)
                    cmdPaid.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    paid = SafeDec(cmdPaid.ExecuteScalar())
                End Using

                Using cmdRefund As New OleDbCommand(
                    "SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblRefunds WHERE BookingID=?;", conn)
                    cmdRefund.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    refunded = SafeDec(cmdRefund.ExecuteScalar())
                End Using
            End Using

            Dim totalCharges As Decimal = roomTotal + chargesTotal
            Dim netPaid As Decimal = paid - refunded
            If netPaid < 0D Then netPaid = 0D
            Dim remaining As Decimal = totalCharges - netPaid
            If remaining < 0D Then remaining = 0D
            CurrentRemaining = remaining

            lblTotalCharges.Text = FormatPeso(totalCharges)
            lblTotalPaid.Text = FormatPeso(netPaid)
            lblRemainingBalance.Text = FormatPeso(remaining)
            Label1.Text = FormatPeso(0D)
            UpdatePaymentControls()
        Catch ex As Exception
            MessageBox.Show("Unable to refresh totals. " & ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UpdatePaymentControls()
        Dim canCollect As Boolean = (CurrentRemaining > 0D)
        btnCollectPayment.Enabled = canCollect
        TextBox1.Enabled = canCollect
        If Not canCollect Then
            SetPaymentPlaceholder()
        End If
    End Sub

    Private Sub SetPaymentPlaceholder()
        PaymentTextInternalUpdate = True
        TextBox1.Text = PaymentPrefix & "0.00"
        TextBox1.Tag = "placeholder"
        TextBox1.SelectionStart = TextBox1.Text.Length
        PaymentTextInternalUpdate = False
        Label1.Text = FormatPeso(0D)
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Tag IsNot Nothing AndAlso TextBox1.Tag.ToString() = "placeholder" Then
            PaymentTextInternalUpdate = True
            TextBox1.Text = PaymentPrefix
            TextBox1.Tag = Nothing
            TextBox1.SelectionStart = TextBox1.Text.Length
            PaymentTextInternalUpdate = False
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Dim raw As String = TextBox1.Text.Trim()
        If raw = "" OrElse raw = PaymentPrefix Then
            SetPaymentPlaceholder()
            Return
        End If
        Dim value As Decimal
        Dim cleaned As String = raw.Replace(PaymentPrefix, "").Replace(",", "").Trim()
        If Decimal.TryParse(cleaned, value) Then
            PaymentTextInternalUpdate = True
            TextBox1.Text = PaymentPrefix & value.ToString("N2", PH)
            TextBox1.SelectionStart = TextBox1.Text.Length
            PaymentTextInternalUpdate = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If PaymentTextInternalUpdate Then Return
        If TextBox1.Text = "" Then Return
        If Not TextBox1.Text.StartsWith(PaymentPrefix) Then
            PaymentTextInternalUpdate = True
            TextBox1.Text = PaymentPrefix & TextBox1.Text
            TextBox1.SelectionStart = TextBox1.Text.Length
            PaymentTextInternalUpdate = False
        End If

        Dim raw As String = TextBox1.Text.Trim().Replace(PaymentPrefix, "").Replace(",", "")
        Dim value As Decimal = 0D
        Decimal.TryParse(raw, value)
        If CurrentRemaining <= 0D Then
            Label1.Text = FormatPeso(0D)
            Return
        End If
        Dim changeDue As Decimal = 0D
        If value > CurrentRemaining Then
            changeDue = value - CurrentRemaining
        End If
        Label1.Text = FormatPeso(changeDue)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.SelectionStart = 0 AndAlso TextBox1.SelectionLength = 0 Then
            e.Handled = True
            Return
        End If
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso TextBox1.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub ApplyGridStyle(dgv As DataGridView)
        If dgv Is Nothing Then Return

        dgv.BackgroundColor = Color.AliceBlue
        dgv.GridColor = SystemColors.ControlDarkDark
        dgv.EnableHeadersVisualStyles = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.RowHeadersVisible = False
        dgv.RowTemplate.Height = 28

        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise

        Dim headerStyle As New DataGridViewCellStyle()
        headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        headerStyle.BackColor = Color.DarkSlateGray
        headerStyle.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        headerStyle.ForeColor = Color.White
        headerStyle.Padding = New Padding(0, 4, 0, 4)
        headerStyle.SelectionBackColor = SystemColors.Highlight
        headerStyle.SelectionForeColor = SystemColors.HighlightText
        headerStyle.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = headerStyle

        Dim rowHeaderStyle As New DataGridViewCellStyle()
        rowHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        rowHeaderStyle.BackColor = Color.LightSeaGreen
        rowHeaderStyle.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        rowHeaderStyle.ForeColor = Color.White
        rowHeaderStyle.SelectionBackColor = Color.White
        rowHeaderStyle.SelectionForeColor = SystemColors.HighlightText
        rowHeaderStyle.WrapMode = DataGridViewTriState.True
        dgv.RowHeadersDefaultCellStyle = rowHeaderStyle

        Dim rowsStyle As New DataGridViewCellStyle()
        rowsStyle.BackColor = Color.Azure
        rowsStyle.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        rowsStyle.SelectionBackColor = Color.Gold
        rowsStyle.SelectionForeColor = SystemColors.InfoText
        dgv.RowsDefaultCellStyle = rowsStyle
    End Sub

    Private Function SafeText(v As Object) As String
        If v Is Nothing OrElse IsDBNull(v) Then Return ""
        Return v.ToString()
    End Function

    Private Function FormatTypeClass(roomType As String, roomClass As String) As String
        Dim t As String = If(roomType, "").Trim()
        Dim c As String = If(roomClass, "").Trim()
        If t = "" AndAlso c = "" Then Return "--------"
        If t <> "" AndAlso c <> "" Then Return t & " / " & c
        If t <> "" Then Return t
        Return c
    End Function

    Private Function SafeInt(v As Object) As Integer
        If v Is Nothing OrElse IsDBNull(v) Then Return 0
        Dim i As Integer = 0
        Integer.TryParse(v.ToString(), i)
        Return i
    End Function

    Private Function SafeDec(v As Object) As Decimal
        If v Is Nothing OrElse IsDBNull(v) Then Return 0D
        Dim d As Decimal = 0D
        Decimal.TryParse(v.ToString(), d)
        Return d
    End Function

    Private Function FormatPeso(value As Decimal) As String
        Return "₱" & value.ToString("N2", PH)
    End Function

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
