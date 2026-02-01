<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCetakLaporanDataDosenPengampu
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
        Me.BtnCetakDataMatkul = New System.Windows.Forms.Button()
        Me.CbNamaJurusanCetakDosen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CbSemesterCetakMatkul = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnKeluarCetakMatkul = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCetakDataMatkul
        '
        Me.BtnCetakDataMatkul.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCetakDataMatkul.Location = New System.Drawing.Point(713, 52)
        Me.BtnCetakDataMatkul.Name = "BtnCetakDataMatkul"
        Me.BtnCetakDataMatkul.Size = New System.Drawing.Size(233, 31)
        Me.BtnCetakDataMatkul.TabIndex = 2
        Me.BtnCetakDataMatkul.Text = "CETAK DATA MATAKULIAH"
        Me.BtnCetakDataMatkul.UseVisualStyleBackColor = True
        '
        'CbNamaJurusanCetakDosen
        '
        Me.CbNamaJurusanCetakDosen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbNamaJurusanCetakDosen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbNamaJurusanCetakDosen.FormattingEnabled = True
        Me.CbNamaJurusanCetakDosen.Location = New System.Drawing.Point(87, 58)
        Me.CbNamaJurusanCetakDosen.Name = "CbNamaJurusanCetakDosen"
        Me.CbNamaJurusanCetakDosen.Size = New System.Drawing.Size(305, 21)
        Me.CbNamaJurusanCetakDosen.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(84, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nama Jurusan"
        '
        'Panel3
        '
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.Firebrick
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1116, 115)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.Controls.Add(Me.CbSemesterCetakMatkul)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.BtnKeluarCetakMatkul)
        Me.Panel4.Controls.Add(Me.BtnCetakDataMatkul)
        Me.Panel4.Controls.Add(Me.CbNamaJurusanCetakDosen)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1116, 115)
        Me.Panel4.TabIndex = 3
        '
        'CbSemesterCetakMatkul
        '
        Me.CbSemesterCetakMatkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbSemesterCetakMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbSemesterCetakMatkul.FormattingEnabled = True
        Me.CbSemesterCetakMatkul.Location = New System.Drawing.Point(442, 58)
        Me.CbSemesterCetakMatkul.Name = "CbSemesterCetakMatkul"
        Me.CbSemesterCetakMatkul.Size = New System.Drawing.Size(102, 21)
        Me.CbSemesterCetakMatkul.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(441, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Semester"
        '
        'BtnKeluarCetakMatkul
        '
        Me.BtnKeluarCetakMatkul.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKeluarCetakMatkul.Location = New System.Drawing.Point(960, 52)
        Me.BtnKeluarCetakMatkul.Name = "BtnKeluarCetakMatkul"
        Me.BtnKeluarCetakMatkul.Size = New System.Drawing.Size(142, 31)
        Me.BtnKeluarCetakMatkul.TabIndex = 3
        Me.BtnKeluarCetakMatkul.Text = "KELUAR"
        Me.BtnKeluarCetakMatkul.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.Firebrick
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1116, 115)
        Me.Panel2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1116, 115)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1116, 71)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = ":: CETAK LAPORAN MATAKULIAH ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 186)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1116, 264)
        Me.CrystalReportViewer1.TabIndex = 9
        '
        'FrmCetakLaporanDataDosenPengampu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 450)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmCetakLaporanDataDosenPengampu"
        Me.Text = "FrmCetakLaporanDataDosenPengampu"
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnCetakDataMatkul As Button
    Friend WithEvents CbNamaJurusanCetakDosen As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CbSemesterCetakMatkul As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnKeluarCetakMatkul As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
