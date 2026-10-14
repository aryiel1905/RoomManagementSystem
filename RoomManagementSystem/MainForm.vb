Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRoleAccess()
        UpdateUserLabel()
        NormalizeStatusesOnLoad()
    End Sub

    Public Sub UpdateUserLabel()
        If lblPrivilegeUN IsNot Nothing Then
            If AppSession.CurrentUserName <> "" AndAlso AppSession.CurrentPosition <> "" Then
                lblPrivilegeUN.Text = $"{AppSession.CurrentPosition} {AppSession.CurrentUserName}!"
            ElseIf AppSession.CurrentUserName <> "" Then
                lblPrivilegeUN.Text = $"{AppSession.CurrentUserName}!"
            Else
                lblPrivilegeUN.Text = "--------------"
            End If
        End If
    End Sub

    Public Sub ApplyRoleAccess()
        Dim role As String = AppSession.CurrentPosition.Trim().ToLowerInvariant()

        btnUserForm.Enabled = False
        btnReservation.Enabled = False
        btnRoom.Enabled = False
        btnGuestLookup.Enabled = False
        btnCheckOut.Enabled = False
        btnReports.Enabled = False
        btnHistory.Enabled = False
        btnAmenities.Enabled = False

        Select Case role
            Case "owner", "manager", "admin"
                btnUserForm.Enabled = True
                btnReservation.Enabled = True
                btnRoom.Enabled = True
                btnGuestLookup.Enabled = True
                btnCheckOut.Enabled = True
                btnReports.Enabled = True
                btnHistory.Enabled = True
                btnAmenities.Enabled = True

            Case "front desk"
                btnReservation.Enabled = True
                btnGuestLookup.Enabled = True
                btnCheckOut.Enabled = True
                btnAmenities.Enabled = True

            Case "cashier"
                btnGuestLookup.Enabled = True
                btnCheckOut.Enabled = True
                btnAmenities.Enabled = True
        End Select
    End Sub

    Public Sub RefreshSessionUI()
        ApplyRoleAccess()
        UpdateUserLabel()
    End Sub
    Private Sub btnUserForm_Click(sender As Object, e As EventArgs) Handles btnUserForm.Click
        UserForm.PrepareForNormalUse()
        UserForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnReservation_Click(sender As Object, e As EventArgs) Handles btnReservation.Click
        frmReservations.Show()
        Me.Hide()
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        CheckOut.Show()
        Me.Hide()
    End Sub

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        frmRooms.Show()
        Me.Hide()
    End Sub

    Private Sub btnAmenities_Click(sender As Object, e As EventArgs) Handles btnAmenities.Click
        DiningNBar.Show()
        Me.Hide()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> DialogResult.Yes Then Return

        AppSession.CurrentUserName = ""
        AppSession.CurrentPosition = ""
        AppSession.CurrentPrivilege = ""
        AppSession.UserId = ""
        LoginForm.txtUserN.Clear()
        LoginForm.txtPass.Clear()
        LoginForm.cbShowPassword.Checked = False

        LoginForm.Show()
        LoginForm.txtUserN.Focus()


        Me.Hide()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshSessionUI()
    End Sub

    Private Sub NormalizeStatusesOnLoad()
        Try
            Using conn As New OleDb.OleDbConnection(DbConfig.GetConnStr())
                conn.Open()
                Using tx = conn.BeginTransaction()
                    Dim updates As String() = {
                        "UPDATE tblBookings SET [Booking Status]='No-show' WHERE [Booking Status] IN ('No Show','NO SHOW','No-Show','NO-SHOW');",
                        "UPDATE tblBookings SET [Booking Status]='Checked In' WHERE [Booking Status] IN ('Checked-In','CHECKED-IN');",
                        "UPDATE tblBookings SET [Booking Status]='Checked Out' WHERE [Booking Status] IN ('Checked-Out','CHECKED-OUT');",
                        "UPDATE tblBookings SET [Booking Status]='Cancelled' WHERE [Booking Status] IN ('Canceled','CANCELED');",
                        "UPDATE tblStays SET [Stay Status]='No-show' WHERE [Stay Status] IN ('No Show','NO SHOW','No-Show','NO-SHOW');",
                        "UPDATE tblStays SET [Stay Status]='Checked In' WHERE [Stay Status] IN ('Checked-In','CHECKED-IN');",
                        "UPDATE tblStays SET [Stay Status]='Checked Out' WHERE [Stay Status] IN ('Checked-Out','CHECKED-OUT');",
                        "UPDATE tblRooms SET [Room Status]='Inactive' WHERE [Room Status] IN ('INACTIVE','inactive');"
                    }
                    For Each sqlStmt In updates
                        Using cmd As New OleDb.OleDbCommand(sqlStmt, conn, tx)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    tx.Commit()
                End Using
            End Using
        Catch ex As Exception
            ' Non-blocking: keep app usable even if normalization fails
        End Try
    End Sub

End Class
