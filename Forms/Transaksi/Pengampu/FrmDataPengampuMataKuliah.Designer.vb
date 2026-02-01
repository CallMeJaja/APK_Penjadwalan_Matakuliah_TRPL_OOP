<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataPengampuMataKuliah
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
        Me.lblProdi = New System.Windows.Forms.Label()
        Me.cmbFilterProdi = New System.Windows.Forms.ComboBox()
        Me.lblTipeSemester = New System.Windows.Forms.Label()
        Me.cmbFilterTipeSemester = New System.Windows.Forms.ComboBox()
        Me.lblSemester = New System.Windows.Forms.Label()
        Me.cmbFilterSemester = New System.Windows.Forms.ComboBox()
        Me.flpFilterSpesifik.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Size = New System.Drawing.Size(1200, 65)
        '
        'pnlFilter
        '
        Me.pnlFilter.Size = New System.Drawing.Size(1200, 42)
        '
        'pnlFilterSpesifik
        '
        Me.pnlFilterSpesifik.Controls.Add(Me.flpFilterSpesifik)
        '
        'flpFilterSpesifik
        '
        Me.flpFilterSpesifik.AutoSize = True
        Me.flpFilterSpesifik.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFilterSpesifik.Controls.Add(Me.lblProdi)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterProdi)
        Me.flpFilterSpesifik.Controls.Add(Me.lblTipeSemester)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterTipeSemester)
        Me.flpFilterSpesifik.Controls.Add(Me.lblSemester)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterSemester)
        Me.flpFilterSpesifik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFilterSpesifik.Location = New System.Drawing.Point(0, 0)
        Me.flpFilterSpesifik.Name = "flpFilterSpesifik"
        Me.flpFilterSpesifik.Size = New System.Drawing.Size(712, 36)
        Me.flpFilterSpesifik.TabIndex = 1
        Me.flpFilterSpesifik.WrapContents = False
        '
        'lblProdi
        '
        Me.lblProdi.AutoSize = True
        Me.lblProdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProdi.Location = New System.Drawing.Point(3, 0)
        Me.lblProdi.Name = "lblProdi"
        Me.lblProdi.Size = New System.Drawing.Size(96, 31)
        Me.lblProdi.TabIndex = 3
        Me.lblProdi.Text = "Program Studi"
        Me.lblProdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblTipeSemester
        '
        Me.lblTipeSemester.AutoSize = True
        Me.lblTipeSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTipeSemester.Location = New System.Drawing.Point(232, 0)
        Me.lblTipeSemester.Name = "lblTipeSemester"
        Me.lblTipeSemester.Size = New System.Drawing.Size(93, 31)
        Me.lblTipeSemester.TabIndex = 4
        Me.lblTipeSemester.Text = "Tipe Semester"
        Me.lblTipeSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblSemester
        '
        Me.lblSemester.AutoSize = True
        Me.lblSemester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSemester.Location = New System.Drawing.Point(473, 0)
        Me.lblSemester.Name = "lblSemester"
        Me.lblSemester.Size = New System.Drawing.Size(64, 31)
        Me.lblSemester.TabIndex = 6
        Me.lblSemester.Text = "Semester"
        Me.lblSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'FrmDataPengampuMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1200, 615)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "FrmDataPengampuMataKuliah"
        Me.flpFilterSpesifik.ResumeLayout(False)
        Me.flpFilterSpesifik.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpFilterSpesifik As FlowLayoutPanel
    Friend WithEvents lblProdi As Label
    Friend WithEvents cmbFilterProdi As ComboBox
    Friend WithEvents lblTipeSemester As Label
    Friend WithEvents cmbFilterTipeSemester As ComboBox
    Friend WithEvents lblSemester As Label
    Friend WithEvents cmbFilterSemester As ComboBox
End Class
