Public Class frmAddItems
    Private MouseIsDown As Boolean = False
    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        If lstAvailable.SelectedIndex <> -1 Then
            lstAddItems.Items.Add(lstAvailable.Text)
        End If
    End Sub

    Private Sub btnSubtractItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubtractItem.Click
        lstAddItems.Items.Remove(lstAddItems.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lstAddItems.SelectedIndex = -1 Then
            MessageBox.Show("Select an item in the add items list box.", "Error")
        Else
            FrmAttributes.Show()
        End If
    End Sub

    Private Sub BtnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPlus.Click
        txtPlatinum.Text = Convert.ToString(Convert.ToInt32(txtPlatinum.Text) + Convert.ToInt32(txtAddPlatinum.Text))
        txtAddPlatinum.Text = "0"
        txtGold.Text = Convert.ToString(Convert.ToInt32(txtGold.Text) + Convert.ToInt32(txtAddGold.Text))
        txtAddGold.Text = "0"
        txtSilver.Text = Convert.ToString(Convert.ToInt32(txtSilver.Text) + Convert.ToInt32(txtAddSilver.Text))
        txtAddSilver.Text = "0"
        txtCopper.Text = Convert.ToString(Convert.ToInt32(txtCopper.Text) + Convert.ToInt32(txtAddCopper.Text))
        txtAddCopper.Text = "0"
    End Sub

    Private Sub BtnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinus.Click
        Dim intplatinum As Integer = Convert.ToInt32(txtPlatinum.Text)
        Dim intgold As Integer = Convert.ToInt32(txtGold.Text)
        Dim intsilver As Integer = Convert.ToInt32(txtSilver.Text)
        Dim intcopper As Integer = Convert.ToInt32(txtCopper.Text)
        txtPlatinum.Text = Convert.ToString(Convert.ToInt32(txtPlatinum.Text) - Convert.ToInt32(txtAddPlatinum.Text))
        txtAddPlatinum.Text = "0"
        txtGold.Text = Convert.ToString(Convert.ToInt32(txtGold.Text) - Convert.ToInt32(txtAddGold.Text))
        txtAddGold.Text = "0"
        txtSilver.Text = Convert.ToString(Convert.ToInt32(txtSilver.Text) - Convert.ToInt32(txtAddSilver.Text))
        txtAddSilver.Text = "0"
        txtCopper.Text = Convert.ToString(Convert.ToInt32(txtCopper.Text) - Convert.ToInt32(txtAddCopper.Text))
        txtAddCopper.Text = "0"
        Do Until Convert.ToInt32(txtCopper.Text) >= 0
            txtSilver.Text = Convert.ToString(Convert.ToInt32(txtSilver.Text) - 1)
            txtCopper.Text = Convert.ToString(Convert.ToInt32(txtCopper.Text) + 10)
        Loop
        Do Until Convert.ToInt32(txtSilver.Text) >= 0
            txtGold.Text = Convert.ToString(Convert.ToInt32(txtGold.Text) - 1)
            txtSilver.Text = Convert.ToString(Convert.ToInt32(txtSilver.Text) + 10)
        Loop
        Do Until Convert.ToInt32(txtGold.Text) >= 0
            txtPlatinum.Text = Convert.ToString(Convert.ToInt32(txtPlatinum.Text) - 1)
            txtGold.Text = Convert.ToString(Convert.ToInt32(txtGold.Text) + 10)
        Loop
        If Convert.ToInt32(txtPlatinum.Text) < 0 Then
            txtPlatinum.Text = Convert.ToString(intplatinum)
            txtGold.Text = Convert.ToString(intgold)
            txtSilver.Text = Convert.ToString(intsilver)
            txtCopper.Text = Convert.ToString(intcopper)
            MessageBox.Show("You don't have enough money.", "Warning")
        End If
    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click
        frmCharacterSheet.LstItems.Items.Clear()
        For Each item As Object In lstAddItems.Items
            frmCharacterSheet.LstItems.Items.Add(item)
        Next
        frmCharacterSheet.txtPlatinum.Text = txtPlatinum.Text
        frmCharacterSheet.txtGold.Text = txtGold.Text
        frmCharacterSheet.txtSilver.Text = txtSilver.Text
        frmCharacterSheet.txtCopper.Text = txtCopper.Text
        lstAddItems.Items.Clear()
        frmCharacterSheet.equip()
        Me.Close()
    End Sub

    Private Sub btnCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustom.Click
        lstAddItems.Items.Add(txtCustom.Text)
        txtCustom.Text = ""
    End Sub

    Private Sub frmAddItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objReader As IO.StreamReader
        Dim strCurrentSearchItem As String
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\itemlist.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\itemlist.txt")
            strCurrentSearchItem = objReader.ReadLine()
            Do While objReader.Peek <> -1
                lstAvailable.Items.Add(strCurrentSearchItem)
                strCurrentSearchItem = objReader.ReadLine()
            Loop
        End If
    End Sub

    Private Sub lstAddItems_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstAddItems.DragDrop
        lstAddItems.Items.Add(e.Data.GetData(DataFormats.Text).ToString)
    End Sub

    Private Sub lstAddItems_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstAddItems.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstAddItems_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAddItems.MouseDoubleClick
        If lstAvailable.SelectedIndex <> -1 Then
            lstAddItems.Items.Add(lstAvailable.Text)
        End If
    End Sub

    Private Sub lstAddItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAddItems.MouseDown

    End Sub

    Private Sub lstAddItems_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAddItems.MouseMove
        
    End Sub

    Private Sub lstAddItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAddItems.SelectedIndexChanged

    End Sub

    Private Sub lstAvailable_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAvailable.MouseDoubleClick
        If lstAvailable.SelectedIndex <> -1 Then
            lstAddItems.Items.Add(lstAvailable.Text)
        End If
    End Sub

    Private Sub lstAvailable_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAvailable.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub lstAvailable_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAvailable.MouseMove
        If MouseIsDown Then
            ' Initiate dragging.
            lstAvailable.DoDragDrop(lstAvailable.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstAvailable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAvailable.SelectedIndexChanged

    End Sub
End Class