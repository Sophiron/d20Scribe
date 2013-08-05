Option Strict On

Public Class frmSkills
    Public bolSkillUpdate As Boolean = True
    Public Character As Character.PC
    Dim strClass As String
    Dim intSkillPoints As Integer
    Private Sub SkillsCalc()
        Dim dblclassskillpoints As Double
        Dim dblcrossclassskillpoints As Double
        Dim strAbilityScore As String = ""
        Dim intBonus As Integer = 0
        If txtClass.Text <> "" Then
            dblclassskillpoints += Convert.ToDouble(nudAppraise.Value) - Character.dblSkillArray(0, 0)
            dblclassskillpoints += Convert.ToDouble(nudBalance.Value) - Character.dblSkillArray(1, 0)
            dblclassskillpoints += Convert.ToDouble(nudBluff.Value) - Character.dblSkillArray(2, 0)
            dblclassskillpoints += Convert.ToDouble(nudClimb.Value) - Character.dblSkillArray(3, 0)
            dblclassskillpoints += Convert.ToDouble(nudConcentration.Value) - Character.dblSkillArray(4, 0)
            dblclassskillpoints += Convert.ToDouble(nudCraft.Value) - Character.dblSkillArray(5, 0)
            dblclassskillpoints += Convert.ToDouble(nudDecipherScript.Value) - Character.dblSkillArray(6, 0)
            dblclassskillpoints += Convert.ToDouble(nudDiplomacy.Value) - Character.dblSkillArray(7, 0)
            dblclassskillpoints += Convert.ToDouble(nudDisableDevice.Value) - Character.dblSkillArray(8, 0)
            dblclassskillpoints += Convert.ToDouble(nudDisguise.Value) - Character.dblSkillArray(9, 0)
            dblclassskillpoints += Convert.ToDouble(nudEscapeArtist.Value) - Character.dblSkillArray(10, 0)
            dblclassskillpoints += Convert.ToDouble(nudForgery.Value) - Character.dblSkillArray(11, 0)
            dblclassskillpoints += Convert.ToDouble(nudGatherInfo.Value) - Character.dblSkillArray(12, 0)
            dblclassskillpoints += Convert.ToDouble(nudHandleAnimal.Value) - Character.dblSkillArray(13, 0)
            dblclassskillpoints += Convert.ToDouble(nudHeal.Value) - Character.dblSkillArray(14, 0)
            dblclassskillpoints += Convert.ToDouble(nudHide.Value) - Character.dblSkillArray(15, 0)
            dblclassskillpoints += Convert.ToDouble(nudIntimidate.Value) - Character.dblSkillArray(16, 0)
            dblclassskillpoints += Convert.ToDouble(nudJump.Value) - Character.dblSkillArray(17, 0)
            dblclassskillpoints += Convert.ToDouble(nudArcana.Value) - Character.dblSkillArray(18, 0)
            dblclassskillpoints += Convert.ToDouble(nudEngineering.Value) - Character.dblSkillArray(19, 0)
            dblclassskillpoints += Convert.ToDouble(nudDungeoneering.Value) - Character.dblSkillArray(20, 0)
            dblclassskillpoints += Convert.ToDouble(nudGeography.Value) - Character.dblSkillArray(21, 0)
            dblclassskillpoints += Convert.ToDouble(nudHistory.Value) - Character.dblSkillArray(22, 0)
            dblclassskillpoints += Convert.ToDouble(nudLocal.Value) - Character.dblSkillArray(23, 0)
            dblclassskillpoints += Convert.ToDouble(nudNature.Value) - Character.dblSkillArray(24, 0)
            dblclassskillpoints += Convert.ToDouble(nudNobility.Value) - Character.dblSkillArray(25, 0)
            dblclassskillpoints += Convert.ToDouble(nudReligion.Value) - Character.dblSkillArray(26, 0)
            dblclassskillpoints += Convert.ToDouble(nudThePlanes.Value) - Character.dblSkillArray(27, 0)
            dblclassskillpoints += Convert.ToDouble(nudListen.Value) - Character.dblSkillArray(28, 0)
            dblclassskillpoints += Convert.ToDouble(nudMoveSilently.Value) - Character.dblSkillArray(29, 0)
            dblclassskillpoints += Convert.ToDouble(nudOpenLock.Value) - Character.dblSkillArray(30, 0)
            dblclassskillpoints += Convert.ToDouble(nudPerform.Value) - Character.dblSkillArray(31, 0)
            dblclassskillpoints += Convert.ToDouble(nudSleightOfHand.Value) - Character.dblSkillArray(32, 0)
            dblclassskillpoints += Convert.ToDouble(nudProfession.Value) - Character.dblSkillArray(33, 0)
            dblclassskillpoints += Convert.ToDouble(nudRide.Value) - Character.dblSkillArray(34, 0)
            dblclassskillpoints += Convert.ToDouble(nudSearch.Value) - Character.dblSkillArray(35, 0)
            dblclassskillpoints += Convert.ToDouble(nudSenseMotive.Value) - Character.dblSkillArray(36, 0)
            dblclassskillpoints += Convert.ToDouble(nudSpellcraft.Value) - Character.dblSkillArray(37, 0)
            dblclassskillpoints += Convert.ToDouble(nudSpot.Value) - Character.dblSkillArray(38, 0)
            dblclassskillpoints += Convert.ToDouble(nudSurvival.Value) - Character.dblSkillArray(39, 0)
            dblclassskillpoints += Convert.ToDouble(nudSwim.Value) - Character.dblSkillArray(40, 0)
            dblclassskillpoints += Convert.ToDouble(nudTumble.Value) - Character.dblSkillArray(41, 0)
            dblclassskillpoints += Convert.ToDouble(nudUseMagicDevice.Value) - Character.dblSkillArray(42, 0)
            dblclassskillpoints += Convert.ToDouble(nudUseRope.Value) - Character.dblSkillArray(43, 0)
            dblclassskillpoints += Convert.ToDouble(nudCustom1.Value) - Character.dblSkillArray(44, 0)
            dblclassskillpoints += Convert.ToDouble(nudCustom2.Value) - Character.dblSkillArray(45, 0)
            dblcrossclassskillpoints += Convert.ToDouble(nudAppraiseCC.Value) - Character.dblSkillArray(0, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudBalanceCC.Value) - Character.dblSkillArray(1, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudbluffCC.Value) - Character.dblSkillArray(2, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudClimbCC.Value) - Character.dblSkillArray(3, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudConcentrationCC.Value) - Character.dblSkillArray(4, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudCraftCC.Value) - Character.dblSkillArray(5, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudDecipherScriptCC.Value) - Character.dblSkillArray(6, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudDiplomacyCC.Value) - Character.dblSkillArray(7, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudDisableDeviceCC.Value) - Character.dblSkillArray(8, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudDisguiseCC.Value) - Character.dblSkillArray(9, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudEscapeArtistCC.Value) - Character.dblSkillArray(10, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudForgeryCC.Value) - Character.dblSkillArray(11, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudGatherInfoCC.Value) - Character.dblSkillArray(12, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudHandleAnimalCC.Value) - Character.dblSkillArray(13, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudHealCC.Value) - Character.dblSkillArray(14, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudHideCC.Value) - Character.dblSkillArray(15, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudIntimidateCC.Value) - Character.dblSkillArray(16, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudJumpCC.Value) - Character.dblSkillArray(17, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudArcanaCC.Value) - Character.dblSkillArray(18, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudEngineeringCC.Value) - Character.dblSkillArray(19, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudDungeoneeringCC.Value) - Character.dblSkillArray(20, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudGeographyCC.Value) - Character.dblSkillArray(21, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudHistoryCC.Value) - Character.dblSkillArray(22, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudLocalCC.Value) - Character.dblSkillArray(23, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudNatureCC.Value) - Character.dblSkillArray(24, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudNobilityCC.Value) - Character.dblSkillArray(25, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudReligionCC.Value) - Character.dblSkillArray(26, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudThePlanesCC.Value) - Character.dblSkillArray(27, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudListenCC.Value) - Character.dblSkillArray(28, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudMoveSilentlyCC.Value) - Character.dblSkillArray(29, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudOpenLockCC.Value) - Character.dblSkillArray(30, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudPerformCC.Value) - Character.dblSkillArray(31, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSleightOfHandCC.Value) - Character.dblSkillArray(32, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudProfessionCC.Value) - Character.dblSkillArray(33, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudRideCC.Value) - Character.dblSkillArray(34, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSearchCC.Value) - Character.dblSkillArray(35, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSenseMotiveCC.Value) - Character.dblSkillArray(36, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSpellCraftCC.Value) - Character.dblSkillArray(37, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSpotCC.Value) - Character.dblSkillArray(38, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSurvivalCC.Value) - Character.dblSkillArray(39, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudSwimCC.Value) - Character.dblSkillArray(40, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudTumbleCC.Value) - Character.dblSkillArray(41, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudUseMagicDeviceCC.Value) - Character.dblSkillArray(42, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudUseRopeCC.Value) - Character.dblSkillArray(43, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudCustom1CC.Value) - Character.dblSkillArray(44, 1)
            dblcrossclassskillpoints += Convert.ToDouble(nudCustom2CC.Value) - Character.dblSkillArray(45, 1)
            txtSkillPointsLeft.Text = Convert.ToString(Convert.ToDouble(txtTotalSkillPoints.Text) - dblclassskillpoints - (dblcrossclassskillpoints * 2))
            Character.intSkillpoints = Convert.ToInt32(txtSkillPointsLeft.Text)
        End If
        
        txtAppraise.Text = Convert.ToString(nudAppraise.Value + nudAppraiseCC.Value + Convert.ToInt32(txtAppraiseBonus.Text) + statbonus("Appraise"))
        txtBalance.Text = Convert.ToString(nudBalance.Value + nudBalanceCC.Value + Convert.ToInt32(txtBalanceBonus.Text) + statbonus("Balance"))
        txtBluff.Text = Convert.ToString(nudBluff.Value + nudbluffCC.Value + Convert.ToInt32(txtBluffBonus.Text) + statbonus("Bluff"))
        txtClimb.Text = Convert.ToString(nudClimb.Value + nudClimbCC.Value + Convert.ToInt32(txtClimbBonus.Text) + statbonus("Climb"))
        txtConcentration.Text = Convert.ToString(nudConcentration.Value + nudConcentrationCC.Value + Convert.ToInt32(txtConcentrationBonus.Text) + statbonus("Concentration"))
        txtCraft.Text = Convert.ToString(nudCraft.Value + nudCraftCC.Value + Convert.ToInt32(txtCraftBonus.Text) + statbonus("Craft"))
        txtDecipherScript.Text = Convert.ToString(nudDecipherScript.Value + nudDecipherScriptCC.Value + Convert.ToInt32(txtDecipherScriptBonus.Text) + statbonus("Decipher Script"))
        txtDiplomacy.Text = Convert.ToString(nudDiplomacy.Value + nudDiplomacyCC.Value + Convert.ToInt32(txtDiplomacyBonus.Text) + statbonus("Diplomacy"))
        txtDisableDevice.Text = Convert.ToString(nudDisableDevice.Value + nudDisableDeviceCC.Value + Convert.ToInt32(txtDisableDeviceBonus.Text) + statbonus("Disable Device"))
        txtDisguise.Text = Convert.ToString(nudDisguise.Value + nudDisguiseCC.Value + Convert.ToInt32(txtDisguiseBonus.Text) + statbonus("Disguise"))
        txtEscapeArtist.Text = Convert.ToString(nudEscapeArtist.Value + nudEscapeArtistCC.Value + Convert.ToInt32(txtEscapeArtistBonus.Text) + statbonus("Escape Artist"))
        txtForgery.Text = Convert.ToString(nudForgery.Value + nudForgeryCC.Value + Convert.ToInt32(txtForgeryBonus.Text) + statbonus("Forgery"))
        txtGatherInfo.Text = Convert.ToString(nudGatherInfo.Value + nudGatherInfoCC.Value + Convert.ToInt32(txtGatherInfoBonus.Text) + statbonus("Gather Information"))
        txtHandleAnimal.Text = Convert.ToString(nudHandleAnimal.Value + nudHandleAnimalCC.Value + Convert.ToInt32(txtHandleAnimalBonus.Text) + statbonus("Handle Animal"))
        txtHeal.Text = Convert.ToString(nudHeal.Value + nudHealCC.Value + Convert.ToInt32(txtHealBonus.Text) + statbonus("Heal"))
        txtHide.Text = Convert.ToString(nudHide.Value + nudHideCC.Value + Convert.ToInt32(txtHideBonus.Text) + statbonus("Hide"))
        txtIntimidate.Text = Convert.ToString(nudIntimidate.Value + nudIntimidateCC.Value + Convert.ToInt32(txtIntimidateBonus.Text) + statbonus("Intimidate"))
        txtJump.Text = Convert.ToString(nudJump.Value + nudJumpCC.Value + Convert.ToInt32(txtJumpBonus.Text) + statbonus("Jump"))
        txtArcana.Text = Convert.ToString(nudArcana.Value + nudArcanaCC.Value + Convert.ToInt32(txtArcanaBonus.Text) + statbonus("Knowledge"))
        txtEngineering.Text = Convert.ToString(nudEngineering.Value + nudEngineeringCC.Value + Convert.ToInt32(txtEngineeringBonus.Text) + statbonus("Knowledge"))
        txtDungeoning.Text = Convert.ToString(nudDungeoneering.Value + nudDungeoneeringCC.Value + Convert.ToInt32(txtDungeoneeringBonus.Text) + statbonus("Knowledge"))
        txtGeography.Text = Convert.ToString(nudGeography.Value + nudGeographyCC.Value + Convert.ToInt32(txtGeographyBonus.Text) + statbonus("Knowledge"))
        txtHistory.Text = Convert.ToString(nudHistory.Value + nudHistoryCC.Value + Convert.ToInt32(txtHistoryBonus.Text) + statbonus("Knowledge"))
        txtLocal.Text = Convert.ToString(nudLocal.Value + nudLocalCC.Value + Convert.ToInt32(txtLocalBonus.Text) + statbonus("Knowledge"))
        txtNature.Text = Convert.ToString(nudNature.Value + nudNatureCC.Value + Convert.ToInt32(txtNatureBonus.Text) + statbonus("Knowledge"))
        txtNobility.Text = Convert.ToString(nudNobility.Value + nudNobilityCC.Value + Convert.ToInt32(txtNobilityBonus.Text) + statbonus("Knowledge"))
        txtReligion.Text = Convert.ToString(nudReligion.Value + nudReligionCC.Value + Convert.ToInt32(txtReligionBonus.Text) + statbonus("Knowledge"))
        txtThePlanes.Text = Convert.ToString(nudThePlanes.Value + nudThePlanesCC.Value + Convert.ToInt32(txtThePlanesBonus.Text) + statbonus("Knowledge"))
        txtListen.Text = Convert.ToString(nudListen.Value + nudListenCC.Value + Convert.ToInt32(txtListenBonus.Text) + statbonus("Listen"))
        txtMoveSilently.Text = Convert.ToString(nudMoveSilently.Value + nudMoveSilentlyCC.Value + Convert.ToInt32(txtMoveSilentlyBonus.Text) + statbonus("Move Silently"))
        txtOpenLock.Text = Convert.ToString(nudOpenLock.Value + nudOpenLockCC.Value + Convert.ToInt32(txtOpenLockBonus.Text) + statbonus("Open Lock"))
        txtPerform.Text = Convert.ToString(nudPerform.Value + nudPerformCC.Value + Convert.ToInt32(txtPerformBonus.Text) + statbonus("Perform"))
        txtSleightOfHand.Text = Convert.ToString(nudSleightOfHand.Value + nudSleightOfHandCC.Value + Convert.ToInt32(txtSleightOfHandBonus.Text) + statbonus("Sleight of Hand"))
        txtProfession.Text = Convert.ToString(nudProfession.Value + nudProfessionCC.Value + Convert.ToInt32(txtProfessionBonus.Text) + statbonus("Profession"))
        txtRide.Text = Convert.ToString(nudRide.Value + nudRideCC.Value + Convert.ToInt32(txtRideBonus.Text) + statbonus("Ride"))
        txtSearch.Text = Convert.ToString(nudSearch.Value + nudSearchCC.Value + Convert.ToInt32(txtSearchBonus.Text) + statbonus("Search"))
        txtSenseMotive.Text = Convert.ToString(nudSenseMotive.Value + nudSenseMotiveCC.Value + Convert.ToInt32(txtSenseMotiveBonus.Text) + statbonus("Sense Motive"))
        txtSpellcraft.Text = Convert.ToString(nudSpellcraft.Value + nudSpellCraftCC.Value + Convert.ToInt32(txtSpellCraftBonus.Text) + statbonus("Spellcraft"))
        txtSpot.Text = Convert.ToString(nudSpot.Value + nudSpotCC.Value + Convert.ToInt32(txtSpotBonus.Text) + statbonus("Spot"))
        txtSurvival.Text = Convert.ToString(nudSurvival.Value + nudSurvivalCC.Value + Convert.ToInt32(txtSurvivalBonus.Text) + statbonus("Survival"))
        txtSwim.Text = Convert.ToString(nudSwim.Value + nudSwimCC.Value + Convert.ToInt32(txtSwimBonus.Text) + statbonus("Swim"))
        txtTumble.Text = Convert.ToString(nudTumble.Value + nudTumbleCC.Value + Convert.ToInt32(txtTumbleBonus.Text) + statbonus("Tumble"))
        txtUseMagicDevice.Text = Convert.ToString(nudUseMagicDevice.Value + nudUseMagicDeviceCC.Value + Convert.ToInt32(txtUseMagicDeviceBonus.Text) + statbonus("Use Magic Device"))
        txtUseRope.Text = Convert.ToString(nudUseRope.Value + nudUseRopeCC.Value + Convert.ToInt32(txtUseRopeBonus.Text) + statbonus("Use Rope"))
    End Sub
    Private Function statbonus(ByVal strSkillname As String) As Integer
        Dim intBonus As Integer = 0
        Dim strArray() As String
        strArray = Split(chain(strSkillname, "Skills.txt", True), ",")
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
    Private Sub SkillsUpdate(ByVal Control1 As NumericUpDown, ByVal control2 As NumericUpDown, ByVal bolClassSkill As Boolean, ByVal intSkillNum As Integer)
        SkillsCalc()
        If Convert.ToDouble(txtSkillPointsLeft.Text) < 0 Then
            txtSkillPointsLeft.Text = "0"
            If bolClassSkill Then
                If Control1.Value > 0 Then
                    Control1.Value -= 1
                End If
            Else
                If control2.Value > 0 Then
                    control2.Value -= Convert.ToDecimal(0.5)
                End If
            End If
        End If
        If Convert.ToDouble(Control1.Value) + Convert.ToDouble(control2.Value) > Convert.ToDouble(txtMaxRanks.Text) Then
            txtSkillPointsLeft.Text = Convert.ToString(Convert.ToInt32(txtSkillPointsLeft.Text) + 1)
            If bolClassSkill Then
                If Control1.Value > 0 Then
                    Control1.Value -= 1
                End If
            Else
                If control2.Value > 0 Then
                    control2.Value -= Convert.ToDecimal(0.5)
                End If
            End If
        End If
        If Control1.Value < Character.dblSkillArray(intSkillNum, 0) Then
            Control1.Value += 1
        End If
        If control2.Value < Character.dblSkillArray(intSkillNum, 1) Then
            control2.Value += Convert.ToDecimal(0.5)
        End If

    End Sub
    Private Function DiceRoll(ByVal intDiceNum As Integer, ByVal intDiceSize As Integer) As Integer
        Dim intRoll As Integer = 0
        ' This function returns the result of a simulated die or dice roll 
        Dim i As Integer
        For i = 1 To intDiceNum
            intRoll += Convert.ToInt32(((intDiceSize - 1) * Rnd()) + 1)
        Next
        Return intRoll
    End Function
    Private Sub LoadSkills()
        Dim i As Integer
        bolSkillUpdate = False
        txtCustom1Name.Text = Character.GetCustomSkillName(True)
        CboCustom1Stat.SelectedItem = Character.getCustomSkillStat(True)
        txtCustom2Name.Text = Character.GetCustomSkillName(False)
        cboCustom2Stat.SelectedItem = Character.getCustomSkillStat(False)
        For i = 0 To 45
            Select Case i
                Case 0
                    nudAppraise.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudAppraiseCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 1
                    nudBalance.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudBalanceCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 2
                    nudBluff.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudbluffCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 3
                    nudClimb.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudClimbCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 4
                    nudConcentration.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudConcentrationCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 5
                    nudCraft.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudCraftCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 6
                    nudDecipherScript.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudDecipherScriptCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 7
                    nudDiplomacy.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudDiplomacyCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 8
                    nudDisableDevice.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudDisableDeviceCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 9
                    nudDisguise.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudDisguiseCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 10
                    nudEscapeArtist.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudEscapeArtistCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 11
                    nudForgery.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudForgeryCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 12
                    nudGatherInfo.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudGatherInfoCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 13
                    nudHandleAnimal.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudHandleAnimalCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 14
                    nudHeal.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudHealCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 15
                    nudHide.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudHideCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 16
                    nudIntimidate.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudIntimidateCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 17
                    nudJump.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudJumpCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 18
                    nudArcana.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudArcanaCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 19
                    nudEngineering.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudEngineeringCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 20
                    nudDungeoneering.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudDungeoneeringCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 21
                    nudGeography.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudGeographyCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 22
                    nudHistory.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudHistoryCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 23
                    nudLocal.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudLocalCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 24
                    nudNature.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudNatureCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 25
                    nudNobility.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudNobilityCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 26
                    nudReligion.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudReligionCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 27
                    nudThePlanes.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudThePlanesCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 28
                    nudListen.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudListenCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 29
                    nudMoveSilently.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudMoveSilentlyCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 30
                    nudOpenLock.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudOpenLockCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 31
                    nudPerform.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudPerformCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 32
                    nudSleightOfHand.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSleightOfHandCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 33
                    nudProfession.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudProfessionCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 34
                    nudRide.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudRideCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 35
                    nudSearch.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSearchCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 36
                    nudSenseMotive.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSenseMotiveCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 37
                    nudSpellcraft.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSpellCraftCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 38
                    nudSpot.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSpotCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 39
                    nudSurvival.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSurvivalCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 40
                    nudSwim.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudSwimCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 41
                    nudTumble.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudTumbleCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 42
                    nudUseMagicDevice.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudUseMagicDeviceCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 43
                    nudUseRope.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudUseRopeCC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 44
                    nudCustom1.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudCustom1CC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
                Case 45
                    nudCustom2.Value = Convert.ToDecimal(Character.dblSkillArray(i, 0))
                    nudCustom2CC.Value = Convert.ToDecimal(Character.dblSkillArray(i, 1))
            End Select
        Next
        bolSkillUpdate = True
        'SkillsCalc()
    End Sub
    Private Sub SetSkills(ByVal ParamArray intskills() As Integer)
        Dim i As Integer = 0
        Dim control As NumericUpDown = nudAppraise
        Dim control2 As NumericUpDown = nudAppraiseCC
        For i = 0 To 45
            If i = 0 Then
                control = nudAppraise
                control2 = nudAppraiseCC
            ElseIf i = 1 Then
                control = nudBalance
                control2 = nudBalanceCC
            ElseIf i = 2 Then
                control = nudBluff
                control2 = nudbluffCC
            ElseIf i = 3 Then
                control = nudClimb
                control2 = nudClimbCC
            ElseIf i = 4 Then
                control = nudConcentration
                control2 = nudConcentrationCC
            ElseIf i = 5 Then
                control = nudCraft
                control2 = nudCraftCC
            ElseIf i = 6 Then
                control = nudDecipherScript
                control2 = nudDecipherScriptCC
            ElseIf i = 7 Then
                control = nudDiplomacy
                control2 = nudDiplomacyCC
            ElseIf i = 8 Then
                control = nudDisableDevice
                control2 = nudDisableDeviceCC
            ElseIf i = 9 Then
                control = nudDisguise
                control2 = nudDisguiseCC
            ElseIf i = 10 Then
                control = nudEscapeArtist
                control2 = nudEscapeArtistCC
            ElseIf i = 11 Then
                control = nudForgery
                control2 = nudForgeryCC
            ElseIf i = 12 Then
                control = nudGatherInfo
                control2 = nudGatherInfoCC
            ElseIf i = 13 Then
                control = nudHandleAnimal
                control2 = nudHandleAnimalCC
            ElseIf i = 14 Then
                control = nudHeal
                control2 = nudHealCC
            ElseIf i = 15 Then
                control = nudHide
                control2 = nudHideCC
            ElseIf i = 16 Then
                control = nudIntimidate
                control2 = nudIntimidateCC
            ElseIf i = 17 Then
                control = nudJump
                control2 = nudJumpCC
            ElseIf i = 18 Then
                control = nudArcana
                control2 = nudArcanaCC
            ElseIf i = 19 Then
                control = nudEngineering
                control2 = nudEngineeringCC
            ElseIf i = 20 Then
                control = nudDungeoneering
                control2 = nudDungeoneeringCC
            ElseIf i = 21 Then
                control = nudGeography
                control2 = nudGeographyCC
            ElseIf i = 22 Then
                control = nudHistory
                control2 = nudHistoryCC
            ElseIf i = 23 Then
                control = nudLocal
                control2 = nudLocalCC
            ElseIf i = 24 Then
                control = nudNature
                control2 = nudNatureCC
            ElseIf i = 25 Then
                control = nudNobility
                control2 = nudNobilityCC
            ElseIf i = 26 Then
                control = nudReligion
                control2 = nudReligionCC
            ElseIf i = 27 Then
                control = nudThePlanes
                control2 = nudThePlanesCC
            ElseIf i = 28 Then
                control = nudListen
                control2 = nudListenCC
            ElseIf i = 29 Then
                control = nudMoveSilently
                control2 = nudMoveSilentlyCC
            ElseIf i = 30 Then
                control = nudOpenLock
                control2 = nudOpenLockCC
            ElseIf i = 31 Then
                control = nudPerform
                control2 = nudPerformCC
            ElseIf i = 32 Then
                control = nudSleightOfHand
                control2 = nudSleightOfHandCC
            ElseIf i = 33 Then
                control = nudProfession
                control2 = nudProfessionCC
            ElseIf i = 34 Then
                control = nudRide
                control2 = nudRideCC
            ElseIf i = 35 Then
                control = nudSearch
                control2 = nudSearchCC
            ElseIf i = 36 Then
                control = nudSenseMotive
                control2 = nudSenseMotiveCC
            ElseIf i = 37 Then
                control = nudSpellcraft
                control2 = nudSpellCraftCC
            ElseIf i = 38 Then
                control = nudSpot
                control2 = nudSpotCC
            ElseIf i = 39 Then
                control = nudSurvival
                control2 = nudSurvivalCC
            ElseIf i = 40 Then
                control = nudSwim
                control2 = nudSwimCC
            ElseIf i = 41 Then
                control = nudTumble
                control2 = nudTumbleCC
            ElseIf i = 42 Then
                control = nudUseMagicDevice
                control2 = nudUseMagicDeviceCC
            ElseIf i = 43 Then
                control = nudUseRope
                control2 = nudUseRopeCC
            ElseIf i = 44 Then
                control = nudCustom1
                control2 = nudCustom1CC
            ElseIf i = 45 Then
                control = nudCustom2
                control2 = nudCustom2CC
            End If
            If intskills(i) = 1 Then
                control.Enabled = True
                control2.Enabled = False
            ElseIf intskills(i) = 2 Then
                control.Enabled = False
                control2.Enabled = True
            ElseIf intskills(i) = 3 Then
                control.Enabled = True
                control2.Enabled = True
            ElseIf intskills(i) = 4 Then
                control.Enabled = False
                control2.Enabled = False
            End If
        Next
    End Sub

    Private Sub frmSkills_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmSkills_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intSkills(46) As Integer
        Dim i As Integer
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        Character = frmCharacterSheet.character
        txtTotalSkillPoints.Text = Convert.ToString(Character.intSkillpoints)
        txtMaxRanks.Text = Convert.ToString(Character.intlevel + 3)
        If Convert.ToInt32(txtMaxRanks.Text) < 4 Then
            txtMaxRanks.Text = "4"
        End If
        For i = 0 To 43
            intSkills(i) = 4
        Next
        txtClass.Text = Character.strSkillClass
        If txtClass.Text = "Barbarian" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(3) = 1
            intSkills(5) = 1
            intSkills(13) = 1
            intSkills(16) = 1
            intSkills(17) = 1
            intSkills(28) = 1
            intSkills(34) = 1
            intSkills(39) = 1
            intSkills(40) = 1
        ElseIf txtClass.Text = "Bard" Then
            For i = 0 To 44
                intSkills(i) = 1
            Next
            intSkills(8) = 2
            intSkills(11) = 2
            intSkills(13) = 2
            intSkills(14) = 2
            intSkills(16) = 2
            intSkills(30) = 2
            intSkills(34) = 2
            intSkills(35) = 2
            intSkills(38) = 2
            intSkills(39) = 2
            intSkills(43) = 2
        ElseIf txtClass.Text = "Cleric" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(7) = 1
            intSkills(14) = 1
            intSkills(18) = 1
            intSkills(22) = 1
            intSkills(26) = 1
            intSkills(27) = 1
            intSkills(33) = 1
            intSkills(37) = 1
        ElseIf txtClass.Text = "Druid" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(7) = 1
            intSkills(13) = 1
            intSkills(14) = 1
            intSkills(24) = 1
            intSkills(28) = 1
            intSkills(33) = 1
            intSkills(34) = 1
            intSkills(37) = 1
            intSkills(38) = 1
            intSkills(39) = 1
            intSkills(40) = 1
        ElseIf txtClass.Text = "Fighter" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(3) = 1
            intSkills(5) = 1
            intSkills(13) = 1
            intSkills(16) = 1
            intSkills(17) = 1
            intSkills(34) = 1
            intSkills(40) = 1
        ElseIf txtClass.Text = "Monk" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(1) = 1
            intSkills(3) = 1
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(7) = 1
            intSkills(10) = 1
            intSkills(15) = 1
            intSkills(17) = 1
            intSkills(18) = 1
            intSkills(26) = 1
            intSkills(27) = 1
            intSkills(31) = 1
            intSkills(32) = 1
            intSkills(36) = 1
            intSkills(40) = 1
            intSkills(41) = 1
        ElseIf txtClass.Text = "Paladin" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(7) = 1
            intSkills(13) = 1
            intSkills(14) = 1
            intSkills(25) = 1
            intSkills(26) = 1
            intSkills(33) = 1
            intSkills(34) = 1
            intSkills(36) = 1
        ElseIf txtClass.Text = "Ranger" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(3) = 1
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(13) = 1
            intSkills(14) = 1
            intSkills(15) = 1
            intSkills(17) = 1
            intSkills(20) = 1
            intSkills(21) = 1
            intSkills(24) = 1
            intSkills(28) = 1
            intSkills(29) = 1
            intSkills(33) = 1
            intSkills(34) = 1
            intSkills(35) = 1
            intSkills(38) = 1
            intSkills(39) = 1
            intSkills(40) = 1
            intSkills(43) = 1

        ElseIf txtClass.Text = "Rogue" Then
            For i = 0 To 44
                intSkills(i) = 1
            Next
            intSkills(4) = 2
            intSkills(13) = 2
            intSkills(14) = 2
            intSkills(18) = 2
            intSkills(19) = 2
            intSkills(20) = 2
            intSkills(21) = 2
            intSkills(22) = 2
            intSkills(24) = 2
            intSkills(25) = 2
            intSkills(26) = 2
            intSkills(27) = 2
            intSkills(34) = 2
            intSkills(37) = 2
            intSkills(39) = 2
        ElseIf txtClass.Text = "Sorcerer" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(2) = 1
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(18) = 1
            intSkills(33) = 1
            intSkills(37) = 1
        ElseIf txtClass.Text = "Wizard" Then
            For i = 0 To 44
                intSkills(i) = 2
            Next
            intSkills(4) = 1
            intSkills(5) = 1
            intSkills(6) = 1
            intSkills(18) = 1
            intSkills(19) = 1
            intSkills(20) = 1
            intSkills(21) = 1
            intSkills(22) = 1
            intSkills(23) = 1
            intSkills(24) = 1
            intSkills(25) = 1
            intSkills(26) = 1
            intSkills(27) = 1
            intSkills(33) = 1
            intSkills(37) = 1
        Else
            For i = 0 To 43
                intSkills(i) = 3
            Next
        End If
        intSkills(44) = 3
        intSkills(45) = 3
        LoadSkills()
        SetSkills(intSkills)
        SkillsCalc()

    End Sub

    Private Sub BtnRoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll.Click
        txtD20.Text = Convert.ToString(DiceRoll(1, 20))
    End Sub

    Private Sub nudAppraise_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAppraise.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudAppraise, nudAppraiseCC, True, 0)
        End If
    End Sub

    Private Sub nudAppraiseCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAppraiseCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudAppraise, nudAppraiseCC, False, 0)
        End If
    End Sub

    Private Sub nudBalance_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBalance.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudBalance, nudBalanceCC, True, 1)
        End If
    End Sub

    Private Sub nudBalanceCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBalanceCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudBalance, nudBalanceCC, False, 1)
        End If
    End Sub

    Private Sub nudBluff_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBluff.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudBluff, nudbluffCC, True, 2)
        End If
    End Sub

    Private Sub nudbluffCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudbluffCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudBluff, nudbluffCC, False, 2)
        End If
    End Sub

    Private Sub nudClimb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolSkillUpdate = True Then
            SkillsUpdate(nudClimb, nudClimbCC, True, 3)
        End If
    End Sub

    Private Sub nudClimbCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolSkillUpdate = True Then
            SkillsUpdate(nudClimb, nudClimbCC, False, 3)
        End If
    End Sub

    Private Sub nudConcentration_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudConcentration.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudConcentration, nudConcentrationCC, True, 4)
        End If
    End Sub

    Private Sub nudConcentrationCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudConcentrationCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudConcentration, nudConcentrationCC, False, 4)
        End If
    End Sub

    Private Sub nudCraft_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCraft.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCraft, nudCraftCC, True, 5)
        End If
    End Sub

    Private Sub nudCraftCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCraftCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCraft, nudCraftCC, False, 5)
        End If
    End Sub

    Private Sub nudDecipherScript_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDecipherScript.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDecipherScript, nudDecipherScriptCC, True, 6)
        End If
    End Sub

    Private Sub nudDecipherScriptCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDecipherScriptCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDecipherScript, nudDecipherScriptCC, False, 6)
        End If
    End Sub

    Private Sub nudDiplomacy_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDiplomacy.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDiplomacy, nudDiplomacyCC, True, 7)
        End If
    End Sub

    Private Sub nudDiplomacyCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDiplomacyCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDiplomacy, nudDiplomacyCC, False, 7)
        End If
    End Sub

    Private Sub nudDisableDevice_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDisableDevice.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDisableDevice, nudDisableDeviceCC, True, 8)
        End If
    End Sub

    Private Sub nudDisableDeviceCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDisableDeviceCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDisableDevice, nudDisableDeviceCC, False, 8)
        End If
    End Sub

    Private Sub nudDisguise_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDisguise.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDisguise, nudDisguiseCC, True, 9)
        End If
    End Sub

    Private Sub nudDisguiseCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDisguiseCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDisguise, nudDisguiseCC, False, 9)
        End If
    End Sub

    Private Sub nudEscapeArtist_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudEscapeArtist.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudEscapeArtist, nudEscapeArtistCC, True, 10)
        End If
    End Sub

    Private Sub nudEscapeArtistCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudEscapeArtistCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudEscapeArtist, nudEscapeArtistCC, False, 10)
        End If
    End Sub

    Private Sub nudForgery_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudForgery.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudForgery, nudForgeryCC, True, 11)
        End If
    End Sub

    Private Sub nudForgeryCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudForgeryCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudForgery, nudForgeryCC, False, 11)
        End If
    End Sub

    Private Sub nudGatherInfo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGatherInfo.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudGatherInfo, nudGatherInfoCC, True, 12)
        End If
    End Sub

    Private Sub nudGatherInfoCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGatherInfoCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudGatherInfo, nudGatherInfoCC, False, 12)
        End If
    End Sub

    Private Sub nudHandleAnimal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHandleAnimal.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHandleAnimal, nudHandleAnimalCC, True, 13)
        End If
    End Sub

    Private Sub nudHandleAnimalCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHandleAnimalCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHandleAnimal, nudHandleAnimalCC, False, 13)
        End If
    End Sub

    Private Sub nudHeal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHeal.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHeal, nudHealCC, True, 14)
        End If
    End Sub

    Private Sub nudHealCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHealCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHeal, nudHealCC, False, 14)
        End If
    End Sub

    Private Sub nudHide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHide.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHide, nudHideCC, True, 15)
        End If
    End Sub

    Private Sub nudHideCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHideCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHide, nudHideCC, False, 15)
        End If
    End Sub

    Private Sub nudIntimidate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudIntimidate.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudIntimidate, nudIntimidateCC, True, 16)
        End If
    End Sub

    Private Sub nudIntimidateCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudIntimidateCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudIntimidate, nudIntimidateCC, False, 16)
        End If
    End Sub

    Private Sub nudJump_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudJump.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudJump, nudJumpCC, True, 17)
        End If
    End Sub

    Private Sub nudJumpCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudJumpCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudJump, nudJumpCC, False, 17)
        End If
    End Sub

    Private Sub nudKnowledge_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudArcana.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudArcana, nudArcanaCC, True, 18)
        End If
    End Sub

    Private Sub nudKnowledgeCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudArcanaCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudArcana, nudArcanaCC, False, 18)
        End If
    End Sub

    Private Sub nudListen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudListen.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudListen, nudListenCC, True, 28)
        End If
    End Sub

    Private Sub nudListenCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudListenCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudListen, nudListenCC, False, 28)
        End If
    End Sub

    Private Sub nudMoveSilently_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMoveSilently.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudMoveSilently, nudMoveSilentlyCC, False, 29)
        End If
    End Sub

    Private Sub nudOpenLock_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudOpenLock.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudOpenLock, nudOpenLockCC, True, 30)
        End If
    End Sub

    Private Sub nudOpenLockCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudOpenLockCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudOpenLock, nudOpenLockCC, False, 30)
        End If
    End Sub

    Private Sub nudPerform_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPerform.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudPerform, nudPerformCC, True, 31)
        End If
    End Sub

    Private Sub nudPerformCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPerformCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudPerform, nudPerformCC, False, 31)
        End If
    End Sub

    Private Sub nudPickPocketCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSleightOfHandCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSleightOfHand, nudSleightOfHandCC, False, 32)
        End If
    End Sub

    Private Sub nudPickPocket_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSleightOfHand.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSleightOfHand, nudSleightOfHandCC, True, 32)
        End If
    End Sub

    Private Sub nudProfession_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudProfession.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudProfession, nudProfessionCC, True, 33)
        End If
    End Sub

    Private Sub nudRide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudRide.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudRide, nudRideCC, True, 34)
        End If
    End Sub

    Private Sub nudRideCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudRideCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudRide, nudRideCC, False, 34)
        End If
    End Sub

    Private Sub nudSearch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSearch.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSearch, nudSearchCC, True, 35)
        End If
    End Sub

    Private Sub nudSearchCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSearchCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSearch, nudSearchCC, False, 35)
        End If
    End Sub

    Private Sub nudSenseMotive_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSenseMotive.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSenseMotive, nudSenseMotiveCC, True, 36)
        End If
    End Sub

    Private Sub nudSenseMotiveCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSenseMotiveCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSenseMotive, nudSenseMotiveCC, False, 36)
        End If
    End Sub

    Private Sub nudSpellcraft_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpellcraft.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSpellcraft, nudSpellCraftCC, True, 37)
        End If
    End Sub

    Private Sub nudSpellCraftCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpellCraftCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSpellcraft, nudSpellCraftCC, False, 37)
        End If
    End Sub

    Private Sub nudSpot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpot.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSpot, nudSpotCC, True, 38)
        End If
    End Sub

    Private Sub nudSpotCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSpotCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSpot, nudSpotCC, False, 38)
        End If
    End Sub

    Private Sub nudSurvival_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSurvival.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSurvival, nudSurvivalCC, True, 39)
        End If
    End Sub

    Private Sub nudSurvivalCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSurvivalCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSurvival, nudSurvivalCC, False, 39)
        End If
    End Sub

    Private Sub nudSwim_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSwim.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSwim, nudSwimCC, True, 40)
        End If
    End Sub

    Private Sub nudSwimCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSwimCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudSwim, nudSwimCC, False, 40)
        End If
    End Sub

    Private Sub nudTumble_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudTumble.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudTumble, nudTumbleCC, True, 41)
        End If
    End Sub

    Private Sub nudUseMagicDevice_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudUseMagicDevice.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudUseMagicDevice, nudUseMagicDeviceCC, True, 42)
        End If
    End Sub

    Private Sub nudTumbleCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudTumbleCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudTumble, nudTumbleCC, False, 41)
        End If
    End Sub

    Private Sub nudUseMagicDeviceCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudUseMagicDeviceCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudUseMagicDevice, nudUseMagicDeviceCC, False, 42)
        End If
    End Sub

    Private Sub nudUseRope_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudUseRope.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudUseRope, nudUseRopeCC, True, 43)
        End If
    End Sub

    Private Sub nudUseRopeCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudUseRopeCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudUseRope, nudUseRopeCC, False, 43)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        If Convert.ToDouble(txtSkillPointsLeft.Text) > 0 Then
            MessageBox.Show("There is still skill points to distribute", "Warning")
        Else
            For i = 0 To 45
                Select Case i
                    Case 0
                        Character.dblSkillArray(i, 0) = nudAppraise.Value
                        Character.dblSkillArray(i, 1) = nudAppraiseCC.Value
                    Case 1
                        Character.dblSkillArray(i, 0) = nudBalance.Value
                        Character.dblSkillArray(i, 1) = nudBalanceCC.Value
                    Case 2
                        Character.dblSkillArray(i, 0) = nudBluff.Value
                        Character.dblSkillArray(i, 1) = nudBluff.Value
                    Case 3
                        Character.dblSkillArray(i, 0) = nudClimb.Value
                        Character.dblSkillArray(i, 1) = nudClimbCC.Value
                    Case 4
                        Character.dblSkillArray(i, 0) = nudConcentration.Value
                        Character.dblSkillArray(i, 1) = nudConcentrationCC.Value
                    Case 5
                        Character.dblSkillArray(i, 0) = nudCraft.Value
                        Character.dblSkillArray(i, 1) = nudCraftCC.Value
                    Case 6
                        Character.dblSkillArray(i, 0) = nudDecipherScript.Value
                        Character.dblSkillArray(i, 1) = nudDecipherScriptCC.Value
                    Case 7
                        Character.dblSkillArray(i, 0) = nudDiplomacy.Value
                        Character.dblSkillArray(i, 1) = nudDiplomacyCC.Value
                    Case 8
                        Character.dblSkillArray(i, 0) = nudDisableDevice.Value
                        Character.dblSkillArray(i, 1) = nudDisableDeviceCC.Value
                    Case 9
                        Character.dblSkillArray(i, 0) = nudDisguise.Value
                        Character.dblSkillArray(i, 1) = nudDisguiseCC.Value
                    Case 10
                        Character.dblSkillArray(i, 0) = nudEscapeArtist.Value
                        Character.dblSkillArray(i, 1) = nudEscapeArtistCC.Value
                    Case 11
                        Character.dblSkillArray(i, 0) = nudForgery.Value
                        Character.dblSkillArray(i, 1) = nudForgeryCC.Value
                    Case 12
                        Character.dblSkillArray(i, 0) = nudGatherInfo.Value
                        Character.dblSkillArray(i, 1) = nudGatherInfoCC.Value
                    Case 13
                        Character.dblSkillArray(i, 0) = nudHandleAnimal.Value
                        Character.dblSkillArray(i, 1) = nudHandleAnimalCC.Value
                    Case 14
                        Character.dblSkillArray(i, 0) = nudHeal.Value
                        Character.dblSkillArray(i, 1) = nudHealCC.Value
                    Case 15
                        Character.dblSkillArray(i, 0) = nudHide.Value
                        Character.dblSkillArray(i, 1) = nudHideCC.Value
                    Case 16
                        Character.dblSkillArray(i, 0) = nudIntimidate.Value
                        Character.dblSkillArray(i, 1) = nudIntimidateCC.Value
                    Case 17
                        Character.dblSkillArray(i, 0) = nudJump.Value
                        Character.dblSkillArray(i, 1) = nudJumpCC.Value
                    Case 18
                        Character.dblSkillArray(i, 0) = nudArcana.Value
                        Character.dblSkillArray(i, 1) = nudArcanaCC.Value
                    Case 19
                        Character.dblSkillArray(i, 0) = nudEngineering.Value
                        Character.dblSkillArray(i, 1) = nudEngineeringCC.Value
                    Case 20
                        Character.dblSkillArray(i, 0) = nudDungeoneering.Value
                        Character.dblSkillArray(i, 1) = nudDungeoneeringCC.Value
                    Case 21
                        Character.dblSkillArray(i, 0) = nudGeography.Value
                        Character.dblSkillArray(i, 1) = nudGeographyCC.Value
                    Case 22
                        Character.dblSkillArray(i, 0) = nudHistory.Value
                        Character.dblSkillArray(i, 1) = nudHistoryCC.Value
                    Case 23
                        Character.dblSkillArray(i, 0) = nudLocal.Value
                        Character.dblSkillArray(i, 1) = nudLocalCC.Value
                    Case 24
                        Character.dblSkillArray(i, 0) = nudNature.Value
                        Character.dblSkillArray(i, 1) = nudNatureCC.Value
                    Case 25
                        Character.dblSkillArray(i, 0) = nudNobility.Value
                        Character.dblSkillArray(i, 1) = nudNobilityCC.Value
                    Case 26
                        Character.dblSkillArray(i, 0) = nudReligion.Value
                        Character.dblSkillArray(i, 1) = nudReligionCC.Value
                    Case 27
                        Character.dblSkillArray(i, 0) = nudThePlanes.Value
                        Character.dblSkillArray(i, 1) = nudThePlanesCC.Value
                    Case 28
                        Character.dblSkillArray(i, 0) = nudListen.Value
                        Character.dblSkillArray(i, 1) = nudListenCC.Value
                    Case 29
                        Character.dblSkillArray(i, 0) = nudMoveSilently.Value
                        Character.dblSkillArray(i, 1) = nudMoveSilentlyCC.Value
                    Case 30
                        Character.dblSkillArray(i, 0) = nudOpenLock.Value
                        Character.dblSkillArray(i, 1) = nudOpenLockCC.Value
                    Case 31
                        Character.dblSkillArray(i, 0) = nudPerform.Value
                        Character.dblSkillArray(i, 1) = nudPerformCC.Value
                    Case 32
                        Character.dblSkillArray(i, 0) = nudSleightOfHand.Value
                        Character.dblSkillArray(i, 1) = nudSleightOfHandCC.Value
                    Case 33
                        Character.dblSkillArray(i, 0) = nudProfession.Value
                        Character.dblSkillArray(i, 1) = nudProfessionCC.Value
                    Case 34
                        Character.dblSkillArray(i, 0) = nudRide.Value
                        Character.dblSkillArray(i, 1) = nudRideCC.Value
                    Case 35
                        Character.dblSkillArray(i, 0) = nudSearch.Value
                        Character.dblSkillArray(i, 1) = nudSearchCC.Value
                    Case 36
                        Character.dblSkillArray(i, 0) = nudSenseMotive.Value
                        Character.dblSkillArray(i, 1) = nudSenseMotiveCC.Value
                    Case 37
                        Character.dblSkillArray(i, 0) = nudSpellcraft.Value
                        Character.dblSkillArray(i, 1) = nudSpellCraftCC.Value
                    Case 38
                        Character.dblSkillArray(i, 0) = nudSpot.Value
                        Character.dblSkillArray(i, 1) = nudSpotCC.Value
                    Case 39
                        Character.dblSkillArray(i, 0) = nudSurvival.Value
                        Character.dblSkillArray(i, 1) = nudSurvivalCC.Value
                    Case 40
                        Character.dblSkillArray(i, 0) = nudSwim.Value
                        Character.dblSkillArray(i, 1) = nudSwimCC.Value
                    Case 41
                        Character.dblSkillArray(i, 0) = nudTumble.Value
                        Character.dblSkillArray(i, 1) = nudTumbleCC.Value
                    Case 42
                        Character.dblSkillArray(i, 0) = nudUseMagicDevice.Value
                        Character.dblSkillArray(i, 1) = nudUseMagicDeviceCC.Value
                    Case 43
                        Character.dblSkillArray(i, 0) = nudUseRope.Value
                        Character.dblSkillArray(i, 1) = nudUseRopeCC.Value
                    Case 44
                        Character.dblSkillArray(i, 0) = nudCustom1.Value
                        Character.dblSkillArray(i, 1) = nudCustom1CC.Value
                    Case 45
                        Character.dblSkillArray(i, 0) = nudCustom2.Value
                        Character.dblSkillArray(i, 1) = nudCustom2CC.Value
                End Select
            Next
            Character.setCustomSkill(txtCustom1Name.Text, Convert.ToString(CboCustom1Stat.SelectedItem), Convert.ToDouble(nudCustom1.Value), Convert.ToDouble(nudCustom1CC.Value), True)
            Character.setCustomSkill(txtCustom2Name.Text, Convert.ToString(cboCustom2Stat.SelectedItem), Convert.ToDouble(nudCustom2.Value), Convert.ToDouble(nudCustom2CC.Value), False)
            frmCharacterSheet.character = Character
            Me.Close()
        End If
    End Sub

    Private Sub nudEngineering_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudEngineering.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudEngineering, nudEngineeringCC, True, 19)
        End If
    End Sub

    Private Sub nudEngineeringCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudEngineeringCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudEngineering, nudEngineeringCC, False, 19)
        End If
    End Sub

    Private Sub nudDungeoneering_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDungeoneering.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDungeoneering, nudDungeoneeringCC, True, 20)
        End If
    End Sub

    Private Sub nudGeography_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGeography.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudGeography, nudGeographyCC, True, 21)
        End If
    End Sub

    Private Sub nudDungeoneeringCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDungeoneeringCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudDungeoneering, nudDungeoneeringCC, False, 20)
        End If
    End Sub

    Private Sub nudGeographyCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGeographyCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudGeography, nudGeographyCC, False, 21)
        End If
    End Sub

    Private Sub nudHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHistory.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHistory, nudHistoryCC, True, 22)
        End If
    End Sub

    Private Sub nudHistoryCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHistoryCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudHistory, nudHistoryCC, False, 22)
        End If
    End Sub

    Private Sub nudLocal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLocal.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudLocal, nudLocalCC, True, 23)
        End If
    End Sub

    Private Sub nudLocalCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLocalCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudLocal, nudLocalCC, False, 23)
        End If
    End Sub

    Private Sub nudNature_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNature.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudNature, nudNatureCC, True, 24)
        End If
    End Sub

    Private Sub nudNatureCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNatureCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudNature, nudNatureCC, False, 24)
        End If
    End Sub

    Private Sub nudNobility_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNobility.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudNobility, nudNobilityCC, True, 25)
        End If
    End Sub

    Private Sub nudNobilityCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNobilityCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudNobility, nudNobilityCC, False, 25)
        End If
    End Sub

    Private Sub nudReligion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudReligion.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudReligion, nudReligionCC, True, 26)
        End If
    End Sub

    Private Sub nudReligionCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudReligionCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudReligion, nudReligionCC, False, 26)
        End If
    End Sub

    Private Sub nudThePlanes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudThePlanes.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudThePlanes, nudThePlanesCC, True, 27)
        End If
    End Sub

    Private Sub nudThePlanesCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudThePlanesCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudThePlanes, nudThePlanesCC, False, 27)
        End If
    End Sub

    Private Sub nudClimb_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudClimb.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudClimb, nudClimbCC, True, 3)
        End If
    End Sub

    Private Sub nudClimbCC_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudClimbCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudClimb, nudClimbCC, False, 3)
        End If
    End Sub

    Private Sub nudProfessionCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudProfessionCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudProfession, nudProfessionCC, False, 33)
        End If
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

    Private Sub nudMoveSilentlyCC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMoveSilentlyCC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudMoveSilently, nudMoveSilentlyCC, False, 29)
        End If
    End Sub

    Private Sub nudCustom1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCustom1.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCustom1, nudCustom1CC, True, 44)
        End If
    End Sub

    Private Sub nudCustom1CC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCustom1CC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCustom1, nudCustom1CC, False, 44)
        End If
    End Sub

    Private Sub nudCustom2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCustom2.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCustom2, nudCustom2CC, True, 45)
        End If
    End Sub

    Private Sub nudCustom2CC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCustom2CC.ValueChanged
        If bolSkillUpdate = True Then
            SkillsUpdate(nudCustom2, nudCustom2CC, False, 45)
        End If
    End Sub
End Class


