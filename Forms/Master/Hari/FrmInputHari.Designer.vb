<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInputHari
    Inherits APK_Penjadwalan_Matakuliah_TRPL_OOP.FrmBaseInput

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblKodeHari = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKodeHari = New System.Windows.Forms.TextBox()
        Me.txtNamaHari = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNamaHari = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(404, 59)
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain.Size = New System.Drawing.Size(404, 100)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblKodeHari, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKodeHari, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNamaHari, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNamaHari, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(404, 100)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lblKodeHari
        '
        Me.lblKodeHari.AutoSize = True
        Me.lblKodeHari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKodeHari.Location = New System.Drawing.Point(3, 0)
        Me.lblKodeHari.Name = "lblKodeHari"
        Me.lblKodeHari.Size = New System.Drawing.Size(144, 31)
        Me.lblKodeHari.TabIndex = 0
        Me.lblKodeHari.Text = "Kode Hari"
        Me.lblKodeHari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'txtKodeHari
        '
        Me.txtKodeHari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKodeHari.Location = New System.Drawing.Point(173, 3)
        Me.txtKodeHari.Name = "txtKodeHari"
        Me.txtKodeHari.Size = New System.Drawing.Size(228, 25)
        Me.txtKodeHari.TabIndex = 4
        '
        'txtNamaHari
        '
        Me.txtNamaHari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNamaHari.Location = New System.Drawing.Point(173, 34)
        Me.txtNamaHari.Name = "txtNamaHari"
        Me.txtNamaHari.Size = New System.Drawing.Size(228, 25)
        Me.txtNamaHari.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(153, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNamaHari
        '
        Me.lblNamaHari.AutoSize = True
        Me.lblNamaHari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaHari.Location = New System.Drawing.Point(3, 31)
        Me.lblNamaHari.Name = "lblNamaHari"
        Me.lblNamaHari.Size = New System.Drawing.Size(144, 31)
        Me.lblNamaHari.TabIndex = 2
        Me.lblNamaHari.Text = "Nama Hari"
        Me.lblNamaHari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmInputHari
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(404, 195)
        Me.Name = "FrmInputHari"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblKodeHari As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtKodeHari As TextBox
    Friend WithEvents txtNamaHari As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNamaHari As Label
End Class
