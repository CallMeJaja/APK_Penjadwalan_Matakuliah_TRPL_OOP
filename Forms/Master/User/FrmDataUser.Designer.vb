<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataUser
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
        Me.lblLevelUser = New System.Windows.Forms.Label()
        Me.cmbFilterLevelUser = New System.Windows.Forms.ComboBox()
        Me.pnlFilter.SuspendLayout()
        Me.pnlFilterSpesifik.SuspendLayout()
        Me.flpFilterSpesifik.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFilterSpesifik
        '
        Me.pnlFilterSpesifik.Controls.Add(Me.flpFilterSpesifik)
        Me.pnlFilterSpesifik.Location = New System.Drawing.Point(872, 0)
        Me.pnlFilterSpesifik.Size = New System.Drawing.Size(202, 39)
        '
        'flpFilterSpesifik
        '
        Me.flpFilterSpesifik.AutoSize = True
        Me.flpFilterSpesifik.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpFilterSpesifik.Controls.Add(Me.lblLevelUser)
        Me.flpFilterSpesifik.Controls.Add(Me.cmbFilterLevelUser)
        Me.flpFilterSpesifik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpFilterSpesifik.Location = New System.Drawing.Point(0, 0)
        Me.flpFilterSpesifik.Name = "flpFilterSpesifik"
        Me.flpFilterSpesifik.Size = New System.Drawing.Size(202, 39)
        Me.flpFilterSpesifik.TabIndex = 1
        '
        'lblLevelUser
        '
        Me.lblLevelUser.AutoSize = True
        Me.lblLevelUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLevelUser.Location = New System.Drawing.Point(3, 0)
        Me.lblLevelUser.Name = "lblLevelUser"
        Me.lblLevelUser.Size = New System.Drawing.Size(69, 31)
        Me.lblLevelUser.TabIndex = 3
        Me.lblLevelUser.Text = "Level User"
        Me.lblLevelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilterLevelUser
        '
        Me.cmbFilterLevelUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterLevelUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterLevelUser.FormattingEnabled = True
        Me.cmbFilterLevelUser.Location = New System.Drawing.Point(78, 3)
        Me.cmbFilterLevelUser.Name = "cmbFilterLevelUser"
        Me.cmbFilterLevelUser.Size = New System.Drawing.Size(121, 25)
        Me.cmbFilterLevelUser.TabIndex = 2
        '
        'FrmDataUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1074, 615)
        Me.Name = "FrmDataUser"
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlFilterSpesifik.ResumeLayout(False)
        Me.pnlFilterSpesifik.PerformLayout()
        Me.flpFilterSpesifik.ResumeLayout(False)
        Me.flpFilterSpesifik.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpFilterSpesifik As FlowLayoutPanel
    Friend WithEvents lblLevelUser As Label
    Friend WithEvents cmbFilterLevelUser As ComboBox
End Class
