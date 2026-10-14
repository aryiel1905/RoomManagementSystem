<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGuest_Stay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuest_Stay))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.mnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEditCharges = New System.Windows.Forms.Button()
        Me.btnConfirmCheckIn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.gbRooms = New System.Windows.Forms.GroupBox()
        Me.lblTypeClass = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCheckOut = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCheckIn = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblResNo = New System.Windows.Forms.Label()
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvGuestStay = New System.Windows.Forms.DataGridView()
        Me.gbReservationLookUp = New System.Windows.Forms.GroupBox()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpCharges = New System.Windows.Forms.TabPage()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.tpDiningNBar = New System.Windows.Forms.TabPage()
        Me.dgvDiningNBar = New System.Windows.Forms.DataGridView()
        Me.tpPayments = New System.Windows.Forms.TabPage()
        Me.dgvPayments = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblRemaingBalance = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDiningNBar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOthers = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRoomCharges = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbRooms.SuspendLayout()
        CType(Me.dgvGuestStay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReservationLookUp.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpCharges.SuspendLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDiningNBar.SuspendLayout()
        CType(Me.dgvDiningNBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPayments.SuspendLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Teal
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu, Me.ToolStripMenuItem16})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip2.TabIndex = 79
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem16.Checked = True
        Me.ToolStripMenuItem16.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem16.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem16.ForeColor = System.Drawing.SystemColors.Control
        Me.ToolStripMenuItem16.Image = CType(resources.GetObject("ToolStripMenuItem16.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Padding = New System.Windows.Forms.Padding(5, 0, 4, 0)
        Me.ToolStripMenuItem16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(33, 34)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.btnEditCharges)
        Me.Panel1.Controls.Add(Me.btnConfirmCheckIn)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnReservation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 870)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 100)
        Me.Panel1.TabIndex = 78
        '
        'btnEditCharges
        '
        Me.btnEditCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditCharges.BackColor = System.Drawing.SystemColors.Control
        Me.btnEditCharges.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditCharges.ForeColor = System.Drawing.Color.Teal
        Me.btnEditCharges.Location = New System.Drawing.Point(1399, 27)
        Me.btnEditCharges.Name = "btnEditCharges"
        Me.btnEditCharges.Size = New System.Drawing.Size(498, 50)
        Me.btnEditCharges.TabIndex = 81
        Me.btnEditCharges.Text = "ADD CHARGES"
        Me.btnEditCharges.UseVisualStyleBackColor = True
        '
        'btnConfirmCheckIn
        '
        Me.btnConfirmCheckIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmCheckIn.BackColor = System.Drawing.SystemColors.Control
        Me.btnConfirmCheckIn.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmCheckIn.ForeColor = System.Drawing.Color.Teal
        Me.btnConfirmCheckIn.Location = New System.Drawing.Point(2209, 27)
        Me.btnConfirmCheckIn.Name = "btnConfirmCheckIn"
        Me.btnConfirmCheckIn.Size = New System.Drawing.Size(238, 50)
        Me.btnConfirmCheckIn.TabIndex = 75
        Me.btnConfirmCheckIn.Text = "CONFIRM CHECK IN"
        Me.btnConfirmCheckIn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Teal
        Me.Button1.Location = New System.Drawing.Point(2478, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 50)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "PRINT CHECK-IN FORM"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.btnReservation.Size = New System.Drawing.Size(235, 50)
        Me.btnReservation.TabIndex = 83
        Me.btnReservation.Text = "GO TO RESERVATION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnReservation.UseVisualStyleBackColor = True
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckOut.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckOut.Location = New System.Drawing.Point(31, 541)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(435, 74)
        Me.btnCheckOut.TabIndex = 84
        Me.btnCheckOut.Text = "CHECK OUT"
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'gbRooms
        '
        Me.gbRooms.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRooms.Controls.Add(Me.lblTypeClass)
        Me.gbRooms.Controls.Add(Me.Label19)
        Me.gbRooms.Controls.Add(Me.Label9)
        Me.gbRooms.Controls.Add(Me.lblCheckOut)
        Me.gbRooms.Controls.Add(Me.Label10)
        Me.gbRooms.Controls.Add(Me.lblCheckIn)
        Me.gbRooms.Controls.Add(Me.lblRoomNo)
        Me.gbRooms.Controls.Add(Me.Label4)
        Me.gbRooms.Controls.Add(Me.Label17)
        Me.gbRooms.Controls.Add(Me.lblResNo)
        Me.gbRooms.Controls.Add(Me.lblGuestName)
        Me.gbRooms.Controls.Add(Me.Label14)
        Me.gbRooms.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRooms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRooms.Location = New System.Drawing.Point(532, 53)
        Me.gbRooms.Name = "gbRooms"
        Me.gbRooms.Size = New System.Drawing.Size(1365, 132)
        Me.gbRooms.TabIndex = 80
        Me.gbRooms.TabStop = False
        Me.gbRooms.Text = "GUEST DETAILS"
        '
        'lblTypeClass
        '
        Me.lblTypeClass.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTypeClass.BackColor = System.Drawing.Color.Lavender
        Me.lblTypeClass.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeClass.Location = New System.Drawing.Point(725, 74)
        Me.lblTypeClass.Name = "lblTypeClass"
        Me.lblTypeClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTypeClass.Size = New System.Drawing.Size(235, 33)
        Me.lblTypeClass.TabIndex = 91
        Me.lblTypeClass.Text = "-------------------"
        Me.lblTypeClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label19.Location = New System.Drawing.Point(720, 38)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(175, 26)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "Room Type/Class"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(1134, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 26)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Check Out:"
        '
        'lblCheckOut
        '
        Me.lblCheckOut.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCheckOut.BackColor = System.Drawing.Color.Lavender
        Me.lblCheckOut.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckOut.Location = New System.Drawing.Point(1139, 74)
        Me.lblCheckOut.Name = "lblCheckOut"
        Me.lblCheckOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCheckOut.Size = New System.Drawing.Size(198, 33)
        Me.lblCheckOut.TabIndex = 90
        Me.lblCheckOut.Text = "-------------------"
        Me.lblCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(980, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 26)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Check In:"
        '
        'lblCheckIn
        '
        Me.lblCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCheckIn.BackColor = System.Drawing.Color.Lavender
        Me.lblCheckIn.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckIn.Location = New System.Drawing.Point(985, 74)
        Me.lblCheckIn.Name = "lblCheckIn"
        Me.lblCheckIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCheckIn.Size = New System.Drawing.Size(129, 33)
        Me.lblCheckIn.TabIndex = 88
        Me.lblCheckIn.Text = "-------------------"
        Me.lblCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomNo.BackColor = System.Drawing.Color.Lavender
        Me.lblRoomNo.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNo.Location = New System.Drawing.Point(575, 74)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRoomNo.Size = New System.Drawing.Size(125, 33)
        Me.lblRoomNo.TabIndex = 92
        Me.lblRoomNo.Text = "-------------------"
        Me.lblRoomNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(570, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 26)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Room No."
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label17.Location = New System.Drawing.Point(298, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 26)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Reservation No:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblResNo
        '
        Me.lblResNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblResNo.BackColor = System.Drawing.Color.Lavender
        Me.lblResNo.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResNo.Location = New System.Drawing.Point(303, 74)
        Me.lblResNo.Name = "lblResNo"
        Me.lblResNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblResNo.Size = New System.Drawing.Size(247, 33)
        Me.lblResNo.TabIndex = 89
        Me.lblResNo.Text = "-------------------"
        Me.lblResNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGuestName
        '
        Me.lblGuestName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGuestName.BackColor = System.Drawing.Color.Lavender
        Me.lblGuestName.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuestName.Location = New System.Drawing.Point(31, 74)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblGuestName.Size = New System.Drawing.Size(247, 33)
        Me.lblGuestName.TabIndex = 86
        Me.lblGuestName.Text = "-------------------"
        Me.lblGuestName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(26, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 26)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Guest Name:"
        '
        'dgvGuestStay
        '
        Me.dgvGuestStay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGuestStay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuestStay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvGuestStay.Location = New System.Drawing.Point(21, 123)
        Me.dgvGuestStay.Name = "dgvGuestStay"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvGuestStay.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGuestStay.RowTemplate.Height = 24
        Me.dgvGuestStay.Size = New System.Drawing.Size(452, 649)
        Me.dgvGuestStay.TabIndex = 1
        '
        'gbReservationLookUp
        '
        Me.gbReservationLookUp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.gbReservationLookUp.Controls.Add(Me.dgvGuestStay)
        Me.gbReservationLookUp.Controls.Add(Me.btnClearFilter)
        Me.gbReservationLookUp.Controls.Add(Me.GroupBox5)
        Me.gbReservationLookUp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReservationLookUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReservationLookUp.Location = New System.Drawing.Point(12, 53)
        Me.gbReservationLookUp.Name = "gbReservationLookUp"
        Me.gbReservationLookUp.Size = New System.Drawing.Size(495, 794)
        Me.gbReservationLookUp.TabIndex = 82
        Me.gbReservationLookUp.TabStop = False
        Me.gbReservationLookUp.Text = "GUEST LOOKUP"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.Teal
        Me.btnClearFilter.Location = New System.Drawing.Point(329, 35)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(144, 69)
        Me.btnClearFilter.TabIndex = 61
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSearch)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox5.Location = New System.Drawing.Point(21, 35)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(296, 69)
        Me.GroupBox5.TabIndex = 58
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Search: "
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
        Me.txtSearch.Size = New System.Drawing.Size(259, 27)
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
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpCharges)
        Me.TabControl1.Controls.Add(Me.tpDiningNBar)
        Me.TabControl1.Controls.Add(Me.tpPayments)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(532, 210)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(848, 637)
        Me.TabControl1.TabIndex = 83
        '
        'tpCharges
        '
        Me.tpCharges.BackColor = System.Drawing.Color.Teal
        Me.tpCharges.Controls.Add(Me.dgvCharges)
        Me.tpCharges.Location = New System.Drawing.Point(4, 37)
        Me.tpCharges.Name = "tpCharges"
        Me.tpCharges.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCharges.Size = New System.Drawing.Size(840, 596)
        Me.tpCharges.TabIndex = 0
        Me.tpCharges.Text = "Charges"
        '
        'dgvCharges
        '
        Me.dgvCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCharges.Location = New System.Drawing.Point(15, 17)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowTemplate.Height = 24
        Me.dgvCharges.Size = New System.Drawing.Size(811, 563)
        Me.dgvCharges.TabIndex = 1
        '
        'tpDiningNBar
        '
        Me.tpDiningNBar.BackColor = System.Drawing.Color.Gold
        Me.tpDiningNBar.Controls.Add(Me.dgvDiningNBar)
        Me.tpDiningNBar.Location = New System.Drawing.Point(4, 37)
        Me.tpDiningNBar.Name = "tpDiningNBar"
        Me.tpDiningNBar.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDiningNBar.Size = New System.Drawing.Size(840, 596)
        Me.tpDiningNBar.TabIndex = 1
        Me.tpDiningNBar.Text = "Dining / Bar"
        '
        'dgvDiningNBar
        '
        Me.dgvDiningNBar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDiningNBar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiningNBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDiningNBar.Location = New System.Drawing.Point(15, 17)
        Me.dgvDiningNBar.Name = "dgvDiningNBar"
        Me.dgvDiningNBar.RowTemplate.Height = 24
        Me.dgvDiningNBar.Size = New System.Drawing.Size(811, 563)
        Me.dgvDiningNBar.TabIndex = 2
        '
        'tpPayments
        '
        Me.tpPayments.Controls.Add(Me.dgvPayments)
        Me.tpPayments.Location = New System.Drawing.Point(4, 37)
        Me.tpPayments.Name = "tpPayments"
        Me.tpPayments.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPayments.Size = New System.Drawing.Size(840, 596)
        Me.tpPayments.TabIndex = 2
        Me.tpPayments.Text = "Payments"
        Me.tpPayments.UseVisualStyleBackColor = True
        '
        'dgvPayments
        '
        Me.dgvPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPayments.Location = New System.Drawing.Point(15, 17)
        Me.dgvPayments.Name = "dgvPayments"
        Me.dgvPayments.RowTemplate.Height = 24
        Me.dgvPayments.Size = New System.Drawing.Size(811, 563)
        Me.dgvPayments.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GroupBox1.Controls.Add(Me.btnCheckOut)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblDiningNBar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblOthers)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblRoomCharges)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(1399, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 637)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BILLING SUMMARY"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.lblTotalPaid)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(31, 368)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(435, 150)
        Me.GroupBox3.TabIndex = 96
        Me.GroupBox3.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(23, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 26)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Total Paid"
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPaid.Font = New System.Drawing.Font("Segoe UI", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.Location = New System.Drawing.Point(28, 60)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalPaid.Size = New System.Drawing.Size(366, 65)
        Me.lblTotalPaid.TabIndex = 90
        Me.lblTotalPaid.Text = "-------------------"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblRemaingBalance)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(31, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(435, 150)
        Me.GroupBox2.TabIndex = 95
        Me.GroupBox2.TabStop = False
        '
        'lblRemaingBalance
        '
        Me.lblRemaingBalance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemaingBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblRemaingBalance.Font = New System.Drawing.Font("Segoe UI", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemaingBalance.Location = New System.Drawing.Point(28, 60)
        Me.lblRemaingBalance.Name = "lblRemaingBalance"
        Me.lblRemaingBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRemaingBalance.Size = New System.Drawing.Size(366, 65)
        Me.lblRemaingBalance.TabIndex = 90
        Me.lblRemaingBalance.Text = "-------------------"
        Me.lblRemaingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(23, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 26)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Remaining Balance"
        '
        'lblDiningNBar
        '
        Me.lblDiningNBar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDiningNBar.BackColor = System.Drawing.Color.Lavender
        Me.lblDiningNBar.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiningNBar.Location = New System.Drawing.Point(320, 98)
        Me.lblDiningNBar.Name = "lblDiningNBar"
        Me.lblDiningNBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDiningNBar.Size = New System.Drawing.Size(147, 33)
        Me.lblDiningNBar.TabIndex = 88
        Me.lblDiningNBar.Text = "-------------------"
        Me.lblDiningNBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(26, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 26)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Dining and Bar"
        '
        'lblOthers
        '
        Me.lblOthers.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOthers.BackColor = System.Drawing.Color.Lavender
        Me.lblOthers.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthers.Location = New System.Drawing.Point(320, 142)
        Me.lblOthers.Name = "lblOthers"
        Me.lblOthers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblOthers.Size = New System.Drawing.Size(147, 33)
        Me.lblOthers.TabIndex = 92
        Me.lblOthers.Text = "-------------------"
        Me.lblOthers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(26, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 26)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Others"
        '
        'lblRoomCharges
        '
        Me.lblRoomCharges.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomCharges.BackColor = System.Drawing.Color.Lavender
        Me.lblRoomCharges.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomCharges.Location = New System.Drawing.Point(320, 54)
        Me.lblRoomCharges.Name = "lblRoomCharges"
        Me.lblRoomCharges.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRoomCharges.Size = New System.Drawing.Size(147, 33)
        Me.lblRoomCharges.TabIndex = 86
        Me.lblRoomCharges.Text = "-------------------"
        Me.lblRoomCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Location = New System.Drawing.Point(26, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(203, 26)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "Total Room Charges" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblOperator
        '
        Me.lblOperator.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Teal
        Me.lblOperator.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(1116, 3)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(238, 32)
        Me.lblOperator.TabIndex = 62
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
        Me.lblDateTime.Location = New System.Drawing.Point(1443, 3)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(402, 32)
        Me.lblDateTime.TabIndex = 63
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmGuest_Stay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbReservationLookUp)
        Me.Controls.Add(Me.gbRooms)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmGuest_Stay"
        Me.Text = "Billing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbRooms.ResumeLayout(False)
        Me.gbRooms.PerformLayout()
        CType(Me.dgvGuestStay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReservationLookUp.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpCharges.ResumeLayout(False)
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDiningNBar.ResumeLayout(False)
        CType(Me.dgvDiningNBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPayments.ResumeLayout(False)
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents mnu As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConfirmCheckIn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents gbRooms As GroupBox
    Friend WithEvents dgvGuestStay As DataGridView
    Friend WithEvents gbReservationLookUp As GroupBox
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lblTypeClass As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCheckOut As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblCheckIn As Label
    Friend WithEvents lblRoomNo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblResNo As Label
    Friend WithEvents lblGuestName As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpCharges As TabPage
    Friend WithEvents dgvCharges As DataGridView
    Friend WithEvents tpDiningNBar As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblRemaingBalance As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents lblDiningNBar As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblOthers As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblRoomCharges As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents tpPayments As TabPage
    Friend WithEvents dgvDiningNBar As DataGridView
    Friend WithEvents dgvPayments As DataGridView
    Friend WithEvents btnEditCharges As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblOperator As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnReservation As Button
End Class
