' Daniel Sizemore
Option Strict On
Imports System
Imports System.IO

Public Class frmCharacterSheet
    Private DragSource As String
    Private Dragindex As Integer
    Private MouseIsDown As Boolean = False
    Public colStack As Collection 'collects calls to different screens and calls them one after the other.
    Public character As Character.PC
    Public bolEquipEnable As Boolean = True 'used to disable the equip sub routine in controls so that if multiple controls are changed by code it doesn't cause a cascade of equip() calls.
    'these are used for frmFeatSubCategories
    Public strFeatName As String
    Public colFeatSubCategories As Collection
    Public Function XpForNextLevel(ByVal intLevel As Integer) As Integer
        Dim x As Integer
        Dim intXp As Integer = 0
        For x = 1 To intLevel
            intXp += (x * 1000)
        Next
        Return intXp
    End Function
    Public Sub EnableControls()
        txtName.Enabled = True
        txtRace.Enabled = True
        txtAlignment.Enabled = True
        txtExp.Enabled = True
        txtSize.Enabled = True
        txtMaxHP.Enabled = True
        txtAC.Enabled = True
        txtTouch.Enabled = True
        txtFlatFooted.Enabled = True
        txtSpeed.Enabled = True
        txtArmorCheckPenalty.Enabled = True
        txtMaximumDexBonus.Enabled = True
        txtArcaneSpellFailure.Enabled = True
        txtStr.Enabled = True
        txtStrBonus.Enabled = True
        txtDex.Enabled = True
        txtDexBonus.Enabled = True
        txtCon.Enabled = True
        txtConBonus.Enabled = True
        txtWis.Enabled = True
        txtWisBonus.Enabled = True
        txtInt.Enabled = True
        txtIntBonus.Enabled = True
        txtCha.Enabled = True
        txtFort.Enabled = True
        txtRef.Enabled = True
        txtWill.Enabled = True
        txtInitiative.Enabled = True
        txtBAB.Enabled = True
        txtMonkBAB.Enabled = True
        txtAcidResistance.Enabled = True
        txtFireResistance.Enabled = True
        txtColdResistance.Enabled = True
        txtElectricityResistance.Enabled = True
        txtSonicResistance.Enabled = True
        txtSpellResistance.Enabled = True
        txtHelmet.Enabled = True
        txtArmor.Enabled = True
        txtRobe.Enabled = True
        txtBracers.Enabled = True
        txtGloves.Enabled = True
        TxtRing1.Enabled = True
        txtRing2.Enabled = True
        txtBoots.Enabled = True
        txtMainHand.Enabled = True
        txtOffHand.Enabled = True
        txtWeight.Enabled = True
        txtPlatinum.Enabled = True
        txtGold.Enabled = True
        txtSilver.Enabled = True
        txtCopper.Enabled = True
        txtDamage.Enabled = True
        txtChaBonus.Enabled = True
        nudStr.Enabled = True
        nudDex.Enabled = True
        nudCon.Enabled = True
        nudWis.Enabled = True
        nudInt.Enabled = True
        nudCha.Enabled = True
        btnAddItems.Enabled = True
        SkillsToolStripMenuItem.Enabled = True
        AddExperienceToolStripMenuItem.Enabled = True
        SpellSheetToolStripMenuItem.Enabled = True
    End Sub
    Public Sub DisableControls()
        txtName.Enabled = False
        txtRace.Enabled = False
        txtAlignment.Enabled = False
        txtExp.Enabled = False
        txtSize.Enabled = False
        txtMaxHP.Enabled = False
        txtAC.Enabled = False
        txtTouch.Enabled = False
        txtFlatFooted.Enabled = False
        txtSpeed.Enabled = False
        txtArmorCheckPenalty.Enabled = False
        txtMaximumDexBonus.Enabled = False
        txtArcaneSpellFailure.Enabled = False
        txtStr.Enabled = False
        txtStrBonus.Enabled = False
        txtDex.Enabled = False
        txtDexBonus.Enabled = False
        txtCon.Enabled = False
        txtConBonus.Enabled = False
        txtWis.Enabled = False
        txtWisBonus.Enabled = False
        txtInt.Enabled = False
        txtIntBonus.Enabled = False
        txtCha.Enabled = False
        txtFort.Enabled = False
        txtRef.Enabled = False
        txtWill.Enabled = False
        txtInitiative.Enabled = False
        txtBAB.Enabled = False
        txtMonkBAB.Enabled = False
        txtAcidResistance.Enabled = False
        txtFireResistance.Enabled = False
        txtColdResistance.Enabled = False
        txtElectricityResistance.Enabled = False
        txtSonicResistance.Enabled = False
        txtSpellResistance.Enabled = False
        txtHelmet.Enabled = False
        txtArmor.Enabled = False
        txtRobe.Enabled = False
        txtBracers.Enabled = False
        txtGloves.Enabled = False
        TxtRing1.Enabled = False
        txtRing2.Enabled = False
        txtBoots.Enabled = False
        txtMainHand.Enabled = False
        txtOffHand.Enabled = False
        txtWeight.Enabled = False
        txtPlatinum.Enabled = False
        txtGold.Enabled = False
        txtSilver.Enabled = False
        txtCopper.Enabled = False
        txtDamage.Enabled = False
        txtChaBonus.Enabled = False
        nudStr.Enabled = False
        nudDex.Enabled = False
        nudCon.Enabled = False
        nudWis.Enabled = False
        nudInt.Enabled = False
        nudCha.Enabled = False
        btnAddItems.Enabled = False
        btnAddXP.Enabled = False
        SkillsToolStripMenuItem.Enabled = False
        AddExperienceToolStripMenuItem.Enabled = False
        SpellSheetToolStripMenuItem.Enabled = False
    End Sub
    Public Sub WriteRTF()
        Dim write As System.IO.StreamWriter
        Dim strSaveFile As String
        Dim x As Integer = 0
        SaveFileDialog1.Title = "Save Character Sheet"
        SaveFileDialog1.DefaultExt = ".rtf"
        SaveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory + "\Charater Sheet Printouts"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> Nothing Then
            strSaveFile = SaveFileDialog1.FileName
            write = File.CreateText(strSaveFile)
            write.WriteLine("{\rtf1")
            write.WriteLine("Name: " + character.strName & "\par")
            write.WriteLine(character.strAlignment + " " + character.strRace & "\par")
            For Each strClass As String In character.GetClassCollection
                write.WriteLine("Level " + Convert.ToString(character.GetClassLevel(strClass)) + " " + strClass & "\par")
            Next
            write.WriteLine("HP:" + txtMaxHP.Text + "  AC:" + txtAC.Text + "  Touch AC" + txtTouch.Text + "  Flatfooted AC:" + txtFlatFooted.Text + "\par")
            write.WriteLine("" & "\par")
            write.WriteLine("Str: " + Convert.ToString(character.intStr) + " +" + Convert.ToString(character.intStrBonus) & "(" + txtStr.Text + " +" + txtStrBonus.Text + ")" + "\par")
            write.WriteLine("Dex: " + Convert.ToString(character.intDex) + " +" + Convert.ToString(character.intDexBonus) & "(" + txtDex.Text + " +" + txtDexBonus.Text + ")" + "\par")
            write.WriteLine("Con: " + Convert.ToString(character.intCon) + " +" + Convert.ToString(character.intConBonus) & "(" + txtCon.Text + " +" + txtConBonus.Text + ")" + "\par")
            write.WriteLine("Int: " + Convert.ToString(character.intInt) + " +" + Convert.ToString(character.intIntBonus) & "(" + txtInt.Text + " +" + txtIntBonus.Text + ")" + "\par")
            write.WriteLine("Wis: " + Convert.ToString(character.intWis) + " +" + Convert.ToString(character.intWisBonus) & "(" + txtStr.Text + " +" + txtStrBonus.Text + ")" + "\par")
            write.WriteLine("Cha: " + Convert.ToString(character.IntCha) + " +" + Convert.ToString(character.intChaBonus) & "(" + txtStr.Text + " +" + txtStrBonus.Text + ")" + "\par")
            write.WriteLine("Base Attack Bonus:" + txtBAB.Text + "\par")
            If txtMonkBAB.Text <> "" Then
                write.WriteLine("Monk Base Attack Bonus:" + txtMonkBAB.Text + "\par")
            End If
            write.WriteLine("Reflex Save: " + txtRef.Text + "\par")
            write.WriteLine("Will Save: " + txtWill.Text + "\par")
            write.WriteLine("Fort Save: " + txtFort.Text + "\par")
            write.WriteLine("Initiative: " + txtInitiative.Text + "\par")
            write.WriteLine("Resistances" + "\par")
            write.WriteLine("Fire: " + txtFireResistance.Text + "  Cold: " + txtColdResistance.Text + "  Electricity: " + txtElectricityResistance.Text + "  Acid: " + txtAcidResistance.Text + "  Sonic: " + txtSonicResistance.Text + "\par")
            write.WriteLine("Spell Resistance:" + txtSpellResistance.Text + "\par")
            For Each strItem As String In lstDamageReduction.Items
                write.WriteLine("Damage Resistance" + strItem + "\par")
            Next
            If lstSpecial.Items.Count <> 0 Then
                write.WriteLine("\par")
                write.WriteLine("Special:" + "\par")
            End If
            For Each strItem As String In lstSpecial.Items
                write.WriteLine(strItem + "\par")
            Next
            If lstFeats.Items.Count <> 0 Then
                write.WriteLine("\par")
                write.WriteLine("Feats:" + "\par")
            End If
            For Each strItem As String In lstFeats.Items
                write.WriteLine(strItem + "\par")
            Next
            write.WriteLine("\par")
            write.WriteLine("Equipped Items:" + "\par")
            If txtHelmet.Text <> "" Then
                write.WriteLine(txtHelmet.Text + "\par")
            End If
            If txtArmor.Text <> "" Then
                write.WriteLine(txtArmor.Text + "\par")
            End If
            If txtRobe.Text <> "" Then
                write.WriteLine(txtRobe.Text + "\par")
            End If
            If txtBracers.Text <> "" Then
                write.WriteLine(txtBracers.Text + "\par")
            End If
            If txtGloves.Text <> "" Then
                write.WriteLine(txtGloves.Text + "\par")
            End If
            If TxtRing1.Text <> "" Then
                write.WriteLine(TxtRing1.Text + "\par")
            End If
            If txtRing2.Text <> "" Then
                write.WriteLine(txtRing2.Text + "\par")
            End If
            If txtBoots.Text <> "" Then
                write.WriteLine(txtBoots.Text + "\par")
            End If
            If txtMainHand.Text <> "" Then
                write.WriteLine(txtMainHand.Text + "\par")
            End If
            If txtOffHand.Text <> "" Then
                write.WriteLine(txtOffHand.Text + "\par")
            End If
            For Each strItem As String In LstMisc.Items
                write.WriteLine(strItem + "\par")
            Next
            write.WriteLine("\par")
            write.WriteLine("Items:\par")
            For Each strItem As String In LstItems.Items
                write.WriteLine(strItem + "\par")
            Next
            write.WriteLine("Platinum: " + txtPlatinum.Text + "  Gold: " + txtGold.Text + "  Silver: " + txtSilver.Text + "  Copper: " + txtCopper.Text + "\par")
            write.WriteLine("\pard \insrsid \page \par")
            write.WriteLine("Appraise " + Convert.ToString(character.dblSkillArray(0, 0) + character.dblSkillArray(0, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(0, 0) + character.dblSkillArray(0, 1) + statbonus("Appraise")) + "\par")
            write.WriteLine("Balance " + Convert.ToString(character.dblSkillArray(1, 0) + character.dblSkillArray(1, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(1, 0) + character.dblSkillArray(1, 1) + statbonus("Balance")) + "\par")
            write.WriteLine("Bluff " + Convert.ToString(character.dblSkillArray(2, 0) + character.dblSkillArray(2, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(2, 0) + character.dblSkillArray(2, 1) + statbonus("Bluff")) + "\par")
            write.WriteLine("Climb " + Convert.ToString(character.dblSkillArray(3, 0) + character.dblSkillArray(3, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(3, 0) + character.dblSkillArray(3, 1) + statbonus("Climb")) + "\par")
            write.WriteLine("Concentration " + Convert.ToString(character.dblSkillArray(4, 0) + character.dblSkillArray(4, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(4, 0) + character.dblSkillArray(4, 1) + statbonus("Concentration")) + "\par")
            write.WriteLine("Craft " + Convert.ToString(character.dblSkillArray(5, 0) + character.dblSkillArray(5, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(5, 0) + character.dblSkillArray(5, 1) + statbonus("Craft")) + "\par")
            write.WriteLine("Decipher Script " + Convert.ToString(character.dblSkillArray(6, 0) + character.dblSkillArray(6, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(6, 0) + character.dblSkillArray(6, 1) + statbonus("Decipher Script")) + "\par")
            write.WriteLine("Diplomacy " + Convert.ToString(character.dblSkillArray(7, 0) + character.dblSkillArray(7, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(7, 0) + character.dblSkillArray(7, 1) + statbonus("Diplomacy")) + "\par")
            write.WriteLine("Disable Device " + Convert.ToString(character.dblSkillArray(8, 0) + character.dblSkillArray(8, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(8, 0) + character.dblSkillArray(8, 1) + statbonus("Disable Device")) + "\par")
            write.WriteLine("Disguise " + Convert.ToString(character.dblSkillArray(9, 0) + character.dblSkillArray(9, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(9, 0) + character.dblSkillArray(9, 1) + statbonus("Disguise")) + "\par")
            write.WriteLine("Escape Artist " + Convert.ToString(character.dblSkillArray(10, 0) + character.dblSkillArray(10, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(10, 0) + character.dblSkillArray(10, 1) + statbonus("Escape Artist")) + "\par")
            write.WriteLine("Forgery " + Convert.ToString(character.dblSkillArray(11, 0) + character.dblSkillArray(11, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(11, 0) + character.dblSkillArray(11, 1) + statbonus("Forgery")) + "\par")
            write.WriteLine("Gather Info " + Convert.ToString(character.dblSkillArray(12, 0) + character.dblSkillArray(12, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(12, 0) + character.dblSkillArray(12, 1) + statbonus("Gather Information")) + "\par")
            write.WriteLine("Handle Animal " + Convert.ToString(character.dblSkillArray(13, 0) + character.dblSkillArray(13, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(13, 0) + character.dblSkillArray(13, 1) + statbonus("Handle Animal")) + "\par")
            write.WriteLine("Heal " + Convert.ToString(character.dblSkillArray(14, 0) + character.dblSkillArray(14, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(14, 0) + character.dblSkillArray(14, 1) + statbonus("Heal")) + "\par")
            write.WriteLine("Hide " + Convert.ToString(character.dblSkillArray(15, 0) + character.dblSkillArray(15, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(15, 0) + character.dblSkillArray(15, 1) + statbonus("Hide")) + "\par")
            write.WriteLine("Intimidate " + Convert.ToString(character.dblSkillArray(16, 0) + character.dblSkillArray(16, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(16, 0) + character.dblSkillArray(16, 1) + statbonus("Intimidate")) + "\par")
            write.WriteLine("Jump " + Convert.ToString(character.dblSkillArray(17, 0) + character.dblSkillArray(17, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(17, 0) + character.dblSkillArray(17, 1) + statbonus("Jump")) + "\par")
            write.WriteLine("Arcana " + Convert.ToString(character.dblSkillArray(18, 0) + character.dblSkillArray(18, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(18, 0) + character.dblSkillArray(18, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Engineering " + Convert.ToString(character.dblSkillArray(19, 0) + character.dblSkillArray(19, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(19, 0) + character.dblSkillArray(19, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Dungeoneering " + Convert.ToString(character.dblSkillArray(20, 0) + character.dblSkillArray(20, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(20, 0) + character.dblSkillArray(20, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Geography " + Convert.ToString(character.dblSkillArray(21, 0) + character.dblSkillArray(21, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(21, 0) + character.dblSkillArray(21, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("History " + Convert.ToString(character.dblSkillArray(22, 0) + character.dblSkillArray(22, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(22, 0) + character.dblSkillArray(22, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Local " + Convert.ToString(character.dblSkillArray(23, 0) + character.dblSkillArray(23, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(23, 0) + character.dblSkillArray(23, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Nature " + Convert.ToString(character.dblSkillArray(24, 0) + character.dblSkillArray(24, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(24, 0) + character.dblSkillArray(24, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Nobility " + Convert.ToString(character.dblSkillArray(25, 0) + character.dblSkillArray(25, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(25, 0) + character.dblSkillArray(25, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Religion " + Convert.ToString(character.dblSkillArray(26, 0) + character.dblSkillArray(26, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(26, 0) + character.dblSkillArray(26, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("The Planes " + Convert.ToString(character.dblSkillArray(27, 0) + character.dblSkillArray(27, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(27, 0) + character.dblSkillArray(27, 1) + statbonus("Knowledge")) + "\par")
            write.WriteLine("Listen " + Convert.ToString(character.dblSkillArray(28, 0) + character.dblSkillArray(28, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(28, 0) + character.dblSkillArray(28, 1) + statbonus("Listen")) + "\par")
            write.WriteLine("Move Silently " + Convert.ToString(character.dblSkillArray(29, 0) + character.dblSkillArray(29, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(29, 0) + character.dblSkillArray(29, 1) + statbonus("Move Silently")) + "\par")
            write.WriteLine("Open Lock " + Convert.ToString(character.dblSkillArray(30, 0) + character.dblSkillArray(30, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(30, 0) + character.dblSkillArray(30, 1) + statbonus("Open Lock")) + "\par")
            write.WriteLine("Perform " + Convert.ToString(character.dblSkillArray(31, 0) + character.dblSkillArray(31, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(31, 0) + character.dblSkillArray(31, 1) + statbonus("Perform")) + "\par")
            write.WriteLine("Sleight Of Hand " + Convert.ToString(character.dblSkillArray(32, 0) + character.dblSkillArray(32, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(32, 0) + character.dblSkillArray(32, 1) + statbonus("Sleight of Hand")) + "\par")
            write.WriteLine("Profession " + Convert.ToString(character.dblSkillArray(33, 0) + character.dblSkillArray(33, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(33, 0) + character.dblSkillArray(33, 1) + statbonus("Profession")) + "\par")
            write.WriteLine("Ride " + Convert.ToString(character.dblSkillArray(34, 0) + character.dblSkillArray(34, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(34, 0) + character.dblSkillArray(34, 1) + statbonus("Ride")) + "\par")
            write.WriteLine("Search " + Convert.ToString(character.dblSkillArray(35, 0) + character.dblSkillArray(35, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(35, 0) + character.dblSkillArray(35, 1) + statbonus("Search")) + "\par")
            write.WriteLine("Sense Motive " + Convert.ToString(character.dblSkillArray(36, 0) + character.dblSkillArray(36, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(36, 0) + character.dblSkillArray(36, 1) + statbonus("Sense Motive")) + "\par")
            write.WriteLine("Spellcraft " + Convert.ToString(character.dblSkillArray(37, 0) + character.dblSkillArray(37, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(37, 0) + character.dblSkillArray(37, 1) + statbonus("Spellcraft")) + "\par")
            write.WriteLine("Spot " + Convert.ToString(character.dblSkillArray(38, 0) + character.dblSkillArray(38, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(38, 0) + character.dblSkillArray(38, 1) + statbonus("Spot")) + "\par")
            write.WriteLine("Survival " + Convert.ToString(character.dblSkillArray(39, 0) + character.dblSkillArray(39, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(39, 0) + character.dblSkillArray(39, 1) + statbonus("Survival")) + "\par")
            write.WriteLine("Swim " + Convert.ToString(character.dblSkillArray(40, 0) + character.dblSkillArray(40, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(40, 0) + character.dblSkillArray(40, 1) + statbonus("Swim")) + "\par")
            write.WriteLine("Tumble " + Convert.ToString(character.dblSkillArray(41, 0) + character.dblSkillArray(41, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(40, 0) + character.dblSkillArray(41, 1) + statbonus("Tumble")) + "\par")
            write.WriteLine("Use Magic Device " + Convert.ToString(character.dblSkillArray(42, 0) + character.dblSkillArray(42, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(41, 0) + character.dblSkillArray(42, 1) + statbonus("Use Magic Device")) + "\par")
            write.WriteLine("Use Rope " + Convert.ToString(character.dblSkillArray(43, 0) + character.dblSkillArray(43, 1)) + " ranks" + " + " + Convert.ToString(character.dblSkillArray(42, 0) + character.dblSkillArray(43, 1) + statbonus("Use Rope")) + "\par")
            For Each strcaster As String In character.colCaster
                Dim strArray3() As String = Split(strcaster, ",")
                write.WriteLine("\pard \insrsid \page \par")
                write.WriteLine(strArray3(0) + "\par")
                If strArray3(3) <> "" Then
                    write.WriteLine("Specialization:" + strArray3(3) + "\par")
                End If
                If strArray3(4) <> "" Then
                    write.WriteLine("Specialization:" + strArray3(4) + "\par")
                End If
                If strArray3(5) <> "" Then
                    write.WriteLine("Prohibited:" + strArray3(5) + "\par")
                End If
                If strArray3(6) <> "" Then
                    write.WriteLine("Prohibited:" + strArray3(6) + "\par")
                End If
                For x = 0 To 9
                    Select Case x
                        Case 0
                            write.WriteLine("Zero Level:\par")
                        Case 1
                            write.WriteLine("First:\par")
                        Case 2
                            write.WriteLine("Second:\par")
                        Case 3
                            write.WriteLine("Third:\par")
                        Case 4
                            write.WriteLine("Fourth:\par")
                        Case 5
                            write.WriteLine("Fifth:\par")
                        Case 6
                            write.WriteLine("Sixth:\par")
                        Case 7
                            write.WriteLine("Seventh:\par")
                        Case 8
                            write.WriteLine("Eighth:\par")
                        Case 9
                            write.WriteLine("Ninth:\par")
                    End Select
                    For Each strspell As String In character.colKnownSpells
                        Dim strarray2() As String = Split(strspell, ",")
                        If Convert.ToInt32(strarray2(1)) = x Then
                            write.WriteLine("     " + strarray2(2))
                            For Each strspell2 As String In character.colUnusedSpells
                                Dim strarray() As String
                                strarray = Split(strspell2, ",")
                                If strarray(0) = strArray3(0) And strarray(2) = strarray2(2) Then
                                    write.WriteLine(" O")
                                End If
                            Next
                            write.WriteLine("\par")
                        End If
                    Next
                Next
            Next
            write.WriteLine("}")
            write.Close()
        End If
    End Sub
    Function statbonus(ByVal strSkillname As String) As Integer
        Dim intBonus As Integer = 0
        Dim strArray() As String
        strArray = Split(frmSkills.chain(strSkillname, "Skills.txt", True), ",")
        Select Case strArray(1)
            Case "str"
                intBonus = Character.intStrMod
            Case "dex"
                intBonus = Character.intDexMod
            Case "con"
                intBonus = Character.intConMod
            Case "wis"
                intBonus = Character.intWisMod
            Case "int"
                intBonus = Character.intIntMod
            Case "cha"
                intBonus = Character.IntChaMod
            Case Else
                intBonus = 0
        End Select
        If strArray(2) = "yes" Then
            intBonus += Character.intArmorCheckPenalty
        ElseIf strArray(2) = "double" Then
            intBonus += Character.intArmorCheckPenalty * 2
        End If
        Return intBonus
    End Function
    Public Function NumOfItems(ByVal strSearch As String) As Integer
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
    Public Function GetIndex(ByVal strItem As String, ByRef Collection As Collection) As Integer
        Dim index As Integer
        For index = 1 To Collection.Count
            If Convert.ToString(Collection(index)) = strItem Then
                Return index
            End If
        Next
        Return 0
    End Function
    Public Sub CleanUp()
        Dim strItem As String
        Dim strItem2 As String
        Dim strArray() As String
        Dim i As Integer
        Dim colfeats As Collection
        colfeats = character.GetFeatCollection
        For Each strItem In colfeats
            strArray = Split(frmSkills.chain(strItem, "CleanUpList.txt", False), ",")
            For Each strItem2 In colfeats
                For i = 1 To strArray.GetUpperBound(0)
                    If strItem2 = strArray(i) Then
                        If GetIndex(strItem2, colfeats) <> 0 Then
                            colfeats.Remove(GetIndex(strItem2, colfeats))
                        End If
                    End If
                Next
            Next
        Next
        For Each strItem In character.colSpecials
            strArray = Split(frmSkills.chain(strItem, "CleanUpList.txt", False), ",")
            For Each strItem2 In character.colSpecials
                For i = 1 To strArray.GetUpperBound(0)
                    If strItem2 = strArray(i) Then
                        If GetIndex(strItem2, character.colSpecials) <> 0 Then
                            character.colSpecials.Remove(GetIndex(strItem2, character.colSpecials))
                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Public Sub ExecuteStack()
        If colStack.Count <> 0 Then
            Select Case colStack(1).ToString
                Case "AddSorcererSpells"
                    frmAddSorcererSpells.Show()
                Case "AddItems"
                    frmAddItems.Show()
                Case "AddWizardSpells"
                    frmAddWizardSpells.Show()
                Case "LevelUp"
                    FrmLevelUp.Show()
                Case "NewCharacter"
                    frmNewCharacter.Show()
                Case "Skills"
                    frmSkills.Show()
                Case "SpellSheet"
                    frmSpellSheet.Show()
                Case "WizardCreation"
                    frmWizardCreation.Show()
            End Select
            colStack.Remove(1)
        End If
    End Sub
    Public Sub equip()
        Dim strItem As String = ""
        Dim objReader As IO.StreamReader
        Dim strCurrentSearchItem As String
        Dim strArray(0) As String
        Dim strItemArray(0) As String
        Dim strSpecialAbilityArray(0) As String
        Dim intCount As Integer = 1
        Dim intBonus As Integer = 0
        Dim strAttribute As String
        Dim intAttribute As Integer = 0
        Dim strType As String
        Dim intType As Integer = 0
        Dim intBonusArray(78, 18) As Integer
        Dim intTotalBonus As Integer
        Dim intMaterialBonus As Integer = 0
        Dim b As Integer 'used to cycle through feats and special abilities to make sure not to add duplicates
        Dim booladditem As Boolean 'if set to false the special ability or feat will not be added because a duplicate exists
        Dim boolSpecial As Boolean = False  'used to determine if the current item read in is a feat or special ability and shouldn't be calculated as a regular bonus
        Dim x As Integer = 0  'count number used to cycle through equipable items
        Dim y As Integer = 0  'count number used to cycle through all equiped classes
        Dim i As Integer
        Dim j As Integer = 0  'used along with k to initialize the intbonus array
        Dim k As Integer = 0
        Dim z As Integer = 0
        Dim c As Integer = 0
        Dim strClass As String = ""
        Dim strFeat As String = ""
        Dim strSpecial As String = ""
        Dim strSplitClass(2) As String
        Dim debug As Integer = 0
        Dim d As Integer = 0 'used to cycle through the base item and any attributes it may have
        Dim intitemcount As Integer = 0
        Dim count As Integer = 0
        Dim colClasses As Collection = character.GetClassCollection
        Dim boolWeightOnly As Boolean = False 'used for items carried but not equiped, so that it will calc weight but not stats
        Dim colFeats As Collection = character.GetFeatCollection
        Dim strEnhancementArray() As String 'used to check for an enhancement bonus
        Dim intEnhancement As Integer
        Dim bolMasterwork As Boolean
        bolEquipEnable = False
        ExecuteStack()
        CleanUp()
        If character.ToString <> Nothing Then
            btnAddXP.Enabled = True
        End If
        If character.colNewFeats.Count > 0 Then
            frmAddFeats.Show()
        End If
        txtName.Text = character.strName
        txtRace.Text = character.strRace
        txtExp.Text = Convert.ToString(character.intExperience) + "/" + Convert.ToString(XpForNextLevel(character.intlevel))
        lstClasses.Items.Clear()
        lstSpecial.Items.Clear()
        lstFeats.Items.Clear()
        If character.GetNumOfClasses <> 0 Then
            For Each strClass In colClasses
                lstClasses.Items.Add("Level " + Convert.ToString(character.GetClassLevel(strClass)) + " " + strClass)
            Next
        End If
        txtAlignment.Text = character.strAlignment
        txtMaxHP.Text = Convert.ToString(character.GetHPTotal())
        If colFeats.Count <> 0 Then
            For Each strFeat In colFeats
                lstFeats.Items.Add(strFeat)
            Next
        End If
        If character.colSpecials.Count <> 0 Then
            For Each strSpecial In character.colSpecials
                lstSpecial.Items.Add(strSpecial)
            Next
        End If
        nudStr.Value = character.intBaseStr
        nudDex.Value = character.intBaseDex
        nudCon.Value = character.intBaseCon
        nudInt.Value = character.intBaseInt
        nudWis.Value = character.intBaseWis
        nudCha.Value = character.IntBaseCha
        For j = 0 To 76
            For k = 0 To 17
                intBonusArray(j, k) = 0
            Next
        Next
        Do While (strItem <> "end of list")
            Select Case x
                Case 0
                    strItem = txtRace.Text
                    x += 1
                Case 1
                    If character.GetNumOfClasses > 0 Then
                        strItem = Convert.ToString(colClasses(count + 1)) + " lvl " + Convert.ToString(character.GetClassLevel(Convert.ToString(colClasses(count + 1))))
                        count += 1
                    End If
                    If count = character.GetNumOfClasses Then
                        x += 1
                        d = 0
                    End If
                Case 2
                    ReDim strItemArray(NumOfItems(txtHelmet.Text))
                    strItemArray = Split(txtHelmet.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtHelmet.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 3
                    ReDim strItemArray(NumOfItems(txtArmor.Text))
                    strItemArray = Split(txtArmor.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtArmor.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 4
                    ReDim strItemArray(NumOfItems(txtRobe.Text))
                    strItemArray = Split(txtRobe.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtRobe.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 5
                    ReDim strItemArray(NumOfItems(txtBracers.Text))
                    strItemArray = Split(txtBracers.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtBracers.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 6
                    ReDim strItemArray(NumOfItems(txtGloves.Text))
                    strItemArray = Split(txtGloves.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtGloves.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 7
                    ReDim strItemArray(NumOfItems(TxtRing1.Text))
                    strItemArray = Split(TxtRing1.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(TxtRing1.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 8
                    ReDim strItemArray(NumOfItems(txtRing2.Text))
                    strItemArray = Split(txtRing2.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtRing2.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 9
                    ReDim strItemArray(NumOfItems(txtBoots.Text))
                    strItemArray = Split(txtBoots.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtBoots.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 10
                    ReDim strItemArray(NumOfItems(txtMainHand.Text))
                    strItemArray = Split(txtMainHand.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtMainHand.Text) Then
                        x += 1
                        d = 0
                    End If
                Case 11
                    ReDim strItemArray(NumOfItems(txtOffHand.Text))
                    strItemArray = Split(txtOffHand.Text, ",")
                    strItem = strItemArray(d)
                    d += 1
                    If d = NumOfItems(txtOffHand.Text) Then
                        x += 1
                        d = 0
                        z = 0
                    End If
                Case 12
                    If LstMisc.Items.Count > 0 Then
                        ReDim strItemArray(NumOfItems(Convert.ToString(LstMisc.Items.Item(z))))
                        strItemArray = Split(Convert.ToString(LstMisc.Items.Item(z)), ",")
                        strItem = strItemArray(d)
                        d += 1
                        If d >= NumOfItems(Convert.ToString(LstMisc.Items.Item(z))) Then
                            z += 1
                            d = 0
                            If z >= LstMisc.Items.Count Then
                                x += 1
                            End If
                        End If
                    Else
                        x += 1
                        z = 0
                        strItem = ""
                    End If
                Case 13
                    strItem = txtSize.Text
                    x += 1
                Case 14
                    boolWeightOnly = True
                    If LstItems.Items.Count > 0 Then
                        ReDim strItemArray(NumOfItems(Convert.ToString(LstItems.Items.Item(z))))
                        strItemArray = Split(Convert.ToString(LstItems.Items.Item(z)), ",")
                        strItem = strItemArray(d)
                        d += 1
                        If d >= NumOfItems(Convert.ToString(LstItems.Items.Item(z))) Then
                            z += 1
                            d = 0
                            If z >= LstItems.Items.Count Then
                                x += 1
                            End If
                        End If
                    Else
                        x += 1
                        strItem = ""
                    End If
                Case Else
                    strItem = "end of list"
                    boolWeightOnly = False
            End Select
            strArray = Split(strItem, ",")
            strEnhancementArray = Split(strArray(0))
            intEnhancement = 0
            bolMasterwork = False
            'need to finish this
            Select Case strEnhancementArray(0)
                Case "+1"
                    intEnhancement = 1
                Case "+2"
                    intEnhancement = 2
                Case "+3"
                    intEnhancement = 3
                Case "+4"
                    intEnhancement = 5
                Case "+5"
                    intEnhancement = 5
                Case "Masterwork"
                    bolMasterwork = True
            End Select
            If intEnhancement <> 0 Or bolMasterwork = True Then
                Dim int As Integer = 0
                strArray(0) = ""
                For Each strPart As String In strEnhancementArray
                    If int > 0 Then
                        strArray(0) += strPart
                        strArray(0) += " "
                    End If
                    int += 1
                Next
                strItem = Trim(strArray(0))
            End If
            If strItem <> "end of list" And strItem <> "" Then
                If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\equiplist.txt") = True Then
                    objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\equiplist.txt")
                    Do
                        strCurrentSearchItem = objReader.ReadLine()
                        strArray = Split(strCurrentSearchItem, ",")
                        If objReader.Peek = -1 And strArray(0) <> strItem Then
                            MessageBox.Show(strItem & " was not found", "Equip List Error")
                            Exit Do
                        End If
                    Loop Until strArray(0) = strItem
                    intCount = 1
                    Do While intCount < strArray.Length
                        strType = Convert.ToString(strArray(intCount + 1))
                        strAttribute = Convert.ToString(strArray(intCount + 2))
                        If strAttribute <> "size" Then
                            Select Case strArray(intCount)
                                Case "str"
                                    intBonus = Convert.ToInt32(txtStrBonus.Text)
                                Case "dex"
                                    intBonus = Convert.ToInt32(txtDexBonus.Text)
                                Case "con"
                                    intBonus = Convert.ToInt32(txtConBonus.Text)
                                Case "wis"
                                    intBonus = Convert.ToInt32(txtWisBonus.Text)
                                Case "int"
                                    intBonus = Convert.ToInt32(txtIntBonus.Text)
                                Case "cha"
                                    intBonus = Convert.ToInt32(txtChaBonus.Text)
                                Case Else
                                    intBonus = Convert.ToInt32(strArray(intCount))
                            End Select
                        Else
                            txtSize.Text = strArray(intCount)
                        End If

                        If boolWeightOnly = False Or strAttribute = "weight" Then
                            Select Case strType
                                Case "armor"
                                    intType = 0
                                Case "circumstance"
                                    intType = 1
                                Case "competence"
                                    intType = 2
                                Case "Deflection"
                                    intType = 3
                                Case "dodge"
                                    intType = 4
                                Case "enhancement"
                                    intType = 5
                                Case "haste"
                                    intType = 6
                                Case "inherent"
                                    intType = 7
                                Case "insight"
                                    intType = 8
                                Case "luck"
                                    intType = 9
                                Case "morale"
                                    intType = 10
                                Case "natural armor"
                                    intType = 11
                                Case "profane"
                                    intType = 12
                                Case "resistance"
                                    intType = 13
                                Case "sacred"
                                    intType = 14
                                Case "shield"
                                    intType = 15
                                Case "synergy"
                                    intType = 16
                                Case "untyped"
                                    intType = 17
                                Case "special"
                                    booladditem = True
                                    For b = 0 To lstSpecial.Items.Count - 1
                                        If strAttribute = Convert.ToString(lstSpecial.Items.Item(b)) Then
                                            booladditem = False
                                        End If
                                    Next
                                    If booladditem = True Then
                                        lstSpecial.Items.Add(strAttribute)
                                    End If
                                    boolSpecial = True
                                Case "feat"
                                    booladditem = True
                                    For b = 0 To lstFeats.Items.Count - 1
                                        If strAttribute = Convert.ToString(lstFeats.Items.Item(b)) Then
                                            booladditem = False
                                        End If
                                    Next
                                    If booladditem = True Then
                                        lstFeats.Items.Add(strAttribute)
                                    End If
                                    boolSpecial = True
                                Case Else
                                    MessageBox.Show("The bonus type" & strType & " was not found", "Error")
                            End Select
                            Select Case strAttribute
                                Case "str"
                                    intAttribute = 0
                                Case "dex"
                                    intAttribute = 1
                                Case "con"
                                    intAttribute = 2
                                Case "wis"
                                    intAttribute = 3
                                Case "int"
                                    intAttribute = 4
                                Case "cha"
                                    intAttribute = 5
                                Case "ac"
                                    intAttribute = 6
                                Case "hp"
                                    intAttribute = 7
                                Case "attack"
                                    intAttribute = 8
                                Case "Damage"
                                    intAttribute = 9
                                Case "speed"
                                    intAttribute = 10
                                Case "ref"
                                    intAttribute = 11
                                Case "fort"
                                    intAttribute = 12
                                Case "will"
                                    intAttribute = 13
                                Case "initiative"
                                    intAttribute = 14
                                Case "alchemy"
                                    intAttribute = 15
                                Case "animalempathy"
                                    intAttribute = 16
                                Case "appraise"
                                    intAttribute = 17
                                Case "balance"
                                    intAttribute = 18
                                Case "bluff"
                                    intAttribute = 19
                                Case "climb"
                                    intAttribute = 20
                                Case "concentration"
                                    intAttribute = 21
                                Case "craft"
                                    intAttribute = 22
                                Case "decipherscript"
                                    intAttribute = 23
                                Case "diplomacy"
                                    intAttribute = 24
                                Case "disabledevice"
                                    intAttribute = 25
                                Case "disguise"
                                    intAttribute = 26
                                Case "escapeartist"
                                    intAttribute = 27
                                Case "forgery"
                                    intAttribute = 28
                                Case "gatherinfo"
                                    intAttribute = 29
                                Case "handleanimal"
                                    intAttribute = 30
                                Case "heal"
                                    intAttribute = 31
                                Case "hide"
                                    intAttribute = 32
                                Case "innuendo"
                                    intAttribute = 33
                                Case "intimidate"
                                    intAttribute = 34
                                Case "intuitdirection"
                                    intAttribute = 35
                                Case "jump"
                                    intAttribute = 36
                                Case "knowledgearcana"
                                    intAttribute = 37
                                Case "knowledgeengineering"
                                    intAttribute = 38
                                Case "knowledgegeography"
                                    intAttribute = 39
                                Case "knowledgehistory"
                                    intAttribute = 40
                                Case "knowledgelocal"
                                    intAttribute = 41
                                Case "knowledgenature"
                                    intAttribute = 42
                                Case "knowledgenobility"
                                    intAttribute = 43
                                Case "knowledgetheplanes"
                                    intAttribute = 44
                                Case "knowledgereligion"
                                    intAttribute = 45
                                Case "listen"
                                    intAttribute = 46
                                Case "movesilently"
                                    intAttribute = 47
                                Case "openlock"
                                    intAttribute = 48
                                Case "perform"
                                    intAttribute = 49
                                Case "pickpocket"
                                    intAttribute = 50
                                Case "Profession"
                                    intAttribute = 51
                                Case "readlips"
                                    intAttribute = 52
                                Case "ride"
                                    intAttribute = 53
                                Case "scry"
                                    intAttribute = 54
                                Case "search"
                                    intAttribute = 55
                                Case "sensemotive"
                                    intAttribute = 56
                                Case "spellcraft"
                                    intAttribute = 57
                                Case "spot"
                                    intAttribute = 58
                                Case "swim"
                                    intAttribute = 59
                                Case "tumble"
                                    intAttribute = 60
                                Case "usemagicdevice"
                                    intAttribute = 61
                                Case "userope"
                                    intAttribute = 62
                                Case "wildernesslore"
                                    intAttribute = 63
                                Case "touchac"
                                    intAttribute = 64
                                Case "flatfootedac"
                                    intAttribute = 65
                                Case "acidresist"
                                    intAttribute = 66
                                Case "fireresist"
                                    intAttribute = 67
                                Case "coldresist"
                                    intAttribute = 68
                                Case "electricityresist"
                                    intAttribute = 69
                                Case "sonicresist"
                                    intAttribute = 70
                                Case "spellresist"
                                    intAttribute = 71
                                Case "armorcheckpenalty"
                                    intAttribute = 72
                                Case "arcanespellfailure"
                                    intAttribute = 73
                                Case "maximumdexbonus"
                                    intAttribute = 74
                                Case "weight"
                                    intAttribute = 75
                                    'the material armor attribute is the ac provided by the base armor type and any special material it is made of
                                Case "materialarmor"
                                    intAttribute = 76
                                    'speed penalty for armor
                                Case "speedreduction"
                                    intAttribute = 77
                                Case Else
                                    If boolSpecial = False And strAttribute <> "size" Then
                                        MessageBox.Show(strAttribute & " was not found", "Bonus Error")
                                    End If
                            End Select
                            If strType = "armor" Or strType = "shield" Then
                                If intEnhancement > 0 Then
                                    intBonus += intEnhancement
                                End If
                            End If
                            If strType = "armorcheckpenalty" And intBonus < 0 Then
                                If intEnhancement > 0 Or bolMasterwork = True Then
                                    intBonus += 1
                                End If
                            End If
                            If boolSpecial = False Then
                                If intType = 16 Or intType = 17 Or intAttribute = 76 Then
                                    intBonusArray(intAttribute, intType) += intBonus
                                Else
                                    If intBonusArray(intAttribute, intType) < intBonus Then
                                        intBonusArray(intAttribute, intType) = intBonus
                                    End If
                                End If
                            End If
                        End If
                        intCount += 3
                        boolSpecial = False
                    Loop
                    objReader.Close()
                Else
                    MessageBox.Show("Equiplist text file not found", "Error")
                End If
            End If
        Loop
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(0, i)
        Next
        txtStr.Text = Convert.ToString(nudStr.Value + intTotalBonus)
        txtStrBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtStr.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(1, i)
        Next
        txtDex.Text = Convert.ToString(nudDex.Value + intTotalBonus)
        txtDexBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtDex.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(2, i)
        Next
        txtCon.Text = Convert.ToString(nudCon.Value + intTotalBonus)
        txtConBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtCon.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(3, i)
        Next
        txtWis.Text = Convert.ToString(nudWis.Value + intTotalBonus)
        txtWisBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtWis.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(4, i)
        Next
        txtInt.Text = Convert.ToString(nudInt.Value + intTotalBonus)
        txtIntBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtInt.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(5, i)
        Next
        txtCha.Text = Convert.ToString(nudCha.Value + intTotalBonus)
        txtChaBonus.Text = Convert.ToString(Int((Convert.ToInt32(txtCha.Text) - 10) / 2))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(6, i)
        Next
        txtAC.Text = Convert.ToString(intTotalBonus + 10)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(7, i)
        Next
        txtMaxHP.Text = Convert.ToString(intTotalBonus + character.getHPtotal)
        intTotalBonus = 0
        'Add loops to calculate the bonus to attacks and damage
        Dim intNumOfAttacks As Integer
        intNumOfAttacks = Convert.ToInt32(intBonusArray(8, 0) / 5) + 1
        For i = 0 To 17
            intTotalBonus += intBonusArray(8, i)
        Next
        txtBAB.Text = ""
        For i = 1 To intNumOfAttacks
            txtBAB.Text += "+" & intTotalBonus - (5 * (i - 1))
            If i <> 1 Then
                txtBAB.Text += ","
            End If
        Next
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(10, i)
        Next
        txtSpeed.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(11, i)
        Next
        txtRef.Text = Convert.ToString(Convert.ToInt32(txtDexBonus.Text) + intTotalBonus)
        If Convert.ToInt32(txtRef.Text) >= 0 Then
            txtRef.Text = "+" + txtRef.Text
        End If
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(12, i)
        Next
        txtFort.Text = Convert.ToString(Convert.ToInt32(txtConBonus.Text) + intTotalBonus)
        If Convert.ToInt32(txtFort.Text) >= 0 Then
            txtFort.Text = "+" + txtFort.Text
        End If
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(13, i)
        Next
        txtWill.Text = Convert.ToString(Convert.ToInt32(txtWisBonus.Text) + intTotalBonus)
        If Convert.ToInt32(txtWill.Text) >= 0 Then
            txtWill.Text = "+" + txtWill.Text
        End If
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(14, i)
        Next
        txtInitiative.Text = Convert.ToString(intTotalBonus + Convert.ToInt32(txtDexBonus.Text))
        If Convert.ToInt32(txtInitiative.Text) >= 0 Then
            txtInitiative.Text = "+" + txtInitiative.Text
        End If
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(6, i)
        Next
        For i = 0 To 17
            intMaterialBonus += intBonusArray(76, i)
        Next

        'these two if statements check to see if the base armor bonus and any enhancement bonus from special materials 
        'supercede the base armor and magical enhancements for both armor and shield.

        If (intBonusArray(75, 0) > intBonusArray(6, 0)) Then
            intTotalBonus = intTotalBonus - intBonusArray(5, 0) + intBonusArray(75, 0)
        End If
        If (intBonusArray(75, 14) > intBonusArray(6, 14)) Then
            intTotalBonus = intTotalBonus - intBonusArray(5, 0) + intBonusArray(75, 0)
        End If
        txtAC.Text = Convert.ToString(10 + intTotalBonus + Convert.ToInt32(txtDexBonus.Text))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(64, i)
        Next
        txtTouch.Text = Convert.ToString(10 + intTotalBonus + Convert.ToInt32(txtDexBonus.Text))
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(65, i)
        Next

        'these two if statements check to see if the base armor bonus and any enhancement bonus from special materials 
        'supercede the base armor and magical enhancements for both armor and shield.

        If (intBonusArray(75, 0) > intBonusArray(65, 0)) Then
            intTotalBonus = intTotalBonus - intBonusArray(65, 0) + intBonusArray(75, 0)
        End If
        If (intBonusArray(75, 14) > intBonusArray(65, 14)) Then
            intTotalBonus = intTotalBonus - intBonusArray(65, 0) + intBonusArray(75, 0)
        End If
        txtFlatFooted.Text = Convert.ToString(10 + intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(66, i)
        Next
        txtAcidResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(67, i)
        Next
        txtFireResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(68, i)
        Next
        txtColdResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(69, i)
        Next
        txtElectricityResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(70, i)
        Next
        txtSonicResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(71, i)
        Next
        txtSpellResistance.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(72, i)
        Next
        txtArmorCheckPenalty.Text = Convert.ToString("-" & intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(73, i)
        Next
        txtArcaneSpellFailure.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(74, i)
        Next
        txtMaximumDexBonus.Text = Convert.ToString("+" & intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(75, i)
        Next
        txtWeight.Text = Convert.ToString(intTotalBonus)
        intTotalBonus = 0
        For i = 0 To 17
            intTotalBonus += intBonusArray(77, i)
        Next
        If intTotalBonus > 0 Then
            If character.strRace <> "Dwarf" Then
                If txtSize.Text = "Medium" Then
                    txtSpeed.Text = Convert.ToString(Convert.ToInt32(txtSpeed.Text) - 10)
                ElseIf txtSize.Text = "Small" Then
                    txtSpeed.Text = Convert.ToString(Convert.ToInt32(txtSpeed.Text) - 5)
                End If
            End If
        End If
        intTotalBonus = 0
        Dim Hp As Integer
        Dim HPTotal As Integer
        For Each Hp In character.intHP
            HPTotal += Hp
        Next
        intTotalBonus = 0
        Hp += character.intConBonus * character.intlevel
        txtMaxHP.Text = Convert.ToString(HPTotal)
        bolEquipEnable = True
        ExecuteStack()
    End Sub
    Private Sub dragswap(ByVal strSource As String, ByVal strlistitem As String)
        Select Case DragSource
            Case "items"
                If strSource <> "" Then
                    LstItems.Items.Add(strSource)
                End If
                LstItems.Items.Remove(strlistitem)
            Case "helmet"
                txtHelmet.Text = strSource
                character.strHelmet = strSource
            Case "armor"
                txtArmor.Text = strSource
                character.strArmor = strSource
            Case "robe"
                txtRobe.Text = strSource
                character.strRobe = strSource
            Case "bracers"
                txtBracers.Text = strSource
                character.strBracer = strSource
            Case "gloves"
                txtGloves.Text = strSource
                character.strGloves = strSource
            Case "ring1"
                TxtRing1.Text = strSource
                character.strRing1 = strSource
            Case "ring2"
                txtRing2.Text = strSource
                character.strRing2 = strSource
            Case "boots"
                txtBoots.Text = strSource
                character.strBoots = strSource
            Case "main hand"
                txtMainHand.Text = strSource
                character.strMainHand = strSource
            Case "off hand"
                txtOffHand.Text = strSource
                character.strOffHand = strSource
            Case "misc"
                If strSource <> "" Then
                    LstMisc.Items.Add(strSource)
                    character.colMisc.Add(strSource, strSource)
                End If
                LstMisc.Items.Remove(strlistitem)
                character.colMisc.Remove(strlistitem)
        End Select
        If bolEquipEnable = True Then
            equip()
        End If
    End Sub

    Private Sub mnuNewCharacter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewCharacter.Click
        frmNewCharacter.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        frmSkills.Close()
        frmCombatSheet.Close()
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        txtName.Clear()
        txtExp.Clear()
        txtRace.Text = ""
        txtAlignment.Text = ""
        txtSize.Text = ""
        txtSpeed.Clear()
        lstClasses.Items.Clear()
        txtDamage.Clear()
        txtMaxHP.Clear()
        txtAC.Clear()
        txtTouch.Clear()
        txtFlatFooted.Clear()
        nudStr.Value = 0
        txtStr.Clear()
        txtStrBonus.Clear()
        nudDex.Value = 0
        txtDex.Clear()
        txtDexBonus.Clear()
        nudCon.Value = 0
        txtCon.Clear()
        txtConBonus.Clear()
        nudWis.Value = 0
        txtWis.Clear()
        txtWisBonus.Clear()
        nudInt.Value = 0
        txtInt.Clear()
        txtIntBonus.Clear()
        nudCha.Value = 0
        txtCha.Clear()
        txtChaBonus.Clear()
        txtRef.Clear()
        txtFort.Clear()
        txtWill.Clear()
        txtInitiative.Clear()
        lstSpecial.Items.Clear()
        lstFeats.Items.Clear()
        txtBAB.Clear()
        LstItems.Items.Clear()
        character = Nothing
        DisableControls()
    End Sub

    Private Sub SkillsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkillsToolStripMenuItem.Click
        frmSkills.Show()

    End Sub

    Private Sub CombatSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CombatSheetToolStripMenuItem.Click
        frmCombatSheet.Show()
    End Sub

    Private Sub OpenEquipListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtArmor_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtArmor.DragDrop
        Dim strText As String
        strText = txtArmor.Text
        txtArmor.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strArmor = txtArmor.Text
        dragswap(strText, txtArmor.Text)
    End Sub

    Private Sub txtArmor_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtArmor.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtArmor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtArmor.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtArmor_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtArmor.MouseMove
        If MouseIsDown Then
            DragSource = "armor"
            ' Initiate dragging.
            txtArmor.DoDragDrop(txtArmor.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub


    Private Sub txtHelmet_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtHelmet.DragDrop
        Dim strText As String
        strText = txtHelmet.Text
        txtHelmet.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strHelmet = txtHelmet.Text
        dragswap(strText, txtHelmet.Text)
    End Sub

    Private Sub txtHelmet_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtHelmet.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtHelmet_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtHelmet.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtHelmet_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtHelmet.MouseMove
        If MouseIsDown Then
            DragSource = "helmet"
            ' Initiate dragging.
            txtHelmet.DoDragDrop(txtHelmet.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRobe_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRobe.DragDrop
        Dim strText As String
        strText = txtRobe.Text
        txtRobe.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strRobe = txtRobe.Text
        dragswap(strText, txtRobe.Text)
    End Sub

    Private Sub txtRobe_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRobe.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRobe_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRobe.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRobe_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRobe.MouseMove
        If MouseIsDown Then
            DragSource = "robe"
            ' Initiate dragging.
            txtRobe.DoDragDrop(txtRobe.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtBracers_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBracers.DragDrop
        Dim strText As String
        strText = txtBracers.Text
        txtBracers.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strBracer = txtBracers.Text
        dragswap(strText, txtBracers.Text)
    End Sub

    Private Sub txtBracers_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBracers.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtBracers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBracers.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtBracers_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBracers.MouseMove
        If MouseIsDown Then
            DragSource = "bracers"
            ' Initiate dragging.
            txtBracers.DoDragDrop(txtBracers.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtGloves_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtGloves.DragDrop
        Dim strText As String
        strText = txtGloves.Text
        txtGloves.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strGloves = txtGloves.Text
        dragswap(strText, txtGloves.Text)
    End Sub

    Private Sub txtGloves_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtGloves.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtGloves_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtGloves.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtGloves_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtGloves.MouseMove
        If MouseIsDown Then
            DragSource = "gloves"
            ' Initiate dragging.
            txtGloves.DoDragDrop(txtGloves.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub


    Private Sub TxtRing1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtRing1.DragDrop
        Dim strText As String
        strText = TxtRing1.Text
        TxtRing1.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strRing1 = TxtRing1.Text
        dragswap(strText, TxtRing1.Text)
    End Sub

    Private Sub TxtRing1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtRing1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TxtRing1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtRing1.MouseDown
        MouseIsDown = True
    End Sub



    Private Sub TxtRing1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtRing1.MouseMove
        If MouseIsDown Then
            DragSource = "ring1"
            ' Initiate dragging.
            TxtRing1.DoDragDrop(TxtRing1.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub LstItems_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LstItems.DragDrop
        Dim strText As String
        Dim strDropItem As String
        If DragSource <> "items" Then
            strText = LstItems.Text
            strDropItem = e.Data.GetData(DataFormats.Text).ToString
            LstItems.Items.Add(strDropItem)
            'need to check for duplicate key issue
            character.colItems.Add(strDropItem)
            dragswap(strText, strDropItem)
        End If
    End Sub

    Private Sub LstItems_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LstItems.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LstItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstItems.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub LstItems_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstItems.MouseMove
        If MouseIsDown Then
            DragSource = "items"
            Dragindex = LstItems.SelectedIndex
            ' Initiate dragging.
            LstItems.DoDragDrop(LstItems.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtRing2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRing2.DragDrop
        Dim strText As String
        strText = txtRing2.Text
        txtRing2.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strRing2 = txtRing2.Text
        dragswap(strText, txtRing2.Text)
    End Sub

    Private Sub txtRing2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtRing2.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtRing2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRing2.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtRing2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRing2.MouseMove
        If MouseIsDown Then
            DragSource = "ring2"
            ' Initiate dragging.
            txtRing2.DoDragDrop(txtRing2.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtBoots_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBoots.DragDrop
        Dim strText As String
        strText = txtBoots.Text
        txtBoots.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strBoots = txtBoots.Text
        dragswap(strText, txtBoots.Text)
    End Sub

    Private Sub txtBoots_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBoots.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtBoots_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBoots.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtBoots_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBoots.MouseMove
        If MouseIsDown Then
            DragSource = "boots"
            ' Initiate dragging.
            txtBoots.DoDragDrop(txtBoots.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtMainHand_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMainHand.DragDrop
        Dim strText As String
        strText = txtMainHand.Text
        txtMainHand.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strMainHand = txtMainHand.Text
        dragswap(strText, txtMainHand.Text)
    End Sub

    Private Sub txtMainHand_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMainHand.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtMainHand_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMainHand.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtMainHand_Mousemove(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMainHand.MouseMove
        If MouseIsDown Then
            DragSource = "main hand"
            ' Initiate dragging.
            txtMainHand.DoDragDrop(txtMainHand.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub txtOffHand_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtOffHand.DragDrop
        Dim strText As String
        strText = txtOffHand.Text
        txtOffHand.Text = e.Data.GetData(DataFormats.Text).ToString
        character.strOffHand = txtOffHand.Text
        dragswap(strText, txtOffHand.Text)
    End Sub

    Private Sub txtOffHand_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtOffHand.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtOffHand_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOffHand.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub txtOffHand_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOffHand.MouseMove
        If MouseIsDown Then
            DragSource = "off hand"
            ' Initiate dragging.
            txtOffHand.DoDragDrop(txtOffHand.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub LstMisc_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LstMisc.DragDrop
        Dim strText As String
        Dim strDropItem As String
        If DragSource <> "misc" Then
            strText = LstMisc.Text
            strDropItem = e.Data.GetData(DataFormats.Text).ToString
            LstMisc.Items.Add(strDropItem)
            character.colMisc.Add(strDropItem, strDropItem)
            dragswap(strText, strDropItem)
        End If
    End Sub

    Private Sub LstMisc_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LstMisc.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LstMisc_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstMisc.MouseDown
        MouseIsDown = True
    End Sub


    Private Sub LstMisc_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstMisc.MouseMove
        If MouseIsDown Then
            DragSource = "misc"
            Dragindex = LstMisc.SelectedIndex
            ' Initiate dragging.
            LstMisc.DoDragDrop(LstMisc.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click
        frmAddItems.Show()
        For Each item As Object In LstItems.Items
            frmAddItems.lstAddItems.Items.Add(item)
        Next
        frmAddItems.txtPlatinum.Text = txtPlatinum.Text
        frmAddItems.txtGold.Text = txtGold.Text
        frmAddItems.txtSilver.Text = txtSilver.Text
        frmAddItems.txtCopper.Text = txtCopper.Text
    End Sub

    Private Sub LockControlsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLockControls.Click
        If mnuLockControls.Checked Then
            txtName.ReadOnly = True
            txtRace.ReadOnly = True
            txtAlignment.ReadOnly = True
            txtExp.ReadOnly = True
            txtSize.ReadOnly = True
            txtMaxHP.ReadOnly = True
            txtAC.ReadOnly = True
            txtTouch.ReadOnly = True
            txtFlatFooted.ReadOnly = True
            txtSpeed.ReadOnly = True
            txtArmorCheckPenalty.ReadOnly = True
            txtMaximumDexBonus.ReadOnly = True
            txtArcaneSpellFailure.ReadOnly = True
            txtStr.ReadOnly = True
            txtStrBonus.ReadOnly = True
            txtDex.ReadOnly = True
            txtDexBonus.ReadOnly = True
            txtCon.ReadOnly = True
            txtConBonus.ReadOnly = True
            txtWis.ReadOnly = True
            txtWisBonus.ReadOnly = True
            txtInt.ReadOnly = True
            txtIntBonus.ReadOnly = True
            txtCha.ReadOnly = True
            txtFort.ReadOnly = True
            txtRef.ReadOnly = True
            txtWill.ReadOnly = True
            txtInitiative.ReadOnly = True
            txtBAB.ReadOnly = True
            txtMonkBAB.ReadOnly = True
            txtAcidResistance.ReadOnly = True
            txtFireResistance.ReadOnly = True
            txtColdResistance.ReadOnly = True
            txtElectricityResistance.ReadOnly = True
            txtSonicResistance.ReadOnly = True
            txtSpellResistance.ReadOnly = True
            txtHelmet.ReadOnly = True
            txtArmor.ReadOnly = True
            txtRobe.ReadOnly = True
            txtBracers.ReadOnly = True
            txtGloves.ReadOnly = True
            TxtRing1.ReadOnly = True
            txtRing2.ReadOnly = True
            txtBoots.ReadOnly = True
            txtMainHand.ReadOnly = True
            txtOffHand.ReadOnly = True
            txtWeight.ReadOnly = True
            txtPlatinum.ReadOnly = True
            txtGold.ReadOnly = True
            txtSilver.ReadOnly = True
            txtCopper.ReadOnly = True
        Else
            txtName.ReadOnly = False
            txtRace.ReadOnly = False
            txtAlignment.ReadOnly = False
            txtExp.ReadOnly = False
            txtSize.ReadOnly = False
            txtMaxHP.ReadOnly = False
            txtAC.ReadOnly = False
            txtTouch.ReadOnly = False
            txtFlatFooted.ReadOnly = False
            txtSpeed.ReadOnly = False
            txtArmorCheckPenalty.ReadOnly = False
            txtMaximumDexBonus.ReadOnly = False
            txtArcaneSpellFailure.ReadOnly = False
            txtStr.ReadOnly = False
            txtStrBonus.ReadOnly = False
            txtDex.ReadOnly = False
            txtDexBonus.ReadOnly = False
            txtCon.ReadOnly = False
            txtConBonus.ReadOnly = False
            txtWis.ReadOnly = False
            txtWisBonus.ReadOnly = False
            txtInt.ReadOnly = False
            txtIntBonus.ReadOnly = False
            txtCha.ReadOnly = False
            txtFort.ReadOnly = False
            txtRef.ReadOnly = False
            txtWill.ReadOnly = False
            txtInitiative.ReadOnly = False
            txtBAB.ReadOnly = False
            txtMonkBAB.ReadOnly = False
            txtAcidResistance.ReadOnly = False
            txtFireResistance.ReadOnly = False
            txtColdResistance.ReadOnly = False
            txtElectricityResistance.ReadOnly = False
            txtSonicResistance.ReadOnly = False
            txtSpellResistance.ReadOnly = False
            txtHelmet.ReadOnly = False
            txtArmor.ReadOnly = False
            txtRobe.ReadOnly = False
            txtBracers.ReadOnly = False
            txtGloves.ReadOnly = False
            TxtRing1.ReadOnly = False
            txtRing2.ReadOnly = False
            txtBoots.ReadOnly = False
            txtMainHand.ReadOnly = False
            txtOffHand.ReadOnly = False
            txtWeight.ReadOnly = False
            txtPlatinum.ReadOnly = False
            txtGold.ReadOnly = False
            txtSilver.ReadOnly = False
            txtCopper.ReadOnly = False
        End If
    End Sub

    Private Sub btnEquip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquip.Click
        equip()
    End Sub

    Private Sub btnLevelUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLevelUp.Click
        FrmLevelUp.Show()
    End Sub

    Private Sub btnAddXP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddXP.Click
        Dim intXP As Integer
        Dim strcurrentxp(2) As String
        intXP = Convert.ToInt32(InputBox("Add how many experience points?", "Experience Points"))
        character.intExperience += intXP
        txtExp.Text = Convert.ToString(character.intExperience) + "/" + Convert.ToString(XpForNextLevel(character.intlevel))
        If character.intExperience >= XpForNextLevel(character.intlevel) Then
            btnLevelUp.Enabled = True
        End If
    End Sub


    Private Sub frmCharacterSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\equiplist.txt") = False Then
            MessageBox.Show("Equip file not found: " & Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory), "File not found")
        End If
        colStack = New Collection
        DisableControls()

    End Sub

    Private Sub SpellSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellSheetToolStripMenuItem.Click
        If character.colCaster.Count > 0 Then
            frmSpellSheet.Show()
        End If
    End Sub

    Private Sub AddExperienceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddExperienceToolStripMenuItem.Click
        btnAddXP.PerformClick()
    End Sub

    Private Sub SaveCharacterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCharacterToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Character"
        SaveFileDialog1.DefaultExt = ".txt"
        SaveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory + "\Character Saves"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.DefaultExt = ".txt"
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> Nothing Then
            character.CharacterSave(SaveFileDialog1.FileName.ToString)
        End If
    End Sub

    Private Sub OpenCharacterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenCharacterToolStripMenuItem.Click
        EnableControls()
        OpenFileDialog1.Title = "Open Character"
        OpenFileDialog1.DefaultExt = ".txt"
        OpenFileDialog1.InitialDirectory = Directory.GetCurrentDirectory + "\Character Saves"
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> Nothing Then
            character = New Character.PC
            character.CharacterLoad(OpenFileDialog1.FileName.ToString)
        End If
        equip()
    End Sub

    Private Sub PrintCharacterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCharacterToolStripMenuItem.Click
        WriteRTF()
    End Sub
End Class

Namespace Character
    Public Class PC
        Public strName As String = ""
        Public strRace As String = ""
        Public strAlignment As String = ""
        Public intExperience As Integer = 0
        Public intlevel As Integer = 0
        Public intBAB As Integer = 0
        Public intMonkBAB As Integer = 0
        Public intArmorCheckPenalty As Integer = 0
        'these are the base stats
        Public intBaseStr As Integer = 0
        Public intBaseDex As Integer = 0
        Public intBaseCon As Integer = 0
        Public intBaseWis As Integer = 0
        Public intBaseInt As Integer = 0
        Public IntBaseCha As Integer = 0
        'these are the enhanced stats
        Public intStr As Integer = 0
        Public intDex As Integer = 0
        Public intCon As Integer = 0
        Public intWis As Integer = 0
        Public intInt As Integer = 0
        Public IntCha As Integer = 0
        'Mod values are the modifiers for their base scores.
        Public intStrMod As Integer = 0
        Public intDexMod As Integer = 0
        Public intConMod As Integer = 0
        Public intWisMod As Integer = 0
        Public intIntMod As Integer = 0
        Public IntChaMod As Integer = 0
        Public colKnownSpells As New Collection
        Public colUnusedSpells As New Collection
        Private colFeats As New Collection
        Public colSpecials As New Collection
        Private colNewSpells As New Collection 'format is number,spell level,class
        Public intHP(20) As Integer
        Public intSkillpoints As Integer
        Public strSkillClass As String
        Public dblSkillArray(46, 2) As Double 'y = 0 for class skills, y = 1 for cross class skills
        Public strHelmet As String = ""
        Public strArmor As String = ""
        Public strRobe As String = ""
        Public strBracer As String = ""
        Public strRing1 As String = ""
        Public strRing2 As String = ""
        Public strGloves As String = ""
        Public strBoots As String = ""
        Public strMainHand As String = ""
        Public strOffHand As String = ""
        Public colMisc As New Collection 'collection of items equiped that don't take up a slot
        Public colItems As New Collection 'collection of items carried
        Public intCopper As Integer = 0
        Public intSilver As Integer = 0
        Public intGold As Integer = 0
        Public intPlatinum As Integer = 0
        Private colNewCasters As New Collection 'collection of caster levels that need to have spells chosen Format: Caster Class as string,Level as integer
        Private colClasses As New Collection 'format: key = class, item = level
        Public intCurrentCaster As Integer = 0 'currently selected 
        Public colCaster As New Collection 'format: (0)Wizard,Wizard,Specialization,Prohibited1,Prohibited2 (1)Sorcerer,Sorcerer (2)Cleric,Wizard,Domain1,Domain2 
        ' (the second class is how the class casts spells i.e. like a wizard or Sorcerer)
        Private colSpellsKnown As New Collection 'format:(0)level,spell,level,spell(1)level,spell,level,spell(2)level,spell,level,spell
        Private colSpellsUncast As New Collection 'format:(0)level,spell,level,spell(1)level,number,level,Number(2)level,spell,level,spell
        Public colNewFeats As New Collection 'format: Type,Listname  General,All  class,FighterFeat class,Monkfeat1  race,Human
        Private strCustom1 As String
        Private strCustom1Stat As String
        Private dblCustom1ClassRanks As Double
        Private dblCustom1CrossRanks As Double
        Private strCustom2 As String
        Private strCustom2Stat As String
        Private dblCustom2ClassRanks As Double
        Private dblCustom2CrossRanks As Double
        Public strSavePath As String
        Public Sub New()
            colClasses = New Collection
            colCaster = New Collection
        End Sub
        Public Function chain(ByVal strKey As String, ByVal strfilename As String, ByVal bolErrorMsg As Boolean) As String
            Dim strCurrentSearchItem As String = ""
            Dim strArray(0) As String
            Dim objReader As IO.StreamReader
            Dim bolFound As Boolean = False
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\" & strfilename) = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\" & strfilename)
                Do
                    strCurrentSearchItem = objReader.ReadLine()
                    ReDim strArray(frmCharacterSheet.NumOfItems(strCurrentSearchItem))
                    strArray = Split(strCurrentSearchItem, ",")
                    If objReader.Peek = -1 And strArray(0) <> strKey Then
                        If bolErrorMsg = True Then
                            MessageBox.Show(strKey & " was not found", strfilename + ": Error")
                        End If
                        Return ""
                    End If
                    If strArray.Length > 1 Then
                        If strArray(0) = strKey Or strArray(0) + "," + strArray(1) = strKey Or strArray(1) = strKey Then
                            bolFound = True
                        End If
                    Else
                        If strArray(0) = strKey Then
                            bolFound = True
                        End If
                    End If
                Loop Until bolFound
            End If
            Return strCurrentSearchItem
        End Function
        Public Sub AddFeat(ByVal strFeat As String)
            'need to get a file that adds schools to spell focus or weapons to weapon focus
            Dim strFindFeat As String
            Dim strArray() As String
            Dim colItems As New Collection
            Dim i As Integer
            strFindFeat = chain(strFeat, "FeatSubCategories.txt", False)
            If strFindFeat <> "End" And strFindFeat <> "" Then
                strArray = Split(strFeat, ",")
                For i = 1 To strArray.Length - 1
                    colItems.Add(strArray(i))
                Next
                frmCharacterSheet.strFeatName = strFeat
                frmCharacterSheet.colFeatSubCategories = colItems
                frmFeatSubCategories.ShowDialog()
            Else
                colFeats.Add(strFeat)
            End If

        End Sub
        Public Function GetFeatCollection() As Collection
            Return colFeats
        End Function

        Public Sub setCustomSkill(ByVal strName As String, ByVal strStat As String, ByVal dblClassPoints As Double, ByVal dblCrossPoints As Double, ByVal bolFirstSkill As Boolean)
            If bolFirstSkill = True Then
                strCustom1 = strName
                strCustom1Stat = strStat
                dblCustom1ClassRanks = dblClassPoints
                dblCustom1CrossRanks = dblCrossPoints
            Else
                strCustom2 = strName
                strCustom2Stat = strStat
                dblCustom2ClassRanks = dblClassPoints
                dblCustom2CrossRanks = dblCrossPoints
            End If
        End Sub
        Public Function getCustomSkillStat(ByVal bolFirstSkill As Boolean) As String
            If bolFirstSkill = True Then
                Return strCustom1Stat
            Else
                Return strCustom2Stat
            End If
        End Function
        Public Function GetCustomSkillName(ByVal bolFirstSkill As Boolean) As String
            If bolFirstSkill Then
                Return strCustom1
            Else
                Return strCustom2
            End If
        End Function
        Public Function GetCustomSkillClassRanks(ByVal bolfirstskill As Boolean) As Double
            If bolfirstskill = True Then
                Return dblCustom1ClassRanks
            Else
                Return dblCustom2ClassRanks
            End If
        End Function
        Public Function GetCustomSkillCrossRanks(ByVal bolfirstskill As Boolean) As Double
            If bolfirstskill = True Then
                Return dblCustom1CrossRanks
            Else
                Return dblCustom2CrossRanks
            End If
        End Function

        Public Sub CharacterSave(ByVal strSavePath As String)
            Dim strSave As String = ""
            Dim strCollection As String = ""
            Dim x As Integer = 0
            Dim y As Integer = 0
            strSave += strName
            strSave += "*" + strRace
            strSave += "*" + strAlignment
            strSave += "*" + Convert.ToString(intExperience)
            strSave += "*" + Convert.ToString(intlevel)
            strSave += "*" + Convert.ToString(intBAB)
            strSave += "*" + Convert.ToString(intMonkBAB)
            strSave += "*" + Convert.ToString(intArmorCheckPenalty)
            'these are the base stats
            strSave += "*" + Convert.ToString(intBaseStr)
            strSave += "*" + Convert.ToString(intBaseDex)
            strSave += "*" + Convert.ToString(intBaseCon)
            strSave += "*" + Convert.ToString(intBaseWis)
            strSave += "*" + Convert.ToString(intBaseInt)
            strSave += "*" + Convert.ToString(IntBaseCha)
            'these are the enhanced stats
            strSave += "*" + Convert.ToString(intStr)
            strSave += "*" + Convert.ToString(intDex)
            strSave += "*" + Convert.ToString(intCon)
            strSave += "*" + Convert.ToString(intWis)
            strSave += "*" + Convert.ToString(intInt)
            strSave += "*" + Convert.ToString(IntCha)
            'Mod values are the modifiers for their base scores.
            strSave += "*" + Convert.ToString(intStrMod)
            strSave += "*" + Convert.ToString(intDexMod)
            strSave += "*" + Convert.ToString(intConMod)
            strSave += "*" + Convert.ToString(intWisMod)
            strSave += "*" + Convert.ToString(intIntMod)
            strSave += "*" + Convert.ToString(IntChaMod)
            For Each strItem As String In colKnownSpells
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colUnusedSpells
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colFeats
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colSpecials
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colNewSpells
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each intItem As Integer In intHP
                strCollection += Convert.ToString(intItem) + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            strSave += "*" + Convert.ToString(intSkillpoints)
            strSave += "*" + strSkillClass + "*"
            For x = 0 To 43
                For y = 0 To 1
                    strSave += Convert.ToString(dblSkillArray(x, y)) + "/"
                Next
            Next
            strSave += "*" + strHelmet
            strSave += "*" + strArmor
            strSave += "*" + strRobe
            strSave += "*" + strBracer
            strSave += "*" + strRing1
            strSave += "*" + strRing2
            strSave += "*" + strGloves
            strSave += "*" + strBoots
            strSave += "*" + strMainHand
            strSave += "*" + strOffHand
            For Each strItem As String In colMisc
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colItems
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            strSave += "*" + Convert.ToString(intCopper)
            strSave += "*" + Convert.ToString(intSilver)
            strSave += "*" + Convert.ToString(intGold)
            strSave += "*" + Convert.ToString(intPlatinum)
            For Each strItem As String In colNewCasters
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colClasses
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            strSave += "*" + Convert.ToString(intCurrentCaster)
            For Each strItem As String In colCaster
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colSpellsKnown
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colSpellsUncast
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            For Each strItem As String In colNewFeats
                strCollection += strItem + "/"
            Next
            strSave += "*" + strCollection
            strCollection = ""
            Dim objWriter As New System.IO.StreamWriter(strSavePath)
            objWriter.Write(strSave)
            objWriter.Close()
        End Sub
        Public Sub CharacterLoad(ByVal strLoadPath As String)
            Dim strLoad As String = ""
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim strArray() As String
            Dim strCollection() As String
            Dim i As Integer = 0
            Dim strClassArray() As String
            If System.IO.File.Exists(strLoadPath) = True Then
                Dim objWriter As New System.IO.StreamReader(strLoadPath)
                strLoad = objWriter.ReadLine()
                objWriter.Close()
                strArray = Split(strLoad, "*")
                strName = strArray(0)
                strRace = strArray(1)
                strAlignment = strArray(2)
                intExperience = Convert.ToInt32(strArray(3))
                intlevel = Convert.ToInt32(strArray(4))
                intBAB = Convert.ToInt32(strArray(5))
                intMonkBAB = Convert.ToInt32(strArray(6))
                intArmorCheckPenalty = Convert.ToInt32(strArray(7))
                intBaseStr = Convert.ToInt32(strArray(8))
                intBaseDex = Convert.ToInt32(strArray(9))
                intBaseCon = Convert.ToInt32(strArray(10))
                intBaseWis = Convert.ToInt32(strArray(11))
                intBaseInt = Convert.ToInt32(strArray(12))
                IntBaseCha = Convert.ToInt32(strArray(13))
                intStr = Convert.ToInt32(strArray(14))
                intDex = Convert.ToInt32(strArray(15))
                intCon = Convert.ToInt32(strArray(16))
                intWis = Convert.ToInt32(strArray(17))
                intInt = Convert.ToInt32(strArray(18))
                IntCha = Convert.ToInt32(strArray(19))
                intStrMod = Convert.ToInt32(strArray(20))
                intDexMod = Convert.ToInt32(strArray(21))
                intConMod = Convert.ToInt32(strArray(22))
                intWisMod = Convert.ToInt32(strArray(23))
                intIntMod = Convert.ToInt32(strArray(24))
                IntChaMod = Convert.ToInt32(strArray(25))
                strCollection = Split(strArray(26), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colKnownSpells.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(27), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colUnusedSpells.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(28), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colFeats.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(29), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colSpecials.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(30), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colNewSpells.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(31), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        intHP(i) = Convert.ToInt32(stritem)
                    End If
                    i += 1
                Next

                intSkillpoints = Convert.ToInt32(strArray(32))
                strSkillClass = strArray(33)
                strCollection = Split(strArray(34), "/")
                i = 0
                For x = 0 To 43
                    For y = 0 To 1
                        If strCollection(i) <> "" Then
                            dblSkillArray(x, y) = Convert.ToDouble(strCollection(i))
                        End If
                        i += 1
                    Next
                Next
                strHelmet = strArray(35)
                strArmor = strArray(36)
                strRobe = strArray(37)
                strBracer = strArray(38)
                strRing1 = strArray(39)
                strRing2 = strArray(40)
                strGloves = strArray(41)
                strBoots = strArray(42)
                strMainHand = strArray(43)
                strOffHand = strArray(44)
                strCollection = Split(strArray(45), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colMisc.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(46), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colItems.Add(stritem)
                    End If
                Next
                intCopper = Convert.ToInt32(strArray(47))
                intSilver = Convert.ToInt32(strArray(48))
                intGold = Convert.ToInt32(strArray(49))
                intPlatinum = Convert.ToInt32(strArray(50))
                strCollection = Split(strArray(51), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colNewCasters.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(52), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        strClassArray = Split(stritem, ",")
                        colClasses.Add(stritem, strClassArray(0))
                    End If
                Next
                intCurrentCaster = Convert.ToInt32(strArray(53))
                strCollection = Split(strArray(54), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colCaster.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(55), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colSpellsKnown.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(56), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colSpellsUncast.Add(stritem)
                    End If
                Next
                strCollection = Split(strArray(57), "/")
                For Each stritem As String In strCollection
                    If stritem <> "" Then
                        colNewFeats.Add(stritem)
                    End If
                Next
            End If
        End Sub
        Public Sub AddNewFeatList(ByVal strType As String, ByVal strListName As String)
            colNewFeats.Add(strType + "," + strListName)
        End Sub
        Private Function DiceRoll(ByVal intDiceNum As Integer, ByVal intDiceSize As Integer) As Integer
            Randomize()
            Dim intRoll As Integer = 0
            ' This function returns the result of a simulated die or dice roll 
            Dim i As Integer
            For i = 1 To intDiceNum
                intRoll += Convert.ToInt32(((intDiceSize - 1) * Rnd()) + 1)
            Next
            Return intRoll
        End Function
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
        Public Function CollectionHas(ByRef collection As Collection, ByVal strItem As String) As Boolean
            Dim strSearch As String
            For Each strSearch In collection
                If strSearch = strItem Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Function CheckPrerequisites(ByVal strItem As String) As Boolean
            Dim objReader As IO.StreamReader
            Dim strReader As String = ""
            Dim strSplitReader(0) As String
            Dim i As Integer
            Dim strStatArray() As String
            Dim bolMeets As Boolean = True
            If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Prerequisites.txt") = True Then
                objReader = IO.File.OpenText(System.AppDomain.CurrentDomain.BaseDirectory & "\Prerequisites.txt")
                strReader = objReader.ReadLine()
                Do Until strReader = "End"
                    ReDim strSplitReader(NumOfItems(strReader))
                    strSplitReader = Split(strReader, ",")
                    If strSplitReader(0) = strItem Then
                        For i = 1 To strSplitReader.Length - 1 Step 2
                            If strSplitReader(i) = "feat" Then
                                If CollectionHas(colFeats, strSplitReader(i + 1)) = False Then
                                    bolMeets = False
                                End If
                            ElseIf strSplitReader(i) = "notfeat" Then
                                If CollectionHas(colFeats, strSplitReader(i + 1)) = True Then
                                    bolMeets = False
                                End If
                            ElseIf strSplitReader(i) = "stat" Then
                                strStatArray = Split(strSplitReader(i + 1))
                                If strStatArray(0) = "Str" Then
                                    If Convert.ToInt32(strStatArray(1)) > intStr Then
                                        bolMeets = False
                                    End If
                                ElseIf strStatArray(0) = "Dex" Then
                                    If Convert.ToInt32(strStatArray(1)) > intDex Then
                                        bolMeets = False
                                    End If
                                ElseIf strStatArray(0) = "Con" Then
                                    If Convert.ToInt32(strStatArray(1)) > intCon Then
                                        bolMeets = False
                                    End If
                                ElseIf strStatArray(0) = "Wis" Then
                                    If Convert.ToInt32(strStatArray(1)) > intWis Then
                                        bolMeets = False
                                    End If
                                ElseIf strStatArray(0) = "Int" Then
                                    If Convert.ToInt32(strStatArray(1)) > intInt Then
                                        bolMeets = False
                                    End If
                                ElseIf strStatArray(0) = "Cha" Then
                                    If Convert.ToInt32(strStatArray(1)) > IntCha Then
                                        bolMeets = False
                                    End If
                                End If
                            ElseIf strSplitReader(i) = "BAB" Then
                                If Convert.ToInt32(strSplitReader(i + 1)) > intBAB Then
                                    bolMeets = False
                                End If
                            End If
                        Next
                    End If
                    strReader = objReader.ReadLine()
                Loop
                objReader.Close()
            End If
            Return bolMeets
        End Function
        Public Sub AddCasterLevelup(ByVal strCaster As String, ByVal intLevel As Integer)
            colNewCasters.Add(strCaster + "," + Convert.ToString(intLevel))
        End Sub
        Public Function GetNewCasterLevelup() As String()
            Dim CasterArray(2) As String
            CasterArray = Split(Convert.ToString(colNewCasters(1)), ",")
            Return CasterArray
        End Function
        Public Function intDexBonus() As Integer
            If intDexMod > 0 Then
                Return intDexMod
            Else
                Return 0
            End If
        End Function
        Public Function intConBonus() As Integer
            If intConMod > 0 Then
                Return intConMod
            Else
                Return 0
            End If
        End Function
        Public Function intWisBonus() As Integer
            If intWisMod > 0 Then
                Return intWisMod
            Else
                Return 0
            End If
        End Function
        Public Function intChaBonus() As Integer
            If IntChaMod > 0 Then
                Return IntChaMod
            Else
                Return 0
            End If
        End Function
        Public Function intIntBonus() As Integer
            If intIntMod > 0 Then
                Return intIntMod
            Else
                Return 0
            End If
        End Function
        Public Function intStrBonus() As Integer
            If intStrMod > 0 Then
                Return intStrMod
            Else
                Return 0
            End If
        End Function
        Public Sub AddNewSpells(ByVal intNumberOfSpells As Integer, ByVal intSpellLevel As Integer, ByVal strClass As String)
            colNewSpells.Add(Convert.ToString(intNumberOfSpells) + "," + Convert.ToString(intSpellLevel) + "," + strClass)
        End Sub
        Public Function NewSpellsExist() As Boolean
            If colNewSpells.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function GetNewSpells() As String
            If colNewSpells.Count <> 0 Then
                Return colNewSpells(1).ToString
            Else
                Return "None"
            End If
        End Function
        Public Function HasClass(ByVal strClass As String) As Boolean
            Return colClasses.Contains(strClass)
        End Function
        Public Sub AddClass(ByVal strclass As String, ByVal intLevel As Integer)
            If colClasses.Contains(strclass) Then
                colClasses.Remove(strclass)
            End If
            colClasses.Add(strclass + "," + Convert.ToString(intLevel), strclass)
        End Sub
        Public Function GetNumOfClasses() As Integer
            Return colClasses.Count
        End Function
        Public Function GetClassCollection() As Collection
            Dim colClassesOnly As New Collection
            Dim strSplit() As String = Nothing
            Dim strString As String
            For Each strString In colClasses
                strSplit = Split(strString, ",")
                colClassesOnly.Add(strSplit(0))
            Next
            Return colClassesOnly
        End Function
        Public Function GetClassLevel(ByVal strClass As String) As Integer
            Dim strSplit() As String
            If colClasses.Contains(strClass) Then
                strSplit = Split(Convert.ToString(colClasses(strClass)), ",")
                If colClasses.Contains(strClass) Then
                    Return Convert.ToInt32(strSplit(1))
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Function
        Public Sub IncrementLevel(ByVal strClass As String)
            Dim strSplit() As String
            If colClasses.Contains(strClass) Then
                strSplit = Split(Convert.ToString(colClasses(strClass)), ",")
                colClasses.Remove(strClass)
                colClasses.Add(strClass + "," + Convert.ToString(Convert.ToInt32(strSplit(1)) + 1), strClass)
            Else
                colClasses.Add(strClass + ",1", strClass)
            End If
        End Sub
        Public Function LevelUpHp(ByVal strClass As String, ByVal bolRolledHP As Boolean) As Integer
            Dim intHP As Integer
            Dim strElements() As String
            strElements = Split(frmSkills.chain(strClass, "ClassLevelUp2.txt", True), ",")
            If bolRolledHP = True Then
                intHP = DiceRoll(1, Convert.ToInt32(strElements(1)))
            Else
                If intlevel <> 1 Then
                    intHP = Convert.ToInt32(Convert.ToDouble(strElements(1)) / 2)
                Else
                    intHP = Convert.ToInt32(strElements(1))
                End If
            End If
            Return intHP
        End Function
        Public Function LevelUpSkillPoints(ByVal strClass As String) As Integer
            Dim intSkillPoints As Integer
            Dim strElements() As String
            strElements = Split(frmSkills.chain(strClass, "ClassLevelUp2.txt", True), ",")
            strSkillClass = strClass
            intSkillPoints = Convert.ToInt32(strElements(2)) + intIntMod
            If strRace = "Human" Then
                intSkillPoints += 1
            End If
            If intlevel = 1 Then
                intSkillPoints *= 4
            End If
            Return intSkillPoints
        End Function
        Public Sub LevelUp(ByVal strClass As String, ByVal bolRolledHP As Boolean)
            Dim strCasterCheck As String
            Dim intClassLevel As Integer
            colNewCasters.Clear()
            intlevel += 1

            IncrementLevel(strClass)
            intHP(intlevel - 1) = LevelUpHp(strClass, bolRolledHP)
            intSkillpoints = LevelUpSkillPoints(strClass)
            strSkillClass = strClass
            If intlevel = 1 Or intlevel Mod 3 = 0 Then
                AddNewFeatList("general", "")
            End If
            strCasterCheck = strClass + "," + Convert.ToString(GetClassLevel(strClass))
            If isCaster(strCasterCheck) = True Then
                If frmSkills.chain(strCasterCheck, "SpellsKnownLevelUp.txt", True) <> "" Then
                    intClassLevel = GetClassLevel(strClass)
                    AddCasterLevelup(strClass, intClassLevel)
                    frmCharacterSheet.colStack.Add("WizardCreation")
                End If
            End If
            frmCharacterSheet.colStack.Add("Skills")
        End Sub

        Public Function GetNewClasses() As Collection 'returns a collection of available classes for level up
            Dim colClasses As New Collection
            Dim objReader As IO.StreamReader
            Dim strSplitReader() As String
            Dim strSearchItem As String
            Dim strStatArray() As String
            Dim i As Integer
            Dim bolMeets As Boolean
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassPrerequisites.txt") = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\ClassPrerequisites.txt")
                strSearchItem = objReader.ReadLine()
                Do While objReader.Peek <> -1
                    strSplitReader = Split(strSearchItem, ",")
                    bolMeets = True
                    For i = 1 To strSplitReader.Length - 1 Step 3
                        If strSplitReader(i) = "feat" Then
                            If CollectionHas(colFeats, strSplitReader(i + 1)) = False Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "notfeat" Then
                            If CollectionHas(colFeats, strSplitReader(i + 1)) = True Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "stat" Then
                            strStatArray = Split(strSplitReader(i + 1))
                            If strStatArray(0) = "Str" Then
                                If Convert.ToInt32(strStatArray(1)) > intStr Then
                                    bolMeets = False
                                End If
                            ElseIf strStatArray(0) = "Dex" Then
                                If Convert.ToInt32(strStatArray(1)) > intDex Then
                                    bolMeets = False
                                End If
                            ElseIf strStatArray(0) = "Con" Then
                                If Convert.ToInt32(strStatArray(1)) > intCon Then
                                    bolMeets = False
                                End If
                            ElseIf strStatArray(0) = "Wis" Then
                                If Convert.ToInt32(strStatArray(1)) > intWis Then
                                    bolMeets = False
                                End If
                            ElseIf strStatArray(0) = "Int" Then
                                If Convert.ToInt32(strStatArray(1)) > intInt Then
                                    bolMeets = False
                                End If
                            ElseIf strStatArray(0) = "Cha" Then
                                If Convert.ToInt32(strStatArray(1)) > IntCha Then
                                    bolMeets = False
                                End If
                            End If
                        ElseIf strSplitReader(i) = "BAB" Then
                            If Convert.ToInt32(strSplitReader(i + 2)) > intBAB Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "race" Then
                            If strRace <> strSplitReader(i + 2) Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "spell" Then
                            If colSpellsKnown.Contains(strSplitReader(i + 2)) = False Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "custom" Then

                        ElseIf strSplitReader(i) = "alignment" Then
                            If strAlignment <> strSplitReader(i + 2) Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "notalignment" Then
                            If strAlignment = strSplitReader(i + 2) Then
                                bolMeets = False
                            End If
                        ElseIf strSplitReader(i) = "skill" Then

                        End If
                    Next
                    If bolMeets = True Then
                        colClasses.Add(strSplitReader(0))
                    End If
                    strSearchItem = objReader.ReadLine()
                Loop
            End If
            Return colClasses
        End Function

        Public Function isCaster(ByVal strKey As String) As Boolean
            Dim strCurrentSearchItem As String = ""
            Dim strfilename As String = "SpellsKnownLevelUp.txt"
            Dim strArray(0) As String
            Dim objReader As IO.StreamReader
            Dim bolFound As Boolean = False
            If My.Computer.FileSystem.FileExists(System.AppDomain.CurrentDomain.BaseDirectory & "\" & strfilename) = True Then
                objReader = My.Computer.FileSystem.OpenTextFileReader(System.AppDomain.CurrentDomain.BaseDirectory & "\" & strfilename)
                Do
                    strCurrentSearchItem = objReader.ReadLine()
                    ReDim strArray(frmCharacterSheet.NumOfItems(strCurrentSearchItem))
                    strArray = Split(strCurrentSearchItem, ",")
                    If objReader.Peek = -1 And strArray(0) <> strKey Then
                        Return False
                    End If
                    If strArray.Length > 1 Then
                        If strArray(0) = strKey Or strArray(0) + "," + strArray(1) = strKey Then
                            bolFound = True
                        End If
                    Else
                        If strArray(0) = strKey Then
                            bolFound = True
                        End If
                    End If
                Loop Until bolFound
                objReader.Close()
            End If
            Return bolFound
        End Function
        Public Function NextCaster() As String
            If intCurrentCaster < colCaster.Count Then
                intCurrentCaster += 1
            End If
            Return Convert.ToString(colCaster.Item(intCurrentCaster))
        End Function
        Public Function PrevCaster() As String
            If intCurrentCaster > 1 Then
                intCurrentCaster -= 1
            End If
            Return Convert.ToString(colCaster.Item(intCurrentCaster))
        End Function
        Public Function GetCasterString(ByVal strSearch As String) As String
            Dim strCaster As String
            Dim strArray() As String
            For Each strCaster In colCaster
                strArray = Split(strCaster, ",")
                If strArray(0) = strSearch Then
                    Return strCaster
                End If
            Next
            Return ""

        End Function
        Public Sub AddSpell(ByVal strClass As String, ByVal strSpell As String, ByVal strLevel As String)
            colSpellsKnown.Add(strClass + "," + strLevel + "," + strSpell, strClass + "," + strLevel + "," + strSpell)
        End Sub
        Public Sub RemoveSpell(ByVal strClass As String, ByVal strSpell As String, ByVal strLevel As String)
            colSpellsKnown.Remove(strClass + "," + strLevel + "," + strSpell)
        End Sub
        Public Function GetHPTotal() As Integer
            Dim intHPtotal As Integer
            Dim int As Integer
            For Each int In intHP
                intHPtotal += int
            Next
            intHPtotal += intConBonus() * intlevel
            Return intHPtotal
        End Function
        Public Sub StatSet(ByVal strStat As String, ByVal intValue As Integer)
            Select Case strStat
                Case "str"
                    intStr = intValue
                    intBaseStr = intValue
                    If intStr Mod 2 = 1 Then
                        intStrMod = Convert.ToInt32((intStr - 11) / 2)
                    Else
                        intStrMod = Convert.ToInt32((intStr - 10) / 2)
                    End If
                Case "dex"
                    intDex = intValue
                    intBaseDex = intValue
                    If intStr Mod 2 = 1 Then
                        intDexMod = Convert.ToInt32((intDex - 11) / 2)
                    Else
                        intDexMod = Convert.ToInt32((intDex - 10) / 2)
                    End If
                Case "con"
                    intCon = intValue
                    intBaseCon = intValue
                    If intStr Mod 2 = 1 Then
                        intConMod = Convert.ToInt32((intCon - 11) / 2)
                    Else
                        intConMod = Convert.ToInt32((intCon - 10) / 2)
                    End If
                Case "wis"
                    intWis = intValue
                    intBaseWis = intValue
                    If intStr Mod 2 = 1 Then
                        intWisMod = Convert.ToInt32((intWis - 11) / 2)
                    Else
                        intWisMod = Convert.ToInt32((intWis - 10) / 2)
                    End If
                Case "int"
                    intInt = intValue
                    intBaseInt = intValue
                    If intStr Mod 2 = 1 Then
                        intIntMod = Convert.ToInt32((intInt - 11) / 2)
                    Else
                        intIntMod = Convert.ToInt32((intInt - 10) / 2)
                    End If
                Case "cha"
                    IntCha = intValue
                    IntBaseCha = intValue
                    If intStr Mod 2 = 1 Then
                        IntChaMod = Convert.ToInt32((IntCha - 11) / 2)
                    Else
                        IntChaMod = Convert.ToInt32((IntCha - 10) / 2)
                    End If
            End Select
        End Sub
        Public Sub ResetStat(ByVal strStat As String)
            'this function sets the modified stat equal to the base stat
            Select Case strStat
                Case "str"
                    intStr = intBaseStr
                    If intStr Mod 2 = 1 Then
                        intStrMod = Convert.ToInt32((intStr - 11) / 2)
                    Else
                        intStrMod = Convert.ToInt32((intStr - 10) / 2)
                    End If
                Case "dex"
                    intDex = intBaseDex
                    If intStr Mod 2 = 1 Then
                        intDexMod = Convert.ToInt32((intDex - 11) / 2)
                    Else
                        intDexMod = Convert.ToInt32((intDex - 10) / 2)
                    End If
                Case "con"
                    intCon = intBaseCon
                    If intStr Mod 2 = 1 Then
                        intConMod = Convert.ToInt32((intCon - 11) / 2)
                    Else
                        intConMod = Convert.ToInt32((intCon - 10) / 2)
                    End If
                Case "wis"
                    intWis = intBaseWis
                    If intStr Mod 2 = 1 Then
                        intWisMod = Convert.ToInt32((intWis - 11) / 2)
                    Else
                        intWisMod = Convert.ToInt32((intWis - 10) / 2)
                    End If
                Case "int"
                    intInt = intBaseInt
                    If intStr Mod 2 = 1 Then
                        intIntMod = Convert.ToInt32((intInt - 11) / 2)
                    Else
                        intIntMod = Convert.ToInt32((intInt - 10) / 2)
                    End If
                Case "cha"
                    IntCha = IntBaseCha
                    If intStr Mod 2 = 1 Then
                        IntChaMod = Convert.ToInt32((IntCha - 11) / 2)
                    Else
                        IntChaMod = Convert.ToInt32((IntCha - 10) / 2)
                    End If
            End Select
        End Sub
        Public Sub StatMod(ByVal strStat As String, ByVal intMod As Integer)
            'this function is for increasing the modified stat while not changing the base stat
            Select Case strStat
                Case "str"
                    intStr += intMod
                    If intStr Mod 2 = 1 Then
                        intStrMod = Convert.ToInt32((intStr - 11) / 2)
                    Else
                        intStrMod = Convert.ToInt32((intStr - 10) / 2)
                    End If
                Case "dex"
                    intDex += intMod
                    If intStr Mod 2 = 1 Then
                        intDexMod = Convert.ToInt32((intDex - 11) / 2)
                    Else
                        intDexMod = Convert.ToInt32((intDex - 10) / 2)
                    End If
                Case "con"
                    intCon += intMod
                    If intStr Mod 2 = 1 Then
                        intConMod = Convert.ToInt32((intCon - 11) / 2)
                    Else
                        intConMod = Convert.ToInt32((intCon - 10) / 2)
                    End If
                Case "wis"
                    intWis += intMod
                    If intStr Mod 2 = 1 Then
                        intWisMod = Convert.ToInt32((intWis - 11) / 2)
                    Else
                        intWisMod = Convert.ToInt32((intWis - 10) / 2)
                    End If
                Case "int"
                    intInt += intMod
                    If intStr Mod 2 = 1 Then
                        intIntMod = Convert.ToInt32((intInt - 11) / 2)
                    Else
                        intIntMod = Convert.ToInt32((intInt - 10) / 2)
                    End If
                Case "cha"
                    IntCha += intMod
                    If intStr Mod 2 = 1 Then
                        IntChaMod = Convert.ToInt32((IntCha - 11) / 2)
                    Else
                        IntChaMod = Convert.ToInt32((IntCha - 10) / 2)
                    End If
            End Select
        End Sub
        Public Sub StatBaseMod(ByVal strStat As String, ByVal intMod As Integer)
            'this function is used to change the base stat, usually by going up once every 4 levels
            Select Case strStat
                Case "str"
                    intBaseStr += intMod
                    intStr += intMod
                    If intStr Mod 2 = 1 Then
                        intStrMod = Convert.ToInt32((intStr - 11) / 2)
                    Else
                        intStrMod = Convert.ToInt32((intStr - 10) / 2)
                    End If
                Case "dex"
                    intBaseDex += intMod
                    intDex += intMod
                    If intStr Mod 2 = 1 Then
                        intDexMod = Convert.ToInt32((intDex - 11) / 2)
                    Else
                        intDexMod = Convert.ToInt32((intDex - 10) / 2)
                    End If
                Case "con"
                    intBaseCon += intMod
                    intCon += intMod
                    If intStr Mod 2 = 1 Then
                        intConMod = Convert.ToInt32((intCon - 11) / 2)
                    Else
                        intConMod = Convert.ToInt32((intCon - 10) / 2)
                    End If
                Case "wis"
                    intBaseWis += intMod
                    intWis += intMod
                    If intStr Mod 2 = 1 Then
                        intWisMod = Convert.ToInt32((intWis - 11) / 2)
                    Else
                        intWisMod = Convert.ToInt32((intWis - 10) / 2)
                    End If
                Case "int"
                    intBaseInt += intMod
                    intInt += intMod
                    If intStr Mod 2 = 1 Then
                        intIntMod = Convert.ToInt32((intInt - 11) / 2)
                    Else
                        intIntMod = Convert.ToInt32((intInt - 10) / 2)
                    End If
                Case "cha"
                    IntCha += intMod
                    IntBaseCha += intMod
                    If intStr Mod 2 = 1 Then
                        IntChaMod = Convert.ToInt32((IntCha - 11) / 2)
                    Else
                        IntChaMod = Convert.ToInt32((IntCha - 10) / 2)
                    End If
            End Select
        End Sub
        Public Sub SkillMod(ByVal strSkill As String, ByVal intMod As Integer, ByVal bolClassSkill As Boolean)
            Select Case strSkill
                Case "appraise"
                    If bolClassSkill Then
                        dblSkillArray(0, 0) += intMod
                    Else
                        dblSkillArray(0, 1) += intMod
                    End If
                Case "balance"
                    If bolClassSkill Then
                        dblSkillArray(1, 0) += intMod
                    Else
                        dblSkillArray(1, 1) += intMod
                    End If
                Case "bluff"
                    If bolClassSkill Then
                        dblSkillArray(2, 0) += intMod
                    Else
                        dblSkillArray(2, 1) += intMod
                    End If
                Case "climb"
                    If bolClassSkill Then
                        dblSkillArray(3, 0) += intMod
                    Else
                        dblSkillArray(3, 1) += intMod
                    End If
                Case "concentration"
                    If bolClassSkill Then
                        dblSkillArray(4, 0) += intMod
                    Else
                        dblSkillArray(4, 1) += intMod
                    End If
                Case "craft"
                    If bolClassSkill Then
                        dblSkillArray(5, 0) += intMod
                    Else
                        dblSkillArray(5, 1) += intMod
                    End If
                Case "decipher script"
                    If bolClassSkill Then
                        dblSkillArray(6, 0) += intMod
                    Else
                        dblSkillArray(6, 1) += intMod
                    End If
                Case "diplomacy"
                    If bolClassSkill Then
                        dblSkillArray(7, 0) += intMod
                    Else
                        dblSkillArray(7, 1) += intMod
                    End If
                Case "disable device"
                    If bolClassSkill Then
                        dblSkillArray(8, 0) += intMod
                    Else
                        dblSkillArray(8, 1) += intMod
                    End If
                Case "disguise"
                    If bolClassSkill Then
                        dblSkillArray(9, 0) += intMod
                    Else
                        dblSkillArray(9, 1) += intMod
                    End If
                Case "escapeartist"
                    If bolClassSkill Then
                        dblSkillArray(10, 0) += intMod
                    Else
                        dblSkillArray(10, 1) += intMod
                    End If
                Case "forgery"
                    If bolClassSkill Then
                        dblSkillArray(11, 0) += intMod
                    Else
                        dblSkillArray(11, 1) += intMod
                    End If
                Case "gatherinfo"
                    If bolClassSkill Then
                        dblSkillArray(12, 0) += intMod
                    Else
                        dblSkillArray(12, 1) += intMod
                    End If
                Case "handleanimal"
                    If bolClassSkill Then
                        dblSkillArray(13, 0) += intMod
                    Else
                        dblSkillArray(13, 1) += intMod
                    End If
                Case "heal"
                    If bolClassSkill Then
                        dblSkillArray(14, 0) += intMod
                    Else
                        dblSkillArray(14, 1) += intMod
                    End If
                Case "hide"
                    If bolClassSkill Then
                        dblSkillArray(15, 0) += intMod
                    Else
                        dblSkillArray(15, 1) += intMod
                    End If
                Case "intimidate"
                    If bolClassSkill Then
                        dblSkillArray(16, 0) += intMod
                    Else
                        dblSkillArray(16, 1) += intMod
                    End If
                Case "jump"
                    If bolClassSkill Then
                        dblSkillArray(17, 0) += intMod
                    Else
                        dblSkillArray(17, 1) += intMod
                    End If
                Case "arcana"
                    If bolClassSkill Then
                        dblSkillArray(18, 0) += intMod
                    Else
                        dblSkillArray(18, 1) += intMod
                    End If
                Case "engineering"
                    If bolClassSkill Then
                        dblSkillArray(19, 0) += intMod
                    Else
                        dblSkillArray(19, 1) += intMod
                    End If
                Case "dungeoneering"
                    If bolClassSkill Then
                        dblSkillArray(20, 0) += intMod
                    Else
                        dblSkillArray(20, 1) += intMod
                    End If
                Case "geography"
                    If bolClassSkill Then
                        dblSkillArray(21, 0) += intMod
                    Else
                        dblSkillArray(21, 1) += intMod
                    End If
                Case "history"
                    If bolClassSkill Then
                        dblSkillArray(22, 0) += intMod
                    Else
                        dblSkillArray(22, 1) += intMod
                    End If
                Case "local"
                    If bolClassSkill Then
                        dblSkillArray(23, 0) += intMod
                    Else
                        dblSkillArray(23, 1) += intMod
                    End If
                Case "nature"
                    If bolClassSkill Then
                        dblSkillArray(24, 0) += intMod
                    Else
                        dblSkillArray(24, 1) += intMod
                    End If
                Case "nobility"
                    If bolClassSkill Then
                        dblSkillArray(25, 0) += intMod
                    Else
                        dblSkillArray(25, 1) += intMod
                    End If
                Case "religion"
                    If bolClassSkill Then
                        dblSkillArray(26, 0) += intMod
                    Else
                        dblSkillArray(26, 1) += intMod
                    End If
                Case "theplanes"
                    If bolClassSkill Then
                        dblSkillArray(27, 0) += intMod
                    Else
                        dblSkillArray(27, 1) += intMod
                    End If
                Case "listen"
                    If bolClassSkill Then
                        dblSkillArray(28, 0) += intMod
                    Else
                        dblSkillArray(28, 1) += intMod
                    End If
                Case "movesilently"
                    If bolClassSkill Then
                        dblSkillArray(29, 0) += intMod
                    Else
                        dblSkillArray(29, 1) += intMod
                    End If
                Case "openlock"
                    If bolClassSkill Then
                        dblSkillArray(30, 0) += intMod
                    Else
                        dblSkillArray(30, 1) += intMod
                    End If
                Case "perform"
                    If bolClassSkill Then
                        dblSkillArray(31, 0) += intMod
                    Else
                        dblSkillArray(31, 1) += intMod
                    End If
                Case "sleightofhand"
                    If bolClassSkill Then
                        dblSkillArray(32, 0) += intMod
                    Else
                        dblSkillArray(32, 1) += intMod
                    End If
                Case "profession"
                    If bolClassSkill Then
                        dblSkillArray(33, 0) += intMod
                    Else
                        dblSkillArray(33, 1) += intMod
                    End If
                Case "ride"
                    If bolClassSkill Then
                        dblSkillArray(34, 0) += intMod
                    Else
                        dblSkillArray(34, 1) += intMod
                    End If
                Case "search"
                    If bolClassSkill Then
                        dblSkillArray(35, 0) += intMod
                    Else
                        dblSkillArray(35, 1) += intMod
                    End If
                Case "sensemotive"
                    If bolClassSkill Then
                        dblSkillArray(36, 0) += intMod
                    Else
                        dblSkillArray(36, 1) += intMod
                    End If
                Case "spellcraft"
                    If bolClassSkill Then
                        dblSkillArray(37, 0) += intMod
                    Else
                        dblSkillArray(37, 1) += intMod
                    End If
                Case "spot"
                    If bolClassSkill Then
                        dblSkillArray(38, 0) += intMod
                    Else
                        dblSkillArray(38, 1) += intMod
                    End If
                Case "survival"
                    If bolClassSkill Then
                        dblSkillArray(39, 0) += intMod
                    Else
                        dblSkillArray(39, 1) += intMod
                    End If
                Case "swim"
                    If bolClassSkill Then
                        dblSkillArray(40, 0) += intMod
                    Else
                        dblSkillArray(40, 1) += intMod
                    End If
                Case "tumble"
                    If bolClassSkill Then
                        dblSkillArray(41, 0) += intMod
                    Else
                        dblSkillArray(41, 1) += intMod
                    End If
                Case "usemagicdevice"
                    If bolClassSkill Then
                        dblSkillArray(42, 0) += intMod
                    Else
                        dblSkillArray(42, 1) += intMod
                    End If
                Case "userope"
                    If bolClassSkill Then
                        dblSkillArray(43, 0) += intMod
                    Else
                        dblSkillArray(43, 1) += intMod
                    End If
            End Select
        End Sub
        Public Sub SetSkillArray(ByVal dblInputArray(,) As Double)
            dblSkillArray = dblInputArray
        End Sub
        Public Sub castspell(ByVal strSpell As String, ByVal strCasterType As String)
            Dim intIndex As Integer
            Dim strArray() As String
            If strCasterType = "Wizard" Then
                For intIndex = 1 To colUnusedSpells.Count
                    If Convert.ToString(colUnusedSpells(1)) = strSpell Then
                        colUnusedSpells.Remove(intIndex)
                        intIndex = colUnusedSpells.Count + 1
                    End If
                Next
            Else
                For intIndex = 1 To colUnusedSpells.Count
                    strArray = Split(Convert.ToString(colUnusedSpells(intIndex)))
                    If strSpell = strArray(1) Then
                        colUnusedSpells.Remove(intIndex)
                        colUnusedSpells.Add(Convert.ToString(Convert.ToInt32(strArray(0)) - 1) + " " + strArray(1) + " " + strArray(2))
                        intIndex = colUnusedSpells.Count + 1
                    End If
                Next
            End If
        End Sub
        Public Function CheckSorcererSpells(ByVal intSpellLevel As Integer) As Boolean
            Dim intIndex As Integer
            Dim strArray() As String
            For intIndex = 1 To colUnusedSpells.Count
                strArray = Split(Convert.ToString(colUnusedSpells(intIndex)))
                If Convert.ToInt32(strArray(1)) = intSpellLevel Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Function GetSorcererSpells(ByVal intSpellLevel As Integer) As Integer
            Dim intIndex As Integer
            Dim strArray() As String
            'problem when cycling through wizard spells, need to change sorcerer spells to format "sorcerer,level,numspells"
            For intIndex = 1 To colUnusedSpells.Count
                strArray = Split(Convert.ToString(colUnusedSpells(intIndex)))
                If Convert.ToInt32(strArray(1)) = intSpellLevel Then
                    Return Convert.ToInt32(strArray(0))
                End If
            Next
            Return 0
        End Function
    End Class
End Namespace


