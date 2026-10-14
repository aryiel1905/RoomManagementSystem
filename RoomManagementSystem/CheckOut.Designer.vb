<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckOut
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckOut))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.mnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCheckingOut = New System.Windows.Forms.Button()
        Me.btnGuestStay = New System.Windows.Forms.Button()
        Me.btnCheckingIn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.btnCollectPayment = New System.Windows.Forms.Button()
        Me.btnConfirmCheckout = New System.Windows.Forms.Button()
        Me.gbReservationLookUp = New System.Windows.Forms.GroupBox()
        Me.dgvGuestStay = New System.Windows.Forms.DataGridView()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dgvSummary = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRemainingBalance = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalCharges = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbReservationLookUp.SuspendLayout()
        CType(Me.dgvGuestStay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbRooms.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.btnCheckingOut)
        Me.Panel1.Controls.Add(Me.btnGuestStay)
        Me.Panel1.Controls.Add(Me.btnCheckingIn)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnReservation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 870)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 100)
        Me.Panel1.TabIndex = 78
        '
        'btnCheckingOut
        '
        Me.btnCheckingOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckingOut.BackColor = System.Drawing.SystemColors.Control
        Me.btnCheckingOut.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnCheckingOut.ForeColor = System.Drawing.Color.Teal
        Me.btnCheckingOut.Location = New System.Drawing.Point(717, 27)
        Me.btnCheckingOut.Name = "btnCheckingOut"
        Me.btnCheckingOut.Size = New System.Drawing.Size(195, 50)
        Me.btnCheckingOut.TabIndex = 77
        Me.btnCheckingOut.Text = "CHECKING OUT"
        Me.btnCheckingOut.UseVisualStyleBackColor = True
        '
        'btnGuestStay
        '
        Me.btnGuestStay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuestStay.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuestStay.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnGuestStay.ForeColor = System.Drawing.Color.Teal
        Me.btnGuestStay.Location = New System.Drawing.Point(496, 27)
        Me.btnGuestStay.Name = "btnGuestStay"
        Me.btnGuestStay.Size = New System.Drawing.Size(195, 50)
        Me.btnGuestStay.TabIndex = 76
        Me.btnGuestStay.Text = "GUEST STAY"
        Me.btnGuestStay.UseVisualStyleBackColor = True
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
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Teal
        Me.Button1.Location = New System.Drawing.Point(1653, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 50)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "PRINT INVOICE"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
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
        Me.btnReservation.TabIndex = 72
        Me.btnReservation.Text = "RESERVATION"
        Me.btnReservation.UseVisualStyleBackColor = True
        '
        'btnCollectPayment
        '
        Me.btnCollectPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCollectPayment.BackColor = System.Drawing.Color.Teal
        Me.btnCollectPayment.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollectPayment.ForeColor = System.Drawing.Color.White
        Me.btnCollectPayment.Location = New System.Drawing.Point(36, 261)
        Me.btnCollectPayment.Name = "btnCollectPayment"
        Me.btnCollectPayment.Size = New System.Drawing.Size(437, 65)
        Me.btnCollectPayment.TabIndex = 75
        Me.btnCollectPayment.Text = "Collect Payment"
        Me.btnCollectPayment.UseVisualStyleBackColor = False
        '
        'btnConfirmCheckout
        '
        Me.btnConfirmCheckout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmCheckout.BackColor = System.Drawing.Color.SeaGreen
        Me.btnConfirmCheckout.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmCheckout.ForeColor = System.Drawing.Color.White
        Me.btnConfirmCheckout.Location = New System.Drawing.Point(36, 341)
        Me.btnConfirmCheckout.Name = "btnConfirmCheckout"
        Me.btnConfirmCheckout.Size = New System.Drawing.Size(437, 64)
        Me.btnConfirmCheckout.TabIndex = 105
        Me.btnConfirmCheckout.Text = "Confirm Check Out"
        Me.btnConfirmCheckout.UseVisualStyleBackColor = False
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
        Me.gbReservationLookUp.TabIndex = 83
        Me.gbReservationLookUp.TabStop = False
        Me.gbReservationLookUp.Text = "GUEST LOOKUP"
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvGuestStay.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGuestStay.RowTemplate.Height = 24
        Me.dgvGuestStay.Size = New System.Drawing.Size(452, 649)
        Me.dgvGuestStay.TabIndex = 1
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
        'dgvSummary
        '
        Me.dgvSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSummary.Location = New System.Drawing.Point(532, 204)
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.RowTemplate.Height = 24
        Me.dgvSummary.Size = New System.Drawing.Size(844, 637)
        Me.dgvSummary.TabIndex = 85
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GroupBox1.Controls.Add(Me.lblRemainingBalance)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblTotalPaid)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblTotalCharges)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(1399, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 192)
        Me.GroupBox1.TabIndex = 95
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BILLING SUMMARY"
        '
        'lblRemainingBalance
        '
        Me.lblRemainingBalance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemainingBalance.BackColor = System.Drawing.Color.Lavender
        Me.lblRemainingBalance.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemainingBalance.Location = New System.Drawing.Point(325, 136)
        Me.lblRemainingBalance.Name = "lblRemainingBalance"
        Me.lblRemainingBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRemainingBalance.Size = New System.Drawing.Size(147, 33)
        Me.lblRemainingBalance.TabIndex = 102
        Me.lblRemainingBalance.Text = "-------------------"
        Me.lblRemainingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(31, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 26)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Remaining Balance"
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalPaid.BackColor = System.Drawing.Color.Lavender
        Me.lblTotalPaid.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.Location = New System.Drawing.Point(325, 83)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalPaid.Size = New System.Drawing.Size(147, 33)
        Me.lblTotalPaid.TabIndex = 101
        Me.lblTotalPaid.Text = "-------------------"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(31, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 26)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "TOTAL PAID"
        '
        'lblTotalCharges
        '
        Me.lblTotalCharges.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalCharges.BackColor = System.Drawing.Color.Lavender
        Me.lblTotalCharges.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCharges.Location = New System.Drawing.Point(325, 39)
        Me.lblTotalCharges.Name = "lblTotalCharges"
        Me.lblTotalCharges.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalCharges.Size = New System.Drawing.Size(147, 33)
        Me.lblTotalCharges.TabIndex = 98
        Me.lblTotalCharges.Text = "-------------------"
        Me.lblTotalCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Location = New System.Drawing.Point(31, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(142, 26)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Total Charges" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.btnCollectPayment)
        Me.GroupBox2.Controls.Add(Me.btnConfirmCheckout)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(1399, 419)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(498, 422)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PAYMENT"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(36, 78)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(437, 53)
        Me.TextBox1.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.BackColor = System.Drawing.Color.Lavender
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(437, 64)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "-------------------"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(31, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 26)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Changes"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(31, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 26)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Pay Amount"
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
        Me.gbRooms.TabIndex = 104
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
        'lblOperator
        '
        Me.lblOperator.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Teal
        Me.lblOperator.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(1115, 3)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(238, 32)
        Me.lblOperator.TabIndex = 105
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
        Me.lblDateTime.Location = New System.Drawing.Point(1442, 3)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(402, 32)
        Me.lblDateTime.TabIndex = 106
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.gbRooms)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.gbReservationLookUp)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CheckOut"
        Me.Text = "Checking Out"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbReservationLookUp.ResumeLayout(False)
        CType(Me.dgvGuestStay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbRooms.ResumeLayout(False)
        Me.gbRooms.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents mnu As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGuestStay As Button
    Friend WithEvents btnCollectPayment As Button
    Friend WithEvents btnConfirmCheckout As Button
    Friend WithEvents btnCheckingIn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnReservation As Button
    Friend WithEvents btnCheckingOut As Button
    Friend WithEvents gbReservationLookUp As GroupBox
    Friend WithEvents dgvGuestStay As DataGridView
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents dgvSummary As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblRemainingBalance As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalCharges As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents gbRooms As GroupBox
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
    Friend WithEvents lblOperator As Label
    Friend WithEvents lblDateTime As Label
End Class
