<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeatSubCategories
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
        Me.cboSelection = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtFeat = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cboSelection
        '
        Me.cboSelection.FormattingEnabled = True
        Me.cboSelection.Location = New System.Drawing.Point(70, 59)
        Me.cboSelection.Name = "cboSelection"
        Me.cboSelection.Size = New System.Drawing.Size(121, 21)
        Me.cboSelection.TabIndex = 0
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(171, 113)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 1
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtFeat
        '
        Me.txtFeat.Enabled = False
        Me.txtFeat.Location = New System.Drawing.Point(70, 33)
        Me.txtFeat.Name = "txtFeat"
        Me.txtFeat.Size = New System.Drawing.Size(100, 20)
        Me.txtFeat.TabIndex = 2
        '
        'frmFeatSubCategories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(323, 176)
        Me.Controls.Add(Me.txtFeat)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboSelection)
        Me.Name = "frmFeatSubCategories"
        Me.Text = "Select Feat Sub Category"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboSelection As System.Windows.Forms.ComboBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtFeat As System.Windows.Forms.TextBox
End Class
