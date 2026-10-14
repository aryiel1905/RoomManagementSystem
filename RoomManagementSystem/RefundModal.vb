Public Partial Class RefundModal
    Inherits Form

    Private _bookingId As Integer
    Private _refundable As Decimal

    Public ReadOnly Property RefundAmount As Decimal
        Get
            Dim v As Decimal = 0D
            Decimal.TryParse(lblRefundAmountValue.Text.Replace("₱", "").Replace(",", "").Trim(), v)
            Return v
        End Get
    End Property

    Public ReadOnly Property ReasonText As String
        Get
            Return txtReason.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property BookingId As Integer
        Get
            Return _bookingId
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        LoadPercentOptions()
    End Sub

    Public Sub New(bookingId As Integer, resNo As String, guestName As String, status As String, totalPaid As Decimal, totalRefunded As Decimal)
        InitializeComponent()
        LoadPercentOptions()

        _bookingId = bookingId
        _refundable = totalPaid - totalRefunded
        If _refundable < 0D Then _refundable = 0D

        lblResNoValue.Text = resNo
        lblGuestNameValue.Text = guestName
        lblStatusValue.Text = status
        lblTotalPaidValue.Text = FormatPeso(totalPaid)
        lblTotalRefundedValue.Text = FormatPeso(totalRefunded)
        lblRefundableValue.Text = FormatPeso(_refundable)

        cboRefundPercent.SelectedIndex = 3 ' 100%
        UpdateRefundAmount()
    End Sub

    Private Sub LoadPercentOptions()
        cboRefundPercent.Items.Clear()
        cboRefundPercent.Items.Add("25%")
        cboRefundPercent.Items.Add("50%")
        cboRefundPercent.Items.Add("75%")
        cboRefundPercent.Items.Add("100%")
    End Sub

    Private Sub cboRefundPercent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRefundPercent.SelectedIndexChanged
        UpdateRefundAmount()
    End Sub

    Private Sub UpdateRefundAmount()
        If _refundable <= 0D Then
            lblRefundAmountValue.Text = "₱0.00"
            Return
        End If

        Dim pct As Decimal = 1D
        Dim s As String = If(cboRefundPercent.SelectedItem, "100%")
        s = s.Replace("%", "").Trim()
        Dim i As Integer = 100
        Integer.TryParse(s, i)
        pct = i / 100D

        Dim amt As Decimal = _refundable * pct
        lblRefundAmountValue.Text = FormatPeso(amt)
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If _refundable <= 0D Then
            MessageBox.Show("No refundable amount available.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim amt As Decimal = RefundAmount
        If amt <= 0D OrElse amt > _refundable Then
            MessageBox.Show("Invalid refund amount.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If ReasonText = "" Then
            MessageBox.Show("Reason is required.", "Refund", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtReason.Focus()
            Return
        End If

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Function FormatPeso(value As Decimal) As String
        Return "₱" & value.ToString("N2")
    End Function
End Class
