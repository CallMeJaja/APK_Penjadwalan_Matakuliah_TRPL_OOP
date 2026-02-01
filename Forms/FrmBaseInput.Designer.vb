<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBaseInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.flpAction = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.flpAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblJudul)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(476, 59)
        Me.pnlHeader.TabIndex = 1
        '
        'lblJudul
        '
        Me.lblJudul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.Location = New System.Drawing.Point(0, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(476, 59)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "FORM INPUT / EDIT [MODUL]"
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMain
        '
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(0, 59)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(476, 443)
        Me.pnlMain.TabIndex = 2
        '
        'pnlFooter
        '
        Me.pnlFooter.AutoSize = True
        Me.pnlFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFooter.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlFooter.Controls.Add(Me.flpAction)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 502)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(476, 36)
        Me.pnlFooter.TabIndex = 0
        '
        'flpAction
        '
        Me.flpAction.AutoSize = True
        Me.flpAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpAction.Controls.Add(Me.btnBatal)
        Me.flpAction.Controls.Add(Me.btnSimpan)
        Me.flpAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpAction.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpAction.Location = New System.Drawing.Point(0, 0)
        Me.flpAction.Name = "flpAction"
        Me.flpAction.Size = New System.Drawing.Size(476, 36)
        Me.flpAction.TabIndex = 0
        '
        'btnBatal
        '
        Me.btnBatal.AutoSize = True
        Me.btnBatal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBatal.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.close_line
        Me.btnBatal.Location = New System.Drawing.Point(408, 3)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(65, 30)
        Me.btnBatal.TabIndex = 0
        Me.btnBatal.Text = "&Batal"
        Me.btnBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.AutoSize = True
        Me.btnSimpan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSimpan.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.save_2_line
        Me.btnSimpan.Location = New System.Drawing.Point(326, 3)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(76, 30)
        Me.btnSimpan.TabIndex = 1
        Me.btnSimpan.Text = "&Simpan"
        Me.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'FrmBaseInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 538)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "FrmBaseInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBaseInput"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.flpAction.ResumeLayout(False)
        Me.flpAction.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As Panel
    Protected WithEvents lblJudul As Label
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents flpAction As FlowLayoutPanel
    Protected WithEvents btnBatal As Button
    Protected WithEvents btnSimpan As Button
    Protected WithEvents pnlMain As Panel
End Class
