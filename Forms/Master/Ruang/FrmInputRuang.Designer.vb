<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputRuang
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
        Me.lblIdRuangan = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdRuangan = New System.Windows.Forms.TextBox()
        Me.txtNamaRuangan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNamaRuangan = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblKapasitas = New System.Windows.Forms.Label()
        Me.nudKapasitas = New System.Windows.Forms.NumericUpDown()
        Me.pnlMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudKapasitas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(409, 59)
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain.Size = New System.Drawing.Size(409, 147)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdRuangan, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIdRuangan, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNamaRuangan, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNamaRuangan, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKapasitas, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.nudKapasitas, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(409, 147)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblIdRuangan
        '
        Me.lblIdRuangan.AutoSize = True
        Me.lblIdRuangan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdRuangan.Location = New System.Drawing.Point(3, 0)
        Me.lblIdRuangan.Name = "lblIdRuangan"
        Me.lblIdRuangan.Size = New System.Drawing.Size(144, 31)
        Me.lblIdRuangan.TabIndex = 0
        Me.lblIdRuangan.Text = "Kode Ruangan"
        Me.lblIdRuangan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'txtIdRuangan
        '
        Me.txtIdRuangan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdRuangan.Location = New System.Drawing.Point(173, 3)
        Me.txtIdRuangan.Name = "txtIdRuangan"
        Me.txtIdRuangan.Size = New System.Drawing.Size(233, 25)
        Me.txtIdRuangan.TabIndex = 4
        '
        'txtNamaRuangan
        '
        Me.txtNamaRuangan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNamaRuangan.Location = New System.Drawing.Point(173, 34)
        Me.txtNamaRuangan.Multiline = True
        Me.txtNamaRuangan.Name = "txtNamaRuangan"
        Me.txtNamaRuangan.Size = New System.Drawing.Size(233, 36)
        Me.txtNamaRuangan.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(153, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 42)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNamaRuangan
        '
        Me.lblNamaRuangan.AutoSize = True
        Me.lblNamaRuangan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaRuangan.Location = New System.Drawing.Point(3, 31)
        Me.lblNamaRuangan.Name = "lblNamaRuangan"
        Me.lblNamaRuangan.Size = New System.Drawing.Size(144, 42)
        Me.lblNamaRuangan.TabIndex = 2
        Me.lblNamaRuangan.Text = "Nama Ruangan"
        Me.lblNamaRuangan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(153, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 31)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKapasitas
        '
        Me.lblKapasitas.AutoSize = True
        Me.lblKapasitas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKapasitas.Location = New System.Drawing.Point(3, 73)
        Me.lblKapasitas.Name = "lblKapasitas"
        Me.lblKapasitas.Size = New System.Drawing.Size(144, 31)
        Me.lblKapasitas.TabIndex = 6
        Me.lblKapasitas.Text = "Kapasitas"
        Me.lblKapasitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudKapasitas
        '
        Me.nudKapasitas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudKapasitas.Location = New System.Drawing.Point(173, 76)
        Me.nudKapasitas.Name = "nudKapasitas"
        Me.nudKapasitas.Size = New System.Drawing.Size(233, 25)
        Me.nudKapasitas.TabIndex = 8
        '
        'FrmInputRuang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(409, 242)
        Me.Name = "FrmInputRuang"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.nudKapasitas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblIdRuangan As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIdRuangan As TextBox
    Friend WithEvents txtNamaRuangan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNamaRuangan As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblKapasitas As Label
    Friend WithEvents nudKapasitas As NumericUpDown
End Class
