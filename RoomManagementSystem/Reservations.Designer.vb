<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReservations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservations))
        Me.lblAdditionals = New System.Windows.Forms.Label()
        Me.lblNights = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nudExtraMattress = New System.Windows.Forms.NumericUpDown()
        Me.lblRoomCharge = New System.Windows.Forms.Label()
        Me.dtpCheckOut = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpCheckIn = New System.Windows.Forms.DateTimePicker()
        Me.nudExtraPax = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvBookings = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboRoomClass = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboRoomType = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvRoomAvailability = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblRemainingBalance = New System.Windows.Forms.Label()
        Me.rbDeposit = New System.Windows.Forms.RadioButton()
        Me.rbFullPayment = New System.Windows.Forms.RadioButton()
        Me.cbDeposit = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblDepositRequired = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTotalCharge = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.gbBillingSummary = New System.Windows.Forms.GroupBox()
        Me.btnAddPayment = New System.Windows.Forms.Button()
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox()
        Me.gbGuestDetails = New System.Windows.Forms.GroupBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.gbPayment = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBilling = New System.Windows.Forms.Button()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.btnCheckingIn = New System.Windows.Forms.Button()
        Me.btnPrintSlip = New System.Windows.Forms.Button()
        Me.mnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigatioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBOF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrevious = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEOF = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.pbSelectedRoom = New System.Windows.Forms.PictureBox()
        Me.lblBookingStatus = New System.Windows.Forms.Label()
        Me.gbSelectRoom = New System.Windows.Forms.GroupBox()
        Me.lblRoomNumber = New System.Windows.Forms.Label()
        Me.lblRoomType = New System.Windows.Forms.Label()
        Me.lblRoomClass = New System.Windows.Forms.Label()
        CType(Me.nudExtraMattress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExtraPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvRoomAvailability, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbBillingSummary.SuspendLayout()
        Me.gbGuestDetails.SuspendLayout()
        Me.gbPayment.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.pbSelectedRoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectRoom.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAdditionals
        '
        Me.lblAdditionals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdditionals.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdditionals.Location = New System.Drawing.Point(237, 294)
        Me.lblAdditionals.Name = "lblAdditionals"
        Me.lblAdditionals.Size = New System.Drawing.Size(171, 32)
        Me.lblAdditionals.TabIndex = 60
        Me.lblAdditionals.Text = "--------"
        Me.lblAdditionals.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNights
        '
        Me.lblNights.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNights.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNights.Location = New System.Drawing.Point(210, 128)
        Me.lblNights.Name = "lblNights"
        Me.lblNights.Size = New System.Drawing.Size(198, 32)
        Me.lblNights.TabIndex = 52
        Me.lblNights.Text = "--------"
        Me.lblNights.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label19.Location = New System.Drawing.Point(29, 300)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 28)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "Extras:"
        '
        'nudExtraMattress
        '
        Me.nudExtraMattress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudExtraMattress.Location = New System.Drawing.Point(255, 212)
        Me.nudExtraMattress.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudExtraMattress.Name = "nudExtraMattress"
        Me.nudExtraMattress.Size = New System.Drawing.Size(153, 34)
        Me.nudExtraMattress.TabIndex = 49
        '
        'lblRoomCharge
        '
        Me.lblRoomCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRoomCharge.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomCharge.Location = New System.Drawing.Point(237, 249)
        Me.lblRoomCharge.Name = "lblRoomCharge"
        Me.lblRoomCharge.Size = New System.Drawing.Size(171, 38)
        Me.lblRoomCharge.TabIndex = 58
        Me.lblRoomCharge.Text = "--------"
        Me.lblRoomCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpCheckOut
        '
        Me.dtpCheckOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckOut.Location = New System.Drawing.Point(212, 91)
        Me.dtpCheckOut.Name = "dtpCheckOut"
        Me.dtpCheckOut.Size = New System.Drawing.Size(196, 34)
        Me.dtpCheckOut.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Location = New System.Drawing.Point(29, 261)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(144, 28)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Room Charge:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label13.Location = New System.Drawing.Point(29, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 28)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Extra Pax:"
        '
        'dtpCheckIn
        '
        Me.dtpCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckIn.Location = New System.Drawing.Point(212, 46)
        Me.dtpCheckIn.Name = "dtpCheckIn"
        Me.dtpCheckIn.Size = New System.Drawing.Size(196, 34)
        Me.dtpCheckIn.TabIndex = 41
        '
        'nudExtraPax
        '
        Me.nudExtraPax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudExtraPax.Location = New System.Drawing.Point(255, 170)
        Me.nudExtraPax.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudExtraPax.Name = "nudExtraPax"
        Me.nudExtraPax.Size = New System.Drawing.Size(153, 34)
        Me.nudExtraPax.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(29, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 28)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Extra Mattress:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(29, 134)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 28)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Nights:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Location = New System.Drawing.Point(29, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 28)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "To:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label16.Location = New System.Drawing.Point(29, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 28)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "From:"
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPaid.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPaid.Location = New System.Drawing.Point(155, 253)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Size = New System.Drawing.Size(184, 41)
        Me.lblTotalPaid.TabIndex = 46
        Me.lblTotalPaid.Text = "--------"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(26, 294)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 56)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Remaining Balance:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(26, 260)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 28)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Total Paid:"
        '
        'dgvBookings
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvBookings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBookings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBookings.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvBookings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBookings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBookings.EnableHeadersVisualStyles = False
        Me.dgvBookings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvBookings.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvBookings.Location = New System.Drawing.Point(13, 16)
        Me.dgvBookings.Name = "dgvBookings"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBookings.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBookings.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.InfoText
        Me.dgvBookings.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBookings.RowTemplate.Height = 28
        Me.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBookings.Size = New System.Drawing.Size(1481, 261)
        Me.dgvBookings.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSearch)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox5.Location = New System.Drawing.Point(16, 56)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(295, 69)
        Me.GroupBox5.TabIndex = 57
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(17, 27)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 27)
        Me.txtSearch.TabIndex = 56
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(19, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(0, 26)
        Me.Label20.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboStatus)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox2.Location = New System.Drawing.Point(1256, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(274, 69)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboStatus.Location = New System.Drawing.Point(16, 28)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(240, 28)
        Me.cboStatus.TabIndex = 13
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboRoomClass)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox4.Location = New System.Drawing.Point(1008, 56)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(233, 69)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Room Class"
        '
        'cboRoomClass
        '
        Me.cboRoomClass.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboRoomClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoomClass.FormattingEnabled = True
        Me.cboRoomClass.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboRoomClass.Location = New System.Drawing.Point(18, 26)
        Me.cboRoomClass.Name = "cboRoomClass"
        Me.cboRoomClass.Size = New System.Drawing.Size(185, 28)
        Me.cboRoomClass.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboRoomType)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox3.Location = New System.Drawing.Point(721, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(270, 69)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Room Type"
        '
        'cboRoomType
        '
        Me.cboRoomType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboRoomType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoomType.FormattingEnabled = True
        Me.cboRoomType.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboRoomType.Location = New System.Drawing.Point(16, 27)
        Me.cboRoomType.Name = "cboRoomType"
        Me.cboRoomType.Size = New System.Drawing.Size(234, 28)
        Me.cboRoomType.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpToDate)
        Me.GroupBox1.Controls.Add(Me.dtpFromDate)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox1.Location = New System.Drawing.Point(322, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 70)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(179, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 26)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "to"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 26)
        Me.Label4.TabIndex = 55
        '
        'dtpToDate
        '
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(217, 28)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(152, 29)
        Me.dtpToDate.TabIndex = 1
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(17, 27)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(152, 29)
        Me.dtpFromDate.TabIndex = 0
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.Teal
        Me.btnClearFilter.Location = New System.Drawing.Point(1548, 56)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(360, 69)
        Me.btnClearFilter.TabIndex = 15
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(200, 36)
        Me.TabControl1.Location = New System.Drawing.Point(16, 513)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1518, 334)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 56
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Teal
        Me.TabPage1.Controls.Add(Me.dgvRoomAvailability)
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1510, 290)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Room Availability"
        '
        'dgvRoomAvailability
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvRoomAvailability.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRoomAvailability.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRoomAvailability.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvRoomAvailability.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRoomAvailability.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRoomAvailability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRoomAvailability.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvRoomAvailability.EnableHeadersVisualStyles = False
        Me.dgvRoomAvailability.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRoomAvailability.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvRoomAvailability.Location = New System.Drawing.Point(15, 17)
        Me.dgvRoomAvailability.Name = "dgvRoomAvailability"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRoomAvailability.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvRoomAvailability.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.InfoText
        Me.dgvRoomAvailability.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvRoomAvailability.RowTemplate.Height = 28
        Me.dgvRoomAvailability.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRoomAvailability.Size = New System.Drawing.Size(1481, 260)
        Me.dgvRoomAvailability.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Gold
        Me.TabPage2.Controls.Add(Me.dgvBookings)
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1510, 290)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reservation List"
        '
        'lblRemainingBalance
        '
        Me.lblRemainingBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemainingBalance.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemainingBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRemainingBalance.Location = New System.Drawing.Point(155, 294)
        Me.lblRemainingBalance.Name = "lblRemainingBalance"
        Me.lblRemainingBalance.Size = New System.Drawing.Size(184, 56)
        Me.lblRemainingBalance.TabIndex = 58
        Me.lblRemainingBalance.Text = "--------"
        Me.lblRemainingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbDeposit
        '
        Me.rbDeposit.AutoSize = True
        Me.rbDeposit.Checked = True
        Me.rbDeposit.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.rbDeposit.Location = New System.Drawing.Point(15, 24)
        Me.rbDeposit.Name = "rbDeposit"
        Me.rbDeposit.Size = New System.Drawing.Size(143, 32)
        Me.rbDeposit.TabIndex = 53
        Me.rbDeposit.TabStop = True
        Me.rbDeposit.Text = "Deposit (%)"
        Me.rbDeposit.UseVisualStyleBackColor = True
        '
        'rbFullPayment
        '
        Me.rbFullPayment.AutoSize = True
        Me.rbFullPayment.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.rbFullPayment.Location = New System.Drawing.Point(15, 67)
        Me.rbFullPayment.Name = "rbFullPayment"
        Me.rbFullPayment.Size = New System.Drawing.Size(156, 32)
        Me.rbFullPayment.TabIndex = 54
        Me.rbFullPayment.Text = "Full Payment"
        Me.rbFullPayment.UseVisualStyleBackColor = True
        '
        'cbDeposit
        '
        Me.cbDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDeposit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbDeposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDeposit.FormattingEnabled = True
        Me.cbDeposit.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cbDeposit.Location = New System.Drawing.Point(159, 28)
        Me.cbDeposit.Name = "cbDeposit"
        Me.cbDeposit.Size = New System.Drawing.Size(138, 28)
        Me.cbDeposit.TabIndex = 55
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.rbFullPayment)
        Me.GroupBox6.Controls.Add(Me.cbDeposit)
        Me.GroupBox6.Controls.Add(Me.rbDeposit)
        Me.GroupBox6.Location = New System.Drawing.Point(24, 32)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(315, 114)
        Me.GroupBox6.TabIndex = 56
        Me.GroupBox6.TabStop = False
        '
        'lblDepositRequired
        '
        Me.lblDepositRequired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDepositRequired.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepositRequired.Location = New System.Drawing.Point(231, 194)
        Me.lblDepositRequired.Name = "lblDepositRequired"
        Me.lblDepositRequired.Size = New System.Drawing.Size(108, 42)
        Me.lblDepositRequired.TabIndex = 62
        Me.lblDepositRequired.Text = "--------"
        Me.lblDepositRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label21.Location = New System.Drawing.Point(27, 208)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(181, 28)
        Me.Label21.TabIndex = 61
        Me.Label21.Text = "Required Deposit:"
        '
        'lblTotalCharge
        '
        Me.lblTotalCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCharge.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCharge.Location = New System.Drawing.Point(199, 160)
        Me.lblTotalCharge.Name = "lblTotalCharge"
        Me.lblTotalCharge.Size = New System.Drawing.Size(140, 34)
        Me.lblTotalCharge.TabIndex = 64
        Me.lblTotalCharge.Text = "--------"
        Me.lblTotalCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label23.Location = New System.Drawing.Point(26, 166)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(136, 28)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "Total Charge:"
        '
        'gbBillingSummary
        '
        Me.gbBillingSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBillingSummary.Controls.Add(Me.Label10)
        Me.gbBillingSummary.Controls.Add(Me.lblDepositRequired)
        Me.gbBillingSummary.Controls.Add(Me.Label11)
        Me.gbBillingSummary.Controls.Add(Me.lblTotalPaid)
        Me.gbBillingSummary.Controls.Add(Me.lblTotalCharge)
        Me.gbBillingSummary.Controls.Add(Me.lblRemainingBalance)
        Me.gbBillingSummary.Controls.Add(Me.GroupBox6)
        Me.gbBillingSummary.Controls.Add(Me.Label21)
        Me.gbBillingSummary.Controls.Add(Me.Label23)
        Me.gbBillingSummary.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBillingSummary.Location = New System.Drawing.Point(1548, 148)
        Me.gbBillingSummary.Name = "gbBillingSummary"
        Me.gbBillingSummary.Size = New System.Drawing.Size(360, 373)
        Me.gbBillingSummary.TabIndex = 65
        Me.gbBillingSummary.TabStop = False
        Me.gbBillingSummary.Text = "BlILLING SUMMARY"
        '
        'btnAddPayment
        '
        Me.btnAddPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPayment.BackColor = System.Drawing.Color.Teal
        Me.btnAddPayment.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPayment.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAddPayment.Location = New System.Drawing.Point(1550, 725)
        Me.btnAddPayment.Name = "btnAddPayment"
        Me.btnAddPayment.Size = New System.Drawing.Size(360, 58)
        Me.btnAddPayment.TabIndex = 66
        Me.btnAddPayment.Text = "COLLECT PAYMENT"
        Me.btnAddPayment.UseVisualStyleBackColor = False
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaymentAmount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentAmount.Location = New System.Drawing.Point(22, 82)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPaymentAmount.Size = New System.Drawing.Size(315, 61)
        Me.txtPaymentAmount.TabIndex = 64
        '
        'gbGuestDetails
        '
        Me.gbGuestDetails.Controls.Add(Me.txtNotes)
        Me.gbGuestDetails.Controls.Add(Me.txtEmail)
        Me.gbGuestDetails.Controls.Add(Me.txtPhone)
        Me.gbGuestDetails.Controls.Add(Me.txtName)
        Me.gbGuestDetails.Controls.Add(Me.Label24)
        Me.gbGuestDetails.Controls.Add(Me.Label32)
        Me.gbGuestDetails.Controls.Add(Me.Label34)
        Me.gbGuestDetails.Controls.Add(Me.Label36)
        Me.gbGuestDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGuestDetails.Location = New System.Drawing.Point(562, 148)
        Me.gbGuestDetails.Name = "gbGuestDetails"
        Me.gbGuestDetails.Size = New System.Drawing.Size(502, 350)
        Me.gbGuestDetails.TabIndex = 66
        Me.gbGuestDetails.TabStop = False
        Me.gbGuestDetails.Text = "GUEST DETAILS"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(108, 194)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(366, 60)
        Me.txtNotes.TabIndex = 60
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(108, 145)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(366, 34)
        Me.txtEmail.TabIndex = 59
        '
        'txtPhone
        '
        Me.txtPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhone.Location = New System.Drawing.Point(108, 88)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(366, 34)
        Me.txtPhone.TabIndex = 58
        '
        'txtName
        '
        Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(108, 41)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(366, 34)
        Me.txtName.TabIndex = 57
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label24.Location = New System.Drawing.Point(21, 194)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 26)
        Me.Label24.TabIndex = 40
        Me.Label24.Text = "Notes:"
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label32.Location = New System.Drawing.Point(21, 145)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 26)
        Me.Label32.TabIndex = 34
        Me.Label32.Text = "Email:"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label34.Location = New System.Drawing.Point(21, 88)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(76, 26)
        Me.Label34.TabIndex = 33
        Me.Label34.Text = "Phone:"
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label36.Location = New System.Drawing.Point(21, 45)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(68, 26)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "Name"
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.BackColor = System.Drawing.Color.Teal
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft PhagsPa", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCreate.Location = New System.Drawing.Point(1550, 725)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(360, 122)
        Me.btnCreate.TabIndex = 67
        Me.btnCreate.Text = "CREATE RESERVATION"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.Teal
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Location = New System.Drawing.Point(1550, 789)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(238, 58)
        Me.btnEdit.TabIndex = 68
        Me.btnEdit.Text = "UPDATE RESERVATION"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Teal
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(1792, 789)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 58)
        Me.btnCancel.TabIndex = 69
        Me.btnCancel.Text = "CANCEL RESERVATION"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(1742, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(153, 35)
        Me.btnBack.TabIndex = 8
        Me.btnBack.Text = "< Go Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'gbPayment
        '
        Me.gbPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPayment.Controls.Add(Me.Label1)
        Me.gbPayment.Controls.Add(Me.txtPaymentAmount)
        Me.gbPayment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPayment.Location = New System.Drawing.Point(1550, 541)
        Me.gbPayment.Name = "gbPayment"
        Me.gbPayment.Size = New System.Drawing.Size(358, 169)
        Me.gbPayment.TabIndex = 67
        Me.gbPayment.TabStop = False
        Me.gbPayment.Text = "PAYMENT "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 28)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Payment Amount"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.btnBilling)
        Me.Panel1.Controls.Add(Me.lblSummary)
        Me.Panel1.Controls.Add(Me.btnReservation)
        Me.Panel1.Controls.Add(Me.btnCheckingIn)
        Me.Panel1.Controls.Add(Me.btnPrintSlip)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 870)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 100)
        Me.Panel1.TabIndex = 75
        '
        'btnBilling
        '
        Me.btnBilling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBilling.BackColor = System.Drawing.SystemColors.Control
        Me.btnBilling.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnBilling.ForeColor = System.Drawing.Color.Teal
        Me.btnBilling.Location = New System.Drawing.Point(495, 27)
        Me.btnBilling.Name = "btnBilling"
        Me.btnBilling.Size = New System.Drawing.Size(235, 50)
        Me.btnBilling.TabIndex = 82
        Me.btnBilling.Text = "PROCEED TO BILLING"
        Me.btnBilling.UseVisualStyleBackColor = True
        '
        'lblSummary
        '
        Me.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSummary.BackColor = System.Drawing.Color.Transparent
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.ForeColor = System.Drawing.Color.White
        Me.lblSummary.Location = New System.Drawing.Point(756, 27)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(774, 50)
        Me.lblSummary.TabIndex = 81
        Me.lblSummary.Text = "TOTAL SUMMARY:"
        Me.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReservation
        '
        Me.btnReservation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReservation.BackColor = System.Drawing.SystemColors.Control
        Me.btnReservation.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnReservation.ForeColor = System.Drawing.Color.Teal
        Me.btnReservation.Location = New System.Drawing.Point(51, 27)
        Me.btnReservation.Name = "btnReservation"
        Me.btnReservation.Size = New System.Drawing.Size(195, 50)
        Me.btnReservation.TabIndex = 77
        Me.btnReservation.Text = "RESERVATION"
        Me.btnReservation.UseVisualStyleBackColor = True
        '
        'btnCheckingIn
        '
        Me.btnCheckingIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckingIn.BackColor = System.Drawing.SystemColors.Control
        Me.btnCheckingIn.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnCheckingIn.ForeColor = System.Drawing.Color.Teal
        Me.btnCheckingIn.Location = New System.Drawing.Point(275, 27)
        Me.btnCheckingIn.Name = "btnCheckingIn"
        Me.btnCheckingIn.Size = New System.Drawing.Size(195, 50)
        Me.btnCheckingIn.TabIndex = 74
        Me.btnCheckingIn.Text = "CHECKING IN"
        Me.btnCheckingIn.UseVisualStyleBackColor = True
        '
        'btnPrintSlip
        '
        Me.btnPrintSlip.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSlip.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintSlip.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnPrintSlip.ForeColor = System.Drawing.Color.Teal
        Me.btnPrintSlip.Location = New System.Drawing.Point(1552, 27)
        Me.btnPrintSlip.Name = "btnPrintSlip"
        Me.btnPrintSlip.Size = New System.Drawing.Size(356, 50)
        Me.btnPrintSlip.TabIndex = 73
        Me.btnPrintSlip.Text = "PRINT RECIEPT"
        Me.btnPrintSlip.UseVisualStyleBackColor = True
        '
        'mnu
        '
        Me.mnu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.mnu.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnu.ForeColor = System.Drawing.SystemColors.Control
        Me.mnu.Image = CType(resources.GetObject("mnu.Image"), System.Drawing.Image)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(80, 34)
        Me.mnu.Text = "File"
        '
        'mnuExit
        '
        Me.mnuExit.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuExit.Size = New System.Drawing.Size(245, 30)
        Me.mnuExit.Text = "Exit"
        '
        'tsmnuRefresh
        '
        Me.tsmnuRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsmnuRefresh.Checked = True
        Me.tsmnuRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmnuRefresh.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmnuRefresh.ForeColor = System.Drawing.SystemColors.Control
        Me.tsmnuRefresh.Image = CType(resources.GetObject("tsmnuRefresh.Image"), System.Drawing.Image)
        Me.tsmnuRefresh.Name = "tsmnuRefresh"
        Me.tsmnuRefresh.Padding = New System.Windows.Forms.Padding(5, 0, 4, 0)
        Me.tsmnuRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsmnuRefresh.Size = New System.Drawing.Size(33, 34)
        '
        'NavigatioToolStripMenuItem
        '
        Me.NavigatioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBOF, Me.mnuNext, Me.mnuPrevious, Me.mnuEOF})
        Me.NavigatioToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigatioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.NavigatioToolStripMenuItem.Image = CType(resources.GetObject("NavigatioToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NavigatioToolStripMenuItem.Name = "NavigatioToolStripMenuItem"
        Me.NavigatioToolStripMenuItem.Size = New System.Drawing.Size(159, 34)
        Me.NavigatioToolStripMenuItem.Text = "Navigation"
        '
        'mnuBOF
        '
        Me.mnuBOF.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBOF.Image = CType(resources.GetObject("mnuBOF.Image"), System.Drawing.Image)
        Me.mnuBOF.Name = "mnuBOF"
        Me.mnuBOF.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.mnuBOF.Size = New System.Drawing.Size(238, 28)
        Me.mnuBOF.Text = "BOF"
        '
        'mnuNext
        '
        Me.mnuNext.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuNext.Image = CType(resources.GetObject("mnuNext.Image"), System.Drawing.Image)
        Me.mnuNext.Name = "mnuNext"
        Me.mnuNext.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)
        Me.mnuNext.Size = New System.Drawing.Size(238, 28)
        Me.mnuNext.Text = "Next"
        '
        'mnuPrevious
        '
        Me.mnuPrevious.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuPrevious.Image = CType(resources.GetObject("mnuPrevious.Image"), System.Drawing.Image)
        Me.mnuPrevious.Name = "mnuPrevious"
        Me.mnuPrevious.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)
        Me.mnuPrevious.Size = New System.Drawing.Size(238, 28)
        Me.mnuPrevious.Text = "Previous"
        '
        'mnuEOF
        '
        Me.mnuEOF.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuEOF.Image = CType(resources.GetObject("mnuEOF.Image"), System.Drawing.Image)
        Me.mnuEOF.Name = "mnuEOF"
        Me.mnuEOF.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.mnuEOF.Size = New System.Drawing.Size(238, 28)
        Me.mnuEOF.Text = "EOF"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Teal
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu, Me.tsmnuRefresh, Me.NavigatioToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip2.TabIndex = 73
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblAdditionals)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.dtpCheckIn)
        Me.GroupBox7.Controls.Add(Me.lblNights)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.nudExtraPax)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.dtpCheckOut)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.nudExtraMattress)
        Me.GroupBox7.Controls.Add(Me.lblRoomCharge)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(1085, 148)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(445, 350)
        Me.GroupBox7.TabIndex = 67
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "RESERVATION DETAILS"
        '
        'lblOperator
        '
        Me.lblOperator.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Teal
        Me.lblOperator.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(981, 3)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(238, 32)
        Me.lblOperator.TabIndex = 76
        Me.lblOperator.Text = "OPERATOR: ADMIN"
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.BackColor = System.Drawing.Color.Teal
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(1308, 3)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(402, 32)
        Me.lblDateTime.TabIndex = 77
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbSelectedRoom
        '
        Me.pbSelectedRoom.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbSelectedRoom.Location = New System.Drawing.Point(16, 38)
        Me.pbSelectedRoom.Name = "pbSelectedRoom"
        Me.pbSelectedRoom.Size = New System.Drawing.Size(493, 295)
        Me.pbSelectedRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSelectedRoom.TabIndex = 55
        Me.pbSelectedRoom.TabStop = False
        '
        'lblBookingStatus
        '
        Me.lblBookingStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBookingStatus.BackColor = System.Drawing.Color.LightGray
        Me.lblBookingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBookingStatus.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookingStatus.ForeColor = System.Drawing.Color.Black
        Me.lblBookingStatus.Location = New System.Drawing.Point(316, 285)
        Me.lblBookingStatus.Name = "lblBookingStatus"
        Me.lblBookingStatus.Size = New System.Drawing.Size(175, 28)
        Me.lblBookingStatus.TabIndex = 80
        Me.lblBookingStatus.Text = "STATUS: ----"
        Me.lblBookingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbSelectRoom
        '
        Me.gbSelectRoom.Controls.Add(Me.lblRoomNumber)
        Me.gbSelectRoom.Controls.Add(Me.lblRoomType)
        Me.gbSelectRoom.Controls.Add(Me.lblRoomClass)
        Me.gbSelectRoom.Controls.Add(Me.lblBookingStatus)
        Me.gbSelectRoom.Controls.Add(Me.pbSelectedRoom)
        Me.gbSelectRoom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSelectRoom.Location = New System.Drawing.Point(16, 148)
        Me.gbSelectRoom.Name = "gbSelectRoom"
        Me.gbSelectRoom.Size = New System.Drawing.Size(525, 350)
        Me.gbSelectRoom.TabIndex = 0
        Me.gbSelectRoom.TabStop = False
        Me.gbSelectRoom.Text = "SELECTED ROOM"
        '
        'lblRoomNumber
        '
        Me.lblRoomNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomNumber.BackColor = System.Drawing.Color.LightGray
        Me.lblRoomNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoomNumber.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNumber.ForeColor = System.Drawing.Color.Black
        Me.lblRoomNumber.Location = New System.Drawing.Point(35, 285)
        Me.lblRoomNumber.Name = "lblRoomNumber"
        Me.lblRoomNumber.Size = New System.Drawing.Size(175, 28)
        Me.lblRoomNumber.TabIndex = 83
        Me.lblRoomNumber.Text = "ROOM: ----"
        Me.lblRoomNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoomType
        '
        Me.lblRoomType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomType.BackColor = System.Drawing.Color.LightGray
        Me.lblRoomType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoomType.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomType.ForeColor = System.Drawing.Color.Black
        Me.lblRoomType.Location = New System.Drawing.Point(316, 52)
        Me.lblRoomType.Name = "lblRoomType"
        Me.lblRoomType.Size = New System.Drawing.Size(175, 28)
        Me.lblRoomType.TabIndex = 82
        Me.lblRoomType.Text = "TYPE: ----"
        Me.lblRoomType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRoomClass
        '
        Me.lblRoomClass.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomClass.BackColor = System.Drawing.Color.LightGray
        Me.lblRoomClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoomClass.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomClass.ForeColor = System.Drawing.Color.Black
        Me.lblRoomClass.Location = New System.Drawing.Point(35, 52)
        Me.lblRoomClass.Name = "lblRoomClass"
        Me.lblRoomClass.Size = New System.Drawing.Size(175, 28)
        Me.lblRoomClass.TabIndex = 81
        Me.lblRoomClass.Text = "CLASS: ----"
        Me.lblRoomClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReservations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.gbPayment)
        Me.Controls.Add(Me.btnClearFilter)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.gbGuestDetails)
        Me.Controls.Add(Me.gbBillingSummary)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.gbSelectRoom)
        Me.Controls.Add(Me.btnAddPayment)
        Me.Name = "frmReservations"
        Me.Text = "Reservations"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.nudExtraMattress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExtraPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvRoomAvailability, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbBillingSummary.ResumeLayout(False)
        Me.gbBillingSummary.PerformLayout()
        Me.gbGuestDetails.ResumeLayout(False)
        Me.gbGuestDetails.PerformLayout()
        Me.gbPayment.ResumeLayout(False)
        Me.gbPayment.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.pbSelectedRoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSelectRoom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpCheckOut As DateTimePicker
    Friend WithEvents dtpCheckIn As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents nudExtraPax As NumericUpDown
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents nudExtraMattress As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents lblNights As Label
    Friend WithEvents dgvBookings As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboRoomClass As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboRoomType As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label18 As Label
    Friend WithEvents lblAdditionals As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblRoomCharge As Label
    Friend WithEvents lblRemainingBalance As Label
    Friend WithEvents rbDeposit As RadioButton
    Friend WithEvents rbFullPayment As RadioButton
    Friend WithEvents cbDeposit As ComboBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblDepositRequired As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblTotalCharge As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents gbBillingSummary As GroupBox
    Friend WithEvents gbGuestDetails As GroupBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents btnAddPayment As Button
    Friend WithEvents txtPaymentAmount As TextBox
    Friend WithEvents dgvRoomAvailability As DataGridView
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents gbPayment As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCheckingIn As Button
    Friend WithEvents btnPrintSlip As Button
    Friend WithEvents btnReservation As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents mnu As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents tsmnuRefresh As ToolStripMenuItem
    Friend WithEvents NavigatioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuBOF As ToolStripMenuItem
    Friend WithEvents mnuNext As ToolStripMenuItem
    Friend WithEvents mnuPrevious As ToolStripMenuItem
    Friend WithEvents mnuEOF As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lblSummary As Label
    Friend WithEvents btnBilling As Button
    Friend WithEvents lblOperator As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents pbSelectedRoom As PictureBox
    Friend WithEvents lblBookingStatus As Label
    Friend WithEvents gbSelectRoom As GroupBox
    Friend WithEvents lblRoomNumber As Label
    Friend WithEvents lblRoomType As Label
    Friend WithEvents lblRoomClass As Label
End Class
