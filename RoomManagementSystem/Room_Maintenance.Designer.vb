<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRooms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRooms))
        Me.dgvRooms = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboPrice = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboFilterClass = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFilterType = New System.Windows.Forms.ComboBox()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbRooms = New System.Windows.Forms.GroupBox()
        Me.gbRoomDetails = New System.Windows.Forms.GroupBox()
        Me.txtRoomType = New System.Windows.Forms.TextBox()
        Me.txtRoomClass = New System.Windows.Forms.TextBox()
        Me.nudIncludedPax = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudExtraMattressRate = New System.Windows.Forms.NumericUpDown()
        Me.Lable6 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.nudExtraPaxRate = New System.Windows.Forms.NumericUpDown()
        Me.nudBaseRate = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.txtRoomNo = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuAddNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCrystalReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigatioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBOF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrevious = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEOF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbRooms = New System.Windows.Forms.PictureBox()
        Me.btnPhotoRooms = New System.Windows.Forms.Button()
        CType(Me.dgvRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbRooms.SuspendLayout()
        Me.gbRoomDetails.SuspendLayout()
        CType(Me.nudIncludedPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExtraMattressRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExtraPaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBaseRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRooms
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvRooms.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRooms.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvRooms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRooms.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRooms.EnableHeadersVisualStyles = False
        Me.dgvRooms.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvRooms.Location = New System.Drawing.Point(20, 39)
        Me.dgvRooms.MultiSelect = False
        Me.dgvRooms.Name = "dgvRooms"
        Me.dgvRooms.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRooms.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRooms.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.InfoText
        Me.dgvRooms.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRooms.RowTemplate.Height = 28
        Me.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRooms.Size = New System.Drawing.Size(1292, 656)
        Me.dgvRooms.TabIndex = 0
        '
        'gbFilter
        '
        Me.gbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFilter.Controls.Add(Me.GroupBox5)
        Me.gbFilter.Controls.Add(Me.GroupBox4)
        Me.gbFilter.Controls.Add(Me.GroupBox3)
        Me.gbFilter.Controls.Add(Me.GroupBox2)
        Me.gbFilter.Controls.Add(Me.GroupBox1)
        Me.gbFilter.Controls.Add(Me.btnClearFilter)
        Me.gbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbFilter.Location = New System.Drawing.Point(557, 66)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(1333, 142)
        Me.gbFilter.TabIndex = 2
        Me.gbFilter.TabStop = False
        Me.gbFilter.Text = "SEARCH / FILTER"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSearch)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox5.Location = New System.Drawing.Point(20, 38)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(277, 87)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Room No. Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(16, 35)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(244, 27)
        Me.txtSearch.TabIndex = 9
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboFilterStatus)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox4.Location = New System.Drawing.Point(981, 39)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(205, 87)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status"
        '
        'cboFilterStatus
        '
        Me.cboFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFilterStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterStatus.FormattingEnabled = True
        Me.cboFilterStatus.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboFilterStatus.Location = New System.Drawing.Point(16, 35)
        Me.cboFilterStatus.Name = "cboFilterStatus"
        Me.cboFilterStatus.Size = New System.Drawing.Size(170, 28)
        Me.cboFilterStatus.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboPrice)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox3.Location = New System.Drawing.Point(759, 39)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(205, 87)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Price"
        '
        'cboPrice
        '
        Me.cboPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrice.FormattingEnabled = True
        Me.cboPrice.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboPrice.Location = New System.Drawing.Point(16, 35)
        Me.cboPrice.Name = "cboPrice"
        Me.cboPrice.Size = New System.Drawing.Size(170, 28)
        Me.cboPrice.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFilterClass)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox2.Location = New System.Drawing.Point(537, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(205, 87)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Class"
        '
        'cboFilterClass
        '
        Me.cboFilterClass.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFilterClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterClass.FormattingEnabled = True
        Me.cboFilterClass.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboFilterClass.Location = New System.Drawing.Point(16, 35)
        Me.cboFilterClass.Name = "cboFilterClass"
        Me.cboFilterClass.Size = New System.Drawing.Size(170, 28)
        Me.cboFilterClass.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFilterType)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox1.Location = New System.Drawing.Point(315, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(205, 87)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type"
        '
        'cboFilterType
        '
        Me.cboFilterType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilterType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterType.FormattingEnabled = True
        Me.cboFilterType.Items.AddRange(New Object() {"All", "AC", "NAC"})
        Me.cboFilterType.Location = New System.Drawing.Point(16, 35)
        Me.cboFilterType.MinimumSize = New System.Drawing.Size(92, 0)
        Me.cboFilterType.Name = "cboFilterType"
        Me.cboFilterType.Size = New System.Drawing.Size(170, 28)
        Me.cboFilterType.TabIndex = 10
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.Teal
        Me.btnClearFilter.Location = New System.Drawing.Point(1202, 39)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(110, 86)
        Me.btnClearFilter.TabIndex = 15
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Teal
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnDelete.FlatAppearance.BorderSize = 3
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Azure
        Me.btnDelete.Location = New System.Drawing.Point(395, 21)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(95, 60)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Teal
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnCancel.FlatAppearance.BorderSize = 3
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Azure
        Me.btnCancel.Location = New System.Drawing.Point(300, 21)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 60)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.Teal
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnEdit.FlatAppearance.BorderSize = 3
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Azure
        Me.btnEdit.Location = New System.Drawing.Point(205, 21)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(95, 60)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnSave.FlatAppearance.BorderSize = 3
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Azure
        Me.btnSave.Location = New System.Drawing.Point(110, 21)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 60)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Teal
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnAdd.FlatAppearance.BorderSize = 3
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Azure
        Me.btnAdd.Location = New System.Drawing.Point(15, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 60)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'gbRooms
        '
        Me.gbRooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRooms.Controls.Add(Me.dgvRooms)
        Me.gbRooms.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRooms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRooms.Location = New System.Drawing.Point(557, 214)
        Me.gbRooms.Name = "gbRooms"
        Me.gbRooms.Size = New System.Drawing.Size(1333, 717)
        Me.gbRooms.TabIndex = 3
        Me.gbRooms.TabStop = False
        Me.gbRooms.Text = "ROOMS"
        '
        'gbRoomDetails
        '
        Me.gbRoomDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbRoomDetails.Controls.Add(Me.txtRoomType)
        Me.gbRoomDetails.Controls.Add(Me.txtRoomClass)
        Me.gbRoomDetails.Controls.Add(Me.nudIncludedPax)
        Me.gbRoomDetails.Controls.Add(Me.Label6)
        Me.gbRoomDetails.Controls.Add(Me.nudExtraMattressRate)
        Me.gbRoomDetails.Controls.Add(Me.Lable6)
        Me.gbRoomDetails.Controls.Add(Me.cboStatus)
        Me.gbRoomDetails.Controls.Add(Me.nudExtraPaxRate)
        Me.gbRoomDetails.Controls.Add(Me.nudBaseRate)
        Me.gbRoomDetails.Controls.Add(Me.Label7)
        Me.gbRoomDetails.Controls.Add(Me.Label5)
        Me.gbRoomDetails.Controls.Add(Me.Label3)
        Me.gbRoomDetails.Controls.Add(Me.Label2)
        Me.gbRoomDetails.Controls.Add(Me.Label1)
        Me.gbRoomDetails.Controls.Add(Me.lblRoomNo)
        Me.gbRoomDetails.Controls.Add(Me.txtRoomNo)
        Me.gbRoomDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRoomDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRoomDetails.Location = New System.Drawing.Point(31, 390)
        Me.gbRoomDetails.Name = "gbRoomDetails"
        Me.gbRoomDetails.Size = New System.Drawing.Size(505, 435)
        Me.gbRoomDetails.TabIndex = 0
        Me.gbRoomDetails.TabStop = False
        Me.gbRoomDetails.Text = "ROOM DETAILS"
        '
        'txtRoomType
        '
        Me.txtRoomType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoomType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomType.Location = New System.Drawing.Point(262, 92)
        Me.txtRoomType.Name = "txtRoomType"
        Me.txtRoomType.Size = New System.Drawing.Size(209, 30)
        Me.txtRoomType.TabIndex = 2
        '
        'txtRoomClass
        '
        Me.txtRoomClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoomClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomClass.Location = New System.Drawing.Point(262, 141)
        Me.txtRoomClass.Name = "txtRoomClass"
        Me.txtRoomClass.Size = New System.Drawing.Size(209, 30)
        Me.txtRoomClass.TabIndex = 3
        '
        'nudIncludedPax
        '
        Me.nudIncludedPax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudIncludedPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudIncludedPax.Location = New System.Drawing.Point(262, 194)
        Me.nudIncludedPax.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudIncludedPax.Name = "nudIncludedPax"
        Me.nudIncludedPax.Size = New System.Drawing.Size(209, 30)
        Me.nudIncludedPax.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(34, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 26)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Included Pax:"
        '
        'nudExtraMattressRate
        '
        Me.nudExtraMattressRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudExtraMattressRate.DecimalPlaces = 2
        Me.nudExtraMattressRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudExtraMattressRate.Location = New System.Drawing.Point(262, 331)
        Me.nudExtraMattressRate.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudExtraMattressRate.Name = "nudExtraMattressRate"
        Me.nudExtraMattressRate.Size = New System.Drawing.Size(209, 30)
        Me.nudExtraMattressRate.TabIndex = 7
        Me.nudExtraMattressRate.ThousandsSeparator = True
        '
        'Lable6
        '
        Me.Lable6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lable6.AutoSize = True
        Me.Lable6.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lable6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Lable6.Location = New System.Drawing.Point(34, 332)
        Me.Lable6.Name = "Lable6"
        Me.Lable6.Size = New System.Drawing.Size(204, 26)
        Me.Lable6.TabIndex = 30
        Me.Lable6.Text = "Extra Mattress Rate:"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownHeight = 100
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.IntegralHeight = False
        Me.cboStatus.Items.AddRange(New Object() {"Available", "Maintenance"})
        Me.cboStatus.Location = New System.Drawing.Point(262, 374)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(209, 33)
        Me.cboStatus.TabIndex = 8
        '
        'nudExtraPaxRate
        '
        Me.nudExtraPaxRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudExtraPaxRate.DecimalPlaces = 2
        Me.nudExtraPaxRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudExtraPaxRate.Location = New System.Drawing.Point(262, 286)
        Me.nudExtraPaxRate.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudExtraPaxRate.Name = "nudExtraPaxRate"
        Me.nudExtraPaxRate.Size = New System.Drawing.Size(209, 30)
        Me.nudExtraPaxRate.TabIndex = 6
        Me.nudExtraPaxRate.ThousandsSeparator = True
        '
        'nudBaseRate
        '
        Me.nudBaseRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudBaseRate.DecimalPlaces = 2
        Me.nudBaseRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudBaseRate.Location = New System.Drawing.Point(262, 241)
        Me.nudBaseRate.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudBaseRate.Name = "nudBaseRate"
        Me.nudBaseRate.Size = New System.Drawing.Size(209, 30)
        Me.nudBaseRate.TabIndex = 5
        Me.nudBaseRate.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(32, 377)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 26)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Status:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(34, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 26)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Extra Pax Rate:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(34, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 26)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Base Rate:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(34, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 26)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Room Class:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(34, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Room Type:"
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRoomNo.AutoSize = True
        Me.lblRoomNo.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNo.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblRoomNo.Location = New System.Drawing.Point(34, 46)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(106, 26)
        Me.lblRoomNo.TabIndex = 11
        Me.lblRoomNo.Text = "Room No:"
        '
        'txtRoomNo
        '
        Me.txtRoomNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoomNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomNo.Location = New System.Drawing.Point(262, 45)
        Me.txtRoomNo.Name = "txtRoomNo"
        Me.txtRoomNo.Size = New System.Drawing.Size(209, 30)
        Me.txtRoomNo.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Teal
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.NavigatioToolStripMenuItem, Me.mnuRefresh})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMnuAddNew, Me.btnMnuSave, Me.btnMnuEdit, Me.btnMnuDelete, Me.btnMnuCancel, Me.btnMnuPrint, Me.mnuExit})
        Me.MenuToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.MenuToolStripMenuItem.Image = CType(resources.GetObject("MenuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(80, 34)
        Me.MenuToolStripMenuItem.Text = "File"
        '
        'btnMnuAddNew
        '
        Me.btnMnuAddNew.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuAddNew.Image = CType(resources.GetObject("btnMnuAddNew.Image"), System.Drawing.Image)
        Me.btnMnuAddNew.Name = "btnMnuAddNew"
        Me.btnMnuAddNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.btnMnuAddNew.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuAddNew.Text = "Add/ New"
        '
        'btnMnuSave
        '
        Me.btnMnuSave.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuSave.Image = CType(resources.GetObject("btnMnuSave.Image"), System.Drawing.Image)
        Me.btnMnuSave.Name = "btnMnuSave"
        Me.btnMnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnMnuSave.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuSave.Text = "Save"
        '
        'btnMnuEdit
        '
        Me.btnMnuEdit.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuEdit.Image = CType(resources.GetObject("btnMnuEdit.Image"), System.Drawing.Image)
        Me.btnMnuEdit.Name = "btnMnuEdit"
        Me.btnMnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.btnMnuEdit.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuEdit.Text = "Edit"
        '
        'btnMnuDelete
        '
        Me.btnMnuDelete.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuDelete.Image = CType(resources.GetObject("btnMnuDelete.Image"), System.Drawing.Image)
        Me.btnMnuDelete.Name = "btnMnuDelete"
        Me.btnMnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.btnMnuDelete.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuDelete.Text = "Delete"
        '
        'btnMnuCancel
        '
        Me.btnMnuCancel.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuCancel.Image = CType(resources.GetObject("btnMnuCancel.Image"), System.Drawing.Image)
        Me.btnMnuCancel.Name = "btnMnuCancel"
        Me.btnMnuCancel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.btnMnuCancel.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuCancel.Text = "Cancel"
        '
        'btnMnuPrint
        '
        Me.btnMnuPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCrystalReport, Me.mnuExcel})
        Me.btnMnuPrint.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMnuPrint.Image = CType(resources.GetObject("btnMnuPrint.Image"), System.Drawing.Image)
        Me.btnMnuPrint.Name = "btnMnuPrint"
        Me.btnMnuPrint.Size = New System.Drawing.Size(245, 30)
        Me.btnMnuPrint.Text = "Print"
        '
        'mnuCrystalReport
        '
        Me.mnuCrystalReport.Image = CType(resources.GetObject("mnuCrystalReport.Image"), System.Drawing.Image)
        Me.mnuCrystalReport.Name = "mnuCrystalReport"
        Me.mnuCrystalReport.Size = New System.Drawing.Size(209, 28)
        Me.mnuCrystalReport.Text = "Crystal Report"
        '
        'mnuExcel
        '
        Me.mnuExcel.Image = CType(resources.GetObject("mnuExcel.Image"), System.Drawing.Image)
        Me.mnuExcel.Name = "mnuExcel"
        Me.mnuExcel.Size = New System.Drawing.Size(209, 28)
        Me.mnuExcel.Text = "Excel "
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
        'mnuRefresh
        '
        Me.mnuRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuRefresh.Checked = True
        Me.mnuRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRefresh.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuRefresh.ForeColor = System.Drawing.SystemColors.Control
        Me.mnuRefresh.Image = CType(resources.GetObject("mnuRefresh.Image"), System.Drawing.Image)
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Padding = New System.Windows.Forms.Padding(5, 0, 4, 0)
        Me.mnuRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mnuRefresh.Size = New System.Drawing.Size(33, 34)
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.btnDelete)
        Me.GroupBox6.Controls.Add(Me.btnAdd)
        Me.GroupBox6.Controls.Add(Me.btnSave)
        Me.GroupBox6.Controls.Add(Me.btnEdit)
        Me.GroupBox6.Controls.Add(Me.btnCancel)
        Me.GroupBox6.Location = New System.Drawing.Point(31, 833)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(505, 98)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'pbRooms
        '
        Me.pbRooms.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbRooms.Location = New System.Drawing.Point(31, 66)
        Me.pbRooms.Name = "pbRooms"
        Me.pbRooms.Size = New System.Drawing.Size(503, 295)
        Me.pbRooms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRooms.TabIndex = 8
        Me.pbRooms.TabStop = False
        '
        'btnPhotoRooms
        '
        Me.btnPhotoRooms.BackColor = System.Drawing.Color.Teal
        Me.btnPhotoRooms.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnPhotoRooms.FlatAppearance.BorderSize = 3
        Me.btnPhotoRooms.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPhotoRooms.ForeColor = System.Drawing.Color.Azure
        Me.btnPhotoRooms.Location = New System.Drawing.Point(183, 194)
        Me.btnPhotoRooms.Name = "btnPhotoRooms"
        Me.btnPhotoRooms.Size = New System.Drawing.Size(178, 54)
        Me.btnPhotoRooms.TabIndex = 9
        Me.btnPhotoRooms.Text = "Upload Photo"
        Me.btnPhotoRooms.UseVisualStyleBackColor = False
        '
        'frmRooms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.btnPhotoRooms)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gbRoomDetails)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbRooms)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gbRooms)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1024, 600)
        Me.Name = "frmRooms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Room"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvRooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gbRooms.ResumeLayout(False)
        Me.gbRoomDetails.ResumeLayout(False)
        Me.gbRoomDetails.PerformLayout()
        CType(Me.nudIncludedPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExtraMattressRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExtraPaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBaseRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvRooms As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents gbFilter As GroupBox
    Friend WithEvents cboFilterType As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cboFilterClass As ComboBox
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents gbRoomDetails As GroupBox
    Friend WithEvents txtRoomNo As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnMnuAddNew As ToolStripMenuItem
    Friend WithEvents btnMnuSave As ToolStripMenuItem
    Friend WithEvents btnMnuEdit As ToolStripMenuItem
    Friend WithEvents btnMnuDelete As ToolStripMenuItem
    Friend WithEvents btnMnuCancel As ToolStripMenuItem
    Friend WithEvents btnMnuPrint As ToolStripMenuItem
    Friend WithEvents NavigatioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents gbRooms As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblRoomNo As Label
    Friend WithEvents nudExtraMattressRate As NumericUpDown
    Friend WithEvents Lable6 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents nudExtraPaxRate As NumericUpDown
    Friend WithEvents nudBaseRate As NumericUpDown
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents nudIncludedPax As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents txtRoomType As TextBox
    Friend WithEvents txtRoomClass As TextBox
    Friend WithEvents cboFilterStatus As ComboBox
    Friend WithEvents pbRooms As PictureBox
    Friend WithEvents mnuBOF As ToolStripMenuItem
    Friend WithEvents mnuNext As ToolStripMenuItem
    Friend WithEvents mnuPrevious As ToolStripMenuItem
    Friend WithEvents mnuEOF As ToolStripMenuItem
    Friend WithEvents mnuRefresh As ToolStripMenuItem
    Friend WithEvents cboPrice As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents btnPhotoRooms As Button
    Friend WithEvents mnuCrystalReport As ToolStripMenuItem
    Friend WithEvents mnuExcel As ToolStripMenuItem
End Class
