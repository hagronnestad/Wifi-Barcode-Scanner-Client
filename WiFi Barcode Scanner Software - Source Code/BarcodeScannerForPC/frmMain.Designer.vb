<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.grpGeneralSettings = New System.Windows.Forms.GroupBox()
        Me.chkUseAdditionalCommands = New System.Windows.Forms.CheckBox()
        Me.chkCopyBarcodeToClipboard = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComputerID = New System.Windows.Forms.TextBox()
        Me.chkSendBarcode = New System.Windows.Forms.CheckBox()
        Me.ni = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmnuNI = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpExtraCommands = New System.Windows.Forms.GroupBox()
        Me.cmbAppendCommands = New System.Windows.Forms.ComboBox()
        Me.cmbPrependCommands = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCustomPrepend = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustomAppend = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.grpSendBarcode = New System.Windows.Forms.GroupBox()
        Me.grpGeneralSettings.SuspendLayout()
        Me.cmnuNI.SuspendLayout()
        Me.grpExtraCommands.SuspendLayout()
        Me.grpSendBarcode.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpGeneralSettings
        '
        Me.grpGeneralSettings.Controls.Add(Me.Label3)
        Me.grpGeneralSettings.Controls.Add(Me.Label2)
        Me.grpGeneralSettings.Controls.Add(Me.txtComputerID)
        Me.grpGeneralSettings.Location = New System.Drawing.Point(12, 12)
        Me.grpGeneralSettings.Name = "grpGeneralSettings"
        Me.grpGeneralSettings.Padding = New System.Windows.Forms.Padding(8)
        Me.grpGeneralSettings.Size = New System.Drawing.Size(332, 104)
        Me.grpGeneralSettings.TabIndex = 0
        Me.grpGeneralSettings.TabStop = False
        Me.grpGeneralSettings.Text = "General settings"
        '
        'chkUseAdditionalCommands
        '
        Me.chkUseAdditionalCommands.Checked = Global.BarcodeScannerForPC.My.MySettings.Default.chkUseAdditionalCommands
        Me.chkUseAdditionalCommands.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseAdditionalCommands.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BarcodeScannerForPC.My.MySettings.Default, "chkUseAdditionalCommands", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkUseAdditionalCommands.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Global.BarcodeScannerForPC.My.MySettings.Default, "chkSendBarcode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkUseAdditionalCommands.Enabled = Global.BarcodeScannerForPC.My.MySettings.Default.chkSendBarcode
        Me.chkUseAdditionalCommands.Location = New System.Drawing.Point(34, 44)
        Me.chkUseAdditionalCommands.Name = "chkUseAdditionalCommands"
        Me.chkUseAdditionalCommands.Size = New System.Drawing.Size(256, 17)
        Me.chkUseAdditionalCommands.TabIndex = 12
        Me.chkUseAdditionalCommands.Text = "Send additional commands"
        Me.chkUseAdditionalCommands.UseVisualStyleBackColor = True
        '
        'chkCopyBarcodeToClipboard
        '
        Me.chkCopyBarcodeToClipboard.Checked = Global.BarcodeScannerForPC.My.MySettings.Default.chkCopyBarcodeToClipboard
        Me.chkCopyBarcodeToClipboard.Location = New System.Drawing.Point(14, 76)
        Me.chkCopyBarcodeToClipboard.Name = "chkCopyBarcodeToClipboard"
        Me.chkCopyBarcodeToClipboard.Size = New System.Drawing.Size(293, 17)
        Me.chkCopyBarcodeToClipboard.TabIndex = 11
        Me.chkCopyBarcodeToClipboard.Text = "Copy the barcode to the clipboard"
        Me.chkCopyBarcodeToClipboard.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(11, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(307, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Enter a unique name for this computer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This name will be shown in the WiFi Barco" & _
    "de Scanner app."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Computer name"
        '
        'txtComputerID
        '
        Me.txtComputerID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BarcodeScannerForPC.My.MySettings.Default, "txtComputerID", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtComputerID.Location = New System.Drawing.Point(14, 68)
        Me.txtComputerID.Name = "txtComputerID"
        Me.txtComputerID.Size = New System.Drawing.Size(306, 22)
        Me.txtComputerID.TabIndex = 0
        Me.txtComputerID.Text = Global.BarcodeScannerForPC.My.MySettings.Default.txtComputerID
        '
        'chkSendBarcode
        '
        Me.chkSendBarcode.Checked = Global.BarcodeScannerForPC.My.MySettings.Default.chkSendBarcode
        Me.chkSendBarcode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSendBarcode.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BarcodeScannerForPC.My.MySettings.Default, "chkSendBarcode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkSendBarcode.Location = New System.Drawing.Point(14, 21)
        Me.chkSendBarcode.Name = "chkSendBarcode"
        Me.chkSendBarcode.Size = New System.Drawing.Size(293, 17)
        Me.chkSendBarcode.TabIndex = 1
        Me.chkSendBarcode.Text = "Send the barcode to the active application"
        Me.chkSendBarcode.UseVisualStyleBackColor = True
        '
        'ni
        '
        Me.ni.ContextMenuStrip = Me.cmnuNI
        Me.ni.Icon = CType(resources.GetObject("ni.Icon"), System.Drawing.Icon)
        Me.ni.Text = "Barcode Reader For PC"
        Me.ni.Visible = True
        '
        'cmnuNI
        '
        Me.cmnuNI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuSettings, Me.ToolStripSeparator1, Me.cmnuExit})
        Me.cmnuNI.Name = "cmnuNI"
        Me.cmnuNI.Size = New System.Drawing.Size(117, 54)
        '
        'cmnuSettings
        '
        Me.cmnuSettings.Name = "cmnuSettings"
        Me.cmnuSettings.Size = New System.Drawing.Size(116, 22)
        Me.cmnuSettings.Text = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(113, 6)
        '
        'cmnuExit
        '
        Me.cmnuExit.Name = "cmnuExit"
        Me.cmnuExit.Size = New System.Drawing.Size(116, 22)
        Me.cmnuExit.Text = "Exit"
        '
        'grpExtraCommands
        '
        Me.grpExtraCommands.Controls.Add(Me.cmbAppendCommands)
        Me.grpExtraCommands.Controls.Add(Me.cmbPrependCommands)
        Me.grpExtraCommands.Controls.Add(Me.Label5)
        Me.grpExtraCommands.Controls.Add(Me.txtCustomPrepend)
        Me.grpExtraCommands.Controls.Add(Me.Label1)
        Me.grpExtraCommands.Controls.Add(Me.txtCustomAppend)
        Me.grpExtraCommands.Controls.Add(Me.Label4)
        Me.grpExtraCommands.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Global.BarcodeScannerForPC.My.MySettings.Default, "chkUseAdditionalCommands", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.grpExtraCommands.Enabled = Global.BarcodeScannerForPC.My.MySettings.Default.chkUseAdditionalCommands
        Me.grpExtraCommands.Location = New System.Drawing.Point(350, 12)
        Me.grpExtraCommands.Name = "grpExtraCommands"
        Me.grpExtraCommands.Padding = New System.Windows.Forms.Padding(8)
        Me.grpExtraCommands.Size = New System.Drawing.Size(301, 439)
        Me.grpExtraCommands.TabIndex = 2
        Me.grpExtraCommands.TabStop = False
        Me.grpExtraCommands.Text = "Commands"
        '
        'cmbAppendCommands
        '
        Me.cmbAppendCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAppendCommands.FormattingEnabled = True
        Me.cmbAppendCommands.Items.AddRange(New Object() {"Choose a command to add it", "{BACKSPACE}", "{BREAK}", "{CAPSLOCK}", "{DELETE}", "{DOWN}", "{END}", "{ENTER}", "{ESC}", "{HELP}", "{HOME}", "{INSERT}", "{LEFT}", "{NUMLOCK}", "{PGDN}", "{PGUP}", "{RIGHT}", "{SCROLLLOCK}", "{TAB}", "{UP}", "{F1}", "{F2}", "{F3}", "{F4}", "{F5}", "{F6}", "{F7}", "{F8}", "{F9}", "{F10}", "{F11}", "{F12}", "{F13}", "{F14}", "{F15}", "{F16}", "{ADD}", "{SUBTRACT}", "{MULTIPLY}", "{DIVIDE}"})
        Me.cmbAppendCommands.Location = New System.Drawing.Point(11, 345)
        Me.cmbAppendCommands.Name = "cmbAppendCommands"
        Me.cmbAppendCommands.Size = New System.Drawing.Size(274, 21)
        Me.cmbAppendCommands.TabIndex = 18
        '
        'cmbPrependCommands
        '
        Me.cmbPrependCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrependCommands.FormattingEnabled = True
        Me.cmbPrependCommands.Items.AddRange(New Object() {"Choose a command to add it", "{BACKSPACE}", "{BREAK}", "{CAPSLOCK}", "{DELETE}", "{DOWN}", "{END}", "{ENTER}", "{ESC}", "{HELP}", "{HOME}", "{INSERT}", "{LEFT}", "{NUMLOCK}", "{PGDN}", "{PGUP}", "{RIGHT}", "{SCROLLLOCK}", "{TAB}", "{UP}", "{F1}", "{F2}", "{F3}", "{F4}", "{F5}", "{F6}", "{F7}", "{F8}", "{F9}", "{F10}", "{F11}", "{F12}", "{F13}", "{F14}", "{F15}", "{F16}", "{ADD}", "{SUBTRACT}", "{MULTIPLY}", "{DIVIDE}"})
        Me.cmbPrependCommands.Location = New System.Drawing.Point(11, 240)
        Me.cmbPrependCommands.Name = "cmbPrependCommands"
        Me.cmbPrependCommands.Size = New System.Drawing.Size(274, 21)
        Me.cmbPrependCommands.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(226, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Send these commands before the barcode"
        '
        'txtCustomPrepend
        '
        Me.txtCustomPrepend.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BarcodeScannerForPC.My.MySettings.Default, "txtCustomPrepend", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtCustomPrepend.Location = New System.Drawing.Point(11, 267)
        Me.txtCustomPrepend.Multiline = True
        Me.txtCustomPrepend.Name = "txtCustomPrepend"
        Me.txtCustomPrepend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCustomPrepend.Size = New System.Drawing.Size(274, 46)
        Me.txtCustomPrepend.TabIndex = 15
        Me.txtCustomPrepend.Text = Global.BarcodeScannerForPC.My.MySettings.Default.txtCustomPrepend
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 329)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Send these commands after the barcode"
        '
        'txtCustomAppend
        '
        Me.txtCustomAppend.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BarcodeScannerForPC.My.MySettings.Default, "txtCustomAppend", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtCustomAppend.Location = New System.Drawing.Point(11, 372)
        Me.txtCustomAppend.Multiline = True
        Me.txtCustomAppend.Name = "txtCustomAppend"
        Me.txtCustomAppend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCustomAppend.Size = New System.Drawing.Size(274, 46)
        Me.txtCustomAppend.TabIndex = 13
        Me.txtCustomAppend.Text = Global.BarcodeScannerForPC.My.MySettings.Default.txtCustomAppend
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(279, 201)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(563, 476)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(89, 25)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(468, 476)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'grpSendBarcode
        '
        Me.grpSendBarcode.Controls.Add(Me.chkUseAdditionalCommands)
        Me.grpSendBarcode.Controls.Add(Me.chkSendBarcode)
        Me.grpSendBarcode.Controls.Add(Me.chkCopyBarcodeToClipboard)
        Me.grpSendBarcode.Location = New System.Drawing.Point(12, 122)
        Me.grpSendBarcode.Name = "grpSendBarcode"
        Me.grpSendBarcode.Size = New System.Drawing.Size(332, 104)
        Me.grpSendBarcode.TabIndex = 5
        Me.grpSendBarcode.TabStop = False
        Me.grpSendBarcode.Text = "Barcode settings"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 513)
        Me.Controls.Add(Me.grpSendBarcode)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpExtraCommands)
        Me.Controls.Add(Me.grpGeneralSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WiFi Barcode Scanner Software"
        Me.grpGeneralSettings.ResumeLayout(False)
        Me.grpGeneralSettings.PerformLayout()
        Me.cmnuNI.ResumeLayout(False)
        Me.grpExtraCommands.ResumeLayout(False)
        Me.grpExtraCommands.PerformLayout()
        Me.grpSendBarcode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpGeneralSettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkSendBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComputerID As System.Windows.Forms.TextBox
    Friend WithEvents ni As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmnuNI As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpExtraCommands As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCustomPrepend As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomAppend As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPrependCommands As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAppendCommands As System.Windows.Forms.ComboBox
    Friend WithEvents chkCopyBarcodeToClipboard As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseAdditionalCommands As System.Windows.Forms.CheckBox
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents grpSendBarcode As System.Windows.Forms.GroupBox

End Class
