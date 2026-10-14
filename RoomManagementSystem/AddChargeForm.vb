Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing

Partial Public Class AddChargeForm
    Private Const ChargeTypeExtraMattress As String = "Extra Mattress"
    Private Const ChargeTypeExtraPax As String = "Extra Pax"
    Private Const ChargeTypeAmenities As String = "Amenities"

    Private ReadOnly _stayId As Integer
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()

    Private _roomExtraMattressRate As Decimal
    Private _roomExtraPaxRate As Decimal
    Private _selectedStockId As Integer = -1
    Private _selectedItemName As String = ""
    Private _selectedStockQty As Decimal
    Private _selectedStockUnitPrice As Decimal

    Public Sub New(stayId As Integer)
        InitializeComponent()
        _stayId = stayId
        ConfigureForm()
        LoadStayContext()
        LoadChargeTypes()
        LoadAmenitiesGrid()
    End Sub

    Private Sub ConfigureForm()
        nudQty.Minimum = 1
        nudQty.Maximum = 9999
        nudQty.Value = 1
        txtUnitPrice.Text = "₱0.00"
        txtAmount.Text = "₱0.00"
        lblItemName.Visible = False
        txtItemName.Visible = False
        dgvStocks.AutoGenerateColumns = False
        dgvStocks.AllowUserToAddRows = False
        dgvStocks.AllowUserToDeleteRows = False
        dgvStocks.MultiSelect = False
        dgvStocks.ReadOnly = True
        dgvStocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStocks.Columns("colAvailableQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStocks.Columns("colUnitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvStocks.Columns("colUnitPrice").DefaultCellStyle.Format = "₱#,##0.00"
    End Sub

    Private Sub LoadStayContext()
        If _stayId <= 0 Then Return

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "SELECT b.[Guest Name], r.[Room No], r.[Extra Pax Rate], r.[Extra Mattress Rate] " &
                    "FROM (tblStays AS s " &
                    "INNER JOIN tblBookings AS b ON s.BookingID=b.BookingID) " &
                    "INNER JOIN tblRooms AS r ON s.RoomID=r.RoomID " &
                    "WHERE s.StayID=?;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = _stayId

                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            txtGuestName.Text = SafeText(rd("Guest Name"))
                            txtRoomNo.Text = SafeText(rd("Room No"))
                            _roomExtraPaxRate = SafeDec(rd("Extra Pax Rate"))
                            _roomExtraMattressRate = SafeDec(rd("Extra Mattress Rate"))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load stay details. " & ex.Message, "Add Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadChargeTypes()
        cboChargeType.Items.Clear()
        cboChargeType.Items.AddRange(New Object() {
            ChargeTypeExtraMattress,
            ChargeTypeExtraPax,
            ChargeTypeAmenities
        })

        If cboChargeType.Items.Count > 0 Then
            cboChargeType.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadAmenitiesGrid()
        Dim dt As New DataTable()

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(
                    "SELECT s.[StockID], s.[Item ID], m.[Item Name], m.[Item Category], s.[Qty] AS [Available Qty], m.[Unit Price] " &
                    "FROM tblStocks AS s " &
                    "INNER JOIN tblMenuItems AS m ON s.[Item ID]=m.[Item ID] " &
                    "WHERE s.[Qty] > 0 AND m.[Item Category]='Amenities' " &
                    "ORDER BY m.[Item Name];", conn)
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load amenity stocks. " & ex.Message, "Add Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        dgvStocks.DataSource = dt
    End Sub

    Private Sub cboChargeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeType.SelectedIndexChanged
        ApplyChargeTypeLayout()
    End Sub

    Private Sub ApplyChargeTypeLayout()
        Dim chargeType As String = SelectedChargeType()
        Dim isAmenities As Boolean = chargeType = ChargeTypeAmenities

        pnlStocks.Visible = isAmenities
        UpdateLayoutForMode(isAmenities)

        If isAmenities Then
            txtItemName.ReadOnly = True
            txtItemName.Text = ""
            txtUnitPrice.Text = "₱0.00"
            _selectedStockId = -1
            _selectedItemName = ""
            _selectedStockQty = 0D
            _selectedStockUnitPrice = 0D

            If dgvStocks.Rows.Count > 0 Then
                dgvStocks.ClearSelection()
                dgvStocks.Rows(0).Selected = True
                UpdateSelectedStock()
            Else
                UpdateAmount()
            End If
        Else
            txtItemName.Text = chargeType
            txtUnitPrice.Text = FormatCurrencyValue(UnitPriceForChargeType(chargeType))
            UpdateAmount()
        End If
    End Sub

    Private Sub UpdateLayoutForMode(isAmenities As Boolean)
        If isAmenities Then
            pnlStocks.Top = 170
            pnlStocks.Height = 240

            lblQty.Top = 430
            nudQty.Top = 458
            lblUnitPrice.Top = 430
            txtUnitPrice.Top = 458
            lblAmount.Top = 430
            txtAmount.Top = 458
            btnSave.Top = 525
            btnCancel.Top = 525
            Me.ClientSize = New Size(620, 595)
        Else
            lblQty.Top = 170
            nudQty.Top = 198
            lblUnitPrice.Top = 170
            txtUnitPrice.Top = 198
            lblAmount.Top = 170
            txtAmount.Top = 198
            btnSave.Top = 265
            btnCancel.Top = 265
            Me.ClientSize = New Size(620, 335)
        End If

        lblQty.Left = 18
        nudQty.Left = 22
        nudQty.Width = 172
        lblUnitPrice.Left = 214
        txtUnitPrice.Left = 218
        txtUnitPrice.Width = 172
        lblAmount.Left = 410
        txtAmount.Left = 414
        txtAmount.Width = 188
    End Sub

    Private Function SelectedChargeType() As String
        Return If(cboChargeType.SelectedItem Is Nothing, "", cboChargeType.SelectedItem.ToString().Trim())
    End Function

    Private Function UnitPriceForChargeType(chargeType As String) As Decimal
        Select Case chargeType
            Case ChargeTypeExtraMattress
                Return _roomExtraMattressRate
            Case ChargeTypeExtraPax
                Return _roomExtraPaxRate
            Case ChargeTypeAmenities
                Return _selectedStockUnitPrice
            Case Else
                Return 0D
        End Select
    End Function

    Private Sub dgvStocks_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStocks.SelectionChanged
        If Not pnlStocks.Visible Then Return
        UpdateSelectedStock()
    End Sub

    Private Sub UpdateSelectedStock()
        If dgvStocks.CurrentRow Is Nothing Then
            _selectedStockId = -1
            _selectedItemName = ""
            _selectedStockQty = 0D
            _selectedStockUnitPrice = 0D
            txtItemName.Text = ""
            txtUnitPrice.Text = "₱0.00"
            UpdateAmount()
            Return
        End If

        _selectedStockId = SafeInt(dgvStocks.CurrentRow.Cells("colStockId").Value)
        _selectedItemName = SafeText(dgvStocks.CurrentRow.Cells("colItemName").Value)
        _selectedStockQty = SafeDec(dgvStocks.CurrentRow.Cells("colAvailableQty").Value)
        _selectedStockUnitPrice = SafeDec(dgvStocks.CurrentRow.Cells("colUnitPrice").Value)

        txtItemName.Text = _selectedItemName
        txtUnitPrice.Text = FormatCurrencyValue(_selectedStockUnitPrice)
        UpdateAmount()
    End Sub

    Private Sub nudQty_ValueChanged(sender As Object, e As EventArgs) Handles nudQty.ValueChanged
        UpdateAmount()
    End Sub

    Private Sub UpdateAmount()
        Dim amount As Decimal = Math.Round(CDec(nudQty.Value) * UnitPriceForChargeType(SelectedChargeType()), 2, MidpointRounding.AwayFromZero)
        txtAmount.Text = FormatCurrencyValue(amount)
    End Sub

    Private Function FormatCurrencyValue(value As Decimal) As String
        Return value.ToString("₱#,##0.00")
    End Function

    Private Function SafeText(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return ""
        Return Convert.ToString(value).Trim()
    End Function

    Private Function SafeInt(value As Object) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then Return 0
        Dim result As Integer
        If Integer.TryParse(value.ToString(), result) Then Return result
        Return 0
    End Function

    Private Function SafeDec(value As Object) As Decimal
        If value Is Nothing OrElse IsDBNull(value) Then Return 0D
        Dim result As Decimal
        If Decimal.TryParse(value.ToString(), result) Then Return result
        Return 0D
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _stayId <= 0 Then
            MessageBox.Show("Please select a guest stay first.", "Missing Stay", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim chargeType As String = SelectedChargeType()
        If chargeType = "" Then
            MessageBox.Show("Please select a charge type.", "Missing Charge Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim qty As Decimal = CDec(nudQty.Value)
        If qty <= 0D Then
            MessageBox.Show("Quantity must be at least 1.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nudQty.Focus()
            Return
        End If

        Dim description As String
        Dim category As String
        Dim chargeSource As String
        Dim unitPrice As Decimal = UnitPriceForChargeType(chargeType)
        Dim referenceId As Object = DBNull.Value

        Select Case chargeType
            Case ChargeTypeExtraMattress
                category = ChargeTypeExtraMattress
                description = ChargeTypeExtraMattress
                chargeSource = "System"
            Case ChargeTypeExtraPax
                category = ChargeTypeExtraPax
                description = ChargeTypeExtraPax
                chargeSource = "System"
            Case ChargeTypeAmenities
                If _selectedStockId <= 0 OrElse _selectedItemName = "" Then
                    MessageBox.Show("Please select an amenity item from the stock list.", "Missing Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvStocks.Focus()
                    Return
                End If

                If qty > _selectedStockQty Then
                    MessageBox.Show("Selected quantity exceeds available stock.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nudQty.Focus()
                    Return
                End If

                category = ChargeTypeAmenities
                description = _selectedItemName
                chargeSource = "Stock"
                referenceId = "STOCK:" & _selectedStockId.ToString()
            Case Else
                MessageBox.Show("Unsupported charge type.", "Add Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
        End Select

        If unitPrice <= 0D Then
            MessageBox.Show("Unit price is not configured for this charge type.", "Missing Rate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim amount As Decimal = Math.Round(qty * unitPrice, 2, MidpointRounding.AwayFromZero)

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                Using tx = conn.BeginTransaction()
                    If chargeType = ChargeTypeAmenities Then
                        Dim currentStockQty As Decimal

                        Using cmdStock As New OleDbCommand("SELECT [Qty] FROM tblStocks WHERE [StockID]=?;", conn, tx)
                            cmdStock.Parameters.Add("?", OleDbType.Integer).Value = _selectedStockId
                            Dim scalar = cmdStock.ExecuteScalar()
                            currentStockQty = SafeDec(scalar)
                        End Using

                        If qty > currentStockQty Then
                            tx.Rollback()
                            MessageBox.Show("Stock was updated by another user. Please review the available quantity and try again.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadAmenitiesGrid()
                            ApplyChargeTypeLayout()
                            Return
                        End If

                        Using cmdUpdateStock As New OleDbCommand(
                            "UPDATE tblStocks SET [Qty]=?, [Updated]=? WHERE [StockID]=?;", conn, tx)
                            cmdUpdateStock.Parameters.Add("?", OleDbType.Double).Value = currentStockQty - qty
                            cmdUpdateStock.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                            cmdUpdateStock.Parameters.Add("?", OleDbType.Integer).Value = _selectedStockId
                            cmdUpdateStock.ExecuteNonQuery()
                        End Using
                    End If

                    Using cmd As New OleDbCommand(
                        "INSERT INTO tblCharges ([StayID], [Charge Date Time], [Charge Category], [Charge Source], [Reference Order ID], [Description], [Qty], [Unit Price], [Amount], [Posted By User ID], [Is Voided], [Created At]) " &
                        "VALUES (?,?,?,?,?,?,?,?,?,?,?,?);", conn, tx)
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = _stayId
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = category
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = chargeSource
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = referenceId
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = description
                        cmd.Parameters.Add("?", OleDbType.Double).Value = qty
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = unitPrice
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = amount
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = If(AppSession.UserId <> "", AppSession.UserId, AppSession.CurrentUserName)
                        cmd.Parameters.Add("?", OleDbType.Boolean).Value = False
                        cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                        cmd.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to save charge. " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub AddChargeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblAmount_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
