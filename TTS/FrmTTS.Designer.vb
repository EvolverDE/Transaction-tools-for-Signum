<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTTS
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTTS))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBPassPhrase = New System.Windows.Forms.TextBox()
        Me.TBPubKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBSigKey = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBAgreeKey = New System.Windows.Forms.TextBox()
        Me.BtPassPhrase = New System.Windows.Forms.Button()
        Me.BtPubKey = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBAccID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBAccRS = New System.Windows.Forms.TextBox()
        Me.BtAccID = New System.Windows.Forms.Button()
        Me.BtRS = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NUDWordsChars = New System.Windows.Forms.NumericUpDown()
        Me.RBtChars = New System.Windows.Forms.RadioButton()
        Me.RBtWords = New System.Windows.Forms.RadioButton()
        Me.BtShowHideAgree = New System.Windows.Forms.Button()
        Me.BtShowHideSign = New System.Windows.Forms.Button()
        Me.BtShowHidePass = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtSign = New System.Windows.Forms.Button()
        Me.TBTXBytes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TBUTXBytes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtShowHideSign2 = New System.Windows.Forms.Button()
        Me.TBSigKey2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TBPubKey2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NUDWordsChars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PassPhrase:"
        '
        'TBPassPhrase
        '
        Me.TBPassPhrase.Location = New System.Drawing.Point(92, 70)
        Me.TBPassPhrase.Name = "TBPassPhrase"
        Me.TBPassPhrase.Size = New System.Drawing.Size(404, 20)
        Me.TBPassPhrase.TabIndex = 0
        Me.TBPassPhrase.UseSystemPasswordChar = True
        '
        'TBPubKey
        '
        Me.TBPubKey.Location = New System.Drawing.Point(92, 100)
        Me.TBPubKey.Name = "TBPubKey"
        Me.TBPubKey.Size = New System.Drawing.Size(450, 20)
        Me.TBPubKey.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PublicKey:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SignatureKey:"
        '
        'TBSigKey
        '
        Me.TBSigKey.Location = New System.Drawing.Point(92, 130)
        Me.TBSigKey.Name = "TBSigKey"
        Me.TBSigKey.ReadOnly = True
        Me.TBSigKey.Size = New System.Drawing.Size(404, 20)
        Me.TBSigKey.TabIndex = 2
        Me.TBSigKey.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "AgreementKey:"
        '
        'TBAgreeKey
        '
        Me.TBAgreeKey.Location = New System.Drawing.Point(92, 160)
        Me.TBAgreeKey.Name = "TBAgreeKey"
        Me.TBAgreeKey.ReadOnly = True
        Me.TBAgreeKey.Size = New System.Drawing.Size(404, 20)
        Me.TBAgreeKey.TabIndex = 3
        Me.TBAgreeKey.UseSystemPasswordChar = True
        '
        'BtPassPhrase
        '
        Me.BtPassPhrase.Location = New System.Drawing.Point(548, 69)
        Me.BtPassPhrase.Name = "BtPassPhrase"
        Me.BtPassPhrase.Size = New System.Drawing.Size(136, 22)
        Me.BtPassPhrase.TabIndex = 6
        Me.BtPassPhrase.Text = "generate Keys / Account"
        Me.BtPassPhrase.UseVisualStyleBackColor = True
        '
        'BtPubKey
        '
        Me.BtPubKey.Location = New System.Drawing.Point(548, 99)
        Me.BtPubKey.Name = "BtPubKey"
        Me.BtPubKey.Size = New System.Drawing.Size(136, 22)
        Me.BtPubKey.TabIndex = 7
        Me.BtPubKey.Text = "convert to Account / RS"
        Me.BtPubKey.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Account ID:"
        '
        'TBAccID
        '
        Me.TBAccID.Location = New System.Drawing.Point(92, 190)
        Me.TBAccID.Name = "TBAccID"
        Me.TBAccID.Size = New System.Drawing.Size(450, 20)
        Me.TBAccID.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Address:"
        '
        'TBAccRS
        '
        Me.TBAccRS.Location = New System.Drawing.Point(92, 220)
        Me.TBAccRS.Name = "TBAccRS"
        Me.TBAccRS.Size = New System.Drawing.Size(450, 20)
        Me.TBAccRS.TabIndex = 5
        '
        'BtAccID
        '
        Me.BtAccID.Location = New System.Drawing.Point(548, 189)
        Me.BtAccID.Name = "BtAccID"
        Me.BtAccID.Size = New System.Drawing.Size(136, 22)
        Me.BtAccID.TabIndex = 8
        Me.BtAccID.Text = "convert to ReedSolomon"
        Me.BtAccID.UseVisualStyleBackColor = True
        '
        'BtRS
        '
        Me.BtRS.Location = New System.Drawing.Point(548, 219)
        Me.BtRS.Name = "BtRS"
        Me.BtRS.Size = New System.Drawing.Size(136, 22)
        Me.BtRS.TabIndex = 9
        Me.BtRS.Text = "convert to Account ID"
        Me.BtRS.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(548, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "( for encrypted Messages)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(548, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "( for signing Transactions)"
        '
        'BtNew
        '
        Me.BtNew.Location = New System.Drawing.Point(143, 42)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(62, 22)
        Me.BtNew.TabIndex = 23
        Me.BtNew.Text = "generate"
        Me.BtNew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.NUDWordsChars)
        Me.GroupBox1.Controls.Add(Me.RBtChars)
        Me.GroupBox1.Controls.Add(Me.RBtWords)
        Me.GroupBox1.Controls.Add(Me.BtShowHideAgree)
        Me.GroupBox1.Controls.Add(Me.BtShowHideSign)
        Me.GroupBox1.Controls.Add(Me.BtShowHidePass)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtNew)
        Me.GroupBox1.Controls.Add(Me.TBPassPhrase)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TBPubKey)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtRS)
        Me.GroupBox1.Controls.Add(Me.TBSigKey)
        Me.GroupBox1.Controls.Add(Me.BtAccID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TBAgreeKey)
        Me.GroupBox1.Controls.Add(Me.TBAccRS)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.BtPassPhrase)
        Me.GroupBox1.Controls.Add(Me.TBAccID)
        Me.GroupBox1.Controls.Add(Me.BtPubKey)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(690, 248)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Section"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Length:"
        '
        'NUDWordsChars
        '
        Me.NUDWordsChars.Location = New System.Drawing.Point(92, 43)
        Me.NUDWordsChars.Name = "NUDWordsChars"
        Me.NUDWordsChars.Size = New System.Drawing.Size(45, 20)
        Me.NUDWordsChars.TabIndex = 29
        Me.NUDWordsChars.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'RBtChars
        '
        Me.RBtChars.AutoSize = True
        Me.RBtChars.Location = New System.Drawing.Point(72, 19)
        Me.RBtChars.Name = "RBtChars"
        Me.RBtChars.Size = New System.Drawing.Size(95, 17)
        Me.RBtChars.TabIndex = 28
        Me.RBtChars.Text = "Random Chars"
        Me.RBtChars.UseVisualStyleBackColor = True
        '
        'RBtWords
        '
        Me.RBtWords.AutoSize = True
        Me.RBtWords.Checked = True
        Me.RBtWords.Location = New System.Drawing.Point(10, 19)
        Me.RBtWords.Name = "RBtWords"
        Me.RBtWords.Size = New System.Drawing.Size(56, 17)
        Me.RBtWords.TabIndex = 27
        Me.RBtWords.TabStop = True
        Me.RBtWords.Text = "Words"
        Me.RBtWords.UseVisualStyleBackColor = True
        '
        'BtShowHideAgree
        '
        Me.BtShowHideAgree.Location = New System.Drawing.Point(502, 159)
        Me.BtShowHideAgree.Name = "BtShowHideAgree"
        Me.BtShowHideAgree.Size = New System.Drawing.Size(40, 22)
        Me.BtShowHideAgree.TabIndex = 26
        Me.BtShowHideAgree.Text = "show"
        Me.BtShowHideAgree.UseVisualStyleBackColor = True
        '
        'BtShowHideSign
        '
        Me.BtShowHideSign.Location = New System.Drawing.Point(502, 129)
        Me.BtShowHideSign.Name = "BtShowHideSign"
        Me.BtShowHideSign.Size = New System.Drawing.Size(40, 22)
        Me.BtShowHideSign.TabIndex = 25
        Me.BtShowHideSign.Text = "show"
        Me.BtShowHideSign.UseVisualStyleBackColor = True
        '
        'BtShowHidePass
        '
        Me.BtShowHidePass.Location = New System.Drawing.Point(502, 69)
        Me.BtShowHidePass.Name = "BtShowHidePass"
        Me.BtShowHidePass.Size = New System.Drawing.Size(40, 22)
        Me.BtShowHidePass.TabIndex = 24
        Me.BtShowHidePass.Text = "show"
        Me.BtShowHidePass.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TBPubKey2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.BtShowHideSign2)
        Me.GroupBox2.Controls.Add(Me.TBSigKey2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.BtSign)
        Me.GroupBox2.Controls.Add(Me.TBTXBytes)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TBUTXBytes)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 139)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transaction Section"
        '
        'BtSign
        '
        Me.BtSign.Location = New System.Drawing.Point(587, 70)
        Me.BtSign.Name = "BtSign"
        Me.BtSign.Size = New System.Drawing.Size(79, 50)
        Me.BtSign.TabIndex = 10
        Me.BtSign.Text = "sign Transaction Bytes"
        Me.BtSign.UseVisualStyleBackColor = True
        '
        'TBTXBytes
        '
        Me.TBTXBytes.Location = New System.Drawing.Point(150, 99)
        Me.TBTXBytes.Name = "TBTXBytes"
        Me.TBTXBytes.ReadOnly = True
        Me.TBTXBytes.Size = New System.Drawing.Size(431, 20)
        Me.TBTXBytes.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Signed TransactionBytes:"
        '
        'TBUTXBytes
        '
        Me.TBUTXBytes.Location = New System.Drawing.Point(150, 71)
        Me.TBUTXBytes.Name = "TBUTXBytes"
        Me.TBUTXBytes.Size = New System.Drawing.Size(431, 20)
        Me.TBUTXBytes.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Unsigned TransactionBytes:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(714, 361)
        Me.TabControl1.TabIndex = 26
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(706, 335)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Account"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(706, 335)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transaction"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BtShowHideSign2
        '
        Me.BtShowHideSign2.Location = New System.Drawing.Point(587, 18)
        Me.BtShowHideSign2.Name = "BtShowHideSign2"
        Me.BtShowHideSign2.Size = New System.Drawing.Size(40, 22)
        Me.BtShowHideSign2.TabIndex = 28
        Me.BtShowHideSign2.Text = "show"
        Me.BtShowHideSign2.UseVisualStyleBackColor = True
        '
        'TBSigKey2
        '
        Me.TBSigKey2.Location = New System.Drawing.Point(150, 19)
        Me.TBSigKey2.Name = "TBSigKey2"
        Me.TBSigKey2.ReadOnly = True
        Me.TBSigKey2.Size = New System.Drawing.Size(431, 20)
        Me.TBSigKey2.TabIndex = 26
        Me.TBSigKey2.UseSystemPasswordChar = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "SignatureKey:"
        '
        'TBPubKey2
        '
        Me.TBPubKey2.Location = New System.Drawing.Point(150, 45)
        Me.TBPubKey2.Name = "TBPubKey2"
        Me.TBPubKey2.Size = New System.Drawing.Size(431, 20)
        Me.TBPubKey2.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "PublicKey:"
        '
        'FrmTTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 361)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmTTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction tools for Signum"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NUDWordsChars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TBPassPhrase As TextBox
    Friend WithEvents TBPubKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBSigKey As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TBAgreeKey As TextBox
    Friend WithEvents BtPassPhrase As Button
    Friend WithEvents BtPubKey As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TBAccID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TBAccRS As TextBox
    Friend WithEvents BtAccID As Button
    Friend WithEvents BtRS As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents BtNew As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtSign As Button
    Friend WithEvents TBTXBytes As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TBUTXBytes As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BtShowHidePass As Button
    Friend WithEvents BtShowHideAgree As Button
    Friend WithEvents BtShowHideSign As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents NUDWordsChars As NumericUpDown
    Friend WithEvents RBtChars As RadioButton
    Friend WithEvents RBtWords As RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BtShowHideSign2 As Button
    Friend WithEvents TBSigKey2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TBPubKey2 As TextBox
    Friend WithEvents Label13 As Label
End Class
