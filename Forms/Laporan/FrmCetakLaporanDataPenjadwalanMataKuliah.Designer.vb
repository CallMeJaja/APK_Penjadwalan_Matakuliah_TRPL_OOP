<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCetakLaporanDataPenjadwalanMataKuliah
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbTahunAkademik = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.cmbJenisKelas = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNamaSemester = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProdi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.cmbTahunAkademik)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnCetak)
        Me.Panel1.Controls.Add(Me.cmbJenisKelas)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbNamaSemester)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbProdi)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1029, 90)
        Me.Panel1.TabIndex = 3
        '
        'cmbTahunAkademik
        '
        Me.cmbTahunAkademik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTahunAkademik.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTahunAkademik.FormattingEnabled = True
        Me.cmbTahunAkademik.Location = New System.Drawing.Point(559, 10)
        Me.cmbTahunAkademik.Name = "cmbTahunAkademik"
        Me.cmbTahunAkademik.Size = New System.Drawing.Size(183, 21)
        Me.cmbTahunAkademik.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(448, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Tahun Akademik"
        '
        'btnCetak
        '
        Me.btnCetak.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCetak.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCetak.Location = New System.Drawing.Point(809, 33)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(210, 36)
        Me.btnCetak.TabIndex = 9
        Me.btnCetak.Text = "CETAK LAPORAN"
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'cmbJenisKelas
        '
        Me.cmbJenisKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJenisKelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbJenisKelas.FormattingEnabled = True
        Me.cmbJenisKelas.Location = New System.Drawing.Point(559, 50)
        Me.cmbJenisKelas.Name = "cmbJenisKelas"
        Me.cmbJenisKelas.Size = New System.Drawing.Size(183, 21)
        Me.cmbJenisKelas.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(448, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Jenis Kelas"
        '
        'cmbNamaSemester
        '
        Me.cmbNamaSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNamaSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbNamaSemester.FormattingEnabled = True
        Me.cmbNamaSemester.Location = New System.Drawing.Point(154, 50)
        Me.cmbNamaSemester.Name = "cmbNamaSemester"
        Me.cmbNamaSemester.Size = New System.Drawing.Size(268, 21)
        Me.cmbNamaSemester.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(49, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nama Semester"
        '
        'cmbProdi
        '
        Me.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProdi.FormattingEnabled = True
        Me.cmbProdi.Location = New System.Drawing.Point(154, 10)
        Me.cmbProdi.Name = "cmbProdi"
        Me.cmbProdi.Size = New System.Drawing.Size(268, 21)
        Me.cmbProdi.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(49, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nama Prodi"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1029, 65)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CETAK LAPORAN DATA PENJADWALAN MATAKULIAH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 155)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1029, 430)
        Me.CrystalReportViewer1.TabIndex = 4
        '
        'FrmCetakLaporanDataPenjadwalanMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 585)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmCetakLaporanDataPenjadwalanMataKuliah"
        Me.Text = "FrmCetakLaporanDataPenjadwalanMataKuliah"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbTahunAkademik As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCetak As Button
    Friend WithEvents cmbJenisKelas As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbNamaSemester As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProdi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
