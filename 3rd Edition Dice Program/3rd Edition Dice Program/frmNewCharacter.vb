Option Strict On


Public Class frmNewCharacter
    Private intConhp As Integer
    Private MouseIsDown As Boolean = False
    'variable used to determine the source that is dragged from (it equals the roll num or 7 = str, 8 = dex, 9 = con, 10 = int, 11 = wis, 12 = cha)
    Private DragSource As Integer


    Private Function DiceRoll(ByVal intDiceNum As Integer, ByVal intDiceSize As Integer) As Integer
        Dim intRoll As Integer = 0
        ' This function returns the result of a simulated die or dice roll 
        Dim i As Integer
        For i = 1 To intDiceNum
            intRoll += Convert.ToInt32(((intDiceSize - 1) * Rnd()) + 1)
        Next
        Return intRoll
    End Function

    Private Function FinalCheck() As Boolean
        Dim strMessage As String = ""
        If Trim(txtName.Text) = "" Then
            strMessage += "name"
        End If
        If cboRace.SelectedIndex < 0 Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "race"
        End If
        If cboFirstLevel.SelectedIndex < 0 Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "class"
        End If
        If cboAlignment.SelectedIndex < 0 Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "alignment"
        End If
        If nudStr.Value = 0 And nudStr.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "strength"
        End If
        If nudDex.Value = 0 And nudDex.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "dexterity"
        End If
        If nudCon.Value = 0 And nudDex.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "constitution"
        End If
        If nudWis.Value = 0 And nudWis.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "wisdom"
        End If
        If nudInt.Value = 0 And nudInt.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "intelligence"
        End If
        If nudCha.Value = 0 And nudCha.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "charisma"
        End If
        If Trim(txtStr.Text) = "" And txtStr.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "strength"
        End If
        If Trim(txtDex.Text) = "" And txtDex.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "dexterity"
        End If
        If Trim(txtCon.Text) = "" And txtCon.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "constitution"
        End If
        If Trim(txtWis.Text) = "" And txtWis.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "wisdom"
        End If
        If Trim(txtInt.Text) = "" And txtInt.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "intelligence"
        End If
        If Trim(txtCha.Text) = "" And txtCha.Visible = True Then
            If strMessage <> "" Then
                strMessage += ", "
            End If
            strMessage += "charisma"
        End If
        If strMessage <> "" Then
            strMessage += " missing"
        End If
        If nudStr.Visible = True And Trim(txtPoints.Text) <> "0" Then
            If strMessage <> "" Then
                strMessage += ", and "
            End If
            strMessage += "ability points need to be used"
        End If
        If strMessage <> "" Then
            MessageBox.Show(strMessage, "Error")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub dragswap(ByVal strSource As String)
        Select Case DragSource
            Case 1
                txtRoll1.Text = strSource
            Case 2
                txtRoll2.Text = strSource
            Case 3
                txtRoll3.Text = strSource
            Case 4
                txtRoll4.Text = strSource
            Case 5
                txtRoll5.Text = strSource
            Case 6
                txtRoll6.Text = strSource
            Case 7
                txtStr.Text = strSource
            Case 8
                txtDex.Text = strSource
            Case 9
                txtCon.Text = strSource
            Case 10
                txtInt.Text = strSource
            Case 11
                txtWis.Text = strSource
            Case 12
                txtCha.Text = strSource
        End Select
    End Sub

    Private Sub frmNewCharacter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboDiceMode.SelectedIndex = 0
        Randomize()
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim intDiceTotal As Integer = 0
        Dim intLowestRoll As Integer = 6
        Dim intSecondLowestRoll As Integer = 6
        Dim intCurrentRoll As Integer
        Dim intRoll(4) As Integer
        Dim i As Integer
        Dim j As Integer
        Dim bolLoop As Boolean
        Dim intHolder As Integer
        Dim bolReroll As Boolean

        txtStr.Text = ""
        txtDex.Text = ""
        txtCon.Text = ""
        txtInt.Text = ""
        txtWis.Text = ""
        txtCha.Text = ""
        nudStr.Value = 0
        nudDex.Value = 0
        nudCon.Value = 0
        nudWis.Value = 0
        nudInt.Value = 0
        nudCha.Value = 0
        btnRerollStr.Enabled = False
        btnRerollDex.Enabled = False
        btnRerollCon.Enabled = False
        btnRerollWis.Enabled = False
        btnRerollInt.Enabled = False
        btnRerollCha.Enabled = False
        'determines the method selected for generating ability scores and implements it
        'the first one is if the user selects 4d6 drop the lowest
        If cboDiceMode.SelectedIndex = 0 Then
            For j = 1 To 6
                For i = 1 To 4
                    intCurrentRoll = DiceRoll(1, 6)
                    If intCurrentRoll < intLowestRoll Then
                        intLowestRoll = intCurrentRoll
                    End If
                    intDiceTotal += intCurrentRoll
                Next
                intDiceTotal -= intLowestRoll
                Select Case j
                    Case 1
                        txtRoll1.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtRoll2.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtRoll3.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtRoll4.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtRoll5.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtRoll6.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
            Next
        End If
        'this next mode is for 5d6 drop the two lowest
        If cboDiceMode.SelectedIndex = 1 Then
            For j = 1 To 6
                For i = 1 To 5
                    intCurrentRoll = DiceRoll(1, 6)
                    If intCurrentRoll < intSecondLowestRoll Then
                        If intCurrentRoll < intLowestRoll Then
                            intSecondLowestRoll = intLowestRoll
                            intLowestRoll = intCurrentRoll
                        Else
                            intSecondLowestRoll = intCurrentRoll
                        End If
                    End If
                    intDiceTotal += intCurrentRoll
                Next
                intDiceTotal = intDiceTotal - intLowestRoll - intSecondLowestRoll
                Select Case j
                    Case 1
                        txtRoll1.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtRoll2.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtRoll3.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtRoll4.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtRoll5.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtRoll6.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
                intSecondLowestRoll = 6
            Next
        End If
        'this is for the organic character mode
        If cboDiceMode.SelectedIndex = 2 Then
            For j = 1 To 6
                For i = 1 To 4
                    intCurrentRoll = DiceRoll(1, 6)
                    If intCurrentRoll < intLowestRoll Then
                        intLowestRoll = intCurrentRoll
                    End If
                    intDiceTotal += intCurrentRoll
                Next
                intDiceTotal = intDiceTotal - intLowestRoll
                Select Case j
                    Case 1
                        txtStr.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtDex.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtCon.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtInt.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtWis.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtCha.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
            Next
            btnRerollStr.Enabled = True
            btnRerollDex.Enabled = True
            btnRerollCon.Enabled = True
            btnRerollWis.Enabled = True
            btnRerollInt.Enabled = True
            btnRerollCha.Enabled = True
        End If
        '3d6 drop none
        If cboDiceMode.SelectedIndex = 3 Then
            For j = 1 To 6
                For i = 1 To 3
                    intCurrentRoll = DiceRoll(1, 6)
                    intDiceTotal += intCurrentRoll
                Next
                Select Case j
                    Case 1
                        txtRoll1.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtRoll2.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtRoll3.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtRoll4.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtRoll5.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtRoll6.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
            Next
        End If
        'this is for the in order organic character mode
        If cboDiceMode.SelectedIndex = 4 Then
            For j = 1 To 6
                For i = 1 To 3
                    intCurrentRoll = DiceRoll(1, 6)
                    intDiceTotal += intCurrentRoll
                Next
                Select Case j
                    Case 1
                        txtStr.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtDex.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtCon.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtInt.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtWis.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtCha.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
            Next
            btnRerollStr.Enabled = True
            btnRerollDex.Enabled = True
            btnRerollCon.Enabled = True
            btnRerollWis.Enabled = True
            btnRerollInt.Enabled = True
            btnRerollCha.Enabled = True
        End If
        If cboDiceMode.SelectedIndex = 5 Then
            bolReroll = False
            For j = 1 To 6
                For i = 1 To 4
                    intCurrentRoll = DiceRoll(1, 6)
                    intRoll(i - 1) = intCurrentRoll
                Next
                If bolReroll = False Then
                    If MessageBox.Show("Reroll lowest score? " + Convert.ToString(intRoll(0)) + ", " + Convert.ToString(intRoll(1)) + ", " + Convert.ToString(intRoll(2)) + ", " + Convert.ToString(intRoll(3)), "Floating Reroll", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        bolReroll = True
                        intCurrentRoll = DiceRoll(1, 6)
                        bolLoop = True
                        Do While bolLoop = True
                            bolLoop = False
                            If intRoll(0) < intRoll(1) Then
                                intHolder = intRoll(0)
                                intRoll(0) = intRoll(1)
                                intRoll(1) = intHolder
                                bolLoop = True
                            End If
                            If intRoll(1) < intRoll(2) Then
                                intHolder = intRoll(1)
                                intRoll(1) = intRoll(2)
                                intRoll(2) = intHolder
                                bolLoop = True
                            End If
                            If intRoll(2) < intRoll(3) Then
                                intHolder = intRoll(2)
                                intRoll(2) = intRoll(3)
                                intRoll(3) = intHolder
                                bolLoop = True
                            End If
                            If intRoll(3) < intRoll(4) Then
                                intHolder = intRoll(3)
                                intRoll(3) = intRoll(4)
                                intRoll(4) = intHolder
                                bolLoop = True
                            End If
                        Loop
                        If intRoll(4) < intCurrentRoll Then
                            intRoll(4) = intCurrentRoll
                        End If
                    End If
                End If
                bolLoop = True
                Do While bolLoop = True
                    bolLoop = False
                    If intRoll(0) < intRoll(1) Then
                        intHolder = intRoll(0)
                        intRoll(0) = intRoll(1)
                        intRoll(1) = intHolder
                        bolLoop = True
                    End If
                    If intRoll(1) < intRoll(2) Then
                        intHolder = intRoll(1)
                        intRoll(1) = intRoll(2)
                        intRoll(2) = intHolder
                        bolLoop = True
                    End If
                    If intRoll(2) < intRoll(3) Then
                        intHolder = intRoll(2)
                        intRoll(2) = intRoll(3)
                        intRoll(3) = intHolder
                        bolLoop = True
                    End If
                    If intRoll(3) < intRoll(4) Then
                        intHolder = intRoll(3)
                        intRoll(3) = intRoll(4)
                        intRoll(4) = intHolder
                        bolLoop = True
                    End If
                Loop
                intDiceTotal = intRoll(0) + intRoll(1) + intRoll(3)
                Select Case j
                    Case 1
                        txtRoll1.Text = Convert.ToString(intDiceTotal)
                    Case 2
                        txtRoll2.Text = Convert.ToString(intDiceTotal)
                    Case 3
                        txtRoll3.Text = Convert.ToString(intDiceTotal)
                    Case 4
                        txtRoll4.Text = Convert.ToString(intDiceTotal)
                    Case 5
                        txtRoll5.Text = Convert.ToString(intDiceTotal)
                    Case 6
                        txtRoll6.Text = Convert.ToString(intDiceTotal)
                End Select
                intDiceTotal = 0
                intLowestRoll = 6
            Next
        End If
    End Sub

    Private Sub btnAcceptScores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptScores.Click
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray(0) As String
        Dim strAbilities As String = ""
        Dim character As New Character.PC
        Dim intupperbounds As Integer
        Dim colFeatList As New Collection
        Dim colClasses As Collection = character.GetClassCollection
        Dim i As Integer
        Dim strClassArray() As String
        Dim strClass As String
        If FinalCheck() = True Then
            'hands all selected information back to the character sheet and closes the new character form
            character.strName = txtName.Text
            If cboDiceMode.SelectedIndex <> 6 Then
                character.StatSet("str", Convert.ToInt32(txtStr.Text))
                character.StatSet("dex", Convert.ToInt32(txtDex.Text))
                character.StatSet("con", Convert.ToInt32(txtCon.Text))
                character.StatSet("wis", Convert.ToInt32(txtWis.Text))
                character.StatSet("int", Convert.ToInt32(txtInt.Text))
                character.StatSet("cha", Convert.ToInt32(txtCha.Text))
            Else
                character.StatSet("str", Convert.ToInt32(nudStr.Value))
                character.StatSet("dex", Convert.ToInt32(nudDex.Value))
                character.StatSet("con", Convert.ToInt32(nudCon.Value))
                character.StatSet("wis", Convert.ToInt32(nudWis.Value))
                character.StatSet("int", Convert.ToInt32(nudInt.Value))
                character.StatSet("cha", Convert.ToInt32(nudCha.Value))
            End If
            character.strRace = cboRace.SelectedItem.ToString
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassLevelUp.txt") = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassLevelUp.txt")
                strCurrentLine = objReader.ReadLine()

                ReDim strArray(NumOfItems(strCurrentLine))
                strArray = Split(strCurrentLine, ",")
                objReader.Close()
            End If
            strClassArray = Split(cboFirstLevel.Text)
            strClass = strClassArray(0)
            character.LevelUp(Convert.ToString(strClass), False)
            character.AddNewFeatList("race", character.strRace)
            strAbilities = frmSkills.chain(Convert.ToString(cboFirstLevel.SelectedItem), "ClassLevelUp.txt", True)
            intupperbounds = NumOfItems(strAbilities)
            ReDim strArray(intupperbounds)
            strArray = Split(strAbilities, ",")
            For i = 1 To intupperbounds - 1
                If strArray(i) = "Special" Then
                    character.colSpecials.Add(strArray(i + 1))
                End If
                If strArray(i) = "Feat" Then
                    character.AddFeat(strArray(i + 1))
                End If
                If strArray(i) = "FeatOption" Then
                    character.AddNewFeatList("class", strArray(i + 1))
                End If
                If strArray(i) = "FeatOptionNP" Then
                    character.AddNewFeatList("classNP", strArray(i + 1))
                End If
                i += 1
            Next


            character.strAlignment = cboAlignment.SelectedItem.ToString
            frmCharacterSheet.btnAddXP.Enabled = True
            frmCharacterSheet.btnAddItems.Enabled = True
            frmCharacterSheet.character = character
            frmCharacterSheet.bolEquipEnable = False
            frmCharacterSheet.equip()
            frmCharacterSheet.bolEquipEnable = True
            frmCharacterSheet.EnableControls()
            Me.Close()
        End If
    End Sub

    Private Sub txtRoll1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll1.DragDrop
        Dim strText As String
        strText = txtRoll1.Text
        txtRoll1.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll1.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll1.MouseMove
        If MouseIsDown Then
            DragSource = 1
            ' Initiate dragging.
            txtRoll1.DoDragDrop(txtRoll1.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtStr_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtStr.DragDrop
        Dim strText As String
        strText = txtStr.Text
        txtStr.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtStr_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtStr.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub cboDiceMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDiceMode.SelectedIndexChanged
        txtRoll1.Text = ""
        txtRoll2.Text = ""
        txtRoll3.Text = ""
        txtRoll4.Text = ""
        txtRoll5.Text = ""
        txtRoll6.Text = ""
        txtStr.Text = ""
        txtDex.Text = ""
        txtCon.Text = ""
        txtInt.Text = ""
        txtWis.Text = ""
        txtCha.Text = ""
        nudStr.Value = 0
        nudDex.Value = 0
        nudCon.Value = 0
        nudWis.Value = 0
        nudInt.Value = 0
        nudCha.Value = 0
        btnRerollStr.Enabled = False
        btnRerollDex.Enabled = False
        btnRerollCon.Enabled = False
        btnRerollWis.Enabled = False
        btnRerollInt.Enabled = False
        btnRerollCha.Enabled = False
        txtStr.Visible = True
        txtDex.Visible = True
        txtCon.Visible = True
        txtInt.Visible = True
        txtWis.Visible = True
        txtCha.Visible = True
        'depending on which item selected turn on controls used by the dice method selected and hides unnecessary controls
        Select Case cboDiceMode.SelectedIndex
            Case 0
                txtRoll1.Visible = True
                txtRoll2.Visible = True
                txtRoll3.Visible = True
                txtRoll4.Visible = True
                txtRoll5.Visible = True
                txtRoll6.Visible = True
                btnRerollStr.Visible = False
                btnRerollDex.Visible = False
                btnRerollCon.Visible = False
                btnRerollInt.Visible = False
                btnRerollWis.Visible = False
                btnRerollCha.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = "This is the standard choice for rolling characters"
            Case 1
                txtRoll1.Visible = True
                txtRoll2.Visible = True
                txtRoll3.Visible = True
                txtRoll4.Visible = True
                txtRoll5.Visible = True
                txtRoll6.Visible = True
                btnRerollStr.Visible = False
                btnRerollDex.Visible = False
                btnRerollCon.Visible = False
                btnRerollInt.Visible = False
                btnRerollWis.Visible = False
                btnRerollCha.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = "This method generates high powered characters"
            Case 2
                btnRerollStr.Visible = True
                btnRerollStr.Enabled = False
                btnRerollDex.Visible = True
                btnRerollDex.Enabled = False
                btnRerollCon.Visible = True
                btnRerollCon.Enabled = False
                btnRerollInt.Visible = True
                btnRerollInt.Enabled = False
                btnRerollWis.Visible = True
                btnRerollWis.Enabled = False
                btnRerollCha.Visible = True
                btnRerollCha.Enabled = False
                txtRoll1.Visible = False
                txtRoll2.Visible = False
                txtRoll3.Visible = False
                txtRoll4.Visible = False
                txtRoll5.Visible = False
                txtRoll6.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = ""
            Case 3
                txtRoll1.Visible = True
                txtRoll2.Visible = True
                txtRoll3.Visible = True
                txtRoll4.Visible = True
                txtRoll5.Visible = True
                txtRoll6.Visible = True
                btnRerollStr.Visible = False
                btnRerollDex.Visible = False
                btnRerollCon.Visible = False
                btnRerollInt.Visible = False
                btnRerollWis.Visible = False
                btnRerollCha.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = "This method generates characters that are as powerful as the average person."
            Case 4
                btnRerollStr.Visible = True
                btnRerollStr.Enabled = False
                btnRerollDex.Visible = True
                btnRerollDex.Enabled = False
                btnRerollCon.Visible = True
                btnRerollCon.Enabled = False
                btnRerollInt.Visible = True
                btnRerollInt.Enabled = False
                btnRerollWis.Visible = True
                btnRerollWis.Enabled = False
                btnRerollCha.Visible = True
                btnRerollCha.Enabled = False
                txtRoll1.Visible = False
                txtRoll2.Visible = False
                txtRoll3.Visible = False
                txtRoll4.Visible = False
                txtRoll5.Visible = False
                txtRoll6.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = ""
            Case 5
                txtRoll1.Visible = True
                txtRoll2.Visible = True
                txtRoll3.Visible = True
                txtRoll4.Visible = True
                txtRoll5.Visible = True
                txtRoll6.Visible = True
                btnRerollStr.Visible = False
                btnRerollDex.Visible = False
                btnRerollCon.Visible = False
                btnRerollInt.Visible = False
                btnRerollWis.Visible = False
                btnRerollCha.Visible = False
                lblPoints.Visible = False
                txtPoints.Visible = False
                nudStr.Visible = False
                nudDex.Visible = False
                nudCon.Visible = False
                nudWis.Visible = False
                nudInt.Visible = False
                nudCha.Visible = False
                txtDescription.Text = "This is the standard choice for rolling characters plus you can reroll one die"
            Case 6
                txtStr.Visible = False
                txtDex.Visible = False
                txtCon.Visible = False
                txtInt.Visible = False
                txtWis.Visible = False
                txtCha.Visible = False
                lblPoints.Visible = True
                txtPoints.Visible = True
                nudStr.Visible = True
                nudDex.Visible = True
                nudCon.Visible = True
                nudWis.Visible = True
                nudInt.Visible = True
                nudCha.Visible = True
                nudStr.Value = 8
                nudDex.Value = 8
                nudCon.Value = 8
                nudInt.Value = 8
                nudWis.Value = 8
                nudCha.Value = 8
                txtPoints.Text = "25"
                txtRoll1.Visible = False
                txtRoll2.Visible = False
                txtRoll3.Visible = False
                txtRoll4.Visible = False
                txtRoll5.Visible = False
                txtRoll6.Visible = False
                btnRerollStr.Visible = False
                btnRerollDex.Visible = False
                btnRerollCon.Visible = False
                btnRerollInt.Visible = False
                btnRerollWis.Visible = False
                btnRerollCha.Visible = False
                txtDescription.Text = "Use the points remaining to improve scores"
        End Select
    End Sub

    Private Sub txtDex_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtDex.DragDrop
        Dim strText As String
        strText = txtDex.Text
        txtDex.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtCon_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCon.DragDrop
        Dim strText As String
        strText = txtCon.Text
        txtCon.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtInt_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtInt.DragDrop
        Dim strText As String
        strText = txtInt.Text
        txtInt.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtWis_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtWis.DragDrop
        Dim strText As String
        strText = txtWis.Text
        txtWis.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtCha_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCha.DragDrop
        Dim strText As String
        strText = txtCha.Text
        txtCha.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtDex_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtDex.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtCon_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCon.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtWis_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtWis.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtInt_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtInt.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtCha_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCha.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll2.DragDrop
        Dim strText As String
        strText = txtRoll2.Text
        txtRoll2.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll2.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll2.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll3.DragDrop
        Dim strText As String
        strText = txtRoll3.Text
        txtRoll3.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll3_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll3.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll3.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll4.DragDrop
        Dim strText As String
        strText = txtRoll4.Text
        txtRoll4.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll4_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll4.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll4.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll5.DragDrop
        Dim strText As String
        strText = txtRoll5.Text
        txtRoll5.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll5_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll5.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll5.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll6.DragDrop
        Dim strText As String
        strText = txtRoll6.Text
        txtRoll6.Text = e.Data.GetData(DataFormats.Text).ToString
        dragswap(strText)
    End Sub

    Private Sub txtRoll6_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRoll6.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRoll6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll6.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRoll2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll2.MouseMove
        If MouseIsDown Then
            DragSource = 2
            ' Initiate dragging.
            txtRoll2.DoDragDrop(txtRoll2.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRoll3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll3.MouseMove
        If MouseIsDown Then
            ' Initiate dragging.
            DragSource = 3
            txtRoll3.DoDragDrop(txtRoll3.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRoll4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll4.MouseMove
        If MouseIsDown Then
            DragSource = 4
            ' Initiate dragging.
            txtRoll4.DoDragDrop(txtRoll4.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRoll5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll5.MouseMove
        If MouseIsDown Then
            DragSource = 5
            ' Initiate dragging.
            txtRoll5.DoDragDrop(txtRoll5.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRoll6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRoll6.MouseMove
        If MouseIsDown Then
            DragSource = 6
            ' Initiate dragging.
            txtRoll6.DoDragDrop(txtRoll6.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtStr_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtStr.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtDex_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDex.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtCon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCon.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtInt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInt.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtWis_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtWis.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtCha_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCha.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtStr_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtStr.MouseMove
        If MouseIsDown Then
            DragSource = 7
            ' Initiate dragging.
            txtStr.DoDragDrop(txtStr.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtDex_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDex.MouseMove
        If MouseIsDown Then
            DragSource = 8
            ' Initiate dragging.
            txtDex.DoDragDrop(txtDex.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtCon_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCon.MouseMove
        If MouseIsDown Then
            DragSource = 9
            ' Initiate dragging.
            txtCon.DoDragDrop(txtCon.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtInt_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInt.MouseMove
        If MouseIsDown Then
            DragSource = 10
            ' Initiate dragging.
            txtInt.DoDragDrop(txtInt.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtWis_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtWis.MouseMove
        If MouseIsDown Then
            DragSource = 11
            ' Initiate dragging.
            txtWis.DoDragDrop(txtWis.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtCha_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCha.MouseMove
        If MouseIsDown Then
            DragSource = 12
            ' Initiate dragging.
            txtCha.DoDragDrop(txtCha.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub cboFirstLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirstLevel.SelectedIndexChanged
        Dim strSplit(3) As String
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim z As Integer = 0
        Dim d As Integer = 0
        Dim k As Integer = 0

        Select Case Convert.ToString(cboFirstLevel.SelectedItem)
            Case "Barbarian lvl 1"
                txtStartHp.Text = "12"
            Case "Bard lvl 1"
                txtStartHp.Text = "8"
            Case "Cleric lvl 1"
                txtStartHp.Text = "8"
            Case "Druid lvl 1"
                txtStartHp.Text = "8"
            Case "Fighter lvl 1"
                txtStartHp.Text = "10"
            Case "Monk lvl 1"
                txtStartHp.Text = "8"
            Case "Paladin lvl 1"
                txtStartHp.Text = "10"
            Case "Rogue lvl 1"
                txtStartHp.Text = "6"
            Case "Sorcerer lvl 1"
                txtStartHp.Text = "4"
            Case "Wizard lvl 1"
                txtStartHp.Text = "4"
        End Select
    End Sub
    Private Function NumOfItems(ByVal strSearch As String) As Integer
        Dim intPosition As Integer
        Dim intStart As Integer = 1
        Dim intCount As Integer = 0
        Do
            intPosition = InStr(intStart, strSearch, ",")
            intStart = intPosition + 1
            intCount += 1
        Loop Until intPosition = 0
        Return intCount
    End Function
    
    Private Sub cboRace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRace.SelectedIndexChanged
        
    End Sub

    Private Sub txtRoll1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRoll1.TextChanged

    End Sub
    Private Sub PointsChanged(ByRef nudScore As NumericUpDown)
        Dim intPoints As Integer = 0
        If nudScore.Value < 8 Then
            nudScore.Value = 8
        End If
        If nudScore.Value > 18 Then
            nudScore.Value = 18
        End If
        intPoints += Convert.ToInt32(nudStr.Value) - 8
        If nudStr.Value > 14 Then
            intPoints += Convert.ToInt32(nudStr.Value) - 14
        End If
        If nudStr.Value > 16 Then
            intPoints += Convert.ToInt32(nudStr.Value) - 16
        End If
        intPoints += Convert.ToInt32(nudDex.Value) - 8
        If nudDex.Value > 14 Then
            intPoints += Convert.ToInt32(nudDex.Value) - 14
        End If
        If nudDex.Value > 16 Then
            intPoints += Convert.ToInt32(nudDex.Value) - 16
        End If
        intPoints += Convert.ToInt32(nudCon.Value) - 8
        If nudCon.Value > 14 Then
            intPoints += Convert.ToInt32(nudCon.Value) - 14
        End If
        If nudCon.Value > 16 Then
            intPoints += Convert.ToInt32(nudCon.Value) - 16
        End If
        intPoints += Convert.ToInt32(nudInt.Value) - 8
        If nudInt.Value > 14 Then
            intPoints += Convert.ToInt32(nudInt.Value) - 14
        End If
        If nudInt.Value > 16 Then
            intPoints += Convert.ToInt32(nudInt.Value) - 16
        End If
        intPoints += Convert.ToInt32(nudWis.Value) - 8
        If nudWis.Value > 14 Then
            intPoints += Convert.ToInt32(nudWis.Value) - 14
        End If
        If nudWis.Value > 16 Then
            intPoints += Convert.ToInt32(nudWis.Value) - 16
        End If
        intPoints += Convert.ToInt32(nudCha.Value) - 8
        If nudCha.Value > 14 Then
            intPoints += Convert.ToInt32(nudCha.Value) - 14
        End If
        If nudCha.Value > 16 Then
            intPoints += Convert.ToInt32(nudCha.Value) - 16
        End If
        If intPoints > 25 Then
            nudScore.Value -= 1
        End If
        If intPoints >= 25 Then
            txtPoints.Text = "0"
        Else
            txtPoints.Text = Convert.ToString(25 - intPoints)
        End If
    End Sub

    Private Sub nudStr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStr.ValueChanged
        PointsChanged(nudStr)
    End Sub

    Private Sub nudDex_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDex.ValueChanged
        PointsChanged(nudDex)
    End Sub

    Private Sub nudCon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCon.ValueChanged
        PointsChanged(nudCon)
    End Sub

    Private Sub nudInt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudInt.ValueChanged
        PointsChanged(nudInt)
    End Sub

    Private Sub nudWis_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudWis.ValueChanged
        PointsChanged(nudWis)
    End Sub

    Private Sub nudCha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCha.ValueChanged
        PointsChanged(nudCha)
    End Sub

    Private Sub btnRerollStr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollStr.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtStr.Text = Convert.ToString(intDiceTotal)
    End Sub

    Private Sub btnRerollDex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollDex.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtDex.Text = Convert.ToString(intDiceTotal)
    End Sub

    Private Sub btnRerollCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollCon.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtCon.Text = Convert.ToString(intDiceTotal)
    End Sub

    Private Sub btnRerollInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollInt.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtInt.Text = Convert.ToString(intDiceTotal)
    End Sub

    Private Sub btnRerollWis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollWis.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtWis.Text = Convert.ToString(intDiceTotal)
    End Sub

    Private Sub btnRerollCha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRerollCha.Click
        Dim i As Integer
        Dim intCurrentRoll As Integer
        Dim intLowestRoll As Integer
        Dim intDiceTotal As Integer
        For i = 1 To 4
            intCurrentRoll = DiceRoll(1, 6)
            If intCurrentRoll < intLowestRoll Then
                intLowestRoll = intCurrentRoll
            End If
            intDiceTotal += intCurrentRoll
        Next
        intDiceTotal = intDiceTotal - intLowestRoll
        txtCha.Text = Convert.ToString(intDiceTotal)
    End Sub
End Class