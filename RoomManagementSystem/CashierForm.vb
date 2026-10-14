Public Class CashierForm
    Private ReadOnly _totalAmount As Decimal
    Private _amountPaid As Decimal = 0D
    Private _changeDue As Decimal = 0D

    Public ReadOnly Property AmountPaid As Decimal
        Get
            Return _amountPaid
        End Get
    End Property

    Public ReadOnly Property ChangeDue As Decimal
        Get
            Return _changeDue
        End Get
    End Property

    Public Sub New(totalAmount As Decimal)
        InitializeComponent()
        _totalAmount = totalAmount
    End Sub

    Private Sub CashierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalAmount.Text = _totalAmount.ToString("₱#,##0.00")
        txtAmountPaid.Text = _totalAmount.ToString("₱#,##0.00")
        UpdateChangePreview()
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        UpdateChangePreview()
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim amountPaid = ParseAmount(txtAmountPaid.Text)

        If amountPaid < _totalAmount Then
            MessageBox.Show("Amount paid is less than the total.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim changeDue = amountPaid - _totalAmount
        SetResultAndClose(amountPaid, changeDue)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub UpdateChangePreview()
        Dim amountPaid = ParseAmount(txtAmountPaid.Text)
        Dim changeDue = Math.Max(0D, amountPaid - _totalAmount)
        lblChangeAmount.Text = changeDue.ToString("₱#,##0.00")
    End Sub

    Private Function ParseAmount(text As String) As Decimal
        Dim result As Decimal = 0D
        Decimal.TryParse(text.Replace("₱", "").Trim(), result)
        Return result
    End Function

    Private Sub SetResultAndClose(paid As Decimal, changeDue As Decimal)
        _amountPaid = paid
        _changeDue = changeDue
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class
