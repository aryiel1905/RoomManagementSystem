<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DiningNBar
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
        Me.tcDiningNBar = New System.Windows.Forms.TabControl()
        Me.tbPOS = New System.Windows.Forms.TabPage()
        Me.btnPOSClear = New System.Windows.Forms.Button()
        Me.txtSearchPOS = New System.Windows.Forms.TextBox()
        Me.btnSides = New System.Windows.Forms.Button()
        Me.dgvCurrentOrder = New System.Windows.Forms.DataGridView()
        Me.btnDessert = New System.Windows.Forms.Button()
        Me.dgvPOS = New System.Windows.Forms.DataGridView()
        Me.btnDrinks = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRoomNumber = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnGuest = New System.Windows.Forms.Button()
        Me.btnWalkIn = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnMainCourse = New System.Windows.Forms.Button()
        Me.btnAppetizers = New System.Windows.Forms.Button()
        Me.btnAllCategory = New System.Windows.Forms.Button()
        Me.tpOrders = New System.Windows.Forms.TabPage()
        Me.btnOrderClear = New System.Windows.Forms.Button()
        Me.txtOrderSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.dgvOrderDetails = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnServed = New System.Windows.Forms.Button()
        Me.btnOrderReciept = New System.Windows.Forms.Button()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.tpMenuItems = New System.Windows.Forms.TabPage()
        Me.btnMenuClear = New System.Windows.Forms.Button()
        Me.dgvMenu = New System.Windows.Forms.DataGridView()
        Me.txtMenuSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnMenuDelete = New System.Windows.Forms.Button()
        Me.btnMenuAdd = New System.Windows.Forms.Button()
        Me.btnMenuSave = New System.Windows.Forms.Button()
        Me.btnMenuEdit = New System.Windows.Forms.Button()
        Me.btnMenuCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtSell = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tpStocks = New System.Windows.Forms.TabPage()
        Me.btnStocksClear = New System.Windows.Forms.Button()
        Me.txtStocksSearch = New System.Windows.Forms.TextBox()
        Me.btnStocksDel = New System.Windows.Forms.Button()
        Me.btnStocksAdd = New System.Windows.Forms.Button()
        Me.btnStocksSave = New System.Windows.Forms.Button()
        Me.btnStocksEdit = New System.Windows.Forms.Button()
        Me.dgvStocks = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.CachedReservationSlip1 = New RoomManagementSystem.CachedReservationSlip()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tcDiningNBar.SuspendLayout()
        Me.tbPOS.SuspendLayout()
        CType(Me.dgvCurrentOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tpOrders.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMenuItems.SuspendLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.tpStocks.SuspendLayout()
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcDiningNBar
        '
        Me.tcDiningNBar.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tcDiningNBar.Controls.Add(Me.tbPOS)
        Me.tcDiningNBar.Controls.Add(Me.tpOrders)
        Me.tcDiningNBar.Controls.Add(Me.tpMenuItems)
        Me.tcDiningNBar.Controls.Add(Me.tpStocks)
        Me.tcDiningNBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tcDiningNBar.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcDiningNBar.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcDiningNBar.ItemSize = New System.Drawing.Size(60, 150)
        Me.tcDiningNBar.Location = New System.Drawing.Point(0, 53)
        Me.tcDiningNBar.Multiline = True
        Me.tcDiningNBar.Name = "tcDiningNBar"
        Me.tcDiningNBar.SelectedIndex = 0
        Me.tcDiningNBar.Size = New System.Drawing.Size(1924, 917)
        Me.tcDiningNBar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcDiningNBar.TabIndex = 0
        '
        'tbPOS
        '
        Me.tbPOS.Controls.Add(Me.btnPOSClear)
        Me.tbPOS.Controls.Add(Me.txtSearchPOS)
        Me.tbPOS.Controls.Add(Me.dgvCurrentOrder)
        Me.tbPOS.Controls.Add(Me.dgvPOS)
        Me.tbPOS.Controls.Add(Me.btnDrinks)
        Me.tbPOS.Controls.Add(Me.GroupBox2)
        Me.tbPOS.Controls.Add(Me.btnMainCourse)
        Me.tbPOS.Controls.Add(Me.btnAppetizers)
        Me.tbPOS.Controls.Add(Me.btnAllCategory)
        Me.tbPOS.Controls.Add(Me.btnSides)
        Me.tbPOS.Controls.Add(Me.btnDessert)
        Me.tbPOS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.tbPOS.Location = New System.Drawing.Point(154, 4)
        Me.tbPOS.Name = "tbPOS"
        Me.tbPOS.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPOS.Size = New System.Drawing.Size(1766, 909)
        Me.tbPOS.TabIndex = 0
        Me.tbPOS.Text = "POS"
        Me.tbPOS.UseVisualStyleBackColor = True
        '
        'btnPOSClear
        '
        Me.btnPOSClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSClear.BackColor = System.Drawing.Color.MediumAquamarine
        Me.btnPOSClear.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnPOSClear.ForeColor = System.Drawing.Color.White
        Me.btnPOSClear.Location = New System.Drawing.Point(356, 29)
        Me.btnPOSClear.Name = "btnPOSClear"
        Me.btnPOSClear.Size = New System.Drawing.Size(118, 45)
        Me.btnPOSClear.TabIndex = 63
        Me.btnPOSClear.Text = "CLEAR"
        Me.btnPOSClear.UseVisualStyleBackColor = False
        '
        'txtSearchPOS
        '
        Me.txtSearchPOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchPOS.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSearchPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchPOS.Location = New System.Drawing.Point(21, 29)
        Me.txtSearchPOS.Name = "txtSearchPOS"
        Me.txtSearchPOS.Size = New System.Drawing.Size(329, 45)
        Me.txtSearchPOS.TabIndex = 62
        '
        'btnSides
        '
        Me.btnSides.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSides.BackColor = System.Drawing.Color.Teal
        Me.btnSides.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnSides.ForeColor = System.Drawing.Color.White
        Me.btnSides.Location = New System.Drawing.Point(762, 90)
        Me.btnSides.Name = "btnSides"
        Me.btnSides.Size = New System.Drawing.Size(92, 53)
        Me.btnSides.TabIndex = 69
        Me.btnSides.Text = "SIDES"
        Me.btnSides.UseVisualStyleBackColor = False
        '
        'dgvCurrentOrder
        '
        Me.dgvCurrentOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCurrentOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCurrentOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCurrentOrder.Location = New System.Drawing.Point(1085, 90)
        Me.dgvCurrentOrder.Name = "dgvCurrentOrder"
        Me.dgvCurrentOrder.RowTemplate.Height = 24
        Me.dgvCurrentOrder.Size = New System.Drawing.Size(624, 389)
        Me.dgvCurrentOrder.TabIndex = 3
        '
        'btnDessert
        '
        Me.btnDessert.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDessert.BackColor = System.Drawing.Color.Teal
        Me.btnDessert.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnDessert.ForeColor = System.Drawing.Color.White
        Me.btnDessert.Location = New System.Drawing.Point(638, 90)
        Me.btnDessert.Name = "btnDessert"
        Me.btnDessert.Size = New System.Drawing.Size(118, 53)
        Me.btnDessert.TabIndex = 68
        Me.btnDessert.Text = "DESSERTS"
        Me.btnDessert.UseVisualStyleBackColor = False
        '
        'dgvPOS
        '
        Me.dgvPOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPOS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOS.Location = New System.Drawing.Point(21, 137)
        Me.dgvPOS.Name = "dgvPOS"
        Me.dgvPOS.RowTemplate.Height = 24
        Me.dgvPOS.Size = New System.Drawing.Size(1011, 748)
        Me.dgvPOS.TabIndex = 2
        '
        'btnDrinks
        '
        Me.btnDrinks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDrinks.BackColor = System.Drawing.Color.Teal
        Me.btnDrinks.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnDrinks.ForeColor = System.Drawing.Color.White
        Me.btnDrinks.Location = New System.Drawing.Point(526, 90)
        Me.btnDrinks.Name = "btnDrinks"
        Me.btnDrinks.Size = New System.Drawing.Size(106, 53)
        Me.btnDrinks.TabIndex = 67
        Me.btnDrinks.Text = "DRINKS"
        Me.btnDrinks.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtRoomNumber)
        Me.GroupBox2.Controls.Add(Me.txtGuestName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnGuest)
        Me.GroupBox2.Controls.Add(Me.btnWalkIn)
        Me.GroupBox2.Controls.Add(Me.btnPayment)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(1057, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 879)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtRoomNumber
        '
        Me.txtRoomNumber.Location = New System.Drawing.Point(37, 695)
        Me.txtRoomNumber.Name = "txtRoomNumber"
        Me.txtRoomNumber.Size = New System.Drawing.Size(347, 37)
        Me.txtRoomNumber.TabIndex = 88
        Me.txtRoomNumber.Text = "Room Number"
        '
        'txtGuestName
        '
        Me.txtGuestName.Location = New System.Drawing.Point(37, 646)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(347, 37)
        Me.txtGuestName.TabIndex = 87
        Me.txtGuestName.Text = "Customer / Guest Name"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(20, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 37)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "TOTAL:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(22, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 32)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "CURRENT ORDER"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(138, 37)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(182, 41)
        Me.lblTotal.TabIndex = 86
        Me.lblTotal.Text = "----------------"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGuest
        '
        Me.btnGuest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuest.BackColor = System.Drawing.Color.White
        Me.btnGuest.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnGuest.ForeColor = System.Drawing.Color.Teal
        Me.btnGuest.Location = New System.Drawing.Point(493, 647)
        Me.btnGuest.Name = "btnGuest"
        Me.btnGuest.Size = New System.Drawing.Size(159, 59)
        Me.btnGuest.TabIndex = 72
        Me.btnGuest.Text = "GUEST ROOM"
        Me.btnGuest.UseVisualStyleBackColor = False
        '
        'btnWalkIn
        '
        Me.btnWalkIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWalkIn.BackColor = System.Drawing.Color.Teal
        Me.btnWalkIn.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnWalkIn.ForeColor = System.Drawing.Color.White
        Me.btnWalkIn.Location = New System.Drawing.Point(258, 647)
        Me.btnWalkIn.Name = "btnWalkIn"
        Me.btnWalkIn.Size = New System.Drawing.Size(217, 59)
        Me.btnWalkIn.TabIndex = 71
        Me.btnWalkIn.Text = "WALK-IN"
        Me.btnWalkIn.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayment.BackColor = System.Drawing.Color.Teal
        Me.btnPayment.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnPayment.ForeColor = System.Drawing.Color.White
        Me.btnPayment.Location = New System.Drawing.Point(396, 777)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(256, 59)
        Me.btnPayment.TabIndex = 70
        Me.btnPayment.Text = "PAYMENT"
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnMainCourse
        '
        Me.btnMainCourse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMainCourse.BackColor = System.Drawing.Color.Teal
        Me.btnMainCourse.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnMainCourse.ForeColor = System.Drawing.Color.White
        Me.btnMainCourse.Location = New System.Drawing.Point(356, 89)
        Me.btnMainCourse.Name = "btnMainCourse"
        Me.btnMainCourse.Size = New System.Drawing.Size(164, 53)
        Me.btnMainCourse.TabIndex = 66
        Me.btnMainCourse.Text = "MAIN COURSE"
        Me.btnMainCourse.UseVisualStyleBackColor = False
        '
        'btnAppetizers
        '
        Me.btnAppetizers.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAppetizers.BackColor = System.Drawing.Color.Teal
        Me.btnAppetizers.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnAppetizers.ForeColor = System.Drawing.Color.White
        Me.btnAppetizers.Location = New System.Drawing.Point(209, 89)
        Me.btnAppetizers.Name = "btnAppetizers"
        Me.btnAppetizers.Size = New System.Drawing.Size(141, 53)
        Me.btnAppetizers.TabIndex = 65
        Me.btnAppetizers.Text = "APPETIZERS"
        Me.btnAppetizers.UseVisualStyleBackColor = False
        '
        'btnAllCategory
        '
        Me.btnAllCategory.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAllCategory.BackColor = System.Drawing.Color.Teal
        Me.btnAllCategory.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnAllCategory.ForeColor = System.Drawing.Color.White
        Me.btnAllCategory.Location = New System.Drawing.Point(21, 89)
        Me.btnAllCategory.Name = "btnAllCategory"
        Me.btnAllCategory.Size = New System.Drawing.Size(182, 53)
        Me.btnAllCategory.TabIndex = 64
        Me.btnAllCategory.Text = "ALL CATEGORIES"
        Me.btnAllCategory.UseVisualStyleBackColor = False
        '
        'tpOrders
        '
        Me.tpOrders.Controls.Add(Me.btnOrderClear)
        Me.tpOrders.Controls.Add(Me.txtOrderSearch)
        Me.tpOrders.Controls.Add(Me.GroupBox3)
        Me.tpOrders.Controls.Add(Me.dgvOrders)
        Me.tpOrders.Location = New System.Drawing.Point(154, 4)
        Me.tpOrders.Name = "tpOrders"
        Me.tpOrders.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrders.Size = New System.Drawing.Size(1766, 909)
        Me.tpOrders.TabIndex = 1
        Me.tpOrders.Text = "Orders"
        Me.tpOrders.UseVisualStyleBackColor = True
        '
        'btnOrderClear
        '
        Me.btnOrderClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderClear.BackColor = System.Drawing.Color.Teal
        Me.btnOrderClear.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnOrderClear.ForeColor = System.Drawing.Color.White
        Me.btnOrderClear.Location = New System.Drawing.Point(1204, 26)
        Me.btnOrderClear.Name = "btnOrderClear"
        Me.btnOrderClear.Size = New System.Drawing.Size(118, 45)
        Me.btnOrderClear.TabIndex = 67
        Me.btnOrderClear.Text = "CLEAR"
        Me.btnOrderClear.UseVisualStyleBackColor = False
        '
        'txtOrderSearch
        '
        Me.txtOrderSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderSearch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtOrderSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderSearch.Location = New System.Drawing.Point(931, 26)
        Me.txtOrderSearch.Name = "txtOrderSearch"
        Me.txtOrderSearch.Size = New System.Drawing.Size(260, 45)
        Me.txtOrderSearch.TabIndex = 66
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnCancelOrder)
        Me.GroupBox3.Controls.Add(Me.dgvOrderDetails)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btnServed)
        Me.GroupBox3.Controls.Add(Me.btnOrderReciept)
        Me.GroupBox3.Location = New System.Drawing.Point(1339, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 879)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelOrder.BackColor = System.Drawing.Color.Firebrick
        Me.btnCancelOrder.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnCancelOrder.ForeColor = System.Drawing.Color.White
        Me.btnCancelOrder.Location = New System.Drawing.Point(23, 621)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(347, 49)
        Me.btnCancelOrder.TabIndex = 81
        Me.btnCancelOrder.Text = "CANCEL ORDER"
        Me.btnCancelOrder.UseVisualStyleBackColor = False
        '
        'dgvOrderDetails
        '
        Me.dgvOrderDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrderDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderDetails.Location = New System.Drawing.Point(23, 85)
        Me.dgvOrderDetails.Name = "dgvOrderDetails"
        Me.dgvOrderDetails.RowTemplate.Height = 24
        Me.dgvOrderDetails.Size = New System.Drawing.Size(347, 443)
        Me.dgvOrderDetails.TabIndex = 66
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(19, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 32)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "ORDER DETAILS"
        '
        'btnServed
        '
        Me.btnServed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnServed.BackColor = System.Drawing.Color.Teal
        Me.btnServed.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnServed.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnServed.Location = New System.Drawing.Point(23, 554)
        Me.btnServed.Name = "btnServed"
        Me.btnServed.Size = New System.Drawing.Size(347, 49)
        Me.btnServed.TabIndex = 71
        Me.btnServed.Text = "MARKED AS SERVED"
        Me.btnServed.UseVisualStyleBackColor = False
        '
        'btnOrderReciept
        '
        Me.btnOrderReciept.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderReciept.BackColor = System.Drawing.Color.Teal
        Me.btnOrderReciept.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnOrderReciept.ForeColor = System.Drawing.Color.White
        Me.btnOrderReciept.Location = New System.Drawing.Point(23, 795)
        Me.btnOrderReciept.Name = "btnOrderReciept"
        Me.btnOrderReciept.Size = New System.Drawing.Size(347, 59)
        Me.btnOrderReciept.TabIndex = 70
        Me.btnOrderReciept.Text = "PRINT RECIEPT"
        Me.btnOrderReciept.UseVisualStyleBackColor = False
        '
        'dgvOrders
        '
        Me.dgvOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrders.Location = New System.Drawing.Point(20, 91)
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.RowTemplate.Height = 24
        Me.dgvOrders.Size = New System.Drawing.Size(1302, 794)
        Me.dgvOrders.TabIndex = 64
        '
        'tpMenuItems
        '
        Me.tpMenuItems.Controls.Add(Me.btnMenuClear)
        Me.tpMenuItems.Controls.Add(Me.dgvMenu)
        Me.tpMenuItems.Controls.Add(Me.txtMenuSearch)
        Me.tpMenuItems.Controls.Add(Me.GroupBox5)
        Me.tpMenuItems.Location = New System.Drawing.Point(154, 4)
        Me.tpMenuItems.Name = "tpMenuItems"
        Me.tpMenuItems.Size = New System.Drawing.Size(1766, 909)
        Me.tpMenuItems.TabIndex = 2
        Me.tpMenuItems.Text = "Menu"
        Me.tpMenuItems.UseVisualStyleBackColor = True
        '
        'btnMenuClear
        '
        Me.btnMenuClear.BackColor = System.Drawing.Color.Teal
        Me.btnMenuClear.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnMenuClear.ForeColor = System.Drawing.Color.White
        Me.btnMenuClear.Location = New System.Drawing.Point(383, 33)
        Me.btnMenuClear.Name = "btnMenuClear"
        Me.btnMenuClear.Size = New System.Drawing.Size(118, 45)
        Me.btnMenuClear.TabIndex = 90
        Me.btnMenuClear.Text = "CLEAR"
        Me.btnMenuClear.UseVisualStyleBackColor = False
        '
        'dgvMenu
        '
        Me.dgvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMenu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.Location = New System.Drawing.Point(526, 33)
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.RowTemplate.Height = 24
        Me.dgvMenu.Size = New System.Drawing.Size(1217, 852)
        Me.dgvMenu.TabIndex = 65
        '
        'txtMenuSearch
        '
        Me.txtMenuSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMenuSearch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMenuSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenuSearch.Location = New System.Drawing.Point(22, 33)
        Me.txtMenuSearch.Name = "txtMenuSearch"
        Me.txtMenuSearch.Size = New System.Drawing.Size(349, 45)
        Me.txtMenuSearch.TabIndex = 89
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.btnMenuDelete)
        Me.GroupBox5.Controls.Add(Me.btnMenuAdd)
        Me.GroupBox5.Controls.Add(Me.btnMenuSave)
        Me.GroupBox5.Controls.Add(Me.btnMenuEdit)
        Me.GroupBox5.Controls.Add(Me.btnMenuCancel)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.cboCategory)
        Me.GroupBox5.Controls.Add(Me.txtCost)
        Me.GroupBox5.Controls.Add(Me.txtItemName)
        Me.GroupBox5.Controls.Add(Me.txtSell)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Location = New System.Drawing.Point(22, 109)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(479, 420)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "MENU FORM"
        '
        'btnMenuDelete
        '
        Me.btnMenuDelete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuDelete.BackColor = System.Drawing.Color.Teal
        Me.btnMenuDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnMenuDelete.FlatAppearance.BorderSize = 3
        Me.btnMenuDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuDelete.ForeColor = System.Drawing.Color.Azure
        Me.btnMenuDelete.Location = New System.Drawing.Point(241, 343)
        Me.btnMenuDelete.Name = "btnMenuDelete"
        Me.btnMenuDelete.Size = New System.Drawing.Size(217, 50)
        Me.btnMenuDelete.TabIndex = 88
        Me.btnMenuDelete.Text = "Delete"
        Me.btnMenuDelete.UseVisualStyleBackColor = False
        '
        'btnMenuAdd
        '
        Me.btnMenuAdd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuAdd.BackColor = System.Drawing.Color.Teal
        Me.btnMenuAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnMenuAdd.FlatAppearance.BorderSize = 3
        Me.btnMenuAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuAdd.ForeColor = System.Drawing.Color.Azure
        Me.btnMenuAdd.Location = New System.Drawing.Point(22, 288)
        Me.btnMenuAdd.Name = "btnMenuAdd"
        Me.btnMenuAdd.Size = New System.Drawing.Size(143, 50)
        Me.btnMenuAdd.TabIndex = 84
        Me.btnMenuAdd.Text = "Add"
        Me.btnMenuAdd.UseVisualStyleBackColor = False
        '
        'btnMenuSave
        '
        Me.btnMenuSave.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuSave.BackColor = System.Drawing.Color.Teal
        Me.btnMenuSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnMenuSave.FlatAppearance.BorderSize = 3
        Me.btnMenuSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuSave.ForeColor = System.Drawing.Color.Azure
        Me.btnMenuSave.Location = New System.Drawing.Point(314, 288)
        Me.btnMenuSave.Name = "btnMenuSave"
        Me.btnMenuSave.Size = New System.Drawing.Size(143, 50)
        Me.btnMenuSave.TabIndex = 86
        Me.btnMenuSave.Text = "Save"
        Me.btnMenuSave.UseVisualStyleBackColor = False
        '
        'btnMenuEdit
        '
        Me.btnMenuEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuEdit.BackColor = System.Drawing.Color.Teal
        Me.btnMenuEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnMenuEdit.FlatAppearance.BorderSize = 3
        Me.btnMenuEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuEdit.ForeColor = System.Drawing.Color.Azure
        Me.btnMenuEdit.Location = New System.Drawing.Point(168, 288)
        Me.btnMenuEdit.Name = "btnMenuEdit"
        Me.btnMenuEdit.Size = New System.Drawing.Size(143, 50)
        Me.btnMenuEdit.TabIndex = 85
        Me.btnMenuEdit.Text = "Edit"
        Me.btnMenuEdit.UseVisualStyleBackColor = False
        '
        'btnMenuCancel
        '
        Me.btnMenuCancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuCancel.BackColor = System.Drawing.Color.Teal
        Me.btnMenuCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnMenuCancel.FlatAppearance.BorderSize = 3
        Me.btnMenuCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuCancel.ForeColor = System.Drawing.Color.Azure
        Me.btnMenuCancel.Location = New System.Drawing.Point(22, 343)
        Me.btnMenuCancel.Name = "btnMenuCancel"
        Me.btnMenuCancel.Size = New System.Drawing.Size(213, 50)
        Me.btnMenuCancel.TabIndex = 87
        Me.btnMenuCancel.Text = "Cancel"
        Me.btnMenuCancel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(248, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 23)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "BASE COST"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(18, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 23)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "CATEGORY"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(18, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 23)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "ITEM NAME"
        '
        'cboCategory
        '
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Appetizers", "Main Course", "Drinks", "Desserts", "Sides", "Amenities"})
        Me.cboCategory.Location = New System.Drawing.Point(22, 155)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(436, 30)
        Me.cboCategory.TabIndex = 80
        '
        'txtCost
        '
        Me.txtCost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCost.Location = New System.Drawing.Point(252, 229)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(206, 37)
        Me.txtCost.TabIndex = 79
        '
        'txtItemName
        '
        Me.txtItemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemName.Location = New System.Drawing.Point(22, 74)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(436, 37)
        Me.txtItemName.TabIndex = 78
        '
        'txtSell
        '
        Me.txtSell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSell.Location = New System.Drawing.Point(22, 229)
        Me.txtSell.Name = "txtSell"
        Me.txtSell.Size = New System.Drawing.Size(206, 37)
        Me.txtSell.TabIndex = 75
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label13.Location = New System.Drawing.Point(18, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 23)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "SELLING PRICE"
        '
        'tpStocks
        '
        Me.tpStocks.Controls.Add(Me.btnStocksClear)
        Me.tpStocks.Controls.Add(Me.txtStocksSearch)
        Me.tpStocks.Controls.Add(Me.btnStocksDel)
        Me.tpStocks.Controls.Add(Me.btnStocksAdd)
        Me.tpStocks.Controls.Add(Me.btnStocksSave)
        Me.tpStocks.Controls.Add(Me.btnStocksEdit)
        Me.tpStocks.Controls.Add(Me.dgvStocks)
        Me.tpStocks.Location = New System.Drawing.Point(154, 4)
        Me.tpStocks.Name = "tpStocks"
        Me.tpStocks.Size = New System.Drawing.Size(1766, 909)
        Me.tpStocks.TabIndex = 3
        Me.tpStocks.Text = "Stocks"
        Me.tpStocks.UseVisualStyleBackColor = True
        '
        'btnStocksClear
        '
        Me.btnStocksClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStocksClear.BackColor = System.Drawing.Color.Teal
        Me.btnStocksClear.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnStocksClear.ForeColor = System.Drawing.Color.White
        Me.btnStocksClear.Location = New System.Drawing.Point(298, 20)
        Me.btnStocksClear.Name = "btnStocksClear"
        Me.btnStocksClear.Size = New System.Drawing.Size(118, 52)
        Me.btnStocksClear.TabIndex = 95
        Me.btnStocksClear.Text = "CLEAR"
        Me.btnStocksClear.UseVisualStyleBackColor = False
        '
        'txtStocksSearch
        '
        Me.txtStocksSearch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStocksSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStocksSearch.Location = New System.Drawing.Point(25, 24)
        Me.txtStocksSearch.Name = "txtStocksSearch"
        Me.txtStocksSearch.Size = New System.Drawing.Size(260, 45)
        Me.txtStocksSearch.TabIndex = 94
        '
        'btnStocksDel
        '
        Me.btnStocksDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnStocksDel.BackColor = System.Drawing.Color.Teal
        Me.btnStocksDel.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnStocksDel.FlatAppearance.BorderSize = 3
        Me.btnStocksDel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStocksDel.ForeColor = System.Drawing.Color.Azure
        Me.btnStocksDel.Location = New System.Drawing.Point(1587, 19)
        Me.btnStocksDel.Name = "btnStocksDel"
        Me.btnStocksDel.Size = New System.Drawing.Size(155, 50)
        Me.btnStocksDel.TabIndex = 93
        Me.btnStocksDel.Text = "Delete"
        Me.btnStocksDel.UseVisualStyleBackColor = False
        '
        'btnStocksAdd
        '
        Me.btnStocksAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnStocksAdd.BackColor = System.Drawing.Color.Teal
        Me.btnStocksAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnStocksAdd.FlatAppearance.BorderSize = 3
        Me.btnStocksAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStocksAdd.ForeColor = System.Drawing.Color.Azure
        Me.btnStocksAdd.Location = New System.Drawing.Point(1119, 19)
        Me.btnStocksAdd.Name = "btnStocksAdd"
        Me.btnStocksAdd.Size = New System.Drawing.Size(143, 50)
        Me.btnStocksAdd.TabIndex = 89
        Me.btnStocksAdd.Text = "Add"
        Me.btnStocksAdd.UseVisualStyleBackColor = False
        '
        'btnStocksSave
        '
        Me.btnStocksSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnStocksSave.BackColor = System.Drawing.Color.Teal
        Me.btnStocksSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnStocksSave.FlatAppearance.BorderSize = 3
        Me.btnStocksSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStocksSave.ForeColor = System.Drawing.Color.Azure
        Me.btnStocksSave.Location = New System.Drawing.Point(1431, 19)
        Me.btnStocksSave.Name = "btnStocksSave"
        Me.btnStocksSave.Size = New System.Drawing.Size(143, 50)
        Me.btnStocksSave.TabIndex = 91
        Me.btnStocksSave.Text = "Save"
        Me.btnStocksSave.UseVisualStyleBackColor = False
        '
        'btnStocksEdit
        '
        Me.btnStocksEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnStocksEdit.BackColor = System.Drawing.Color.Teal
        Me.btnStocksEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnStocksEdit.FlatAppearance.BorderSize = 3
        Me.btnStocksEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStocksEdit.ForeColor = System.Drawing.Color.Azure
        Me.btnStocksEdit.Location = New System.Drawing.Point(1275, 19)
        Me.btnStocksEdit.Name = "btnStocksEdit"
        Me.btnStocksEdit.Size = New System.Drawing.Size(143, 50)
        Me.btnStocksEdit.TabIndex = 90
        Me.btnStocksEdit.Text = "Edit"
        Me.btnStocksEdit.UseVisualStyleBackColor = False
        '
        'dgvStocks
        '
        Me.dgvStocks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStocks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStocks.Location = New System.Drawing.Point(25, 89)
        Me.dgvStocks.Name = "dgvStocks"
        Me.dgvStocks.RowTemplate.Height = 24
        Me.dgvStocks.Size = New System.Drawing.Size(1717, 791)
        Me.dgvStocks.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(7, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 45)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "DINING and BAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(1490, 12)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(402, 32)
        Me.lblDateTime.TabIndex = 27
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOperator
        '
        Me.lblOperator.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Transparent
        Me.lblOperator.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(1193, 12)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(236, 32)
        Me.lblOperator.TabIndex = 28
        Me.lblOperator.Text = "WELCOME, [NAME]"
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Teal
        Me.Button1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(25, 502)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 64)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Teal
        Me.Button2.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(183, 502)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 64)
        Me.Button2.TabIndex = 90
        Me.Button2.Text = " "
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 757)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 100)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Teal
        Me.Button3.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(516, 502)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 64)
        Me.Button3.TabIndex = 92
        Me.Button3.Text = "WALK-IN"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Teal
        Me.Button4.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(358, 502)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(136, 64)
        Me.Button4.TabIndex = 91
        Me.Button4.Text = "WALK-IN"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'DiningNBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tcDiningNBar)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "DiningNBar"
        Me.Text = "DiningNBar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcDiningNBar.ResumeLayout(False)
        Me.tbPOS.ResumeLayout(False)
        Me.tbPOS.PerformLayout()
        CType(Me.dgvCurrentOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpOrders.ResumeLayout(False)
        Me.tpOrders.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMenuItems.ResumeLayout(False)
        Me.tpMenuItems.PerformLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpStocks.ResumeLayout(False)
        Me.tpStocks.PerformLayout()
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tcDiningNBar As TabControl
    Friend WithEvents tbPOS As TabPage
    Friend WithEvents tpOrders As TabPage
    Friend WithEvents tpMenuItems As TabPage
    Friend WithEvents tpStocks As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents dgvPOS As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblOperator As Label
    Friend WithEvents btnPOSClear As Button
    Friend WithEvents txtSearchPOS As TextBox
    Friend WithEvents btnPayment As Button
    Friend WithEvents btnSides As Button
    Friend WithEvents btnDessert As Button
    Friend WithEvents btnDrinks As Button
    Friend WithEvents btnMainCourse As Button
    Friend WithEvents btnAppetizers As Button
    Friend WithEvents btnAllCategory As Button
    Friend WithEvents btnGuest As Button
    Friend WithEvents btnWalkIn As Button
    Friend WithEvents dgvCurrentOrder As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtRoomNumber As TextBox
    Friend WithEvents txtGuestName As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnCancelOrder As Button
    Friend WithEvents dgvOrderDetails As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents btnServed As Button
    Friend WithEvents btnOrderReciept As Button
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtCost As TextBox
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtSell As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents btnMenuDelete As Button
    Friend WithEvents btnMenuAdd As Button
    Friend WithEvents btnMenuSave As Button
    Friend WithEvents btnMenuEdit As Button
    Friend WithEvents btnMenuCancel As Button
    Friend WithEvents dgvStocks As DataGridView
    Friend WithEvents CachedReservationSlip1 As CachedReservationSlip
    Friend WithEvents btnStocksDel As Button
    Friend WithEvents btnStocksAdd As Button
    Friend WithEvents btnStocksSave As Button
    Friend WithEvents btnStocksEdit As Button
    Friend WithEvents btnOrderClear As Button
    Friend WithEvents txtOrderSearch As TextBox
    Friend WithEvents btnMenuClear As Button
    Friend WithEvents txtMenuSearch As TextBox
    Friend WithEvents btnStocksClear As Button
    Friend WithEvents txtStocksSearch As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
