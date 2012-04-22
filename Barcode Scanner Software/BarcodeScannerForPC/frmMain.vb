Imports System.Net
Imports System.Net.Sockets

Public Class frmMain
    Dim WithEvents barcodeReceiver As New BarcodeReceiver
    Dim broadcastResponder As New BroadcastResponder


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text &= String.Format(" (Version {0})", My.Application.Info.Version.ToString(2))

        If My.Settings.txtComputerID.Trim = "" Then My.Settings.txtComputerID = My.Computer.Name
        cmbPrependCommands.SelectedIndex = 0
        cmbAppendCommands.SelectedIndex = 0


        If barcodeReceiver.Start() AndAlso broadcastResponder.Start(50123, My.Application.Info.Version.ToString(2), My.Settings.txtComputerID, barcodeReceiver.GetLocalPort()) Then
            ShowBalloonTip()
        Else
            MessageBox.Show("Could not start the WiFi Barcode Scanner software. Check your network connection.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If My.Settings.isFirstRun Then
            My.Settings.isFirstRun = False
            My.Settings.Save()
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ValidateAndSaveSettings()

        Me.Hide()
        e.Cancel = True
    End Sub

    Public Sub ShowBalloonTip(Optional SecondInstance = False)
        If SecondInstance Then
            ni.ShowBalloonTip(3000, Me.Text, "Barcode Scanner for PC is already running. Click this baloon to show the configuration window.", ToolTipIcon.Info)
        Else
            ni.ShowBalloonTip(3000, Me.Text, "Barcode Scanner for PC is running. Click this baloon to show the configuration window.", ToolTipIcon.Info)
        End If
    End Sub



    Private Sub barcodeReceiver_BarcodeReceived(Barcode As String) Handles barcodeReceiver.BarcodeReceived
        Debug.WriteLine("Barcode read: " & Barcode)

        If My.Settings.chkSendBarcode Then

            If My.Settings.chkUseAdditionalCommands AndAlso My.Settings.txtCustomPrepend <> "" Then
                SendKeys.SendWait(My.Settings.txtCustomPrepend)
            End If

            SendKeys.SendWait(MakeBarcodeSendKeysCompliant(Barcode))

            If My.Settings.chkUseAdditionalCommands AndAlso My.Settings.txtCustomAppend <> "" Then
                SendKeys.SendWait(My.Settings.txtCustomAppend)
            End If
        End If

        If chkCopyBarcodeToClipboard.Checked Then
            Clipboard.SetText(Barcode)
        End If


    End Sub

    Private Function MakeBarcodeSendKeysCompliant(Barcode As String) As String
        'This is a dirty hack to "support" curly brackets in a barcode.
        'Curly brackets must be sent as {{} and {}}, but if I replace all
        '{ with {{}, the next replace function to replace } with {}} would cause the
        'previous replaced bracket to not be encoded correctly anymore.
        'Instead of using RegEx or something, I just substitue curly brackets with standard brackets,
        'it's better than nothing. Sorry!
        Barcode = Barcode.Replace("{", "[")
        Barcode = Barcode.Replace("}", "]")

        'The following characters; + ^ ~ ( ) [ ] must be enclosed in curly brackets to be sent with SendKeys.
        Barcode = Barcode.Replace("+", "{+}")
        Barcode = Barcode.Replace("^", "{^}")
        Barcode = Barcode.Replace("~", "{~}")
        Barcode = Barcode.Replace("(", "{(}")
        Barcode = Barcode.Replace(")", "{)}")
        Barcode = Barcode.Replace("[", "{[}")
        Barcode = Barcode.Replace("]", "{]}")

        'This prevents double line breaks, SendKeys treat both Chr(13) and Chr(10) as a line break,
        'so a combined Windows linebreak of Chr(13) together with Chr(10) creates two linebreaks.
        'Removing the carriage return character is the way to go!
        Barcode = Barcode.Replace(Chr(13), "")

        Return Barcode
    End Function


    Private Sub ni_BalloonTipClicked(sender As Object, e As System.EventArgs) Handles ni.BalloonTipClicked
        Me.Show()
    End Sub

    Private Sub ni_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ni.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.Show()
    End Sub

    Private Sub ni_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ni.DoubleClick
        Me.Show()
    End Sub

    Private Sub cmnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuSettings.Click
        Me.Show()
    End Sub

    Private Sub cmnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuExit.Click
        ni.Visible = False

        ValidateAndSaveSettings()
        End
    End Sub


    Private Sub ValidateAndSaveSettings()
        If My.Settings.txtComputerID.Trim = "" Then My.Settings.txtComputerID = My.Computer.Name
        My.Settings.txtComputerID = My.Settings.txtComputerID.Replace("|", "_")

        broadcastResponder.computerID = My.Settings.txtComputerID

        My.Settings.Save()
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

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ValidateAndSaveSettings()
        Me.Hide()
    End Sub

    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        ValidateAndSaveSettings()
    End Sub


End Class
