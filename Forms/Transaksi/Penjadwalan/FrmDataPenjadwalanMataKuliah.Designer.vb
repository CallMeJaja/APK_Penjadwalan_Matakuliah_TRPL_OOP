<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataPenjadwalanMataKuliah
    Inherits APK_Penjadwalan_Matakuliah_TRPL_OOP.FrmBaseData

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
        Me.flpFilterSpesifik = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFilterProdi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFilterTipeSemester = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFilterSemester = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFilterTahun = New System.Windows.Forms.ComboBox()
        Me.flpFilterSpesifik.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(1405, 65)
        '
        'pnlFilter
        '
        Me.pnlFilter.Size = New System.Drawing.Size(1405, 42)
        '
        'flpFilterSpesifik
        '
        Me.flpFilterSpesifik.AutoSize = True
        Me.flpFilterSpesifik.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFilterSpesifik.Controls.Add(Me.Label1)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterProdi)
        Me.flpFilterSpesifik.Controls.Add(Me.Label2)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterTipeSemester)
        Me.flpFilterSpesifik.Controls.Add(Me.Label3)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterSemester)
        Me.flpFilterSpesifik.Controls.Add(Me.Label4)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterTahun)
        Me.flpFilterSpesifik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFilterSpesifik.Location = New System.Drawing.Point(0, 0)
        Me.flpFilterSpesifik.Name = "flpFilterSpesifik"
        Me.flpFilterSpesifik.Size = New System.Drawing.Size(917, 36)
        Me.flpFilterSpesifik.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Program Studi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterProdi
        '
        Me.cmbFilterProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterProdi.FormattingEnabled = True
        Me.cmbFilterProdi.Location = New System.Drawing.Point(105, 3)
        Me.cmbFilterProdi.Name = "cmbFilterProdi"
        Me.cmbFilterProdi.Size = New System.Drawing.Size(121, 25)
        Me.cmbFilterProdi.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(232, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 31)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tipe Semester"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterTipeSemester
        '
        Me.cmbFilterTipeSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterTipeSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterTipeSemester.FormattingEnabled = True
        Me.cmbFilterTipeSemester.Location = New System.Drawing.Point(331, 3)
        Me.cmbFilterTipeSemester.Name = "cmbFilterTipeSemester"
        Me.cmbFilterTipeSemester.Size = New System.Drawing.Size(136, 25)
        Me.cmbFilterTipeSemester.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(473, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 31)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Semester"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterSemester
        '
        Me.cmbFilterSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSemester.FormattingEnabled = True
        Me.cmbFilterSemester.Location = New System.Drawing.Point(543, 3)
        Me.cmbFilterSemester.Name = "cmbFilterSemester"
        Me.cmbFilterSemester.Size = New System.Drawing.Size(136, 25)
        Me.cmbFilterSemester.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(685, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 31)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tahun Akademik"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterTahun
        '
        Me.cmbFilterTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterTahun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterTahun.FormattingEnabled = True
        Me.cmbFilterTahun.Location = New System.Drawing.Point(3, 34)
        Me.cmbFilterTahun.Name = "cmbFilterTahun"
        Me.cmbFilterTahun.Size = New System.Drawing.Size(136, 25)
        Me.cmbFilterTahun.TabIndex = 9
        '
        'FrmDataPenjadwalanMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1405, 615)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "FrmDataPenjadwalanMataKuliah"
        Me.flpFilterSpesifik.ResumeLayout(False)
        Me.flpFilterSpesifik.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpFilterSpesifik As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFilterProdi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFilterTipeSemester As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbFilterSemester As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbFilterTahun As ComboBox
End Class

