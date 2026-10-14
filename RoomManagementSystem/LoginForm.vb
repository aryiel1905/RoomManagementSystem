Imports System.Data.OleDb

Public Class LoginForm
    Private ReadOnly ConnStr As String = DbConfig.GetConnStr()
    Private RemainingTries As Integer = 3
    Private SuppressValidation As Boolean = False

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CLOSE As Integer = &H10
        If m.Msg = WM_CLOSE Then
            SuppressValidation = True
            Me.AutoValidate = AutoValidate.Disable
            txtUserN.CausesValidation = False
            txtPass.CausesValidation = False
        End If
        MyBase.WndProc(m)
    End Sub

    Public Sub ResetInputs()
        txtUserN.Clear()
        txtPass.Clear()
        cbShowPassword.Checked = False
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtPass.PasswordChar = "●"c
        btnClose.CausesValidation = False
    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        SuppressValidation = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUserN.Text) Then
            MessageBox.Show("Please enter your username.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUserN.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPass.Text) Then
            MessageBox.Show("Please enter your password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPass.Focus()
            Return
        End If

        Dim sql As String =
            "SELECT UserID, [User Name], [Position], [Privilege] FROM tblUsers WHERE [User Name]=? AND [Password]=?;"

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtUserN.Text.Trim()
                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtPass.Text.Trim()
                Using rd = cmd.ExecuteReader()
                    If Not rd.Read() Then
                        RemainingTries -= 1
                        If RemainingTries <= 0 Then
                            MessageBox.Show("Invalid username or password. No tries left. The application will now close.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Application.Exit()
                            Return
                        End If
                        MessageBox.Show($"Invalid username or password. You have {RemainingTries} tries left.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtPass.Clear()
                        txtPass.Focus()
                        Return
                    End If
                    AppSession.CurrentUserName = rd("User Name").ToString()
                    AppSession.CurrentPosition = rd("Position").ToString()
                    AppSession.CurrentPrivilege = rd("Privilege").ToString()
                    If IsDBNull(rd("UserID")) Then
                        AppSession.UserId = ""
                    Else
                        AppSession.UserId = rd("UserID").ToString()
                    End If
                End Using
            End Using
        End Using

        RemainingTries = 3
        MainForm.RefreshSessionUI()
        MainForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        SuppressValidation = True
        txtUserN.CausesValidation = False
        txtPass.CausesValidation = False
        Dim result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        Else
            SuppressValidation = False
            txtUserN.CausesValidation = True
            txtPass.CausesValidation = True
        End If
    End Sub

    Private Sub txtUserN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserN.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If String.IsNullOrWhiteSpace(txtUserN.Text) Then
                MessageBox.Show("Please enter your username.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUserN.Focus()
                Return
            End If
            txtPass.Focus()
        End If
    End Sub

    Private Sub txtUserN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUserN.Validating
        If SuppressValidation Then Return
        If String.IsNullOrWhiteSpace(txtUserN.Text) Then
            MessageBox.Show("Please enter your username.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        End If
    End Sub

    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SuppressValidation = True
        txtUserN.CausesValidation = False
        txtPass.CausesValidation = False
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub cbShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowPassword.CheckedChanged
        If cbShowPassword.Checked Then
            txtPass.PasswordChar = ControlChars.NullChar
        Else
            txtPass.PasswordChar = "●"c
        End If
    End Sub

    Private Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.Alt AndAlso e.KeyCode = Keys.F12 Then
            e.SuppressKeyPress = True
            AppSession.UserSetupMode = True
            UserForm.Show()
            Me.Hide()
        End If
    End Sub
End Class
