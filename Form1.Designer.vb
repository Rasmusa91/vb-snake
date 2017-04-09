<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.GameLoop = New System.Windows.Forms.Timer(Me.components)
        Me.mainGroupBox = New System.Windows.Forms.GroupBox()
        Me.startButton = New System.Windows.Forms.Button()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.endScreenGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.endScreenScoreLabel = New System.Windows.Forms.Label()
        Me.returnButton = New System.Windows.Forms.Button()
        Me.restartButton = New System.Windows.Forms.Button()
        Me.mainGroupBox.SuspendLayout()
        Me.endScreenGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GameLoop
        '
        Me.GameLoop.Enabled = True
        Me.GameLoop.Interval = 33
        '
        'mainGroupBox
        '
        Me.mainGroupBox.Controls.Add(Me.Label4)
        Me.mainGroupBox.Controls.Add(Me.Label3)
        Me.mainGroupBox.Controls.Add(Me.Label2)
        Me.mainGroupBox.Controls.Add(Me.Label1)
        Me.mainGroupBox.Controls.Add(Me.exitButton)
        Me.mainGroupBox.Controls.Add(Me.startButton)
        Me.mainGroupBox.Location = New System.Drawing.Point(228, 256)
        Me.mainGroupBox.Name = "mainGroupBox"
        Me.mainGroupBox.Size = New System.Drawing.Size(224, 154)
        Me.mainGroupBox.TabIndex = 0
        Me.mainGroupBox.TabStop = False
        Me.mainGroupBox.Text = "Snake"
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(9, 19)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(209, 26)
        Me.startButton.TabIndex = 0
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(9, 51)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(209, 26)
        Me.exitButton.TabIndex = 1
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(52, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Arrows on the keyboard or WASD"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 43)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "                  Move Snake around the map and collect as much food as you can (" & _
    "watch out for the walls and your tail!)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Controls"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Objective"
        '
        'endScreenGroupBox
        '
        Me.endScreenGroupBox.Controls.Add(Me.restartButton)
        Me.endScreenGroupBox.Controls.Add(Me.returnButton)
        Me.endScreenGroupBox.Controls.Add(Me.endScreenScoreLabel)
        Me.endScreenGroupBox.Controls.Add(Me.Label5)
        Me.endScreenGroupBox.Location = New System.Drawing.Point(228, 239)
        Me.endScreenGroupBox.Name = "endScreenGroupBox"
        Me.endScreenGroupBox.Size = New System.Drawing.Size(224, 170)
        Me.endScreenGroupBox.TabIndex = 1
        Me.endScreenGroupBox.TabStop = False
        Me.endScreenGroupBox.Text = "Game Over"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 48)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Game Over"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'endScreenScoreLabel
        '
        Me.endScreenScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.endScreenScoreLabel.Location = New System.Drawing.Point(9, 64)
        Me.endScreenScoreLabel.Name = "endScreenScoreLabel"
        Me.endScreenScoreLabel.Size = New System.Drawing.Size(212, 31)
        Me.endScreenScoreLabel.TabIndex = 1
        Me.endScreenScoreLabel.Text = "Score: 100"
        Me.endScreenScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'returnButton
        '
        Me.returnButton.Location = New System.Drawing.Point(6, 139)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(212, 25)
        Me.returnButton.TabIndex = 5
        Me.returnButton.Text = "Return to the Main Menu"
        Me.returnButton.UseVisualStyleBackColor = True
        '
        'restartButton
        '
        Me.restartButton.Location = New System.Drawing.Point(6, 108)
        Me.restartButton.Name = "restartButton"
        Me.restartButton.Size = New System.Drawing.Size(212, 25)
        Me.restartButton.TabIndex = 6
        Me.restartButton.Text = "Restart"
        Me.restartButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 640)
        Me.Controls.Add(Me.endScreenGroupBox)
        Me.Controls.Add(Me.mainGroupBox)
        Me.Name = "MainForm"
        Me.Text = "Snake"
        Me.mainGroupBox.ResumeLayout(False)
        Me.mainGroupBox.PerformLayout()
        Me.endScreenGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GameLoop As System.Windows.Forms.Timer
    Friend WithEvents mainGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents endScreenGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents restartButton As System.Windows.Forms.Button
    Friend WithEvents returnButton As System.Windows.Forms.Button
    Friend WithEvents endScreenScoreLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
