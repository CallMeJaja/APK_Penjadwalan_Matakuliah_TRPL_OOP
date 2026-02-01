<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataDosen
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
        Me.cmbFilterGender = New System.Windows.Forms.ComboBox()
        Me.flpFilterSpesifik.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblJudul.Size = New System.Drawing.Size(1268, 80)
        '
        'pnlFilter
        '
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.pnlFilter.Size = New System.Drawing.Size(1268, 61)
        '
        'flpFilterSpesifik
        '
        Me.flpFilterSpesifik.AutoSize = True
        Me.flpFilterSpesifik.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFilterSpesifik.Controls.Add(Me.Label1)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterProdi)
        Me.flpFilterSpesifik.Controls.Add(Me.Label2)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterGender)
        Me.flpFilterSpesifik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFilterSpesifik.Location = New System.Drawing.Point(0, 0)
        Me.flpFilterSpesifik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.flpFilterSpesifik.Name = "flpFilterSpesifik"
        Me.flpFilterSpesifik.Size = New System.Drawing.Size(632, 53)
        Me.flpFilterSpesifik.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Program Studi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterProdi
        '
        Me.cmbFilterProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterProdi.FormattingEnabled = True
        Me.cmbFilterProdi.Location = New System.Drawing.Point(132, 4)
        Me.cmbFilterProdi.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbFilterProdi.Name = "cmbFilterProdi"
        Me.cmbFilterProdi.Size = New System.Drawing.Size(160, 29)
        Me.cmbFilterProdi.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(300, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 37)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Gender"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterGender
        '
        Me.cmbFilterGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterGender.FormattingEnabled = True
        Me.cmbFilterGender.Location = New System.Drawing.Point(374, 4)
        Me.cmbFilterGender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbFilterGender.Name = "cmbFilterGender"
        Me.cmbFilterGender.Size = New System.Drawing.Size(180, 29)
        Me.cmbFilterGender.TabIndex = 5
        '
        'FrmDataDosen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1268, 757)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "FrmDataDosen"
        Me.flpFilterSpesifik.ResumeLayout(False)
        Me.flpFilterSpesifik.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpFilterSpesifik As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFilterProdi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFilterGender As ComboBox
End Class
