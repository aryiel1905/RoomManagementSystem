<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RefundModal
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblResNo = New System.Windows.Forms.Label()
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.lblResNoValue = New System.Windows.Forms.Label()
        Me.lblGuestNameValue = New System.Windows.Forms.Label()
        Me.lblStatusValue = New System.Windows.Forms.Label()
        Me.lblTotalPaidValue = New System.Windows.Forms.Label()
        Me.lblTotalRefunded = New System.Windows.Forms.Label()
        Me.lblTotalRefundedValue = New System.Windows.Forms.Label()
        Me.lblRefundable = New System.Windows.Forms.Label()
        Me.lblRefundableValue = New System.Windows.Forms.Label()
        Me.lblRefundPercent = New System.Windows.Forms.Label()
        Me.cboRefundPercent = New System.Windows.Forms.ComboBox()
        Me.lblRefundAmount = New System.Windows.Forms.Label()
        Me.lblRefundAmountValue = New System.Windows.Forms.Label()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblResNo
        '
        Me.lblResNo.AutoSize = True
        Me.lblResNo.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResNo.Location = New System.Drawing.Point(25, 21)
        Me.lblResNo.Name = "lblResNo"
        Me.lblResNo.Size = New System.Drawing.Size(84, 26)
        Me.lblResNo.TabIndex = 1
        Me.lblResNo.Text = "Res No:"
        '
        'lblGuestName
        '
        Me.lblGuestName.AutoSize = True
        Me.lblGuestName.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuestName.Location = New System.Drawing.Point(25, 53)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.Size = New System.Drawing.Size(71, 26)
        Me.lblGuestName.TabIndex = 2
        Me.lblGuestName.Text = "Guest:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(25, 85)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(76, 26)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status:"
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.AutoSize = True
        Me.lblTotalPaid.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.Location = New System.Drawing.Point(25, 134)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Size = New System.Drawing.Size(113, 26)
        Me.lblTotalPaid.TabIndex = 4
        Me.lblTotalPaid.Text = "Total Paid:"
        '
        'lblResNoValue
        '
        Me.lblResNoValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblResNoValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResNoValue.Location = New System.Drawing.Point(228, 18)
        Me.lblResNoValue.Name = "lblResNoValue"
        Me.lblResNoValue.Size = New System.Drawing.Size(173, 29)
        Me.lblResNoValue.TabIndex = 15
        Me.lblResNoValue.Text = "------"
        Me.lblResNoValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGuestNameValue
        '
        Me.lblGuestNameValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblGuestNameValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuestNameValue.Location = New System.Drawing.Point(228, 50)
        Me.lblGuestNameValue.Name = "lblGuestNameValue"
        Me.lblGuestNameValue.Size = New System.Drawing.Size(173, 29)
        Me.lblGuestNameValue.TabIndex = 16
        Me.lblGuestNameValue.Text = "--------"
        Me.lblGuestNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStatusValue
        '
        Me.lblStatusValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblStatusValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusValue.Location = New System.Drawing.Point(228, 82)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(173, 29)
        Me.lblStatusValue.TabIndex = 17
        Me.lblStatusValue.Text = "--------"
        Me.lblStatusValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPaidValue
        '
        Me.lblTotalPaidValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotalPaidValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaidValue.Location = New System.Drawing.Point(228, 134)
        Me.lblTotalPaidValue.Name = "lblTotalPaidValue"
        Me.lblTotalPaidValue.Size = New System.Drawing.Size(173, 29)
        Me.lblTotalPaidValue.TabIndex = 18
        Me.lblTotalPaidValue.Text = "₱0.00"
        Me.lblTotalPaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalRefunded
        '
        Me.lblTotalRefunded.AutoSize = True
        Me.lblTotalRefunded.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRefunded.Location = New System.Drawing.Point(25, 168)
        Me.lblTotalRefunded.Name = "lblTotalRefunded"
        Me.lblTotalRefunded.Size = New System.Drawing.Size(163, 26)
        Me.lblTotalRefunded.TabIndex = 5
        Me.lblTotalRefunded.Text = "Total Refunded:"
        '
        'lblTotalRefundedValue
        '
        Me.lblTotalRefundedValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotalRefundedValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRefundedValue.Location = New System.Drawing.Point(278, 168)
        Me.lblTotalRefundedValue.Name = "lblTotalRefundedValue"
        Me.lblTotalRefundedValue.Size = New System.Drawing.Size(123, 26)
        Me.lblTotalRefundedValue.TabIndex = 19
        Me.lblTotalRefundedValue.Text = "₱0.00"
        Me.lblTotalRefundedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRefundable
        '
        Me.lblRefundable.AutoSize = True
        Me.lblRefundable.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundable.Location = New System.Drawing.Point(25, 202)
        Me.lblRefundable.Name = "lblRefundable"
        Me.lblRefundable.Size = New System.Drawing.Size(125, 26)
        Me.lblRefundable.TabIndex = 6
        Me.lblRefundable.Text = "Refundable:"
        '
        'lblRefundableValue
        '
        Me.lblRefundableValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblRefundableValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundableValue.Location = New System.Drawing.Point(278, 202)
        Me.lblRefundableValue.Name = "lblRefundableValue"
        Me.lblRefundableValue.Size = New System.Drawing.Size(123, 26)
        Me.lblRefundableValue.TabIndex = 20
        Me.lblRefundableValue.Text = "₱0.00"
        Me.lblRefundableValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRefundPercent
        '
        Me.lblRefundPercent.AutoSize = True
        Me.lblRefundPercent.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundPercent.Location = New System.Drawing.Point(25, 236)
        Me.lblRefundPercent.Name = "lblRefundPercent"
        Me.lblRefundPercent.Size = New System.Drawing.Size(103, 26)
        Me.lblRefundPercent.TabIndex = 7
        Me.lblRefundPercent.Text = "Refund %"
        '
        'cboRefundPercent
        '
        Me.cboRefundPercent.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cboRefundPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefundPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRefundPercent.FormattingEnabled = True
        Me.cboRefundPercent.Location = New System.Drawing.Point(280, 234)
        Me.cboRefundPercent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboRefundPercent.Name = "cboRefundPercent"
        Me.cboRefundPercent.Size = New System.Drawing.Size(121, 28)
        Me.cboRefundPercent.TabIndex = 8
        '
        'lblRefundAmount
        '
        Me.lblRefundAmount.AutoSize = True
        Me.lblRefundAmount.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundAmount.Location = New System.Drawing.Point(25, 272)
        Me.lblRefundAmount.Name = "lblRefundAmount"
        Me.lblRefundAmount.Size = New System.Drawing.Size(162, 26)
        Me.lblRefundAmount.TabIndex = 9
        Me.lblRefundAmount.Text = "Refund Amount"
        '
        'lblRefundAmountValue
        '
        Me.lblRefundAmountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRefundAmountValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundAmountValue.Location = New System.Drawing.Point(300, 272)
        Me.lblRefundAmountValue.Name = "lblRefundAmountValue"
        Me.lblRefundAmountValue.Size = New System.Drawing.Size(101, 26)
        Me.lblRefundAmountValue.TabIndex = 10
        Me.lblRefundAmountValue.Text = "₱0.00"
        Me.lblRefundAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReason.Location = New System.Drawing.Point(25, 320)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(80, 26)
        Me.lblReason.TabIndex = 11
        Me.lblReason.Text = "Reason"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(28, 348)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(373, 65)
        Me.txtReason.TabIndex = 12
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.SeaGreen
        Me.btnConfirm.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.ForeColor = System.Drawing.Color.White
        Me.btnConfirm.Location = New System.Drawing.Point(27, 428)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(184, 52)
        Me.btnConfirm.TabIndex = 13
        Me.btnConfirm.Text = "Confirm Refund"
        Me.btnConfirm.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(217, 428)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(184, 52)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'RefundModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 511)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.lblRefundAmountValue)
        Me.Controls.Add(Me.lblRefundAmount)
        Me.Controls.Add(Me.cboRefundPercent)
        Me.Controls.Add(Me.lblRefundPercent)
        Me.Controls.Add(Me.lblRefundableValue)
        Me.Controls.Add(Me.lblRefundable)
        Me.Controls.Add(Me.lblTotalRefundedValue)
        Me.Controls.Add(Me.lblTotalRefunded)
        Me.Controls.Add(Me.lblTotalPaidValue)
        Me.Controls.Add(Me.lblTotalPaid)
        Me.Controls.Add(Me.lblStatusValue)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblGuestNameValue)
        Me.Controls.Add(Me.lblGuestName)
        Me.Controls.Add(Me.lblResNoValue)
        Me.Controls.Add(Me.lblResNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RefundModal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Refund"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblResNo As System.Windows.Forms.Label
    Friend WithEvents lblGuestName As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblTotalPaid As System.Windows.Forms.Label
    Friend WithEvents lblResNoValue As System.Windows.Forms.Label
    Friend WithEvents lblGuestNameValue As System.Windows.Forms.Label
    Friend WithEvents lblStatusValue As System.Windows.Forms.Label
    Friend WithEvents lblTotalPaidValue As System.Windows.Forms.Label
    Friend WithEvents lblTotalRefunded As System.Windows.Forms.Label
    Friend WithEvents lblTotalRefundedValue As System.Windows.Forms.Label
    Friend WithEvents lblRefundable As System.Windows.Forms.Label
    Friend WithEvents lblRefundableValue As System.Windows.Forms.Label
    Friend WithEvents lblRefundPercent As System.Windows.Forms.Label
    Friend WithEvents cboRefundPercent As System.Windows.Forms.ComboBox
    Friend WithEvents lblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents lblRefundAmountValue As System.Windows.Forms.Label
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

End Class
