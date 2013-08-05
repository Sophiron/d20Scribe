Public Class FrmAttributes

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim strItem As String
        strItem = frmAddItems.lstAddItems.SelectedItem.ToString()
        frmAddItems.lstAddItems.Items.Remove(strItem)
        If RadMasterwork.Checked = True Then
            strItem = "Masterwork " + strItem
        End If
        If RadPlusOne.Checked = True Then
            strItem = "+1 " + strItem
        End If
        If RadPlusTwo.Checked = True Then
            strItem = "+2 " + strItem
        End If
        If RadPlusThree.Checked = True Then
            strItem = "+3 " + strItem
        End If
        If RadPlusFour.Checked = True Then
            strItem = "+4 " + strItem
        End If
        If RadPlusFive.Checked = True Then
            strItem = "+5 " + strItem
        End If
        If chkGhostTouch.Checked = True Then
            strItem = strItem + ",Ghost Touch"
        End If
        If chkAcidResist.Checked = True Then
            strItem = strItem + ",Acid Resistance"
        End If
        If chkFireResist.Checked = True Then
            strItem = strItem + ",Fire Resistance"
        End If
        If chkColdResist.Checked = True Then
            strItem = strItem + ",Cold Resistance"
        End If
        If chkElectricityResist.Checked = True Then
            strItem = strItem + ",Electricity Resistance"
        End If
        If chkSonicResist.Checked = True Then
            strItem = strItem + ",Sonic Resistance"
        End If
        If chkLightFort.Checked = True Then
            strItem = strItem + ",Light Fortification"
        End If
        If chkMediumFort.Checked = True Then
            strItem = strItem + ",Medium Fortification"
        End If
        If chkHeavyFort.Checked = True Then
            strItem = strItem + ",Heavy Fortification"
        End If
        If chkGlamered.Checked = True Then
            strItem = strItem + ",Glamered"
        End If
        If chkSR13.Checked = True Then
            strItem = strItem + ",Spell Resistance 13"
        End If
        If chkSR15.Checked = True Then
            strItem = strItem + ",Spell Resistance 15"
        End If
        If chkSR17.Checked = True Then
            strItem = strItem + ",Spell Resistance 17"
        End If
        If chkSR19.Checked = True Then
            strItem = strItem + ",Spell Resistance 19"
        End If
        If chkEtherealness.Checked = True Then
            strItem = strItem + ",Etherealness"
        End If
        If chkInvulnerability.Checked = True Then
            strItem = strItem + ",Invulnerability"
        End If
        If chkShadow.Checked = True Then
            strItem = strItem + ",Shadow"
        End If
        If chkSilentMoves.Checked = True Then
            strItem = strItem + ",Silent Moves"
        End If
        If chkSlick.Checked = True Then
            strItem = strItem + ",Slick"
        End If
        If chkAnimated.Checked = True Then
            strItem = strItem + ",Animated"
        End If
        If chkArrowDeflection.Checked = True Then
            strItem = strItem + ",Arrow Deflection"
        End If
        If chkBashing.Checked = True Then
            strItem = strItem + ",Bashing"
        End If
        If chkBlinding.Checked = True Then
            strItem = strItem + ",Blinding"
        End If
        If chkReflection.Checked = True Then
            strItem = strItem + ",Reflection"
        End If
        If chkBrilliantEnergy.Checked = True Then
            strItem = strItem + ",Brilliant Energy"
        End If
        If chkChaotic.Checked = True Then
            strItem = strItem + ",Chaotic"
        End If
        If chkFlaming.Checked = True Then
            strItem = strItem + ",Flaming"
        End If
        If chkFlamingBurst.Checked = True Then
            strItem = strItem + ",Flaming Burst"
        End If
        If chkFrost.Checked = True Then
            strItem = strItem + ",Frost"
        End If
        If chkIcyBurst.Checked = True Then
            strItem = strItem + ",Icy Burst"
        End If
        If chkHoly.Checked = True Then
            strItem = strItem + ",Holy"
        End If
        If chkUnholy.Checked = True Then
            strItem = strItem + ",Unholy"
        End If
        If chkKeen.Checked = True Then
            strItem = strItem + ",Keen"
        End If
        If chkLawful.Checked = True Then
            strItem = strItem + ",lawful"
        End If
        If chkShock.Checked = True Then
            strItem = strItem + ",Shock"
        End If
        If chkShockingBurst.Checked = True Then
            strItem = strItem + ",Shocking Burst"
        End If
        If chkSpeed.Checked = True Then
            strItem = strItem + ",Speed"
        End If
        If chkThundering.Checked = True Then
            strItem = strItem + ",Thundering"
        End If
        If chkVorpal.Checked = True Then
            strItem = strItem + ",Vorpal"
        End If
        If chkWounding.Checked = True Then
            strItem = strItem + ",Wounding"
        End If
        If chkDancing.Checked = True Then
            strItem = strItem + ",Dancing"
        End If
        If chkDefending.Checked = True Then
            strItem = strItem + ",Defending"
        End If
        If chkDisruption.Checked = True Then
            strItem = strItem + ",Disruption"
        End If
        If chkMightyCleaving.Checked = True Then
            strItem = strItem + ",Mighty Cleaving"
        End If
        If chkSpellStoring.Checked = True Then
            strItem = strItem + ",Spell Storing"
        End If
        If chkThrowing.Checked = True Then
            strItem = strItem + ",Throwing"
        End If
        If chkDistance.Checked = True Then
            strItem = strItem + ",Distance"
        End If
        If chkReturning.Checked = True Then
            strItem = strItem + ",Returning"
        End If
        frmAddItems.lstAddItems.Items.Add(strItem)
        Me.Close()
    End Sub

    Private Sub FrmAttributes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
    End Sub
End Class