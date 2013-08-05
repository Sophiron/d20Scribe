Option Strict On
Public Class FrmLevelUp
    Public character As Character.PC
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
    Private Sub FrmLevelUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        character = frmCharacterSheet.character
        Dim x As Integer = 0
        Dim intcount As Integer = character.GetNumOfClasses
        Dim strClasses(intcount) As String
        Dim strSplit(3) As String
        Dim boolfound As Boolean = False
        Dim strReader As String = ""
        Dim objReader As IO.StreamReader
        Dim intnewlevel As Integer = character.intlevel + 1

        'This code populates the level up drop down with the appropriate classes and their respective levels
        
        cboLevel.Items.Add("Barbarian")
        cboLevel.Items.Add("Bard")
        cboLevel.Items.Add("Cleric")
        cboLevel.Items.Add("Druid")
        cboLevel.Items.Add("Fighter")
        cboLevel.Items.Add("Monk")
        cboLevel.Items.Add("Ranger")
        cboLevel.Items.Add("Rogue")
        cboLevel.Items.Add("Sorcerer")
        cboLevel.Items.Add("Wizard")

        
        'If the character's next level is a multilple of four let them add an ability point
        If (Convert.ToInt32(frmCharacterSheet.intLevel) + 1) Mod 4 = 0 Then
            cboAttribute.Enabled = True
        End If


        'If the character's next level is a multiple of three then let them add a feat
        If (Convert.ToInt32(frmCharacterSheet.intLevel) + 1) Mod 3 = 0 Then
            cboFeat.Enabled = True
            If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\FeatList.txt") = True Then
                objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\FeatList.txt")
                Do Until strReader = "End"
                    strReader = objReader.ReadLine()
                    If strReader <> "End" Then
                        cboFeat.Items.Add(strReader)
                    End If
                Loop
            End If
        End If
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLevel.SelectedIndexChanged

        Dim strSplit(3) As String
        Dim z As Integer = 0
        Dim strClass As String
        Dim strFeats() As String
        lstSpecial.Items.Clear()
        cboClassFeat.Enabled = False
        txtHitDice.Enabled = True
        radFixed.Enabled = True
        radRoll.Enabled = True
        radRoll.Checked = True
        strClass = cboLevel.Text
        strSplit = Split(frmSkills.chain(strClass, "ClassLevelUp2.txt"), ",")
        txtHitDice.Text = "d" + strSplit(1) + " + " + Convert.ToString(character.intConMod)
        txtSkillPoints.Text = Convert.ToString(Convert.ToInt32(strSplit(2)) + character.intIntMod)
        strSplit = Split(frmSkills.chain(strClass + " lvl " + Convert.ToString(character.GetClassLevel(strClass) + 1), "ClassLevelUp.txt"), ",")

        For z = 1 To strSplit.Length - 1
            If strSplit(z) = "Special" Then
                lstSpecial.Items.Add(strSplit(z + 1))
            End If
            If strSplit(z) = "FeatOption" Then
                strFeats = Split(frmSkills.chain(strSplit(z + 1), "ClassFeats.txt"), ",")
                cboClassFeat.Items.AddRange(strFeats)
            End If
            z += 1
        Next

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub radRoll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRoll.CheckedChanged
        Dim strSplit(3) As String
        strSplit = Split(cboLevel.Text)
        Select Case strSplit(0)
            Case "Barbarian"
                txtHitDice.Text = "d12 + " + frmCharacterSheet.txtConBonus.Text
            Case "Bard"
                txtHitDice.Text = "d8 + " + frmCharacterSheet.txtConBonus.Text
            Case "Cleric"
                txtHitDice.Text = "d8 + " + frmCharacterSheet.txtConBonus.Text
            Case "Druid"
                txtHitDice.Text = "d8 + " + frmCharacterSheet.txtConBonus.Text
            Case "Fighter"
                txtHitDice.Text = "d10 + " + frmCharacterSheet.txtConBonus.Text
            Case "Monk"
                txtHitDice.Text = "d8 + " + frmCharacterSheet.txtConBonus.Text
            Case "Paladin"
                txtHitDice.Text = "d10 + " + frmCharacterSheet.txtConBonus.Text
            Case "Rogue"
                txtHitDice.Text = "d6 + " + frmCharacterSheet.txtConBonus.Text
            Case "Sorceror"
                txtHitDice.Text = "d4 + " + frmCharacterSheet.txtConBonus.Text
            Case "Wizard"
                txtHitDice.Text = "d4 + " + frmCharacterSheet.txtConBonus.Text
        End Select
    End Sub

    Private Sub radFixed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFixed.CheckedChanged
        Dim strSplit(3) As String
        strSplit = Split(cboLevel.Text)
        Select Case strSplit(0)
            Case "Barbarian"
                txtHitDice.Text = Convert.ToString(6 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Bard"
                txtHitDice.Text = Convert.ToString(4 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Cleric"
                txtHitDice.Text = Convert.ToString(4 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Druid"
                txtHitDice.Text = Convert.ToString(3 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Fighter"
                txtHitDice.Text = Convert.ToString(5 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Monk"
                txtHitDice.Text = Convert.ToString(4 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Paladin"
                txtHitDice.Text = Convert.ToString(5 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Rogue"
                txtHitDice.Text = Convert.ToString(3 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Sorceror"
                txtHitDice.Text = Convert.ToString(2 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
            Case "Wizard"
                txtHitDice.Text = Convert.ToString(2 + Convert.ToInt16(frmCharacterSheet.txtConBonus.Text))
        End Select
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim x As Integer = 0
        Dim intcount As Integer = frmCharacterSheet.lstClasses.Items.Count
        Dim strClasses(intcount) As String
        Dim strSplit(3) As String
        Dim strSplit2(3) As String
        Dim bolRolledHP As Boolean
        Dim strReader As String = ""
        If radFixed.Checked Then
            bolRolledHP = False
        ElseIf radRoll.Checked Then
            bolRolledHP = True
        Else
            bolRolledHP = True
        End If
        character.LevelUp(Convert.ToString(cboLevel.SelectedItem), bolRolledHP)
        frmCharacterSheet.txtExp.Text = Convert.ToString(character.intExperience) + "/" + Convert.ToString(character.intlevel * character.intlevel * 1000)
        For Each strSpecial As String In lstSpecial.Items
            character.colSpecials.Add(strSpecial)
        Next
        If cboClassFeat.SelectedItem Is Nothing Then
        Else
            character.colFeats.Add(cboClassFeat.SelectedItem.ToString)
        End If
        If cboFeat.SelectedItem Is Nothing Then
        Else
            character.colFeats.Add(cboFeat.SelectedItem.ToString)
        End If
        frmCharacterSheet.character = character

        frmSkills.Show()
        If character.intExperience < character.intlevel * character.intlevel * 1000 Then
            frmCharacterSheet.btnLevelUp.Enabled = False
        End If
        If strSplit(1) = "Wizard" Then
            If strSplit(3) = "1" Then
                frmWizardCreation.Show()
            Else
                frmAddWizardSpells.Show()
                frmAddWizardSpells.intWizardLevel = Convert.ToInt32(strSplit(3))
            End If
        End If
        frmCharacterSheet.equip()
        Me.Close()
    End Sub
End Class