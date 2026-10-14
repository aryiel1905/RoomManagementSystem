Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class frmReservations

    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly PH As CultureInfo = CultureInfo.GetCultureInfo("en-PH")
    Private ReadOnly clockTimer As New Timer()

    Private SelectedRoomID As Integer = -1
    Private SelectedBookingID As Integer = -1
    Private SuppressFilterChange As Boolean = False
    Private DateFilterActive As Boolean = False
    Private IsEditMode As Boolean = False
    Private LastTabPage As TabPage = Nothing
    Private LastSelectedBookingID As Integer = -1
    Private LastOverstayPromptBookingID As Integer = -1
    Private PaymentComplete As Boolean = False
    Private PaymentBlocked As Boolean = False
    Private Const PaymentPrefix As String = "₱"
    Private PaymentTextInternalUpdate As Boolean = False

    ' Match frmRooms button disabled style
    Private ReadOnly BtnDisabledBack As Color = Color.Gray
    Private ReadOnly BtnDisabledFore As Color = Color.White
    Private ReadOnly ButtonDefaultBack As New Dictionary(Of Button, Color)()
    Private ReadOnly ButtonDefaultFore As New Dictionary(Of Button, Color)()
    Private ReadOnly ButtonDefaultUseVisual As New Dictionary(Of Button, Boolean)()
    Private ActionButtonsStyled As Boolean = False

    ' Track loaded booking values for change detection
    Private LoadedBookingID As Integer = -1
    Private OrigRoomID As Integer = -1
    Private OrigGuestName As String = ""
    Private OrigGuestPhone As String = ""
    Private OrigGuestEmail As String = ""
    Private OrigGuestNotes As String = ""
    Private OrigCheckIn As Date
    Private OrigCheckOut As Date
    Private OrigExtraPaxQty As Integer = 0
    Private OrigExtraMattressQty As Integer = 0
    Private OrigPaymentReq As String = ""
    Private OrigDepositPct As Integer = 0
    Private OrigUpdatedAt As Date = Date.MinValue

    ' Room info cache (from tblRooms)
    Private IncludedPax As Integer = 0
    Private BaseRate As Decimal = 0D
    Private ExtraPaxRate As Decimal = 0D
    Private ExtraMattressRate As Decimal = 0D

    ' -------------------- FORM LOAD --------------------
    Private Sub frmBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        InitHeaderLabels()
        InitActionButtonsStyle()
        SetPaymentPlaceholder()
        ' Defaults
        dtpCheckIn.Value = Date.Today
        dtpCheckOut.Value = Date.Today.AddDays(1)

        dtpFromDate.Format = DateTimePickerFormat.[Short]
        dtpToDate.Format = DateTimePickerFormat.[Short]
        dtpFromDate.Value = Date.Today
        dtpToDate.Value = Date.Today.AddDays(7)

        nudExtraPax.Minimum = 0
        nudExtraMattress.Minimum = 0

        ' Deposit dropdown default values (you can adjust)
        LoadDepositChoices()

        ' Load filters
        LoadFilterCombosFromDB()

        ' Load grid for active tab only
        UpdateFilterControlsForTab()
        RecomputeBookingStatusByDeposit()
        LoadActiveTabGrid()
        WireRefundButton()

        ' Custom tab strip colors
        SetupTabControlStyles()

        ResetBookingFieldsOnly()
        SyncSelectionFromActiveGrid()
        UpdateButtonStates()
    End Sub

    Private Sub InitHeaderLabels()
        If lblOperator IsNot Nothing Then
            Dim name = AppSession.CurrentUserName
            If String.IsNullOrWhiteSpace(name) Then
                lblOperator.Text = "OPERATOR: --------"
            Else
                lblOperator.Text = $"OPERATOR: {name.ToUpperInvariant()}"
            End If
        End If

        UpdateDateTimeLabel()

        clockTimer.Interval = 1000
        AddHandler clockTimer.Tick, AddressOf ClockTimer_Tick
        clockTimer.Start()
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs)
        UpdateDateTimeLabel()
    End Sub

    Private Sub UpdateDateTimeLabel()
        If lblDateTime Is Nothing Then Return
        lblDateTime.Text = Date.Now.ToString("dddd, MMM d, yyyy • hh:mm tt").ToUpperInvariant()
    End Sub

    Private Sub frmReservations_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        RemoveHandler clockTimer.Tick, AddressOf ClockTimer_Tick
        clockTimer.Stop()
    End Sub

    Private Sub WireRefundButton()
        Dim btn = Me.Controls.Find("btnRefund", True).FirstOrDefault()
        If TypeOf btn Is Button Then
            AddHandler DirectCast(btn, Button).Click, AddressOf BtnRefund_Click
        End If
    End Sub

    Private Sub BtnRefund_Click(sender As Object, e As EventArgs)
        If SelectedBookingID <= 0 Then
            MessageBox.Show("Please select a reservation first.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If TryOpenRefundModal(SelectedBookingID) Then
            RefreshPaymentSummary(SelectedBookingID)
            LoadBookingsGrid()
        End If
    End Sub

    ' -------------------- FILTERS --------------------
    Private Sub LoadFilterCombosFromDB()
        SuppressFilterChange = True
        Try
            cboRoomType.Items.Clear()
            cboRoomClass.Items.Clear()
            cboStatus.Items.Clear()

            cboRoomType.Items.Add("All Types")
            cboRoomClass.Items.Add("All Classes")
            cboStatus.Items.Add("All Status")

            Try
                Using conn As New OleDbConnection(ConnStr)
                    conn.Open()

                    Using cmd As New OleDbCommand("SELECT DISTINCT [Room Type] FROM tblRooms WHERE [Room Type] Is Not Null ORDER BY [Room Type];", conn),
                          reader = cmd.ExecuteReader()
                        While reader.Read()
                            cboRoomType.Items.Add(reader(0).ToString())
                        End While
                    End Using

                    Using cmd As New OleDbCommand("SELECT DISTINCT [Class] FROM tblRooms WHERE [Class] Is Not Null ORDER BY [Class];", conn),
                          reader = cmd.ExecuteReader()
                        While reader.Read()
                            cboRoomClass.Items.Add(reader(0).ToString())
                        End While
                    End Using

                    If TabControl1.SelectedTab Is TabPage1 Then
                        Using cmd As New OleDbCommand("SELECT DISTINCT [Room Status] FROM tblRooms WHERE [Room Status] Is Not Null AND [Room Status] NOT IN ('Maintenance','Inactive') ORDER BY [Room Status];", conn),
                              reader = cmd.ExecuteReader()
                            While reader.Read()
                                cboStatus.Items.Add(reader(0).ToString())
                            End While
                        End Using
                    Else
                        Using cmd As New OleDbCommand("SELECT DISTINCT [Booking Status] FROM tblBookings WHERE [Booking Status] IN ('Reserved','Pending','Cancelled','No-show') ORDER BY [Booking Status];", conn),
                              reader = cmd.ExecuteReader()
                            While reader.Read()
                                cboStatus.Items.Add(reader(0).ToString())
                            End While
                        End Using
                    End If

                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error loading filters", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

            cboRoomType.SelectedIndex = 0
            cboRoomClass.SelectedIndex = 0
            cboStatus.SelectedIndex = 0
        Finally
            SuppressFilterChange = False
        End Try
    End Sub

    Private Sub FilterControls_Changed(sender As Object, e As EventArgs) _
        Handles txtSearch.TextChanged, dtpFromDate.ValueChanged, dtpToDate.ValueChanged,
                cboRoomType.SelectedIndexChanged, cboRoomClass.SelectedIndexChanged, cboStatus.SelectedIndexChanged

        If SuppressFilterChange Then Return
        If sender Is dtpFromDate OrElse sender Is dtpToDate Then
            DateFilterActive = True
        End If
        LoadActiveTabGrid()
        UpdateClearFilterState()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        ClearFiltersForActiveTab()
        LoadActiveTabGrid()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        SetPaymentPlaceholder()
        If IsEditMode AndAlso HasBookingChanges() Then
            Dim confirmSwitch = MessageBox.Show(
                "Discard changes?",
                "Cancel Edit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information)
            If confirmSwitch <> DialogResult.Yes Then
                SuppressFilterChange = True
                RemoveHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged
                If LastTabPage IsNot Nothing Then
                    TabControl1.SelectedTab = LastTabPage
                End If
                AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged
                SuppressFilterChange = False
                Return
            End If
        End If
        SuppressFilterChange = True
        Try
            UpdateFilterControlsForTab()
            ClearFiltersForActiveTab()
            LoadFilterCombosFromDB()
        Finally
            SuppressFilterChange = False
        End Try
        SetPaymentPlaceholder()
        If TabControl1.SelectedTab Is TabPage1 Then
            SetEditMode(False, enableInputs:=True)
            ResetBookingFieldsOnly()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            SetEditMode(False, enableInputs:=False)
        End If
        LoadActiveTabGrid()
        If TabControl1.SelectedTab Is TabPage2 Then
            RecomputeBookingStatusByDeposit()
            SelectFirstBookingRow()
        End If
        SyncSelectionFromActiveGrid()
        UpdateClearFilterState()
        LastTabPage = TabControl1.SelectedTab
    End Sub

    Private Sub frmReservations_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ApplyNavState(btnReservation)
        LastTabPage = TabControl1.SelectedTab
    End Sub

    Private Sub LoadActiveTabGrid()
        If TabControl1.SelectedTab Is TabPage1 Then
            LoadRoomAvailabilityGrid()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            LoadBookingsGrid()
        End If
    End Sub

    Public Sub ReloadData()
        LoadActiveTabGrid()
    End Sub

    Private Sub UpdateFilterControlsForTab()
        Dim isReservationTab As Boolean = (TabControl1.SelectedTab Is TabPage2)
        dtpFromDate.Enabled = isReservationTab
        dtpToDate.Enabled = isReservationTab
    End Sub

    Private Function GetActiveGrid() As DataGridView
        If TabControl1.SelectedTab Is TabPage1 Then
            Return dgvRoomAvailability
        End If
        Return dgvBookings
    End Function

    Private Sub JumpGridSelection(toEnd As Boolean)
        Dim grid = GetActiveGrid()
        If grid Is Nothing OrElse grid.RowCount = 0 Then Return

        Dim colIndex = GetFirstVisibleColumnIndex(grid)
        If colIndex = -1 Then Return

        Dim targetRow As Integer = If(toEnd, grid.Rows.Count - 1, 0)
        grid.ClearSelection()
        grid.CurrentCell = grid.Rows(targetRow).Cells(colIndex)
        grid.Rows(targetRow).Selected = True
        SyncSelectionFromActiveGrid()
    End Sub

    Private Sub mnuBOF_Click(sender As Object, e As EventArgs) Handles mnuBOF.Click
        JumpGridSelection(False)
    End Sub

    Private Sub mnuEOF_Click(sender As Object, e As EventArgs) Handles mnuEOF.Click
        JumpGridSelection(True)
    End Sub

    Private Sub mnuNext_Click(sender As Object, e As EventArgs) Handles mnuNext.Click
        Dim grid = GetActiveGrid()
        If grid Is Nothing OrElse grid.RowCount = 0 Then Return
        MoveGridSelection(grid, 1)
        SyncSelectionFromActiveGrid()
    End Sub

    Private Sub mnuPrevious_Click(sender As Object, e As EventArgs) Handles mnuPrevious.Click
        Dim grid = GetActiveGrid()
        If grid Is Nothing OrElse grid.RowCount = 0 Then Return
        MoveGridSelection(grid, -1)
        SyncSelectionFromActiveGrid()
    End Sub

    Private Sub MoveGridSelection(grid As DataGridView, rowDelta As Integer)
        If grid.CurrentCell Is Nothing Then
            Dim firstCol = GetFirstVisibleColumnIndex(grid)
            If firstCol = -1 Then Return
            grid.CurrentCell = grid.Rows(0).Cells(firstCol)
            grid.Rows(0).Selected = True
            Return
        End If

        Dim rowIndex As Integer = grid.CurrentCell.RowIndex
        Dim colIndex As Integer = grid.CurrentCell.ColumnIndex

        rowIndex += rowDelta
        If rowIndex < 0 Then rowIndex = grid.Rows.Count - 1
        If rowIndex > grid.Rows.Count - 1 Then rowIndex = 0

        If colIndex = -1 Then Return

        grid.ClearSelection()
        grid.CurrentCell = grid.Rows(rowIndex).Cells(colIndex)
        grid.Rows(rowIndex).Selected = True
    End Sub

    Private Function GetFirstVisibleColumnIndex(grid As DataGridView) As Integer
        For i As Integer = 0 To grid.Columns.Count - 1
            If grid.Columns(i).Visible Then Return i
        Next
        Return -1
    End Function


    Private Sub SetupTabControlStyles()
        AddHandler TabControl1.DrawItem, AddressOf TabControl1_DrawItem
        AddHandler TabControl1.Paint, AddressOf TabControl1_Paint
    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs)
        Dim tab = TabControl1.TabPages(e.Index)

        ' Use the full tab bounds so we paint over any default borders
        Dim rect = e.Bounds
        Dim textRect = rect
        textRect.Inflate(-8, -4)

        Dim backColor As Color = If(tab Is TabPage1, Color.Teal, Color.Gold)
        Dim foreColor As Color = If(tab Is TabPage1, Color.White, Color.Black)

        Using b As New SolidBrush(backColor)
            e.Graphics.FillRectangle(b, rect)
        End Using

        ' Add padding via TextFormatFlags instead of shrinking the rectangle
        TextRenderer.DrawText(
            e.Graphics,
            tab.Text,
            TabControl1.Font,
            textRect,
            foreColor,
            TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.NoPadding)
    End Sub

    Private Sub TabControl1_Paint(sender As Object, e As PaintEventArgs)
        ' Paint the tab strip background to remove any remaining 3D borders/separators
        Dim stripRect As Rectangle = TabControl1.ClientRectangle
        stripRect.Height = TabControl1.ItemSize.Height + 2

        Using b As New SolidBrush(TabControl1.SelectedTab.BackColor)
            e.Graphics.FillRectangle(b, stripRect)
        End Using
    End Sub

    Private Sub ClearFiltersForActiveTab()
        SuppressFilterChange = True
        Try
            txtSearch.Clear()
            If dtpFromDate.Enabled Then dtpFromDate.Value = Date.Today
            If dtpToDate.Enabled Then dtpToDate.Value = Date.Today.AddDays(7)
            cboRoomType.SelectedIndex = 0
            cboRoomClass.SelectedIndex = 0
            cboStatus.SelectedIndex = 0
            DateFilterActive = False
        Finally
            SuppressFilterChange = False
        End Try
        UpdateClearFilterState()
    End Sub

    Private Sub UpdateClearFilterState()
        If btnClearFilter Is Nothing Then Return

        Dim active As Boolean = False
        If txtSearch.Text.Trim() <> "" Then active = True
        If cboRoomType.SelectedIndex > 0 Then active = True
        If cboRoomClass.SelectedIndex > 0 Then active = True
        If cboStatus.SelectedIndex > 0 Then active = True

        If TabControl1.SelectedTab Is TabPage2 AndAlso dtpFromDate.Enabled Then
            Dim defFrom As Date = Date.Today
            Dim defTo As Date = Date.Today.AddDays(7)
            If dtpFromDate.Value.Date <> defFrom OrElse dtpToDate.Value.Date <> defTo Then
                active = True
            End If
        End If

        btnClearFilter.Enabled = active
    End Sub

    ' -------------------- DEPOSIT CHOICES --------------------
    Private Sub LoadDepositChoices()
        cbDeposit.Items.Clear()
        cbDeposit.Items.Add("10")
        cbDeposit.Items.Add("20")
        cbDeposit.Items.Add("30")
        cbDeposit.Items.Add("40")
        cbDeposit.Items.Add("50")
        cbDeposit.Items.Add("60")
        cbDeposit.Items.Add("70")
        cbDeposit.Items.Add("80")
        cbDeposit.Items.Add("90")


        cbDeposit.SelectedItem = "30"
        rbDeposit.Checked = True
    End Sub

    Private Sub rbDeposit_CheckedChanged(sender As Object, e As EventArgs) Handles rbDeposit.CheckedChanged
        If Not CanModifyDeposit() Then
            rbDeposit.Checked = False
            rbFullPayment.Checked = True
            MessageBox.Show("Only Owner/Manager (Admin) can change deposit settings after payment.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        cbDeposit.Enabled = rbDeposit.Checked
        RecomputeAll()
    End Sub

    Private Sub rbFullPayment_CheckedChanged(sender As Object, e As EventArgs) Handles rbFullPayment.CheckedChanged
        If Not CanModifyDeposit() Then
            rbFullPayment.Checked = False
            rbDeposit.Checked = True
            MessageBox.Show("Only Owner/Manager (Admin) can change deposit settings after payment.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        cbDeposit.Enabled = rbDeposit.Checked
        RecomputeAll()
    End Sub

    Private Sub cbDeposit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDeposit.SelectedIndexChanged
        If Not CanModifyDeposit() Then
            Dim pct As Integer = 0
            Integer.TryParse(OrigDepositPct.ToString(), pct)
            cbDeposit.SelectedItem = pct.ToString()
            MessageBox.Show("Only Owner/Manager (Admin) can change deposit settings after payment.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        RecomputeAll()
    End Sub

    Private Function CanModifyDeposit() As Boolean
        ' Temporarily allow deposit changes for all users.
        Return True
    End Function

    Public Sub OpenWalkIn()
        TabControl1.SelectedTab = TabPage1
        ResetBookingFieldsOnly()
        UpdateFilterControlsForTab()
        LoadActiveTabGrid()
    End Sub

    ' -------------------- ROOM SELECTION FROM frmRooms --------------------
    Public Sub LoadSelectedRoom(roomID As Integer,
                               roomNo As String,
                               roomType As String,
                               classif As String,
                               includedPax As Integer,
                               baseRate As Decimal,
                               extraPaxRate As Decimal,
                               extraMattressRate As Decimal)

        SelectedRoomID = roomID

        Me.IncludedPax = includedPax
        Me.BaseRate = baseRate
        Me.ExtraPaxRate = extraPaxRate
        Me.ExtraMattressRate = extraMattressRate

        LoadSelectedRoomInfo(roomID)
        LoadReservationDatesForRoom(roomID)
        RecomputeAll()
        UpdateButtonStates()
    End Sub

    Private Sub LoadSelectedRoomInfo(roomId As Integer)
        Dim sql As String =
            "SELECT [Room No], [Room Type], [Class], [Included Pax], [Base Rate], [Extra Pax Rate], [Extra Mattress Rate], [RoomPhotoPath] " &
            "FROM tblRooms WHERE RoomID=?;"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        UpdateSelectedRoomBadge("lblRoomNumber", "ROOM:", rd("Room No"))
                        UpdateSelectedRoomBadge("lblRoomType", "TYPE:", rd("Room Type"))
                        UpdateSelectedRoomBadge("lblRoomClass", "CLASS:", rd("Class"))
                        IncludedPax = CInt(rd("Included Pax"))
                        BaseRate = CDec(rd("Base Rate"))
                        ExtraPaxRate = CDec(rd("Extra Pax Rate"))
                        ExtraMattressRate = CDec(rd("Extra Mattress Rate"))
                        LoadRoomPhoto(rd("RoomPhotoPath"))
                    Else
                        ClearSelectedRoomBadges()
                        pbSelectedRoom.Image = Nothing
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadReservationDatesForRoom(roomId As Integer)
        ' No reservation date list control in the current form layout.
        ' Keeping this method as a no-op to avoid compile errors and preserve call sites.
        Return
    End Sub

    Private Sub ClearRoomLabels()
        ClearSelectedRoomBadges()
        pbSelectedRoom.Image = Nothing

        IncludedPax = 0
        BaseRate = 0D
        ExtraPaxRate = 0D
        ExtraMattressRate = 0D
    End Sub

    Private Sub ClearSelectedRoomBadges()
        UpdateSelectedRoomBadge("lblRoomNumber", "ROOM:", Nothing)
        UpdateSelectedRoomBadge("lblRoomType", "TYPE:", Nothing)
        UpdateSelectedRoomBadge("lblRoomClass", "CLASS:", Nothing)
    End Sub

    Private Sub UpdateSelectedRoomBadge(labelName As String, prefix As String, value As Object)
        If gbSelectRoom Is Nothing Then Return

        Dim matches = gbSelectRoom.Controls.Find(labelName, True)
        If matches.Length = 0 Then Return

        Dim badge = TryCast(matches(0), Label)
        If badge Is Nothing Then Return

        Dim textValue As String = If(value Is Nothing OrElse IsDBNull(value), "", value.ToString().Trim())
        If textValue = "" Then
            badge.Text = prefix & " ----"
        Else
            badge.Text = prefix & " " & textValue
        End If
    End Sub

    Private Sub LoadRoomPhoto(roomPhotoPathValue As Object)
        Dim fileValue As String = If(roomPhotoPathValue Is Nothing, "", roomPhotoPathValue.ToString())
        If String.IsNullOrWhiteSpace(fileValue) Then
            pbSelectedRoom.Image = Nothing
            Return
        End If

        Dim fullPath As String
        If fileValue.StartsWith("\\") OrElse fileValue.Contains(":\") Then
            fullPath = fileValue
        Else
            fullPath = Path.Combine(RoomImagesFolder(), fileValue)
        End If

        SetPictureBoxImageSafe(pbSelectedRoom, fullPath)
    End Sub

    Private Function RoomImagesFolder() As String
        Dim dbPath = DbConfig.GetDbPath()
        Dim dbDir = Path.GetDirectoryName(dbPath)
        Return Path.Combine(dbDir, "RoomImages")
    End Function

    Private Sub SetPictureBoxImageSafe(pb As PictureBox, fullPath As String)
        Try
            If pb Is Nothing Then Return
            If String.IsNullOrWhiteSpace(fullPath) OrElse Not File.Exists(fullPath) Then
                pb.Image = Nothing
                Return
            End If

            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using img = Image.FromStream(fs)
                    pb.Image = New Bitmap(img)
                End Using
            End Using
        Catch
            If pb IsNot Nothing Then pb.Image = Nothing
        End Try
    End Sub

    ' -------------------- COMPUTATIONS --------------------
    Private Sub dtpCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckIn.ValueChanged
        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then
            dtpCheckOut.Value = dtpCheckIn.Value.Date.AddDays(1)
        End If
        RecomputeAll()
        If TabControl1.SelectedTab Is TabPage1 Then
            LoadRoomAvailabilityGrid()
        End If
    End Sub

    Private Sub dtpCheckOut_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckOut.ValueChanged
        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then
            dtpCheckOut.Value = dtpCheckIn.Value.Date.AddDays(1)
        End If
        RecomputeAll()
        If TabControl1.SelectedTab Is TabPage1 Then
            LoadRoomAvailabilityGrid()
        End If
    End Sub

    Private Sub nudExtraPax_ValueChanged(sender As Object, e As EventArgs) Handles nudExtraPax.ValueChanged
        RecomputeAll()
    End Sub

    Private Sub nudExtraMattress_ValueChanged(sender As Object, e As EventArgs) Handles nudExtraMattress.ValueChanged
        RecomputeAll()
    End Sub

    Private Sub RecomputeAll()
        ComputeNights()
        ComputeCharges()
        ComputeDepositRequired()

        If TabControl1.SelectedTab Is TabPage1 Then
            ' Availability tab: show billing only when a payment option is chosen
            If rbFullPayment.Checked OrElse rbDeposit.Checked Then
                Dim totalCharge As Decimal = SafeDec(lblTotalCharge.Text)
                Dim depositRequired As Decimal = SafeDec(lblDepositRequired.Text)

                lblTotalPaid.Text = FormatPeso(0D)
                lblTotalCharge.Text = FormatPeso(totalCharge)
                lblDepositRequired.Text = FormatPeso(depositRequired)
                lblRemainingBalance.Text = FormatPeso(totalCharge)
            Else
                lblTotalPaid.Text = FormatPeso(0D)
                lblRemainingBalance.Text = FormatPeso(0D)
                lblDepositRequired.Text = FormatPeso(0D)
                lblTotalCharge.Text = FormatPeso(0D)
            End If
        Else
            ' Reservation list tab
            If SelectedBookingID > 0 Then
                RefreshPaymentSummary(SelectedBookingID)
            Else
                lblTotalPaid.Text = FormatPeso(0D)
                lblRemainingBalance.Text = lblTotalCharge.Text
            End If
        End If

        UpdateButtonStates()
    End Sub

    Private Sub ComputeNights()
        Dim nights As Integer = DateDiff(DateInterval.Day, dtpCheckIn.Value.Date, dtpCheckOut.Value.Date)
        If nights < 1 Then nights = 1
        lblNights.Text = nights.ToString() & " Nights"
    End Sub

    Private Function GetNightsValue() As Integer
        If lblNights Is Nothing Then Return 1

        Dim raw As String = If(lblNights.Text, "").Trim()
        If raw = "" Then Return 1

        Dim firstPart As String = raw.Split(" "c)(0).Trim()
        Dim nights As Integer = 1
        If Integer.TryParse(firstPart, nights) AndAlso nights > 0 Then
            Return nights
        End If

        Return 1
    End Function

    Private Sub ComputeCharges()
        Dim nights As Integer = GetNightsValue()

        Dim extraPaxQty As Integer = CInt(nudExtraPax.Value)
        Dim extraMattressQty As Integer = CInt(nudExtraMattress.Value)

        ' Room charge is nights * base rate only
        Dim roomCharge As Decimal = Math.Round(BaseRate * nights, 2, MidpointRounding.AwayFromZero)
        lblRoomCharge.Text = FormatPeso(roomCharge)

        ' Total/Total Charge includes extras
        Dim extrasTotal As Decimal = Math.Round(
            (extraPaxQty * ExtraPaxRate) +
            (extraMattressQty * ExtraMattressRate), 2, MidpointRounding.AwayFromZero)

        Dim totalCharge As Decimal = Math.Round(roomCharge + extrasTotal, 2, MidpointRounding.AwayFromZero)
        lblAdditionals.Text = FormatPeso(extrasTotal)
        lblTotalCharge.Text = FormatPeso(totalCharge)

        ' If no booking selected, set remaining = total charge initially
        If SelectedBookingID <= 0 Then
            lblRemainingBalance.Text = FormatPeso(totalCharge)
        End If
    End Sub

    Private Sub ComputeDepositRequired()
        Dim totalCharge As Decimal = SafeDec(lblTotalCharge.Text)

        If rbFullPayment.Checked Then
            lblDepositRequired.Text = FormatPeso(Math.Round(totalCharge, 2, MidpointRounding.AwayFromZero))
        Else
            Dim pct As Decimal = 0D
            Decimal.TryParse(Convert.ToString(cbDeposit.SelectedItem), pct)
            Dim req As Decimal = Math.Round(totalCharge * (pct / 100D), 2, MidpointRounding.AwayFromZero)
            lblDepositRequired.Text = FormatPeso(req)
        End If
    End Sub

    Private Function FormatPeso(value As Decimal) As String
        Return "₱" & value.ToString("N2")
    End Function

    Private Function SafeDec(s As String) As Decimal
        Dim d As Decimal = 0D
        If s Is Nothing Then Return 0D
        Dim cleaned = s.Replace("₱", "").Replace(",", "").Trim()
        Decimal.TryParse(cleaned, d)
        Return d
    End Function

    Private Function SafeInt(value As Object) As Integer
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0
        Dim result As Integer = 0
        Integer.TryParse(value.ToString(), result)
        Return result
    End Function

    ' -------------------- ROOM AVAILABILITY GRID --------------------
    Private Sub LoadRoomAvailabilityGrid()
        Dim dt As New DataTable()
        Dim selectedRoomId As Integer = -1
        If dgvRoomAvailability.CurrentRow IsNot Nothing AndAlso dgvRoomAvailability.Columns.Contains("RoomID") Then
            Dim v = dgvRoomAvailability.CurrentRow.Cells("RoomID").Value
            If v IsNot Nothing AndAlso Not IsDBNull(v) Then
                Integer.TryParse(v.ToString(), selectedRoomId)
            End If
        End If

        Dim rangeStart As Date = dtpCheckIn.Value.Date
        Dim rangeEnd As Date = dtpCheckOut.Value.Date
        If rangeEnd <= rangeStart Then rangeEnd = rangeStart.AddDays(1)

        Dim sql As String =
            "SELECT r.RoomID, r.[Room No], r.[Room Type], r.[Class], r.[Included Pax], r.[Base Rate], " &
            " r.[Extra Pax Rate], r.[Extra Mattress Rate], " &
            " IIf(EXISTS (SELECT 1 FROM tblBookings AS b " &
            "     WHERE b.RoomID=r.RoomID AND b.[Booking Status]='Checked In' " &
            "       AND b.[Check In] < ? AND b.[Check Out] > ?), " &
            "     'Occupied', " &
            "     IIf(EXISTS (SELECT 1 FROM tblBookings AS b " &
            "         WHERE b.RoomID=r.RoomID AND b.[Booking Status]='Reserved' " &
            "           AND b.[Check In] < ? AND b.[Check Out] > ?), " &
            "         'Reserved', r.[Room Status])) AS [Room Status] " &
            "FROM tblRooms AS r " &
            "WHERE 1=1 "

        ' Search (match Room No like frmRooms)
        If txtSearch.Text.Trim() <> "" Then
            sql &= " AND r.[Room No] LIKE ? "
        End If

        ' Room Type filter
        If cboRoomType.SelectedIndex > 0 Then
            sql &= " AND r.[Room Type]=? "
        End If

        ' Room Class filter
        If cboRoomClass.SelectedIndex > 0 Then
            sql &= " AND r.[Class]=? "
        End If

        ' Status filter (availability tab uses room status)
        sql &= " AND r.[Room Status] NOT IN ('Maintenance','Inactive') "
        If cboStatus.SelectedIndex > 0 Then
            sql &= " AND r.[Room Status]=? "
        End If

        sql &= " ORDER BY r.[Room No];"

        Using conn As New OleDbConnection(ConnStr)
            Using cmd As New OleDbCommand(sql, conn)
                ' Add filters params in the same order as they appear
                cmd.Parameters.Add("?", OleDbType.Date).Value = rangeEnd.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = rangeStart.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = rangeEnd.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = rangeStart.Date

                If txtSearch.Text.Trim() <> "" Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & txtSearch.Text.Trim() & "%"
                End If
                If cboRoomType.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboRoomType.SelectedItem.ToString()
                End If
                If cboRoomClass.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboRoomClass.SelectedItem.ToString()
                End If
                If cboStatus.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboStatus.SelectedItem.ToString()
                End If

                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        dgvRoomAvailability.DataSource = dt
        dgvRoomAvailability.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvRoomAvailability.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRoomAvailability.MultiSelect = False
        dgvRoomAvailability.ReadOnly = True
        dgvRoomAvailability.AllowUserToAddRows = False
        dgvRoomAvailability.RowHeadersVisible = False

        If dgvRoomAvailability.Columns.Contains("RoomID") Then dgvRoomAvailability.Columns("RoomID").Visible = False
        FormatAvailabilityMoneyColumn("Base Rate")
        FormatAvailabilityMoneyColumn("Extra Pax Rate")
        FormatAvailabilityMoneyColumn("Extra Mattress Rate")
        ApplyAvailabilityGridColumnWidths()
        UpdateActiveGridSummary()

        If selectedRoomId > 0 Then
            SelectAvailabilityRowById(selectedRoomId)
        Else
            SelectFirstAvailabilityRow()
        End If

        If dgvRoomAvailability.CurrentRow IsNot Nothing Then
            UpdateSelectedRoomFromAvailabilityRow(dgvRoomAvailability.CurrentRow)
        End If
    End Sub

    Private Sub SelectFirstAvailabilityRow()
        If dgvRoomAvailability.Rows.Count = 0 Then Return
        dgvRoomAvailability.ClearSelection()
        Dim firstRow = dgvRoomAvailability.Rows(0)
        For Each cell As DataGridViewCell In firstRow.Cells
            If cell.Visible Then
                dgvRoomAvailability.CurrentCell = cell
                firstRow.Selected = True
                Exit Sub
            End If
        Next
    End Sub

    Private Sub SelectAvailabilityRowById(roomId As Integer)
        If roomId <= 0 Then Return
        If Not dgvRoomAvailability.Columns.Contains("RoomID") Then Return
        For Each row As DataGridViewRow In dgvRoomAvailability.Rows
            If row.Cells("RoomID").Value Is Nothing OrElse IsDBNull(row.Cells("RoomID").Value) Then Continue For
            If CInt(row.Cells("RoomID").Value) = roomId Then
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible Then
                        dgvRoomAvailability.CurrentCell = cell
                        Exit For
                    End If
                Next
                row.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub FormatAvailabilityMoneyColumn(colName As String)
        If Not dgvRoomAvailability.Columns.Contains(colName) Then Exit Sub

        With dgvRoomAvailability.Columns(colName).DefaultCellStyle
            .Format = "C0"
            .FormatProvider = PH
            .Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub ApplyAvailabilityGridColumnWidths()
        If dgvRoomAvailability.Columns.Contains("Room No") Then dgvRoomAvailability.Columns("Room No").Width = 110
        If dgvRoomAvailability.Columns.Contains("Room Type") Then dgvRoomAvailability.Columns("Room Type").Width = 120
        If dgvRoomAvailability.Columns.Contains("Class") Then dgvRoomAvailability.Columns("Class").Width = 110
        If dgvRoomAvailability.Columns.Contains("Included Pax") Then dgvRoomAvailability.Columns("Included Pax").Width = 130
        If dgvRoomAvailability.Columns.Contains("Base Rate") Then dgvRoomAvailability.Columns("Base Rate").Width = 109
        If dgvRoomAvailability.Columns.Contains("Extra Pax Rate") Then dgvRoomAvailability.Columns("Extra Pax Rate").Width = 160
        If dgvRoomAvailability.Columns.Contains("Extra Mattress Rate") Then dgvRoomAvailability.Columns("Extra Mattress Rate").Width = 200
        If dgvRoomAvailability.Columns.Contains("Room Status") Then dgvRoomAvailability.Columns("Room Status").Width = 150
    End Sub

    Private Sub SyncRoomStatusesFromBookings()
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Dim roomIds As New List(Of Integer)()
            Using cmdRooms As New OleDbCommand("SELECT RoomID FROM tblRooms WHERE [Room Status] NOT IN ('Maintenance','Inactive');", conn)
                Using rdRooms = cmdRooms.ExecuteReader()
                    While rdRooms.Read()
                        roomIds.Add(CInt(rdRooms("RoomID")))
                    End While
                End Using
            End Using

            Using tx = conn.BeginTransaction()
                For Each roomId In roomIds
                    RecomputeRoomStatus(roomId, conn, tx)
                Next
                tx.Commit()
            End Using
        End Using
    End Sub

    Private Sub dgvRoomAvailability_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRoomAvailability.CellFormatting
        Dim colName = dgvRoomAvailability.Columns(e.ColumnIndex).Name
        If colName = "Extra Pax Rate" OrElse colName = "Extra Mattress Rate" Then
            If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
                e.Value = "N/A"
                e.FormattingApplied = True
            ElseIf IsNumeric(e.Value) AndAlso Convert.ToDecimal(e.Value) = 0D Then
                e.Value = "N/A"
                e.FormattingApplied = True
            End If
        End If

        If colName = "Room Status" Then
            Dim status As String = If(e.Value Is Nothing, "", e.Value.ToString()).Trim().ToUpperInvariant()
            Dim backColor As Color = Color.Empty
            Dim foreColor As Color = dgvRoomAvailability.DefaultCellStyle.ForeColor

            Select Case status
                Case "AVAILABLE"
                    backColor = ColorTranslator.FromHtml("#D9E6F2") ' lighter Jolly Blue
                    foreColor = ColorTranslator.FromHtml("#193B55")
                Case "RESERVED"
                    backColor = Color.FromArgb(198, 239, 206) ' matches badge: RESERVED
                    foreColor = Color.FromArgb(0, 97, 0)
                Case "OCCUPIED"
                    backColor = Color.FromArgb(255, 199, 206) ' red tint for occupied
                    foreColor = Color.FromArgb(156, 0, 6)
            End Select

            If backColor <> Color.Empty Then
                e.CellStyle.BackColor = backColor
                e.CellStyle.ForeColor = foreColor
            End If
        End If
    End Sub

    Private Sub dgvBookings_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvBookings.CellFormatting
        Dim colName = dgvBookings.Columns(e.ColumnIndex).Name
        If colName <> "Booking Status" Then Return

        Dim status As String = If(e.Value Is Nothing, "", e.Value.ToString()).Trim().ToUpperInvariant()
        Dim backColor As Color = Color.Empty
        Dim foreColor As Color = dgvBookings.DefaultCellStyle.ForeColor

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
            Case "CHECKED IN"
                backColor = Color.FromArgb(189, 215, 238)
                foreColor = Color.FromArgb(0, 32, 96)
            Case "NO-SHOW"
                backColor = Color.FromArgb(217, 217, 217)
                foreColor = Color.FromArgb(64, 64, 64)
        End Select

        If backColor <> Color.Empty Then
            e.CellStyle.BackColor = backColor
            e.CellStyle.ForeColor = foreColor
        End If
    End Sub

    Private Sub dgvRoomAvailability_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRoomAvailability.SelectionChanged
        UpdateSelectedRoomFromAvailabilityRow(dgvRoomAvailability.CurrentRow)
    End Sub

    ' -------------------- BOOKINGS GRID (RESERVATION LIST) --------------------
    Private Sub LoadBookingsGrid()
        Dim dt As New DataTable()

        Dim sql As String =
            "SELECT " &
            " b.BookingID, b.RoomID, b.[Reservation No] AS [Reservation No], " &
            " r.[Room No] AS [Room No], r.[Room Type] AS [Room Type], r.[Class] AS [Class], " &
            " b.[Check In] AS [Check In], b.[Check Out] AS [Check Out], " &
            " b.Nights AS [Nights], b.[Total Amount] AS [Total Amount], " &
            " b.[Booking Status] AS [Booking Status], " &
            " (SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) AS [Total Paid], " &
            " IIf((b.[Total Amount] - " &
            "     ((SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) - " &
            "      (SELECT IIf(IsNull(SUM(rf.Amount)),0,SUM(rf.Amount)) FROM tblRefunds AS rf WHERE rf.BookingID=b.BookingID))) < 0, " &
            "     0, " &
            "     (b.[Total Amount] - " &
            "     ((SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) - " &
            "      (SELECT IIf(IsNull(SUM(rf.Amount)),0,SUM(rf.Amount)) FROM tblRefunds AS rf WHERE rf.BookingID=b.BookingID)))) AS [Remaining] " &
            "FROM (tblBookings AS b " &
            "INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID) " &
            "WHERE b.[Booking Status] IN ('Reserved','Pending') "

        ' Search filter
        Dim search As String = txtSearch.Text.Trim()
        If search <> "" Then
            sql &= " AND (b.[Reservation No] LIKE ? OR b.[Guest Name] LIKE ? OR b.[Guest Phone] LIKE ?) "
        End If

        ' Date filter (booking check-in within range) - only when user changes dates
        Dim fromDate As Date = dtpFromDate.Value.Date
        Dim toDate As Date = dtpToDate.Value.Date
        If toDate <= fromDate Then toDate = fromDate.AddDays(1)
        If DateFilterActive Then
            sql &= " AND b.[Check In] >= ? AND b.[Check In] < ? "
        End If

        ' Room type/class filters
        If cboRoomType.SelectedIndex > 0 Then
            sql &= " AND r.[Room Type]=? "
        End If
        If cboRoomClass.SelectedIndex > 0 Then
            sql &= " AND r.[Class]=? "
        End If

        ' Status filter
        If cboStatus.SelectedIndex > 0 Then
            sql &= " AND b.[Booking Status]=? "
        End If

        sql &= " ORDER BY b.CreatedAt DESC, b.BookingID DESC;"

        Using conn As New OleDbConnection(ConnStr)
            Using cmd As New OleDbCommand(sql, conn)

                If search <> "" Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & search & "%"
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & search & "%"
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & search & "%"
                End If

                If DateFilterActive Then
                    cmd.Parameters.Add("?", OleDbType.Date).Value = fromDate
                    cmd.Parameters.Add("?", OleDbType.Date).Value = toDate
                End If

                If cboRoomType.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboRoomType.SelectedItem.ToString()
                End If
                If cboRoomClass.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboRoomClass.SelectedItem.ToString()
                End If
                If cboStatus.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboStatus.SelectedItem.ToString()
                End If

                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        If Not dt.Columns.Contains("Stay") Then
            dt.Columns.Add("Stay", GetType(String))
        End If
        For Each row As DataRow In dt.Rows
            Dim ciObj = row("Check In")
            Dim coObj = row("Check Out")
            If ciObj IsNot DBNull.Value AndAlso coObj IsNot DBNull.Value Then
                Dim ci = CDate(ciObj)
                Dim co = CDate(coObj)
                Dim stayText As String
                If ci.Year = co.Year AndAlso ci.Month = co.Month Then
                    stayText = $"{ci:MMM d}–{co:%d}, {co:yyyy}"
                ElseIf ci.Year = co.Year Then
                    stayText = $"{ci:MMM d}–{co:MMM d}, {co:yyyy}"
                Else
                    stayText = $"{ci:MMM d, yyyy}–{co:MMM d, yyyy}"
                End If
                row("Stay") = stayText
            Else
                row("Stay") = ""
            End If
        Next

        dgvBookings.DataSource = dt
        dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBookings.MultiSelect = False
        dgvBookings.ReadOnly = True
        dgvBookings.AllowUserToAddRows = False
        dgvBookings.RowHeadersVisible = False

        ' Hide internal IDs
        If dgvBookings.Columns.Contains("BookingID") Then dgvBookings.Columns("BookingID").Visible = False
        If dgvBookings.Columns.Contains("RoomID") Then dgvBookings.Columns("RoomID").Visible = False
        If dgvBookings.Columns.Contains("Nights") Then dgvBookings.Columns("Nights").Visible = False
        If dgvBookings.Columns.Contains("Check In") Then dgvBookings.Columns("Check In").Visible = False
        If dgvBookings.Columns.Contains("Check Out") Then dgvBookings.Columns("Check Out").Visible = False

        ' Format money columns
        If dgvBookings.Columns.Contains("Total Amount") Then dgvBookings.Columns("Total Amount").DefaultCellStyle.Format = "N2"
        If dgvBookings.Columns.Contains("Total Paid") Then dgvBookings.Columns("Total Paid").DefaultCellStyle.Format = "N2"
        If dgvBookings.Columns.Contains("Remaining") Then dgvBookings.Columns("Remaining").DefaultCellStyle.Format = "N2"

        ApplyBookingsGridColumnWidths()
        UpdateActiveGridSummary()
    End Sub

    Private Sub UpdateActiveGridSummary()
        If lblSummary Is Nothing Then Return

        Dim activeGrid = GetActiveGrid()
        If activeGrid Is Nothing Then
            lblSummary.Text = "TOTAL ROWS: 0"
            Return
        End If

        Dim rowCount As Integer = 0
        For Each row As DataGridViewRow In activeGrid.Rows
            If Not row.IsNewRow Then
                rowCount += 1
            End If
        Next

        lblSummary.Text = $"TOTAL ROWS: {rowCount}"
    End Sub

    Private Sub SelectFirstBookingRow()
        If dgvBookings.Rows.Count = 0 Then Return
        dgvBookings.ClearSelection()
        Dim firstRow = dgvBookings.Rows(0)
        For Each cell As DataGridViewCell In firstRow.Cells
            If cell.Visible Then
                dgvBookings.CurrentCell = cell
                firstRow.Selected = True
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ApplyBookingsGridColumnWidths()
        If dgvBookings.Columns.Contains("Reservation No") Then dgvBookings.Columns("Reservation No").Width = 190
        If dgvBookings.Columns.Contains("Room No") Then dgvBookings.Columns("Room No").Width = 80
        If dgvBookings.Columns.Contains("Room Type") Then dgvBookings.Columns("Room Type").Width = 78
        If dgvBookings.Columns.Contains("Class") Then dgvBookings.Columns("Class").Width = 100
        If dgvBookings.Columns.Contains("Stay") Then dgvBookings.Columns("Stay").Width = 160
        If dgvBookings.Columns.Contains("Booking Status") Then dgvBookings.Columns("Booking Status").Width = 145
        If dgvBookings.Columns.Contains("Total Amount") Then dgvBookings.Columns("Total Amount").Width = 130
        If dgvBookings.Columns.Contains("Total Paid") Then dgvBookings.Columns("Total Paid").Width = 110
        If dgvBookings.Columns.Contains("Remaining") Then dgvBookings.Columns("Remaining").Width = 100

        If dgvBookings.Columns.Contains("Stay") AndAlso dgvBookings.Columns.Contains("Class") AndAlso dgvBookings.Columns.Contains("Total Amount") Then
            dgvBookings.Columns("Stay").DisplayIndex = dgvBookings.Columns("Class").DisplayIndex + 1
        End If
    End Sub

    Private Sub dgvBookings_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBookings.SelectionChanged
        If dgvBookings.CurrentRow Is Nothing Then Exit Sub
        If dgvBookings.CurrentRow.Cells("BookingID").Value Is Nothing Then Exit Sub

        Dim newBookingId As Integer = CInt(dgvBookings.CurrentRow.Cells("BookingID").Value)
        If LastOverstayPromptBookingID <> -1 AndAlso LastOverstayPromptBookingID <> newBookingId Then
            LastOverstayPromptBookingID = -1
        End If
        If LastSelectedBookingID > 0 AndAlso newBookingId <> LastSelectedBookingID Then
            SetPaymentPlaceholder()
        End If

        SelectedBookingID = newBookingId
        UpdateSelectedRoomFromBookingRow(dgvBookings.CurrentRow)
        LoadBookingIntoForm(SelectedBookingID, SelectedRoomID)
        HandleOverstayIfNeeded(dgvBookings.CurrentRow)
        If TabControl1.SelectedTab Is TabPage2 Then
            SetEditMode(False, enableInputs:=False)
        End If
        LastSelectedBookingID = SelectedBookingID
        UpdateButtonStates()
    End Sub

    Private Sub HandleOverstayIfNeeded(row As DataGridViewRow)
        If row Is Nothing Then Return
        Dim statusObj = row.Cells("Booking Status").Value
        If statusObj Is Nothing OrElse statusObj Is DBNull.Value Then Return
        Dim status = statusObj.ToString().Trim()
        If Not status.Equals("Checked In", StringComparison.OrdinalIgnoreCase) Then Return

        Dim checkOutObj = row.Cells("Check Out").Value
        If checkOutObj Is Nothing OrElse checkOutObj Is DBNull.Value Then Return
        Dim checkOutDate As Date = CDate(checkOutObj).Date
        If Date.Today <= checkOutDate Then Return

        Dim bookingIdObj = row.Cells("BookingID").Value
        If bookingIdObj Is Nothing OrElse bookingIdObj Is DBNull.Value Then Return
        Dim bookingId = Convert.ToInt32(bookingIdObj)
        If bookingId = LastOverstayPromptBookingID Then Return
        LastOverstayPromptBookingID = bookingId

        Using dlg As New OverstayDialog(checkOutDate)
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Select Case dlg.SelectedAction
                Case OverstayDialog.OverstayAction.CheckOut
                    CheckOut.Show()
                    Me.Hide()
                Case OverstayDialog.OverstayAction.Extend
                    Dim newCheckout = dlg.NewCheckoutDate
                    If newCheckout <= Date.Today Then
                        MessageBox.Show("New check-out must be after today.", "Extend Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                    If UpdateBookingForExtension(bookingId, newCheckout) Then
                        LoadBookingsGrid()
                        SelectBookingRowById(bookingId)
                        MessageBox.Show("Stay extended.", "Extend Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
            End Select
        End Using
    End Sub

    Private Function UpdateBookingForExtension(bookingId As Integer, newCheckout As Date) As Boolean
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Dim sql As String =
                    "SELECT b.[RoomID], b.[Check In], b.[Extra Pax Qty], b.[Extra Mattress Qty], " &
                    " b.[Payment Requirement], b.[Deposit Percent], " &
                    " r.[Base Rate], r.[Extra Pax Rate], r.[Extra Mattress Rate] " &
                    "FROM (tblBookings AS b INNER JOIN tblRooms AS r ON b.RoomID=r.RoomID) " &
                    "WHERE b.BookingID=?;"
                Using cmd As New OleDbCommand(sql, conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Using rd = cmd.ExecuteReader()
                        If Not rd.Read() Then Return False

                        Dim checkInDate As Date = CDate(rd("Check In")).Date
                        Dim nights As Integer = DateDiff(DateInterval.Day, checkInDate, newCheckout)
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
                            "UPDATE tblBookings SET [Check Out]=?, Nights=?, [Total Amount]=?, [Deposit Required]=?, UpdatedAt=? WHERE BookingID=?;", conn)
                            cmdUp.Parameters.Add("?", OleDbType.Date).Value = newCheckout
                            cmdUp.Parameters.Add("?", OleDbType.Integer).Value = nights
                            cmdUp.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
                            cmdUp.Parameters.Add("?", OleDbType.Currency).Value = depositRequired
                            cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                            cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                            cmdUp.ExecuteNonQuery()
                        End Using
                    End Using
                End Using
            End Using
            RecomputeBookingStatusByDeposit()
            Return True
        Catch ex As Exception
            MessageBox.Show("Unable to extend stay. " & ex.Message, "Extend Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Private Sub UpdateSelectedRoomFromAvailabilityRow(row As DataGridViewRow)
        If row Is Nothing Then Exit Sub
        Dim roomIdObj = row.Cells("RoomID").Value
        If roomIdObj Is Nothing OrElse IsDBNull(roomIdObj) Then Exit Sub

        Dim roomId As Integer
        If Not Integer.TryParse(roomIdObj.ToString(), roomId) Then Exit Sub

        Dim hadSelectedBooking As Boolean = (SelectedBookingID > 0)
        SelectedBookingID = -1
        LastSelectedBookingID = -1
        If hadSelectedBooking Then
            txtName.Clear()
            txtPhone.Clear()
            txtEmail.Clear()
            txtNotes.Clear()
        End If
        Dim roomStatus As String = ""
        If row.DataGridView IsNot Nothing AndAlso row.DataGridView.Columns.Contains("Room Status") Then
            Dim statusValue = row.Cells("Room Status").Value
            If statusValue IsNot Nothing AndAlso Not IsDBNull(statusValue) Then
                roomStatus = statusValue.ToString().Trim()
            End If
        End If
        UpdateBookingStatusBadge(roomStatus)

        SelectedRoomID = roomId
        LoadSelectedRoomInfo(SelectedRoomID)
        LoadReservationDatesForRoom(SelectedRoomID)
        RecomputeAll()
    End Sub

    Private Sub UpdateSelectedRoomFromBookingRow(row As DataGridViewRow)
        If row Is Nothing Then Exit Sub
        Dim roomIdObj = row.Cells("RoomID").Value
        If roomIdObj Is Nothing OrElse IsDBNull(roomIdObj) Then Exit Sub

        Dim roomId As Integer
        If Not Integer.TryParse(roomIdObj.ToString(), roomId) Then Exit Sub

        SelectedRoomID = roomId
        LoadSelectedRoomInfo(SelectedRoomID)
        LoadReservationDatesForRoom(SelectedRoomID)
    End Sub

    Private Sub SyncSelectionFromActiveGrid()
        If TabControl1.SelectedTab Is TabPage1 Then
            UpdateSelectedRoomFromAvailabilityRow(dgvRoomAvailability.CurrentRow)
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            UpdateSelectedRoomFromBookingRow(dgvBookings.CurrentRow)
        End If
    End Sub

    Private Sub SelectBookingRowById(bookingId As Integer)
        If bookingId <= 0 OrElse dgvBookings.Rows.Count = 0 Then Return
        RemoveHandler dgvBookings.SelectionChanged, AddressOf dgvBookings_SelectionChanged
        Try
            For Each row As DataGridViewRow In dgvBookings.Rows
                Dim cellVal = row.Cells("BookingID").Value
                If cellVal IsNot Nothing AndAlso CInt(cellVal) = bookingId Then
                    dgvBookings.ClearSelection()
                    Dim visibleCell As DataGridViewCell = row.Cells("Reservation No")
                    dgvBookings.CurrentCell = visibleCell
                    row.Selected = True
                    Exit For
                End If
            Next
        Finally
            AddHandler dgvBookings.SelectionChanged, AddressOf dgvBookings_SelectionChanged
        End Try
    End Sub

    Private Sub LoadBookingIntoForm(bookingId As Integer, roomId As Integer)
        ' Load room info
        LoadSelectedRoomInfo(roomId)
        SelectedRoomID = roomId

        Dim sql As String =
            "SELECT * FROM tblBookings WHERE BookingID=?;"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()

            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Guest
                        txtName.Text = rd("Guest Name").ToString()
                        txtPhone.Text = rd("Guest Phone").ToString()
                        txtEmail.Text = rd("Guest Email").ToString()
                        Dim guestNotes As String = rd("Guest Notes").ToString()
                        Dim bookingStatus As String = rd("Booking Status").ToString().Trim()
                        UpdateBookingStatusBadge(bookingStatus)
                        Dim cancelReason As String = rd("Cancel Reason").ToString()
                        If bookingStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) Then
                            If String.IsNullOrWhiteSpace(cancelReason) Then
                                cancelReason = "Cancelled"
                            End If
                            cancelReason = "Cancel Reason: " & cancelReason
                            If String.IsNullOrWhiteSpace(guestNotes) Then
                                txtNotes.Text = cancelReason
                            Else
                                txtNotes.Text = cancelReason & Environment.NewLine & Environment.NewLine & guestNotes
                            End If
                        Else
                            txtNotes.Text = guestNotes
                        End If

                        ' Dates & extras
                        dtpCheckIn.Value = CDate(rd("Check In"))
                        dtpCheckOut.Value = CDate(rd("Check Out"))
                        nudExtraPax.Value = CInt(rd("Extra Pax Qty"))
                        nudExtraMattress.Value = CInt(rd("Extra Mattress Qty"))

                        ' Payment requirement
                        Dim req As String = rd("Payment Requirement").ToString().ToUpperInvariant()
                        If req = "FULL" Then
                            rbFullPayment.Checked = True
                        Else
                            rbDeposit.Checked = True
                            Dim pct As Integer = 0
                            Integer.TryParse(rd("Deposit Percent").ToString(), pct)
                            cbDeposit.SelectedItem = pct.ToString()
                        End If

                        ' Totals (we compute again from room cache)
                        RecomputeAll()

                        If rd("UpdatedAt") IsNot DBNull.Value Then
                            OrigUpdatedAt = CDate(rd("UpdatedAt"))
                        Else
                            OrigUpdatedAt = Date.MinValue
                        End If
                    End If
                End Using
            End Using
        End Using

        RefreshPaymentSummary(bookingId)
        CaptureBookingSnapshot()
    End Sub

    Private Sub CaptureBookingSnapshot()
        LoadedBookingID = SelectedBookingID
        OrigRoomID = SelectedRoomID
        OrigGuestName = txtName.Text.Trim()
        OrigGuestPhone = txtPhone.Text.Trim()
        OrigGuestEmail = txtEmail.Text.Trim()
        OrigGuestNotes = txtNotes.Text.Trim()
        OrigCheckIn = dtpCheckIn.Value.Date
        OrigCheckOut = dtpCheckOut.Value.Date
        OrigExtraPaxQty = CInt(nudExtraPax.Value)
        OrigExtraMattressQty = CInt(nudExtraMattress.Value)
        OrigPaymentReq = If(rbFullPayment.Checked, "FULL", "PERCENT")
        Dim pct As Integer = 0
        Integer.TryParse(cbDeposit.SelectedItem?.ToString(), pct)
        OrigDepositPct = pct
    End Sub

    Private Sub UpdateBookingStatusBadge(status As String)
        Dim s As String = If(status, "").Trim()
        If s = "" Then
            lblBookingStatus.Text = "STATUS: ----"
            lblBookingStatus.BackColor = Color.LightGray
            lblBookingStatus.ForeColor = Color.Black
            Return
        End If

        Dim upper As String = s.ToUpperInvariant()
        lblBookingStatus.Text = upper

        Select Case upper
            Case "RESERVED"
                lblBookingStatus.BackColor = Color.FromArgb(198, 239, 206)
                lblBookingStatus.ForeColor = Color.FromArgb(0, 97, 0)
            Case "AVAILABLE"
                lblBookingStatus.BackColor = ColorTranslator.FromHtml("#D9E6F2")
                lblBookingStatus.ForeColor = ColorTranslator.FromHtml("#193B55")
            Case "PENDING"
                lblBookingStatus.BackColor = Color.FromArgb(255, 235, 156)
                lblBookingStatus.ForeColor = Color.FromArgb(156, 101, 0)
            Case "CANCELLED"
                lblBookingStatus.BackColor = Color.FromArgb(255, 199, 206)
                lblBookingStatus.ForeColor = Color.FromArgb(156, 0, 6)
            Case "CHECKED IN"
                lblBookingStatus.BackColor = Color.FromArgb(189, 215, 238)
                lblBookingStatus.ForeColor = Color.FromArgb(0, 32, 96)
            Case "OCCUPIED"
                lblBookingStatus.BackColor = Color.FromArgb(255, 199, 206)
                lblBookingStatus.ForeColor = Color.FromArgb(156, 0, 6)
            Case "NO-SHOW"
                lblBookingStatus.BackColor = Color.FromArgb(217, 217, 217)
                lblBookingStatus.ForeColor = Color.FromArgb(64, 64, 64)
            Case Else
                lblBookingStatus.BackColor = Color.LightGray
                lblBookingStatus.ForeColor = Color.Black
        End Select
    End Sub

    Private Function HasBookingChanges() As Boolean
        If LoadedBookingID <= 0 OrElse LoadedBookingID <> SelectedBookingID Then Return True
        If OrigRoomID <> SelectedRoomID Then Return True
        If OrigGuestName <> txtName.Text.Trim() Then Return True
        If OrigGuestPhone <> txtPhone.Text.Trim() Then Return True
        If OrigGuestEmail <> txtEmail.Text.Trim() Then Return True
        If OrigGuestNotes <> txtNotes.Text.Trim() Then Return True
        If OrigCheckIn <> dtpCheckIn.Value.Date Then Return True
        If OrigCheckOut <> dtpCheckOut.Value.Date Then Return True
        If OrigExtraPaxQty <> CInt(nudExtraPax.Value) Then Return True
        If OrigExtraMattressQty <> CInt(nudExtraMattress.Value) Then Return True
        Dim currentReq As String = If(rbFullPayment.Checked, "FULL", "PERCENT")
        If OrigPaymentReq <> currentReq Then Return True
        Dim pct As Integer = 0
        Integer.TryParse(cbDeposit.SelectedItem?.ToString(), pct)
        If OrigDepositPct <> pct Then Return True
        Return False
    End Function

    ' -------------------- PAYMENT SUMMARY --------------------
    Private Sub RefreshPaymentSummary(bookingId As Integer)
        If bookingId <= 0 Then
            lblTotalPaid.Text = FormatPeso(0D)
            lblRemainingBalance.Text = lblTotalCharge.Text
            PaymentComplete = False
            PaymentBlocked = False
            If txtPaymentAmount IsNot Nothing Then
                txtPaymentAmount.Enabled = False
                SetPaymentPlaceholder()
            End If
            UpdateCancelButtonMode()
            Return
        End If

        Try
            Dim paid As Decimal = 0D
            Dim totalAmt As Decimal = 0D

            Dim sql As String =
                "SELECT " &
                "(SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) AS Paid, " &
                "(SELECT IIf(IsNull(SUM(r.Amount)),0,SUM(r.Amount)) FROM tblRefunds AS r WHERE r.BookingID=b.BookingID) AS Refunded, " &
                "IIf(IsNull(b.[Total Amount]),0,b.[Total Amount]) AS TotalAmt " &
                "FROM tblBookings AS b " &
                "WHERE b.BookingID=?;"

            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(sql, conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            paid = SafeDec(rd("Paid"))
                            Dim refunded As Decimal = SafeDec(rd("Refunded"))
                            paid = paid - refunded
                            If paid < 0D Then paid = 0D
                            totalAmt = SafeDec(rd("TotalAmt"))
                        End If
                    End Using
                End Using
            End Using

            Dim paidRounded As Decimal = Math.Round(paid, 2, MidpointRounding.AwayFromZero)
            lblTotalPaid.Text = FormatPeso(paidRounded)

            Dim totalRounded As Decimal = Math.Round(totalAmt, 2, MidpointRounding.AwayFromZero)
            Dim remaining As Decimal = totalRounded - paidRounded
            remaining = Math.Round(remaining, 2, MidpointRounding.AwayFromZero)
            If remaining < 0 Then remaining = 0
            lblRemainingBalance.Text = FormatPeso(remaining)
            PaymentComplete = (remaining <= 0D)
            PaymentBlocked = SelectedStatusIs("No-show")
            If txtPaymentAmount IsNot Nothing Then
                txtPaymentAmount.Enabled = Not PaymentComplete AndAlso Not PaymentBlocked
                If PaymentComplete OrElse PaymentBlocked Then
                    SetPaymentPlaceholder()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to refresh payment summary. " & ex.Message, "Payment Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        UpdateCancelButtonMode()
        UpdateButtonStates()
    End Sub

    Private Function SelectedStatusIs(expected As String) As Boolean
        If dgvBookings Is Nothing OrElse dgvBookings.CurrentRow Is Nothing Then Return False
        If Not dgvBookings.Columns.Contains("Booking Status") Then Return False
        Dim v = dgvBookings.CurrentRow.Cells("Booking Status").Value
        Dim status As String = If(v Is Nothing OrElse IsDBNull(v), "", v.ToString()).Trim()
        Return status.Equals(expected, StringComparison.OrdinalIgnoreCase)
    End Function

    ' -------------------- AVAILABILITY CHECK --------------------
    Private Function IsRoomAvailable(roomId As Integer, startDate As Date, endDate As Date, Optional excludeBookingId As Integer = -1) As Boolean
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

                Dim cnt As Integer = CInt(cmd.ExecuteScalar())
                Return cnt = 0
            End Using
        End Using
    End Function

    Private Function GetOverlappingBookings(roomId As Integer, startDate As Date, endDate As Date, Optional excludeBookingId As Integer = -1) As List(Of String)
        Dim result As New List(Of String)()
        Dim sql As String =
            "SELECT [Reservation No], [Check In], [Check Out], [Booking Status] " &
            "FROM tblBookings " &
            "WHERE RoomID=? " &
            "  AND [Booking Status] NOT IN ('Cancelled','No-show') " &
            "  AND [Check In] < ? AND [Check Out] > ? "

        If excludeBookingId > 0 Then
            sql &= " AND BookingID <> ? "
        End If

        sql &= " ORDER BY [Check In] ASC;"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
                cmd.Parameters.Add("?", OleDbType.Date).Value = endDate.Date
                cmd.Parameters.Add("?", OleDbType.Date).Value = startDate.Date
                If excludeBookingId > 0 Then
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = excludeBookingId
                End If

                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim refNo As String = rd("Reservation No").ToString()
                        Dim checkIn As Date = CDate(rd("Check In"))
                        Dim checkOut As Date = CDate(rd("Check Out"))
                        Dim status As String = rd("Booking Status").ToString()
                        Dim line As String = $"{refNo} | {checkIn:MMM d}–{checkOut:MMM d, yyyy} ({status})"
                        result.Add(line)
                    End While
                End Using
            End Using
        End Using

        Return result
    End Function

    ' -------------------- BUTTON STATES --------------------
    Private Sub InitActionButtonsStyle()
        Dim buttons = New Button() {btnCreate, btnEdit, btnCancel, btnPrintSlip, btnAddPayment}
        For Each b In buttons
            If Not ButtonDefaultBack.ContainsKey(b) Then
                ButtonDefaultBack(b) = b.BackColor
                ButtonDefaultFore(b) = b.ForeColor
                ButtonDefaultUseVisual(b) = b.UseVisualStyleBackColor
            End If
        Next
        ActionButtonsStyled = True
        RefreshActionButtonsStyle()
    End Sub


    Private Sub RefreshActionButtonsStyle()
        If Not ActionButtonsStyled Then Return
        Dim buttons = New Button() {btnCreate, btnEdit, btnCancel, btnPrintSlip, btnAddPayment}
        For Each b In buttons
            Dim isEnabled As Boolean = b.Enabled
            If isEnabled Then
                If ButtonDefaultUseVisual.ContainsKey(b) Then
                    b.UseVisualStyleBackColor = ButtonDefaultUseVisual(b)
                    b.BackColor = ButtonDefaultBack(b)
                    b.ForeColor = ButtonDefaultFore(b)
                End If
            Else
                b.UseVisualStyleBackColor = False
                b.BackColor = BtnDisabledBack
                b.ForeColor = BtnDisabledFore
            End If
        Next

        If IsEditMode Then
            If btnEdit.Enabled Then
                btnEdit.UseVisualStyleBackColor = False
                btnEdit.BackColor = Color.SeaGreen
                btnEdit.ForeColor = Color.White
            End If
            If btnCancel.Enabled Then
                btnCancel.UseVisualStyleBackColor = False
                btnCancel.BackColor = Color.IndianRed
                btnCancel.ForeColor = Color.White
            End If
        End If

        If btnCancel IsNot Nothing AndAlso btnCancel.Tag IsNot Nothing AndAlso btnCancel.Tag.ToString() = "refund" Then
            btnCancel.UseVisualStyleBackColor = False
            btnCancel.BackColor = Color.IndianRed
            btnCancel.ForeColor = Color.White
        End If
    End Sub

    Private Sub UpdateButtonStates()
        Dim hasRoom As Boolean = (SelectedRoomID > 0)
        Dim hasBooking As Boolean = (SelectedBookingID > 0)
        Dim isAvailabilityTab As Boolean = (TabControl1.SelectedTab Is TabPage1)

        btnCreate.Tag = Nothing
        btnEdit.Tag = Nothing
        btnCancel.Tag = Nothing
        btnPrintSlip.Tag = Nothing
        btnAddPayment.Tag = Nothing

        If isAvailabilityTab Then
            btnCreate.Enabled = hasRoom
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnPrintSlip.Enabled = False
            btnAddPayment.Enabled = False
        Else
            btnCreate.Enabled = False
            btnEdit.Enabled = hasBooking
            btnCancel.Enabled = hasBooking
            btnPrintSlip.Enabled = hasBooking
            btnAddPayment.Enabled = hasBooking AndAlso Not PaymentComplete AndAlso Not PaymentBlocked
        End If

        btnCreate.Visible = isAvailabilityTab
        btnAddPayment.Visible = Not isAvailabilityTab
        btnEdit.Visible = Not isAvailabilityTab
        btnCancel.Visible = Not isAvailabilityTab
        btnPrintSlip.Visible = Not isAvailabilityTab

        RefreshActionButtonsStyle()
        UpdateCancelButtonMode()
    End Sub

    Private Sub SetReservationInputsEnabled(enabled As Boolean)
        txtName.Enabled = enabled
        txtPhone.Enabled = enabled
        txtEmail.Enabled = enabled
        txtNotes.Enabled = enabled

        dtpCheckIn.Enabled = enabled
        dtpCheckOut.Enabled = enabled
        nudExtraPax.Enabled = enabled
        nudExtraMattress.Enabled = enabled

        rbDeposit.Enabled = enabled
        rbFullPayment.Enabled = enabled
        cbDeposit.Enabled = enabled AndAlso rbDeposit.Checked

        If TabControl1.SelectedTab Is TabPage2 Then
            txtPaymentAmount.Enabled = Not PaymentComplete AndAlso Not PaymentBlocked
        Else
            txtPaymentAmount.Enabled = enabled
        End If
    End Sub

    Private Sub SetEditMode(editing As Boolean, enableInputs As Boolean)
        IsEditMode = editing
        SetReservationInputsEnabled(enableInputs)
        btnEdit.Text = If(editing, "SAVE RESERVATION", "UPDATE RESERVATION")
        btnCancel.Text = If(editing, "CANCEL EDIT", "CANCEL RESERVATION")
        RefreshActionButtonsStyle()
        UpdateCancelButtonMode()
    End Sub

    Private Sub UpdateCancelButtonMode()
        If btnCancel Is Nothing Then Return
        Dim isAvailabilityTab As Boolean = (TabControl1.SelectedTab Is TabPage1)
        If isAvailabilityTab OrElse SelectedBookingID <= 0 Then
            btnCancel.Text = If(IsEditMode, "CANCEL EDIT", "CANCEL RESERVATION")
            btnCancel.Tag = Nothing
            RefreshActionButtonsStyle()
            Return
        End If

        If IsEditMode Then
            btnCancel.Text = "CANCEL EDIT"
            btnCancel.Tag = Nothing
            RefreshActionButtonsStyle()
            Return
        End If

        Dim status As String = GetBookingStatusById(SelectedBookingID)
        If status = "" Then
            status = GetSelectedBookingStatus()
        End If
        Dim refundable As Decimal = 0D
        If status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("No-show", StringComparison.OrdinalIgnoreCase) Then
            Dim totalPaid As Decimal = 0D
            Dim totalRefunded As Decimal = 0D
            If GetRefundTotals(SelectedBookingID, totalPaid, totalRefunded) Then
                refundable = totalPaid - totalRefunded
            End If
        End If

        If (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("No-show", StringComparison.OrdinalIgnoreCase)) AndAlso refundable > 0D Then
            btnCancel.Text = "REFUND"
            btnCancel.Tag = "refund"
        Else
            btnCancel.Text = "CANCEL RESERVATION"
            btnCancel.Tag = Nothing
        End If

        RefreshActionButtonsStyle()
    End Sub

    Private Sub SetPaymentPlaceholder()
        PaymentTextInternalUpdate = True
        txtPaymentAmount.Text = PaymentPrefix & "0.00"
        txtPaymentAmount.Tag = "placeholder"
        txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
        PaymentTextInternalUpdate = False
    End Sub


    Private Function GetRefundTotals(bookingId As Integer, ByRef totalPaid As Decimal, ByRef totalRefunded As Decimal) As Boolean
        totalPaid = 0D
        totalRefunded = 0D
        If bookingId <= 0 Then Return False
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(
                "SELECT " &
                "(SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) AS Paid, " &
                "(SELECT IIf(IsNull(SUM(r.Amount)),0,SUM(r.Amount)) FROM tblRefunds AS r WHERE r.BookingID=b.BookingID) AS Refunded " &
                "FROM tblBookings AS b WHERE b.BookingID=?;", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        totalPaid = SafeDec(rd("Paid").ToString())
                        totalRefunded = SafeDec(rd("Refunded").ToString())
                        Return True
                    End If
                End Using
            End Using
        End Using
        Return False
    End Function

    Private Function GetBookingInfo(bookingId As Integer, ByRef resNo As String, ByRef guestName As String, ByRef status As String) As Boolean
        resNo = ""
        guestName = ""
        status = ""
        If bookingId <= 0 Then Return False
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand("SELECT [Reservation No], [Guest Name], [Booking Status] FROM tblBookings WHERE BookingID=?;", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        resNo = rd(0).ToString()
                        guestName = rd(1).ToString()
                        status = rd(2).ToString()
                        Return True
                    End If
                End Using
            End Using
        End Using
        Return False
    End Function

    Private Function TryOpenRefundModal(bookingId As Integer) As Boolean
        Dim resNo As String = ""
        Dim guestName As String = ""
        Dim status As String = ""
        If Not GetBookingInfo(bookingId, resNo, guestName, status) Then Return False
        If Not status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) AndAlso Not status.Equals("No-show", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Refunds are only allowed for cancelled or no-show reservations.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Dim totalPaid As Decimal = 0D
        Dim totalRefunded As Decimal = 0D
        If Not GetRefundTotals(bookingId, totalPaid, totalRefunded) Then Return False
        Dim refundable As Decimal = totalPaid - totalRefunded
        If refundable <= 0D Then
            MessageBox.Show("No refundable balance remaining.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Using dlg As New RefundModal(bookingId, resNo, guestName, status, totalPaid, totalRefunded)
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return False

            Dim refundAmount As Decimal = dlg.RefundAmount
            Dim reason As String = dlg.ReasonText
            If refundAmount <= 0D OrElse refundAmount > refundable Then
                MessageBox.Show("Invalid refund amount.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            If String.IsNullOrWhiteSpace(reason) Then
                MessageBox.Show("Reason is required.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "INSERT INTO tblRefunds (BookingID, Amount, [Refund Date], Reason, [Created At], [Created By User ID]) VALUES (?,?,?,?,?,?);", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = refundAmount
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = reason
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = AppSession.UserId
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Using

        Return True
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
                        totalAmount = SafeDec(rd(0).ToString())
                        totalPaid = SafeDec(rd(1).ToString())
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

    Private Function HasPaymentInput() As Boolean
        If txtPaymentAmount Is Nothing Then Return False
        If txtPaymentAmount.Tag IsNot Nothing AndAlso txtPaymentAmount.Tag.ToString() = "placeholder" Then
            Return False
        End If

        Dim hasValue As Boolean = False
        Dim value As Decimal = GetPaymentAmountValue(hasValue)
        Return hasValue AndAlso value > 0D
    End Function

    Private Function GetPaymentAmountValue(ByRef hasValue As Boolean) As Decimal
        hasValue = False
        If txtPaymentAmount Is Nothing Then Return 0D

        Dim raw As String = txtPaymentAmount.Text.Trim()
        If raw = "" OrElse raw = PaymentPrefix OrElse raw = PaymentPrefix & "0.00" OrElse raw = PaymentPrefix & "0" Then
            Return 0D
        End If

        Dim cleaned As String = raw.Replace(PaymentPrefix, "").Replace(",", "").Trim()
        Dim value As Decimal
        If Decimal.TryParse(cleaned, Globalization.NumberStyles.AllowDecimalPoint, Globalization.CultureInfo.InvariantCulture, value) Then
            hasValue = True
            Return value
        End If

        If Decimal.TryParse(cleaned, value) Then
            hasValue = True
            Return value
        End If

        Return 0D
    End Function

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

        Dim hasVal As Boolean = False
        Dim value As Decimal = GetPaymentAmountValue(hasVal)
        If hasVal Then
            If value <= 0D Then
                SetPaymentPlaceholder()
                Return
            End If
            PaymentTextInternalUpdate = True
            txtPaymentAmount.Text = PaymentPrefix & value.ToString("N2", Globalization.CultureInfo.GetCultureInfo("en-PH"))
            txtPaymentAmount.SelectionStart = txtPaymentAmount.Text.Length
            PaymentTextInternalUpdate = False
        Else
            SetPaymentPlaceholder()
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

    Private Function GetSelectedBookingStatus() As String
        If dgvBookings.CurrentRow Is Nothing Then Return ""
        If Not dgvBookings.Columns.Contains("Booking Status") Then Return ""
        Dim v = dgvBookings.CurrentRow.Cells("Booking Status").Value
        If v Is Nothing Then Return ""
        Return v.ToString()
    End Function

    Private Function GetBookingStatusById(bookingId As Integer) As String
        If bookingId <= 0 Then Return ""
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [Booking Status] FROM tblBookings WHERE BookingID=?;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                    Dim v = cmd.ExecuteScalar()
                    If v Is Nothing OrElse v Is DBNull.Value Then Return ""
                    Return v.ToString()
                End Using
            End Using
        Catch
            Return ""
        End Try
    End Function

    Private Function ValidateCreate(Optional showMessage As Boolean = True) As Boolean
        If SelectedRoomID <= 0 Then
            If showMessage Then
                MessageBox.Show("Please select a room first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        If txtName.Text.Trim() = "" OrElse txtPhone.Text.Trim() = "" Then
            If showMessage Then
                MessageBox.Show("Guest Name and Phone are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        Return True
    End Function

    Private Function ValidateRequiresBooking(Optional showMessage As Boolean = True) As Boolean
        If SelectedBookingID <= 0 Then
            If showMessage Then
                MessageBox.Show("Please select a reservation first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        Return True
    End Function

    Private Sub GuestText_Changed(sender As Object, e As EventArgs) _
        Handles txtName.TextChanged, txtPhone.TextChanged
        UpdateButtonStates()
    End Sub

    ' -------------------- NEW RESERVATION --------------------
    Private Sub btnNewReservation_Click(sender As Object, e As EventArgs)
        SelectedBookingID = -1
        ResetBookingFieldsOnly()
        UpdateButtonStates()
    End Sub

    Private Sub ResetBookingFieldsOnly()
        txtName.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        txtNotes.Clear()

        dtpCheckIn.Value = Date.Today
        dtpCheckOut.Value = Date.Today.AddDays(1)
        nudExtraPax.Value = 0
        nudExtraMattress.Value = 0

        rbDeposit.Checked = True
        cbDeposit.SelectedItem = "30"

        SetPaymentPlaceholder()

        lblTotalPaid.Text = FormatPeso(0D)
        lblRemainingBalance.Text = "--------"
        lblDepositRequired.Text = "--------"
        lblTotalCharge.Text = "--------"
        lblRoomCharge.Text = "--------"
        lblAdditionals.Text = "--------"
        lblNights.Text = "1 Nights"
        UpdateBookingStatusBadge("")

        LoadedBookingID = -1
        RecomputeAll()
    End Sub

    ' -------------------- CREATE RESERVATION --------------------
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If Not btnCreate.Enabled Then Return
        If SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a room first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim startDate As Date = dtpCheckIn.Value.Date
        Dim endDate As Date = dtpCheckOut.Value.Date
        If endDate <= startDate Then
            MessageBox.Show("Check Out must be later than Check In.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim overlaps = GetOverlappingBookings(SelectedRoomID, startDate, endDate)
        If overlaps.Count > 0 Then
            Dim details As String = String.Join(Environment.NewLine, overlaps)
            MessageBox.Show(
                "This room is not available for the selected dates:" & Environment.NewLine & details,
                "Not Available",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        If dgvRoomAvailability.CurrentRow IsNot Nothing AndAlso dgvRoomAvailability.Columns.Contains("Room Status") Then
            Dim statusObj = dgvRoomAvailability.CurrentRow.Cells("Room Status").Value
            Dim statusText As String = If(statusObj Is Nothing, "", statusObj.ToString()).Trim()
            If statusText.Equals("Occupied", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("This room is occupied.", "Occupied Room", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If
        If Not ValidateCreate() Then Return

        Dim confirmCreate = MessageBox.Show("Create this reservation now?", "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmCreate <> DialogResult.Yes Then Return

        Dim nights As Integer = GetNightsValue()
        Dim totalAmount As Decimal = SafeDec(lblTotalCharge.Text)

        Dim initialPayment As Decimal = 0D
        Dim hasInitialPayment As Boolean = False
        initialPayment = GetPaymentAmountValue(hasInitialPayment)
        If Not hasInitialPayment OrElse initialPayment <= 0D Then
            MessageBox.Show("Initial payment is required to create a reservation.", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPaymentAmount.Focus()
            Return
        End If

        Dim paymentReq As String = If(rbFullPayment.Checked, "FULL", "PERCENT")
        Dim depositPct As Integer = 0
        If paymentReq = "PERCENT" Then Integer.TryParse(cbDeposit.SelectedItem.ToString(), depositPct)

        Dim depositRequired As Decimal = SafeDec(lblDepositRequired.Text)
        Dim overpayAction As Overpayment.OverpaymentAction = Overpayment.OverpaymentAction.None
        Dim creditAmount As Decimal = 0D
        If Not GetOverpaymentDecision(totalAmount, 0D, initialPayment, creditAmount, overpayAction) Then
            Return
        End If
        If creditAmount > 0D Then
            Dim allowed As Decimal = totalAmount
            If allowed <= 0D Then
                MessageBox.Show("This reservation is already fully paid.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            MessageBox.Show("Change due: ₱" & creditAmount.ToString("N2"), "Give Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            initialPayment = allowed
        End If

        Dim insertSql As String =
            "INSERT INTO tblBookings " &
            "(RoomID, [Reservation No], [Guest Name], [Guest Phone], [Guest Email], [Guest Notes], " &
            "[Check In], [Check Out], Nights, [Extra Pax Qty], [Extra Mattress Qty], [Total Amount], " &
            "[Payment Requirement], [Deposit Percent], [Deposit Required], [Booking Status], CreatedAt, UpdatedAt) " &
            "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);"

        Dim newId As Integer = -1

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using tx = conn.BeginTransaction()
                ' Final availability check inside the transaction (prevents race conditions)
                If Not IsRoomAvailableInTx(conn, tx, SelectedRoomID, startDate, endDate, -1) Then
                    MessageBox.Show("This room is not available for the selected dates.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tx.Rollback()
                    Return
                End If
                Using cmd As New OleDbCommand(insertSql, conn, tx)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedRoomID

                    ' Temporarily blank Reservation No; we'll update after we know BookingID
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = ""

                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtName.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtPhone.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtEmail.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtNotes.Text.Trim()

                    cmd.Parameters.Add("?", OleDbType.Date).Value = startDate
                    cmd.Parameters.Add("?", OleDbType.Date).Value = endDate
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = nights
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = CInt(nudExtraPax.Value)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = CInt(nudExtraMattress.Value)
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = totalAmount

                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = paymentReq
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = depositPct
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = depositRequired

                    Dim initialStatus As String = If(depositRequired <= 0D, "Reserved", "Pending")
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = initialStatus
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now

                    cmd.ExecuteNonQuery()
                End Using

                ' Get new BookingID
                Using cmdId As New OleDbCommand("SELECT @@IDENTITY;", conn, tx)
                    newId = CInt(cmdId.ExecuteScalar())
                End Using

                ' Generate BookingRef and update
                Dim bookingRef As String = $"R#-{Date.Today:yyyyMMdd}-{newId.ToString().PadLeft(6, "0"c)}"
                Using cmdRef As New OleDbCommand("UPDATE tblBookings SET [Reservation No]=? WHERE BookingID=?;", conn, tx)
                    cmdRef.Parameters.Add("?", OleDbType.VarWChar).Value = bookingRef
                    cmdRef.Parameters.Add("?", OleDbType.Integer).Value = newId
                    cmdRef.ExecuteNonQuery()
                End Using

                ' Optional initial payment
                If initialPayment > 0D Then
                    Using cmdPay As New OleDbCommand(
                        "INSERT INTO tblPayments (BookingID, [Payment Date], Amount, [Reference No], CreatedAt) VALUES (?,?,?,?,?);",
                        conn, tx)
                        cmdPay.Parameters.Add("?", OleDbType.Integer).Value = newId
                        cmdPay.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdPay.Parameters.Add("?", OleDbType.Currency).Value = initialPayment
                        cmdPay.Parameters.Add("?", OleDbType.VarWChar).Value = DBNull.Value
                        cmdPay.Parameters.Add("?", OleDbType.Date).Value = Now
                        cmdPay.ExecuteNonQuery()
                    End Using
                End If

                tx.Commit()
            End Using
        End Using

        SelectedBookingID = newId

        If initialPayment > 0D Then
            AutoUpdateBookingStatusAfterPayment(SelectedBookingID)
        End If
        RecomputeBookingStatusByDeposit()
        LoadBookingsGrid()
        RefreshPaymentSummary(SelectedBookingID)
        SetPaymentPlaceholder()
        TabControl1.SelectedTab = TabPage2

        MessageBox.Show("Reservation created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        UpdateButtonStates()
    End Sub

    ' -------------------- UPDATE RESERVATION --------------------
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not btnEdit.Enabled Then Return
        If Not IsEditMode Then
            If Not ValidateRequiresBooking() Then Return
            SetEditMode(True, enableInputs:=True)
            txtName.Focus()
            Return
        End If
        If Not ValidateRequiresBooking() Then Return
        If SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a room.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not HasBookingChanges() Then
            MessageBox.Show("No changes to save.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm = MessageBox.Show("Save changes to this reservation?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If confirm <> DialogResult.Yes Then
            LoadBookingIntoForm(SelectedBookingID, SelectedRoomID)
            SetEditMode(False, enableInputs:=False)
            Return
        End If

        Dim startDate As Date = dtpCheckIn.Value.Date
        Dim endDate As Date = dtpCheckOut.Value.Date

        If Not IsRoomAvailable(SelectedRoomID, startDate, endDate, SelectedBookingID) Then
            MessageBox.Show("This room is not available for the selected dates.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim nights As Integer = GetNightsValue()
        Dim totalAmount As Decimal = SafeDec(lblTotalCharge.Text)

        Dim paymentReq As String = If(rbFullPayment.Checked, "FULL", "PERCENT")
        Dim depositPct As Integer = 0
        If paymentReq = "PERCENT" Then Integer.TryParse(cbDeposit.SelectedItem.ToString(), depositPct)

        Dim depositRequired As Decimal = SafeDec(lblDepositRequired.Text)

        Dim sql As String =
            "UPDATE tblBookings SET " &
            "RoomID=?, [Guest Name]=?, [Guest Phone]=?, [Guest Email]=?, [Guest Notes]=?, " &
            "[Check In]=?, [Check Out]=?, Nights=?, [Extra Pax Qty]=?, [Extra Mattress Qty]=?, [Total Amount]=?, " &
            "[Payment Requirement]=?, [Deposit Percent]=?, [Deposit Required]=?, UpdatedAt=? " &
            "WHERE BookingID=? AND UpdatedAt=?;"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using tx = conn.BeginTransaction()
                If Not IsRoomAvailableInTx(conn, tx, SelectedRoomID, startDate, endDate, SelectedBookingID) Then
                    MessageBox.Show("This room is not available for the selected dates.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tx.Rollback()
                    Return
                End If

                Using cmd As New OleDbCommand(sql, conn, tx)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedRoomID
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtName.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtPhone.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtEmail.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = txtNotes.Text.Trim()

                    cmd.Parameters.Add("?", OleDbType.Date).Value = startDate
                    cmd.Parameters.Add("?", OleDbType.Date).Value = endDate
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = nights
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = CInt(nudExtraPax.Value)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = CInt(nudExtraMattress.Value)
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = totalAmount

                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = paymentReq
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = depositPct
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = depositRequired
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now

                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                    cmd.Parameters.Add("?", OleDbType.Date).Value = OrigUpdatedAt

                    Dim rows = cmd.ExecuteNonQuery()
                    If rows = 0 Then
                        tx.Rollback()
                        MessageBox.Show("This reservation was modified by another user. Reloading latest data.", "Conflict Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadBookingIntoForm(SelectedBookingID, SelectedRoomID)
                        SetEditMode(False, enableInputs:=False)
                        Return
                    End If
                End Using

                tx.Commit()
            End Using
        End Using

        AutoUpdateBookingStatusAfterPayment(SelectedBookingID)
        RecomputeBookingStatusByDeposit()
        LoadBookingsGrid()
        RefreshPaymentSummary(SelectedBookingID)
        CaptureBookingSnapshot()
        MessageBox.Show("Reservation updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        SetEditMode(False, enableInputs:=False)
    End Sub

    ' -------------------- CANCEL RESERVATION --------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Not btnCancel.Enabled Then Return
        If btnCancel.Tag IsNot Nothing AndAlso btnCancel.Tag.ToString() = "refund" Then
            If Not ValidateRequiresBooking() Then Return
            TryOpenRefundModal(SelectedBookingID)
            RefreshPaymentSummary(SelectedBookingID)
            Return
        End If
        If IsEditMode Then
            If Not ValidateRequiresBooking() Then Return
            If HasBookingChanges() Then
                Dim confirmEditCancel = MessageBox.Show(
                    "Discard changes?",
                    "Cancel Edit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information)
                If confirmEditCancel <> DialogResult.Yes Then Return
            End If
            LoadBookingIntoForm(SelectedBookingID, SelectedRoomID)
            SetEditMode(False, enableInputs:=False)
            Return
        End If
        If Not ValidateRequiresBooking() Then Return

        Dim currentStatus As String = GetBookingStatusById(SelectedBookingID)
        If currentStatus = "" Then currentStatus = GetSelectedBookingStatus()
        If currentStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse currentStatus.Equals("No-show", StringComparison.OrdinalIgnoreCase) Then
            Dim totalPaid As Decimal = 0D
            Dim totalRefunded As Decimal = 0D
            Dim refundable As Decimal = 0D
            If GetRefundTotals(SelectedBookingID, totalPaid, totalRefunded) Then
                refundable = totalPaid - totalRefunded
            End If
            If refundable > 0D Then
                Dim statusLabel = If(currentStatus.Equals("No-show", StringComparison.OrdinalIgnoreCase), "no-show", "cancelled")
                MessageBox.Show("This reservation is already " & statusLabel & ". A refund is available—use the REFUND button.", "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim statusLabel = If(currentStatus.Equals("No-show", StringComparison.OrdinalIgnoreCase), "no-show", "cancelled")
                MessageBox.Show("This reservation is already " & statusLabel & ". No refundable balance remains.", "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return
        End If
        If currentStatus.Equals("Checked In", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Cannot cancel a reservation that is already checked in.", "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm = MessageBox.Show("Cancel this reservation?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If confirm <> DialogResult.Yes Then Return

        Dim reason As String = "Cancelled"

        Dim sql As String =
            "UPDATE tblBookings SET [Booking Status]=?, [Cancel Reason]=?, UpdatedAt=? " &
            "WHERE BookingID=? AND [Booking Status] NOT IN ('Cancelled','Checked In');"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "Cancelled"
                cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = reason
                cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows = 0 Then
                    MessageBox.Show("Status changed. Please refresh and try again.", "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End Using

        End Using

        LoadBookingsGrid()
        RecomputeBookingStatusByDeposit()
        UpdateRoomStatusAfterCancellation(SelectedBookingID)
        SyncRoomStatusesFromBookings()

        TryOpenRefundModal(SelectedBookingID)

        MessageBox.Show("Reservation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UpdateRoomStatusAfterCancellation(bookingId As Integer)
        If bookingId <= 0 Then Return
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()

            Dim roomId As Integer = 0

            Using cmd As New OleDbCommand(
                "SELECT RoomID FROM tblBookings WHERE BookingID=?;", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        roomId = If(IsDBNull(rd("RoomID")), 0, Convert.ToInt32(rd("RoomID")))
                    End If
                End Using
            End Using

            If roomId <= 0 Then Return
            RecomputeRoomStatus(roomId, conn, Nothing)
        End Using
    End Sub

    ' -------------------- ADD PAYMENT --------------------
    Private Sub btnAddPayment_Click(sender As Object, e As EventArgs) Handles btnAddPayment.Click
        If Not btnAddPayment.Enabled Then Return
        If SelectedBookingID <= 0 Then
            MessageBox.Show("Please select a reservation first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim amount As Decimal
        Dim hasPay As Boolean = False
        amount = GetPaymentAmountValue(hasPay)
        If Not hasPay OrElse amount <= 0D Then
            MessageBox.Show("Enter a valid payment amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        Dim totalAmount As Decimal = 0D
        Dim totalPaid As Decimal = 0D
        Dim creditAmount As Decimal = 0D
        Dim overpayAction As Overpayment.OverpaymentAction = Overpayment.OverpaymentAction.None
        If GetBookingTotals(SelectedBookingID, totalAmount, totalPaid) Then
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
            MessageBox.Show("Change due: ₱" & creditAmount.ToString("N2"), "Give Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            amount = allowed
        End If

        Dim sql As String =
            "INSERT INTO tblPayments (BookingID, [Payment Date], Amount, CreatedAt) " &
            "VALUES (?,?,?,?);"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using tx = conn.BeginTransaction()
                Using cmd As New OleDbCommand(sql, conn, tx)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedBookingID
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.Currency).Value = amount
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using
        End Using

        ' After payment: refresh summary and auto-set booking status based on Deposit Required
        SetPaymentPlaceholder()
        AutoUpdateBookingStatusAfterPayment(SelectedBookingID)
        RecomputeBookingStatusByDeposit()
        LoadBookingsGrid()
        RefreshPaymentSummary(SelectedBookingID)

        MessageBox.Show("Payment added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AutoUpdateBookingStatusAfterPayment(bookingId As Integer)
        Dim paid As Decimal = 0D
        Dim refunded As Decimal = 0D
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()

            Using cmdPaid As New OleDbCommand("SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblPayments WHERE BookingID=?;", conn)
                cmdPaid.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                paid = CDec(cmdPaid.ExecuteScalar())
            End Using

            Using cmdRefund As New OleDbCommand("SELECT IIf(IsNull(SUM(Amount)),0,SUM(Amount)) FROM tblRefunds WHERE BookingID=?;", conn)
                cmdRefund.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                refunded = CDec(cmdRefund.ExecuteScalar())
            End Using

            Dim depReq As Decimal = 0D
            Using cmdReq As New OleDbCommand("SELECT IIf(IsNull([Deposit Required]),0,[Deposit Required]) FROM tblBookings WHERE BookingID=?;", conn)
                cmdReq.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                depReq = CDec(cmdReq.ExecuteScalar())
            End Using

            Dim netPaid As Decimal = paid - refunded
            If netPaid < 0D Then netPaid = 0D

            Dim newStatus As String
            If depReq <= 0D Then
                newStatus = "Reserved"
            ElseIf netPaid >= depReq Then
                newStatus = "Reserved"
            Else
                newStatus = "Pending"
            End If

            ' If FULL payment requirement is used, Deposit Required equals Total Amount (so this still works)
            Using cmdUp As New OleDbCommand("UPDATE tblBookings SET [Booking Status]=?, UpdatedAt=? WHERE BookingID=?;", conn)
                cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = newStatus
                cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                cmdUp.ExecuteNonQuery()
            End Using

            Dim roomId As Integer = 0
            Using cmdRoomId As New OleDbCommand("SELECT RoomID FROM tblBookings WHERE BookingID=?;", conn)
                cmdRoomId.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                Dim roomIdObj = cmdRoomId.ExecuteScalar()
                If roomIdObj IsNot Nothing AndAlso roomIdObj IsNot DBNull.Value Then
                    roomId = CInt(roomIdObj)
                End If
            End Using
            If roomId > 0 Then
                RecomputeRoomStatus(roomId, conn, Nothing)
            End If
        End Using
    End Sub

    Private Function IsRoomAvailableInTx(conn As OleDbConnection, tx As OleDbTransaction, roomId As Integer, startDate As Date, endDate As Date, Optional excludeBookingId As Integer = -1) As Boolean
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

            Dim cnt As Integer = CInt(cmd.ExecuteScalar())
            Return cnt = 0
        End Using
    End Function

    ' -------------------- PRINT SLIP (placeholder) --------------------
    Private Sub btnPrintSlip_Click(sender As Object, e As EventArgs) Handles btnPrintSlip.Click
        If Not btnPrintSlip.Enabled Then Return
        If Not ValidateRequiresBooking() Then Return

        Try
            Dim rptPath As String = Path.Combine(Application.StartupPath, "ReservationSlip.rpt")
            If Not File.Exists(rptPath) Then
                MessageBox.Show("Report file not found: " & rptPath, "Print Slip")
                Return
            End If

            btnPrintSlip.Enabled = False

            Dim rpt As New ReportDocument()
            rpt.Load(rptPath)
            ApplyReportDbPath(rpt)
            ApplyReportParameters(rpt, SelectedBookingID)
            ShowReportPreview(rpt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print Slip failed")
        Finally
            btnPrintSlip.Enabled = True
        End Try
    End Sub

    ' -------------------- NAVIGATION --------------------
    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim result = MessageBox.Show(
          "Are you sure you want to exit the Reservations?",
          "Exit Confirmation",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
      )

        If result = DialogResult.Yes Then
            MainForm.Show()
            Me.Hide()
        End If
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
    Private Sub btnCheckingIn_Click(sender As Object, e As EventArgs) Handles btnCheckingIn.Click
        If btnCheckingIn.Tag IsNot Nothing Then Return
        frmCheckIn.ReloadData()
        frmCheckIn.Show()
        Me.Hide()
    End Sub

    Private Sub MenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub

    Private Sub tsmnuRefresh_Click(sender As Object, e As EventArgs) Handles tsmnuRefresh.Click
        RecomputeBookingStatusByDeposit()
        LoadActiveTabGrid()
        If TabControl1.SelectedTab Is TabPage1 Then
            If dgvRoomAvailability.CurrentRow IsNot Nothing Then
                UpdateSelectedRoomFromAvailabilityRow(dgvRoomAvailability.CurrentRow)
            End If
        Else
            If dgvBookings.CurrentRow IsNot Nothing Then
                UpdateSelectedRoomFromBookingRow(dgvBookings.CurrentRow)
            End If
        End If
    End Sub

    Private Sub RecomputeBookingStatusByDeposit()
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                Dim sql As String =
                    "SELECT b.BookingID, " &
                    " IIf(IsNull(b.[Deposit Required]),0,b.[Deposit Required]) AS DepReq, " &
                    " (SELECT IIf(IsNull(SUM(p.Amount)),0,SUM(p.Amount)) FROM tblPayments AS p WHERE p.BookingID=b.BookingID) AS Paid, " &
                    " (SELECT IIf(IsNull(SUM(r.Amount)),0,SUM(r.Amount)) FROM tblRefunds AS r WHERE r.BookingID=b.BookingID) AS Refunded, " &
                    " b.[Booking Status] AS CurrStatus, b.RoomID " &
                    "FROM tblBookings AS b " &
                    "WHERE b.[Booking Status] NOT IN ('Cancelled','No-show','Checked In');"

                Dim items As New List(Of Tuple(Of Integer, Integer, Decimal, Decimal, Decimal, String))()
                Using cmd As New OleDbCommand(sql, conn)
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim bookingId As Integer = CInt(rd("BookingID"))
                            Dim roomId As Integer = If(IsDBNull(rd("RoomID")), 0, CInt(rd("RoomID")))
                            Dim depReq As Decimal = CDec(rd("DepReq"))
                            Dim paid As Decimal = CDec(rd("Paid"))
                            Dim refunded As Decimal = CDec(rd("Refunded"))
                            Dim currStatus As String = rd("CurrStatus").ToString()
                            items.Add(Tuple.Create(bookingId, roomId, depReq, paid, refunded, currStatus))
                        End While
                    End Using
                End Using

                Using tx = conn.BeginTransaction()
                    For Each item In items
                        Dim bookingId = item.Item1
                        Dim roomId = item.Item2
                        Dim depReq = item.Item3
                        Dim paid = item.Item4
                        Dim refunded = item.Item5
                        Dim currStatus = item.Item6
                        Dim netPaid = paid - refunded
                        If netPaid < 0D Then netPaid = 0D

                        Dim newStatus As String
                        If depReq <= 0D OrElse netPaid >= depReq Then
                            newStatus = "Reserved"
                        Else
                            newStatus = "Pending"
                        End If

                        If Not String.Equals(currStatus, newStatus, StringComparison.OrdinalIgnoreCase) Then
                            Using cmdUp As New OleDbCommand("UPDATE tblBookings SET [Booking Status]=?, UpdatedAt=? WHERE BookingID=?;", conn, tx)
                                cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = newStatus
                                cmdUp.Parameters.Add("?", OleDbType.Date).Value = Now
                                cmdUp.Parameters.Add("?", OleDbType.Integer).Value = bookingId
                                cmdUp.ExecuteNonQuery()
                            End Using
                        End If

                        If roomId > 0 Then
                            RecomputeRoomStatus(roomId, conn, tx)
                        End If
                    Next

                    tx.Commit()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to recompute booking status. " & ex.Message, "Recompute Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' -------------------- REPORT SUPPORT --------------------
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

    Private Sub ShowReportPreview(rpt As ReportDocument)
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
        viewer.ReuseParameterValuesOnRefresh = True
        viewer.ReportSource = rpt
        viewer.RefreshReport()

        preview.Controls.Add(viewer)
        AddHandler preview.FormClosed, Sub()
                                           rpt.Dispose()
                                       End Sub
        preview.ShowDialog(Me)
    End Sub

    Private Sub ApplyReportParameters(rpt As ReportDocument, bookingId As Integer)
        ApplyParameterValue(rpt, "pBookingId", bookingId)

        For Each sr As ReportDocument In rpt.Subreports
            ApplyParameterValue(sr, "pBookingId", bookingId)
        Next
    End Sub

    Private Sub ApplyParameterValue(doc As ReportDocument, paramName As String, value As Object)
        Try
            Dim fields = doc.DataDefinition.ParameterFields
            If fields Is Nothing OrElse fields.Count = 0 Then Return

            For Each pf As ParameterFieldDefinition In fields
                If String.Equals(pf.Name, paramName, StringComparison.OrdinalIgnoreCase) Then
                    Dim vals As New ParameterValues()
                    Dim v As New ParameterDiscreteValue()
                    v.Value = value
                    vals.Add(v)
                    pf.ApplyCurrentValues(vals)
                    Exit For
                End If
            Next
        Catch
            ' Ignore if parameter does not exist in this report/subreport
        End Try
    End Sub

    Private Sub txtNotes_TextChanged(sender As Object, e As EventArgs) Handles txtNotes.TextChanged

    End Sub

    Private Sub btnBilling_Click(sender As Object, e As EventArgs) Handles btnBilling.Click
        frmGuest_Stay.ReloadData()
        If SelectedBookingID > 0 Then
            frmGuest_Stay.OpenForBooking(SelectedBookingID)
        End If
        frmGuest_Stay.Show()
        Me.Hide()
    End Sub

    Private Sub pbSelectedRoom_Click(sender As Object, e As EventArgs) Handles pbSelectedRoom.Click

    End Sub
End Class
