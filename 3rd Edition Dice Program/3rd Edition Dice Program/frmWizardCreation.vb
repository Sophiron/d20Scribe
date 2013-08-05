Public Class frmWizardCreation
    'the max spell level accessible for each spell selection combo box
    Public intMaxLevel(12) As Integer
    Public character As Character.PC
    Public bolAllSpells() As Boolean = {False, False, False, False, False, False, False, False, False, False}
    Private Sub SpellFill()
        Dim x As Integer = 1
        Dim control As ComboBox = cmbSpell1
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray(4) As String
        Dim intCurrentLevel As Integer = 0
        Dim strCaster As String = txtClass.Text
        cmbSpell1.Items.Clear()
        cmbSpell2.Items.Clear()
        cmbSpell3.Items.Clear()
        cmbSpell4.Items.Clear()
        cmbSpell5.Items.Clear()
        cmbSpell6.Items.Clear()
        cmbSpell7.Items.Clear()
        cmbSpell8.Items.Clear()
        cmbSpell9.Items.Clear()
        cmbSpell10.Items.Clear()
        cmbSpell11.Items.Clear()
        cmbSpell12.Items.Clear()
        If strCaster = "Sorcerer" Then
            strCaster = "Wizard"
        End If
        For x = 1 To 12
            Select Case x
                Case 1
                    control = cmbSpell1
                Case 2
                    control = cmbSpell2
                Case 3
                    control = cmbSpell3
                Case 4
                    control = cmbSpell4
                Case 5
                    control = cmbSpell5
                Case 6
                    control = cmbSpell6
                Case 7
                    control = cmbSpell7
                Case 8
                    control = cmbSpell8
                Case 9
                    control = cmbSpell9
                Case 10
                    control = cmbSpell10
                Case 11
                    control = cmbSpell11
                Case 12
                    control = cmbSpell12
            End Select
            If control.Enabled = True Then
                intCurrentLevel = intMaxLevel(x - 1)
                Do While intCurrentLevel >= 0
                    If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt") = True Then
                        objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt")
                        strCurrentLine = objReader.ReadLine()
                        strArray = Split(strCurrentLine, ",")
                        Do While objReader.Peek <> -1
                            If strArray(3) = strCaster Then
                                If strArray(0) = intCurrentLevel Then
                                    If strArray(2) <> cboSpecial4.Text Then
                                        If strArray(2) <> cboSpecial3.Text Then
                                            control.Items.Add(strArray(1))
                                        End If
                                    End If
                                End If
                            End If
                            strCurrentLine = objReader.ReadLine()
                            strArray = Split(strCurrentLine, ",")
                        Loop
                        objReader.Close()
                    End If
                    intCurrentLevel -= 1
                Loop
            End If
        Next
    End Sub

    Private Sub cboSpecialization_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpecial1.SelectedIndexChanged
        If txtClass.Text = "wizard" Then
            If cboSpecial1.SelectedItem = "Divination" Then
                cboSpecial2.Enabled = True
                cboSpecial3.Enabled = False
                cboSpecial4.Enabled = False
            Else
                If cboSpecial1.SelectedItem <> "" Then
                    cboSpecial2.Enabled = False
                    cboSpecial3.Enabled = True
                    cboSpecial4.Enabled = True
                Else
                    cboSpecial2.Enabled = False
                    cboSpecial3.Enabled = False
                    cboSpecial4.Enabled = False
                End If
            End If
        End If
        SpellFill()
    End Sub

    Private Sub frmwizardCreation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intSpellNum As Integer = 0 'number of cmbspells to enable
        Dim intNum As Integer = 0 'intermediate number
        Dim i As Integer = 0 'loop variable
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strElement(4) As String
        Dim control As TextBox = txtSpell1
        Dim strCasterArray() As String
        Dim text As String
        Dim strArray(3) As String
        Dim strcaster() As String
        Dim strClass() As String
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        character = frmCharacterSheet.character
        strCasterArray = character.GetNewCasterLevelup
        txtClass.Text = strCasterArray(0)
        txtLevel.Text = strCasterArray(1)
        Dim bolclose As Boolean = True 'so that it will not close if a class that doesn't choose spells known
        Threading.Thread.Sleep(1000)
        cboSpecial2.Enabled = False
        cboSpecial3.Enabled = False
        cboSpecial4.Enabled = False
        cmbSpell1.Enabled = False
        cmbSpell2.Enabled = False
        cmbSpell3.Enabled = False
        cmbSpell4.Enabled = False
        cmbSpell5.Enabled = False
        cmbSpell6.Enabled = False
        cmbSpell7.Enabled = False
        cmbSpell8.Enabled = False
        cmbSpell9.Enabled = False
        cmbSpell10.Enabled = False
        cmbSpell11.Enabled = False
        cmbSpell12.Enabled = False
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellsKnownLevelUp.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellsKnownLevelUp.txt")
            strCurrentLine = objReader.ReadLine()
            Do While objReader.Peek <> -1
                strElement = Split(strCurrentLine, ",")
                If strElement(0) = txtClass.Text Then
                    If strElement(1) = txtLevel.Text Then
                        If strElement(2) <> "all" Then
                            Select Case strElement(2)
                                Case "str"
                                    intNum = character.intStrBonus
                                Case "dex"
                                    intNum = character.intDexBonus
                                Case "con"
                                    intNum = character.intConBonus
                                Case "wis"
                                    intNum = character.intWisBonus
                                Case "int"
                                    intNum = character.intIntBonus
                                Case "cha"
                                    intNum = character.IntChaBonus
                                Case Else
                                    intNum = strElement(2)
                            End Select
                            For i = 0 To intNum - 1
                                intMaxLevel(intSpellNum + i) = strElement(3)
                            Next
                            intSpellNum += intNum
                        Else
                            bolAllSpells(strElement(3)) = True
                            'addAllSpells(strElement(3))
                            bolclose = False
                        End If
                    End If
                    End If
                    strCurrentLine = objReader.ReadLine()
            Loop
        End If
        Select Case intSpellNum
            Case 0
                If bolclose Then
                    Me.Close()
                End If
            Case 1
                cmbSpell1.Enabled = True
            Case 2
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
            Case 3
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
            Case 4
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
            Case 5
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
            Case 6
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
            Case 7
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
            Case 8
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
                cmbSpell8.Enabled = True
            Case 9
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
                cmbSpell8.Enabled = True
                cmbSpell9.Enabled = True
            Case 10
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
                cmbSpell8.Enabled = True
                cmbSpell9.Enabled = True
                cmbSpell10.Enabled = True
            Case 11
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
                cmbSpell8.Enabled = True
                cmbSpell9.Enabled = True
                cmbSpell10.Enabled = True
                cmbSpell11.Enabled = True
            Case 9
                cmbSpell1.Enabled = True
                cmbSpell2.Enabled = True
                cmbSpell3.Enabled = True
                cmbSpell4.Enabled = True
                cmbSpell5.Enabled = True
                cmbSpell6.Enabled = True
                cmbSpell7.Enabled = True
                cmbSpell8.Enabled = True
                cmbSpell9.Enabled = True
                cmbSpell10.Enabled = True
                cmbSpell11.Enabled = True
                cmbSpell12.Enabled = True
        End Select
        For i = 0 To intSpellNum - 1
            Select Case i
                Case 0
                    control = txtSpell1
                Case 1
                    control = txtSpell2
                Case 2
                    control = txtSpell3
                Case 3
                    control = txtSpell4
                Case 4
                    control = txtSpell5
                Case 5
                    control = txtSpell6
                Case 6
                    control = txtSpell7
                Case 7
                    control = txtSpell8
                Case 8
                    control = txtSpell9
                Case 9
                    control = txtSpell10
                Case 10
                    control = txtSpell11
                Case 11
                    control = txtSpell12
            End Select
            Select Case intMaxLevel(i)
                Case 1
                    text = "st level"
                Case 2
                    text = "nd level"
                Case Else
                    text = "th level"
            End Select
            control.Text = Convert.ToString(intMaxLevel(i)) + text
        Next
        If character.GetClassLevel(strCasterArray(0)) = 1 Then
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt") = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt")
                strCurrentLine = objReader.ReadLine()
                strArray = Split(strCurrentLine, ",")
                Do While objReader.Peek <> -1
                    If strArray(0) = txtClass.Text Then
                        If strArray(1) = "slot1" Then
                            cboSpecial1.Enabled = True
                            lblSpecial1.Text = strArray(2)
                            cboSpecial1.Items.Add("")
                            For i = 3 To strArray.GetUpperBound(0)
                                cboSpecial1.Items.Add(strArray(i))
                            Next
                        End If
                        If strArray(1) = "slot2" Then
                            cboSpecial2.Enabled = True
                            lblSpecial2.Text = strArray(2)
                            cboSpecial2.Items.Add("")
                            For i = 3 To strArray.GetUpperBound(0)
                                cboSpecial2.Items.Add(strArray(i))
                            Next
                        End If
                        If strArray(1) = "slot3" Then
                            cboSpecial3.Enabled = True
                            lblSpecial3.Text = strArray(2)
                            cboSpecial3.Items.Add("")
                            For i = 3 To strArray.GetUpperBound(0)
                                cboSpecial3.Items.Add(strArray(i))
                            Next
                        End If
                        If strArray(1) = "slot4" Then
                            cboSpecial4.Enabled = True
                            lblSpecial4.Text = strArray(2)
                            cboSpecial4.Items.Add("")
                            For i = 3 To strArray.GetUpperBound(0)
                                cboSpecial4.Items.Add(strArray(i))
                            Next
                        End If
                    End If
                    strCurrentLine = objReader.ReadLine()
                    strArray = Split(strCurrentLine, ",")
                Loop
                objReader.Close()
            End If
        Else
            strcaster = Split(character.GetCasterString(strCasterArray(0)), ",")
            lblSpecial1.Visible = False
            cboSpecial1.Enabled = False
            cboSpecial1.Visible = False
            lblSpecial2.Visible = False
            cboSpecial2.Enabled = False
            cboSpecial2.Visible = False
            lblSpecial3.Visible = False
            cboSpecial3.Enabled = False
            cboSpecial3.Visible = False
            lblSpecial4.Visible = False
            cboSpecial4.Enabled = False
            cboSpecial4.Visible = False
            strClass = strcaster
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt") = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt")
                strCurrentLine = objReader.ReadLine()
                Do While objReader.Peek <> -1
                    strArray = Split(strCurrentLine, ",")
                    If strArray(0) = strClass(1) Then
                        Select Case strArray(1)
                            Case "slot1"
                                lblSpecial1.Visible = True
                                cboSpecial1.Enabled = True
                                cboSpecial1.Visible = True
                                lblSpecial1.Text = strArray(2) & ":"
                                cboSpecial1.Text = strClass(3)
                            Case "slot2"
                                lblSpecial2.Visible = True
                                cboSpecial2.Enabled = True
                                cboSpecial2.Visible = True
                                lblSpecial2.Text = strArray(2) & ":"
                                cboSpecial2.Text = strClass(4)
                            Case "slot3"
                                lblSpecial3.Visible = True
                                cboSpecial3.Enabled = True
                                cboSpecial3.Visible = True
                                lblSpecial3.Text = strArray(2) & ":"
                                cboSpecial3.Text = strClass(5)
                            Case "slot4"
                                lblSpecial4.Visible = True
                                cboSpecial4.Enabled = True
                                cboSpecial4.Visible = True
                                lblSpecial4.Text = strArray(2) & ":"
                                cboSpecial4.Text = strClass(6)
                        End Select
                    End If
                    strCurrentLine = objReader.ReadLine()
                Loop
            End If
        End If
        SpellFill()
    End Sub

    Private Sub cboFirstProhibited_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpecial2.SelectedIndexChanged
        SpellFill()
    End Sub

    Private Sub cboSecondProhibited_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpecial3.SelectedIndexChanged
        SpellFill()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim x As Integer = 0
        Dim StrCaster As String = ""
        Dim strSpells As String = ""
        Dim strArray(3) As String
        Dim strtype As String = "" 'the type of caster specifically whether they cast as a wizard or Sorcerer
        Dim i As Integer = 0
        If txtClass.Text = "Sorcerer" Or txtClass.Text = "Bard" Then
            strtype = "Sorcerer"
        Else
            strtype = "Wizard"
        End If
        StrCaster = txtClass.Text + "," + strtype + "," + txtLevel.Text
        If cboSpecial1.Text <> "" Then
            StrCaster += "," & cboSpecial1.Text
        Else
            StrCaster += ","
        End If
        If cboSpecial2.Text <> "" Then
            StrCaster += "," & cboSpecial2.Text
        Else
            StrCaster += ","
        End If
        If cboSpecial3.Text <> "" Then
            StrCaster += "," & cboSpecial3.Text
        Else
            StrCaster += ","
        End If
        If cboSpecial4.Text <> "" Then
            StrCaster += "," & cboSpecial4.Text
        Else
            StrCaster += ","
        End If
        If cmbSpell1.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(0)) + "," + cmbSpell1.Text)
        End If
        If cmbSpell2.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(1)) + "," + cmbSpell2.Text)
        End If
        If cmbSpell3.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(2)) + "," + cmbSpell3.Text)
        End If
        If cmbSpell4.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(3)) + "," + cmbSpell4.Text)
        End If
        If cmbSpell5.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(4)) + "," + cmbSpell5.Text)
        End If
        If cmbSpell6.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(5)) + "," + cmbSpell6.Text)
        End If
        If cmbSpell7.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(6)) + "," + cmbSpell7.Text)
        End If
        If cmbSpell8.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(7)) + "," + cmbSpell8.Text)
        End If
        If cmbSpell9.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(8)) + "," + cmbSpell9.Text)
        End If
        If cmbSpell10.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(9)) + "," + cmbSpell10.Text)
        End If
        If cmbSpell11.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(10)) + "," + cmbSpell11.Text)
        End If
        If cmbSpell12.Text <> "" Then
            character.colKnownSpells.Add(txtClass.Text + "," + Convert.ToString(intMaxLevel(11)) + "," + cmbSpell12.Text)
        End If
        If character.colCaster.Contains(txtClass.Text) Then
            character.colCaster.Remove(txtClass.Text)
        End If
        character.colCaster.Add(StrCaster, txtClass.Text)
        For i = 0 To 9
            If bolAllSpells(i) = True Then
                addAllSpells(i)
            End If
        Next
        Me.Close()
    End Sub
    Sub addAllSpells(ByVal intLevel As Integer)
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray(3) As String
        Dim int As Integer = 1
        Dim collection As New Collection
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt")
            strCurrentLine = objReader.ReadLine()
            strArray = Split(strCurrentLine, ",")
            Do While objReader.Peek <> -1
                If strArray(0) = Convert.ToString(intLevel) Then
                    If strArray(3) = txtClass.Text Then
                        character.colKnownSpells.Add(txtClass.Text + "," + strArray(0) + "," + strArray(1))
                        collection.Add(txtClass.Text + "," + strArray(0) + "," + strArray(1), int)
                        int += 1
                    End If
                End If
                strCurrentLine = objReader.ReadLine()
                strArray = Split(strCurrentLine, ",")
            Loop
            objReader.Close()
        End If
    End Sub

    Private Sub cboSpecial4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpecial4.SelectedIndexChanged
        SpellFill()
    End Sub
End Class