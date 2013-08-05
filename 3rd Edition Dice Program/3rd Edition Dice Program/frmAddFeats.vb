Public Class frmAddFeats
    Dim character As Character.PC
    Private Sub AddFeats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strItem As String
        Dim strArray() As String
        Dim objReader As IO.StreamReader
        Dim strReader As String = ""
        Dim strSplitReader2(0) As String
        Dim ComboBox(5) As ComboBox
        Dim Label(5) As Label
        Dim x As Integer = 0
        Dim i As Integer
        ComboBox(0) = cboFeat1
        ComboBox(1) = cboFeat2
        ComboBox(2) = cboFeat3
        ComboBox(3) = cboFeat4
        ComboBox(4) = cboFeat5
        Label(0) = Label1
        Label(1) = Label2
        Label(2) = Label3
        Label(3) = Label4
        Label(4) = Label5
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        character = frmCharacterSheet.character
        For Each strItem In character.colNewFeats
            strArray = Split(strItem, ",")

            If strArray(0) = "general" Then
                If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\FeatList.txt") = True Then
                    objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\FeatList.txt")
                    strReader = objReader.ReadLine()
                    Do Until strReader = "End"
                        If character.CheckPrerequisites(strReader) Then
                            Label(x).Text = "General Feat"
                            ComboBox(x).Items.Add(strReader)
                            Label(x).Visible = True
                            ComboBox(x).Visible = True
                        End If
                        strReader = objReader.ReadLine()
                    Loop
                End If
            ElseIf strArray(0) = "class" Then
                If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassFeats.txt") = True Then
                    objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassFeats.txt")
                    strReader = objReader.ReadLine()
                    Do Until strReader = "End"
                        ReDim strSplitReader2(frmCharacterSheet.NumOfItems(strReader))
                        strSplitReader2 = Split(strReader, ",")
                        If strSplitReader2(0) = strArray(1) Then
                            Label(x).Text = "Class Feat"
                            For i = 1 To strSplitReader2.Length - 1
                                If character.CheckPrerequisites(strSplitReader2(i)) = True Then
                                    ComboBox(x).Items.Add(strSplitReader2(i))
                                End If
                            Next
                            Label(x).Visible = True
                            ComboBox(x).Visible = True
                        End If
                        strReader = objReader.ReadLine()
                    Loop
                End If
            ElseIf strArray(0) = "classNP" Then
                If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassFeats.txt") = True Then
                    objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassFeats.txt")
                    strReader = objReader.ReadLine()
                    Do Until strReader = "End"
                        ReDim strSplitReader2(frmCharacterSheet.NumOfItems(strReader))
                        strSplitReader2 = Split(strReader, ",")
                        If strSplitReader2(0) = strArray(1) Then
                            Label(x).Text = "Class Feat"
                            For i = 1 To strSplitReader2.Length - 1
                                ComboBox(x).Items.Add(strSplitReader2(i))
                            Next
                            Label(x).Visible = True
                            ComboBox(x).Visible = True
                        End If
                        strReader = objReader.ReadLine()
                    Loop
                End If
            ElseIf strArray(0) = "race" Then
                If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\RaceFeats.txt") = True Then
                    objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\RaceFeats.txt")
                    strReader = objReader.ReadLine()
                    Do Until strReader = "End"
                        ReDim strSplitReader2(frmCharacterSheet.NumOfItems(strReader))
                        strSplitReader2 = Split(strReader, ",")
                        If strSplitReader2(0) = strArray(1) Then
                            Label(x).Text = "Racial Feat"
                            For i = 1 To strSplitReader2.Length - 1
                                If character.CheckPrerequisites(strSplitReader2(i)) = True Then
                                    ComboBox(x).Items.Add(strSplitReader2(i))
                                End If
                            Next
                            Label(x).Visible = True
                            ComboBox(x).Visible = True
                        End If
                        strReader = objReader.ReadLine()
                    Loop
                End If
            End If
            x += 1
        Next
    End Sub

    Private Sub btnAddFeats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFeats.Click
        If cboFeat1.Text <> "" Then
            character.AddFeat(cboFeat1.Text)
            character.colNewFeats.Remove(1)
        End If
        If cboFeat2.Text <> "" Then
            character.AddFeat(cboFeat2.Text)
            character.colNewFeats.Remove(1)
        End If
        If cboFeat3.Text <> "" Then
            character.AddFeat(cboFeat3.Text)
            character.colNewFeats.Remove(1)
        End If
        If cboFeat4.Text <> "" Then
            character.AddFeat(cboFeat4.Text)
            character.colNewFeats.Remove(1)
        End If
        If cboFeat5.Text <> "" Then
            character.AddFeat(cboFeat5.Text)
            character.colNewFeats.Remove(1)
        End If
        frmCharacterSheet.equip()
        Me.Close()
    End Sub
End Class