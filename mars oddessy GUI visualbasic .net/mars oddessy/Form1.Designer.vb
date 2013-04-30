<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton8 = New System.Windows.Forms.RadioButton
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button19 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(137, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Default Controls"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 544)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 174)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "From"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(39, 130)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "Mars"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(39, 96)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Moon"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(39, 59)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(106, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Washington D.C."
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(39, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(53, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Nepal"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.RadioButton7)
        Me.GroupBox2.Controls.Add(Me.RadioButton8)
        Me.GroupBox2.Location = New System.Drawing.Point(267, 544)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 174)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "To"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(54, 130)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.Text = "Mars"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(54, 96)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton6.TabIndex = 6
        Me.RadioButton6.Text = "Moon"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(54, 59)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(106, 17)
        Me.RadioButton7.TabIndex = 5
        Me.RadioButton7.Text = "Washington D.C."
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Checked = True
        Me.RadioButton8.Location = New System.Drawing.Point(54, 25)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(53, 17)
        Me.RadioButton8.TabIndex = 4
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "Nepal"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(632, 127)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(514, 371)
        Me.ListView1.TabIndex = 15
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.rules
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(1093, 333)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(170, 208)
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.Timon
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(822, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(153, 125)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.Start_Engine_page_001
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(770, 533)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(246, 185)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Button19
        '
        Me.Button19.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.reverse_left1
        Me.Button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button19.Location = New System.Drawing.Point(149, 321)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(112, 102)
        Me.Button19.TabIndex = 7
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.reverse_left1
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.Location = New System.Drawing.Point(149, 321)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(112, 102)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Reverse Left"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.reverse_left___Copy
        Me.Button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button18.Location = New System.Drawing.Point(399, 321)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(109, 102)
        Me.Button18.TabIndex = 9
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.reverse_left___Copy
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button9.Location = New System.Drawing.Point(399, 321)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(109, 102)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Reverse Right"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_back
        Me.Button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button17.Location = New System.Drawing.Point(287, 375)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(80, 162)
        Me.Button17.TabIndex = 8
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_right
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button16.Location = New System.Drawing.Point(399, 237)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(158, 78)
        Me.Button16.TabIndex = 6
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_back
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button8.Location = New System.Drawing.Point(287, 375)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 162)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "Back"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.stop1
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button15.Location = New System.Drawing.Point(267, 195)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(126, 174)
        Me.Button15.TabIndex = 5
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_right
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.Location = New System.Drawing.Point(399, 237)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(158, 78)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Right"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.sideleft
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button14.Location = New System.Drawing.Point(106, 237)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(155, 78)
        Me.Button14.TabIndex = 4
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.stop1
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button5.Location = New System.Drawing.Point(267, 195)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(126, 174)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Stop"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side___Copy
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button13.Location = New System.Drawing.Point(399, 157)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(158, 74)
        Me.Button13.TabIndex = 3
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.sideleft
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.Location = New System.Drawing.Point(106, 237)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 78)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Left"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_up
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button12.Location = New System.Drawing.Point(287, 31)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(78, 158)
        Me.Button12.TabIndex = 2
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side___Copy
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(399, 157)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(158, 74)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Sharp Right"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button11.Location = New System.Drawing.Point(103, 157)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(158, 74)
        Me.Button11.TabIndex = 1
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side_up
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(287, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 158)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Forward"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.mars_oddessy.My.Resources.Resources.side
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(103, 157)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 74)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gold
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 778)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox

End Class
