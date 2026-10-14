<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashierForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTotalLabel = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblAmountLabel = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.lblChangeLabel = New System.Windows.Forms.Label()
        Me.lblChangeAmount = New System.Windows.Forms.Label()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTotalLabel
        '
        Me.lblTotalLabel.AutoSize = True
        Me.lblTotalLabel.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLabel.Location = New System.Drawing.Point(28, 24)
        Me.lblTotalLabel.Name = "lblTotalLabel"
        Me.lblTotalLabel.Size = New System.Drawing.Size(153, 37)
        Me.lblTotalLabel.TabIndex = 0
        Me.lblTotalLabel.Text = "Total Due:"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Teal
        Me.lblTotalAmount.Location = New System.Drawing.Point(366, 24)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(228, 37)
        Me.lblTotalAmount.TabIndex = 1
        Me.lblTotalAmount.Text = "₱0.00"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmountLabel
        '
        Me.lblAmountLabel.AutoSize = True
        Me.lblAmountLabel.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountLabel.Location = New System.Drawing.Point(30, 96)
        Me.lblAmountLabel.Name = "lblAmountLabel"
        Me.lblAmountLabel.Size = New System.Drawing.Size(171, 32)
        Me.lblAmountLabel.TabIndex = 4
        Me.lblAmountLabel.Text = "Amount Paid:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.Location = New System.Drawing.Point(380, 90)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.Size = New System.Drawing.Size(214, 38)
        Me.txtAmountPaid.TabIndex = 5
        Me.txtAmountPaid.Text = "₱0.00"
        Me.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChangeLabel
        '
        Me.lblChangeLabel.AutoSize = True
        Me.lblChangeLabel.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeLabel.Location = New System.Drawing.Point(30, 139)
        Me.lblChangeLabel.Name = "lblChangeLabel"
        Me.lblChangeLabel.Size = New System.Drawing.Size(107, 32)
        Me.lblChangeLabel.TabIndex = 6
        Me.lblChangeLabel.Text = "Change:"
        '
        'lblChangeAmount
        '
        Me.lblChangeAmount.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeAmount.Location = New System.Drawing.Point(380, 137)
        Me.lblChangeAmount.Name = "lblChangeAmount"
        Me.lblChangeAmount.Size = New System.Drawing.Size(214, 30)
        Me.lblChangeAmount.TabIndex = 7
        Me.lblChangeAmount.Text = "₱0.00"
        Me.lblChangeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPay
        '
        Me.btnPay.BackColor = System.Drawing.Color.Teal
        Me.btnPay.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Location = New System.Drawing.Point(35, 195)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(278, 49)
        Me.btnPay.TabIndex = 10
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(334, 195)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(260, 49)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'CashierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 276)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.lblChangeAmount)
        Me.Controls.Add(Me.lblChangeLabel)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.lblAmountLabel)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.lblTotalLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "CashierForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotalLabel As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblAmountLabel As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents lblChangeLabel As Label
    Friend WithEvents lblChangeAmount As Label
    Friend WithEvents btnPay As Button
    Friend WithEvents btnCancel As Button
End Class
