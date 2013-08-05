<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLevelUp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLevel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAttribute = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHitDice = New System.Windows.Forms.TextBox()
        Me.radRoll = New System.Windows.Forms.RadioButton()
        Me.radFixed = New System.Windows.Forms.RadioButton()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.cboClassFeat = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstSpecial = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSkillPoints = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add a Level of:"
        '
        'cboLevel
        '
        Me.cboLevel.FormattingEnabled = True
        Me.cboLevel.Location = New System.Drawing.Point(12, 51)
        Me.cboLevel.Name = "cboLevel"
        Me.cboLevel.Size = New System.Drawing.Size(121, 21)
        Me.cboLevel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attribute Increase:"
        '
        'cboAttribute
        '
        Me.cboAttribute.Enabled = False
        Me.cboAttribute.FormattingEnabled = True
        Me.cboAttribute.Items.AddRange(New Object() {"Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma"})
        Me.cboAttribute.Location = New System.Drawing.Point(233, 113)
        Me.cboAttribute.Name = "cboAttribute"
        Me.cboAttribute.Size = New System.Drawing.Size(121, 21)
        Me.cboAttribute.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hit Points:"
        '
        'txtHitDice
        '
        Me.txtHitDice.Enabled = False
        Me.txtHitDice.Location = New System.Drawing.Point(12, 114)
        Me.txtHitDice.Name = "txtHitDice"
        Me.txtHitDice.Size = New System.Drawing.Size(55, 20)
        Me.txtHitDice.TabIndex = 5
        '
        'radRoll
        '
        Me.radRoll.AutoSize = True
        Me.radRoll.Enabled = False
        Me.radRoll.Location = New System.Drawing.Point(15, 142)
        Me.radRoll.Name = "radRoll"
        Me.radRoll.Size = New System.Drawing.Size(91, 17)
        Me.radRoll.TabIndex = 6
        Me.radRoll.TabStop = True
        Me.radRoll.Text = "Roll Hit Points"
        Me.radRoll.UseVisualStyleBackColor = True
        '
        'radFixed
        '
        Me.radFixed.AutoSize = True
        Me.radFixed.Enabled = False
        Me.radFixed.Location = New System.Drawing.Point(15, 165)
        Me.radFixed.Name = "radFixed"
        Me.radFixed.Size = New System.Drawing.Size(98, 17)
        Me.radFixed.TabIndex = 7
        Me.radFixed.TabStop = True
        Me.radFixed.Text = "Fixed Hit Points"
        Me.radFixed.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(230, 225)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(59, 23)
        Me.btnNext.TabIndex = 10
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(296, 225)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(55, 23)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'cboClassFeat
        '
        Me.cboClassFeat.Enabled = False
        Me.cboClassFeat.FormattingEnabled = True
        Me.cboClassFeat.Location = New System.Drawing.Point(230, 179)
        Me.cboClassFeat.Name = "cboClassFeat"
        Me.cboClassFeat.Size = New System.Drawing.Size(121, 21)
        Me.cboClassFeat.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Add a Class Feat:"
        '
        'lstSpecial
        '
        Me.lstSpecial.FormattingEnabled = True
        Me.lstSpecial.Location = New System.Drawing.Point(15, 225)
        Me.lstSpecial.Name = "lstSpecial"
        Me.lstSpecial.Size = New System.Drawing.Size(120, 95)
        Me.lstSpecial.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(230, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Skill Points:"
        '
        'txtSkillPoints
        '
        Me.txtSkillPoints.Location = New System.Drawing.Point(230, 51)
        Me.txtSkillPoints.Name = "txtSkillPoints"
        Me.txtSkillPoints.Size = New System.Drawing.Size(100, 20)
        Me.txtSkillPoints.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Special Abilities:"
        '
        'FrmLevelUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(367, 337)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSkillPoints)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstSpecial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboClassFeat)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.radFixed)
        Me.Controls.Add(Me.radRoll)
        Me.Controls.Add(Me.txtHitDice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboAttribute)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboLevel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmLevelUp"
        Me.Text = "FrmLevelUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAttribute As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHitDice As System.Windows.Forms.TextBox
    Friend WithEvents radRoll As System.Windows.Forms.RadioButton
    Friend WithEvents radFixed As System.Windows.Forms.RadioButton
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents cboClassFeat As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstSpecial As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSkillPoints As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
