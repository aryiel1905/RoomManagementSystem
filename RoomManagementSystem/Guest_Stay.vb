Imports System.Data.OleDb
Imports System.Globalization

Partial Public Class frmGuest_Stay
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly PH As CultureInfo = CultureInfo.GetCultureInfo("en-PH")
    Private ReadOnly clockTimer As New Timer()
    Private SelectedStayID As Integer = -1
    Private SelectedBookingID As Integer = -1
    Private SelectedRoomID As Integer = -1

    Private Sub frmGuest_Stay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyGridStyle(dgvGuestStay)
        ApplyGridStyle(dgvCharges)
        ApplyGridStyle(dgvDiningNBar)
        ApplyGridStyle(dgvPayments)
        InitHeaderLabels()
        LoadGuestStays()
        UpdateClearFilterState()
    End Sub
    Private Sub frmGuest_Stay_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ApplyNavState(Nothing)
    End Sub

    Private Sub ApplyNavState(activeButton As Button)
        Dim navButtons = New Button() {btnReservation, btnCheckOut}
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

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If SelectedStayID <= 0 OrElse SelectedBookingID <= 0 OrElse SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a guest stay first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim stayStatus As String = ""
        If dgvGuestStay.CurrentRow IsNot Nothing AndAlso dgvGuestStay.Columns.Contains("Stay Status") Then
            stayStatus = SafeText(dgvGuestStay.CurrentRow.Cells("Stay Status").Value).Trim()
        End If
        If Not stayStatus.Equals("Checked In", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Only checked-in stays can be checked out.", "Invalid Stay Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim remaining As Decimal = SafeDec(lblRemaingBalance.Text.Replace("₱", "").Replace(",", "").Trim())
        If remaining > 0D Then
            MessageBox.Show("Remaining balance must be fully settled before check out.", "Balance Due", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show("Confirm check out for the selected guest stay?", "Confirm Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                        Dim stayRows = cmdStay.ExecuteNonQuery()
                        If stayRows = 0 Then
                            tx.Rollback()
                            MessageBox.Show("The stay is no longer eligible for check out. Please refresh.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                    RecomputeRoomStatus(SelectedRoomID, conn, tx)

                    tx.Commit()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to complete check out. " & ex.Message, "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        MessageBox.Show("Guest checked out successfully.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ReloadData()
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
        LoadChargesGrid(SelectedStayID)
        LoadDiningGrid(SelectedStayID)
        LoadPaymentsGrid(SelectedBookingID)
        RefreshStaySummary(SelectedStayID, SelectedBookingID)
    End Sub

    Private Sub btnAddCharges_Click(sender As Object, e As EventArgs) Handles btnEditCharges.Click
        If SelectedStayID <= 0 Then
            MessageBox.Show("Please select a guest stay first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New AddChargeForm(SelectedStayID)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LoadChargesGrid(SelectedStayID)
                RefreshStaySummary(SelectedStayID, SelectedBookingID)
            End If
        End Using
    End Sub

    Private Sub LoadGuestStays()
        Try
            Dim search As String = txtSearch.Text.Trim()
            Dim sql As String =
                "SELECT s.StayID, s.BookingID, s.RoomID, b.[Reservation No], b.[Guest Name], r.[Room No], r.[Room Type], r.[Class], " &
                "b.[Check In], b.[Check Out], s.[Stay Status] " &
                "FROM (tblStays AS s " &
                "INNER JOIN tblBookings AS b ON s.BookingID=b.BookingID) " &
                "INNER JOIN tblRooms AS r ON s.RoomID=r.RoomID "

            If search <> "" Then
                sql &= "WHERE b.[Guest Name] LIKE ? OR r.[Room No] LIKE ? "
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
                SelectedStayID = -1
                SelectedBookingID = -1
                SelectedRoomID = -1
                ClearHeader()
                LoadChargesGrid(-1)
                LoadDiningGrid(-1)
                LoadPaymentsGrid(-1)
                RefreshStaySummary(-1, -1)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to load guest stays. " & ex.Message, "Guest Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub ReloadData()
        LoadGuestStays()
    End Sub

    Public Function OpenForBooking(bookingId As Integer) As Boolean
        ReloadData()
        If bookingId <= 0 Then Return False

        For Each row As DataGridViewRow In dgvGuestStay.Rows
            If row.IsNewRow Then Continue For
            Dim value = row.Cells("BookingID").Value
            If value Is Nothing OrElse IsDBNull(value) Then Continue For
            If SafeInt(value) = bookingId Then
                dgvGuestStay.ClearSelection()
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible Then
                        dgvGuestStay.CurrentCell = cell
                        Exit For
                    End If
                Next
                row.Selected = True
                UpdateHeaderFromRow(row)
                SelectedStayID = SafeInt(row.Cells("StayID").Value)
                SelectedBookingID = SafeInt(row.Cells("BookingID").Value)
                SelectedRoomID = SafeInt(row.Cells("RoomID").Value)
                LoadChargesGrid(SelectedStayID)
                LoadDiningGrid(SelectedStayID)
                LoadPaymentsGrid(SelectedBookingID)
                RefreshStaySummary(SelectedStayID, SelectedBookingID)
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub UpdateHeaderFromRow(row As DataGridViewRow)
        If row Is Nothing Then Return
        lblGuestName.Text = SafeText(row.Cells("Guest Name").Value)
        lblResNo.Text = SafeText(row.Cells("Reservation No").Value)
        lblRoomNo.Text = SafeText(row.Cells("Room No").Value)
        Dim roomType As String = SafeText(row.Cells("Class").Value)
        Dim roomClass As String = SafeText(row.Cells("Room Type").Value)
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

    Private Sub LoadChargesGrid(stayId As Integer)
        Dim dt As New DataTable()
        If stayId <= 0 Then
            dgvCharges.DataSource = dt
            Return
        End If
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                ' Load manual/system charges from tblCharges
                Using cmd As New OleDbCommand(
                    "SELECT [Charge Date Time], [Charge Category], [Description], [Qty], [Unit Price], [Amount], [Charge Source] " &
                    "FROM tblCharges WHERE StayID=? AND IIf(IsNull([Is Voided]),0,[Is Voided])=0 " &
                    "ORDER BY [Charge Date Time] DESC;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using

                ' Add computed room charges (room + extras) so they appear in the grid
                If SelectedBookingID > 0 Then
                    Dim checkInDate As Date = Date.Today
                    Dim nights As Integer = 1
                    Dim extraPaxQty As Integer = 0
                    Dim extraMattressQty As Integer = 0
                    Dim baseRate As Decimal = 0D
                    Dim extraPaxRate As Decimal = 0D
                    Dim extraMattressRate As Decimal = 0D

                    Using cmdB As New OleDbCommand(
                        "SELECT b.[Check In], b.[Nights], b.[Extra Pax Qty], b.[Extra Mattress Qty], " &
                        "r.[Base Rate], r.[Extra Pax Rate], r.[Extra Mattress Rate] " &
                        "FROM tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID " &
                        "WHERE b.BookingID=?;", conn)
                        cmdB.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                        Using rd = cmdB.ExecuteReader()
                            If rd.Read() Then
                                If Not IsDBNull(rd(0)) Then checkInDate = CDate(rd(0))
                                nights = SafeInt(rd(1))
                                If nights < 1 Then nights = 1
                                extraPaxQty = SafeInt(rd(2))
                                extraMattressQty = SafeInt(rd(3))
                                baseRate = SafeDec(rd(4))
                                extraPaxRate = SafeDec(rd(5))
                                extraMattressRate = SafeDec(rd(6))
                            End If
                        End Using
                    End Using

                    Dim roomCharge As Decimal = Math.Round(baseRate * nights, 2, MidpointRounding.AwayFromZero)
                    Dim extraPaxCharge As Decimal = Math.Round(extraPaxRate * extraPaxQty, 2, MidpointRounding.AwayFromZero)
                    Dim extraMattressCharge As Decimal = Math.Round(extraMattressRate * extraMattressQty, 2, MidpointRounding.AwayFromZero)

                    ' Insert computed rows at the top
                    Dim insertIndex As Integer = 0
                    If roomCharge > 0D Then
                        Dim r = dt.NewRow()
                        r("Charge Date Time") = checkInDate
                        r("Charge Category") = "Room"
                        r("Description") = "Room Charge"
                        r("Qty") = nights
                        r("Unit Price") = baseRate
                        r("Amount") = roomCharge
                        r("Charge Source") = "System"
                        dt.Rows.InsertAt(r, insertIndex)
                        insertIndex += 1
                    End If
                    If extraPaxQty > 0 AndAlso extraPaxCharge > 0D Then
                        Dim r = dt.NewRow()
                        r("Charge Date Time") = checkInDate
                        r("Charge Category") = "Extra Pax"
                        r("Description") = "Extra Pax"
                        r("Qty") = extraPaxQty
                        r("Unit Price") = extraPaxRate
                        r("Amount") = extraPaxCharge
                        r("Charge Source") = "System"
                        dt.Rows.InsertAt(r, insertIndex)
                        insertIndex += 1
                    End If
                    If extraMattressQty > 0 AndAlso extraMattressCharge > 0D Then
                        Dim r = dt.NewRow()
                        r("Charge Date Time") = checkInDate
                        r("Charge Category") = "Extra Mattress"
                        r("Description") = "Extra Mattress"
                        r("Qty") = extraMattressQty
                        r("Unit Price") = extraMattressRate
                        r("Amount") = extraMattressCharge
                        r("Charge Source") = "System"
                        dt.Rows.InsertAt(r, insertIndex)
                    End If
                End If
            End Using
            If dt.Columns.Contains("Qty") Then
                If Not dt.Columns.Contains("Quantity") Then
                    dt.Columns.Add("Quantity", GetType(String))
                End If

                For Each row As DataRow In dt.Rows
                    row("Quantity") = FormatChargeQuantity(SafeText(row("Charge Category")), SafeDec(row("Qty")))
                Next
            End If

            dgvCharges.DataSource = dt
            dgvCharges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvCharges.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If dgvCharges.Columns.Contains("Charge Date Time") Then dgvCharges.Columns("Charge Date Time").HeaderText = "Date"
            If dgvCharges.Columns.Contains("Charge Category") Then dgvCharges.Columns("Charge Category").HeaderText = "Category"
            If dgvCharges.Columns.Contains("Description") Then dgvCharges.Columns("Description").HeaderText = "Description"
            If dgvCharges.Columns.Contains("Quantity") Then dgvCharges.Columns("Quantity").HeaderText = "Quantity"
            If dgvCharges.Columns.Contains("Amount") Then dgvCharges.Columns("Amount").HeaderText = "Amount"
            If dgvCharges.Columns.Contains("Quantity") Then dgvCharges.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For Each col As DataGridViewColumn In dgvCharges.Columns
                Dim name As String = col.Name
                If name = "Charge Date Time" OrElse name = "Charge Category" OrElse name = "Description" OrElse name = "Quantity" OrElse name = "Amount" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Unable to load charges. " & ex.Message, "Guest Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadDiningGrid(stayId As Integer)
        Dim dt As New DataTable()
        If stayId <= 0 Then
            dgvDiningNBar.DataSource = dt
            Return
        End If
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "SELECT [OrderID], [Order Date Time], [Order Status], [Total Amount], [Payment Mode] " &
                    "FROM tblOrders WHERE StayID=? ORDER BY [Order Date Time] DESC;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            dgvDiningNBar.DataSource = dt
            dgvDiningNBar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvDiningNBar.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If dgvDiningNBar.Columns.Contains("OrderID") Then dgvDiningNBar.Columns("OrderID").HeaderText = "Order No"
            If dgvDiningNBar.Columns.Contains("Order Date Time") Then dgvDiningNBar.Columns("Order Date Time").HeaderText = "Date"
            If dgvDiningNBar.Columns.Contains("Total Amount") Then dgvDiningNBar.Columns("Total Amount").HeaderText = "Total"
            If dgvDiningNBar.Columns.Contains("Order Status") Then dgvDiningNBar.Columns("Order Status").HeaderText = "Status"

            For Each col As DataGridViewColumn In dgvDiningNBar.Columns
                Dim name As String = col.Name
                If name = "OrderID" OrElse name = "Order Date Time" OrElse name = "Total Amount" OrElse name = "Order Status" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Unable to load dining & bar orders. " & ex.Message, "Guest Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadPaymentsGrid(bookingId As Integer)
        Dim dt As New DataTable()
        If bookingId <= 0 Then
            dgvPayments.DataSource = dt
            Return
        End If
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "SELECT [Payment Date], [Method], [Amount], [Reference No] FROM tblPayments WHERE BookingID=? ORDER BY [Payment Date] DESC;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            dgvPayments.DataSource = dt
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If dgvPayments.Columns.Contains("Payment Date") Then dgvPayments.Columns("Payment Date").HeaderText = "Date"
            If dgvPayments.Columns.Contains("Method") Then dgvPayments.Columns("Method").HeaderText = "Method"
            If dgvPayments.Columns.Contains("Amount") Then dgvPayments.Columns("Amount").HeaderText = "Amount"
            If dgvPayments.Columns.Contains("Reference No") Then dgvPayments.Columns("Reference No").HeaderText = "Reference"

            For Each col As DataGridViewColumn In dgvPayments.Columns
                Dim name As String = col.Name
                If name = "Payment Date" OrElse name = "Amount" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Unable to load payments. " & ex.Message, "Guest Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RefreshStaySummary(stayId As Integer, bookingId As Integer)
        If stayId <= 0 OrElse bookingId <= 0 Then
            lblRoomCharges.Text = FormatPeso(0D)
            lblDiningNBar.Text = FormatPeso(0D)
            If lblOthers IsNot Nothing Then lblOthers.Text = FormatPeso(0D)
            lblTotalPaid.Text = FormatPeso(0D)
            lblRemaingBalance.Text = FormatPeso(0D)
            Return
        End If

        Try
            Dim roomCharges As Decimal = 0D
            Dim diningCharges As Decimal = 0D
            Dim damageCharges As Decimal = 0D
            Dim paid As Decimal = 0D
            Dim refunded As Decimal = 0D

            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                Using cmdRoom As New OleDbCommand("SELECT IIf(IsNull([Total Amount]),0,[Total Amount]) FROM tblBookings WHERE BookingID=?;", conn)
                    cmdRoom.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    roomCharges = SafeDec(cmdRoom.ExecuteScalar())
                End Using

                Using cmdDining As New OleDbCommand(
                    "SELECT IIf(IsNull(SUM([Amount])),0,SUM([Amount])) FROM tblCharges " &
                    "WHERE StayID=? AND IIf(IsNull([Is Voided]),0,[Is Voided])=0 AND [Charge Category]='Dining/Bar';", conn)
                    cmdDining.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    diningCharges = SafeDec(cmdDining.ExecuteScalar())
                End Using

                Using cmdOther As New OleDbCommand(
                    "SELECT IIf(IsNull(SUM([Amount])),0,SUM([Amount])) FROM tblCharges " &
                    "WHERE StayID=? AND IIf(IsNull([Is Voided]),0,[Is Voided])=0 AND [Charge Category]='Damage';", conn)
                    cmdOther.Parameters.Add("?", OleDbType.Integer).Value = stayId
                    damageCharges = SafeDec(cmdOther.ExecuteScalar())
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

            Dim totalCharges As Decimal = roomCharges + diningCharges + damageCharges
            Dim netPaid As Decimal = paid - refunded
            If netPaid < 0D Then netPaid = 0D
            Dim remaining As Decimal = totalCharges - netPaid
            If remaining < 0D Then remaining = 0D

            lblRoomCharges.Text = FormatPeso(roomCharges)
            lblDiningNBar.Text = FormatPeso(diningCharges)
            If lblOthers IsNot Nothing Then lblOthers.Text = FormatPeso(damageCharges)
            lblTotalPaid.Text = FormatPeso(netPaid)
            lblRemaingBalance.Text = FormatPeso(remaining)
        Catch ex As Exception
            MessageBox.Show("Unable to refresh summary. " & ex.Message, "Guest Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
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

    Private Function FormatChargeQuantity(chargeCategory As String, qty As Decimal) As String
        If qty <= 0D Then Return ""

        Dim formattedQty As String = qty.ToString("0.##")

        Select Case chargeCategory.Trim().ToUpperInvariant()
            Case "ROOM"
                Return formattedQty & If(qty = 1D, " night", " nights")
            Case "EXTRA PAX"
                Return formattedQty & " pax"
            Case "EXTRA MATTRESS"
                Return formattedQty & If(qty = 1D, " mattress", " mattresses")
            Case "AMENITIES"
                Return formattedQty & If(qty = 1D, " item", " items")
            Case Else
                Return formattedQty
        End Select
    End Function

    Private Function FormatPeso(value As Decimal) As String
        Return "₱" & value.ToString("N2", PH)
    End Function

    Private Sub gbReservationLookUp_Enter(sender As Object, e As EventArgs) Handles gbReservationLookUp.Enter

    End Sub

    Private Sub gbRooms_Enter(sender As Object, e As EventArgs) Handles gbRooms.Enter

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblCheckOut_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTypeClass_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class
