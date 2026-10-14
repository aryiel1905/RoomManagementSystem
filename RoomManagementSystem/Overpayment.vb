Public Partial Class Overpayment
    Inherits Form

    Public Enum OverpaymentAction
        None
        GiveChange
    End Enum

    Private _selectedAction As OverpaymentAction = OverpaymentAction.None

    Public ReadOnly Property SelectedAction As OverpaymentAction
        Get
            Return _selectedAction
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        lblTotalChargeValue.Text = "₱0.00"
        lblCurrentPaidValue.Text = "₱0.00"
        lblThisPaymentValue.Text = "₱0.00"
        lblChangeValue.Text = "₱0.00"
    End Sub

    Public Sub New(totalDue As Decimal, currentPaid As Decimal, paymentEntered As Decimal)
        InitializeComponent()

        Dim newTotal As Decimal = currentPaid + paymentEntered
        Dim changeDue As Decimal = newTotal - totalDue
        If changeDue < 0D Then changeDue = 0D

        lblTotalChargeValue.Text = FormatPeso(totalDue)
        lblCurrentPaidValue.Text = FormatPeso(currentPaid)
        lblThisPaymentValue.Text = FormatPeso(paymentEntered)
        lblChangeValue.Text = FormatPeso(changeDue)
    End Sub

    Private Sub btnGiveChange_Click(sender As Object, e As EventArgs) Handles btnGiveChange.Click
        SetActionAndClose(OverpaymentAction.GiveChange)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub SetActionAndClose(action As OverpaymentAction)
        _selectedAction = action
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Function FormatPeso(value As Decimal) As String
        Return "₱" & value.ToString("N2")
    End Function
End Class
