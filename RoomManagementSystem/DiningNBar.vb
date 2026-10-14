Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class DiningNBar
    Private Enum EditMode
        View
        Adding
        Editing
    End Enum

    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly clockTimer As New Timer()
    Private Const AmenityCategory As String = "Amenities"
    Private _tabIcons As ImageList
    Private _currentOrder As DataTable
    Private _posMenu As DataTable
    Private _orders As DataTable
    Private _menuItems As DataTable
    Private _stocks As DataTable
    Private _menuMode As EditMode = EditMode.View
    Private _selectedMenuItemId As Integer = -1
    Private _posCategory As String = ""
    Private _isGuestMode As Boolean = False

    Private Sub DiningNBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tcDiningNBar IsNot Nothing Then
            ConfigureTabIcons()
            tcDiningNBar.DrawMode = TabDrawMode.OwnerDrawFixed
        End If

        ApplyRoomMaintenanceDgvStyle(dgvPOS)
        ApplyRoomMaintenanceDgvStyle(dgvOrders)
        ApplyRoomMaintenanceDgvStyle(dgvMenu)
        ApplyRoomMaintenanceDgvStyle(dgvStocks)

        SetupCurrentOrderGrid()
        LoadPosMenu()
        LoadOrders()
        LoadMenuItems()
        LoadStocks()
        SetOrderMode(isGuest:=False)
        SetMenuMode(EditMode.View)
        SetActiveCategoryButton(btnAllCategory)
        InitHeaderLabels()
    End Sub

    Private Sub ConfigureTabIcons()
        _tabIcons = New ImageList() With {
            .ImageSize = New Size(24, 24),
            .ColorDepth = ColorDepth.Depth32Bit
        }

        AddTabIcon("pos", "shopping-cart.png")
        AddTabIcon("orders", "clipboard-list.png")
        AddTabIcon("menu", "utensils.png")
        AddTabIcon("stocks", "packages.png")

        tcDiningNBar.ImageList = _tabIcons
        tbPOS.ImageKey = "pos"
        tpOrders.ImageKey = "orders"
        tpMenuItems.ImageKey = "menu"
        tpStocks.ImageKey = "stocks"
    End Sub

    Private Sub AddTabIcon(key As String, fileName As String)
        Dim iconPath = Path.Combine(Application.StartupPath, "Icons", fileName)
        If Not File.Exists(iconPath) Then Return

        Using img = Image.FromFile(iconPath)
            _tabIcons.Images.Add(key, CType(img.Clone(), Image))
        End Using
    End Sub

    Private Sub tcDiningNBar_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tcDiningNBar.DrawItem
        Dim tab = tcDiningNBar
        If tab Is Nothing Then Return

        Dim rect = tab.GetTabRect(e.Index)
        Dim isSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        Dim backColor As Color = If(isSelected, Color.Teal, tab.BackColor)
        Dim foreColor As Color = If(isSelected, Color.White, tab.ForeColor)

        Using backBrush As New SolidBrush(backColor)
            e.Graphics.FillRectangle(backBrush, rect)
        End Using

        Dim page = tab.TabPages(e.Index)
        Dim text As String = page.Text
        Dim icon As Image = Nothing
        If tab.ImageList IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(page.ImageKey) Then
            If tab.ImageList.Images.ContainsKey(page.ImageKey) Then
                icon = tab.ImageList.Images(page.ImageKey)
            End If
        End If

        Using textBrush As New SolidBrush(foreColor)
            Using sf As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center}
                Dim paddingLeft As Integer = 25
                Dim textStartX As Integer = rect.X + paddingLeft

                If icon IsNot Nothing Then
                    Dim iconY = rect.Y + CInt((rect.Height - icon.Height) / 2)
                    Dim iconX = rect.X + paddingLeft
                    Dim iconRect = New Rectangle(iconX, iconY, icon.Width, icon.Height)
                    If isSelected Then
                        DrawIconTinted(e.Graphics, icon, iconRect, Color.White)
                    Else
                        e.Graphics.DrawImage(icon, iconRect)
                    End If
                    textStartX = iconX + icon.Width + 6
                End If

                Dim textRect = New Rectangle(textStartX, rect.Y, rect.Width - (textStartX - rect.X) - 4, rect.Height)
                e.Graphics.DrawString(text, tab.Font, textBrush, textRect, sf)
            End Using
        End Using
    End Sub

    Private Sub DrawIconTinted(g As Graphics, img As Image, bounds As Rectangle, tint As Color)
        Using ia As New Imaging.ImageAttributes()
            Dim matrix As New Imaging.ColorMatrix(New Single()() {
                New Single() {0, 0, 0, 0, 0},
                New Single() {0, 0, 0, 0, 0},
                New Single() {0, 0, 0, 0, 0},
                New Single() {0, 0, 0, 1, 0},
                New Single() {tint.R / 255.0F, tint.G / 255.0F, tint.B / 255.0F, 0, 1}
            })
            ia.SetColorMatrix(matrix, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)
            g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
        End Using
    End Sub

    Private Sub SetupCurrentOrderGrid()
        _currentOrder = New DataTable()
        _currentOrder.Columns.Add("ItemID", GetType(Integer))
        _currentOrder.Columns.Add("ItemName", GetType(String))
        _currentOrder.Columns.Add("Qty", GetType(Integer))
        _currentOrder.Columns.Add("UnitPrice", GetType(Decimal))
        _currentOrder.Columns.Add("LineTotal", GetType(Decimal))

        dgvCurrentOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCurrentOrder.AutoGenerateColumns = True
        dgvCurrentOrder.DataSource = _currentOrder
        If dgvCurrentOrder.Columns.Contains("ItemID") Then
            dgvCurrentOrder.Columns("ItemID").Visible = False
        End If
        If dgvCurrentOrder.Columns.Contains("UnitPrice") Then
            dgvCurrentOrder.Columns("UnitPrice").DefaultCellStyle.Format = "₱#,##0.00"
        End If
        If dgvCurrentOrder.Columns.Contains("LineTotal") Then
            dgvCurrentOrder.Columns("LineTotal").DefaultCellStyle.Format = "₱#,##0.00"
        End If
        UpdateOrderTotal()
    End Sub

    Private Sub ApplyRoomMaintenanceDgvStyle(dgv As DataGridView)
        If dgv Is Nothing Then Return

        Dim altStyle As New DataGridViewCellStyle()
        altStyle.BackColor = Color.PaleTurquoise
        dgv.AlternatingRowsDefaultCellStyle = altStyle

        dgv.BackgroundColor = Color.AliceBlue
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        Dim headerStyle As New DataGridViewCellStyle()
        headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        headerStyle.BackColor = Color.DarkSlateGray
        headerStyle.Font = New Font("Segoe UI", 12.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        headerStyle.ForeColor = Color.White
        headerStyle.Padding = New Padding(0, 4, 0, 4)
        headerStyle.SelectionBackColor = SystemColors.Highlight
        headerStyle.SelectionForeColor = SystemColors.HighlightText
        headerStyle.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = headerStyle

        dgv.EnableHeadersVisualStyles = False
        dgv.GridColor = SystemColors.ControlDarkDark

        Dim rowHeaderStyle As New DataGridViewCellStyle()
        rowHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        rowHeaderStyle.BackColor = Color.LightSeaGreen
        rowHeaderStyle.Font = New Font("Segoe UI", 12.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        rowHeaderStyle.ForeColor = Color.White
        rowHeaderStyle.SelectionBackColor = Color.White
        rowHeaderStyle.SelectionForeColor = SystemColors.HighlightText
        rowHeaderStyle.WrapMode = DataGridViewTriState.True
        dgv.RowHeadersDefaultCellStyle = rowHeaderStyle

        dgv.RowHeadersVisible = False

        Dim rowsStyle As New DataGridViewCellStyle()
        rowsStyle.BackColor = Color.Azure
        rowsStyle.Font = New Font("Segoe UI", 12.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        rowsStyle.SelectionBackColor = Color.Gold
        rowsStyle.SelectionForeColor = SystemColors.InfoText
        dgv.RowsDefaultCellStyle = rowsStyle

        dgv.RowTemplate.Height = 28
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
    End Sub

    Private Sub LoadPosMenu(Optional category As String = "", Optional search As String = "")
        Dim sql As String = "SELECT [Item ID] AS ItemID, [Item Name] AS ItemName, [Item Category] AS Category, [Unit Price] AS UnitPrice " &
                            "FROM tblMenuItems WHERE [Is Active]=True"

        Dim parms As New List(Of OleDbParameter)()
        If Not String.IsNullOrWhiteSpace(category) Then
            sql &= " AND [Item Category]=?"
            parms.Add(New OleDbParameter("?", OleDbType.VarWChar) With {.Value = category})
        End If
        If Not String.IsNullOrWhiteSpace(search) Then
            sql &= " AND [Item Name] LIKE ?"
            parms.Add(New OleDbParameter("?", OleDbType.VarWChar) With {.Value = "%" & search & "%"})
        End If
        sql &= " ORDER BY [Item Name];"

        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn),
              da As New OleDbDataAdapter(cmd)
            If parms.Count > 0 Then cmd.Parameters.AddRange(parms.ToArray())
            Dim dt As New DataTable()
            da.Fill(dt)
            _posMenu = dt
            dgvPOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvPOS.AutoGenerateColumns = True
            dgvPOS.DataSource = _posMenu
            If dgvPOS.Columns.Contains("ItemID") Then dgvPOS.Columns("ItemID").Visible = False
            If dgvPOS.Columns.Contains("UnitPrice") Then
                dgvPOS.Columns("UnitPrice").DefaultCellStyle.Format = "₱#,##0.00"
            End If
        End Using
    End Sub

    Private Sub LoadOrders()
        Dim sql As String = "SELECT [OrderID], [Order Date Time], [Order Status], [Payment Mode], [StayID], [Total Amount], [Paid Amount], [Guest Name], [Room No] " &
                            "FROM tblOrders ORDER BY [Order Date Time] DESC;"
        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn),
              da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            _orders = dt
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvOrders.AutoGenerateColumns = True
            dgvOrders.DataSource = _orders
            If dgvOrders.Columns.Contains("StayID") Then dgvOrders.Columns("StayID").Visible = False
            If dgvOrders.Columns.Contains("Total Amount") Then dgvOrders.Columns("Total Amount").DefaultCellStyle.Format = "₱#,##0.00"
            If dgvOrders.Columns.Contains("Paid Amount") Then dgvOrders.Columns("Paid Amount").DefaultCellStyle.Format = "₱#,##0.00"
        End Using
    End Sub

    Private Sub LoadOrderDetails(orderId As Integer)
        Dim sql As String = "SELECT oi.[Item ID], m.[Item Name], oi.[Qty], oi.[Unit Price], oi.[Line Total] " &
                            "FROM (tblOrderItems oi INNER JOIN tblMenuItems m ON oi.[Item ID]=m.[Item ID]) " &
                            "WHERE oi.[Order ID]=?;"
        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn),
              da As New OleDbDataAdapter(cmd)
            cmd.Parameters.Add("?", OleDbType.Integer).Value = orderId
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvOrderDetails.AutoGenerateColumns = True
            dgvOrderDetails.DataSource = dt
            If dgvOrderDetails.Columns.Contains("Item ID") Then dgvOrderDetails.Columns("Item ID").Visible = False
            If dgvOrderDetails.Columns.Contains("Unit Price") Then dgvOrderDetails.Columns("Unit Price").DefaultCellStyle.Format = "₱#,##0.00"
            If dgvOrderDetails.Columns.Contains("Line Total") Then dgvOrderDetails.Columns("Line Total").DefaultCellStyle.Format = "₱#,##0.00"
        End Using
    End Sub

    Private Sub LoadMenuItems()
        Dim sql As String = "SELECT [Item ID], [Item Name], [Item Category], [Unit Price], [Cost], [Is Active], [Created At] FROM tblMenuItems ORDER BY [Item Name];"
        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn),
              da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            _menuItems = dt
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvMenu.AutoGenerateColumns = True
            dgvMenu.DataSource = _menuItems
            If dgvMenu.Columns.Contains("Item ID") Then dgvMenu.Columns("Item ID").Visible = False
            If dgvMenu.Columns.Contains("Unit Price") Then dgvMenu.Columns("Unit Price").DefaultCellStyle.Format = "₱#,##0.00"
            If dgvMenu.Columns.Contains("Cost") Then dgvMenu.Columns("Cost").DefaultCellStyle.Format = "₱#,##0.00"
        End Using

        ConfigureStockColumns()
        If _stocks IsNot Nothing Then
            RefreshStockLookupColumns()
        End If
    End Sub

    Private Sub LoadStocks()
        _stocks = New DataTable()
        _stocks.Columns.Add("StockID", GetType(Integer))
        _stocks.Columns.Add("Item ID", GetType(Integer))
        _stocks.Columns.Add("Item Name", GetType(String))
        _stocks.Columns.Add("Item Category", GetType(String))
        _stocks.Columns.Add("Qty", GetType(Decimal))
        _stocks.Columns.Add("Unit", GetType(String))
        _stocks.Columns.Add("Reorder Level", GetType(Decimal))
        _stocks.Columns.Add("Status", GetType(String))
        _stocks.Columns.Add("Updated", GetType(Date))

        Dim sql As String =
            "SELECT s.[StockID], s.[Item ID], m.[Item Name], m.[Item Category], s.[Qty], s.[Unit], s.[Reorder Level], s.[Status], s.[Updated] " &
            "FROM tblStocks AS s " &
            "LEFT JOIN tblMenuItems AS m ON s.[Item ID]=m.[Item ID] " &
            "ORDER BY m.[Item Name], s.[StockID];"

        Try
            Using conn As New OleDbConnection(ConnStr),
                  cmd As New OleDbCommand(sql, conn),
                  da As New OleDbDataAdapter(cmd)
                da.Fill(_stocks)
            End Using
        Catch ex As OleDbException
            dgvStocks.DataSource = _stocks
            ConfigureStockColumns()
            RefreshStockLookupColumns()
            dgvStocks.AllowUserToAddRows = False
            dgvStocks.ReadOnly = True
            dgvStocks.EditMode = DataGridViewEditMode.EditProgrammatically

            MessageBox.Show(
                "Unable to load stocks right now because tblStocks is locked by another open session or by Microsoft Access." & Environment.NewLine &
                "Close any other screen or database window using tblStocks, then try again.",
                "Stocks Locked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            'Return
        End Try

        dgvStocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStocks.AutoGenerateColumns = False
        dgvStocks.DataSource = _stocks
        ConfigureStockColumns()
        RefreshStockLookupColumns()
        dgvStocks.AllowUserToAddRows = False
        dgvStocks.ReadOnly = False
        dgvStocks.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub ConfigureStockColumns()
        If dgvStocks Is Nothing OrElse _menuItems Is Nothing Then Return
        If dgvStocks.Columns.Count > 0 AndAlso TypeOf dgvStocks.Columns("Item ID") Is DataGridViewComboBoxColumn Then Return

        dgvStocks.Columns.Clear()
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "StockID", .HeaderText = "StockID", .Name = "StockID", .Visible = False, .ReadOnly = True})
        dgvStocks.Columns.Add(New DataGridViewComboBoxColumn() With {
            .DataPropertyName = "Item ID",
            .HeaderText = "Item Name",
            .Name = "Item Picker",
            .DisplayMember = "Item Name",
            .ValueMember = "Item ID",
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
            .FlatStyle = FlatStyle.Flat
        })
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Item ID", .HeaderText = "Item ID", .Name = "Item ID", .Visible = False, .ReadOnly = True})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Item Name", .HeaderText = "Selected Item", .Name = "Item Name", .ReadOnly = True})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Item Category", .HeaderText = "Category", .Name = "Item Category", .ReadOnly = True})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Qty", .HeaderText = "Qty", .Name = "Qty"})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Unit", .HeaderText = "Unit", .Name = "Unit"})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Reorder Level", .HeaderText = "Reorder Level", .Name = "Reorder Level"})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Status", .HeaderText = "Status", .Name = "Status"})
        dgvStocks.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Updated", .HeaderText = "Updated", .Name = "Updated", .ReadOnly = True})

        dgvStocks.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStocks.Columns("Reorder Level").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStocks.Columns("Updated").DefaultCellStyle.Format = "MMM d, yyyy hh:mm tt"
    End Sub

    Private Sub RefreshStockLookupColumns()
        If dgvStocks Is Nothing OrElse _menuItems Is Nothing OrElse Not dgvStocks.Columns.Contains("Item Picker") Then Return
        Dim itemColumn = TryCast(dgvStocks.Columns("Item Picker"), DataGridViewComboBoxColumn)
        If itemColumn Is Nothing Then Return

        itemColumn.DataSource = _menuItems.Copy()
        itemColumn.DisplayMember = "Item Name"
        itemColumn.ValueMember = "Item ID"
    End Sub

    Private Sub AddItemToOrder(itemId As Integer, itemName As String, unitPrice As Decimal)
        Dim row = _currentOrder.AsEnumerable().FirstOrDefault(Function(r) Convert.ToInt32(r("ItemID")) = itemId)
        If row Is Nothing Then
            Dim newRow = _currentOrder.NewRow()
            newRow("ItemID") = itemId
            newRow("ItemName") = itemName
            newRow("Qty") = 1
            newRow("UnitPrice") = unitPrice
            newRow("LineTotal") = unitPrice
            _currentOrder.Rows.Add(newRow)
        Else
            Dim qty = Convert.ToInt32(row("Qty")) + 1
            row("Qty") = qty
            row("LineTotal") = qty * unitPrice
        End If
        UpdateOrderTotal()
    End Sub

    Private Sub UpdateOrderTotal()
        Dim total As Decimal = 0D
        For Each r As DataRow In _currentOrder.Rows
            total += SafeDec(r("LineTotal"))
        Next
        lblTotal.Text = total.ToString("₱#,##0.00")
    End Sub

    Private Function SafeDec(value As Object) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D
        Dim result As Decimal = 0D
        Decimal.TryParse(value.ToString(), result)
        Return result
    End Function

    Private Sub SetOrderMode(isGuest As Boolean)
        _isGuestMode = isGuest
        btnGuest.BackColor = If(isGuest, Color.Teal, Color.White)
        btnGuest.ForeColor = If(isGuest, Color.White, Color.Teal)
        btnWalkIn.BackColor = If(isGuest, Color.White, Color.Teal)
        btnWalkIn.ForeColor = If(isGuest, Color.Teal, Color.White)
        txtRoomNumber.Enabled = isGuest
        If Not isGuest Then txtRoomNumber.Clear()
    End Sub

    Private Sub SetMenuMode(mode As EditMode)
        _menuMode = mode
        Dim editing = (mode <> EditMode.View)
        btnMenuAdd.Enabled = Not editing
        btnMenuEdit.Enabled = Not editing AndAlso _selectedMenuItemId > 0
        btnMenuDelete.Enabled = Not editing AndAlso _selectedMenuItemId > 0
        btnMenuSave.Enabled = editing
        btnMenuCancel.Enabled = editing

        txtItemName.ReadOnly = Not editing
        txtSell.ReadOnly = Not editing
        txtCost.ReadOnly = Not editing
        cboCategory.Enabled = editing
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

    Private Sub SetActiveCategoryButton(activeBtn As Button)
        Dim buttons As Button() = {btnAllCategory, btnAppetizers, btnMainCourse, btnDrinks, btnDessert, btnSides}
        For Each btn In buttons
            If btn Is Nothing Then Continue For
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 2
            btn.FlatAppearance.BorderColor = Color.Teal
            If btn Is activeBtn Then
                btn.BackColor = Color.Teal
                btn.ForeColor = Color.White
            Else
                btn.BackColor = Color.White
                btn.ForeColor = Color.Teal
            End If
        Next
    End Sub

    Private Sub ClearMenuFields()
        txtItemName.Clear()
        txtSell.Clear()
        txtCost.Clear()
        cboCategory.SelectedIndex = -1
        _selectedMenuItemId = -1
    End Sub

    Private Function TryGetStayByRoom(roomNo As String, ByRef stayId As Integer, ByRef bookingId As Integer, ByRef guestName As String) As Boolean
        stayId = 0
        bookingId = 0
        guestName = ""
        Dim sql As String = "SELECT TOP 1 s.[StayID], s.[BookingID], b.[Guest Name] " &
                            "FROM (tblStays s INNER JOIN tblRooms r ON s.[RoomID]=r.[RoomID]) " &
                            "LEFT JOIN tblBookings b ON s.[BookingID]=b.[BookingID] " &
                            "WHERE r.[Room No]=? AND s.[Stay Status] IN ('Checked In','In House');"
        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn)
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = roomNo
            conn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    stayId = Convert.ToInt32(rd("StayID"))
                    bookingId = Convert.ToInt32(rd("BookingID"))
                    guestName = rd("Guest Name").ToString()
                    Return True
                End If
            End Using
        End Using
        Return False
    End Function

    Private Function SaveOrder(totalAmount As Decimal, paidAmount As Decimal, paymentMode As String, stayId As Integer, guestName As String, roomNo As String) As Integer
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using tx = conn.BeginTransaction()
                Try
                    Dim orderId As Integer
                    Using cmd As New OleDbCommand(
                        "INSERT INTO tblOrders ([Order Date Time], [Order Status], [Payment Mode], [StayID], [Total Amount], [Paid Amount], [Created By User ID], [Notes], [Guest Name], [Room No]) " &
                        "VALUES (?,?,?,?,?,?,?,?,?,?);", conn, tx)
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "Pending"
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = paymentMode
                        If stayId > 0 Then
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = stayId
                        Else
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = DBNull.Value
                        End If
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = paidAmount
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = If(AppSession.UserId <> "", AppSession.UserId, AppSession.CurrentUserName)
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = ""
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = guestName
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = roomNo
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmdId As New OleDbCommand("SELECT @@IDENTITY;", conn, tx)
                        orderId = Convert.ToInt32(cmdId.ExecuteScalar())
                    End Using

                    For Each r As DataRow In _currentOrder.Rows
                        Using cmd As New OleDbCommand(
                            "INSERT INTO tblOrderItems ([Order ID], [Item ID], [Qty], [Unit Price], [Line Total]) VALUES (?,?,?,?,?);", conn, tx)
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = orderId
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(r("ItemID"))
                            cmd.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(r("Qty"))
                            cmd.Parameters.Add("?", OleDbType.Currency).Value = SafeDec(r("UnitPrice"))
                            cmd.Parameters.Add("?", OleDbType.Currency).Value = SafeDec(r("LineTotal"))
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    If paymentMode = "Charge to Room" AndAlso stayId > 0 Then
                        Dim totalQty As Double = 0
                        For Each r As DataRow In _currentOrder.Rows
                            totalQty += Convert.ToDouble(r("Qty"))
                        Next
                        Dim unitPrice As Decimal = If(totalQty > 0, totalAmount / CDec(totalQty), totalAmount)
                        Using cmd As New OleDbCommand(
                            "INSERT INTO tblCharges ([StayID], [Charge Date Time], [Charge Category], [Charge Source], [Reference Order ID], [Description], [Qty], [Unit Price], [Amount], [Posted By User ID], [Is Voided], [Created At]) " &
                            "VALUES (?,?,?,?,?,?,?,?,?,?,?,?);", conn, tx)
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = stayId
                            cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "Dining/Bar"
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "POS"
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = orderId.ToString()
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "POS Order"
                            cmd.Parameters.Add("?", OleDbType.Double).Value = totalQty
                            cmd.Parameters.Add("?", OleDbType.Currency).Value = unitPrice
                            cmd.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = If(AppSession.UserId <> "", AppSession.UserId, AppSession.CurrentUserName)
                            cmd.Parameters.Add("?", OleDbType.Boolean).Value = False
                            cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    tx.Commit()
                    Return orderId
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    Private Sub dgvPOS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOS.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvPOS.Rows(e.RowIndex)
        Dim itemId = Convert.ToInt32(row.Cells("ItemID").Value)
        Dim itemName = row.Cells("ItemName").Value.ToString()
        Dim unitPrice = SafeDec(row.Cells("UnitPrice").Value)
        AddItemToOrder(itemId, itemName, unitPrice)
    End Sub

    Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        If dgvMenu.SelectedRows.Count = 0 Then Return
        Dim row = dgvMenu.SelectedRows(0)
        If row.Cells("Item ID").Value Is Nothing OrElse row.Cells("Item ID").Value Is DBNull.Value Then Return

        _selectedMenuItemId = SafeInt(row.Cells("Item ID").Value)
        If _selectedMenuItemId <= 0 Then Return
        If _menuMode <> EditMode.View Then Return

        txtItemName.Text = row.Cells("Item Name").Value.ToString()
        cboCategory.Text = row.Cells("Item Category").Value.ToString()
        txtSell.Text = SafeDec(row.Cells("Unit Price").Value).ToString("0.00")
        txtCost.Text = SafeDec(row.Cells("Cost").Value).ToString("0.00")
        SetMenuMode(EditMode.View)
    End Sub

    Private Sub dgvStocks_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvStocks.CellFormatting
        If dgvStocks.Columns(e.ColumnIndex).Name <> "Item Name" OrElse e.RowIndex < 0 Then Return
        Dim itemIdObj = dgvStocks.Rows(e.RowIndex).Cells("Item ID").Value
        If itemIdObj Is Nothing OrElse itemIdObj Is DBNull.Value Then
            e.Value = ""
            e.FormattingApplied = True
            Return
        End If

        Dim itemId As Integer = 0
        Integer.TryParse(itemIdObj.ToString(), itemId)
        Dim name = GetMenuItemName(itemId)
        e.Value = name
        e.FormattingApplied = True
    End Sub

    Private Function GetMenuItemName(itemId As Integer) As String
        If _menuItems Is Nothing Then Return ""
        Dim row = _menuItems.AsEnumerable().FirstOrDefault(Function(r) SafeInt(r("Item ID")) = itemId)
        If row Is Nothing Then Return ""
        Return row("Item Name").ToString()
    End Function

    Private Function GetMenuItemCategory(itemId As Integer) As String
        If _menuItems Is Nothing Then Return ""
        Dim row = _menuItems.AsEnumerable().FirstOrDefault(Function(r) SafeInt(r("Item ID")) = itemId)
        If row Is Nothing Then Return ""
        Return row("Item Category").ToString()
    End Function

    Private Function SafeInt(value As Object) As Integer
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0
        Dim result As Integer = 0
        Integer.TryParse(value.ToString(), result)
        Return result
    End Function

    Private Sub dgvCurrentOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCurrentOrder.KeyDown
        If e.KeyCode <> Keys.Delete Then Return
        For Each r As DataGridViewRow In dgvCurrentOrder.SelectedRows
            If Not r.IsNewRow Then dgvCurrentOrder.Rows.Remove(r)
        Next
        UpdateOrderTotal()
    End Sub

    Private Sub dgvOrders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOrders.SelectionChanged
        If dgvOrders.SelectedRows.Count = 0 Then Return
        Dim row = dgvOrders.SelectedRows(0)
        If row.Cells("OrderID").Value Is Nothing Then Return
        Dim orderId = Convert.ToInt32(row.Cells("OrderID").Value)
        LoadOrderDetails(orderId)
    End Sub

    Private Sub btnAllCategory_Click(sender As Object, e As EventArgs) Handles btnAllCategory.Click
        _posCategory = ""
        SetActiveCategoryButton(btnAllCategory)
        LoadPosMenu(search:=txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnAppetizers_Click(sender As Object, e As EventArgs) Handles btnAppetizers.Click
        _posCategory = "Appetizers"
        SetActiveCategoryButton(btnAppetizers)
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnMainCourse_Click(sender As Object, e As EventArgs) Handles btnMainCourse.Click
        _posCategory = "Main Course"
        SetActiveCategoryButton(btnMainCourse)
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnDrinks_Click(sender As Object, e As EventArgs) Handles btnDrinks.Click
        _posCategory = "Drinks"
        SetActiveCategoryButton(btnDrinks)
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnDessert_Click(sender As Object, e As EventArgs) Handles btnDessert.Click
        _posCategory = "Desserts"
        SetActiveCategoryButton(btnDessert)
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnSides_Click(sender As Object, e As EventArgs) Handles btnSides.Click
        _posCategory = "Sides"
        SetActiveCategoryButton(btnSides)
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub txtSearchPOS_TextChanged(sender As Object, e As EventArgs) Handles txtSearchPOS.TextChanged
        LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
    End Sub

    Private Sub btnPOSClear_Click(sender As Object, e As EventArgs) Handles btnPOSClear.Click
        _currentOrder.Clear()
        UpdateOrderTotal()
    End Sub

    Private Sub btnWalkIn_Click(sender As Object, e As EventArgs) Handles btnWalkIn.Click
        SetOrderMode(isGuest:=False)
    End Sub

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click
        SetOrderMode(isGuest:=True)
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        If _currentOrder.Rows.Count = 0 Then
            MessageBox.Show("Add at least one item before payment.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim totalAmount As Decimal = 0D
        For Each r As DataRow In _currentOrder.Rows
            totalAmount += SafeDec(r("LineTotal"))
        Next

        Dim stayId As Integer = 0
        Dim bookingId As Integer = 0
        Dim guestName As String = txtGuestName.Text.Trim()
        Dim roomNo As String = txtRoomNumber.Text.Trim()
        If _isGuestMode Then
            If roomNo = "" Then
                MessageBox.Show("Enter a room number for guest charges.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim stayFound = TryGetStayByRoom(roomNo, stayId, bookingId, guestName)
            If Not stayFound Then
                Dim res = MessageBox.Show("No active stay found for this room. Continue as walk-in?", "POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.No Then Return
                stayId = 0
                bookingId = 0
            End If
        End If

        Using dlg As New CashierForm(totalAmount)
            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Dim paymentMode = "Cash"
            Dim paidAmount = dlg.AmountPaid

            Try
                Dim orderId = SaveOrder(totalAmount, paidAmount, paymentMode, stayId, guestName, roomNo)
                MessageBox.Show("Order saved. Order ID: " & orderId.ToString(), "POS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _currentOrder.Clear()
                UpdateOrderTotal()
                LoadOrders()
            Catch ex As Exception
                MessageBox.Show("Failed to save order: " & ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub txtOrderSearch_TextChanged(sender As Object, e As EventArgs) Handles txtOrderSearch.TextChanged
        If _orders Is Nothing Then Return
        Dim view = _orders.DefaultView
        Dim q = txtOrderSearch.Text.Trim().Replace("'", "''")
        If q = "" Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"Convert([OrderID], 'System.String') LIKE '%{q}%' OR [Guest Name] LIKE '%{q}%' OR [Room No] LIKE '%{q}%'"
        End If
    End Sub

    Private Sub btnOrderClear_Click(sender As Object, e As EventArgs) Handles btnOrderClear.Click
        txtOrderSearch.Clear()
    End Sub

    Private Sub txtMenuSearch_TextChanged(sender As Object, e As EventArgs) Handles txtMenuSearch.TextChanged
        If _menuItems Is Nothing Then Return
        Dim view = _menuItems.DefaultView
        Dim q = txtMenuSearch.Text.Trim().Replace("'", "''")
        view.RowFilter = If(q = "", "", $"[Item Name] LIKE '%{q}%' OR [Item Category] LIKE '%{q}%'")
    End Sub

    Private Sub btnMenuClear_Click(sender As Object, e As EventArgs) Handles btnMenuClear.Click
        txtMenuSearch.Clear()
        LoadMenuItems()
    End Sub

    Private Sub txtStocksSearch_TextChanged(sender As Object, e As EventArgs) Handles txtStocksSearch.TextChanged
        If _stocks Is Nothing Then Return
        Dim view = _stocks.DefaultView
        Dim q = txtStocksSearch.Text.Trim().Replace("'", "''")
        view.RowFilter = If(q = "", "", $"[Item Name] LIKE '%{q}%' OR [Item Category] LIKE '%{q}%' OR [Status] LIKE '%{q}%' OR Convert([Item ID], 'System.String') LIKE '%{q}%'")
    End Sub

    Private Sub btnStocksClear_Click(sender As Object, e As EventArgs) Handles btnStocksClear.Click
        txtStocksSearch.Clear()
        LoadStocks()
    End Sub

    Private Sub btnMenuAdd_Click(sender As Object, e As EventArgs) Handles btnMenuAdd.Click
        ClearMenuFields()
        SetMenuMode(EditMode.Adding)
        txtItemName.Focus()
    End Sub

    Private Sub btnMenuEdit_Click(sender As Object, e As EventArgs) Handles btnMenuEdit.Click
        If _selectedMenuItemId <= 0 Then Return
        SetMenuMode(EditMode.Editing)
        txtItemName.Focus()
    End Sub

    Private Sub btnMenuCancel_Click(sender As Object, e As EventArgs) Handles btnMenuCancel.Click
        SetMenuMode(EditMode.View)
        LoadMenuItems()
    End Sub

    Private Sub btnMenuSave_Click(sender As Object, e As EventArgs) Handles btnMenuSave.Click
        Dim itemName = txtItemName.Text.Trim()
        Dim category = cboCategory.Text.Trim()
        Dim sellPrice = SafeDec(txtSell.Text)
        Dim cost = SafeDec(txtCost.Text)

        If itemName = "" OrElse category = "" OrElse sellPrice <= 0D Then
            MessageBox.Show("Please fill item name, category, and selling price.", "Menu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                If _menuMode = EditMode.Adding Then
                    Using cmd As New OleDbCommand(
                        "INSERT INTO tblMenuItems ([Item Name], [Item Category], [Unit Price], [Cost], [Is Active], [Created At]) VALUES (?,?,?,?,?,?);", conn)
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = itemName
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = category
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = sellPrice
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = cost
                        cmd.Parameters.Add("?", OleDbType.Boolean).Value = True
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmd.ExecuteNonQuery()
                    End Using
                ElseIf _menuMode = EditMode.Editing AndAlso _selectedMenuItemId > 0 Then
                    Using cmd As New OleDbCommand(
                        "UPDATE tblMenuItems SET [Item Name]=?, [Item Category]=?, [Unit Price]=?, [Cost]=? WHERE [Item ID]=?;", conn)
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = itemName
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = category
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = sellPrice
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = cost
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = _selectedMenuItemId
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to save menu item: " & ex.Message, "Menu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        SetMenuMode(EditMode.View)
        LoadMenuItems()
    End Sub

    Private Sub btnMenuDelete_Click(sender As Object, e As EventArgs) Handles btnMenuDelete.Click
        If _selectedMenuItemId <= 0 Then Return
        Dim res = MessageBox.Show("Delete this menu item?", "Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res <> DialogResult.Yes Then Return

        Try
            Using conn As New OleDbConnection(ConnStr),
                  cmd As New OleDbCommand("DELETE FROM tblMenuItems WHERE [Item ID]=?;", conn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = _selectedMenuItemId
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete menu item: " & ex.Message, "Menu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        SetMenuMode(EditMode.View)
        LoadMenuItems()
    End Sub

    Private Sub btnStocksAdd_Click(sender As Object, e As EventArgs) Handles btnStocksAdd.Click
        Dim result = MessageBox.Show(
            "Yes: create a new amenity/item first." & Environment.NewLine &
            "No: add stock for an existing item." & Environment.NewLine &
            "Cancel: abort.",
            "Add Stock",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question)

        If result = DialogResult.Cancel Then Return
        If result = DialogResult.Yes Then
            AddNewAmenityStock()
            Return
        End If

        AddBlankStockRow()
    End Sub

    Private Sub btnStocksEdit_Click(sender As Object, e As EventArgs) Handles btnStocksEdit.Click
        If dgvStocks.SelectedRows.Count = 0 Then Return
        dgvStocks.ReadOnly = False
        dgvStocks.BeginEdit(True)
    End Sub

    Private Sub btnStocksSave_Click(sender As Object, e As EventArgs) Handles btnStocksSave.Click
        Try
            dgvStocks.EndEdit()
            SaveStocks()
            LoadStocks()
        Catch ex As Exception
            MessageBox.Show("Failed to save stocks: " & ex.Message, "Stocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStocksDel_Click(sender As Object, e As EventArgs) Handles btnStocksDel.Click
        If dgvStocks.SelectedRows.Count = 0 Then Return
        Dim res = MessageBox.Show("Delete this stock record?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res <> DialogResult.Yes Then Return
        For Each r As DataGridViewRow In dgvStocks.SelectedRows
            If Not r.IsNewRow Then dgvStocks.Rows.Remove(r)
        Next
        Try
            SaveStocks()
            LoadStocks()
        Catch ex As Exception
            MessageBox.Show("Failed to delete stocks: " & ex.Message, "Stocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddBlankStockRow(Optional itemId As Integer = 0, Optional qty As Decimal = 0D, Optional unitText As String = "", Optional reorderLevel As Decimal = 0D)
        If _stocks Is Nothing Then Return

        Dim row = _stocks.NewRow()
        If itemId > 0 Then
            row("Item ID") = itemId
            row("Item Name") = GetMenuItemName(itemId)
            row("Item Category") = GetMenuItemCategory(itemId)
        Else
            row("Item Name") = ""
            row("Item Category") = ""
        End If
        row("Qty") = qty
        row("Unit") = unitText
        row("Reorder Level") = reorderLevel
        row("Status") = ComputeStockStatus(qty, reorderLevel)
        row("Updated") = Date.Now
        _stocks.Rows.Add(row)

        Dim targetIndex = dgvStocks.Rows.Count - 1
        If targetIndex >= 0 Then
            dgvStocks.ClearSelection()
            dgvStocks.Rows(targetIndex).Selected = True
            dgvStocks.CurrentCell = dgvStocks.Rows(targetIndex).Cells("Item Picker")
            dgvStocks.BeginEdit(True)
        End If
    End Sub

    Private Sub AddNewAmenityStock()
        Dim itemName = InputBox("Enter the new item/amenity name.", "New Item")
        itemName = itemName.Trim()
        If itemName = "" Then Return

        Dim category = InputBox("Enter the category for this stock item.", "Category", AmenityCategory).Trim()
        If category = "" Then category = AmenityCategory

        Dim sellPrice = PromptDecimal("Enter the selling price.", "Selling Price")
        If sellPrice Is Nothing Then Return

        Dim baseCost = PromptDecimal("Enter the base cost.", "Base Cost", allowBlank:=True)
        If baseCost Is Nothing Then Return

        Dim initialQty = PromptDecimal("Enter the initial stock quantity.", "Initial Quantity", allowBlank:=True)
        If initialQty Is Nothing Then Return

        Dim unitText = InputBox("Enter the stock unit (pcs, bottle, pack, etc.).", "Unit", "pcs").Trim()
        Dim reorderLevel = PromptDecimal("Enter the reorder level.", "Reorder Level", allowBlank:=True)
        If reorderLevel Is Nothing Then Return

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Dim itemId As Integer
                    Using cmd As New OleDbCommand(
                        "INSERT INTO tblMenuItems ([Item Name], [Item Category], [Unit Price], [Cost], [Is Active], [Created At]) VALUES (?,?,?,?,?,?);",
                        conn, tx)
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = itemName
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = category
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = sellPrice.Value
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = baseCost.Value
                        cmd.Parameters.Add("?", OleDbType.Boolean).Value = True
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmdId As New OleDbCommand("SELECT @@IDENTITY;", conn, tx)
                        itemId = Convert.ToInt32(cmdId.ExecuteScalar())
                    End Using

                    Using cmdStock As New OleDbCommand(
                        "INSERT INTO tblStocks ([Item ID], [Qty], [Unit], [Reorder Level], [Status], [Updated]) VALUES (?,?,?,?,?,?);",
                        conn, tx)
                        cmdStock.Parameters.Add("?", OleDbType.Integer).Value = itemId
                        cmdStock.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(initialQty.Value)
                        cmdStock.Parameters.Add("?", OleDbType.VarWChar).Value = unitText
                        cmdStock.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(reorderLevel.Value)
                        cmdStock.Parameters.Add("?", OleDbType.VarWChar).Value = ComputeStockStatus(initialQty.Value, reorderLevel.Value)
                        cmdStock.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmdStock.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using

            LoadMenuItems()
            LoadPosMenu(_posCategory, txtSearchPOS.Text.Trim())
            LoadStocks()
        Catch ex As Exception
            MessageBox.Show("Failed to add item and stock: " & ex.Message, "Stocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function PromptDecimal(prompt As String, title As String, Optional allowBlank As Boolean = False) As Decimal?
        Dim raw = InputBox(prompt, title, If(allowBlank, "0", ""))
        raw = raw.Trim()
        If raw = "" Then
            If allowBlank Then Return 0D
            Return Nothing
        End If

        Dim value As Decimal = 0D
        If Not Decimal.TryParse(raw, value) OrElse value < 0D Then
            MessageBox.Show("Enter a valid non-negative number.", title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End If

        Return value
    End Function

    Private Function ComputeStockStatus(qty As Decimal, reorderLevel As Decimal) As String
        If qty <= 0D Then Return "Out of Stock"
        If reorderLevel > 0D AndAlso qty <= reorderLevel Then Return "Low Stock"
        Return "Available"
    End Function

    Private Sub NormalizeStockRow(row As DataRow)
        If row Is Nothing OrElse row.RowState = DataRowState.Deleted Then Return

        Dim itemId = SafeInt(row("Item ID"))
        row("Item Name") = GetMenuItemName(itemId)
        row("Item Category") = GetMenuItemCategory(itemId)

        Dim qty = SafeDec(row("Qty"))
        Dim reorderLevel = SafeDec(row("Reorder Level"))
        If qty < 0D Then qty = 0D
        If reorderLevel < 0D Then reorderLevel = 0D
        row("Qty") = qty
        row("Reorder Level") = reorderLevel
        row("Unit") = If(row("Unit") Is DBNull.Value, "", row("Unit").ToString().Trim())
        row("Status") = ComputeStockStatus(qty, reorderLevel)
        row("Updated") = Date.Now
    End Sub

    Private Sub SaveStocks()
        If _stocks Is Nothing Then Return

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using tx = conn.BeginTransaction()
                Try
                    For Each row As DataRow In _stocks.Rows
                        Select Case row.RowState
                            Case DataRowState.Added
                                NormalizeStockRow(row)
                                ValidateStockRow(row)
                                Using cmd As New OleDbCommand(
                                    "INSERT INTO tblStocks ([Item ID], [Qty], [Unit], [Reorder Level], [Status], [Updated]) VALUES (?,?,?,?,?,?);",
                                    conn, tx)
                                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SafeInt(row("Item ID"))
                                    cmd.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(SafeDec(row("Qty")))
                                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = row("Unit").ToString()
                                    cmd.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(SafeDec(row("Reorder Level")))
                                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = row("Status").ToString()
                                    cmd.Parameters.Add("?", OleDbType.Date).Value = CDate(row("Updated"))
                                    cmd.ExecuteNonQuery()
                                End Using
                            Case DataRowState.Modified
                                NormalizeStockRow(row)
                                ValidateStockRow(row)
                                Using cmd As New OleDbCommand(
                                    "UPDATE tblStocks SET [Item ID]=?, [Qty]=?, [Unit]=?, [Reorder Level]=?, [Status]=?, [Updated]=? WHERE [StockID]=?;",
                                    conn, tx)
                                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SafeInt(row("Item ID"))
                                    cmd.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(SafeDec(row("Qty")))
                                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = row("Unit").ToString()
                                    cmd.Parameters.Add("?", OleDbType.Double).Value = Convert.ToDouble(SafeDec(row("Reorder Level")))
                                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = row("Status").ToString()
                                    cmd.Parameters.Add("?", OleDbType.Date).Value = CDate(row("Updated"))
                                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SafeInt(row("StockID"))
                                    cmd.ExecuteNonQuery()
                                End Using
                            Case DataRowState.Deleted
                                Using cmd As New OleDbCommand("DELETE FROM tblStocks WHERE [StockID]=?;", conn, tx)
                                    cmd.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(row("StockID", DataRowVersion.Original))
                                    cmd.ExecuteNonQuery()
                                End Using
                        End Select
                    Next

                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Sub ValidateStockRow(row As DataRow)
        Dim itemId = SafeInt(row("Item ID"))
        If itemId <= 0 Then Throw New InvalidOperationException("Each stock row must have an item selected.")
    End Sub

    Private Sub dgvStocks_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStocks.CellValueChanged
        If e.RowIndex < 0 OrElse _stocks Is Nothing OrElse e.RowIndex >= _stocks.Rows.Count Then Return
        Dim row = _stocks.Rows(e.RowIndex)
        If row.RowState = DataRowState.Deleted Then Return

        Dim columnName = dgvStocks.Columns(e.ColumnIndex).Name
        If columnName = "Item Picker" OrElse columnName = "Qty" OrElse columnName = "Reorder Level" OrElse columnName = "Unit" Then
            NormalizeStockRow(row)
        End If
    End Sub

    Private Sub dgvStocks_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvStocks.DataError
        e.ThrowException = False
        MessageBox.Show("Invalid stock value. Check the edited cell and try again.", "Stocks", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnServed_Click(sender As Object, e As EventArgs) Handles btnServed.Click
        UpdateOrderStatus("Served")
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        UpdateOrderStatus("Cancelled")
    End Sub

    Private Sub UpdateOrderStatus(newStatus As String)
        If dgvOrders.SelectedRows.Count = 0 Then Return
        Dim row = dgvOrders.SelectedRows(0)
        If row.Cells("OrderID").Value Is Nothing Then Return
        Dim orderId = Convert.ToInt32(row.Cells("OrderID").Value)
        Try
            Using conn As New OleDbConnection(ConnStr),
                  cmd As New OleDbCommand("UPDATE tblOrders SET [Order Status]=? WHERE [OrderID]=?;", conn)
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = newStatus
                cmd.Parameters.Add("?", OleDbType.Integer).Value = orderId
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            LoadOrders()
        Catch ex As Exception
            MessageBox.Show("Failed to update order: " & ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOrderReciept_Click(sender As Object, e As EventArgs) Handles btnOrderReciept.Click
        MessageBox.Show("Receipt printing is not configured yet.", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tbPOS_Click(sender As Object, e As EventArgs) Handles tbPOS.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

End Class
