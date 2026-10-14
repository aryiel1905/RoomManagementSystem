<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Overpayment
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
        Me.lblTotalCharge = New System.Windows.Forms.Label()
        Me.lblCurrentPaid = New System.Windows.Forms.Label()
        Me.lblThisPayment = New System.Windows.Forms.Label()
        Me.lblChangeDue = New System.Windows.Forms.Label()
        Me.lblTotalChargeValue = New System.Windows.Forms.Label()
        Me.lblCurrentPaidValue = New System.Windows.Forms.Label()
        Me.lblThisPaymentValue = New System.Windows.Forms.Label()
        Me.lblChangeValue = New System.Windows.Forms.Label()
        Me.btnGiveChange = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTotalCharge
        '
        Me.lblTotalCharge.AutoSize = True
        Me.lblTotalCharge.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCharge.Location = New System.Drawing.Point(17, 32)
        Me.lblTotalCharge.Name = "lblTotalCharge"
        Me.lblTotalCharge.Size = New System.Drawing.Size(180, 32)
        Me.lblTotalCharge.TabIndex = 1
        Me.lblTotalCharge.Text = "Total Amount:"
        '
        'lblCurrentPaid
        '
        Me.lblCurrentPaid.AutoSize = True
        Me.lblCurrentPaid.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPaid.Location = New System.Drawing.Point(17, 72)
        Me.lblCurrentPaid.Name = "lblCurrentPaid"
        Me.lblCurrentPaid.Size = New System.Drawing.Size(167, 32)
        Me.lblCurrentPaid.TabIndex = 2
        Me.lblCurrentPaid.Text = "Already Paid:"
        '
        'lblThisPayment
        '
        Me.lblThisPayment.AutoSize = True
        Me.lblThisPayment.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThisPayment.Location = New System.Drawing.Point(14, 133)
        Me.lblThisPayment.Name = "lblThisPayment"
        Me.lblThisPayment.Size = New System.Drawing.Size(175, 32)
        Me.lblThisPayment.TabIndex = 3
        Me.lblThisPayment.Text = "This Payment:"
        '
        'lblChangeDue
        '
        Me.lblChangeDue.AutoSize = True
        Me.lblChangeDue.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDue.Location = New System.Drawing.Point(14, 171)
        Me.lblChangeDue.Name = "lblChangeDue"
        Me.lblChangeDue.Size = New System.Drawing.Size(107, 32)
        Me.lblChangeDue.TabIndex = 4
        Me.lblChangeDue.Text = "Change:"
        '
        'lblTotalChargeValue
        '
        Me.lblTotalChargeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalChargeValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalChargeValue.Location = New System.Drawing.Point(226, 32)
        Me.lblTotalChargeValue.Name = "lblTotalChargeValue"
        Me.lblTotalChargeValue.Size = New System.Drawing.Size(170, 29)
        Me.lblTotalChargeValue.TabIndex = 10
        Me.lblTotalChargeValue.Text = "-------------"
        Me.lblTotalChargeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCurrentPaidValue
        '
        Me.lblCurrentPaidValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentPaidValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPaidValue.Location = New System.Drawing.Point(226, 72)
        Me.lblCurrentPaidValue.Name = "lblCurrentPaidValue"
        Me.lblCurrentPaidValue.Size = New System.Drawing.Size(170, 29)
        Me.lblCurrentPaidValue.TabIndex = 11
        Me.lblCurrentPaidValue.Text = "-------------"
        Me.lblCurrentPaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThisPaymentValue
        '
        Me.lblThisPaymentValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblThisPaymentValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThisPaymentValue.Location = New System.Drawing.Point(226, 133)
        Me.lblThisPaymentValue.Name = "lblThisPaymentValue"
        Me.lblThisPaymentValue.Size = New System.Drawing.Size(170, 29)
        Me.lblThisPaymentValue.TabIndex = 12
        Me.lblThisPaymentValue.Text = "-------------"
        Me.lblThisPaymentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChangeValue
        '
        Me.lblChangeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChangeValue.Font = New System.Drawing.Font("Microsoft PhagsPa", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeValue.Location = New System.Drawing.Point(226, 171)
        Me.lblChangeValue.Name = "lblChangeValue"
        Me.lblChangeValue.Size = New System.Drawing.Size(170, 29)
        Me.lblChangeValue.TabIndex = 13
        Me.lblChangeValue.Text = "-------------"
        Me.lblChangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGiveChange
        '
        Me.btnGiveChange.BackColor = System.Drawing.Color.SeaGreen
        Me.btnGiveChange.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGiveChange.ForeColor = System.Drawing.Color.White
        Me.btnGiveChange.Location = New System.Drawing.Point(20, 222)
        Me.btnGiveChange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGiveChange.Name = "btnGiveChange"
        Me.btnGiveChange.Size = New System.Drawing.Size(184, 52)
        Me.btnGiveChange.TabIndex = 4
        Me.btnGiveChange.Text = "Give Change"
        Me.btnGiveChange.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(213, 222)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(184, 52)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Overpayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 296)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGiveChange)
        Me.Controls.Add(Me.lblChangeDue)
        Me.Controls.Add(Me.lblThisPayment)
        Me.Controls.Add(Me.lblCurrentPaid)
        Me.Controls.Add(Me.lblTotalCharge)
        Me.Controls.Add(Me.lblChangeValue)
        Me.Controls.Add(Me.lblThisPaymentValue)
        Me.Controls.Add(Me.lblCurrentPaidValue)
        Me.Controls.Add(Me.lblTotalChargeValue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Overpayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTotalCharge As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPaid As System.Windows.Forms.Label
    Friend WithEvents lblThisPayment As System.Windows.Forms.Label
    Friend WithEvents lblChangeDue As System.Windows.Forms.Label
    Friend WithEvents lblTotalChargeValue As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPaidValue As System.Windows.Forms.Label
    Friend WithEvents lblThisPaymentValue As System.Windows.Forms.Label
    Friend WithEvents lblChangeValue As System.Windows.Forms.Label
    Friend WithEvents btnGiveChange As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

End Class
