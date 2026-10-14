<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pbRooms = New System.Windows.Forms.PictureBox()
        Me.btnUserForm = New System.Windows.Forms.Button()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblPrivilegeUN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRoom = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnGuestLookup = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.btnAmenities = New System.Windows.Forms.Button()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbRooms
        '
        Me.pbRooms.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbRooms.BackColor = System.Drawing.Color.Transparent
        Me.pbRooms.Image = CType(resources.GetObject("pbRooms.Image"), System.Drawing.Image)
        Me.pbRooms.Location = New System.Drawing.Point(927, 107)
        Me.pbRooms.Name = "pbRooms"
        Me.pbRooms.Size = New System.Drawing.Size(286, 286)
        Me.pbRooms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRooms.TabIndex = 9
        Me.pbRooms.TabStop = False
        '
        'btnUserForm
        '
        Me.btnUserForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUserForm.BackColor = System.Drawing.Color.Teal
        Me.btnUserForm.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnUserForm.FlatAppearance.BorderSize = 3
        Me.btnUserForm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUserForm.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserForm.ForeColor = System.Drawing.Color.Azure
        Me.btnUserForm.Location = New System.Drawing.Point(927, 408)
        Me.btnUserForm.Name = "btnUserForm"
        Me.btnUserForm.Size = New System.Drawing.Size(286, 65)
        Me.btnUserForm.TabIndex = 13
        Me.btnUserForm.Text = "User Form"
        Me.btnUserForm.UseVisualStyleBackColor = False
        '
        'btnReservation
        '
        Me.btnReservation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReservation.BackColor = System.Drawing.Color.Teal
        Me.btnReservation.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnReservation.FlatAppearance.BorderSize = 3
        Me.btnReservation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReservation.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReservation.ForeColor = System.Drawing.Color.Azure
        Me.btnReservation.Location = New System.Drawing.Point(617, 790)
        Me.btnReservation.Name = "btnReservation"
        Me.btnReservation.Size = New System.Drawing.Size(286, 65)
        Me.btnReservation.TabIndex = 14
        Me.btnReservation.Text = "Reservation"
        Me.btnReservation.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Teal
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.mnuRefresh})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.MenuToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.MenuToolStripMenuItem.Image = CType(resources.GetObject("MenuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(80, 34)
        Me.MenuToolStripMenuItem.Text = "File"
        '
        'mnuExit
        '
        Me.mnuExit.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuExit.Size = New System.Drawing.Size(245, 30)
        Me.mnuExit.Text = "Exit"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuRefresh.Checked = True
        Me.mnuRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRefresh.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuRefresh.ForeColor = System.Drawing.SystemColors.Control
        Me.mnuRefresh.Image = CType(resources.GetObject("mnuRefresh.Image"), System.Drawing.Image)
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Padding = New System.Windows.Forms.Padding(5, 0, 4, 0)
        Me.mnuRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mnuRefresh.Size = New System.Drawing.Size(33, 34)
        '
        'lblPrivilegeUN
        '
        Me.lblPrivilegeUN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPrivilegeUN.BackColor = System.Drawing.Color.Transparent
        Me.lblPrivilegeUN.Font = New System.Drawing.Font("Microsoft PhagsPa", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrivilegeUN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPrivilegeUN.Location = New System.Drawing.Point(108, 604)
        Me.lblPrivilegeUN.Name = "lblPrivilegeUN"
        Me.lblPrivilegeUN.Size = New System.Drawing.Size(478, 189)
        Me.lblPrivilegeUN.TabIndex = 20
        Me.lblPrivilegeUN.Text = "--------------"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(108, 525)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 79)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Welcome,"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRoom
        '
        Me.btnRoom.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRoom.BackColor = System.Drawing.Color.Teal
        Me.btnRoom.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnRoom.FlatAppearance.BorderSize = 3
        Me.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRoom.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoom.ForeColor = System.Drawing.Color.Azure
        Me.btnRoom.Location = New System.Drawing.Point(617, 408)
        Me.btnRoom.Name = "btnRoom"
        Me.btnRoom.Size = New System.Drawing.Size(286, 65)
        Me.btnRoom.TabIndex = 26
        Me.btnRoom.Text = "Rooms"
        Me.btnRoom.UseVisualStyleBackColor = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(617, 107)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 27
        Me.PictureBox6.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(1238, 107)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'btnGuestLookup
        '
        Me.btnGuestLookup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuestLookup.BackColor = System.Drawing.Color.Teal
        Me.btnGuestLookup.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnGuestLookup.FlatAppearance.BorderSize = 3
        Me.btnGuestLookup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGuestLookup.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuestLookup.ForeColor = System.Drawing.Color.Azure
        Me.btnGuestLookup.Location = New System.Drawing.Point(927, 790)
        Me.btnGuestLookup.Name = "btnGuestLookup"
        Me.btnGuestLookup.Size = New System.Drawing.Size(286, 65)
        Me.btnGuestLookup.TabIndex = 30
        Me.btnGuestLookup.Text = "Guest Lookup"
        Me.btnGuestLookup.UseVisualStyleBackColor = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCheckOut.BackColor = System.Drawing.Color.Teal
        Me.btnCheckOut.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnCheckOut.FlatAppearance.BorderSize = 3
        Me.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCheckOut.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.ForeColor = System.Drawing.Color.Azure
        Me.btnCheckOut.Location = New System.Drawing.Point(1549, 790)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(286, 65)
        Me.btnCheckOut.TabIndex = 29
        Me.btnCheckOut.Text = "Checking Out"
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1549, 489)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 28
        Me.PictureBox3.TabStop = False
        '
        'btnReports
        '
        Me.btnReports.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReports.BackColor = System.Drawing.Color.Teal
        Me.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnReports.FlatAppearance.BorderSize = 3
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.Azure
        Me.btnReports.Location = New System.Drawing.Point(1549, 408)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(286, 65)
        Me.btnReports.TabIndex = 33
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(1549, 107)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 32
        Me.PictureBox7.TabStop = False
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnHistory.BackColor = System.Drawing.Color.Teal
        Me.btnHistory.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnHistory.FlatAppearance.BorderSize = 3
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHistory.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.ForeColor = System.Drawing.Color.Azure
        Me.btnHistory.Location = New System.Drawing.Point(1238, 408)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(286, 65)
        Me.btnHistory.TabIndex = 37
        Me.btnHistory.Text = "History"
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(1238, 489)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 36
        Me.PictureBox8.TabStop = False
        '
        'btnAmenities
        '
        Me.btnAmenities.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAmenities.BackColor = System.Drawing.Color.Teal
        Me.btnAmenities.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnAmenities.FlatAppearance.BorderSize = 3
        Me.btnAmenities.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAmenities.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAmenities.ForeColor = System.Drawing.Color.Azure
        Me.btnAmenities.Location = New System.Drawing.Point(1238, 790)
        Me.btnAmenities.Name = "btnAmenities"
        Me.btnAmenities.Size = New System.Drawing.Size(286, 65)
        Me.btnAmenities.TabIndex = 39
        Me.btnAmenities.Text = "Amenities"
        Me.btnAmenities.UseVisualStyleBackColor = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Location = New System.Drawing.Point(927, 489)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 38
        Me.PictureBox9.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(76, 187)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(510, 286)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 40
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(617, 489)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(286, 286)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 970)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.btnAmenities)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnGuestLookup)
        Me.Controls.Add(Me.btnCheckOut)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.lblPrivilegeUN)
        Me.Controls.Add(Me.btnRoom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnReservation)
        Me.Controls.Add(Me.btnUserForm)
        Me.Controls.Add(Me.pbRooms)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbRooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbRooms As PictureBox
    Friend WithEvents btnUserForm As Button
    Friend WithEvents btnReservation As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuRefresh As ToolStripMenuItem
    Friend WithEvents lblPrivilegeUN As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRoom As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnGuestLookup As Button
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnReports As Button
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents btnHistory As Button
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents btnAmenities As Button
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
