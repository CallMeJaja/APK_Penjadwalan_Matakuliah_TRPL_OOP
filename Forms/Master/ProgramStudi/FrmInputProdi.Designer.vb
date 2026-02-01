<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputProdi
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
        Me.lblKodeProdi = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKodeProdi = New System.Windows.Forms.TextBox()
        Me.txtNamaProdi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNamaProdi = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(414, 59)
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain.Size = New System.Drawing.Size(414, 115)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblKodeProdi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKodeProdi, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNamaProdi, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNamaProdi, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(414, 115)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblKodeProdi
        '
        Me.lblKodeProdi.AutoSize = True
        Me.lblKodeProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKodeProdi.Location = New System.Drawing.Point(3, 0)
        Me.lblKodeProdi.Name = "lblKodeProdi"
        Me.lblKodeProdi.Size = New System.Drawing.Size(144, 31)
        Me.lblKodeProdi.TabIndex = 0
        Me.lblKodeProdi.Text = "Kode Program Studi"
        Me.lblKodeProdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(153, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKodeProdi
        '
        Me.txtKodeProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKodeProdi.Location = New System.Drawing.Point(173, 3)
        Me.txtKodeProdi.Name = "txtKodeProdi"
        Me.txtKodeProdi.Size = New System.Drawing.Size(238, 25)
        Me.txtKodeProdi.TabIndex = 4
        '
        'txtNamaProdi
        '
        Me.txtNamaProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNamaProdi.Location = New System.Drawing.Point(173, 34)
        Me.txtNamaProdi.Multiline = True
        Me.txtNamaProdi.Name = "txtNamaProdi"
        Me.txtNamaProdi.Size = New System.Drawing.Size(238, 45)
        Me.txtNamaProdi.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(153, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 51)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNamaProdi
        '
        Me.lblNamaProdi.AutoSize = True
        Me.lblNamaProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaProdi.Location = New System.Drawing.Point(3, 31)
        Me.lblNamaProdi.Name = "lblNamaProdi"
        Me.lblNamaProdi.Size = New System.Drawing.Size(144, 51)
        Me.lblNamaProdi.TabIndex = 2
        Me.lblNamaProdi.Text = "Nama Program Studi"
        Me.lblNamaProdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmInputProdi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(414, 210)
        Me.Name = "FrmInputProdi"
        Me.pnlMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblKodeProdi As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtKodeProdi As TextBox
    Friend WithEvents txtNamaProdi As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNamaProdi As Label
End Class
