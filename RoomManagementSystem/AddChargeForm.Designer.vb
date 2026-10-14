<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddChargeForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.txtRoomNo = New System.Windows.Forms.TextBox()
        Me.lblChargeType = New System.Windows.Forms.Label()
        Me.cboChargeType = New System.Windows.Forms.ComboBox()
        Me.pnlStocks = New System.Windows.Forms.Panel()
        Me.dgvStocks = New System.Windows.Forms.DataGridView()
        Me.colStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvailableQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblStockList = New System.Windows.Forms.Label()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.nudQty = New System.Windows.Forms.NumericUpDown()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.pnlStocks.SuspendLayout()
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGuestName
        '
        Me.lblGuestName.AutoSize = True
        Me.lblGuestName.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuestName.Location = New System.Drawing.Point(18, 18)
        Me.lblGuestName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.Size = New System.Drawing.Size(128, 26)
        Me.lblGuestName.TabIndex = 0
        Me.lblGuestName.Text = "Guest Name"
        '
        'lblRoomNo
        '
        Me.lblRoomNo.AutoSize = True
        Me.lblRoomNo.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNo.Location = New System.Drawing.Point(462, 18)
        Me.lblRoomNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(101, 26)
        Me.lblRoomNo.TabIndex = 2
        Me.lblRoomNo.Text = "Room No"
        '
        'txtRoomNo
        '
        Me.txtRoomNo.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomNo.Location = New System.Drawing.Point(466, 51)
        Me.txtRoomNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRoomNo.Name = "txtRoomNo"
        Me.txtRoomNo.ReadOnly = True
        Me.txtRoomNo.Size = New System.Drawing.Size(136, 33)
        Me.txtRoomNo.TabIndex = 3
        '
        'lblChargeType
        '
        Me.lblChargeType.AutoSize = True
        Me.lblChargeType.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChargeType.Location = New System.Drawing.Point(18, 92)
        Me.lblChargeType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChargeType.Name = "lblChargeType"
        Me.lblChargeType.Size = New System.Drawing.Size(130, 26)
        Me.lblChargeType.TabIndex = 6
        Me.lblChargeType.Text = "Charge Type"
        '
        'cboChargeType
        '
        Me.cboChargeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChargeType.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboChargeType.FormattingEnabled = True
        Me.cboChargeType.Location = New System.Drawing.Point(22, 123)
        Me.cboChargeType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboChargeType.Name = "cboChargeType"
        Me.cboChargeType.Size = New System.Drawing.Size(580, 34)
        Me.cboChargeType.TabIndex = 7
        '
        'pnlStocks
        '
        Me.pnlStocks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStocks.Controls.Add(Me.dgvStocks)
        Me.pnlStocks.Controls.Add(Me.lblStockList)
        Me.pnlStocks.Location = New System.Drawing.Point(22, 170)
        Me.pnlStocks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlStocks.Name = "pnlStocks"
        Me.pnlStocks.Size = New System.Drawing.Size(580, 240)
        Me.pnlStocks.TabIndex = 8
        '
        'dgvStocks
        '
        Me.dgvStocks.AllowUserToAddRows = False
        Me.dgvStocks.AllowUserToDeleteRows = False
        Me.dgvStocks.BackgroundColor = System.Drawing.Color.White
        Me.dgvStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStocks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStockId, Me.colItemId, Me.colItemName, Me.colCategory, Me.colAvailableQty, Me.colUnitPrice})
        Me.dgvStocks.Location = New System.Drawing.Point(12, 38)
        Me.dgvStocks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvStocks.MultiSelect = False
        Me.dgvStocks.Name = "dgvStocks"
        Me.dgvStocks.ReadOnly = True
        Me.dgvStocks.RowHeadersVisible = False
        Me.dgvStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStocks.Size = New System.Drawing.Size(554, 186)
        Me.dgvStocks.TabIndex = 1
        '
        'colStockId
        '
        Me.colStockId.DataPropertyName = "StockID"
        Me.colStockId.HeaderText = "StockID"
        Me.colStockId.Name = "colStockId"
        Me.colStockId.ReadOnly = True
        Me.colStockId.Visible = False
        '
        'colItemId
        '
        Me.colItemId.DataPropertyName = "Item ID"
        Me.colItemId.HeaderText = "Item ID"
        Me.colItemId.Name = "colItemId"
        Me.colItemId.ReadOnly = True
        Me.colItemId.Visible = False
        '
        'colItemName
        '
        Me.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemName.DataPropertyName = "Item Name"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "Item Category"
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 120
        '
        'colAvailableQty
        '
        Me.colAvailableQty.DataPropertyName = "Available Qty"
        Me.colAvailableQty.HeaderText = "Available Qty"
        Me.colAvailableQty.Name = "colAvailableQty"
        Me.colAvailableQty.ReadOnly = True
        Me.colAvailableQty.Width = 110
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "Unit Price"
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 110
        '
        'lblStockList
        '
        Me.lblStockList.AutoSize = True
        Me.lblStockList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockList.Location = New System.Drawing.Point(9, 9)
        Me.lblStockList.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockList.Name = "lblStockList"
        Me.lblStockList.Size = New System.Drawing.Size(132, 18)
        Me.lblStockList.TabIndex = 0
        Me.lblStockList.Text = "Available Stocks"
        '
        'txtGuestName
        '
        Me.txtGuestName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGuestName.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestName.Location = New System.Drawing.Point(22, 51)
        Me.txtGuestName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.ReadOnly = True
        Me.txtGuestName.Size = New System.Drawing.Size(426, 33)
        Me.txtGuestName.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(320, 585)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(282, 52)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(22, 585)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(282, 52)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save Charge"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(414, 458)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(188, 33)
        Me.txtAmount.TabIndex = 26
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAmount
        '
        Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(410, 430)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(88, 26)
        Me.lblAmount.TabIndex = 25
        Me.lblAmount.Text = "Amount"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUnitPrice.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitPrice.Location = New System.Drawing.Point(218, 458)
        Me.txtUnitPrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.ReadOnly = True
        Me.txtUnitPrice.Size = New System.Drawing.Size(172, 33)
        Me.txtUnitPrice.TabIndex = 24
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblUnitPrice.AutoSize = True
        Me.lblUnitPrice.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitPrice.Location = New System.Drawing.Point(214, 430)
        Me.lblUnitPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(105, 26)
        Me.lblUnitPrice.TabIndex = 23
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'nudQty
        '
        Me.nudQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudQty.Location = New System.Drawing.Point(22, 458)
        Me.nudQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudQty.Name = "nudQty"
        Me.nudQty.Size = New System.Drawing.Size(172, 30)
        Me.nudQty.TabIndex = 22
        Me.nudQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblQty
        '
        Me.lblQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.Location = New System.Drawing.Point(18, 430)
        Me.lblQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(95, 26)
        Me.lblQty.TabIndex = 21
        Me.lblQty.Text = "Quantity"
        '
        'txtItemName
        '
        Me.txtItemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(22, 458)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(426, 33)
        Me.txtItemName.TabIndex = 20
        Me.txtItemName.Visible = False
        '
        'lblItemName
        '
        Me.lblItemName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.Location = New System.Drawing.Point(18, 430)
        Me.lblItemName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(170, 26)
        Me.lblItemName.TabIndex = 19
        Me.lblItemName.Text = "Item Description"
        Me.lblItemName.Visible = False
        '
        'AddChargeForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(620, 595)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.nudQty)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.pnlStocks)
        Me.Controls.Add(Me.cboChargeType)
        Me.Controls.Add(Me.lblChargeType)
        Me.Controls.Add(Me.txtRoomNo)
        Me.Controls.Add(Me.lblRoomNo)
        Me.Controls.Add(Me.txtGuestName)
        Me.Controls.Add(Me.lblGuestName)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddChargeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Charge"
        Me.pnlStocks.ResumeLayout(False)
        Me.pnlStocks.PerformLayout()
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGuestName As System.Windows.Forms.Label
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents txtRoomNo As System.Windows.Forms.TextBox
    Friend WithEvents lblChargeType As System.Windows.Forms.Label
    Friend WithEvents cboChargeType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStocks As System.Windows.Forms.Panel
    Friend WithEvents dgvStocks As System.Windows.Forms.DataGridView
    Friend WithEvents lblStockList As System.Windows.Forms.Label
    Friend WithEvents colStockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvailableQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtGuestName As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents nudQty As NumericUpDown
    Friend WithEvents lblQty As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents lblItemName As Label
End Class
