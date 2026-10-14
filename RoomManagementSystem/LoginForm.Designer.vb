<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.txtUserN = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cbShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.pbRooms = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUserN
        '
        Me.txtUserN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUserN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserN.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserN.Location = New System.Drawing.Point(810, 504)
        Me.txtUserN.Name = "txtUserN"
        Me.txtUserN.Size = New System.Drawing.Size(380, 45)
        Me.txtUserN.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnClose.FlatAppearance.BorderSize = 3
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Teal
        Me.btnClose.Location = New System.Drawing.Point(810, 777)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(380, 55)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cbShowPassword
        '
        Me.cbShowPassword.AutoSize = True
        Me.cbShowPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cbShowPassword.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowPassword.ForeColor = System.Drawing.Color.Teal
        Me.cbShowPassword.Location = New System.Drawing.Point(810, 657)
        Me.cbShowPassword.Name = "cbShowPassword"
        Me.cbShowPassword.Size = New System.Drawing.Size(173, 29)
        Me.cbShowPassword.TabIndex = 3
        Me.cbShowPassword.Text = "Show Password"
        Me.cbShowPassword.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.Teal
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnLogin.FlatAppearance.BorderSize = 3
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.Azure
        Me.btnLogin.Location = New System.Drawing.Point(810, 694)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(380, 68)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Log In"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(805, 568)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 26)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Password:"
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRoomNo.AutoSize = True
        Me.lblRoomNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.lblRoomNo.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoomNo.ForeColor = System.Drawing.Color.Teal
        Me.lblRoomNo.Location = New System.Drawing.Point(805, 475)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(121, 26)
        Me.lblRoomNo.TabIndex = 15
        Me.lblRoomNo.Text = "User Name:"
        '
        'txtPass
        '
        Me.txtPass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(810, 597)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(380, 45)
        Me.txtPass.TabIndex = 2
        '
        'pbRooms
        '
        Me.pbRooms.BackColor = System.Drawing.Color.Transparent
        Me.pbRooms.BackgroundImage = CType(resources.GetObject("pbRooms.BackgroundImage"), System.Drawing.Image)
        Me.pbRooms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbRooms.Location = New System.Drawing.Point(674, 43)
        Me.pbRooms.Name = "pbRooms"
        Me.pbRooms.Size = New System.Drawing.Size(657, 371)
        Me.pbRooms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRooms.TabIndex = 13
        Me.pbRooms.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(753, 420)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(492, 470)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cbShowPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRoomNo)
        Me.Controls.Add(Me.txtUserN)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.pbRooms)
        Me.Controls.Add(Me.PictureBox2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Name = "LoginForm"
        Me.Text = "LoginForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUserN As TextBox
    Friend WithEvents lblRoomNo As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents pbRooms As PictureBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbShowPassword As CheckBox
    Friend WithEvents btnClose As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
