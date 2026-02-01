<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputUser
    Inherits APK_Penjadwalan_Matakuliah_TRPL_OOP.FrmBaseInput

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIdUser = New System.Windows.Forms.Label()
        Me.lblNamaUser = New System.Windows.Forms.Label()
        Me.lblPasswordUser = New System.Windows.Forms.Label()
        Me.lblLevelUser = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdUser = New System.Windows.Forms.TextBox()
        Me.txtNamaUser = New System.Windows.Forms.TextBox()
        Me.txtPasswordUser = New System.Windows.Forms.TextBox()
        Me.cmbLevelUser = New System.Windows.Forms.ComboBox()
        Me.pnlMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(433, 59)
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain.Size = New System.Drawing.Size(433, 164)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdUser, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNamaUser, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPasswordUser, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLevelUser, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIdUser, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNamaUser, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPasswordUser, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbLevelUser, 2, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(433, 164)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblIdUser
        '
        Me.lblIdUser.AutoSize = True
        Me.lblIdUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdUser.Location = New System.Drawing.Point(3, 0)
        Me.lblIdUser.Name = "lblIdUser"
        Me.lblIdUser.Size = New System.Drawing.Size(144, 31)
        Me.lblIdUser.TabIndex = 0
        Me.lblIdUser.Text = "ID User"
        '
        'lblNamaUser
        '
        Me.lblNamaUser.AutoSize = True
        Me.lblNamaUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaUser.Location = New System.Drawing.Point(3, 31)
        Me.lblNamaUser.Name = "lblNamaUser"
        Me.lblNamaUser.Size = New System.Drawing.Size(144, 31)
        Me.lblNamaUser.TabIndex = 1
        Me.lblNamaUser.Text = "Nama User"
        '
        'lblPasswordUser
        '
        Me.lblPasswordUser.AutoSize = True
        Me.lblPasswordUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPasswordUser.Location = New System.Drawing.Point(3, 62)
        Me.lblPasswordUser.Name = "lblPasswordUser"
        Me.lblPasswordUser.Size = New System.Drawing.Size(144, 31)
        Me.lblPasswordUser.TabIndex = 2
        Me.lblPasswordUser.Text = "Password User"
        '
        'lblLevelUser
        '
        Me.lblLevelUser.AutoSize = True
        Me.lblLevelUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLevelUser.Location = New System.Drawing.Point(3, 93)
        Me.lblLevelUser.Name = "lblLevelUser"
        Me.lblLevelUser.Size = New System.Drawing.Size(144, 31)
        Me.lblLevelUser.TabIndex = 3
        Me.lblLevelUser.Text = "Level User"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(153, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(153, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 31)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(153, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 31)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(153, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 31)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = ":"
        '
        'txtIdUser
        '
        Me.txtIdUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdUser.Location = New System.Drawing.Point(173, 3)
        Me.txtIdUser.Name = "txtIdUser"
        Me.txtIdUser.Size = New System.Drawing.Size(257, 25)
        Me.txtIdUser.TabIndex = 8
        '
        'txtNamaUser
        '
        Me.txtNamaUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNamaUser.Location = New System.Drawing.Point(173, 34)
        Me.txtNamaUser.Name = "txtNamaUser"
        Me.txtNamaUser.Size = New System.Drawing.Size(257, 25)
        Me.txtNamaUser.TabIndex = 9
        '
        'txtPasswordUser
        '
        Me.txtPasswordUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPasswordUser.Location = New System.Drawing.Point(173, 65)
        Me.txtPasswordUser.Name = "txtPasswordUser"
        Me.txtPasswordUser.Size = New System.Drawing.Size(257, 25)
        Me.txtPasswordUser.TabIndex = 10
        '
        'cmbLevelUser
        '
        Me.cmbLevelUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLevelUser.FormattingEnabled = True
        Me.cmbLevelUser.Location = New System.Drawing.Point(173, 96)
        Me.cmbLevelUser.Name = "cmbLevelUser"
        Me.cmbLevelUser.Size = New System.Drawing.Size(257, 25)
        Me.cmbLevelUser.TabIndex = 11
        '
        'FrmInputUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(433, 259)
        Me.Name = "FrmInputUser"
        Me.pnlMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblIdUser As Label
    Friend WithEvents lblNamaUser As Label
    Friend WithEvents lblPasswordUser As Label
    Friend WithEvents lblLevelUser As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIdUser As TextBox
    Friend WithEvents txtNamaUser As TextBox
    Friend WithEvents txtPasswordUser As TextBox
    Friend WithEvents cmbLevelUser As ComboBox
End Class
