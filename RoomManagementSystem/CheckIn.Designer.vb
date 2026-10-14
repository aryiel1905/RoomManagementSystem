<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCheckIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckIn))
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.gbRooms = New System.Windows.Forms.GroupBox()
        Me.dgvReservations = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBilling = New System.Windows.Forms.Button()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnCheckingIn = New System.Windows.Forms.Button()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.btnConfirmCheckIn = New System.Windows.Forms.Button()
        Me.gbReservationLookUp = New System.Windows.Forms.GroupBox()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbGuestDetails = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblNights = New System.Windows.Forms.Label()
        Me.lblTypeClass = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalPax = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCheckOut = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCheckIn = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCheckinStatus = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbNotes = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.lblRequiredDeposit = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbPayment = New System.Windows.Forms.GroupBox()
        Me.btnAddPayment = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblResNo = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.mnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.CachedReservationSlip1 = New RoomManagementSystem.CachedReservationSlip()
        Me.gbRooms.SuspendLayout()
        CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbReservationLookUp.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gbGuestDetails.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbPayment.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblDateTime.TabIndex = 2
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lblOperator.TabIndex = 0
        Me.lblOperator.Text = "OPERATOR: ADMIN"
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbRooms
        '
        Me.gbRooms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbRooms.BackColor = System.Drawing.Color.White
        Me.gbRooms.Controls.Add(Me.dgvReservations)
        Me.gbRooms.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRooms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRooms.Location = New System.Drawing.Point(30, 211)
        Me.gbRooms.Name = "gbRooms"
        Me.gbRooms.Size = New System.Drawing.Size(587, 629)
        Me.gbRooms.TabIndex = 4
        Me.gbRooms.TabStop = False
        Me.gbRooms.Text = "RESERVATION LIST"
        '
        'dgvReservations
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvReservations.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReservations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReservations.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvReservations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReservations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReservations.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReservations.EnableHeadersVisualStyles = False
        Me.dgvReservations.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvReservations.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvReservations.Location = New System.Drawing.Point(21, 45)
        Me.dgvReservations.Name = "dgvReservations"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReservations.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReservations.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.InfoText
        Me.dgvReservations.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReservations.RowTemplate.Height = 28
        Me.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReservations.Size = New System.Drawing.Size(537, 564)
        Me.dgvReservations.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.btnBilling)
        Me.Panel1.Controls.Add(Me.lblSummary)
        Me.Panel1.Controls.Add(Me.btnCreate)
        Me.Panel1.Controls.Add(Me.btnCheckingIn)
        Me.Panel1.Controls.Add(Me.btnReservation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 870)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 100)
        Me.Panel1.TabIndex = 2
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
        Me.btnBilling.TabIndex = 85
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
        Me.lblSummary.TabIndex = 84
        Me.lblSummary.Text = "TOTAL SUMMARY:"
        Me.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.BackColor = System.Drawing.Color.Teal
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft PhagsPa", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCreate.Location = New System.Drawing.Point(1557, 725)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(360, 122)
        Me.btnCreate.TabIndex = 83
        Me.btnCreate.Text = "CREATE RESERVATION"
        Me.btnCreate.UseVisualStyleBackColor = False
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
        Me.btnCheckingIn.TabIndex = 77
        Me.btnCheckingIn.Text = "CHECKING IN"
        Me.btnCheckingIn.UseVisualStyleBackColor = True
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
        'btnConfirmCheckIn
        '
        Me.btnConfirmCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmCheckIn.BackColor = System.Drawing.Color.SeaGreen
        Me.btnConfirmCheckIn.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmCheckIn.ForeColor = System.Drawing.Color.White
        Me.btnConfirmCheckIn.Location = New System.Drawing.Point(1426, 691)
        Me.btnConfirmCheckIn.Name = "btnConfirmCheckIn"
        Me.btnConfirmCheckIn.Size = New System.Drawing.Size(468, 69)
        Me.btnConfirmCheckIn.TabIndex = 75
        Me.btnConfirmCheckIn.Text = "CONFIRM CHECK IN"
        Me.btnConfirmCheckIn.UseVisualStyleBackColor = False
        '
        'gbReservationLookUp
        '
        Me.gbReservationLookUp.BackColor = System.Drawing.Color.White
        Me.gbReservationLookUp.Controls.Add(Me.btnClearFilter)
        Me.gbReservationLookUp.Controls.Add(Me.GroupBox5)
        Me.gbReservationLookUp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReservationLookUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReservationLookUp.Location = New System.Drawing.Point(30, 66)
        Me.gbReservationLookUp.Name = "gbReservationLookUp"
        Me.gbReservationLookUp.Size = New System.Drawing.Size(587, 120)
        Me.gbReservationLookUp.TabIndex = 5
        Me.gbReservationLookUp.TabStop = False
        Me.gbReservationLookUp.Text = "RESERVATION LOOKUP"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.BackColor = System.Drawing.Color.Teal
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.White
        Me.btnClearFilter.Location = New System.Drawing.Point(435, 32)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(123, 69)
        Me.btnClearFilter.TabIndex = 61
        Me.btnClearFilter.Text = "CLEAR"
        Me.btnClearFilter.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSearch)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox5.Location = New System.Drawing.Point(21, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(397, 69)
        Me.GroupBox5.TabIndex = 58
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Search: "
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(9, 25)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(513, 34)
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
        'gbGuestDetails
        '
        Me.gbGuestDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbGuestDetails.BackColor = System.Drawing.Color.White
        Me.gbGuestDetails.Controls.Add(Me.Label15)
        Me.gbGuestDetails.Controls.Add(Me.lblNights)
        Me.gbGuestDetails.Controls.Add(Me.lblTypeClass)
        Me.gbGuestDetails.Controls.Add(Me.Label19)
        Me.gbGuestDetails.Controls.Add(Me.Label22)
        Me.gbGuestDetails.Controls.Add(Me.Label5)
        Me.gbGuestDetails.Controls.Add(Me.lblTotalPax)
        Me.gbGuestDetails.Controls.Add(Me.Label21)
        Me.gbGuestDetails.Controls.Add(Me.Label9)
        Me.gbGuestDetails.Controls.Add(Me.lblCheckOut)
        Me.gbGuestDetails.Controls.Add(Me.Label18)
        Me.gbGuestDetails.Controls.Add(Me.Label10)
        Me.gbGuestDetails.Controls.Add(Me.lblCheckIn)
        Me.gbGuestDetails.Controls.Add(Me.Label16)
        Me.gbGuestDetails.Controls.Add(Me.lblRoomNo)
        Me.gbGuestDetails.Controls.Add(Me.Label4)
        Me.gbGuestDetails.Controls.Add(Me.Label2)
        Me.gbGuestDetails.Controls.Add(Me.lblCheckinStatus)
        Me.gbGuestDetails.Controls.Add(Me.Label11)
        Me.gbGuestDetails.Controls.Add(Me.lbNotes)
        Me.gbGuestDetails.Controls.Add(Me.Label8)
        Me.gbGuestDetails.Controls.Add(Me.Label23)
        Me.gbGuestDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGuestDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbGuestDetails.Location = New System.Drawing.Point(643, 292)
        Me.gbGuestDetails.Name = "gbGuestDetails"
        Me.gbGuestDetails.Size = New System.Drawing.Size(760, 548)
        Me.gbGuestDetails.TabIndex = 5
        Me.gbGuestDetails.TabStop = False
        Me.gbGuestDetails.Text = "GUEST RESERVATION DETAILS"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Lavender
        Me.Label15.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Location = New System.Drawing.Point(474, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 26)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Nights:"
        '
        'lblNights
        '
        Me.lblNights.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblNights.AutoSize = True
        Me.lblNights.BackColor = System.Drawing.Color.Lavender
        Me.lblNights.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNights.Location = New System.Drawing.Point(479, 155)
        Me.lblNights.Name = "lblNights"
        Me.lblNights.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNights.Size = New System.Drawing.Size(174, 41)
        Me.lblNights.TabIndex = 58
        Me.lblNights.Text = "-------------"
        Me.lblNights.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTypeClass
        '
        Me.lblTypeClass.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTypeClass.AutoSize = True
        Me.lblTypeClass.BackColor = System.Drawing.Color.Lavender
        Me.lblTypeClass.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeClass.Location = New System.Drawing.Point(479, 296)
        Me.lblTypeClass.Name = "lblTypeClass"
        Me.lblTypeClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTypeClass.Size = New System.Drawing.Size(175, 32)
        Me.lblTypeClass.TabIndex = 63
        Me.lblTypeClass.Text = "----------------"
        Me.lblTypeClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Lavender
        Me.Label19.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label19.Location = New System.Drawing.Point(474, 260)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(175, 26)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "Room Type/Class"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.BackColor = System.Drawing.Color.Lavender
        Me.Label22.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label22.Location = New System.Drawing.Point(449, 241)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(278, 107)
        Me.Label22.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Lavender
        Me.Label5.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(311, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 26)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Total Pax:"
        '
        'lblTotalPax
        '
        Me.lblTotalPax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTotalPax.AutoSize = True
        Me.lblTotalPax.BackColor = System.Drawing.Color.Lavender
        Me.lblTotalPax.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPax.Location = New System.Drawing.Point(316, 289)
        Me.lblTotalPax.Name = "lblTotalPax"
        Me.lblTotalPax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalPax.Size = New System.Drawing.Size(90, 41)
        Me.lblTotalPax.TabIndex = 70
        Me.lblTotalPax.Text = "------"
        Me.lblTotalPax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.BackColor = System.Drawing.Color.Lavender
        Me.Label21.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label21.Location = New System.Drawing.Point(295, 241)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 107)
        Me.Label21.TabIndex = 77
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Lavender
        Me.Label9.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(311, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 26)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Check Out:"
        '
        'lblCheckOut
        '
        Me.lblCheckOut.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCheckOut.AutoSize = True
        Me.lblCheckOut.BackColor = System.Drawing.Color.Lavender
        Me.lblCheckOut.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckOut.Location = New System.Drawing.Point(316, 164)
        Me.lblCheckOut.Name = "lblCheckOut"
        Me.lblCheckOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCheckOut.Size = New System.Drawing.Size(75, 32)
        Me.lblCheckOut.TabIndex = 57
        Me.lblCheckOut.Text = "------"
        Me.lblCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.Color.Lavender
        Me.Label18.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Location = New System.Drawing.Point(295, 112)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(140, 107)
        Me.Label18.TabIndex = 76
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Lavender
        Me.Label10.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(54, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 26)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Check In:"
        '
        'lblCheckIn
        '
        Me.lblCheckIn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCheckIn.AutoSize = True
        Me.lblCheckIn.BackColor = System.Drawing.Color.Lavender
        Me.lblCheckIn.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckIn.Location = New System.Drawing.Point(59, 164)
        Me.lblCheckIn.Name = "lblCheckIn"
        Me.lblCheckIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCheckIn.Size = New System.Drawing.Size(175, 32)
        Me.lblCheckIn.TabIndex = 56
        Me.lblCheckIn.Text = "----------------"
        Me.lblCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label16.BackColor = System.Drawing.Color.Lavender
        Me.Label16.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label16.Location = New System.Drawing.Point(29, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(252, 107)
        Me.Label16.TabIndex = 75
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRoomNo.AutoSize = True
        Me.lblRoomNo.BackColor = System.Drawing.Color.Lavender
        Me.lblRoomNo.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNo.Location = New System.Drawing.Point(59, 289)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRoomNo.Size = New System.Drawing.Size(174, 41)
        Me.lblRoomNo.TabIndex = 63
        Me.lblRoomNo.Text = "-------------"
        Me.lblRoomNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Lavender
        Me.Label4.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(54, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 26)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Room No."
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.BackColor = System.Drawing.Color.Lavender
        Me.Label2.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(29, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 107)
        Me.Label2.TabIndex = 57
        '
        'lblCheckinStatus
        '
        Me.lblCheckinStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCheckinStatus.AutoSize = True
        Me.lblCheckinStatus.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckinStatus.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblCheckinStatus.Location = New System.Drawing.Point(32, 52)
        Me.lblCheckinStatus.Name = "lblCheckinStatus"
        Me.lblCheckinStatus.Size = New System.Drawing.Size(335, 37)
        Me.lblCheckinStatus.TabIndex = 74
        Me.lblCheckinStatus.Text = "STATUS: ------------------"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(25, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 26)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "NOTES"
        '
        'lbNotes
        '
        Me.lbNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNotes.BackColor = System.Drawing.Color.Azure
        Me.lbNotes.FormattingEnabled = True
        Me.lbNotes.ItemHeight = 28
        Me.lbNotes.Location = New System.Drawing.Point(30, 412)
        Me.lbNotes.Name = "lbNotes"
        Me.lbNotes.Size = New System.Drawing.Size(699, 116)
        Me.lbNotes.TabIndex = 68
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label8.Location = New System.Drawing.Point(-389, 702)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 26)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Paid:"
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.BackColor = System.Drawing.Color.Lavender
        Me.Label23.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label23.Location = New System.Drawing.Point(449, 112)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(278, 107)
        Me.Label23.TabIndex = 79
        '
        'lblRemaining
        '
        Me.lblRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemaining.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRemaining.Location = New System.Drawing.Point(250, 215)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRemaining.Size = New System.Drawing.Size(187, 41)
        Me.lblRemaining.TabIndex = 62
        Me.lblRemaining.Text = "----------------"
        Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaid
        '
        Me.lblPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaid.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPaid.Location = New System.Drawing.Point(253, 162)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPaid.Size = New System.Drawing.Size(187, 41)
        Me.lblPaid.TabIndex = 61
        Me.lblPaid.Text = "----------------"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRequiredDeposit
        '
        Me.lblRequiredDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRequiredDeposit.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequiredDeposit.Location = New System.Drawing.Point(250, 109)
        Me.lblRequiredDeposit.Name = "lblRequiredDeposit"
        Me.lblRequiredDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRequiredDeposit.Size = New System.Drawing.Size(187, 41)
        Me.lblRequiredDeposit.TabIndex = 60
        Me.lblRequiredDeposit.Text = "----------------"
        Me.lblRequiredDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(250, 55)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(187, 41)
        Me.lblTotal.TabIndex = 59
        Me.lblTotal.Text = "----------------"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(20, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 26)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Required Deposit:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(22, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 26)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Paid:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(22, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 26)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Remaining Balance:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.lblRemaining)
        Me.GroupBox6.Controls.Add(Me.lblTotal)
        Me.GroupBox6.Controls.Add(Me.lblRequiredDeposit)
        Me.GroupBox6.Controls.Add(Me.lblPaid)
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox6.Location = New System.Drawing.Point(1426, 66)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(468, 285)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BILLING SUMMARY"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(22, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 26)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Total  Amount:"
        '
        'gbPayment
        '
        Me.gbPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPayment.BackColor = System.Drawing.Color.White
        Me.gbPayment.Controls.Add(Me.btnAddPayment)
        Me.gbPayment.Controls.Add(Me.Label31)
        Me.gbPayment.Controls.Add(Me.txtPaymentAmount)
        Me.gbPayment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPayment.Location = New System.Drawing.Point(1426, 382)
        Me.gbPayment.Name = "gbPayment"
        Me.gbPayment.Size = New System.Drawing.Size(468, 267)
        Me.gbPayment.TabIndex = 76
        Me.gbPayment.TabStop = False
        Me.gbPayment.Text = "PAYMENT"
        '
        'btnAddPayment
        '
        Me.btnAddPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPayment.BackColor = System.Drawing.Color.Teal
        Me.btnAddPayment.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPayment.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAddPayment.Location = New System.Drawing.Point(25, 177)
        Me.btnAddPayment.Name = "btnAddPayment"
        Me.btnAddPayment.Size = New System.Drawing.Size(428, 61)
        Me.btnAddPayment.TabIndex = 66
        Me.btnAddPayment.Text = "Collect Payment"
        Me.btnAddPayment.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label31.Location = New System.Drawing.Point(22, 57)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(182, 28)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "Payment Amount:"
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaymentAmount.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPaymentAmount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentAmount.Location = New System.Drawing.Point(25, 104)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(428, 61)
        Me.txtPaymentAmount.TabIndex = 64
        Me.txtPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEmail
        '
        Me.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEmail.BackColor = System.Drawing.Color.Lavender
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(30, 151)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblEmail.Size = New System.Drawing.Size(401, 33)
        Me.lblEmail.TabIndex = 54
        Me.lblEmail.Text = "-------------------"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPhone
        '
        Me.lblPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPhone.BackColor = System.Drawing.Color.Lavender
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhone.Location = New System.Drawing.Point(470, 74)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPhone.Size = New System.Drawing.Size(257, 33)
        Me.lblPhone.TabIndex = 53
        Me.lblPhone.Text = "-------------------"
        Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label12.Location = New System.Drawing.Point(25, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 26)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Email:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label13.Location = New System.Drawing.Point(465, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 26)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Phone:"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(25, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 26)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Guest Name:"
        '
        'lblGuestName
        '
        Me.lblGuestName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGuestName.BackColor = System.Drawing.Color.Lavender
        Me.lblGuestName.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuestName.Location = New System.Drawing.Point(30, 75)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblGuestName.Size = New System.Drawing.Size(406, 33)
        Me.lblGuestName.TabIndex = 52
        Me.lblGuestName.Text = "-------------------"
        Me.lblGuestName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.lblResNo)
        Me.GroupBox4.Controls.Add(Me.lblGuestName)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.lblPhone)
        Me.GroupBox4.Controls.Add(Me.lblEmail)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(643, 66)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(760, 207)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "RESERVATION LOOKUP"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label17.Location = New System.Drawing.Point(465, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 26)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Reservation No:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblResNo
        '
        Me.lblResNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResNo.BackColor = System.Drawing.Color.Lavender
        Me.lblResNo.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResNo.Location = New System.Drawing.Point(470, 151)
        Me.lblResNo.Name = "lblResNo"
        Me.lblResNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblResNo.Size = New System.Drawing.Size(274, 33)
        Me.lblResNo.TabIndex = 56
        Me.lblResNo.Text = "-------------------"
        Me.lblResNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Teal
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip2.TabIndex = 79
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'mnu
        '
        Me.mnu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.mnuExit})
        Me.mnu.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnu.ForeColor = System.Drawing.SystemColors.Control
        Me.mnu.Image = CType(resources.GetObject("mnu.Image"), System.Drawing.Image)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(80, 34)
        Me.mnu.Text = "File"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
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
        'frmCheckIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gbGuestDetails)
        Me.Controls.Add(Me.gbPayment)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnConfirmCheckIn)
        Me.Controls.Add(Me.gbReservationLookUp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbRooms)
        Me.Name = "frmCheckIn"
        Me.Text = "CheckIn"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbRooms.ResumeLayout(False)
        CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gbReservationLookUp.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gbGuestDetails.ResumeLayout(False)
        Me.gbGuestDetails.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbPayment.ResumeLayout(False)
        Me.gbPayment.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbRooms As GroupBox
    Friend WithEvents dgvReservations As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbReservationLookUp As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents gbGuestDetails As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblRoomNo As Label
    Friend WithEvents lblRemaining As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents lblRequiredDeposit As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblNights As Label
    Friend WithEvents lblCheckOut As Label
    Friend WithEvents lblCheckIn As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents gbPayment As GroupBox
    Friend WithEvents btnAddPayment As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents txtPaymentAmount As TextBox
    Friend WithEvents btnConfirmCheckIn As Button
    Friend WithEvents lblOperator As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents btnReservation As Button
    Friend WithEvents btnCheckingIn As Button
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents lbNotes As ListBox
    Friend WithEvents lblTotalPax As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblGuestName As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CachedReservationSlip1 As CachedReservationSlip
    Friend WithEvents lblTypeClass As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents mnu As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents Label17 As Label
    Friend WithEvents lblResNo As Label
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCheckinStatus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents btnBilling As Button
    Friend WithEvents lblSummary As Label
    Friend WithEvents btnCreate As Button
End Class
