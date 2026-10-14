<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LateCheckInDialog
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
        Me.btnUpdateReservation = New System.Windows.Forms.Button()
        Me.btnMarkNoShow = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(24, 37)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(631, 80)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "This reservation is already past its check-in date. Choose an action."
        '
        'btnUpdateReservation
        '
        Me.btnUpdateReservation.BackColor = System.Drawing.Color.Teal
        Me.btnUpdateReservation.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateReservation.ForeColor = System.Drawing.Color.White
        Me.btnUpdateReservation.Location = New System.Drawing.Point(24, 120)
        Me.btnUpdateReservation.Name = "btnUpdateReservation"
        Me.btnUpdateReservation.Size = New System.Drawing.Size(231, 52)
        Me.btnUpdateReservation.TabIndex = 1
        Me.btnUpdateReservation.Text = "Update Reservation"
        Me.btnUpdateReservation.UseVisualStyleBackColor = False
        '
        'btnMarkNoShow
        '
        Me.btnMarkNoShow.BackColor = System.Drawing.Color.Firebrick
        Me.btnMarkNoShow.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarkNoShow.ForeColor = System.Drawing.Color.White
        Me.btnMarkNoShow.Location = New System.Drawing.Point(273, 120)
        Me.btnMarkNoShow.Name = "btnMarkNoShow"
        Me.btnMarkNoShow.Size = New System.Drawing.Size(182, 52)
        Me.btnMarkNoShow.TabIndex = 2
        Me.btnMarkNoShow.Text = "Mark No-show"
        Me.btnMarkNoShow.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(473, 120)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(182, 52)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'LateCheckInDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 197)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnMarkNoShow)
        Me.Controls.Add(Me.btnUpdateReservation)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LateCheckInDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Late Check-In"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents btnUpdateReservation As Button
    Friend WithEvents btnMarkNoShow As Button
    Friend WithEvents btnCancel As Button
End Class
