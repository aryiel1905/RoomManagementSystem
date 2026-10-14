<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserForm))
        Me.gbReservationDetails = New System.Windows.Forms.GroupBox()
        Me.cbShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnUploadPhoto = New System.Windows.Forms.Button()
        Me.cboPositionEdit = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboPrivilege = New System.Windows.Forms.ComboBox()
        Me.txtRetypePassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboFilterPrivilege = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.dgvUserForm = New System.Windows.Forms.DataGridView()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.gbReservationDetails.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvUserForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbReservationDetails
        '
        Me.gbReservationDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbReservationDetails.Controls.Add(Me.cbShowPassword)
        Me.gbReservationDetails.Controls.Add(Me.btnUploadPhoto)
        Me.gbReservationDetails.Controls.Add(Me.cboPositionEdit)
        Me.gbReservationDetails.Controls.Add(Me.Label1)
        Me.gbReservationDetails.Controls.Add(Me.btnDelete)
        Me.gbReservationDetails.Controls.Add(Me.btnAdd)
        Me.gbReservationDetails.Controls.Add(Me.btnSave)
        Me.gbReservationDetails.Controls.Add(Me.btnEdit)
        Me.gbReservationDetails.Controls.Add(Me.btnCancel)
        Me.gbReservationDetails.Controls.Add(Me.PictureBox1)
        Me.gbReservationDetails.Controls.Add(Me.cboPrivilege)
        Me.gbReservationDetails.Controls.Add(Me.txtRetypePassword)
        Me.gbReservationDetails.Controls.Add(Me.txtPassword)
        Me.gbReservationDetails.Controls.Add(Me.txtUserID)
        Me.gbReservationDetails.Controls.Add(Me.txtUserName)
        Me.gbReservationDetails.Controls.Add(Me.Label13)
        Me.gbReservationDetails.Controls.Add(Me.Label9)
        Me.gbReservationDetails.Controls.Add(Me.Label14)
        Me.gbReservationDetails.Controls.Add(Me.Label15)
        Me.gbReservationDetails.Controls.Add(Me.Label16)
        Me.gbReservationDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReservationDetails.Location = New System.Drawing.Point(25, 71)
        Me.gbReservationDetails.Name = "gbReservationDetails"
        Me.gbReservationDetails.Size = New System.Drawing.Size(449, 809)
        Me.gbReservationDetails.TabIndex = 2
        Me.gbReservationDetails.TabStop = False
        Me.gbReservationDetails.Text = "USER DETAILS"
        '
        'cbShowPassword
        '
        Me.cbShowPassword.AutoSize = True
        Me.cbShowPassword.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowPassword.Location = New System.Drawing.Point(232, 623)
        Me.cbShowPassword.Name = "cbShowPassword"
        Me.cbShowPassword.Size = New System.Drawing.Size(173, 29)
        Me.cbShowPassword.TabIndex = 7
        Me.cbShowPassword.Text = "Show Password"
        Me.cbShowPassword.UseVisualStyleBackColor = True
        '
        'btnUploadPhoto
        '
        Me.btnUploadPhoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUploadPhoto.BackColor = System.Drawing.Color.Teal
        Me.btnUploadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnUploadPhoto.FlatAppearance.BorderSize = 3
        Me.btnUploadPhoto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadPhoto.ForeColor = System.Drawing.Color.Azure
        Me.btnUploadPhoto.Location = New System.Drawing.Point(132, 156)
        Me.btnUploadPhoto.Name = "btnUploadPhoto"
        Me.btnUploadPhoto.Size = New System.Drawing.Size(190, 70)
        Me.btnUploadPhoto.TabIndex = 78
        Me.btnUploadPhoto.Text = "Upload Photo"
        Me.btnUploadPhoto.UseVisualStyleBackColor = False
        '
        'cboPositionEdit
        '
        Me.cboPositionEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPositionEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPositionEdit.FormattingEnabled = True
        Me.cboPositionEdit.Location = New System.Drawing.Point(232, 432)
        Me.cboPositionEdit.Name = "cboPositionEdit"
        Me.cboPositionEdit.Size = New System.Drawing.Size(189, 36)
        Me.cboPositionEdit.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(21, 438)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 28)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Position"
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
        Me.btnDelete.Location = New System.Drawing.Point(232, 737)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(189, 50)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
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
        Me.btnAdd.Location = New System.Drawing.Point(26, 672)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(123, 50)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
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
        Me.btnSave.Location = New System.Drawing.Point(298, 672)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(123, 50)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
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
        Me.btnEdit.Location = New System.Drawing.Point(162, 672)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(123, 50)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
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
        Me.btnCancel.Location = New System.Drawing.Point(26, 737)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(189, 50)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(89, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(273, 258)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'cboPrivilege
        '
        Me.cboPrivilege.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPrivilege.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrivilege.FormattingEnabled = True
        Me.cboPrivilege.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboPrivilege.Location = New System.Drawing.Point(232, 485)
        Me.cboPrivilege.Name = "cboPrivilege"
        Me.cboPrivilege.Size = New System.Drawing.Size(189, 28)
        Me.cboPrivilege.TabIndex = 4
        '
        'txtRetypePassword
        '
        Me.txtRetypePassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRetypePassword.Location = New System.Drawing.Point(232, 573)
        Me.txtRetypePassword.Name = "txtRetypePassword"
        Me.txtRetypePassword.Size = New System.Drawing.Size(189, 34)
        Me.txtRetypePassword.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(232, 526)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(189, 34)
        Me.txtPassword.TabIndex = 5
        '
        'txtUserID
        '
        Me.txtUserID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserID.Location = New System.Drawing.Point(232, 338)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(189, 34)
        Me.txtUserID.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Location = New System.Drawing.Point(232, 385)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(189, 34)
        Me.txtUserName.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label13.Location = New System.Drawing.Point(21, 579)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(189, 28)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Re-Type Password:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(21, 485)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 28)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Privilege:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(21, 532)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 28)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Password:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Location = New System.Drawing.Point(21, 344)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 28)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "User ID:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label16.Location = New System.Drawing.Point(21, 391)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 28)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "User Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnClearFilter)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.dgvUserForm)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(498, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1403, 809)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.Teal
        Me.btnClearFilter.Location = New System.Drawing.Point(1167, 33)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(215, 87)
        Me.btnClearFilter.TabIndex = 16
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSearch)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox5.Location = New System.Drawing.Point(218, 34)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(350, 87)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Name Search"
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
        Me.txtSearch.Size = New System.Drawing.Size(317, 27)
        Me.txtSearch.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFilterPrivilege)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox2.Location = New System.Drawing.Point(875, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 87)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Privilege"
        '
        'cboFilterPrivilege
        '
        Me.cboFilterPrivilege.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFilterPrivilege.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterPrivilege.FormattingEnabled = True
        Me.cboFilterPrivilege.Items.AddRange(New Object() {"All", "Couple", "Per Pax", "Family", "Company", "Driver"})
        Me.cboFilterPrivilege.Location = New System.Drawing.Point(16, 35)
        Me.cboFilterPrivilege.Name = "cboFilterPrivilege"
        Me.cboFilterPrivilege.Size = New System.Drawing.Size(232, 28)
        Me.cboFilterPrivilege.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboPosition)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox3.Location = New System.Drawing.Point(590, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(262, 87)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Position"
        '
        'cboPosition
        '
        Me.cboPosition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Items.AddRange(New Object() {"All", "AC", "NAC"})
        Me.cboPosition.Location = New System.Drawing.Point(16, 35)
        Me.cboPosition.MinimumSize = New System.Drawing.Size(92, 0)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(227, 28)
        Me.cboPosition.TabIndex = 14
        '
        'dgvUserForm
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvUserForm.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUserForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUserForm.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvUserForm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserForm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUserForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserForm.EnableHeadersVisualStyles = False
        Me.dgvUserForm.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvUserForm.Location = New System.Drawing.Point(22, 151)
        Me.dgvUserForm.MultiSelect = False
        Me.dgvUserForm.Name = "dgvUserForm"
        Me.dgvUserForm.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserForm.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUserForm.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.InfoText
        Me.dgvUserForm.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUserForm.RowTemplate.Height = 28
        Me.dgvUserForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUserForm.Size = New System.Drawing.Size(1360, 636)
        Me.dgvUserForm.TabIndex = 0
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
        Me.MenuStrip1.TabIndex = 67
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lblOperator)
        Me.Panel1.Controls.Add(Me.lblDateTime)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 905)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 65)
        Me.Panel1.TabIndex = 68
        '
        'lblOperator
        '
        Me.lblOperator.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Teal
        Me.lblOperator.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(19, 16)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(238, 32)
        Me.lblOperator.TabIndex = 69
        Me.lblOperator.Text = "OPERATOR: ADMIN"
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.BackColor = System.Drawing.Color.Teal
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(1499, 16)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(402, 32)
        Me.lblDateTime.TabIndex = 70
        Me.lblDateTime.Text = "SUNDAY, FEB 23, 2025 • 10:52 AM"
        '
        'UserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbReservationDetails)
        Me.Name = "UserForm"
        Me.Text = "UserForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbReservationDetails.ResumeLayout(False)
        Me.gbReservationDetails.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvUserForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbReservationDetails As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnMnuAddNew As ToolStripMenuItem
    Friend WithEvents btnMnuSave As ToolStripMenuItem
    Friend WithEvents btnMnuEdit As ToolStripMenuItem
    Friend WithEvents btnMnuDelete As ToolStripMenuItem
    Friend WithEvents btnMnuCancel As ToolStripMenuItem
    Friend WithEvents btnMnuPrint As ToolStripMenuItem
    Friend WithEvents mnuCrystalReport As ToolStripMenuItem
    Friend WithEvents mnuExcel As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents NavigatioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuBOF As ToolStripMenuItem
    Friend WithEvents mnuNext As ToolStripMenuItem
    Friend WithEvents mnuPrevious As ToolStripMenuItem
    Friend WithEvents mnuEOF As ToolStripMenuItem
    Friend WithEvents mnuRefresh As ToolStripMenuItem
    Friend WithEvents txtRetypePassword As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cboPrivilege As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboPositionEdit As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvUserForm As DataGridView
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents cbShowPassword As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboFilterPrivilege As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboPosition As ComboBox
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents lblOperator As Label
    Friend WithEvents lblDateTime As Label
End Class
