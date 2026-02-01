<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCetakLaporanDataMataKuliah
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
        Me.CbTa = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbSemester = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbProdi = New System.Windows.Forms.ComboBox()
        Me.txtTahunAkademik = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNamaDosen = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNidnDosen = New System.Windows.Forms.TextBox()
        Me.txtKdDosen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnCetakTA = New System.Windows.Forms.Button()
        Me.BtnBatal = New System.Windows.Forms.Button()
        Me.BtnCetak = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbTa
        '
        Me.CbTa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbTa.FormattingEnabled = True
        Me.CbTa.Location = New System.Drawing.Point(444, 56)
        Me.CbTa.Name = "CbTa"
        Me.CbTa.Size = New System.Drawing.Size(135, 21)
        Me.CbTa.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(319, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tahun Akademik"
        '
        'CbSemester
        '
        Me.CbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbSemester.FormattingEnabled = True
        Me.CbSemester.Location = New System.Drawing.Point(153, 54)
        Me.CbSemester.Name = "CbSemester"
        Me.CbSemester.Size = New System.Drawing.Size(160, 21)
        Me.CbSemester.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama Semester"
        '
        'CbProdi
        '
        Me.CbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbProdi.FormattingEnabled = True
        Me.CbProdi.Location = New System.Drawing.Point(153, 19)
        Me.CbProdi.Name = "CbProdi"
        Me.CbProdi.Size = New System.Drawing.Size(280, 21)
        Me.CbProdi.TabIndex = 1
        '
        'txtTahunAkademik
        '
        Me.txtTahunAkademik.Location = New System.Drawing.Point(153, 127)
        Me.txtTahunAkademik.Name = "txtTahunAkademik"
        Me.txtTahunAkademik.Size = New System.Drawing.Size(121, 20)
        Me.txtTahunAkademik.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Tahun Akademik"
        '
        'txtNamaDosen
        '
        Me.txtNamaDosen.Location = New System.Drawing.Point(153, 93)
        Me.txtNamaDosen.Name = "txtNamaDosen"
        Me.txtNamaDosen.Size = New System.Drawing.Size(221, 20)
        Me.txtNamaDosen.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Nama Dosen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbTa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CbSemester)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CbProdi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(38, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(948, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nama Jurusan"
        '
        'txtNidnDosen
        '
        Me.txtNidnDosen.Location = New System.Drawing.Point(153, 60)
        Me.txtNidnDosen.Name = "txtNidnDosen"
        Me.txtNidnDosen.Size = New System.Drawing.Size(121, 20)
        Me.txtNidnDosen.TabIndex = 8
        '
        'txtKdDosen
        '
        Me.txtKdDosen.Location = New System.Drawing.Point(153, 26)
        Me.txtKdDosen.Name = "txtKdDosen"
        Me.txtKdDosen.Size = New System.Drawing.Size(121, 20)
        Me.txtKdDosen.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Kode Dosen"
        '
        'BtnCetakTA
        '
        Me.BtnCetakTA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCetakTA.Location = New System.Drawing.Point(645, 243)
        Me.BtnCetakTA.Name = "BtnCetakTA"
        Me.BtnCetakTA.Size = New System.Drawing.Size(144, 42)
        Me.BtnCetakTA.TabIndex = 4
        Me.BtnCetakTA.Text = "CETAK DATA TAHUN AKADEMIK"
        Me.BtnCetakTA.UseVisualStyleBackColor = True
        '
        'BtnBatal
        '
        Me.BtnBatal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBatal.Location = New System.Drawing.Point(817, 244)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(123, 42)
        Me.BtnBatal.TabIndex = 3
        Me.BtnBatal.Text = "BATAL"
        Me.BtnBatal.UseVisualStyleBackColor = True
        '
        'BtnCetak
        '
        Me.BtnCetak.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCetak.Location = New System.Drawing.Point(494, 243)
        Me.BtnCetak.Name = "BtnCetak"
        Me.BtnCetak.Size = New System.Drawing.Size(123, 42)
        Me.BtnCetak.TabIndex = 2
        Me.BtnCetak.Text = "CETAK DOSEN PENGAMPU"
        Me.BtnCetak.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTahunAkademik)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtNamaDosen)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtNidnDosen)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtKdDosen)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(38, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 161)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter Data"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "NIDN Dosen"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.BtnCetakTA)
        Me.Panel1.Controls.Add(Me.BtnBatal)
        Me.Panel1.Controls.Add(Me.BtnCetak)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(985, 300)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(985, 53)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = ":: CETAK DATA DOSEN PENGAMPU ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 353)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(985, 300)
        Me.CrystalReportViewer1.TabIndex = 4
        '
        'FrmCetakLaporanDataMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 653)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmCetakLaporanDataMataKuliah"
        Me.Text = "FrmCetakLaporanDataMataKuliah"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CbTa As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CbSemester As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CbProdi As ComboBox
    Friend WithEvents txtTahunAkademik As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNamaDosen As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNidnDosen As TextBox
    Friend WithEvents txtKdDosen As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnCetakTA As Button
    Friend WithEvents BtnBatal As Button
    Friend WithEvents BtnCetak As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
