Partial Public Class OverstayDialog
    Public Enum OverstayAction
        None
        CheckOut
        Extend
    End Enum

    Private _action As OverstayAction = OverstayAction.None

    Public ReadOnly Property SelectedAction As OverstayAction
        Get
            Return _action
        End Get
    End Property

    Public ReadOnly Property NewCheckoutDate As Date
        Get
            Return dtpNewCheckout.Value.Date
        End Get
    End Property

    Public Sub New(currentCheckout As Date)
        InitializeComponent()
        dtpNewCheckout.Value = currentCheckout
        dtpNewCheckout.MinDate = Date.Today.AddDays(1)
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        _action = OverstayAction.CheckOut
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnExtend_Click(sender As Object, e As EventArgs) Handles btnExtend.Click
        _action = OverstayAction.Extend
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _action = OverstayAction.None
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub OverstayDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
