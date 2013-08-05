<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddWizardSpells
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
        Me.cboFirstSpell = New System.Windows.Forms.ComboBox()
        Me.cboSecondSpell = New System.Windows.Forms.ComboBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboFirstSpell
        '
        Me.cboFirstSpell.FormattingEnabled = True
        Me.cboFirstSpell.Location = New System.Drawing.Point(25, 42)
        Me.cboFirstSpell.Name = "cboFirstSpell"
        Me.cboFirstSpell.Size = New System.Drawing.Size(121, 21)
        Me.cboFirstSpell.TabIndex = 0
        '
        'cboSecondSpell
        '
        Me.cboSecondSpell.FormattingEnabled = True
        Me.cboSecondSpell.Location = New System.Drawing.Point(25, 70)
        Me.cboSecondSpell.Name = "cboSecondSpell"
        Me.cboSecondSpell.Size = New System.Drawing.Size(121, 21)
        Me.cboSecondSpell.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(24, 98)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(121, 97)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Add Wizard Spells:"
        '
        'frmAddWizardSpells
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(229, 143)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.cboSecondSpell)
        Me.Controls.Add(Me.cboFirstSpell)
        Me.Name = "frmAddWizardSpells"
        Me.Text = "Add Wizard Spells"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFirstSpell As System.Windows.Forms.ComboBox
    Friend WithEvents cboSecondSpell As System.Windows.Forms.ComboBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
