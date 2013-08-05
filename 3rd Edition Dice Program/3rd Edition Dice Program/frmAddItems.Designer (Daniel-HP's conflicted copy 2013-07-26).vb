<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddItems
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
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstAddItems = New System.Windows.Forms.ListBox()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.btnSubtractItem = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnPlus = New System.Windows.Forms.Button()
        Me.BtnMinus = New System.Windows.Forms.Button()
        Me.btnAddItems = New System.Windows.Forms.Button()
        Me.txtCopper = New System.Windows.Forms.TextBox()
        Me.txtSilver = New System.Windows.Forms.TextBox()
        Me.txtGold = New System.Windows.Forms.TextBox()
        Me.txtPlatinum = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtAddCopper = New System.Windows.Forms.TextBox()
        Me.txtAddSilver = New System.Windows.Forms.TextBox()
        Me.txtAddGold = New System.Windows.Forms.TextBox()
        Me.txtAddPlatinum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustom = New System.Windows.Forms.TextBox()
        Me.btnCustom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstAvailable
        '
        Me.lstAvailable.FormattingEnabled = True
        Me.lstAvailable.Location = New System.Drawing.Point(22, 44)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(161, 277)
        Me.lstAvailable.TabIndex = 0
        '
        'lstAddItems
        '
        Me.lstAddItems.AllowDrop = True
        Me.lstAddItems.FormattingEnabled = True
        Me.lstAddItems.HorizontalScrollbar = True
        Me.lstAddItems.Location = New System.Drawing.Point(300, 44)
        Me.lstAddItems.Name = "lstAddItems"
        Me.lstAddItems.Size = New System.Drawing.Size(166, 277)
        Me.lstAddItems.TabIndex = 1
        '
        'btnAddItem
        '
        Me.btnAddItem.Location = New System.Drawing.Point(22, 327)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(75, 23)
        Me.btnAddItem.TabIndex = 2
        Me.btnAddItem.Text = "Add Item"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'btnSubtractItem
        '
        Me.btnSubtractItem.Location = New System.Drawing.Point(300, 327)
        Me.btnSubtractItem.Name = "btnSubtractItem"
        Me.btnSubtractItem.Size = New System.Drawing.Size(84, 23)
        Me.btnSubtractItem.TabIndex = 3
        Me.btnSubtractItem.Text = "Remove Item"
        Me.btnSubtractItem.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Items"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(189, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 21)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Modify Attributes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnPlus
        '
        Me.BtnPlus.Location = New System.Drawing.Point(132, 406)
        Me.BtnPlus.Name = "BtnPlus"
        Me.BtnPlus.Size = New System.Drawing.Size(19, 19)
        Me.BtnPlus.TabIndex = 9
        Me.BtnPlus.Text = "+"
        Me.BtnPlus.UseVisualStyleBackColor = True
        '
        'BtnMinus
        '
        Me.BtnMinus.Location = New System.Drawing.Point(132, 432)
        Me.BtnMinus.Name = "BtnMinus"
        Me.BtnMinus.Size = New System.Drawing.Size(19, 19)
        Me.BtnMinus.TabIndex = 10
        Me.BtnMinus.Text = "-"
        Me.BtnMinus.UseVisualStyleBackColor = True
        '
        'btnAddItems
        '
        Me.btnAddItems.Location = New System.Drawing.Point(315, 436)
        Me.btnAddItems.Name = "btnAddItems"
        Me.btnAddItems.Size = New System.Drawing.Size(99, 23)
        Me.btnAddItems.TabIndex = 12
        Me.btnAddItems.Text = "Add Items/Gold"
        Me.btnAddItems.UseVisualStyleBackColor = True
        '
        'txtCopper
        '
        Me.txtCopper.Location = New System.Drawing.Point(169, 460)
        Me.txtCopper.Name = "txtCopper"
        Me.txtCopper.ReadOnly = True
        Me.txtCopper.Size = New System.Drawing.Size(51, 20)
        Me.txtCopper.TabIndex = 145
        Me.txtCopper.Text = "0"
        Me.txtCopper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSilver
        '
        Me.txtSilver.Location = New System.Drawing.Point(169, 434)
        Me.txtSilver.Name = "txtSilver"
        Me.txtSilver.ReadOnly = True
        Me.txtSilver.Size = New System.Drawing.Size(51, 20)
        Me.txtSilver.TabIndex = 144
        Me.txtSilver.Text = "0"
        Me.txtSilver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGold
        '
        Me.txtGold.Location = New System.Drawing.Point(169, 406)
        Me.txtGold.Name = "txtGold"
        Me.txtGold.ReadOnly = True
        Me.txtGold.Size = New System.Drawing.Size(51, 20)
        Me.txtGold.TabIndex = 143
        Me.txtGold.Text = "0"
        Me.txtGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPlatinum
        '
        Me.txtPlatinum.Location = New System.Drawing.Point(169, 382)
        Me.txtPlatinum.Name = "txtPlatinum"
        Me.txtPlatinum.ReadOnly = True
        Me.txtPlatinum.Size = New System.Drawing.Size(51, 20)
        Me.txtPlatinum.TabIndex = 142
        Me.txtPlatinum.Text = "0"
        Me.txtPlatinum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(33, 467)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(44, 13)
        Me.Label53.TabIndex = 141
        Me.Label53.Text = "Copper:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(41, 441)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(36, 13)
        Me.Label52.TabIndex = 140
        Me.Label52.Text = "Silver:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(27, 389)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(50, 13)
        Me.Label51.TabIndex = 139
        Me.Label51.Text = "Platinum:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(45, 415)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(32, 13)
        Me.Label50.TabIndex = 138
        Me.Label50.Text = "Gold:"
        '
        'txtAddCopper
        '
        Me.txtAddCopper.Location = New System.Drawing.Point(75, 460)
        Me.txtAddCopper.Name = "txtAddCopper"
        Me.txtAddCopper.Size = New System.Drawing.Size(51, 20)
        Me.txtAddCopper.TabIndex = 149
        Me.txtAddCopper.Text = "0"
        Me.txtAddCopper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddSilver
        '
        Me.txtAddSilver.Location = New System.Drawing.Point(75, 434)
        Me.txtAddSilver.Name = "txtAddSilver"
        Me.txtAddSilver.Size = New System.Drawing.Size(51, 20)
        Me.txtAddSilver.TabIndex = 148
        Me.txtAddSilver.Text = "0"
        Me.txtAddSilver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddGold
        '
        Me.txtAddGold.Location = New System.Drawing.Point(75, 406)
        Me.txtAddGold.Name = "txtAddGold"
        Me.txtAddGold.Size = New System.Drawing.Size(51, 20)
        Me.txtAddGold.TabIndex = 147
        Me.txtAddGold.Text = "0"
        Me.txtAddGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddPlatinum
        '
        Me.txtAddPlatinum.Location = New System.Drawing.Point(75, 382)
        Me.txtAddPlatinum.Name = "txtAddPlatinum"
        Me.txtAddPlatinum.Size = New System.Drawing.Size(51, 20)
        Me.txtAddPlatinum.TabIndex = 146
        Me.txtAddPlatinum.Text = "0"
        Me.txtAddPlatinum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(186, 357)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Total:"
        '
        'txtCustom
        '
        Me.txtCustom.Location = New System.Drawing.Point(189, 212)
        Me.txtCustom.Name = "txtCustom"
        Me.txtCustom.Size = New System.Drawing.Size(100, 20)
        Me.txtCustom.TabIndex = 151
        '
        'btnCustom
        '
        Me.btnCustom.Location = New System.Drawing.Point(201, 238)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(75, 23)
        Me.btnCustom.TabIndex = 152
        Me.btnCustom.Text = "Add Custom Item"
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'frmAddItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(506, 491)
        Me.Controls.Add(Me.btnCustom)
        Me.Controls.Add(Me.txtCustom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddCopper)
        Me.Controls.Add(Me.txtAddSilver)
        Me.Controls.Add(Me.txtAddGold)
        Me.Controls.Add(Me.txtAddPlatinum)
        Me.Controls.Add(Me.txtCopper)
        Me.Controls.Add(Me.txtSilver)
        Me.Controls.Add(Me.txtGold)
        Me.Controls.Add(Me.txtPlatinum)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.btnAddItems)
        Me.Controls.Add(Me.BtnMinus)
        Me.Controls.Add(Me.BtnPlus)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSubtractItem)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.lstAddItems)
        Me.Controls.Add(Me.lstAvailable)
        Me.Name = "frmAddItems"
        Me.Text = "Items"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstAvailable As System.Windows.Forms.ListBox
    Friend WithEvents lstAddItems As System.Windows.Forms.ListBox
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents btnSubtractItem As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnPlus As System.Windows.Forms.Button
    Friend WithEvents BtnMinus As System.Windows.Forms.Button
    Friend WithEvents btnAddItems As System.Windows.Forms.Button
    Friend WithEvents txtCopper As System.Windows.Forms.TextBox
    Friend WithEvents txtSilver As System.Windows.Forms.TextBox
    Friend WithEvents txtGold As System.Windows.Forms.TextBox
    Friend WithEvents txtPlatinum As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtAddCopper As System.Windows.Forms.TextBox
    Friend WithEvents txtAddSilver As System.Windows.Forms.TextBox
    Friend WithEvents txtAddGold As System.Windows.Forms.TextBox
    Friend WithEvents txtAddPlatinum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustom As System.Windows.Forms.TextBox
    Friend WithEvents btnCustom As System.Windows.Forms.Button
End Class
