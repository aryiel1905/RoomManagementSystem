Partial Public Class LateCheckInDialog
    Public Enum LateCheckInAction
        None
        UpdateReservation
        MarkNoShow
    End Enum

    Private _action As LateCheckInAction = LateCheckInAction.None

    Public ReadOnly Property SelectedAction As LateCheckInAction
        Get
            Return _action
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnUpdateReservation_Click(sender As Object, e As EventArgs) Handles btnUpdateReservation.Click
        _action = LateCheckInAction.UpdateReservation
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnMarkNoShow_Click(sender As Object, e As EventArgs) Handles btnMarkNoShow.Click
        _action = LateCheckInAction.MarkNoShow
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _action = LateCheckInAction.None
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class
