<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewCharacter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCha = New System.Windows.Forms.Label()
        Me.lblWis = New System.Windows.Forms.Label()
        Me.lblInt = New System.Windows.Forms.Label()
        Me.lblCon = New System.Windows.Forms.Label()
        Me.lblDex = New System.Windows.Forms.Label()
        Me.lblStr = New System.Windows.Forms.Label()
        Me.cboDiceMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtRoll1 = New System.Windows.Forms.TextBox()
        Me.txtRoll2 = New System.Windows.Forms.TextBox()
        Me.txtRoll3 = New System.Windows.Forms.TextBox()
        Me.txtRoll6 = New System.Windows.Forms.TextBox()
        Me.txtRoll5 = New System.Windows.Forms.TextBox()
        Me.txtRoll4 = New System.Windows.Forms.TextBox()
        Me.btnAcceptScores = New System.Windows.Forms.Button()
        Me.txtCha = New System.Windows.Forms.TextBox()
        Me.txtWis = New System.Windows.Forms.TextBox()
        Me.txtInt = New System.Windows.Forms.TextBox()
        Me.txtCon = New System.Windows.Forms.TextBox()
        Me.txtDex = New System.Windows.Forms.TextBox()
        Me.txtStr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFirstLevel = New System.Windows.Forms.ComboBox()
        Me.btnRerollStr = New System.Windows.Forms.Button()
        Me.btnRerollDex = New System.Windows.Forms.Button()
        Me.btnRerollCon = New System.Windows.Forms.Button()
        Me.btnRerollInt = New System.Windows.Forms.Button()
        Me.btnRerollWis = New System.Windows.Forms.Button()
        Me.btnRerollCha = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboRace = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboAlignment = New System.Windows.Forms.ComboBox()
        Me.txtStartHp = New System.Windows.Forms.TextBox()
        Me.lblPoints = New System.Windows.Forms.Label()
        Me.txtPoints = New System.Windows.Forms.TextBox()
        Me.nudStr = New System.Windows.Forms.NumericUpDown()
        Me.nudDex = New System.Windows.Forms.NumericUpDown()
        Me.nudCon = New System.Windows.Forms.NumericUpDown()
        Me.nudInt = New System.Windows.Forms.NumericUpDown()
        Me.nudWis = New System.Windows.Forms.NumericUpDown()
        Me.nudCha = New System.Windows.Forms.NumericUpDown()
        CType(Me.nudStr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudInt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCha
        '
        Me.lblCha.AutoSize = True
        Me.lblCha.Location = New System.Drawing.Point(55, 334)
        Me.lblCha.Name = "lblCha"
        Me.lblCha.Size = New System.Drawing.Size(26, 13)
        Me.lblCha.TabIndex = 36
        Me.lblCha.Text = "Cha"
        '
        'lblWis
        '
        Me.lblWis.AutoSize = True
        Me.lblWis.Location = New System.Drawing.Point(57, 309)
        Me.lblWis.Name = "lblWis"
        Me.lblWis.Size = New System.Drawing.Size(25, 13)
        Me.lblWis.TabIndex = 35
        Me.lblWis.Text = "Wis"
        '
        'lblInt
        '
        Me.lblInt.AutoSize = True
        Me.lblInt.Location = New System.Drawing.Point(62, 282)
        Me.lblInt.Name = "lblInt"
        Me.lblInt.Size = New System.Drawing.Size(19, 13)
        Me.lblInt.TabIndex = 34
        Me.lblInt.Text = "Int"
        '
        'lblCon
        '
        Me.lblCon.AutoSize = True
        Me.lblCon.Location = New System.Drawing.Point(55, 255)
        Me.lblCon.Name = "lblCon"
        Me.lblCon.Size = New System.Drawing.Size(26, 13)
        Me.lblCon.TabIndex = 33
        Me.lblCon.Text = "Con"
        '
        'lblDex
        '
        Me.lblDex.AutoSize = True
        Me.lblDex.Location = New System.Drawing.Point(56, 228)
        Me.lblDex.Name = "lblDex"
        Me.lblDex.Size = New System.Drawing.Size(26, 13)
        Me.lblDex.TabIndex = 32
        Me.lblDex.Text = "Dex"
        '
        'lblStr
        '
        Me.lblStr.AutoSize = True
        Me.lblStr.Location = New System.Drawing.Point(62, 201)
        Me.lblStr.Name = "lblStr"
        Me.lblStr.Size = New System.Drawing.Size(20, 13)
        Me.lblStr.TabIndex = 31
        Me.lblStr.Text = "Str"
        '
        'cboDiceMode
        '
        Me.cboDiceMode.FormattingEnabled = True
        Me.cboDiceMode.Items.AddRange(New Object() {"4d6 drop lowest", "5d6 drop 2 lowest", "4d6 drop lowest Organic", "3d6 drop none", "3d6 Organic", "The Floating Reroll", "Point Buy"})
        Me.cboDiceMode.Location = New System.Drawing.Point(163, 169)
        Me.cboDiceMode.Name = "cboDiceMode"
        Me.cboDiceMode.Size = New System.Drawing.Size(121, 21)
        Me.cboDiceMode.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Select Ability Score Generator:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(34, 432)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(270, 93)
        Me.txtDescription.TabIndex = 45
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(51, 385)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(104, 23)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "Generate Scores"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtRoll1
        '
        Me.txtRoll1.BackColor = System.Drawing.Color.White
        Me.txtRoll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll1.ForeColor = System.Drawing.Color.Black
        Me.txtRoll1.Location = New System.Drawing.Point(243, 199)
        Me.txtRoll1.Name = "txtRoll1"
        Me.txtRoll1.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll1.TabIndex = 47
        Me.txtRoll1.TabStop = False
        Me.txtRoll1.Visible = False
        '
        'txtRoll2
        '
        Me.txtRoll2.BackColor = System.Drawing.Color.White
        Me.txtRoll2.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll2.ForeColor = System.Drawing.Color.Black
        Me.txtRoll2.Location = New System.Drawing.Point(243, 226)
        Me.txtRoll2.Name = "txtRoll2"
        Me.txtRoll2.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll2.TabIndex = 48
        Me.txtRoll2.TabStop = False
        Me.txtRoll2.Visible = False
        '
        'txtRoll3
        '
        Me.txtRoll3.BackColor = System.Drawing.Color.White
        Me.txtRoll3.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll3.ForeColor = System.Drawing.Color.Black
        Me.txtRoll3.Location = New System.Drawing.Point(243, 253)
        Me.txtRoll3.Name = "txtRoll3"
        Me.txtRoll3.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll3.TabIndex = 49
        Me.txtRoll3.TabStop = False
        Me.txtRoll3.Visible = False
        '
        'txtRoll6
        '
        Me.txtRoll6.BackColor = System.Drawing.Color.White
        Me.txtRoll6.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll6.ForeColor = System.Drawing.Color.Black
        Me.txtRoll6.Location = New System.Drawing.Point(243, 334)
        Me.txtRoll6.Name = "txtRoll6"
        Me.txtRoll6.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll6.TabIndex = 52
        Me.txtRoll6.TabStop = False
        Me.txtRoll6.Visible = False
        '
        'txtRoll5
        '
        Me.txtRoll5.BackColor = System.Drawing.Color.White
        Me.txtRoll5.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll5.ForeColor = System.Drawing.Color.Black
        Me.txtRoll5.Location = New System.Drawing.Point(243, 307)
        Me.txtRoll5.Name = "txtRoll5"
        Me.txtRoll5.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll5.TabIndex = 51
        Me.txtRoll5.TabStop = False
        Me.txtRoll5.Visible = False
        '
        'txtRoll4
        '
        Me.txtRoll4.BackColor = System.Drawing.Color.White
        Me.txtRoll4.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoll4.ForeColor = System.Drawing.Color.Black
        Me.txtRoll4.Location = New System.Drawing.Point(243, 280)
        Me.txtRoll4.Name = "txtRoll4"
        Me.txtRoll4.Size = New System.Drawing.Size(41, 20)
        Me.txtRoll4.TabIndex = 50
        Me.txtRoll4.TabStop = False
        Me.txtRoll4.Visible = False
        '
        'btnAcceptScores
        '
        Me.btnAcceptScores.Location = New System.Drawing.Point(180, 385)
        Me.btnAcceptScores.Name = "btnAcceptScores"
        Me.btnAcceptScores.Size = New System.Drawing.Size(104, 23)
        Me.btnAcceptScores.TabIndex = 6
        Me.btnAcceptScores.Text = "Accept Scores"
        Me.btnAcceptScores.UseVisualStyleBackColor = True
        '
        'txtCha
        '
        Me.txtCha.AllowDrop = True
        Me.txtCha.BackColor = System.Drawing.Color.White
        Me.txtCha.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtCha.ForeColor = System.Drawing.Color.Black
        Me.txtCha.Location = New System.Drawing.Point(94, 333)
        Me.txtCha.Name = "txtCha"
        Me.txtCha.Size = New System.Drawing.Size(41, 20)
        Me.txtCha.TabIndex = 59
        Me.txtCha.TabStop = False
        '
        'txtWis
        '
        Me.txtWis.AllowDrop = True
        Me.txtWis.BackColor = System.Drawing.Color.White
        Me.txtWis.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtWis.ForeColor = System.Drawing.Color.Black
        Me.txtWis.Location = New System.Drawing.Point(94, 306)
        Me.txtWis.Name = "txtWis"
        Me.txtWis.Size = New System.Drawing.Size(41, 20)
        Me.txtWis.TabIndex = 58
        Me.txtWis.TabStop = False
        '
        'txtInt
        '
        Me.txtInt.AllowDrop = True
        Me.txtInt.BackColor = System.Drawing.Color.White
        Me.txtInt.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtInt.ForeColor = System.Drawing.Color.Black
        Me.txtInt.Location = New System.Drawing.Point(94, 279)
        Me.txtInt.Name = "txtInt"
        Me.txtInt.Size = New System.Drawing.Size(41, 20)
        Me.txtInt.TabIndex = 57
        Me.txtInt.TabStop = False
        '
        'txtCon
        '
        Me.txtCon.AllowDrop = True
        Me.txtCon.BackColor = System.Drawing.Color.White
        Me.txtCon.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtCon.ForeColor = System.Drawing.Color.Black
        Me.txtCon.Location = New System.Drawing.Point(94, 254)
        Me.txtCon.Name = "txtCon"
        Me.txtCon.Size = New System.Drawing.Size(41, 20)
        Me.txtCon.TabIndex = 56
        Me.txtCon.TabStop = False
        '
        'txtDex
        '
        Me.txtDex.AllowDrop = True
        Me.txtDex.BackColor = System.Drawing.Color.White
        Me.txtDex.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDex.ForeColor = System.Drawing.Color.Black
        Me.txtDex.Location = New System.Drawing.Point(94, 226)
        Me.txtDex.Name = "txtDex"
        Me.txtDex.Size = New System.Drawing.Size(41, 20)
        Me.txtDex.TabIndex = 55
        Me.txtDex.TabStop = False
        '
        'txtStr
        '
        Me.txtStr.AllowDrop = True
        Me.txtStr.BackColor = System.Drawing.Color.White
        Me.txtStr.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtStr.ForeColor = System.Drawing.Color.Black
        Me.txtStr.Location = New System.Drawing.Point(94, 198)
        Me.txtStr.Name = "txtStr"
        Me.txtStr.Size = New System.Drawing.Size(41, 20)
        Me.txtStr.TabIndex = 7
        Me.txtStr.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "First Level:"
        '
        'cboFirstLevel
        '
        Me.cboFirstLevel.FormattingEnabled = True
        Me.cboFirstLevel.Items.AddRange(New Object() {"Barbarian lvl 1", "Bard lvl 1", "Cleric lvl 1", "Druid lvl 1", "Fighter lvl 1", "Monk lvl 1", "Paladin lvl 1", "Rogue lvl 1", "Sorcerer lvl 1", "Wizard lvl 1"})
        Me.cboFirstLevel.Location = New System.Drawing.Point(89, 81)
        Me.cboFirstLevel.Name = "cboFirstLevel"
        Me.cboFirstLevel.Size = New System.Drawing.Size(121, 21)
        Me.cboFirstLevel.TabIndex = 2
        '
        'btnRerollStr
        '
        Me.btnRerollStr.Location = New System.Drawing.Point(141, 195)
        Me.btnRerollStr.Name = "btnRerollStr"
        Me.btnRerollStr.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollStr.TabIndex = 62
        Me.btnRerollStr.TabStop = False
        Me.btnRerollStr.Text = "Reroll"
        Me.btnRerollStr.UseVisualStyleBackColor = True
        Me.btnRerollStr.Visible = False
        '
        'btnRerollDex
        '
        Me.btnRerollDex.Location = New System.Drawing.Point(141, 223)
        Me.btnRerollDex.Name = "btnRerollDex"
        Me.btnRerollDex.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollDex.TabIndex = 63
        Me.btnRerollDex.TabStop = False
        Me.btnRerollDex.Text = "Reroll"
        Me.btnRerollDex.UseVisualStyleBackColor = True
        Me.btnRerollDex.Visible = False
        '
        'btnRerollCon
        '
        Me.btnRerollCon.Location = New System.Drawing.Point(141, 251)
        Me.btnRerollCon.Name = "btnRerollCon"
        Me.btnRerollCon.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollCon.TabIndex = 64
        Me.btnRerollCon.TabStop = False
        Me.btnRerollCon.Text = "Reroll"
        Me.btnRerollCon.UseVisualStyleBackColor = True
        Me.btnRerollCon.Visible = False
        '
        'btnRerollInt
        '
        Me.btnRerollInt.Location = New System.Drawing.Point(141, 276)
        Me.btnRerollInt.Name = "btnRerollInt"
        Me.btnRerollInt.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollInt.TabIndex = 65
        Me.btnRerollInt.TabStop = False
        Me.btnRerollInt.Text = "Reroll"
        Me.btnRerollInt.UseVisualStyleBackColor = True
        Me.btnRerollInt.Visible = False
        '
        'btnRerollWis
        '
        Me.btnRerollWis.Location = New System.Drawing.Point(141, 303)
        Me.btnRerollWis.Name = "btnRerollWis"
        Me.btnRerollWis.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollWis.TabIndex = 66
        Me.btnRerollWis.TabStop = False
        Me.btnRerollWis.Text = "Reroll"
        Me.btnRerollWis.UseVisualStyleBackColor = True
        Me.btnRerollWis.Visible = False
        '
        'btnRerollCha
        '
        Me.btnRerollCha.Location = New System.Drawing.Point(141, 330)
        Me.btnRerollCha.Name = "btnRerollCha"
        Me.btnRerollCha.Size = New System.Drawing.Size(51, 23)
        Me.btnRerollCha.TabIndex = 67
        Me.btnRerollCha.TabStop = False
        Me.btnRerollCha.Text = "Reroll"
        Me.btnRerollCha.UseVisualStyleBackColor = True
        Me.btnRerollCha.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Race:"
        '
        'cboRace
        '
        Me.cboRace.FormattingEnabled = True
        Me.cboRace.Items.AddRange(New Object() {"Human", "Halfling", "Gnome", "Half-orc", "Dwarf", "Half-elf", "Elf"})
        Me.cboRace.Location = New System.Drawing.Point(89, 54)
        Me.cboRace.Name = "cboRace"
        Me.cboRace.Size = New System.Drawing.Size(121, 21)
        Me.cboRace.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(89, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Alignment:"
        '
        'cboAlignment
        '
        Me.cboAlignment.FormattingEnabled = True
        Me.cboAlignment.Items.AddRange(New Object() {"Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil"})
        Me.cboAlignment.Location = New System.Drawing.Point(91, 113)
        Me.cboAlignment.Name = "cboAlignment"
        Me.cboAlignment.Size = New System.Drawing.Size(121, 21)
        Me.cboAlignment.TabIndex = 3
        '
        'txtStartHp
        '
        Me.txtStartHp.Location = New System.Drawing.Point(91, 140)
        Me.txtStartHp.Name = "txtStartHp"
        Me.txtStartHp.Size = New System.Drawing.Size(100, 20)
        Me.txtStartHp.TabIndex = 73
        Me.txtStartHp.Visible = False
        '
        'lblPoints
        '
        Me.lblPoints.AutoSize = True
        Me.lblPoints.Location = New System.Drawing.Point(89, 360)
        Me.lblPoints.Name = "lblPoints"
        Me.lblPoints.Size = New System.Drawing.Size(60, 13)
        Me.lblPoints.TabIndex = 74
        Me.lblPoints.Text = "Points Left:"
        Me.lblPoints.Visible = False
        '
        'txtPoints
        '
        Me.txtPoints.Location = New System.Drawing.Point(155, 357)
        Me.txtPoints.Name = "txtPoints"
        Me.txtPoints.ReadOnly = True
        Me.txtPoints.Size = New System.Drawing.Size(100, 20)
        Me.txtPoints.TabIndex = 75
        Me.txtPoints.Visible = False
        '
        'nudStr
        '
        Me.nudStr.Location = New System.Drawing.Point(92, 199)
        Me.nudStr.Name = "nudStr"
        Me.nudStr.Size = New System.Drawing.Size(43, 20)
        Me.nudStr.TabIndex = 76
        Me.nudStr.Visible = False
        '
        'nudDex
        '
        Me.nudDex.Location = New System.Drawing.Point(92, 226)
        Me.nudDex.Name = "nudDex"
        Me.nudDex.Size = New System.Drawing.Size(43, 20)
        Me.nudDex.TabIndex = 77
        Me.nudDex.Visible = False
        '
        'nudCon
        '
        Me.nudCon.Location = New System.Drawing.Point(92, 251)
        Me.nudCon.Name = "nudCon"
        Me.nudCon.Size = New System.Drawing.Size(43, 20)
        Me.nudCon.TabIndex = 78
        Me.nudCon.Visible = False
        '
        'nudInt
        '
        Me.nudInt.Location = New System.Drawing.Point(94, 279)
        Me.nudInt.Name = "nudInt"
        Me.nudInt.Size = New System.Drawing.Size(43, 20)
        Me.nudInt.TabIndex = 79
        Me.nudInt.Visible = False
        '
        'nudWis
        '
        Me.nudWis.Location = New System.Drawing.Point(94, 305)
        Me.nudWis.Name = "nudWis"
        Me.nudWis.Size = New System.Drawing.Size(43, 20)
        Me.nudWis.TabIndex = 80
        Me.nudWis.Visible = False
        '
        'nudCha
        '
        Me.nudCha.Location = New System.Drawing.Point(94, 332)
        Me.nudCha.Name = "nudCha"
        Me.nudCha.Size = New System.Drawing.Size(43, 20)
        Me.nudCha.TabIndex = 81
        Me.nudCha.Visible = False
        '
        'frmNewCharacter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(330, 573)
        Me.Controls.Add(Me.nudCha)
        Me.Controls.Add(Me.nudWis)
        Me.Controls.Add(Me.nudInt)
        Me.Controls.Add(Me.nudCon)
        Me.Controls.Add(Me.nudDex)
        Me.Controls.Add(Me.nudStr)
        Me.Controls.Add(Me.txtPoints)
        Me.Controls.Add(Me.lblPoints)
        Me.Controls.Add(Me.txtStartHp)
        Me.Controls.Add(Me.cboAlignment)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboRace)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnRerollCha)
        Me.Controls.Add(Me.btnRerollWis)
        Me.Controls.Add(Me.btnRerollInt)
        Me.Controls.Add(Me.btnRerollCon)
        Me.Controls.Add(Me.btnRerollDex)
        Me.Controls.Add(Me.btnRerollStr)
        Me.Controls.Add(Me.cboFirstLevel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCha)
        Me.Controls.Add(Me.txtWis)
        Me.Controls.Add(Me.txtInt)
        Me.Controls.Add(Me.txtCon)
        Me.Controls.Add(Me.txtDex)
        Me.Controls.Add(Me.txtStr)
        Me.Controls.Add(Me.btnAcceptScores)
        Me.Controls.Add(Me.txtRoll6)
        Me.Controls.Add(Me.txtRoll5)
        Me.Controls.Add(Me.txtRoll4)
        Me.Controls.Add(Me.txtRoll3)
        Me.Controls.Add(Me.txtRoll2)
        Me.Controls.Add(Me.txtRoll1)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDiceMode)
        Me.Controls.Add(Me.lblCha)
        Me.Controls.Add(Me.lblWis)
        Me.Controls.Add(Me.lblInt)
        Me.Controls.Add(Me.lblCon)
        Me.Controls.Add(Me.lblDex)
        Me.Controls.Add(Me.lblStr)
        Me.Name = "frmNewCharacter"
        Me.Text = "frmNewCharacter"
        CType(Me.nudStr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudInt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCha As System.Windows.Forms.Label
    Friend WithEvents lblWis As System.Windows.Forms.Label
    Friend WithEvents lblInt As System.Windows.Forms.Label
    Friend WithEvents lblCon As System.Windows.Forms.Label
    Friend WithEvents lblDex As System.Windows.Forms.Label
    Friend WithEvents lblStr As System.Windows.Forms.Label
    Friend WithEvents cboDiceMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtRoll1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRoll2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRoll3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRoll6 As System.Windows.Forms.TextBox
    Friend WithEvents txtRoll5 As System.Windows.Forms.TextBox
    Friend WithEvents txtRoll4 As System.Windows.Forms.TextBox
    Friend WithEvents btnAcceptScores As System.Windows.Forms.Button
    Friend WithEvents txtCha As System.Windows.Forms.TextBox
    Friend WithEvents txtWis As System.Windows.Forms.TextBox
    Friend WithEvents txtInt As System.Windows.Forms.TextBox
    Friend WithEvents txtCon As System.Windows.Forms.TextBox
    Friend WithEvents txtDex As System.Windows.Forms.TextBox
    Friend WithEvents txtStr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFirstLevel As System.Windows.Forms.ComboBox
    Friend WithEvents btnRerollStr As System.Windows.Forms.Button
    Friend WithEvents btnRerollDex As System.Windows.Forms.Button
    Friend WithEvents btnRerollCon As System.Windows.Forms.Button
    Friend WithEvents btnRerollInt As System.Windows.Forms.Button
    Friend WithEvents btnRerollWis As System.Windows.Forms.Button
    Friend WithEvents btnRerollCha As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboRace As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAlignment As System.Windows.Forms.ComboBox
    Friend WithEvents txtStartHp As System.Windows.Forms.TextBox
    Friend WithEvents lblPoints As System.Windows.Forms.Label
    Friend WithEvents txtPoints As System.Windows.Forms.TextBox
    Friend WithEvents nudStr As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDex As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCon As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudInt As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudWis As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCha As System.Windows.Forms.NumericUpDown
End Class
