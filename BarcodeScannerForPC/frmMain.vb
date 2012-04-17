Imports System.Net, System.Net.Sockets

Public Class frmMain
    Dim WithEvents S As New Server

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ValidateAndSaveSettings()

        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.txtComputerID.Trim = "" Then txtComputerID.Text = My.Computer.Name
        cmbPrependCommands.SelectedIndex = 0
        cmbAppendCommands.SelectedIndex = 0

        ni.ShowBalloonTip(3000, "Barcode Scanner for PC", "Barcode Scanner for PC is running. Click this baloon to show the configuration window.", ToolTipIcon.Info)


        S.StartServer()
        S.StartDiscoveryDaemon()
    End Sub

    Private Sub S_BarcodeRead(ByVal Barcode As String) Handles S.BarcodeRead
        Debug.WriteLine("Barcode read: " & Barcode)


        If chkSendBarcode.Checked Then
            SendKeys.SendWait(Barcode)
        End If

        If chkCopyBarcodeToClipboard.Checked Then
            Clipboard.SetText(Barcode)
        End If


    End Sub

    Private Sub ni_BalloonTipClicked(sender As Object, e As System.EventArgs) Handles ni.BalloonTipClicked
        Me.Show()
    End Sub

    Private Sub ni_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ni.DoubleClick
        Me.Show()
    End Sub

    Private Sub cmnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuSettings.Click
        Me.Show()
    End Sub

    Private Sub cmnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuExit.Click
        End
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ValidateAndSaveSettings()
        Me.Hide()
    End Sub



    Private Sub ValidateAndSaveSettings()
        If My.Settings.txtComputerID.Trim = "" Then txtComputerID.Text = My.Computer.Name

        My.Settings.Save()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If My.Settings.isFirstRun Then
            My.Settings.isFirstRun = False
            My.Settings.Save()
        Else
            Me.Hide()
        End If

    End Sub

    Private Sub cmbPrependCommands_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPrependCommands.SelectedIndexChanged
        If cmbPrependCommands.SelectedIndex <> 0 Then
            Dim selectedCommand As String = cmbPrependCommands.Text

            Dim selectionStart As Integer = txtCustomPrepend.SelectionStart
            Dim tmp1 As String = txtCustomPrepend.Text.Substring(0, selectionStart)
            Dim tmp2 As String = txtCustomPrepend.Text.Substring(selectionStart)

            txtCustomPrepend.Text = tmp1 & selectedCommand & tmp2
            txtCustomPrepend.SelectionStart = selectionStart + selectedCommand.Length
            cmbPrependCommands.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbAppendCommands_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbAppendCommands.SelectedIndexChanged
        If cmbAppendCommands.SelectedIndex <> 0 Then
            Dim selectedCommand As String = cmbAppendCommands.Text

            Dim selectionStart As Integer = txtCustomAppend.SelectionStart()
            Dim tmp1 As String = txtCustomAppend.Text.Substring(0, selectionStart)
            Dim tmp2 As String = txtCustomAppend.Text.Substring(selectionStart)

            txtCustomAppend.Text = tmp1 & selectedCommand & tmp2
            txtCustomAppend.SelectionStart = selectionStart + selectedCommand.Length
            cmbAppendCommands.SelectedIndex = 0
        End If
    End Sub
End Class
