Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class frmCheckIn
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly clockTimer As New Timer()
    Private Const PaymentPrefix As String = "₱"
    Private PaymentTextInternalUpdate As Boolean = False
    Private _currentTotalPax As Integer = 0

    Private Sub frmCheckIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReservationsGrid()
        ApplyNavState(btnCheckingIn)
        InitHeaderLabels()
        SetPaymentPlaceholder()
    End Sub

    Private Sub UpdateReservationsSummary()
        If lblSummary Is Nothing Then Return

        Dim rowCount As Integer = 0
        If dgvReservations IsNot Nothing Then
            For Each row As DataGridViewRow In dgvReservations.Rows
                If Not row.IsNewRow Then
                    rowCount += 1
                End If
            Next
        End If

        lblSummary.Text = $"TOTAL ROWS: {rowCount}"
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

    Private Sub UpdateStatusBadge(status As String)
        If lblCheckinStatus Is Nothing Then Return
        Dim s As String = If(status, "").Trim()
        If s = "" Then
            lblCheckinStatus.Text = "STATUS: ----"
            lblCheckinStatus.BackColor = Color.LightGray
            lblCheckinStatus.ForeColor = Color.Black
            Return
        End If

        Dim upper As String = s.ToUpperInvariant()
        lblCheckinStatus.Text = "STATUS: " & upper

        Select Case upper
            Case "RESERVED"
                lblCheckinStatus.BackColor = Color.FromArgb(198, 239, 206)
                lblCheckinStatus.ForeColor = Color.FromArgb(0, 97, 0)
            Case "PENDING"
                lblCheckinStatus.BackColor = Color.FromArgb(255, 235, 156)
                lblCheckinStatus.ForeColor = Color.FromArgb(156, 101, 0)
            Case "CHECKED IN"
                lblCheckinStatus.BackColor = Color.FromArgb(189, 215, 238)
                lblCheckinStatus.ForeColor = Color.FromArgb(0, 32, 96)
            Case "CANCELLED"
                lblCheckinStatus.BackColor = Color.FromArgb(255, 199, 206)
                lblCheckinStatus.ForeColor = Color.FromArgb(156, 0, 6)
            Case "NO-SHOW"
                lblCheckinStatus.BackColor = Color.FromArgb(217, 217, 217)
                lblCheckinStatus.ForeColor = Color.FromArgb(64, 64, 64)
            Case Else
                lblCheckinStatus.BackColor = Color.LightGray
                lblCheckinStatus.ForeColor = Color.Black
        End Select
    End Sub


    Private Sub LoadReservationsGrid()
        Dim dt As New DataTable()

        Dim sql As String =
            "SELECT " &
            " b.BookingID, b.RoomID, b.[Reservation No] AS [Res No], " &
            " b.[Guest Name] AS [Guest Name], " &
            " b.[Booking Status] AS [Status] " &
            "FROM (tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID) " &
            "WHERE 1=1 "

        Dim search As String = txtSearch.Text.Trim()
        If search <> "" Then
            sql &= " AND (b.[Reservation No] LIKE ? OR b.[Guest Name] LIKE ?) "
        End If
        sql &= " AND b.[Booking Status] IN ('Reserved','Pending','Checked In') "

        sql &= " ORDER BY b.BookingID DESC;"

        Try
            Using conn As New OleDbConnection(ConnStr)
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
        Catch ex As Exception
            MessageBox.Show("Unable to load reservations. " & ex.Message, "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        dgvReservations.DataSource = dt
        dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReservations.MultiSelect = False
        dgvReservations.ReadOnly = True
        dgvReservations.AllowUserToAddRows = False
        dgvReservations.RowHeadersVisible = False
        UpdateReservationsSummary()

        If dgvReservations.Columns.Contains("BookingID") Then dgvReservations.Columns("BookingID").Visible = False
        If dgvReservations.Columns.Contains("RoomID") Then dgvReservations.Columns("RoomID").Visible = False

        If dgvReservations.Rows.Count > 0 Then
            For Each cell As DataGridViewCell In dgvReservations.Rows(0).Cells
                If cell.Visible Then
                    dgvReservations.CurrentCell = cell
                    Exit For
                End If
            Next
            LoadSelectedReservationDetails()
        Else
            ClearGuestDetails()
        End If
    End Sub

    Private Sub dgvReservations_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvReservations.KeyDown
        If dgvReservations.CurrentCell Is Nothing Then Return

        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            Me.SelectNextControl(dgvReservations, Not e.Shift, True, True, True)
            Return
        End If

        If e.KeyCode = Keys.Down Then
            MoveReservationSelection(1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If

        If e.KeyCode = Keys.Up Then
            MoveReservationSelection(-1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If
    End Sub

    Private Sub dgvReservations_SelectionChanged(sender As Object, e As EventArgs) Handles dgvReservations.SelectionChanged
        LoadSelectedReservationDetails()
    End Sub

    Private Sub dgvReservations_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReservations.CellFormatting
        Dim colName = dgvReservations.Columns(e.ColumnIndex).Name
        If colName <> "Status" Then Return

        Dim status As String = If(e.Value Is Nothing, "", e.Value.ToString()).Trim().ToUpperInvariant()
        Dim backColor As Color = Color.Empty
        Dim foreColor As Color = dgvReservations.DefaultCellStyle.ForeColor

        Select Case status
            Case "RESERVED"
                backColor = Color.FromArgb(198, 239, 206)
                foreColor = Color.FromArgb(0, 97, 0)
            Case "PENDING"
                backColor = Color.FromArgb(255, 235, 156)
                foreColor = Color.FromArgb(156, 101, 0)
            Case "CANCELLED"
                backColor = Color.FromArgb(255, 199, 206)
                foreColor = Color.FromArgb(156, 0, 6)
            Case "NO-SHOW"
                backColor = Color.FromArgb(217, 217, 217)
                foreColor = Color.FromArgb(64, 64, 64)
        End Select

        If backColor <> Color.Empty Then
            e.CellStyle.BackColor = backColor
            e.CellStyle.ForeColor = foreColor
        End If
    End Sub

    Private Sub LoadSelectedReservationDetails()
        If dgvReservations.CurrentRow Is Nothing Then
            ClearGuestDetails()
            Return
        End If
        If dgvReservations.CurrentRow.Cells("BookingID").Value Is Nothing Then
            ClearGuestDetails()
            Return
        End If

        Dim bookingId As Integer = CInt(dgvReservations.CurrentRow.Cells("BookingID").Value)
        Dim sql As String =
            "SELECT b.[Reservation No], b.[Guest Name], b.[Guest Phone], b.[Guest Email], b.[Guest Notes], " &
            " b.[Check In], b.[Check Out], b.Nights, b.[Total Amount], b.[Deposit Required], " &
            " b.[Extra Pax Qty], r.[Room No], r.[Included Pax], r.[Room Type], r.[Class] " &
            "FROM (tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID) " &
            "WHERE b.BookingID=?;"

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(sql, conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            lblGuestName.Text = rd("Guest Name").ToString()
                            lblPhone.Text = rd("Guest Phone").ToString()
                            lblEmail.Text = rd("Guest Email").ToString()
                            lblResNo.Text = $"{rd("Reservation No")}"

                            If lbNotes IsNot Nothing Then
                                lbNotes.Items.Clear()
                                Dim guestNotes As String = rd("Guest Notes").ToString()
                                If Not String.IsNullOrWhiteSpace(guestNotes) Then
                                    Dim lines = guestNotes.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
                                    For Each line In lines
                                        If line IsNot Nothing AndAlso line.Trim().Length > 0 Then
                                            lbNotes.Items.Add(line)
                                        End If
                                    Next
                                End If
                            End If

                            Dim ci As Date = CDate(rd("Check In"))
                            Dim co As Date = CDate(rd("Check Out"))
                            lblCheckIn.Text = ci.ToString("MMM d, yyyy")
                            lblCheckOut.Text = co.ToString("MMM d, yyyy")

                            lblNights.Text = SafeInt(rd("Nights")).ToString()

                            Dim totalAmount As Decimal = SafeDec(rd("Total Amount"))
                            lblTotal.Text = FormatPeso(totalAmount)

                            Dim depositRequired As Decimal = SafeDec(rd("Deposit Required"))
                            lblRequiredDeposit.Text = FormatPeso(depositRequired)

                            lblRoomNo.Text = rd("Room No").ToString()
                            Dim roomType As String = rd("Room Type").ToString()
                            Dim roomClass As String = rd("Class").ToString()
                            If roomType = "" AndAlso roomClass = "" Then
                                lblTypeClass.Text = "--------"
                            Else
                                lblTypeClass.Text = $"{roomType} / {roomClass}"
                            End If

                            Dim includedPax As Integer = SafeInt(rd("Included Pax"))
                            Dim extraPax As Integer = SafeInt(rd("Extra Pax Qty"))
                            Dim totalPax As Integer = includedPax + extraPax
                            _currentTotalPax = totalPax
                            lblTotalPax.Text = totalPax.ToString()

                            Dim paid As Decimal = GetTotalPaid(bookingId)
                            lblPaid.Text = FormatPeso(paid)
                            Dim remaining As Decimal = totalAmount - paid
                            If remaining < 0D Then remaining = 0D
                            lblRemaining.Text = FormatPeso(remaining)
                            If btnAddPayment IsNot Nothing Then
                                btnAddPayment.Enabled = (remaining > 0D)
                            End If
                            If txtPaymentAmount IsNot Nothing Then
                                txtPaymentAmount.Enabled = (remaining > 0D)
                                If remaining <= 0D Then
                                    SetPaymentPlaceholder()
                                End If
                            End If

                            Dim gridStatus As String = ""
                            If dgvReservations.Columns.Contains("Status") Then
                                gridStatus = Convert.ToString(dgvReservations.CurrentRow.Cells("Status").Value).Trim()
                            End If
                            UpdateStatusBadge(gridStatus)
                            UpdatePrimaryActionButton(gridStatus)
                        Else
                            ClearGuestDetails()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load reservation details. " & ex.Message, "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearGuestDetails()
        End Try
    End Sub

    Private Function GetTotalPaid(bookingId As Integer) As Decimal
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Dim paid As Decimal = 0D
            Dim refunded As Decimal = 0D

            Using cmdPaid As New OleDbCommand(
                "SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=?;", conn)
                cmdPaid.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                paid = SafeDec(cmdPaid.ExecuteScalar())
            End Using

            Using cmdRefund As New OleDbCommand(
                "SELECT IIf(IsNull(SUM(r.Amount)),0,SUM(r.Amount)) FROM tblRefunds AS r WHERE r.BookingID=?;", conn)
                cmdRefund.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                refunded = SafeDec(cmdRefund.ExecuteScalar())
            End Using

            Return paid - refunded
        End Using
    End Function

    Private Function MarkNoShowForLateCheckIn(bookingId As Integer) As Boolean
        If bookingId <= 0 Then Return False
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Using cmd As New OleDbCommand(
                        "UPDATE tblBookings SET [Booking Status]='No-show', UpdatedAt=? WHERE BookingID=?;", conn, tx)
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        cmd.ExecuteNonQuery()
                    End Using

                    UpdateRoomStatusAfterNoShow(bookingId, conn, tx)
                    tx.Commit()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Unable to mark no-show. " & ex.Message, "No-show", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Private Sub UpdateRoomStatusAfterNoShow(bookingId As Integer, conn As OleDbConnection, tx As OleDbTransaction)
        If bookingId <= 0 Then Return

        Dim roomId As Integer = 0

        Using cmd As New OleDbCommand(
            "SELECT RoomID FROM tblBookings WHERE BookingID=?;", conn, tx)
            cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    roomId = SafeInt(rd("RoomID"))
                End If
            End Using
        End Using

        If roomId <= 0 Then Return
        RecomputeRoomStatus(roomId, conn, tx)
    End Sub

    Private Sub ClearGuestDetails()
        lblGuestName.Text = "--------"
        lblPhone.Text = "--------"
        lblEmail.Text = "--------"
        lblResNo.Text = "--------"
        lblCheckIn.Text = "--------"
        lblCheckOut.Text = "--------"
        lblNights.Text = "--------"
        lblTotal.Text = FormatPeso(0D)
        lblRequiredDeposit.Text = FormatPeso(0D)
        lblPaid.Text = FormatPeso(0D)
        lblRemaining.Text = FormatPeso(0D)
        lblRoomNo.Text = "--------"
        lblTotalPax.Text = "--------"
        lblTypeClass.Text = "--------"
        _currentTotalPax = 0
        If lbNotes IsNot Nothing Then
            lbNotes.Items.Clear()
        End If
        If btnAddPayment IsNot Nothing Then
            btnAddPayment.Enabled = False
        End If
        If txtPaymentAmount IsNot Nothing Then
            txtPaymentAmount.Enabled = False
            SetPaymentPlaceholder()
        End If
        UpdateStatusBadge("")
        UpdatePrimaryActionButton("")
    End Sub

    Private Function IsRoomAvailableForDateRange(roomId As Integer, startDate As Date, endDate As Date, Optional excludeBookingId As Integer = -1) As Boolean
        Dim sql As String =
            "SELECT COUNT(*) FROM tblBookings " &
            "WHERE RoomID=? " &
            "  AND [Booking Status] NOT IN ('Cancelled','No-show') " &
            "  AND [Check In] < ? AND [Check Out] > ? "

        If excludeBookingId > 0 Then
            sql &= " AND BookingID <> ? "
        End If

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
                cmd.Parameters.Add("?", OleDbType.Date).Value = endDate.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = startDate.Date
                If excludeBookingId > 0 Then
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = excludeBookingId
                End If
                Return CInt(cmd.ExecuteScalar()) = 0
            End Using
        End Using
    End Function

    Private Function IsRoomAvailableForDateRangeInTx(conn As OleDbConnection, tx As OleDbTransaction, roomId As Integer, startDate As Date, endDate As Date, Optional excludeBookingId As Integer = -1) As Boolean
        Dim sql As String =
            "SELECT COUNT(*) FROM tblBookings " &
            "WHERE RoomID=? " &
            "  AND [Booking Status] NOT IN ('Cancelled','No-show') " &
            "  AND [Check In] < ? AND [Check Out] > ? "

        If excludeBookingId > 0 Then
            sql &= " AND BookingID <> ? "
        End If

        Using cmd As New OleDbCommand(sql, conn, tx)
            cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
            cmd.Parameters.Add("?", OleDbType.Date).Value = endDate.Date
            cmd.Parameters.Add("?", OleDbType.Date).Value = startDate.Date
            If excludeBookingId > 0 Then
                cmd.Parameters.Add("?", OleDbType.Integer).Value = excludeBookingId
            End If
            Return CInt(cmd.ExecuteScalar()) = 0
        End Using
    End Function

    Private Function FindEarliestAvailableEarlyCheckInDate(roomId As Integer, bookingId As Integer, searchStart As Date, originalCheckIn As Date, originalCheckOut As Date) As Date
        Dim candidate As Date = searchStart.Date
        Dim lastEarlyDate As Date = originalCheckIn.Date.AddDays(-1)

        While candidate <= lastEarlyDate
            If IsRoomAvailableForDateRange(roomId, candidate, originalCheckOut.Date, bookingId) Then
                Return candidate
            End If
            candidate = candidate.AddDays(1)
        End While

        Return originalCheckIn.Date
    End Function

    Private Function UpdateBookingForEarlyCheckIn(conn As OleDbConnection, tx As OleDbTransaction, bookingId As Integer, newCheckInDate As Date, checkOutDate As Date) As Boolean
        Dim sql As String =
            "SELECT b.[Extra Pax Qty], b.[Extra Mattress Qty], b.[Payment Requirement], b.[Deposit Percent], " &
            " r.[Base Rate], r.[Extra Pax Rate], r.[Extra Mattress Rate] " &
            "FROM (tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID) " &
            "WHERE b.BookingID=?;"

        Using cmd As New OleDbCommand(sql, conn, tx)
            cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
            Using rd = cmd.ExecuteReader()
                If Not rd.Read() Then Return False

                Dim nights As Integer = DateDiff(DateInterval.Day, newCheckInDate.Date, checkOutDate.Date)
                If nights < 1 Then nights = 1

                Dim baseRate As Decimal = SafeDec(rd("Base Rate"))
                Dim extraPaxRate As Decimal = SafeDec(rd("Extra Pax Rate"))
                Dim extraMattressRate As Decimal = SafeDec(rd("Extra Mattress Rate"))
                Dim extraPaxQty As Integer = SafeInt(rd("Extra Pax Qty"))
                Dim extraMattressQty As Integer = SafeInt(rd("Extra Mattress Qty"))

                Dim roomCharge As Decimal = Math.Round(baseRate * nights, 2, MidpointRounding.AwayFromZero)
                Dim extrasTotal As Decimal = Math.Round(
                    (extraPaxQty * extraPaxRate) + (extraMattressQty * extraMattressRate), 2, MidpointRounding.AwayFromZero)
                Dim totalAmount As Decimal = Math.Round(roomCharge + extrasTotal, 2, MidpointRounding.AwayFromZero)

                Dim paymentReq As String = rd("Payment Requirement").ToString().ToUpperInvariant()
                Dim depositPct As Integer = 0
                Integer.TryParse(rd("Deposit Percent").ToString(), depositPct)

                Dim depositRequired As Decimal
                If paymentReq = "FULL" Then
                    depositRequired = totalAmount
                Else
                    depositRequired = Math.Round(totalAmount * (depositPct / 100D), 2, MidpointRounding.AwayFromZero)
                End If

                Using cmdUp As New OleDbCommand(
                    "UPDATE tblBookings SET [Check In]=?, Nights=?, [Total Amount]=?, [Deposit Required]=?, UpdatedAt=? WHERE BookingID=?;",
                    conn, tx)
                    cmdUp.Parameters.Add("?", OleDbType.Date).Value = newCheckInDate.Date
                    cmdUp.Parameters.Add("?", OleDbType.Integer).Value = nights
                    cmdUp.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
                    cmdUp.Parameters.Add("?", OleDbType.Currency).Value = depositRequired
                    cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    cmdUp.ExecuteNonQuery()
                End Using
            End Using
        End Using

        Return True
    End Function

    Private Sub UpdatePrimaryActionButton(status As String)
        If btnConfirmCheckIn Is Nothing Then Return

        Dim upper As String = If(status, "").Trim().ToUpperInvariant()
        If upper = "CHECKED IN" Then
            btnConfirmCheckIn.Text = "VIEW STAY"
            btnConfirmCheckIn.BackColor = Color.DarkSlateGray
        Else
            btnConfirmCheckIn.Text = "CONFIRM CHECK IN"
            btnConfirmCheckIn.BackColor = Color.SeaGreen
        End If
    End Sub

    Private Sub OpenSelectedBookingInGuestStay()
        frmGuest_Stay.ReloadData()
        If dgvReservations.CurrentRow IsNot Nothing AndAlso dgvReservations.CurrentRow.Cells("BookingID").Value IsNot Nothing Then
            Dim bookingId As Integer = CInt(dgvReservations.CurrentRow.Cells("BookingID").Value)
            frmGuest_Stay.OpenForBooking(bookingId)
        End If
        frmGuest_Stay.Show()
        Me.Hide()
    End Sub

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
        Return PaymentPrefix & value.ToString("N2")
    End Function

    Private Function GetBookingTotals(bookingId As Integer, ByRef totalAmount As Decimal, ByRef totalPaid As Decimal) As Boolean
        totalAmount = 0D
        totalPaid = 0D
        If bookingId <= 0 Then Return False
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(
                "SELECT b.[Total Amount], IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) AS Paid " &
                "FROM tblBookings AS b LEFT JOIN tblPayments AS p ON b.BookingID=p.BookingID " &
                "WHERE b.BookingID=? GROUP BY b.[Total Amount];", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        totalAmount = SafeDec(rd(0))
                        totalPaid = SafeDec(rd(1))
                        Return True
                    End If
                End Using
            End Using
        End Using
        Return False
    End Function

    Private Function GetOverpaymentDecision(totalAmount As Decimal, currentPaid As Decimal, newPaid As Decimal, ByRef creditAmount As Decimal, ByRef action As Overpayment.OverpaymentAction) As Boolean
        creditAmount = 0D
        action = Overpayment.OverpaymentAction.None

        If totalAmount <= 0D Then Return True
        If newPaid <= totalAmount Then Return True

        creditAmount = newPaid - totalAmount

        Dim paymentEntered As Decimal = newPaid - currentPaid
        Using dlg As New Overpayment(totalAmount, currentPaid, paymentEntered)
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return False
            action = dlg.SelectedAction
            If action = Overpayment.OverpaymentAction.None Then Return False
        End Using
        Return True
    End Function

    Private Function GetGuestNameByBooking(bookingId As Integer) As String
        If bookingId <= 0 Then Return ""
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand("SELECT [Guest Name] FROM tblBookings WHERE BookingID=?;", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Dim v = cmd.ExecuteScalar()
                If v Is Nothing OrElse IsDBNull(v) Then Return ""
                Return v.ToString()
            End Using
        End Using
    End Function

    Private Function JoinNotesText() As String
        If lbNotes Is Nothing OrElse lbNotes.Items.Count = 0 Then Return ""
        Dim parts As New List(Of String)()
        For Each item In lbNotes.Items
            If item Is Nothing Then Continue For
            Dim s As String = item.ToString().Trim()
            If s.Length = 0 Then Continue For
            parts.Add(s)
        Next
        Return String.Join(Environment.NewLine, parts)
    End Function

    Private Sub MoveReservationSelection(delta As Integer)
        If dgvReservations.CurrentCell Is Nothing Then Return

        Dim colName As String = "Res No"
        If Not dgvReservations.Columns.Contains(colName) Then Return

        Dim targetRow As Integer = dgvReservations.CurrentCell.RowIndex + delta
        If targetRow >= dgvReservations.Rows.Count Then targetRow = 0
        If targetRow < 0 Then targetRow = dgvReservations.Rows.Count - 1

        dgvReservations.ClearSelection()
        dgvReservations.CurrentCell = dgvReservations.Rows(targetRow).Cells(colName)
        dgvReservations.Rows(targetRow).Selected = True
    End Sub

    Private Sub SelectReservationRowById(bookingId As Integer)
        If bookingId <= 0 Then Return
        If Not dgvReservations.Columns.Contains("BookingID") Then Return
        For Each row As DataGridViewRow In dgvReservations.Rows
            If row.Cells("BookingID").Value Is Nothing OrElse IsDBNull(row.Cells("BookingID").Value) Then Continue For
            If CInt(row.Cells("BookingID").Value) = bookingId Then
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible Then
                        dgvReservations.CurrentCell = cell
                        Exit For
                    End If
                Next
                row.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadReservationsGrid()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        LoadReservationsGrid()
    End Sub



    Private Sub ApplyNavState(activeButton As Button)
        Dim navButtons = New Button() {btnReservation, btnCheckingIn}
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

    Private Sub btnConfirmCheckIn_Click(sender As Object, e As EventArgs) Handles btnConfirmCheckIn.Click
        If dgvReservations.CurrentRow Is Nothing OrElse dgvReservations.CurrentRow.Cells("BookingID").Value Is Nothing Then
            MessageBox.Show("Please select a reservation first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim bookingId As Integer = CInt(dgvReservations.CurrentRow.Cells("BookingID").Value)
        Dim roomId As Integer = SafeInt(dgvReservations.CurrentRow.Cells("RoomID").Value)
        Dim status As String = ""
        If dgvReservations.Columns.Contains("Status") Then
            status = Convert.ToString(dgvReservations.CurrentRow.Cells("Status").Value).Trim()
        End If

        If status.Equals("Checked In", StringComparison.OrdinalIgnoreCase) Then
            OpenSelectedBookingInGuestStay()
            Return
        End If

        If Not status.Equals("Reserved", StringComparison.OrdinalIgnoreCase) AndAlso
           Not status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Only reserved or pending bookings can be checked in.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("No-show", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This reservation is not valid for check-in.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim plannedCheckIn As Date
        Dim plannedCheckOut As Date
        If Date.TryParse(lblCheckIn.Text, plannedCheckIn) AndAlso Date.TryParse(lblCheckOut.Text, plannedCheckOut) Then
            If Date.Today < plannedCheckIn.Date Then
                Dim earliestAvailableDate As Date = FindEarliestAvailableEarlyCheckInDate(
                    roomId, bookingId, Date.Today, plannedCheckIn.Date, plannedCheckOut.Date)

                If earliestAvailableDate = Date.Today Then
                    Dim allowEarly = MessageBox.Show(
                        "This room is available for early check-in today." & Environment.NewLine &
                        "Move the check-in date to " & Date.Today.ToString("MMMM d, yyyy") & " and continue?",
                        "Early Check-In",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                    If allowEarly <> DialogResult.Yes Then Return
                ElseIf earliestAvailableDate < plannedCheckIn.Date Then
                    MessageBox.Show(
                        "Early check-in today is not available." & Environment.NewLine &
                        "The earliest available early check-in date is " & earliestAvailableDate.ToString("MMMM d, yyyy") & ".",
                        "Early Check-In",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                    Return
                Else
                    MessageBox.Show(
                        "This room is not available for early check-in before " & plannedCheckIn.ToString("MMMM d, yyyy") & ".",
                        "Early Check-In",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                    Return
                End If
            End If

            If Date.Today > plannedCheckIn.Date Then
                Using dlg As New LateCheckInDialog()
                    If dlg.ShowDialog(Me) = DialogResult.OK Then
                        Select Case dlg.SelectedAction
                            Case LateCheckInDialog.LateCheckInAction.UpdateReservation
                                frmReservations.ReloadData()
                                frmReservations.Show()
                                Me.Hide()
                            Case LateCheckInDialog.LateCheckInAction.MarkNoShow
                                Dim confirmNoShow = MessageBox.Show(
                                    "Mark this reservation as No-show?",
                                    "Confirm No-show",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)
                                If confirmNoShow = DialogResult.Yes Then
                                    If MarkNoShowForLateCheckIn(bookingId) Then
                                        LoadReservationsGrid()
                                        SelectReservationRowById(bookingId)
                                    End If
                                End If
                        End Select
                    End If
                End Using
                Return
            End If
        Else
            MessageBox.Show("Unable to verify the reservation dates.", "Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim effectiveCheckInDate As Date = If(Date.Today < plannedCheckIn.Date, Date.Today, plannedCheckIn.Date)
        Dim effectiveCheckOutDate As Date = plannedCheckOut.Date

        Dim confirm = MessageBox.Show("Confirm check-in for this reservation?", "Confirm Check In", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                Using cmdExist As New OleDbCommand("SELECT COUNT(*) FROM tblStays WHERE BookingID=?;", conn)
                    cmdExist.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Dim existing As Integer = CInt(cmdExist.ExecuteScalar())
                    If existing > 0 Then
                        ' If a stay already exists, ensure booking/room statuses are aligned
                        Using tx = conn.BeginTransaction()
                            Using cmdUp As New OleDbCommand("UPDATE tblBookings SET [Booking Status]=?, UpdatedAt=? WHERE BookingID=?;", conn, tx)
                                cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = "Checked In"
                                cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                                cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                                cmdUp.ExecuteNonQuery()
                            End Using
                            Using cmdRoom As New OleDbCommand("UPDATE tblRooms SET [Room Status]='Occupied' WHERE RoomID=? AND [Room Status] NOT IN ('Maintenance','Inactive');", conn, tx)
                                cmdRoom.Parameters.Add("?", OleDbType.Integer).Value = roomId
                                cmdRoom.ExecuteNonQuery()
                            End Using
                            tx.Commit()
                        End Using

                        LoadReservationsGrid()
                        MessageBox.Show("This reservation is already checked in. Status refreshed.", "Already Checked In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using

                Using tx = conn.BeginTransaction()
                    ' Re-check status in DB for consistency
                    Using cmdStatus As New OleDbCommand("SELECT [Booking Status] FROM tblBookings WHERE BookingID=?;", conn, tx)
                        cmdStatus.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        Dim dbStatusObj = cmdStatus.ExecuteScalar()
                        Dim dbStatus As String = If(dbStatusObj Is Nothing OrElse IsDBNull(dbStatusObj), "", dbStatusObj.ToString())
                        If Not dbStatus.Equals("Reserved", StringComparison.OrdinalIgnoreCase) AndAlso
                           Not dbStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then
                            MessageBox.Show("This reservation is not in a valid status for check-in.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tx.Rollback()
                            Return
                        End If
                    End Using

                    ' Block check-in if room is in Maintenance/Inactive
                    Using cmdRoomStatus As New OleDbCommand("SELECT [Room Status] FROM tblRooms WHERE RoomID=?;", conn, tx)
                        cmdRoomStatus.Parameters.Add("?", OleDbType.Integer).Value = roomId
                        Dim roomStatusObj = cmdRoomStatus.ExecuteScalar()
                        Dim roomStatus As String = If(roomStatusObj Is Nothing OrElse IsDBNull(roomStatusObj), "", roomStatusObj.ToString())
                        If roomStatus.Equals("Maintenance", StringComparison.OrdinalIgnoreCase) OrElse roomStatus.Equals("Inactive", StringComparison.OrdinalIgnoreCase) Then
                            MessageBox.Show("This room is not available for check-in (" & roomStatus & ").", "Room Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tx.Rollback()
                            Return
                        End If
                    End Using

                    If Not IsRoomAvailableForDateRangeInTx(conn, tx, roomId, effectiveCheckInDate, effectiveCheckOutDate, bookingId) Then
                        MessageBox.Show("This room already has an active booking that overlaps these dates.", "Overlap Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tx.Rollback()
                        Return
                    End If

                    If effectiveCheckInDate <> plannedCheckIn.Date Then
                        If Not UpdateBookingForEarlyCheckIn(conn, tx, bookingId, effectiveCheckInDate, effectiveCheckOutDate) Then
                            MessageBox.Show("Unable to update the booking for early check-in.", "Early Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tx.Rollback()
                            Return
                        End If
                    End If

                    ' Enforce deposit requirement before check-in
                    Dim requiredDeposit As Decimal = 0D
                    Dim totalPaid As Decimal = 0D
                    Dim totalRefunded As Decimal = 0D
                    Using cmdReq As New OleDbCommand("SELECT IIf(IsNull([Deposit Required]),0,[Deposit Required]) FROM tblBookings WHERE BookingID=?;", conn, tx)
                        cmdReq.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        requiredDeposit = SafeDec(cmdReq.ExecuteScalar())
                    End Using
                    Using cmdPaid As New OleDbCommand("SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblPayments WHERE BookingID=?;", conn, tx)
                        cmdPaid.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        totalPaid = SafeDec(cmdPaid.ExecuteScalar())
                    End Using
                    Using cmdRef As New OleDbCommand("SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblRefunds WHERE BookingID=?;", conn, tx)
                        cmdRef.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        totalRefunded = SafeDec(cmdRef.ExecuteScalar())
                    End Using
                    Dim netPaid As Decimal = totalPaid - totalRefunded
                    If netPaid < requiredDeposit Then
                        MessageBox.Show("Required deposit has not been fully paid.", "Deposit Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tx.Rollback()
                        Return
                    End If

                    ' Update booking status
                    Using cmdUp As New OleDbCommand("UPDATE tblBookings SET [Booking Status]=?, UpdatedAt=? WHERE BookingID=?;", conn, tx)
                        cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = "Checked In"
                        cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        cmdUp.ExecuteNonQuery()
                    End Using

                    ' Update room status
                    Using cmdRoom As New OleDbCommand("UPDATE tblRooms SET [Room Status]='Occupied' WHERE RoomID=?;", conn, tx)
                        cmdRoom.Parameters.Add("?", OleDbType.Integer).Value = roomId
                        cmdRoom.ExecuteNonQuery()
                    End Using

                    ' Insert stay record
                    Using cmdStay As New OleDbCommand(
                        "INSERT INTO tblStays (BookingID, RoomID, [Actual Check In], [Stay Status], [Pax Count], [Notes], [Created At], [Created By User ID]) " &
                        "VALUES (?,?,?,?,?,?,?,?);", conn, tx)
                        cmdStay.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        cmdStay.Parameters.Add("?", OleDbType.Integer).Value = roomId
                        cmdStay.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdStay.Parameters.Add("?", OleDbType.VarWChar).Value = "Checked In"
                        cmdStay.Parameters.Add("?", OleDbType.Integer).Value = _currentTotalPax
                        cmdStay.Parameters.Add("?", OleDbType.LongVarWChar).Value = JoinNotesText()
                        cmdStay.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdStay.Parameters.Add("?", OleDbType.VarWChar).Value = AppSession.UserId
                        cmdStay.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using

            LoadReservationsGrid()
            SelectReservationRowById(bookingId)
            MessageBox.Show("Check-in confirmed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Unable to complete check-in. " & ex.Message, "Check-In Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnAddPayment_Click(sender As Object, e As EventArgs) Handles btnAddPayment.Click
        If dgvReservations.CurrentRow Is Nothing OrElse dgvReservations.CurrentRow.Cells("BookingID").Value Is Nothing Then
            MessageBox.Show("Please select a reservation first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim bookingId As Integer = CInt(dgvReservations.CurrentRow.Cells("BookingID").Value)

        Dim amount As Decimal
        Dim cleaned As String = txtPaymentAmount.Text.Trim().Replace(PaymentPrefix, "").Replace(",", "").Trim()
        If Not Decimal.TryParse(cleaned, amount) OrElse amount <= 0 Then
            MessageBox.Show("Enter a valid payment amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim totalAmount As Decimal = 0D
        Dim totalPaid As Decimal = 0D
        Dim creditAmount As Decimal = 0D
        Dim overpayAction As Overpayment.OverpaymentAction = Overpayment.OverpaymentAction.None
        If GetBookingTotals(bookingId, totalAmount, totalPaid) Then
            Dim newPaid As Decimal = totalPaid + amount
            If Not GetOverpaymentDecision(totalAmount, totalPaid, newPaid, creditAmount, overpayAction) Then
                Return
            End If
        End If
        If creditAmount > 0D Then
            Dim allowed As Decimal = totalAmount - totalPaid
            If allowed <= 0D Then
                MessageBox.Show("This reservation is already fully paid.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            amount = allowed
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Using cmd As New OleDbCommand(
                        "INSERT INTO tblPayments (BookingID, [Payment Date], Amount, CreatedAt) VALUES (?,?,?,?);",
                        conn, tx)
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = amount
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmd.ExecuteNonQuery()
                    End Using

                    If overpayAction = Overpayment.OverpaymentAction.GiveChange AndAlso creditAmount > 0D Then
                        MessageBox.Show("Change due: ₱" & creditAmount.ToString("N2"), "Give Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    tx.Commit()
                End Using
            End Using

            SetPaymentPlaceholder()
            LoadSelectedReservationDetails()
            MessageBox.Show("Payment added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Unable to add payment. " & ex.Message, "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SetPaymentPlaceholder()
        PaymentTextInternalUpdate = True
        txtPaymentAmount.Text = PaymentPrefix & "0.00"
        txtPaymentAmount.Tag = "placeholder"
        txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
        PaymentTextInternalUpdate = False
    End Sub

    Private Sub txtPaymentAmount_Enter(sender As Object, e As EventArgs) Handles txtPaymentAmount.Enter
        If txtPaymentAmount.Tag IsNot Nothing AndAlso txtPaymentAmount.Tag.ToString() = "placeholder" Then
            PaymentTextInternalUpdate = True
            txtPaymentAmount.Text = PaymentPrefix
            txtPaymentAmount.Tag = Nothing
            txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
            PaymentTextInternalUpdate = False
        End If
    End Sub

    Private Sub txtPaymentAmount_Leave(sender As Object, e As EventArgs) Handles txtPaymentAmount.Leave
        Dim raw As String = txtPaymentAmount.Text.Trim()
        If raw = "" OrElse raw = PaymentPrefix Then
            SetPaymentPlaceholder()
            Return
        End If

        Dim cleaned As String = raw.Replace(PaymentPrefix, "").Replace(",", "").Trim()
        Dim value As Decimal
        If Decimal.TryParse(cleaned, value) Then
            PaymentTextInternalUpdate = True
            txtPaymentAmount.Text = PaymentPrefix & value.ToString("N2", Globalization.CultureInfo.GetCultureInfo("en-PH"))
            txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
            PaymentTextInternalUpdate = False
        End If
    End Sub

    Private Sub txtPaymentAmount_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentAmount.TextChanged
        If PaymentTextInternalUpdate Then Return
        If txtPaymentAmount.Text = "" Then Return
        If Not txtPaymentAmount.Text.StartsWith(PaymentPrefix) Then
            PaymentTextInternalUpdate = True
            txtPaymentAmount.Text = PaymentPrefix & txtPaymentAmount.Text
            txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
            PaymentTextInternalUpdate = False
        End If
    End Sub

    Private Sub txtPaymentAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaymentAmount.KeyPress
        If Char.IsControl(e.KeyChar) Then Return
        If txtPaymentAmount.SelectionStart = 0 AndAlso txtPaymentAmount.SelectionLength = 0 Then
            e.Handled = True
            Return
        End If
        If Char.IsDigit(e.KeyChar) Then Return
        If e.KeyChar = "."c Then
            If txtPaymentAmount.Text.Contains(".") Then
                e.Handled = True
            End If
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub txtPaymentAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaymentAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAddPayment.PerformClick()
        End If
    End Sub

    Private Sub RefreshScreen()
        LoadReservationsGrid()
    End Sub

    Public Sub ReloadData()
        LoadReservationsGrid()
    End Sub

    Private Sub btnBilling_Click(sender As Object, e As EventArgs) Handles btnBilling.Click
        OpenSelectedBookingInGuestStay()
    End Sub

    Private Sub ConfirmExit()
        Dim result = MessageBox.Show("Are you sure you want to exit Check-In?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> DialogResult.Yes Then Return
        MainForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnSearchBooking_Click(sender As Object, e As EventArgs)
        txtSearch.Focus()
        txtSearch.SelectAll()
        LoadReservationsGrid()
    End Sub

    Private Sub btnNewWalkIn_Click(sender As Object, e As EventArgs)
        frmReservations.Show()
        frmReservations.OpenWalkIn()
        Me.Hide()
    End Sub

    Private Sub btnRefreshTop_Click(sender As Object, e As EventArgs)
        RefreshScreen()
    End Sub

    Private Sub btnExitTop_Click(sender As Object, e As EventArgs)
        ConfirmExit()
    End Sub


    Private Sub btnNoShow_Click(sender As Object, e As EventArgs)
        If dgvReservations.CurrentRow Is Nothing OrElse dgvReservations.CurrentRow.Cells("BookingID").Value Is Nothing Then
            MessageBox.Show("Please select a reservation first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim bookingId As Integer = CInt(dgvReservations.CurrentRow.Cells("BookingID").Value)
        Dim status As String = ""
        If dgvReservations.Columns.Contains("Status") Then
            status = Convert.ToString(dgvReservations.CurrentRow.Cells("Status").Value).Trim()
        End If

        If status.Equals("Checked In", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This reservation is already checked in.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("No-show", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This reservation is not valid for no-show.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm = MessageBox.Show("Mark this reservation as No-Show?", "Confirm No-Show", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Using cmdStatus As New OleDbCommand("SELECT [Booking Status] FROM tblBookings WHERE BookingID=?;", conn, tx)
                        cmdStatus.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        Dim dbStatusObj = cmdStatus.ExecuteScalar()
                        Dim dbStatus As String = If(dbStatusObj Is Nothing OrElse IsDBNull(dbStatusObj), "", dbStatusObj.ToString())
                        If Not dbStatus.Equals("Reserved", StringComparison.OrdinalIgnoreCase) Then
                            MessageBox.Show("This reservation is not in a valid status for no-show.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tx.Rollback()
                            Return
                        End If
                    End Using

                    Using cmdUp As New OleDbCommand("UPDATE tblBookings SET [Booking Status]=?, [Cancel Reason]=?, UpdatedAt=? WHERE BookingID=?;", conn, tx)
                        cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = "No-show"
                        cmdUp.Parameters.Add("?", OleDbType.LongVarWChar).Value = "No-show"
                        cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                        cmdUp.ExecuteNonQuery()
                    End Using

                    UpdateRoomStatusAfterNoShow(bookingId, conn, tx)
                    tx.Commit()
                End Using
            End Using

            LoadReservationsGrid()
            SelectReservationRowById(bookingId)
            MessageBox.Show("Reservation marked as No-Show.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Unable to mark no-show. " & ex.Message, "No-Show Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs)
        Dim rptPath As String = Path.Combine(Application.StartupPath, "CheckInForm.rpt")
        If Not File.Exists(rptPath) Then
            MessageBox.Show("Report file not found: " & rptPath, "Print")
            Return
        End If

        Try
            ShowReportPreview(rptPath)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print failed")
        End Try
    End Sub

    Private Function GetDbPathFromConnStr() As String
        Return DbConfig.GetDbPath()
    End Function

    Private Sub ApplyReportDbPath(rpt As ReportDocument)
        Dim dbPath As String = GetDbPathFromConnStr()

        If rpt.DataSourceConnections IsNot Nothing AndAlso rpt.DataSourceConnections.Count > 0 Then
            For i As Integer = 0 To rpt.DataSourceConnections.Count - 1
                Dim conn = rpt.DataSourceConnections(i)
                conn.SetConnection(dbPath, "", "", "")
            Next
        End If

        For Each tbl As Table In rpt.Database.Tables
            ApplyTableLogon(tbl, dbPath)
        Next

        For Each sr As ReportDocument In rpt.Subreports
            If sr.DataSourceConnections IsNot Nothing AndAlso sr.DataSourceConnections.Count > 0 Then
                For i As Integer = 0 To sr.DataSourceConnections.Count - 1
                    Dim conn = sr.DataSourceConnections(i)
                    conn.SetConnection(dbPath, "", "", "")
                Next
            End If

            For Each tbl As Table In sr.Database.Tables
                ApplyTableLogon(tbl, dbPath)
            Next
        Next
    End Sub

    Private Sub ApplyTableLogon(tbl As Table, dbPath As String)
        Dim logon As TableLogOnInfo = tbl.LogOnInfo
        logon.ConnectionInfo.ServerName = dbPath
        logon.ConnectionInfo.DatabaseName = dbPath
        logon.ConnectionInfo.UserID = ""
        logon.ConnectionInfo.Password = ""
        tbl.ApplyLogOnInfo(logon)

        If tbl.Location.Contains(";") Then
            tbl.Location = dbPath & ";" & tbl.Name
        End If
    End Sub

    Private Sub ShowReportPreview(rptPath As String)
        Dim preview As New Form()
        preview.Text = "Print Preview"
        preview.StartPosition = FormStartPosition.CenterParent
        preview.WindowState = FormWindowState.Maximized
        preview.MinimizeBox = True

        Dim viewer As New CrystalReportViewer()
        viewer.Dock = DockStyle.Fill
        viewer.ShowRefreshButton = False
        viewer.ShowGroupTreeButton = False
        viewer.ToolPanelView = ToolPanelViewType.None
        viewer.DisplayStatusBar = False

        preview.Controls.Add(viewer)
        preview.UseWaitCursor = True

        Dim rpt As ReportDocument = Nothing
        AddHandler preview.Shown, Sub()
                                      preview.BeginInvoke(Sub()
                                                              rpt = New ReportDocument()
                                                              rpt.Load(rptPath)
                                                              ApplyReportDbPath(rpt)
                                                              viewer.ReportSource = rpt
                                                              viewer.RefreshReport()
                                                              preview.UseWaitCursor = False
                                                          End Sub)
                                  End Sub

        AddHandler preview.FormClosed, Sub()
                                           If rpt IsNot Nothing Then rpt.Dispose()
                                       End Sub

        preview.ShowDialog(Me)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshScreen()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        ConfirmExit()
    End Sub

    Private Sub dgvReservations_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReservations.CellContentClick

    End Sub
End Class
