<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverstayDialog
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblNewCheckout = New System.Windows.Forms.Label()
        Me.dtpNewCheckout = New System.Windows.Forms.DateTimePicker()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnExtend = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(24, 18)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(547, 42)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Stay is past check-out date. Choose an action."
        '
        'lblNewCheckout
        '
        Me.lblNewCheckout.AutoSize = True
        Me.lblNewCheckout.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCheckout.Location = New System.Drawing.Point(24, 80)
        Me.lblNewCheckout.Name = "lblNewCheckout"
        Me.lblNewCheckout.Size = New System.Drawing.Size(180, 28)
        Me.lblNewCheckout.TabIndex = 1
        Me.lblNewCheckout.Text = "NEW CHECK OUT:"
        '
        'dtpNewCheckout
        '
        Me.dtpNewCheckout.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNewCheckout.Location = New System.Drawing.Point(233, 75)
        Me.dtpNewCheckout.Name = "dtpNewCheckout"
        Me.dtpNewCheckout.Size = New System.Drawing.Size(338, 34)
        Me.dtpNewCheckout.TabIndex = 2
        '
        'btnCheckOut
        '
        Me.btnCheckOut.BackColor = System.Drawing.Color.Firebrick
        Me.btnCheckOut.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckOut.Location = New System.Drawing.Point(24, 135)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(163, 52)
        Me.btnCheckOut.TabIndex = 3
        Me.btnCheckOut.Text = "Check Out"
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'btnExtend
        '
        Me.btnExtend.BackColor = System.Drawing.Color.Teal
        Me.btnExtend.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtend.ForeColor = System.Drawing.Color.White
        Me.btnExtend.Location = New System.Drawing.Point(197, 135)
        Me.btnExtend.Name = "btnExtend"
        Me.btnExtend.Size = New System.Drawing.Size(182, 52)
        Me.btnExtend.TabIndex = 4
        Me.btnExtend.Text = "Extend Stay"
        Me.btnExtend.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(389, 135)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(182, 52)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OverstayDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 217)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExtend)
        Me.Controls.Add(Me.btnCheckOut)
        Me.Controls.Add(Me.dtpNewCheckout)
        Me.Controls.Add(Me.lblNewCheckout)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OverstayDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Overstay "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents lblNewCheckout As Label
    Friend WithEvents dtpNewCheckout As DateTimePicker
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnExtend As Button
    Friend WithEvents btnCancel As Button
End Class
