Public Class frmFeatSubCategories

    Private Sub frmFeatSubCategories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        txtFeat.Text = frmCharacterSheet.strFeatName
        For Each strItem As String In frmCharacterSheet.colFeatSubCategories
            cboSelection.Items.Add(strItem)
        Next
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        frmCharacterSheet.character.AddFeat(txtFeat.Text + "(" + cboSelection.SelectedItem.ToString + ")")
    End Sub
End Class