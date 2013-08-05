' Daniel Sizemore, November 3rd 2008

Option Strict On

Public Class frmCombatSheet

    Private Sub frmDice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        If My.Computer.Screen.Bounds.Width < Me.Width Then
            Me.Width = My.Computer.Screen.Bounds.Width
        End If
        If My.Computer.Screen.Bounds.Height < Me.Height Then
            Me.Height = Convert.ToInt32(Convert.ToDouble(My.Computer.Screen.Bounds.Height) * 0.95)
        End If
        cboPlusOrMinus.SelectedIndex = 0
        cboPlusOrMinus2.SelectedIndex = 0
        cboPlusOrMinus3.SelectedIndex = 0
        cboPlusOrMinus4.SelectedIndex = 0
        cboPlusOrMinus5.SelectedIndex = 0
        cboDamagePlusOrMinus.SelectedIndex = 0
        cboPlusOrMinusAttack.SelectedIndex = 0
        cboBAB.SelectedIndex = 0
        cboThreatRange.SelectedIndex = 0
        cboMultiplier.SelectedIndex = 0
        txtCumulative.Text = "0"
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

    Private Sub btnRoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer
        ' This button calculates the random roll plus the modifier of dice roller 1
        If Not IsNumeric(txtNumberOfDice.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDice.Clear()
            txtNumberOfDice.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDice.Text)
        End If
        Select Case cboDiceSize.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtModifier.TextLength > 0 Then
            If Not IsNumeric(txtModifier.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtModifier.Clear()
                txtModifier.Focus()
                blnError = True
            Else
                Select Case cboPlusOrMinus.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtModifier.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtModifier.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + Convert.ToInt32(intModifier)
            If intResult < 1 Then
                intResult = 1
            End If
            txtResult.Text = Convert.ToString(intResult)
        End If
    End Sub

    Private Sub btnRoll2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll2.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer
        ' This button calculates the random roll plus the modifier of dice roller 2
        If Not IsNumeric(txtNumberOfDice2.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDice2.Clear()
            txtNumberOfDice2.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDice2.Text)
        End If
        Select Case cboDiceSize2.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtModifier2.TextLength > 0 Then
            If Not IsNumeric(txtModifier2.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtModifier2.Clear()
                txtModifier2.Focus()
                blnError = True
            Else
                Select Case cboPlusOrMinus2.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtModifier2.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtModifier2.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + Convert.ToInt32(intModifier)
            If intResult < 1 Then
                intResult = 1
            End If
            txtResult2.Text = Convert.ToString(intResult)
        End If
    End Sub

    Private Sub btnRoll3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll3.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer
        ' This button calculates the random roll plus the modifier of dice roller 3
        If Not IsNumeric(txtNumberOfDice3.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDice3.Clear()
            txtNumberOfDice3.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDice3.Text)
        End If
        Select Case cboDiceSize3.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtModifier3.TextLength > 0 Then
            If Not IsNumeric(txtModifier3.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtModifier3.Clear()
                txtModifier3.Focus()
                blnError = True
            Else
                Select Case cboPlusOrMinus3.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtModifier3.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtModifier3.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + Convert.ToInt32(intModifier)
            If intResult < 1 Then
                intResult = 1
            End If
            txtResult3.Text = Convert.ToString(intResult)
        End If
    End Sub

    Private Sub btnRoll4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll4.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer
        ' This button calculates the random roll plus the modifier of dice roller 4
        If Not IsNumeric(txtNumberOfDice4.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDice4.Clear()
            txtNumberOfDice4.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDice4.Text)
        End If
        Select Case cboDiceSize4.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtModifier4.TextLength > 0 Then
            If Not IsNumeric(txtModifier4.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtModifier4.Clear()
                txtModifier4.Focus()
                blnError = True
            Else
                Select Case cboPlusOrMinus4.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtModifier4.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtModifier4.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + Convert.ToInt32(intModifier)
            If intResult < 1 Then
                intResult = 1
            End If
            txtResult4.Text = Convert.ToString(intResult)
        End If
    End Sub

    Private Sub btnRoll5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll5.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer
        ' This button calculates the random roll plus the modifier of dice roller 5
        If Not IsNumeric(txtNumberOfDice5.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDice5.Clear()
            txtNumberOfDice5.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDice5.Text)
        End If
        Select Case cboDiceSize5.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtModifier5.TextLength > 0 Then
            If Not IsNumeric(txtModifier5.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtModifier5.Clear()
                txtModifier5.Focus()
                blnError = True
            Else
                Select Case cboPlusOrMinus5.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtModifier5.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtModifier5.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + Convert.ToInt32(intModifier)
            If intResult < 1 Then
                intResult = 1
            End If
            txtResult5.Text = Convert.ToString(intResult)
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        txtNumberOfDice.Text = ""
        txtNumberOfDice2.Text = ""
        txtNumberOfDice3.Text = ""
        txtNumberOfDice4.Text = ""
        txtNumberOfDice5.Text = ""
        cboDiceSize.SelectedIndex = -1
        cboDiceSize2.SelectedIndex = -1
        cboDiceSize3.SelectedIndex = -1
        cboDiceSize4.SelectedIndex = -1
        cboDiceSize5.SelectedIndex = -1
        cboPlusOrMinus.SelectedIndex = 0
        cboPlusOrMinus2.SelectedIndex = 0
        cboPlusOrMinus3.SelectedIndex = 0
        cboPlusOrMinus4.SelectedIndex = 0
        cboPlusOrMinus5.SelectedIndex = 0
        txtModifier.Text = ""
        txtModifier2.Text = ""
        txtModifier3.Text = ""
        txtModifier4.Text = ""
        txtModifier5.Text = ""
        txtResult.Text = ""
        txtResult2.Text = ""
        txtResult3.Text = ""
        txtResult4.Text = ""
        txtResult5.Text = ""
        txtNumberOfDamageDice.Clear()
        cboDamageDiceSize.SelectedIndex = -1
        cboDamagePlusOrMinus.SelectedIndex = 0
        txtDamageBonus.Clear()
        cboThreatRange.SelectedIndex = 0
        cboMultiplier.SelectedIndex = 0
        chkDiceRollerOne.Checked = False
        chkDiceRollerTwo.Checked = False
        chkDiceRollerThree.Checked = False
        chkDiceRollerFour.Checked = False
        chkDiceRollerFive.Checked = False
        cboDamageType1.SelectedIndex = -1
        cboDamageType2.SelectedIndex = -1
        cboDamageType3.SelectedIndex = -1
        cboDamageType4.SelectedIndex = -1
        cboDamageType5.SelectedIndex = -1
        cboMode1.SelectedIndex = -1
        cboMode2.SelectedIndex = -1
        cboMode3.SelectedIndex = -1
        cboMode4.SelectedIndex = -1
        cboMode5.SelectedIndex = -1
        cboBAB.SelectedIndex = -1
        chkExtraAttack.Checked = False
        chkSecondExtraAttack.Checked = False
        cboPlusOrMinusAttack.SelectedIndex = 0
        txtbonus.Clear()
        txtAttacks.Clear()
        TxtResults.Clear()
        btnClear_Click(Nothing, Nothing)

    End Sub

    Private Function CalculateAttacks() As Integer()
        Dim intAttacks(6) As Integer
        ' the first 5 integers in the array hold the values for the possible attacks of the char,
        ' the last integer holds how many attacks the char gets
        Dim intMonkAttack As Integer
        Dim intBonus As Integer
        ' this sets all recursive attacks off and in the next set of code turns them on if the base attack bonus is high enough
        intAttacks(5) = 1
        If cboBAB.SelectedIndex <= 20 Then
            intAttacks(0) = cboBAB.SelectedIndex
            If cboBAB.SelectedIndex > 5 Then
                intAttacks(5) = 2
                intAttacks(1) = cboBAB.SelectedIndex - 5
                If cboBAB.SelectedIndex > 10 Then
                    intAttacks(5) = 3
                    intAttacks(2) = cboBAB.SelectedIndex - 10
                    If cboBAB.SelectedIndex > 15 Then
                        intAttacks(5) = 4
                        intAttacks(3) = cboBAB.SelectedIndex - 15
                    End If
                End If
            End If
        Else
            intMonkAttack = cboBAB.SelectedIndex - 17
            intAttacks(0) = intMonkAttack
            If intMonkAttack > 3 Then
                intAttacks(5) = 2
                intAttacks(1) = intMonkAttack - 3
                If intMonkAttack > 6 Then
                    intAttacks(5) = 3
                    intAttacks(2) = intMonkAttack - 6
                    If intMonkAttack > 9 Then
                        intAttacks(5) = 4
                        intAttacks(3) = intMonkAttack - 9
                        If intMonkAttack > 12 Then
                            intAttacks(5) = 5
                            intAttacks(4) = intMonkAttack - 12
                        End If
                    End If
                End If
            End If
        End If
        If cboPlusOrMinusAttack.SelectedIndex = 0 Then
            intBonus = Convert.ToInt32(txtbonus.Text)
        ElseIf cboPlusOrMinusAttack.SelectedIndex = 1 Then
            intBonus = -1 * Convert.ToInt32(txtbonus.Text)
        End If
        intAttacks(0) = intAttacks(0) + intBonus
        If intAttacks(1) > 0 Then
            intAttacks(1) = intAttacks(1) + intBonus
        End If
        If intAttacks(2) > 0 Then
            intAttacks(2) = intAttacks(2) + intBonus
        End If
        If intAttacks(3) > 0 Then
            intAttacks(3) = intAttacks(3) + intBonus
        End If
        If intAttacks(4) > 0 Then
            intAttacks(4) = intAttacks(4) + intBonus
        End If
        Return intAttacks
    End Function

    Private Sub cboBAB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAB.SelectedIndexChanged
        Dim intAttacks(6) As Integer
        Dim strAttacks As String
        ' this calls the function to calculate the number and bonuses of the attacks and saves all the info into a string and displays it.
        intAttacks = CalculateAttacks()
        If intAttacks(0) > -1 Then
            strAttacks = "+" & Convert.ToString(intAttacks(0))
        Else
            strAttacks = "-" & Convert.ToString(intAttacks(0))
        End If
        If chkExtraAttack.Checked Then
            If intAttacks(0) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(0))
            Else
                strAttacks = strAttacks & "/-" & Convert.ToString(intAttacks(0))
            End If
        End If
        If chkSecondExtraAttack.Checked Then
            If intAttacks(0) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(0))
            Else
                strAttacks = strAttacks & "/-" & Convert.ToString(intAttacks(0))
            End If
        End If
        If intAttacks(5) >= 2 Then
            If intAttacks(1) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(1))
            Else
                strAttacks = strAttacks & "/" & Convert.ToString(intAttacks(1))
            End If
        End If
        If intAttacks(5) >= 3 Then
            If intAttacks(2) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(2))
            Else
                strAttacks = strAttacks & "/" & Convert.ToString(intAttacks(2))
            End If
        End If
        If intAttacks(5) >= 4 Then
            If intAttacks(3) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(3))
            Else
                strAttacks = strAttacks & "/" & Convert.ToString(intAttacks(3))
            End If
        End If
        If intAttacks(5) >= 5 Then
            If intAttacks(4) > -1 Then
                strAttacks = strAttacks & "/+" & Convert.ToString(intAttacks(4))
            Else
                strAttacks = strAttacks & "/" & Convert.ToString(intAttacks(4))
            End If
        End If
        txtAttacks.Text = strAttacks
    End Sub

    Private Sub chkExtraAttack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExtraAttack.CheckedChanged
        If chkExtraAttack.Checked Then
            chkSecondExtraAttack.Enabled = True
        End If
        If chkExtraAttack.Checked = False Then
            chkSecondExtraAttack.Enabled = False
            chkSecondExtraAttack.Checked = False
        End If
        cboBAB_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub chkSecondExtraAttack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSecondExtraAttack.CheckedChanged
        cboBAB_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboPlusOrMinusAttack_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlusOrMinusAttack.SelectedIndexChanged
        cboBAB_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub txtbonus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbonus.TextChanged
        cboBAB_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub BtnRollAttacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRollAttacks.Click
        Dim intAttacks(6) As Integer
        Dim intDiceRoll As Integer
        ' This button calculates one attack such as an attack of opportunity or a single attack as a standard action.  An Asterik denotes a natural 20,
        ' and parentheses denotes a critical confirmation roll.
        TxtResults.Text = ""
        intAttacks = CalculateAttacks()
        intDiceRoll = DiceRoll(1, 20)
        If intDiceRoll = 20 Then
            TxtResults.Text = "*" & Convert.ToString(intDiceRoll + intAttacks(0))
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & "*"
            End If
            TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
        Else
            TxtResults.Text = Convert.ToString(intDiceRoll + intAttacks(0))
        End If
    End Sub

    Private Sub BtnRollAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRollAll.Click
        Dim intAttacks(6) As Integer
        Dim intDiceRoll As Integer
        ' this button rolls all attacks specified and displays them with comma's separating the individual attacks.  Natural 20's are denoted with
        ' an Asterik and rolls to confirm critical hits are displayed in parentheses next to the rolls that triggered them.
        TxtResults.Text = ""
        intAttacks = CalculateAttacks()
        intDiceRoll = DiceRoll(1, 20)
        If intDiceRoll = 20 Then
            TxtResults.Text = "*" & Convert.ToString(intDiceRoll + intAttacks(0))
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & "*"
            End If
            TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
        ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
            TxtResults.Text = Convert.ToString(intDiceRoll + intAttacks(0))
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & "*"
            End If
            TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
        Else
            TxtResults.Text = Convert.ToString(intDiceRoll + intAttacks(0))
        End If

        If chkExtraAttack.Checked Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(0))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(0))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(0))
            End If
        End If
        If chkSecondExtraAttack.Checked Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(0))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(0))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(0)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(0))
            End If
        End If
        If intAttacks(5) >= 2 Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(1))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(1)) & ")"
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(1))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(1)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(1))
            End If
        End If
        If intAttacks(5) >= 3 Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(2))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(2)) & ")"
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(2))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(2)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(2))
            End If
        End If
        If intAttacks(5) >= 4 Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(3))
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(3))
                intDiceRoll = DiceRoll(1, 20)
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(3)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(3))
            End If
        End If
        If intAttacks(5) >= 5 Then
            intDiceRoll = DiceRoll(1, 20)
            If intDiceRoll = 20 Then
                TxtResults.Text = TxtResults.Text & ", *" & Convert.ToString(intDiceRoll + intAttacks(4))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(4)) & ")"
            ElseIf intDiceRoll >= 20 - cboThreatRange.SelectedIndex Then
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(4))
                intDiceRoll = DiceRoll(1, 20)
                If intDiceRoll = 20 Then
                    TxtResults.Text = TxtResults.Text & "*"
                End If
                TxtResults.Text = TxtResults.Text & "(" & Convert.ToString(intDiceRoll + intAttacks(4)) & ")"
            Else
                TxtResults.Text = TxtResults.Text & ", " & Convert.ToString(intDiceRoll + intAttacks(4))
            End If
        End If
    End Sub

    Private Sub btnHit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHit.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer = 0
        Dim intTotal As Integer = 0
        Dim intCumulative As Integer = 0
        'This button calculates the damage from a single hit by adding the weapon damage with any dice rollers designated by "on both" and "on hit"
        If Not IsNumeric(txtNumberOfDamageDice.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDamageDice.Clear()
            txtNumberOfDamageDice.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDamageDice.Text)
        End If
        Select Case cboDamageDiceSize.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtDamageBonus.TextLength > 0 Then
            If Not IsNumeric(txtDamageBonus.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtDamageBonus.Clear()
                txtDamageBonus.Focus()
                blnError = True
            Else
                Select Case cbodamagePlusOrMinus.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtDamageBonus.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtDamageBonus.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intResult = DiceRoll(intDiceNum, intDiceSize) + intModifier
            If intResult < 1 Then
                intResult = 1
            End If
            intTotal = intTotal + intResult
            txtDamage.Text = Convert.ToString(intResult) & " as physical Damage"
        End If
        If chkDiceRollerOne.Checked Then
            If cboMode1.SelectedIndex = 0 Or cboMode1.SelectedIndex = 1 Then
                btnRoll_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult.Text & " " & Convert.ToString(cboDamageType1.SelectedItem)
                If cboDamageType1.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult.Text)
                End If
            End If
        End If
        If chkDiceRollerTwo.Checked Then
            If cboMode2.SelectedIndex = 0 Or cboMode2.SelectedIndex = 1 Then
                btnRoll2_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult2.Text & " " & Convert.ToString(cboDamageType2.SelectedItem)
                If cboDamageType2.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult2.Text)
                End If
            End If
        End If
        If chkDiceRollerThree.Checked Then
            If cboMode3.SelectedIndex = 0 Or cboMode3.SelectedIndex = 1 Then
                btnRoll3_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult3.Text & " " & Convert.ToString(cboDamageType3.SelectedItem)
                If cboDamageType3.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult3.Text)
                End If
            End If
        End If
        If chkDiceRollerFour.Checked Then
            If cboMode4.SelectedIndex = 0 Or cboMode4.SelectedIndex = 1 Then
                btnRoll4_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult4.Text & " " & Convert.ToString(cboDamageType4.SelectedItem)
                If cboDamageType4.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult4.Text)
                End If
            End If
        End If
        If chkDiceRollerFive.Checked Then
            If cboMode5.SelectedIndex = 0 Or cboMode5.SelectedIndex = 1 Then
                btnRoll5_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult5.Text & " " & Convert.ToString(cboDamageType5.SelectedItem)
                If cboDamageType5.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult5.Text)
                End If
            End If
        End If
        txtTotalDamage.Text = Convert.ToString(intTotal)
        intCumulative = Convert.ToInt32(txtCumulative.Text) + intTotal
        txtCumulative.Text = Convert.ToString(intCumulative)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'this button clears the damage fields
        txtDamage.Text = ""
        txtTotalDamage.Text = "0"
        txtCumulative.Text = "0"
    End Sub

    Private Sub btnCriticalHit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriticalHit.Click
        Dim intDiceNum As Integer
        Dim intDiceSize As Integer
        Dim blnError As Boolean = False
        Dim intModifier As Integer
        Dim intResult As Integer = 0
        Dim intTotal As Integer = 0
        Dim intCumulative As Integer = 0
        Dim intMultiplier As Integer
        Dim i As Integer
        ' This button is to calculate the damage from a critical hit.  It rerolls and adds together the base weapon damage based on the multiplier and 
        ' adds all dice rollers designated as "on both" and "on crit"
        intMultiplier = cboMultiplier.SelectedIndex + 2
        If Not IsNumeric(txtNumberOfDamageDice.Text) Then
            MessageBox.Show("Enter the number of dice to be rolled", "Error")
            txtNumberOfDamageDice.Clear()
            txtNumberOfDamageDice.Focus()
            blnError = True
        Else
            intDiceNum = Convert.ToInt32(txtNumberOfDamageDice.Text)
        End If
        Select Case cboDamageDiceSize.SelectedIndex
            Case 0
                intDiceSize = 2
            Case 1
                intDiceSize = 3
            Case 2
                intDiceSize = 4
            Case 3
                intDiceSize = 6
            Case 4
                intDiceSize = 8
            Case 5
                intDiceSize = 10
            Case 6
                intDiceSize = 12
            Case 7
                intDiceSize = 20
            Case 8
                intDiceSize = 100
            Case Else
                MessageBox.Show("Please select a size for the dice(die) to be rolled.", "Error")
                blnError = True
        End Select
        If txtDamageBonus.TextLength > 0 Then
            If Not IsNumeric(txtDamageBonus.Text) Then
                MessageBox.Show("Do not enter text into the modifier field", "Error")
                txtDamageBonus.Clear()
                txtDamageBonus.Focus()
                blnError = True
            Else
                Select Case cboDamagePlusOrMinus.SelectedIndex
                    Case 0
                        intModifier = Convert.ToInt32(txtDamageBonus.Text)
                    Case 1
                        intModifier = -1 * Convert.ToInt32(txtDamageBonus.Text)
                    Case Else
                        MessageBox.Show("Please select either plus or minus for the modifier", "Error")
                End Select
            End If
        End If
        If Not blnError Then
            intTotal = 0
            For i = 1 To intMultiplier
                intResult = DiceRoll(intDiceNum, intDiceSize) + intModifier
                If intResult < 1 Then
                    intResult = 1
                End If
                intTotal = intTotal + intResult
            Next
            txtDamage.Text = Convert.ToString(intTotal) & " as physical Damage"
        End If
        If chkDiceRollerOne.Checked Then
            If cboMode1.SelectedIndex = 0 Or cboMode1.SelectedIndex = 2 Then
                btnRoll_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult.Text & " " & Convert.ToString(cboDamageType1.SelectedItem)
                If cboDamageType1.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult.Text)
                End If
            End If
        End If
        If chkDiceRollerTwo.Checked Then
            If cboMode2.SelectedIndex = 0 Or cboMode2.SelectedIndex = 2 Then
                btnRoll2_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult2.Text & " " & Convert.ToString(cboDamageType2.SelectedItem)
                If cboDamageType2.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult2.Text)
                End If
            End If
        End If
        If chkDiceRollerThree.Checked Then
            If cboMode3.SelectedIndex = 0 Or cboMode3.SelectedIndex = 2 Then
                btnRoll3_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult3.Text & " " & Convert.ToString(cboDamageType3.SelectedItem)
                If cboDamageType3.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult3.Text)
                End If
            End If
        End If
        If chkDiceRollerFour.Checked Then
            If cboMode4.SelectedIndex = 0 Or cboMode4.SelectedIndex = 2 Then
                btnRoll4_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult4.Text & " " & Convert.ToString(cboDamageType4.SelectedItem)
                If cboDamageType4.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult4.Text)
                End If
            End If
        End If
        If chkDiceRollerFive.Checked Then
            If cboMode5.SelectedIndex = 0 Or cboMode5.SelectedIndex = 2 Then
                btnRoll5_Click(Nothing, Nothing)
                txtDamage.Text = txtDamage.Text & Environment.NewLine & txtResult5.Text & " " & Convert.ToString(cboDamageType5.SelectedItem)
                If cboDamageType5.SelectedIndex <= 5 Then
                    intTotal = intTotal + Convert.ToInt32(txtResult5.Text)
                End If
            End If
        End If
        txtTotalDamage.Text = Convert.ToString(intTotal)
        intCumulative = Convert.ToInt32(txtCumulative.Text) + intTotal
        txtCumulative.Text = Convert.ToString(intCumulative)
    End Sub
End Class