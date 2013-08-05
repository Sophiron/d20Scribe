Public Class frmSpellSheet
    Public intCurrentCaster As Integer
    Public intSpellsPerDay(10) As Integer
    Public character As Character.PC
    Public strClass(6) As String
    Public MouseIsDown As Boolean = False
    Public ListBoxSelected As ListBox
    Public TextBoxSelected As TextBox
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
    Sub SpellMemorize(ByVal ListBox As ListBox, ByVal strSpell As String, ByVal intLevel As Integer, ByVal txtspecial As TextBox)
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray(4) As String
        Dim bolspecial As Boolean = False 'whether it has been added to the specialization box or not
        If strClass(1) = "Wizard" Then
            If txtspecial.Text = "" And txtSpecial1.Text <> "" Then
                If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt") = True Then
                    objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt")
                    strCurrentLine = objReader.ReadLine()
                    strArray = Split(strCurrentLine, ",")
                    Do While objReader.Peek <> -1
                        If strSpell = strArray(1) And strArray(2) = txtSpecial1.Text Then
                            txtspecial.Text = strSpell
                            bolspecial = True
                        End If
                        strCurrentLine = objReader.ReadLine()
                        strArray = Split(strCurrentLine, ",")
                    Loop
                    objReader.Close()
                End If
            End If
            If txtspecial.Text <> "" And bolspecial = False Then
                If ListBox.Items.Count < intSpellsPerDay(intLevel) - 1 Then
                    ListBox.Items.Add(strSpell)
                    character.colUnusedSpells.Add(txtClass.Text + "," + Convert.ToString(intLevel) + "," + strSpell)
                End If
            Else
                If ListBox.Items.Count < intSpellsPerDay(intLevel) Then
                    If bolspecial = False Then
                        ListBox.Items.Add(strSpell)
                    Else
                        txtspecial.Text = strSpell
                    End If
                    character.colUnusedSpells.Add(txtClass.Text + "," + Convert.ToString(intLevel) + "," + strSpell)
                End If
            End If
        End If
    End Sub
    Function FindSpell(ByVal strspell As String, ByVal strCaster As String)
        Dim strCurrentSearchItem As String = ""
        Dim strArray(0) As String
        Dim objReader As IO.StreamReader
        Dim bolFound As Boolean = False
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\Spells.txt")
            Do
                strCurrentSearchItem = objReader.ReadLine()
                ReDim strArray(frmCharacterSheet.NumOfItems(strCurrentSearchItem))
                strArray = Split(strCurrentSearchItem, ",")
                If objReader.Peek = -1 And strArray(0) <> strspell Then
                    MessageBox.Show(strspell & " was not found", "Spells.txt: Error")
                    Return ""
                End If
                If strArray.Length > 1 Then
                    If strArray(1) = strspell And strArray(3) = strCaster Then
                        bolFound = True
                    End If
                Else
                    If strArray(0) = strspell Then
                        bolFound = True
                    End If
                End If
            Loop Until bolFound
        End If
        Return strCurrentSearchItem
    End Function
    Sub SetContextMenu(ByVal StrSpell As String, ByVal intSlotLevel As Integer, ByVal strCaster As String)
        Dim ToolStripItem As ToolStripMenuItem
        Dim strMetamagicFeat As String
        Dim strArray() As String
        Dim objReader As IO.StreamReader
        Dim strReader As String = ""
        Dim intSpellLevel As Integer
        Dim intDifference As Integer
        Dim strArray2() As String
        Dim strCasterArray() As String
        strCasterArray = Split(character.colCaster(intCurrentCaster), ",")
        If strCasterArray(1) <> "Sorcerer" Then
            For Each ToolStripItem In ContextMenuStrip1.Items
                strMetamagicFeat = ToolStripItem.Name
                If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Metamagic.txt") = True Then
                    objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\Metamagic.txt")
                    strReader = objReader.ReadLine()
                    strArray = Split(strReader, ",")
                    Do While objReader.Peek <> -1 And strArray(0) <> strMetamagicFeat
                        strReader = objReader.ReadLine()
                        strArray = Split(strReader, ",")
                    Loop
                    strArray2 = Split(FindSpell(StrSpell, strClass(1)), ",")
                    intDifference = intSlotLevel - intSpellLevel
                    intSpellLevel = Convert.ToInt32(strArray2(0))
                    If strArray(0) = strMetamagicFeat And Convert.ToInt32(strArray(1) <= intDifference) Then
                        ToolStripItem.Visible = True
                    Else
                        ToolStripItem.Visible = False
                    End If
                    objReader.Close()
                End If
            Next
        End If
    End Sub
    Sub clearall()
        lstSpells0.Items.Clear()
        lstSpells1.Items.Clear()
        lstSpells2.Items.Clear()
        lstSpells3.Items.Clear()
        lstSpells4.Items.Clear()
        lstSpells5.Items.Clear()
        lstSpells6.Items.Clear()
        lstSpells7.Items.Clear()
        lstSpells8.Items.Clear()
        lstSpells9.Items.Clear()
        lstUncast0.Items.Clear()
        lstUncast1.Items.Clear()
        lstUncast2.Items.Clear()
        lstUncast3.Items.Clear()
        lstUncast4.Items.Clear()
        lstUncast5.Items.Clear()
        lstUncast6.Items.Clear()
        lstUncast7.Items.Clear()
        lstUncast8.Items.Clear()
        lstUncast9.Items.Clear()
        txtSpecialization0.Clear()
        txtSpecialization1.Clear()
        txtSpecialization2.Clear()
        txtSpecialization3.Clear()
        txtSpecialization4.Clear()
        txtSpecialization5.Clear()
        txtSpecialization6.Clear()
        txtSpecialization7.Clear()
        txtSpecialization8.Clear()
        txtSpecialization9.Clear()

    End Sub
    Private Sub Populate(ByVal strClass() As String)
        Dim strknown(3) As String
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray() As String
        clearall()
        txtClass.Text = strClass(0)
        lblSpecial1.Visible = False
        txtSpecial1.Enabled = False
        txtSpecial1.Visible = False
        lblSpecial2.Visible = False
        txtSpecial2.Enabled = False
        txtSpecial2.Visible = False
        lblSpecial3.Visible = False
        txtSpecial3.Enabled = False
        txtSpecial3.Visible = False
        lblSpecial4.Visible = False
        txtSpecial4.Enabled = False
        txtSpecial4.Visible = False
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\CasterSpecializations.txt")
            strCurrentLine = objReader.ReadLine()
            Do While objReader.Peek <> -1
                strArray = Split(strCurrentLine, ",")
                If strArray(0) = strClass(0) Then
                    Select Case strArray(1)
                        Case "slot1"
                            lblSpecial1.Visible = True
                            txtSpecial1.Enabled = True
                            txtSpecial1.Visible = True
                            lblSpecial1.Text = strArray(2) & ":"
                            txtSpecial1.Text = strClass(3)
                        Case "slot2"
                            lblSpecial2.Visible = True
                            txtSpecial2.Enabled = True
                            txtSpecial2.Visible = True
                            lblSpecial2.Text = strArray(2) & ":"
                            txtSpecial2.Text = strClass(4)
                        Case "slot3"
                            lblSpecial3.Visible = True
                            txtSpecial3.Enabled = True
                            txtSpecial3.Visible = True
                            lblSpecial3.Text = strArray(2) & ":"
                            txtSpecial3.Text = strClass(5)
                        Case "slot4"
                            lblSpecial4.Visible = True
                            txtSpecial4.Enabled = True
                            txtSpecial4.Visible = True
                            lblSpecial4.Text = strArray(2) & ":"
                            txtSpecial4.Text = strClass(6)
                    End Select
                End If
                strCurrentLine = objReader.ReadLine()
            Loop
            objReader.Close()
        End If

        For Each strSpell As String In Character.colKnownSpells
            strknown = Split(strSpell, ",")
            If strknown(0) = strClass(0) Then
                Select Case strknown(1)
                    Case 0
                        lstSpells0.Items.Add(strknown(2))
                    Case 1
                        lstSpells1.Items.Add(strknown(2))
                    Case 2
                        lstSpells2.Items.Add(strknown(2))
                    Case 3
                        lstSpells3.Items.Add(strknown(2))
                    Case 4
                        lstSpells4.Items.Add(strknown(2))
                    Case 5
                        lstSpells5.Items.Add(strknown(2))
                    Case 6
                        lstSpells6.Items.Add(strknown(2))
                    Case 7
                        lstSpells7.Items.Add(strknown(2))
                    Case 8
                        lstSpells8.Items.Add(strknown(2))
                    Case 9
                        lstSpells9.Items.Add(strknown(2))
                End Select
            End If
        Next
        If strClass(1) = "Wizard" Then
            For Each strSpell As String In character.colUnusedSpells
                strknown = Split(strSpell, ",")
                If strknown(0) = strClass(1) Then
                    Select Case strknown(1)
                        Case 0
                            lstUncast0.Items.Add(strknown(2))
                        Case 1
                            lstUncast1.Items.Add(strknown(2))
                        Case 2
                            lstUncast2.Items.Add(strknown(2))
                        Case 3
                            lstUncast3.Items.Add(strknown(2))
                        Case 4
                            lstUncast4.Items.Add(strknown(2))
                        Case 5
                            lstUncast5.Items.Add(strknown(2))
                        Case 6
                            lstUncast6.Items.Add(strknown(2))
                        Case 7
                            lstUncast7.Items.Add(strknown(2))
                        Case 8
                            lstUncast8.Items.Add(strknown(2))
                        Case 9
                            lstUncast9.Items.Add(strknown(2))
                    End Select
                End If
            Next
        Else
            If character.CheckSorcererSpells(0) Then
                lstUncast0.Items.Add(Convert.ToString(character.GetSorcererSpells(0)) + " spells left")
            Else
                lstUncast0.Items.Add(Convert.ToString(intSpellsPerDay(0)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(0)) + " 0 Level")
            End If
            If character.CheckSorcererSpells(1) Then
                lstUncast1.Items.Add(Convert.ToString(character.GetSorcererSpells(1)) + " spells left")
            Else
                lstUncast1.Items.Add(Convert.ToString(intSpellsPerDay(1)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(1)) + " 1 Level")
            End If
            If character.CheckSorcererSpells(2) Then
                lstUncast2.Items.Add(Convert.ToString(character.GetSorcererSpells(2)) + " spells left")
            Else
                lstUncast2.Items.Add(Convert.ToString(intSpellsPerDay(2)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(2)) + " 2 Level")
            End If
            If character.CheckSorcererSpells(3) Then
                lstUncast3.Items.Add(Convert.ToString(character.GetSorcererSpells(3)) + " spells left")
            Else
                lstUncast3.Items.Add(Convert.ToString(intSpellsPerDay(3)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(3)) + " 3 Level")
            End If
            If character.CheckSorcererSpells(4) Then
                lstUncast4.Items.Add(Convert.ToString(character.GetSorcererSpells(4)) + " spells left")
            Else
                lstUncast4.Items.Add(Convert.ToString(intSpellsPerDay(4)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(4)) + " 4 Level")
            End If
            If character.CheckSorcererSpells(5) Then
                lstUncast5.Items.Add(Convert.ToString(character.GetSorcererSpells(5)) + " spells left")
            Else
                lstUncast5.Items.Add(Convert.ToString(intSpellsPerDay(5)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(5)) + " 5 Level")
            End If
            If character.CheckSorcererSpells(6) Then
                lstUncast6.Items.Add(Convert.ToString(character.GetSorcererSpells(6)) + " spells left")
            Else
                lstUncast6.Items.Add(Convert.ToString(intSpellsPerDay(6)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(6)) + " 6 Level")
            End If
            If character.CheckSorcererSpells(7) Then
                lstUncast7.Items.Add(Convert.ToString(character.GetSorcererSpells(7)) + " spells left")
            Else
                lstUncast7.Items.Add(Convert.ToString(intSpellsPerDay(7)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(7)) + " 7 Level")
            End If
            If character.CheckSorcererSpells(8) Then
                lstUncast8.Items.Add(Convert.ToString(character.GetSorcererSpells(8)) + " spells left")
            Else
                lstUncast8.Items.Add(Convert.ToString(intSpellsPerDay(8)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(8)) + " 8 Level")
            End If
            If character.CheckSorcererSpells(9) Then
                lstUncast9.Items.Add(Convert.ToString(character.GetSorcererSpells(9)) + " spells left")
            Else
                lstUncast9.Items.Add(Convert.ToString(intSpellsPerDay(9)) + " spells left")
                character.colUnusedSpells.Add(Convert.ToString(intSpellsPerDay(9)) + " 9 Level")
            End If
        End If
    End Sub
    Private Sub CastSpell(ByRef lstbox As ListBox, ByVal intSpellLevel As Integer)
        Dim strLine As String
        Dim strArray() As String
        If strClass(1) = "Wizard" Then
            character.castspell(txtClass.Text + "," + Convert.ToString(intSpellLevel) + "," + lstbox.Text, strClass(1))
            lstbox.Items.Remove(lstbox.SelectedItem)
        Else
            character.castspell(Convert.ToString(intSpellLevel), "Sorcerer")
            strLine = lstbox.Text
            strArray = Split(strLine)
            strArray(0) = Convert.ToString(Convert.ToInt16(strArray(0)) - 1)
            lstbox.Items.Clear()
            strLine = ""
            For Each strElement As String In strArray
                strLine += strElement + " "
            Next
            lstbox.Items.Add(strLine)
        End If
    End Sub

    Private Sub frmSpellSheet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim strSpell As String
        'Dim listBox As ListBox
        'Dim listcollection As New Collection
        'Dim strSpellLevel As String = ""
        'listcollection.Add(lstUncast0)
        'listcollection.Add(lstUncast1)
        'listcollection.Add(lstUncast2)
        'listcollection.Add(lstUncast3)
        'listcollection.Add(lstUncast4)
        'listcollection.Add(lstUncast5)
        'listcollection.Add(lstUncast6)
        'listcollection.Add(lstUncast7)
        'listcollection.Add(lstUncast8)
        'listcollection.Add(lstUncast9)
        'For Each listBox In listcollection
        '    If listBox.Name = "lstUncast0" Then
        '        strSpellLevel = 0
        '    End If
        '    If listBox.Name = "lstUncast1" Then
        '        strSpellLevel = 1
        '    End If
        '    If listBox.Name = "lstUncast2" Then
        '        strSpellLevel = 2
        '    End If
        '    If listBox.Name = "lstUncast3" Then
        '        strSpellLevel = 3
        '    End If
        '    If listBox.Name = "lstUncast4" Then
        '        strSpellLevel = 4
        '    End If
        '    If listBox.Name = "lstUncast5" Then
        '        strSpellLevel = 5
        '    End If
        '    If listBox.Name = "lstUncast6" Then
        '        strSpellLevel = 6
        '    End If
        '    If listBox.Name = "lstUncast7" Then
        '        strSpellLevel = 7
        '    End If
        '    If listBox.Name = "lstUncast8" Then
        '        strSpellLevel = 8
        '    End If
        '    If listBox.Name = "lstUncast9" Then
        '        strSpellLevel = 9
        '    End If
        '    For Each strSpell In listBox.Items
        '        frmCharacterSheet.colUnusedSpells.Add(txtClass.Text & "," & strSpellLevel & "," & strSpell)
        '    Next
        'Next
    End Sub
    Private Sub frmSpellSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strNew As String
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        intCurrentCaster = 1
        character = frmCharacterSheet.character
        strNew = New String(character.colCaster.Item(intCurrentCaster))
        strClass = Split(strNew, ",")
        LoadCaster(strClass)
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If intCurrentCaster < character.colCaster.Count Then
            intCurrentCaster += 1
            strClass = Split(character.colCaster.Item(intCurrentCaster), ",")
            LoadCaster(strClass)
        End If
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If intCurrentCaster > 1 Then
            intCurrentCaster -= 1
            strClass = Split(character.colCaster.Item(intCurrentCaster), ",")
            LoadCaster(strClass)
        End If
    End Sub

    Private Sub lstSpells0_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells0.MouseDoubleClick
        SpellMemorize(lstUncast0, lstSpells0.Text, 0, txtSpecialization0)
    End Sub

    Private Sub lstSpells1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells1.MouseDoubleClick
        SpellMemorize(lstUncast1, lstSpells1.Text, 1, txtSpecialization1)
    End Sub

    Private Sub lstSpells2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells2.MouseDoubleClick
        SpellMemorize(lstUncast2, lstSpells2.Text, 2, txtSpecialization2)
    End Sub

    Private Sub lstSpells3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells3.MouseDoubleClick
        SpellMemorize(lstUncast3, lstSpells3.Text, 3, txtSpecialization3)
    End Sub

    Private Sub lstSpells4_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells4.MouseDoubleClick
        SpellMemorize(lstUncast4, lstSpells4.Text, 4, txtSpecialization4)
    End Sub

    Private Sub lstSpells5_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells5.MouseDoubleClick
        SpellMemorize(lstUncast5, lstSpells5.Text, 5, txtSpecialization5)
    End Sub

    Private Sub lstSpells6_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells6.MouseDoubleClick
        SpellMemorize(lstUncast6, lstSpells6.Text, 6, txtSpecialization6)
    End Sub

    Private Sub lstSpells7_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells7.MouseDoubleClick
        SpellMemorize(lstUncast7, lstSpells7.Text, 7, txtSpecialization7)
    End Sub

    Private Sub lstSpells8_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells8.MouseDoubleClick
        SpellMemorize(lstUncast8, lstSpells8.Text, 8, txtSpecialization8)
    End Sub

    Private Sub lstSpells9_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells9.MouseDoubleClick
        SpellMemorize(lstUncast9, lstSpells9.Text, 9, txtSpecialization9)
    End Sub

    Private Sub lstUncast0_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast0.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 0 Then
                SpellMemorize(lstUncast0, strSpell, 0, txtSpecialization0)
            End If
        End If
    End Sub

    Private Sub lstUncast0_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast0.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast0_FormatStringChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUncast0.FormatStringChanged

    End Sub

    Private Sub lstUncast0_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast0.MouseDoubleClick
        CastSpell(lstUncast0, 0)
    End Sub

    Private Sub lstUncast0_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast0.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast0.MouseMove
        
    End Sub

    Private Sub lstUncast0_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast0.MouseUp
        MouseIsDown = False
    End Sub

    Private Sub lstUncast0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast0.SelectedIndexChanged

    End Sub

    Private Sub lstUncast1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast1.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 1 Then
                SpellMemorize(lstUncast1, strSpell, 1, txtSpecialization1)
            End If
        End If
    End Sub

    Private Sub lstUncast1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast1.MouseDoubleClick
        CastSpell(lstUncast1, 1)
    End Sub

    Private Sub lstUncast1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast1.MouseDown
        ListBoxSelected = lstUncast1
        If lstUncast1.SelectedItem <> Nothing Then
            SetContextMenu(lstUncast1.SelectedItem.ToString, 1, txtClass.Text)
        End If
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast1.SelectedIndexChanged

    End Sub

    Private Sub lstUncast2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast2.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 2 Then
                SpellMemorize(lstUncast2, strSpell, 2, txtSpecialization2)
            End If
        End If
    End Sub

    Private Sub lstUncast2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast2.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast2.MouseDoubleClick
        CastSpell(lstUncast2, 2)
    End Sub

    Private Sub lstUncast2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast2.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast2.SelectedIndexChanged

    End Sub

    Private Sub lstUncast3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast3.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 3 Then
                SpellMemorize(lstUncast3, strSpell, 3, txtSpecialization3)
            End If
        End If
    End Sub

    Private Sub lstUncast3_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast3.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast3.MouseDoubleClick
        CastSpell(lstUncast3, 3)
    End Sub

    Private Sub lstUncast3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast3.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast3.SelectedIndexChanged

    End Sub

    Private Sub lstUncast4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast4.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 4 Then
                SpellMemorize(lstUncast4, strSpell, 4, txtSpecialization4)
            End If
        End If
    End Sub

    Private Sub lstUncast4_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast4.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast4_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast4.MouseDoubleClick
        CastSpell(lstUncast4, 4)
    End Sub

    Private Sub lstUncast4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast4.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast4.SelectedIndexChanged

    End Sub

    Private Sub lstUncast5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast5.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 5 Then
                SpellMemorize(lstUncast5, strSpell, 5, txtSpecialization5)
            End If
        End If
    End Sub

    Private Sub lstUncast5_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast5.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast5_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast5.MouseDoubleClick
        CastSpell(lstUncast5, 5)
    End Sub

    Private Sub lstUncast5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast5.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast5.SelectedIndexChanged

    End Sub

    Private Sub lstUncast6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast6.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 6 Then
                SpellMemorize(lstUncast6, strSpell, 6, txtSpecialization6)
            End If
        End If
    End Sub

    Private Sub lstUncast6_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast6.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast6_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast6.MouseDoubleClick
        CastSpell(lstUncast6, 6)
    End Sub

    Private Sub lstUncast6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast6.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast6.SelectedIndexChanged

    End Sub

    Private Sub lstSpells7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells7.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells7.MouseMove
        If MouseIsDown And lstSpells7.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells7.DoDragDrop(lstSpells7.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells7.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSpells7.SelectedIndexChanged

    End Sub

    Private Sub lstSpells8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells8.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells8.MouseMove
        If MouseIsDown And lstSpells8.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells8.DoDragDrop(lstSpells8.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells8.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSpells8.SelectedIndexChanged

    End Sub

    Private Sub lstUncast7_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast7.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 7 Then
                SpellMemorize(lstUncast7, strSpell, 7, txtSpecialization7)
            End If
        End If
    End Sub

    Private Sub lstUncast7_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast7.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast7_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast7.MouseDoubleClick
        CastSpell(lstUncast7, 7)
    End Sub

    Private Sub lstUncast7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast7.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast7.SelectedIndexChanged

    End Sub

    Private Sub lstUncast8_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast8.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 8 Then
                SpellMemorize(lstUncast8, strSpell, 8, txtSpecialization8)
            End If
        End If
    End Sub

    Private Sub lstUncast8_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast8.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast8_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast8.MouseDoubleClick
        CastSpell(lstUncast8, 8)
    End Sub

    Private Sub lstUncast8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast8.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast8.SelectedIndexChanged

    End Sub

    Private Sub lstUncast9_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast9.DragDrop
        Dim strSpell As String
        Dim strArray() As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 9 Then
                SpellMemorize(lstUncast9, strSpell, 9, txtSpecialization9)
            End If
        End If
    End Sub

    Private Sub lstUncast9_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstUncast9.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstUncast9_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast9.MouseDoubleClick
        CastSpell(lstUncast9, 9)
    End Sub

    Private Sub lstUncast9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUncast9.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstUncast9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUncast9.SelectedIndexChanged

    End Sub

    Private Sub lstSpells0_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells0.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells0.MouseMove
        If MouseIsDown And lstSpells0.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells0.DoDragDrop(lstSpells0.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells0_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells0.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSpells0.SelectedIndexChanged

    End Sub
    Private Sub LoadCaster(ByVal strClass() As String)
        Dim strknown(3) As String
        Dim objReader As IO.StreamReader
        Dim strCurrentLine As String
        Dim strArray(4) As String
        Dim strCastingScore As String = ""
        Dim intcastingscore As Integer = 0
        Dim i As Integer = 0
        Dim z As Integer = 0

        For i = 0 To intSpellsPerDay.GetLength(0) - 1
            intSpellsPerDay(i) = 0
        Next
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellsPerDay.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellsPerDay.txt")
            strCurrentLine = objReader.ReadLine()
            strArray = Split(strCurrentLine, ",")
            Do While objReader.Peek <> -1
                If strArray(0) = strClass(1) And strArray(1) = strClass(2) Then
                    intSpellsPerDay(Convert.ToInt32(strArray(2))) += Convert.ToInt32(strArray(3))
                End If
                strCurrentLine = objReader.ReadLine()
                strArray = Split(strCurrentLine, ",")
            Loop
            objReader.Close()
        End If
        Populate(strClass)
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellcasterAbility.txt") = True Then
            objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\SpellcasterAbility.txt")
            strCurrentLine = objReader.ReadLine()
            strArray = Split(strCurrentLine, ",")
            Do While objReader.Peek <> -1 And strCastingScore = ""
                If strArray(0) = strClass(1) Then
                    strCastingScore = strArray(1)
                End If
                strCurrentLine = objReader.ReadLine()
                strArray = Split(strCurrentLine, ",")
            Loop
            objReader.Close()
        End If
        Select Case strCastingScore
            Case "wis"
                intcastingscore = character.intWis
            Case "int"
                intcastingscore = character.intInt
            Case "cha"
                intcastingscore = character.IntCha
        End Select
        If intcastingscore Mod 2 = 1 Then
            intcastingscore = (intcastingscore - 11) / 2
        Else
            intcastingscore = (intcastingscore - 10) / 2
        End If
        For z = 1 To 9
            If intSpellsPerDay(z) <> 0 Then
                If (intcastingscore - z + 1) Mod 4 <> 0 Then
                    intSpellsPerDay(z) += ((intcastingscore - z + 1 - ((intcastingscore - z + 1) Mod 4)) / 4) + 1
                Else
                    intSpellsPerDay(z) += ((intcastingscore - z + 1) / 4)
                End If
            End If
        Next

    End Sub

    Private Sub txtSpecialization0_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization0.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 0 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization0.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization0_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization0.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization0_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization0.MouseDoubleClick
        txtSpecialization0.Text = ""
    End Sub

    Private Sub txtSpecialization1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization1.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 1 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization1.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization1.MouseDoubleClick
        txtSpecialization1.Text = ""
    End Sub

    Private Sub txtSpecialization2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization2.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 2 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization2.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization2.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization2.MouseDoubleClick
        txtSpecialization2.Text = ""
    End Sub

    Private Sub txtSpecialization3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization3.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 3 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization3.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization3_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization3.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization3.MouseDoubleClick
        txtSpecialization3.Text = ""
    End Sub

    Private Sub txtSpecialization4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization4.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 4 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization4.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization4_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization4.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization4_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization4.MouseDoubleClick
        txtSpecialization4.Text = ""
    End Sub

    Private Sub txtSpecialization5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization5.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 5 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization5.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization5_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization5.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization5_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization5.MouseDoubleClick
        txtSpecialization5.Text = ""
    End Sub

    Private Sub txtSpecialization6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization6.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 6 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization6.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization6_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization6.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization6_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization6.MouseDoubleClick
        txtSpecialization6.Text = ""
    End Sub

    Private Sub txtSpecialization7_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization7.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 7 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization7.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization7_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization7.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization7_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization7.MouseDoubleClick
        txtSpecialization7.Text = ""
    End Sub

    Private Sub txtSpecialization8_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization8.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 8 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization8.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization8_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization8.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization8_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization8.MouseDoubleClick
        txtSpecialization8.Text = ""
    End Sub

    Private Sub txtSpecialization9_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization9.DragDrop
        Dim strArray() As String
        Dim strSpell As String
        strSpell = e.Data.GetData(DataFormats.Text).ToString
        strArray = Split(frmSkills.chain(strSpell, "Spells.txt", True), ",")
        If IsNumeric(strArray(0)) Then
            If Convert.ToInt32(strArray(0)) <= 9 Then
                If strArray(2) = txtSpecial1.Text Or strArray(2) = txtSpecial2.Text Then
                    txtSpecialization9.Text = strSpell
                End If
            End If
        End If
    End Sub

    Private Sub txtSpecialization9_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSpecialization9.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtSpecialization9_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialization9.MouseDoubleClick
        txtSpecialization9.Text = ""
    End Sub

    Private Sub lstSpells1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells1.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells1.MouseMove
        If MouseIsDown And lstSpells1.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells1.DoDragDrop(lstSpells1.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells1.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSpells1.SelectedIndexChanged

    End Sub

    Private Sub lstSpells2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells2.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells2.MouseMove
        If MouseIsDown And lstSpells2.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells2.DoDragDrop(lstSpells2.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells3.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells3.MouseMove
        If MouseIsDown And lstSpells3.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells3.DoDragDrop(lstSpells3.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells4.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells4.MouseMove
        If MouseIsDown And lstSpells4.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells4.DoDragDrop(lstSpells4.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells5.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells5.MouseMove
        If MouseIsDown And lstSpells5.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells5.DoDragDrop(lstSpells5.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells6.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells6.MouseMove
        If MouseIsDown And lstSpells6.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells6.DoDragDrop(lstSpells6.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub lstSpells9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells9.MouseDown
        If e.Clicks = 1 Then
            MouseIsDown = True
        Else
            MouseIsDown = False
        End If
    End Sub

    Private Sub lstSpells9_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells9.MouseMove
        If MouseIsDown And lstSpells9.SelectedItem <> Nothing Then
            ' Initiate dragging.
            lstSpells9.DoDragDrop(lstSpells9.SelectedItem.ToString, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtSpecialization0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpecialization0.TextChanged

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Empower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Empower.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Empowered " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub lstSpells2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells2.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells3.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells4.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells5.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells6.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub lstSpells9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpells9.MouseUp
        ' Assume no drag operation
        MouseIsDown = False
    End Sub

    Private Sub Enlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enlarge.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Enlarged " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Extend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extend.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Extended " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Heighten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Heighten.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Heightened " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Maximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maximize.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Maximized " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Quicken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quicken.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Quickened " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Silent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Silent.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Silent " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Still_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Still.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Still " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub Widen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Widen.Click
        Dim strSpell As String
        Dim strModSpell As String
        strSpell = ListBoxSelected.SelectedItem.ToString
        strModSpell = "Widen " + strSpell
        ListBoxSelected.Items.Add(strModSpell)
        ListBoxSelected.Items.Remove(strSpell)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim strNew As String
        character.colUnusedSpells.Clear()
        strNew = New String(character.colCaster.Item(intCurrentCaster))
        strClass = Split(strNew, ",")
        Populate(strClass)
    End Sub
End Class