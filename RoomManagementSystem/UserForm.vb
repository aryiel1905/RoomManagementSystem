Imports System.Data.OleDb
Imports System.IO

Public Class UserForm
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private ReadOnly clockTimer As New Timer()

    Private Enum FormMode
        ViewMode
        Adding
        Editing
    End Enum

    Private CurrentMode As FormMode = FormMode.ViewMode
    Private SelectedUserID As String = ""
    Private LastSelectedUserID As String = ""
    Private IsDirty As Boolean = False
    Private SuppressPhotoRefresh As Boolean = False
    Private PendingPhotoSourcePath As String = ""
    Private ReadOnly Property IsSetupMode As Boolean
        Get
            Return AppSession.UserSetupMode
        End Get
    End Property

    ' Match frmRooms button disabled style
    Private ReadOnly BtnEnabledBack As Color = Color.Teal
    Private ReadOnly BtnEnabledFore As Color = Color.White
    Private ReadOnly BtnDisabledBack As Color = Color.Gray
    Private ReadOnly BtnDisabledFore As Color = Color.White

    Public Sub PrepareForNormalUse()
        AppSession.UserSetupMode = False
        dgvUserForm.Visible = True
        GroupBox1.Enabled = True
        btnMnuPrint.Enabled = True
        PendingPhotoSourcePath = ""
        SuppressPhotoRefresh = False
        IsDirty = False
        LoadUsers()
        If dgvUserForm.Rows.Count > 0 Then
            For Each cell As DataGridViewCell In dgvUserForm.Rows(0).Cells
                If cell.Visible Then
                    dgvUserForm.CurrentCell = cell
                    Exit For
                End If
            Next
            PopulateInputsFromGrid()
        Else
            ClearInputs()
        End If
        SetMode(FormMode.ViewMode)
    End Sub

    Private Sub ReturnToLoginFromSetup()
        AppSession.UserSetupMode = False
        LoginForm.ResetInputs()
        LoginForm.Show()
        LoginForm.txtUserN.Focus()
        Me.Hide()
    End Sub

    Private Sub UserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If AppSession.UserSetupMode Then
            e.Cancel = True
            ReturnToLoginFromSetup()
        End If
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitActionButtonsStyle()
        InitPrivilegeChoices()
        InitPositionChoices()
        InitPasswordMasking()
        MigrateUserPhotoNames()
        LoadFilterCombosFromDB()
        LoadUsers()
        SetMode(FormMode.ViewMode)
        InitHeaderLabels()

        If IsSetupMode Then
            dgvUserForm.Visible = False
            GroupBox1.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnMnuEdit.Enabled = False
            btnMnuDelete.Enabled = False
            btnMnuPrint.Enabled = False
            btnAdd.Enabled = True
            btnAdd.PerformClick()
            RefreshActionButtonsStyle()
            btnMnuPrint.Enabled = False
        End If
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

    Private Sub LoadFilterCombosFromDB()
        cboFilterPrivilege.Items.Clear()
        cboPosition.Items.Clear()

        cboFilterPrivilege.Items.Add("All")
        cboPosition.Items.Add("All")

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand("SELECT DISTINCT [Privilege] FROM tblUsers WHERE [Privilege] Is Not Null ORDER BY [Privilege];", conn),
                  reader = cmd.ExecuteReader()
                While reader.Read()
                    cboFilterPrivilege.Items.Add(reader(0).ToString())
                End While
            End Using

            Using cmd As New OleDbCommand("SELECT DISTINCT [Position] FROM tblUsers WHERE [Position] Is Not Null ORDER BY [Position];", conn),
                  reader = cmd.ExecuteReader()
                While reader.Read()
                    cboPosition.Items.Add(reader(0).ToString())
                End While
            End Using
        End Using

        cboFilterPrivilege.SelectedIndex = 0
        cboPosition.SelectedIndex = 0
    End Sub

    Private Sub InitPrivilegeChoices()
        cboPrivilege.Items.Clear()
        cboPrivilege.DropDownStyle = ComboBoxStyle.DropDownList
        cboPrivilege.Items.AddRange(New Object() {"Admin", "User"})
        cboPrivilege.SelectedIndex = -1
    End Sub

    Private Sub InitPositionChoices()
        If cboPositionEdit Is Nothing Then Return
        cboPositionEdit.Items.Clear()

        Dim defaults = New String() {"Owner", "Manager"}
        For Each p In defaults
            cboPositionEdit.Items.Add(p)
        Next

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT DISTINCT [Position] FROM tblUsers WHERE [Position] Is Not Null ORDER BY [Position];", conn),
                      reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim p = reader(0).ToString().Trim()
                        If p <> "" AndAlso Not cboPositionEdit.Items.Contains(p) Then
                            cboPositionEdit.Items.Add(p)
                        End If
                    End While
                End Using
            End Using
        Catch
            ' ignore load errors
        End Try

        cboPositionEdit.SelectedIndex = -1
    End Sub

    Private Sub InitPasswordMasking()
        txtPassword.PasswordChar = "●"c
        txtRetypePassword.PasswordChar = "●"c
    End Sub

    Private Sub cbShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowPassword.CheckedChanged
        If cbShowPassword.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
            txtRetypePassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "●"c
            txtRetypePassword.PasswordChar = "●"c
        End If
    End Sub

    Private Sub InitActionButtonsStyle()
        Dim buttons = New Button() {btnAdd, btnSave, btnEdit, btnCancel, btnDelete}
        For Each b In buttons
            b.UseVisualStyleBackColor = False
            b.FlatAppearance.BorderSize = 0
            b.FlatAppearance.MouseOverBackColor = BtnEnabledBack
            b.FlatAppearance.MouseDownBackColor = BtnEnabledBack
        Next
        RefreshActionButtonsStyle()
    End Sub

    Private Sub RefreshActionButtonsStyle()
        Dim buttons = New Button() {btnAdd, btnSave, btnEdit, btnCancel, btnDelete}
        For Each b In buttons
            If b.Enabled Then
                b.BackColor = BtnEnabledBack
                b.ForeColor = BtnEnabledFore
            Else
                b.BackColor = BtnDisabledBack
                b.ForeColor = BtnDisabledFore
            End If
        Next

        btnMnuSave.Enabled = btnSave.Enabled
        btnMnuCancel.Enabled = btnCancel.Enabled
        btnMnuAddNew.Enabled = btnAdd.Enabled
        btnMnuEdit.Enabled = btnEdit.Enabled
        btnMnuDelete.Enabled = btnDelete.Enabled
    End Sub

    Private Sub SetMode(mode As FormMode)
        CurrentMode = mode
        Dim editing As Boolean = (mode = FormMode.Adding OrElse mode = FormMode.Editing)

        gbReservationDetails.Enabled = True
        GroupBox1.Enabled = Not editing
        dgvUserForm.Enabled = Not editing
        dgvUserForm.TabStop = Not editing
        If editing Then
            LastSelectedUserID = SelectedUserID
            dgvUserForm.ClearSelection()
        End If

        txtUserID.ReadOnly = True
        txtUserName.ReadOnly = Not editing
        cboPositionEdit.Enabled = editing
        txtPassword.ReadOnly = Not editing
        txtRetypePassword.ReadOnly = Not editing
        cboPrivilege.Enabled = editing
        UpdatePrivilegeLock()

        btnSave.Enabled = editing
        btnCancel.Enabled = editing

        btnAdd.Enabled = Not editing
        btnEdit.Enabled = Not editing AndAlso SelectedUserID <> ""
        btnDelete.Enabled = Not editing AndAlso SelectedUserID <> ""
        btnUploadPhoto.Visible = editing
        btnUploadPhoto.Enabled = editing

        RefreshActionButtonsStyle()
    End Sub

    Private Sub LoadUsers()
        Dim dt As New DataTable()
        Dim sql As String =
            "SELECT [UserID], [User Name], [Privilege], [Position], [Password], [IsActive], [CreatedAt], [LastLogin], [UserPhotoPath] " &
            "FROM tblUsers WHERE 1=1 "

        Dim search As String = txtSearch.Text.Trim()
        If search <> "" Then
            sql &= " AND (" &
                   " [UserID] LIKE ? OR [User Name] LIKE ? " &
                   ") "
        End If

        If cboFilterPrivilege.SelectedIndex > 0 Then
            sql &= " AND [Privilege]=? "
        End If

        If cboPosition.SelectedIndex > 0 Then
            sql &= " AND [Position]=? "
        End If

        sql &= " ORDER BY [UserID] ASC;"

        Using conn As New OleDbConnection(ConnStr)
            Using cmd As New OleDbCommand(sql, conn)
                If search <> "" Then
                    Dim likePattern = "%" & search & "%"
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = likePattern
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = likePattern
                End If

                If cboFilterPrivilege.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboFilterPrivilege.Text
                End If

                If cboPosition.SelectedIndex > 0 Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboPosition.Text
                End If

                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        dgvUserForm.DataSource = dt
        dgvUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUserForm.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUserForm.MultiSelect = False
        dgvUserForm.ReadOnly = True
        dgvUserForm.AllowUserToAddRows = False
        dgvUserForm.RowHeadersVisible = False

        If dgvUserForm.Columns.Contains("Password") Then dgvUserForm.Columns("Password").Visible = False
        If dgvUserForm.Columns.Contains("IsActive") Then dgvUserForm.Columns("IsActive").Visible = False
        If dgvUserForm.Columns.Contains("CreatedAt") Then dgvUserForm.Columns("CreatedAt").Visible = False
        If dgvUserForm.Columns.Contains("LastLogin") Then dgvUserForm.Columns("LastLogin").Visible = False
        If dgvUserForm.Columns.Contains("UserPhotoPath") Then dgvUserForm.Columns("UserPhotoPath").Visible = False

        ApplyRoomsGridAppearanceToUsers()

        If dgvUserForm.Rows.Count > 0 Then
            For Each cell As DataGridViewCell In dgvUserForm.Rows(0).Cells
                If cell.Visible Then
                    dgvUserForm.CurrentCell = cell
                    Exit For
                End If
            Next
            PopulateInputsFromGrid()
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub ApplyRoomsGridAppearanceToUsers()
        dgvUserForm.AlternatingRowsDefaultCellStyle = New DataGridViewCellStyle() With {
            .BackColor = Color.PaleTurquoise
        }
        dgvUserForm.BackgroundColor = Color.AliceBlue
        dgvUserForm.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.[Single]

        Dim headerStyle As New DataGridViewCellStyle() With {
            .Alignment = DataGridViewContentAlignment.MiddleLeft,
            .BackColor = Color.DarkSlateGray,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0),
            .ForeColor = Color.White,
            .Padding = New Padding(0, 4, 0, 4),
            .SelectionBackColor = SystemColors.Highlight,
            .SelectionForeColor = SystemColors.HighlightText,
            .WrapMode = DataGridViewTriState.[True]
        }
        dgvUserForm.ColumnHeadersDefaultCellStyle = headerStyle
        dgvUserForm.EnableHeadersVisualStyles = False
        dgvUserForm.GridColor = SystemColors.ControlDarkDark

        Dim rowHeaderStyle As New DataGridViewCellStyle() With {
            .Alignment = DataGridViewContentAlignment.MiddleLeft,
            .BackColor = Color.LightSeaGreen,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0),
            .ForeColor = Color.White,
            .SelectionBackColor = Color.White,
            .SelectionForeColor = SystemColors.HighlightText,
            .WrapMode = DataGridViewTriState.[True]
        }
        dgvUserForm.RowHeadersDefaultCellStyle = rowHeaderStyle
        dgvUserForm.RowHeadersVisible = False

        Dim rowsStyle As New DataGridViewCellStyle() With {
            .BackColor = Color.Azure,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, 0),
            .SelectionBackColor = Color.Gold,
            .SelectionForeColor = SystemColors.InfoText
        }
        dgvUserForm.RowsDefaultCellStyle = rowsStyle

        dgvUserForm.RowTemplate.Height = 28
        dgvUserForm.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvUserForm.DefaultCellStyle.Font = New Font(dgvUserForm.Font.FontFamily, 12.0F)
        dgvUserForm.ColumnHeadersDefaultCellStyle.Font = New Font(dgvUserForm.Font.FontFamily, 11.0F, FontStyle.Bold)
    End Sub

    Private Sub dgvUserForm_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUserForm.SelectionChanged
        If IsSetupMode Then Return
        If CurrentMode <> FormMode.ViewMode Then Return
        If dgvUserForm.CurrentCell Is Nothing Then Return

        Dim row = dgvUserForm.Rows(dgvUserForm.CurrentCell.RowIndex)
        If row Is Nothing OrElse row.DataBoundItem Is Nothing Then Return
        If row.Cells("UserID").Value Is Nothing Then Return

        SelectedUserID = row.Cells("UserID").Value.ToString()
        PopulateInputsFromRow(row)
        SetMode(FormMode.ViewMode)
    End Sub

    Private Sub dgvUserForm_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserForm.RowEnter
        If IsSetupMode Then Return
        If CurrentMode <> FormMode.ViewMode Then Return
        If e.RowIndex < 0 Then Return
        Dim row = dgvUserForm.Rows(e.RowIndex)
        If row Is Nothing OrElse row.DataBoundItem Is Nothing Then Return
        If row.Cells("UserID").Value Is Nothing Then Return

        SelectedUserID = row.Cells("UserID").Value.ToString()
        PopulateInputsFromRow(row)
        SetMode(FormMode.ViewMode)
    End Sub

    Private Sub dgvUserForm_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvUserForm.KeyDown
        If dgvUserForm.CurrentCell Is Nothing Then Return
        If CurrentMode <> FormMode.ViewMode Then
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If

        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            Me.SelectNextControl(dgvUserForm, Not e.Shift, True, True, True)
            Return
        End If

        If e.KeyCode = Keys.Down Then
            MoveUserSelection(1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If

        If e.KeyCode = Keys.Up Then
            MoveUserSelection(-1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If
    End Sub

    Private Sub PopulateInputsFromGrid()
        If dgvUserForm.CurrentCell Is Nothing Then Return
        Dim row = dgvUserForm.Rows(dgvUserForm.CurrentCell.RowIndex)
        If row Is Nothing OrElse row.DataBoundItem Is Nothing Then Return
        PopulateInputsFromRow(row)
    End Sub

    Private Sub PopulateInputsFromRow(row As DataGridViewRow)
        If row Is Nothing Then Return
        txtUserID.Text = row.Cells("UserID").Value.ToString()
        txtUserName.Text = row.Cells("User Name").Value.ToString()
        cboPrivilege.Text = row.Cells("Privilege").Value.ToString()
        Dim posValue As String = row.Cells("Position").Value.ToString()
        If posValue <> "" AndAlso Not cboPositionEdit.Items.Contains(posValue) Then
            cboPositionEdit.Items.Add(posValue)
        End If
        cboPositionEdit.Text = posValue
        txtPassword.Text = row.Cells("Password").Value.ToString()
        txtRetypePassword.Text = txtPassword.Text
        UpdatePrivilegeLock()
        If dgvUserForm.Columns.Contains("UserPhotoPath") Then
            PictureBox1.Image = Nothing
            LoadUserPhoto(row.Cells("UserPhotoPath").Value)
        End If
        IsDirty = False
    End Sub

    Private Sub ClearInputs()
        txtUserID.Clear()
        txtUserName.Clear()
        cboPositionEdit.SelectedIndex = -1
        txtPassword.Clear()
        txtRetypePassword.Clear()
        cboPrivilege.SelectedIndex = -1
        UpdatePrivilegeLock()
        PictureBox1.Image = Nothing
        IsDirty = False
    End Sub

    Private Function ValidateInputs() As Boolean
        ResetInputStyles()
        NormalizePrivilegeByPosition()
        If Not RequireText(txtUserName, "User Name") Then Return False
        If IsUserNameTaken(txtUserName.Text.Trim(), If(CurrentMode = FormMode.Editing, SelectedUserID, "")) Then
            MessageBox.Show("Username already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUserName.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(cboPrivilege.Text) Then
            MessageBox.Show("Privilege is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboPrivilege.BackColor = Color.MistyRose
            cboPrivilege.Focus()
            Return False
        End If
        If Not RequireText(cboPositionEdit, "Position") Then Return False
        If Not RequireText(txtPassword, "Password") Then Return False
        If txtPassword.Text <> txtRetypePassword.Text Then
            MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.BackColor = Color.MistyRose
            txtRetypePassword.BackColor = Color.MistyRose
            txtRetypePassword.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ResetInputStyles()
        txtUserName.BackColor = SystemColors.Window
        cboPositionEdit.BackColor = SystemColors.Window
        txtPassword.BackColor = SystemColors.Window
        txtRetypePassword.BackColor = SystemColors.Window
        cboPrivilege.BackColor = SystemColors.Window
    End Sub

    Private Function RequireText(tb As TextBox, fieldName As String) As Boolean
        If tb.Text.Trim().Length < 1 Then
            MessageBox.Show("Please enter " & fieldName & ".", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tb.BackColor = Color.MistyRose
            tb.Focus()
            tb.SelectAll()
            Return False
        End If
        tb.BackColor = SystemColors.Window
        Return True
    End Function

    Private Function RequireText(cb As ComboBox, fieldName As String) As Boolean
        If String.IsNullOrWhiteSpace(cb.Text) Then
            MessageBox.Show("Please select " & fieldName & ".", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cb.BackColor = Color.MistyRose
            cb.Focus()
            Return False
        End If
        cb.BackColor = SystemColors.Window
        Return True
    End Function

    Private Sub NormalizePrivilegeByPosition()
        Dim pos = cboPositionEdit.Text.Trim().ToLowerInvariant()
        If pos = "owner" OrElse pos = "manager" Then
            cboPrivilege.Text = "Admin"
        End If
    End Sub

    Private Function IsUserNameTaken(userName As String, excludeUserId As String) As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM tblUsers WHERE UCase([User Name])=UCase(?)"
        If Not String.IsNullOrWhiteSpace(excludeUserId) Then
            sql &= " AND [UserID]<>?"
        End If

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = userName
                If Not String.IsNullOrWhiteSpace(excludeUserId) Then
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = excludeUserId
                End If
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Sub ExecuteAdd()
        If Not btnAdd.Enabled Then Return
        SelectedUserID = ""
        ClearInputs()
        SetMode(FormMode.Adding)
        txtUserID.Text = GenerateNextUserId()
        txtUserName.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ExecuteAdd()
    End Sub

    Private Sub ExecuteEdit()
        If Not btnEdit.Enabled Then Return
        If SelectedUserID = "" Then
            MessageBox.Show("Please select a user to edit.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        SetMode(FormMode.Editing)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ExecuteEdit()
    End Sub

    Private Sub ExecuteCancel()
        If Not btnCancel.Enabled Then Return
        If IsSetupMode Then
            ReturnToLoginFromSetup()
            Return
        End If
        PendingPhotoSourcePath = ""
        SuppressPhotoRefresh = False
        IsDirty = False

        LoadUsers()

        Dim targetId = If(LastSelectedUserID <> "", LastSelectedUserID, SelectedUserID)
        If targetId <> "" Then
            FocusUserRowById(targetId)
            SelectedUserID = targetId
            PopulateInputsFromGrid()
        ElseIf dgvUserForm.Rows.Count > 0 Then
            For Each cell As DataGridViewCell In dgvUserForm.Rows(0).Cells
                If cell.Visible Then
                    dgvUserForm.CurrentCell = cell
                    Exit For
                End If
            Next
            PopulateInputsFromGrid()
        Else
            ClearInputs()
        End If
        SetMode(FormMode.ViewMode)
        dgvUserForm.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ExecuteCancel()
    End Sub

    Private Sub ExecuteSave()
        If Not btnSave.Enabled Then Return
        NormalizePrivilegeByPosition()
        If Not ValidateInputs() Then Return
        If Not IsDirty Then
            MessageBox.Show("No changes to save.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirmText As String = If(CurrentMode = FormMode.Adding, "Do you want to add this user?", "Do you want to save these changes?")
        Dim confirmTitle As String = If(CurrentMode = FormMode.Adding, "Confirm Add", "Confirm Update")
        If MessageBox.Show(confirmText, confirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            If CurrentMode = FormMode.Adding Then
                Dim sqlInsert As String =
                    "INSERT INTO tblUsers ([UserID], [User Name], [Privilege], [Position], [Password], [IsActive], [CreatedAt], [LastLogin]) " &
                    "VALUES (?,?,?,?,?,?,?,?);"
                Using cmd As New OleDbCommand(sqlInsert, conn)
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtUserID.Text.Trim()
                    AddUserParameters(cmd)
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = True
                    cmd.Parameters.Add("?", OleDbType.Date).Value = Now
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DBNull.Value
                    cmd.ExecuteNonQuery()
                End Using
                SelectedUserID = txtUserID.Text.Trim()
                If PendingPhotoSourcePath <> "" Then
                    SaveUserPhoto(SelectedUserID)
                End If
            ElseIf CurrentMode = FormMode.Editing Then
                Dim sqlUpdate As String =
                    "UPDATE tblUsers SET [User Name]=?, [Privilege]=?, [Position]=?, [Password]=?, [IsActive]=? WHERE [UserID]=?;"
                Using cmd As New OleDbCommand(sqlUpdate, conn)
                    AddUserParameters(cmd)
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = True
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = SelectedUserID
                    cmd.ExecuteNonQuery()
                End Using

                If PendingPhotoSourcePath <> "" Then
                    SaveUserPhoto(SelectedUserID)
                End If
            End If
        End Using

        LoadUsers()
        SetMode(FormMode.ViewMode)
        FocusUserRowById(SelectedUserID)
        PopulateInputsFromGrid()

        If IsSetupMode Then
            ReturnToLoginFromSetup()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ExecuteSave()
    End Sub

    Private Sub ExecuteDelete()
        If Not btnDelete.Enabled Then Return
        If SelectedUserID = "" Then
            MessageBox.Show("Please select a user to delete.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not String.IsNullOrWhiteSpace(AppSession.UserId) AndAlso String.Equals(SelectedUserID, AppSession.UserId, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("You cannot delete the currently logged-in user.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim previousRowIndex As Integer = -1
        Dim photoPathValue As Object = Nothing
        If dgvUserForm.CurrentRow IsNot Nothing Then
            previousRowIndex = dgvUserForm.CurrentRow.Index
            If dgvUserForm.Columns.Contains("UserPhotoPath") Then
                photoPathValue = dgvUserForm.CurrentRow.Cells("UserPhotoPath").Value
            End If
        End If

        Dim shouldDeletePhoto As Boolean = False
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            If IsLastAdmin(SelectedUserID, conn) Then
                MessageBox.Show("You cannot delete the last admin user.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            shouldDeletePhoto = ShouldDeleteUserPhoto(photoPathValue, conn, SelectedUserID)
            Using cmd As New OleDbCommand("DELETE FROM tblUsers WHERE [UserID]=?;", conn)
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = SelectedUserID
                cmd.ExecuteNonQuery()
            End Using
        End Using

        If shouldDeletePhoto Then
            TryDeleteUserPhoto(photoPathValue)
        End If

        SelectedUserID = ""
        LoadUsers()
        If dgvUserForm.Rows.Count > 0 Then
            If previousRowIndex < 0 Then
                previousRowIndex = 0
            ElseIf previousRowIndex >= dgvUserForm.Rows.Count Then
                previousRowIndex = dgvUserForm.Rows.Count - 1
            End If

            For Each cell As DataGridViewCell In dgvUserForm.Rows(previousRowIndex).Cells
                If cell.Visible Then
                    dgvUserForm.CurrentCell = cell
                    dgvUserForm.Rows(previousRowIndex).Selected = True
                    Exit For
                End If
            Next
            PopulateInputsFromGrid()
        Else
            ClearInputs()
        End If
        SetMode(FormMode.ViewMode)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ExecuteDelete()
    End Sub

    Private Sub btnMnuAddNew_Click(sender As Object, e As EventArgs) Handles btnMnuAddNew.Click
        ExecuteAdd()
    End Sub

    Private Sub btnMnuSave_Click(sender As Object, e As EventArgs) Handles btnMnuSave.Click
        ExecuteSave()
    End Sub

    Private Sub btnMnuEdit_Click(sender As Object, e As EventArgs) Handles btnMnuEdit.Click
        ExecuteEdit()
    End Sub

    Private Sub btnMnuDelete_Click(sender As Object, e As EventArgs) Handles btnMnuDelete.Click
        ExecuteDelete()
    End Sub

    Private Sub btnMnuCancel_Click(sender As Object, e As EventArgs) Handles btnMnuCancel.Click
        ExecuteCancel()
    End Sub

    Private Sub AddUserParameters(cmd As OleDbCommand)
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtUserName.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboPrivilege.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboPositionEdit.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtPassword.Text.Trim()
    End Sub

    ' --- USER PHOTO SUPPORT ---
    Private Function UserImagesFolder() As String
        Dim dbPath = DbConfig.GetDbPath()
        Dim dbDir = Path.GetDirectoryName(dbPath)
        Return Path.Combine(dbDir, "UserPhotos")
    End Function

    Private Sub EnsureUserImagesFolder()
        Dim folder = UserImagesFolder()
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If
    End Sub

    Private Function SanitizeFileNamePart(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return ""
        Dim cleaned As String = value
        For Each ch In Path.GetInvalidFileNameChars()
            cleaned = cleaned.Replace(ch, "_"c)
        Next
        cleaned = cleaned.Trim()
        If cleaned = "" Then cleaned = "User"
        Return cleaned
    End Function

    Private Function BuildUserImageFileName(userName As String, userId As String, sourceFile As String) As String
        Dim ext As String = Path.GetExtension(sourceFile).ToLower()
        If ext <> ".jpg" AndAlso ext <> ".jpeg" AndAlso ext <> ".png" AndAlso ext <> ".bmp" Then
            ext = ".jpg"
        End If

        Dim safeUserName = SanitizeFileNamePart(userName)
        If String.IsNullOrWhiteSpace(safeUserName) Then
            safeUserName = "User"
        End If

        Return $"{safeUserName}_{userId}{ext}"
    End Function

    Private Sub MigrateUserPhotoNames()
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT [UserID], [User Name], [UserPhotoPath] FROM tblUsers WHERE [UserPhotoPath] Is Not Null AND [UserPhotoPath]<>'';", conn),
                      reader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim userId As String = reader("UserID").ToString()
                        Dim userName As String = reader("User Name").ToString()
                        Dim photoPath As String = reader("UserPhotoPath").ToString()
                        If String.IsNullOrWhiteSpace(photoPath) Then Continue While

                        Dim fullPath As String
                        If photoPath.StartsWith("\\") OrElse photoPath.Contains(":\") Then
                            fullPath = photoPath
                        Else
                            fullPath = Path.Combine(UserImagesFolder(), photoPath)
                        End If

                        If Not File.Exists(fullPath) Then Continue While

                        Dim newFileName = BuildUserImageFileName(userName, userId, fullPath)
                        Dim newFullPath = Path.Combine(UserImagesFolder(), newFileName)

                        If String.Equals(fullPath, newFullPath, StringComparison.OrdinalIgnoreCase) Then
                            If Not String.Equals(photoPath, newFileName, StringComparison.OrdinalIgnoreCase) Then
                                UpdateUserPhotoPath(conn, userId, newFileName)
                            End If
                            Continue While
                        End If

                        EnsureUserImagesFolder()
                        If Not File.Exists(newFullPath) Then
                            Try
                                CopyFileWithRetries(fullPath, newFullPath, 5, 120)
                            Catch
                                Continue While
                            End Try
                        End If
                        UpdateUserPhotoPath(conn, userId, newFileName)
                    End While
                End Using
            End Using
        Catch
            ' Silent migration
        End Try
    End Sub

    Private Sub UpdateUserPhotoPath(conn As OleDbConnection, userId As String, fileName As String)
        Using cmd As New OleDbCommand("UPDATE tblUsers SET [UserPhotoPath]=? WHERE [UserID]=?;", conn)
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = fileName
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = userId
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub SetPictureBoxImageSafe(fullPath As String)
        Try
            If String.IsNullOrWhiteSpace(fullPath) OrElse Not File.Exists(fullPath) Then
                PictureBox1.Image = Nothing
                Return
            End If

            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using img = Image.FromStream(fs)
                    PictureBox1.Image = New Bitmap(img)
                End Using
            End Using
        Catch
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub LoadUserPhoto(userPhotoPathValue As Object)
        Dim fileValue As String = If(userPhotoPathValue Is Nothing, "", userPhotoPathValue.ToString())
        If String.IsNullOrWhiteSpace(fileValue) Then
            PictureBox1.Image = Nothing
            Return
        End If

        Dim fullPath As String = ResolveUserPhotoPath(fileValue)

        SetPictureBoxImageSafe(fullPath)
    End Sub

    Private Sub SaveUserPhoto(userId As String)
        If String.IsNullOrWhiteSpace(userId) Then Return
        If String.IsNullOrWhiteSpace(PendingPhotoSourcePath) Then Return
        If Not File.Exists(PendingPhotoSourcePath) Then Return

        EnsureUserImagesFolder()

        Dim fileName = BuildUserImageFileName(txtUserName.Text.Trim(), userId, PendingPhotoSourcePath)
        Dim destPath = Path.Combine(UserImagesFolder(), fileName)

        Dim sourceFullPath = Path.GetFullPath(PendingPhotoSourcePath)
        Dim destFullPath = Path.GetFullPath(destPath)
        If Not sourceFullPath.Equals(destFullPath, StringComparison.OrdinalIgnoreCase) Then
            Try
                CopyFileWithRetries(sourceFullPath, destFullPath, 5, 120)
            Catch ex As IOException
                MessageBox.Show("The selected photo is currently in use by another process. Please close it and try again.",
                                "Photo In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End Try
        End If

        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand("UPDATE tblUsers SET [UserPhotoPath]=? WHERE [UserID]=?", conn)
            conn.Open()
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = fileName
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = userId
            cmd.ExecuteNonQuery()
        End Using

        PendingPhotoSourcePath = ""
        LoadUserPhoto(fileName)
    End Sub

    Private Function ResolveUserPhotoPath(fileValue As String) As String
        If String.IsNullOrWhiteSpace(fileValue) Then Return ""
        If fileValue.StartsWith("\\") OrElse fileValue.Contains(":\") Then
            Return fileValue
        End If
        Return Path.Combine(UserImagesFolder(), fileValue)
    End Function

    Private Sub TryDeleteUserPhoto(photoPathValue As Object)
        Dim fileValue As String = If(photoPathValue Is Nothing, "", photoPathValue.ToString())
        If String.IsNullOrWhiteSpace(fileValue) Then Return
        Dim fullPath As String = ResolveUserPhotoPath(fileValue)
        If fullPath = "" Then Return
        Try
            If File.Exists(fullPath) Then
                File.Delete(fullPath)
            End If
        Catch
            ' ignore delete errors
        End Try
    End Sub

    Private Function ShouldDeleteUserPhoto(photoPathValue As Object, conn As OleDbConnection, userId As String) As Boolean
        Dim fileValue As String = If(photoPathValue Is Nothing, "", photoPathValue.ToString())
        If String.IsNullOrWhiteSpace(fileValue) Then Return False

        Using cmd As New OleDbCommand("SELECT COUNT(*) FROM tblUsers WHERE [UserPhotoPath]=? AND [UserID]<>?;", conn)
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = fileValue
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = userId
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count = 0
        End Using
    End Function

    Private Function IsLastAdmin(userId As String, conn As OleDbConnection) As Boolean
        Dim isAdmin As Boolean = False
        Using cmdCheck As New OleDbCommand("SELECT [Privilege] FROM tblUsers WHERE [UserID]=?;", conn)
            cmdCheck.Parameters.Add("?", OleDbType.VarWChar).Value = userId
            Dim privObj = cmdCheck.ExecuteScalar()
            Dim priv As String = If(privObj Is Nothing OrElse IsDBNull(privObj), "", privObj.ToString())
            isAdmin = priv.Equals("Admin", StringComparison.OrdinalIgnoreCase)
        End Using
        If Not isAdmin Then Return False

        Using cmdCount As New OleDbCommand("SELECT COUNT(*) FROM tblUsers WHERE [Privilege]='Admin';", conn)
            Dim cnt As Integer = Convert.ToInt32(cmdCount.ExecuteScalar())
            Return cnt <= 1
        End Using
    End Function

    Private Sub CopyFileWithRetries(sourcePath As String, destPath As String, retries As Integer, delayMs As Integer)
        For attempt = 1 To retries
            Try
                Using src As New FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    Using dst As New FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None)
                        src.CopyTo(dst)
                    End Using
                End Using
                Exit Sub
            Catch ex As IOException
                If attempt = retries Then Throw
                Threading.Thread.Sleep(delayMs)
            End Try
        Next
    End Sub

    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        IsDirty = True

        If CurrentMode <> FormMode.Adding AndAlso CurrentMode <> FormMode.Editing Then
            MessageBox.Show("Click Edit/Add first to change the photo.", "Photo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        SuppressPhotoRefresh = True
        Dim previousPhotoValue As Object = Nothing
        If dgvUserForm.CurrentRow IsNot Nothing AndAlso dgvUserForm.Columns.Contains("UserPhotoPath") Then
            previousPhotoValue = dgvUserForm.CurrentRow.Cells("UserPhotoPath").Value
        End If
        PictureBox1.Image = Nothing
        PictureBox1.Refresh()

        Using ofd As New OpenFileDialog()
            ofd.Title = "Choose user photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                PendingPhotoSourcePath = ofd.FileName
                SetPictureBoxImageSafe(PendingPhotoSourcePath)
            Else
                If previousPhotoValue IsNot Nothing Then
                    LoadUserPhoto(previousPhotoValue)
                Else
                    PictureBox1.Image = Nothing
                End If
            End If
        End Using

        SuppressPhotoRefresh = False
    End Sub

    Private Function GenerateNextUserId() As String
        Dim nextNumber As Integer = 1
        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand("SELECT MAX([UserID]) FROM tblUsers WHERE [UserID] LIKE 'RMS_%';", conn)
                Dim maxIdObj = cmd.ExecuteScalar()
                If maxIdObj IsNot Nothing AndAlso Not IsDBNull(maxIdObj) Then
                    Dim maxId As String = maxIdObj.ToString()
                    Dim parts = maxId.Split("_"c)
                    If parts.Length = 2 Then
                        Dim num As Integer
                        If Integer.TryParse(parts(1), num) Then
                            nextNumber = num + 1
                        End If
                    End If
                End If
            End Using
        End Using
        Return $"RMS_{nextNumber:0000}"
    End Function

    Private Sub FocusUserRowById(userId As String)
        If String.IsNullOrWhiteSpace(userId) Then Return
        For Each row As DataGridViewRow In dgvUserForm.Rows
            If row.Cells("UserID").Value IsNot Nothing AndAlso row.Cells("UserID").Value.ToString() = userId Then
                dgvUserForm.ClearSelection()
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible Then
                        dgvUserForm.CurrentCell = cell
                        row.Selected = True
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Private Sub InputChanged(sender As Object, e As EventArgs) _
        Handles txtUserName.TextChanged, cboPositionEdit.SelectedIndexChanged, txtPassword.TextChanged, txtRetypePassword.TextChanged, cboPrivilege.SelectedIndexChanged
        If CurrentMode = FormMode.Adding OrElse CurrentMode = FormMode.Editing Then
            IsDirty = True
        End If
        ResetInputStyles()
    End Sub

    Private Sub UpdatePrivilegeLock()
        Dim editing As Boolean = (CurrentMode = FormMode.Adding OrElse CurrentMode = FormMode.Editing)
        Dim pos = cboPositionEdit.Text.Trim().ToLowerInvariant()
        Dim lockAdmin As Boolean = (pos = "owner" OrElse pos = "manager")
        If lockAdmin Then
            cboPrivilege.Text = "Admin"
        End If
        cboPrivilege.Enabled = editing AndAlso Not lockAdmin
    End Sub

    Private Sub cboPositionEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPositionEdit.SelectedIndexChanged
        If CurrentMode <> FormMode.Adding AndAlso CurrentMode <> FormMode.Editing Then Return
        UpdatePrivilegeLock()
    End Sub

    Private Sub PreventViewModeFocus(sender As Object, e As EventArgs) Handles _
        txtUserID.Enter, txtUserName.Enter, cboPositionEdit.Enter, txtPassword.Enter, txtRetypePassword.Enter, cboPrivilege.Enter
        If CurrentMode <> FormMode.ViewMode Then Return
        BeginInvoke(Sub() dgvUserForm.Focus())
    End Sub

    Private Sub FilterControls_Changed(sender As Object, e As EventArgs) _
        Handles txtSearch.TextChanged, cboFilterPrivilege.SelectedIndexChanged, cboPosition.SelectedIndexChanged
        LoadUsers()
    End Sub

    Private Sub DebugFilterQuery(sql As String, cmd As OleDbCommand)
        Dim msg As String = "SQL:" & vbCrLf & sql & vbCrLf & vbCrLf &
            "Parameter count: " & cmd.Parameters.Count.ToString()
        MessageBox.Show(msg, "Filter Debug")
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        cboFilterPrivilege.SelectedIndex = 0
        cboPosition.SelectedIndex = 0
        LoadUsers()
    End Sub

    Private Sub mnuRefresh_Click(sender As Object, e As EventArgs) Handles mnuRefresh.Click
        LoadUsers()
        LoadFilterCombosFromDB()
    End Sub

    Private Sub JumpUserSelection(toEnd As Boolean)
        If dgvUserForm.CurrentCell Is Nothing OrElse dgvUserForm.Rows.Count = 0 Then Return
        Dim targetRow As Integer = If(toEnd, dgvUserForm.Rows.Count - 1, 0)
        For Each cell As DataGridViewCell In dgvUserForm.Rows(targetRow).Cells
            If cell.Visible Then
                dgvUserForm.CurrentCell = cell
                Exit For
            End If
        Next
    End Sub

    Private Sub MoveUserSelection(delta As Integer)
        If dgvUserForm.CurrentCell Is Nothing Then Return
        Dim col = dgvUserForm.CurrentCell.ColumnIndex
        Dim row = dgvUserForm.CurrentCell.RowIndex + delta
        If row < 0 Then row = dgvUserForm.Rows.Count - 1
        If row >= dgvUserForm.Rows.Count Then row = 0
        If dgvUserForm.Rows.Count = 0 Then Return
        dgvUserForm.CurrentCell = dgvUserForm.Rows(row).Cells(col)
    End Sub

    Private Sub mnuBOF_Click(sender As Object, e As EventArgs) Handles mnuBOF.Click
        JumpUserSelection(False)
    End Sub

    Private Sub mnuNext_Click(sender As Object, e As EventArgs) Handles mnuNext.Click
        MoveUserSelection(1)
    End Sub

    Private Sub mnuPrevious_Click(sender As Object, e As EventArgs) Handles mnuPrevious.Click
        MoveUserSelection(-1)
    End Sub

    Private Sub mnuEOF_Click(sender As Object, e As EventArgs) Handles mnuEOF.Click
        JumpUserSelection(True)
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim result = MessageBox.Show("Are you sure you want to exit the User Form?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            MainForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub mnuCrystalReport_Click(sender As Object, e As EventArgs) Handles mnuCrystalReport.Click
        MessageBox.Show("Print (Crystal Report) not implemented for Users.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub mnuExcel_Click(sender As Object, e As EventArgs) Handles mnuExcel.Click
        PrintUsersToExcelTemplate()
    End Sub

    Private Sub PrintUsersToExcelTemplate()
        Dim templatePath As String = Path.Combine(Application.StartupPath, "ReportTemplate.xlsx")
        If Not File.Exists(templatePath) Then
            MessageBox.Show("Excel template not found: " & templatePath, "Export")
            Return
        End If

        Dim xlApp As Object = Nothing
        Dim wb As Object = Nothing
        Dim ws As Object = Nothing
        Dim dataStart As Object = Nothing

        Try
            xlApp = CreateObject("Excel.Application")
            xlApp.Visible = True
            wb = xlApp.Workbooks.Open(templatePath)
            ws = wb.Worksheets(1)

            Try
                dataStart = wb.Names("DataStart").RefersToRange
            Catch
                dataStart = Nothing
            End Try

            Dim headerRow As Integer = 5
            Dim dataStartRow As Integer = 6
            Dim startCol As Integer = 2 ' Column B

            Dim colUserId = If(dgvUserForm.Columns.Contains("UserID"), dgvUserForm.Columns("UserID"), Nothing)
            Dim colUserName = If(dgvUserForm.Columns.Contains("User Name"), dgvUserForm.Columns("User Name"), Nothing)
            Dim colPrivilege = If(dgvUserForm.Columns.Contains("Privilege"), dgvUserForm.Columns("Privilege"), Nothing)
            Dim colPosition = If(dgvUserForm.Columns.Contains("Position"), dgvUserForm.Columns("Position"), Nothing)

            ' Title
            Dim titleRange = ws.Range("D3:F3")
            titleRange.Merge()
            titleRange.Value = "USER REPORT"
            titleRange.Font.Bold = True
            titleRange.Font.Size = 20

            ' Headers (B5:C5, D5:E5, F5, G5)
            Dim hdrUserId = ws.Range("B5:C5")
            hdrUserId.Merge()
            hdrUserId.Value = "User ID"

            Dim hdrUserName = ws.Range("D5:E5")
            hdrUserName.Merge()
            hdrUserName.Value = "User Name"

            ws.Range("F5").Value = "Privilege"
            ws.Range("G5").Value = "Position"

            Dim headerRange = ws.Range("B5:G5")
            headerRange.Font.Bold = True
            headerRange.Font.Color = RGB(255, 255, 255)
            headerRange.Interior.Color = RGB(51, 63, 79)

            ' Date/Time stamp
            ws.Range("H2").Value = Date.Now.ToString("yyyy-MM-dd")
            ws.Range("H3").Value = Date.Now.ToString("HH:mm:ss")

            ' Data
            Dim r As Integer = dataStartRow
            For Each row As DataGridViewRow In dgvUserForm.Rows
                If row.IsNewRow Then Continue For

                Dim userIdVal As Object = If(colUserId IsNot Nothing, row.Cells(colUserId.Index).Value, Nothing)
                Dim userNameVal As Object = If(colUserName IsNot Nothing, row.Cells(colUserName.Index).Value, Nothing)
                Dim privilegeVal As Object = If(colPrivilege IsNot Nothing, row.Cells(colPrivilege.Index).Value, Nothing)
                Dim positionVal As Object = If(colPosition IsNot Nothing, row.Cells(colPosition.Index).Value, Nothing)

                Dim userIdRange = ws.Range($"B{r}:C{r}")
                userIdRange.Merge()
                userIdRange.Value = userIdVal

                Dim userNameRange = ws.Range($"D{r}:E{r}")
                userNameRange.Merge()
                userNameRange.Value = userNameVal

                ws.Range($"F{r}").Value = privilegeVal
                ws.Range($"G{r}").Value = positionVal

                r += 1
            Next

            ' Borders for header + data
            Dim lastRow As Integer = Math.Max(dataStartRow, r - 1)
            Dim fullRange = ws.Range(ws.Cells(headerRow, startCol), ws.Cells(lastRow, 7))
            fullRange.Borders.LineStyle = 1 ' xlContinuous
            fullRange.Borders.Weight = 2    ' xlThin

            Try
                xlApp.CommandBars.ExecuteMso("FilePrintPreview")
            Catch
                wb.PrintPreview()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excel Export failed")
        Finally
            If dataStart IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(dataStart)
            If ws IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(ws)
            If wb IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(wb)
            If xlApp IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
