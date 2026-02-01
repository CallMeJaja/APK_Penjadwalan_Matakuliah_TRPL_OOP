<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputMataKuliah
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
        Me.tlpInput = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTotalSks = New System.Windows.Forms.TableLayoutPanel()
        Me.nudTotalSks = New System.Windows.Forms.NumericUpDown()
        Me.txtTotalMenit = New System.Windows.Forms.TextBox()
        Me.tlpSksPraktek = New System.Windows.Forms.TableLayoutPanel()
        Me.nudSksPraktek = New System.Windows.Forms.NumericUpDown()
        Me.txtMenitPraktek = New System.Windows.Forms.TextBox()
        Me.txtNamaMataKuliah = New System.Windows.Forms.TextBox()
        Me.lblNamaMataKuliah = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblKodeMataKuliah = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtKodeMataKuliah = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipeSemester = New System.Windows.Forms.Label()
        Me.lblSksPraktek = New System.Windows.Forms.Label()
        Me.lblSksTeori = New System.Windows.Forms.Label()
        Me.lblProdi = New System.Windows.Forms.Label()
        Me.cmbTipeSemester = New System.Windows.Forms.ComboBox()
        Me.cmbProdi = New System.Windows.Forms.ComboBox()
        Me.tlpSksTeori = New System.Windows.Forms.TableLayoutPanel()
        Me.nudSksTeori = New System.Windows.Forms.NumericUpDown()
        Me.txtMenitTeori = New System.Windows.Forms.TextBox()
        Me.lblTotalSks = New System.Windows.Forms.Label()
        Me.lblSemester = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSemester = New System.Windows.Forms.ComboBox()
        Me.pnlMain.SuspendLayout()
        Me.tlpInput.SuspendLayout()
        Me.tlpTotalSks.SuspendLayout()
        CType(Me.nudTotalSks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSksPraktek.SuspendLayout()
        CType(Me.nudSksPraktek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSksTeori.SuspendLayout()
        CType(Me.nudSksTeori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(467, 59)
        Me.lblJudul.Text = "FORM TAMBAH DATA"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.tlpInput)
        Me.pnlMain.Size = New System.Drawing.Size(467, 354)
        '
        'tlpInput
        '
        Me.tlpInput.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpInput.ColumnCount = 3
        Me.tlpInput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpInput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpInput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpInput.Controls.Add(Me.tlpTotalSks, 2, 6)
        Me.tlpInput.Controls.Add(Me.tlpSksPraktek, 2, 5)
        Me.tlpInput.Controls.Add(Me.txtNamaMataKuliah, 2, 1)
        Me.tlpInput.Controls.Add(Me.lblNamaMataKuliah, 0, 1)
        Me.tlpInput.Controls.Add(Me.Label8, 1, 2)
        Me.tlpInput.Controls.Add(Me.Label5, 1, 1)
        Me.tlpInput.Controls.Add(Me.lblKodeMataKuliah, 0, 0)
        Me.tlpInput.Controls.Add(Me.Label2, 1, 0)
        Me.tlpInput.Controls.Add(Me.Label9, 1, 3)
        Me.tlpInput.Controls.Add(Me.Label6, 1, 4)
        Me.tlpInput.Controls.Add(Me.Label10, 1, 5)
        Me.tlpInput.Controls.Add(Me.txtKodeMataKuliah, 2, 0)
        Me.tlpInput.Controls.Add(Me.Label7, 1, 6)
        Me.tlpInput.Controls.Add(Me.lblTipeSemester, 0, 2)
        Me.tlpInput.Controls.Add(Me.lblSksPraktek, 0, 5)
        Me.tlpInput.Controls.Add(Me.lblSksTeori, 0, 4)
        Me.tlpInput.Controls.Add(Me.lblProdi, 0, 3)
        Me.tlpInput.Controls.Add(Me.cmbTipeSemester, 2, 2)
        Me.tlpInput.Controls.Add(Me.cmbProdi, 2, 3)
        Me.tlpInput.Controls.Add(Me.tlpSksTeori, 2, 4)
        Me.tlpInput.Controls.Add(Me.lblTotalSks, 0, 6)
        Me.tlpInput.Controls.Add(Me.lblSemester, 0, 7)
        Me.tlpInput.Controls.Add(Me.Label4, 1, 7)
        Me.tlpInput.Controls.Add(Me.cmbSemester, 2, 7)
        Me.tlpInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpInput.Location = New System.Drawing.Point(0, 0)
        Me.tlpInput.Name = "tlpInput"
        Me.tlpInput.RowCount = 9
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInput.Size = New System.Drawing.Size(467, 354)
        Me.tlpInput.TabIndex = 1
        '
        'tlpTotalSks
        '
        Me.tlpTotalSks.AutoSize = True
        Me.tlpTotalSks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTotalSks.ColumnCount = 2
        Me.tlpTotalSks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTotalSks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTotalSks.Controls.Add(Me.nudTotalSks, 0, 0)
        Me.tlpTotalSks.Controls.Add(Me.txtTotalMenit, 1, 0)
        Me.tlpTotalSks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTotalSks.Location = New System.Drawing.Point(176, 239)
        Me.tlpTotalSks.Name = "tlpTotalSks"
        Me.tlpTotalSks.RowCount = 1
        Me.tlpTotalSks.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTotalSks.Size = New System.Drawing.Size(287, 31)
        Me.tlpTotalSks.TabIndex = 32
        '
        'nudTotalSks
        '
        Me.nudTotalSks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudTotalSks.Location = New System.Drawing.Point(3, 3)
        Me.nudTotalSks.Name = "nudTotalSks"
        Me.nudTotalSks.Size = New System.Drawing.Size(137, 25)
        Me.nudTotalSks.TabIndex = 3
        '
        'txtTotalMenit
        '
        Me.txtTotalMenit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotalMenit.Location = New System.Drawing.Point(146, 3)
        Me.txtTotalMenit.Name = "txtTotalMenit"
        Me.txtTotalMenit.Size = New System.Drawing.Size(138, 25)
        Me.txtTotalMenit.TabIndex = 0
        '
        'tlpSksPraktek
        '
        Me.tlpSksPraktek.AutoSize = True
        Me.tlpSksPraktek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSksPraktek.ColumnCount = 2
        Me.tlpSksPraktek.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSksPraktek.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSksPraktek.Controls.Add(Me.nudSksPraktek, 0, 0)
        Me.tlpSksPraktek.Controls.Add(Me.txtMenitPraktek, 1, 0)
        Me.tlpSksPraktek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSksPraktek.Location = New System.Drawing.Point(176, 201)
        Me.tlpSksPraktek.Name = "tlpSksPraktek"
        Me.tlpSksPraktek.RowCount = 1
        Me.tlpSksPraktek.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSksPraktek.Size = New System.Drawing.Size(287, 31)
        Me.tlpSksPraktek.TabIndex = 31
        '
        'nudSksPraktek
        '
        Me.nudSksPraktek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudSksPraktek.Location = New System.Drawing.Point(3, 3)
        Me.nudSksPraktek.Name = "nudSksPraktek"
        Me.nudSksPraktek.Size = New System.Drawing.Size(137, 25)
        Me.nudSksPraktek.TabIndex = 2
        '
        'txtMenitPraktek
        '
        Me.txtMenitPraktek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMenitPraktek.Location = New System.Drawing.Point(146, 3)
        Me.txtMenitPraktek.Name = "txtMenitPraktek"
        Me.txtMenitPraktek.Size = New System.Drawing.Size(138, 25)
        Me.txtMenitPraktek.TabIndex = 0
        '
        'txtNamaMataKuliah
        '
        Me.txtNamaMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNamaMataKuliah.Location = New System.Drawing.Point(176, 36)
        Me.txtNamaMataKuliah.Multiline = True
        Me.txtNamaMataKuliah.Name = "txtNamaMataKuliah"
        Me.txtNamaMataKuliah.Size = New System.Drawing.Size(287, 56)
        Me.txtNamaMataKuliah.TabIndex = 21
        '
        'lblNamaMataKuliah
        '
        Me.lblNamaMataKuliah.AutoSize = True
        Me.lblNamaMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaMataKuliah.Location = New System.Drawing.Point(4, 33)
        Me.lblNamaMataKuliah.Name = "lblNamaMataKuliah"
        Me.lblNamaMataKuliah.Size = New System.Drawing.Size(144, 62)
        Me.lblNamaMataKuliah.TabIndex = 11
        Me.lblNamaMataKuliah.Text = "Nama Mata Kuliah"
        Me.lblNamaMataKuliah.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(155, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 31)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = ":"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(155, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 62)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKodeMataKuliah
        '
        Me.lblKodeMataKuliah.AutoSize = True
        Me.lblKodeMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKodeMataKuliah.Location = New System.Drawing.Point(4, 1)
        Me.lblKodeMataKuliah.Name = "lblKodeMataKuliah"
        Me.lblKodeMataKuliah.Size = New System.Drawing.Size(144, 31)
        Me.lblKodeMataKuliah.TabIndex = 0
        Me.lblKodeMataKuliah.Text = "Kode Mata Kuliah"
        Me.lblKodeMataKuliah.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(155, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(155, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 31)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = ":"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(155, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 37)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(155, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 37)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = ":"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKodeMataKuliah
        '
        Me.txtKodeMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKodeMataKuliah.Location = New System.Drawing.Point(176, 4)
        Me.txtKodeMataKuliah.Name = "txtKodeMataKuliah"
        Me.txtKodeMataKuliah.Size = New System.Drawing.Size(287, 25)
        Me.txtKodeMataKuliah.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(155, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 37)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = ":"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTipeSemester
        '
        Me.lblTipeSemester.AutoSize = True
        Me.lblTipeSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTipeSemester.Location = New System.Drawing.Point(4, 96)
        Me.lblTipeSemester.Name = "lblTipeSemester"
        Me.lblTipeSemester.Size = New System.Drawing.Size(144, 31)
        Me.lblTipeSemester.TabIndex = 26
        Me.lblTipeSemester.Text = "Tipe Semester"
        Me.lblTipeSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSksPraktek
        '
        Me.lblSksPraktek.AutoSize = True
        Me.lblSksPraktek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSksPraktek.Location = New System.Drawing.Point(4, 198)
        Me.lblSksPraktek.Name = "lblSksPraktek"
        Me.lblSksPraktek.Size = New System.Drawing.Size(144, 37)
        Me.lblSksPraktek.TabIndex = 23
        Me.lblSksPraktek.Text = "SKS Praktek - Menit"
        Me.lblSksPraktek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSksTeori
        '
        Me.lblSksTeori.AutoSize = True
        Me.lblSksTeori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSksTeori.Location = New System.Drawing.Point(4, 160)
        Me.lblSksTeori.Name = "lblSksTeori"
        Me.lblSksTeori.Size = New System.Drawing.Size(144, 37)
        Me.lblSksTeori.TabIndex = 13
        Me.lblSksTeori.Text = "SKS Teori - Menit"
        Me.lblSksTeori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProdi
        '
        Me.lblProdi.AutoSize = True
        Me.lblProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProdi.Location = New System.Drawing.Point(4, 128)
        Me.lblProdi.Name = "lblProdi"
        Me.lblProdi.Size = New System.Drawing.Size(144, 31)
        Me.lblProdi.TabIndex = 27
        Me.lblProdi.Text = "Program Studi"
        Me.lblProdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipeSemester
        '
        Me.cmbTipeSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbTipeSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipeSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipeSemester.FormattingEnabled = True
        Me.cmbTipeSemester.Location = New System.Drawing.Point(176, 99)
        Me.cmbTipeSemester.Name = "cmbTipeSemester"
        Me.cmbTipeSemester.Size = New System.Drawing.Size(287, 25)
        Me.cmbTipeSemester.TabIndex = 28
        '
        'cmbProdi
        '
        Me.cmbProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProdi.FormattingEnabled = True
        Me.cmbProdi.Location = New System.Drawing.Point(176, 131)
        Me.cmbProdi.Name = "cmbProdi"
        Me.cmbProdi.Size = New System.Drawing.Size(287, 25)
        Me.cmbProdi.TabIndex = 29
        '
        'tlpSksTeori
        '
        Me.tlpSksTeori.AutoSize = True
        Me.tlpSksTeori.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSksTeori.ColumnCount = 2
        Me.tlpSksTeori.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSksTeori.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSksTeori.Controls.Add(Me.nudSksTeori, 0, 0)
        Me.tlpSksTeori.Controls.Add(Me.txtMenitTeori, 1, 0)
        Me.tlpSksTeori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSksTeori.Location = New System.Drawing.Point(176, 163)
        Me.tlpSksTeori.Name = "tlpSksTeori"
        Me.tlpSksTeori.RowCount = 1
        Me.tlpSksTeori.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSksTeori.Size = New System.Drawing.Size(287, 31)
        Me.tlpSksTeori.TabIndex = 30
        '
        'nudSksTeori
        '
        Me.nudSksTeori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudSksTeori.Location = New System.Drawing.Point(3, 3)
        Me.nudSksTeori.Name = "nudSksTeori"
        Me.nudSksTeori.Size = New System.Drawing.Size(137, 25)
        Me.nudSksTeori.TabIndex = 0
        '
        'txtMenitTeori
        '
        Me.txtMenitTeori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMenitTeori.Location = New System.Drawing.Point(146, 3)
        Me.txtMenitTeori.Name = "txtMenitTeori"
        Me.txtMenitTeori.Size = New System.Drawing.Size(138, 25)
        Me.txtMenitTeori.TabIndex = 1
        '
        'lblTotalSks
        '
        Me.lblTotalSks.AutoSize = True
        Me.lblTotalSks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalSks.Location = New System.Drawing.Point(4, 236)
        Me.lblTotalSks.Name = "lblTotalSks"
        Me.lblTotalSks.Size = New System.Drawing.Size(144, 37)
        Me.lblTotalSks.TabIndex = 15
        Me.lblTotalSks.Text = "Total SKS - Menit"
        Me.lblTotalSks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSemester
        '
        Me.lblSemester.AutoSize = True
        Me.lblSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSemester.Location = New System.Drawing.Point(4, 274)
        Me.lblSemester.Name = "lblSemester"
        Me.lblSemester.Size = New System.Drawing.Size(144, 37)
        Me.lblSemester.TabIndex = 19
        Me.lblSemester.Text = "Semester"
        Me.lblSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(155, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 37)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSemester
        '
        Me.cmbSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSemester.FormattingEnabled = True
        Me.cmbSemester.Location = New System.Drawing.Point(176, 277)
        Me.cmbSemester.Name = "cmbSemester"
        Me.cmbSemester.Size = New System.Drawing.Size(287, 25)
        Me.cmbSemester.TabIndex = 33
        '
        'FrmInputMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(467, 449)
        Me.Name = "FrmInputMataKuliah"
        Me.Text = "TAMBAH Data"
        Me.pnlMain.ResumeLayout(False)
        Me.tlpInput.ResumeLayout(False)
        Me.tlpInput.PerformLayout()
        Me.tlpTotalSks.ResumeLayout(False)
        Me.tlpTotalSks.PerformLayout()
        CType(Me.nudTotalSks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSksPraktek.ResumeLayout(False)
        Me.tlpSksPraktek.PerformLayout()
        CType(Me.nudSksPraktek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSksTeori.ResumeLayout(False)
        Me.tlpSksTeori.PerformLayout()
        CType(Me.nudSksTeori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlpInput As TableLayoutPanel
    Friend WithEvents txtNamaMataKuliah As TextBox
    Friend WithEvents lblSksTeori As Label
    Friend WithEvents lblNamaMataKuliah As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblKodeMataKuliah As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtKodeMataKuliah As TextBox
    Friend WithEvents lblSemester As Label
    Friend WithEvents lblTotalSks As Label
    Friend WithEvents lblSksPraktek As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tlpTotalSks As TableLayoutPanel
    Friend WithEvents nudTotalSks As NumericUpDown
    Friend WithEvents txtTotalMenit As TextBox
    Friend WithEvents tlpSksPraktek As TableLayoutPanel
    Friend WithEvents nudSksPraktek As NumericUpDown
    Friend WithEvents txtMenitPraktek As TextBox
    Friend WithEvents lblTipeSemester As Label
    Friend WithEvents lblProdi As Label
    Friend WithEvents cmbTipeSemester As ComboBox
    Friend WithEvents cmbProdi As ComboBox
    Friend WithEvents cmbSemester As ComboBox
    Friend WithEvents tlpSksTeori As TableLayoutPanel
    Friend WithEvents nudSksTeori As NumericUpDown
    Friend WithEvents txtMenitTeori As TextBox
    Friend WithEvents Label4 As Label
End Class
