<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBaseData
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaseData))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.flpSearchBase = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.pnlFilterSpesifik = New System.Windows.Forms.Panel()
        Me.pnlNavigation = New System.Windows.Forms.Panel()
        Me.bnData = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.lblHalaman = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEntries = New System.Windows.Forms.ToolStripLabel()
        Me.cmbEntries = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTotalData = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusFilter = New System.Windows.Forms.ToolStripLabel()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnkelaur = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnUbah = New System.Windows.Forms.Button()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tsProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slLevel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.flpSearchBase.SuspendLayout()
        Me.pnlNavigation.SuspendLayout()
        CType(Me.bnData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnData.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblJudul)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1074, 65)
        Me.pnlHeader.TabIndex = 0
        '
        'lblJudul
        '
        Me.lblJudul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.Location = New System.Drawing.Point(0, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(1074, 65)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "DAFTAR DATA [MODUL]"
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlFilter
        '
        Me.pnlFilter.AutoSize = True
        Me.pnlFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlFilter.Controls.Add(Me.TableLayoutPanel3)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFilter.Location = New System.Drawing.Point(0, 65)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(1074, 42)
        Me.pnlFilter.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.flpSearchBase, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnlFilterSpesifik, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1074, 42)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'flpSearchBase
        '
        Me.flpSearchBase.AutoSize = True
        Me.flpSearchBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpSearchBase.Controls.Add(Me.lblCari)
        Me.flpSearchBase.Controls.Add(Me.txtCari)
        Me.flpSearchBase.Controls.Add(Me.btnCari)
        Me.flpSearchBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSearchBase.Location = New System.Drawing.Point(3, 3)
        Me.flpSearchBase.Name = "flpSearchBase"
        Me.flpSearchBase.Size = New System.Drawing.Size(476, 36)
        Me.flpSearchBase.TabIndex = 0
        Me.flpSearchBase.WrapContents = False
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCari.Location = New System.Drawing.Point(3, 0)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(82, 36)
        Me.lblCari.TabIndex = 0
        Me.lblCari.Text = "Cari [Modul]"
        Me.lblCari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(91, 3)
        Me.txtCari.Multiline = True
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(311, 30)
        Me.txtCari.TabIndex = 1
        '
        'btnCari
        '
        Me.btnCari.AutoSize = True
        Me.btnCari.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCari.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.search_2_line
        Me.btnCari.Location = New System.Drawing.Point(408, 3)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(65, 30)
        Me.btnCari.TabIndex = 2
        Me.btnCari.Text = "Cari"
        Me.btnCari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'pnlFilterSpesifik
        '
        Me.pnlFilterSpesifik.AutoSize = True
        Me.pnlFilterSpesifik.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFilterSpesifik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFilterSpesifik.Location = New System.Drawing.Point(485, 3)
        Me.pnlFilterSpesifik.Name = "pnlFilterSpesifik"
        Me.pnlFilterSpesifik.Size = New System.Drawing.Size(586, 36)
        Me.pnlFilterSpesifik.TabIndex = 0
        '
        'pnlNavigation
        '
        Me.pnlNavigation.AutoSize = True
        Me.pnlNavigation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlNavigation.BackColor = System.Drawing.SystemColors.Control
        Me.pnlNavigation.Controls.Add(Me.bnData)
        Me.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNavigation.Location = New System.Drawing.Point(0, 107)
        Me.pnlNavigation.Name = "pnlNavigation"
        Me.pnlNavigation.Size = New System.Drawing.Size(1074, 25)
        Me.pnlNavigation.TabIndex = 2
        '
        'bnData
        '
        Me.bnData.AddNewItem = Nothing
        Me.bnData.BackColor = System.Drawing.SystemColors.ControlLight
        Me.bnData.CountItem = Me.BindingNavigatorCountItem
        Me.bnData.CountItemFormat = "dari {0}"
        Me.bnData.DeleteItem = Nothing
        Me.bnData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.lblHalaman, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.lblEntries, Me.cmbEntries, Me.ToolStripSeparator1, Me.lblTotalData, Me.ToolStripSeparator3, Me.lblStatusFilter})
        Me.bnData.Location = New System.Drawing.Point(0, 0)
        Me.bnData.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnData.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnData.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnData.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnData.Name = "bnData"
        Me.bnData.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnData.Size = New System.Drawing.Size(1074, 25)
        Me.bnData.TabIndex = 0
        Me.bnData.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(44, 22)
        Me.BindingNavigatorCountItem.Text = "dari {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'lblHalaman
        '
        Me.lblHalaman.Name = "lblHalaman"
        Me.lblHalaman.Size = New System.Drawing.Size(55, 22)
        Me.lblHalaman.Text = "Halaman"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(100, 25)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEntries
        '
        Me.lblEntries.Name = "lblEntries"
        Me.lblEntries.Size = New System.Drawing.Size(62, 22)
        Me.lblEntries.Text = "Tampilkan"
        '
        'cmbEntries
        '
        Me.cmbEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEntries.Name = "cmbEntries"
        Me.cmbEntries.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblTotalData
        '
        Me.lblTotalData.Name = "lblTotalData"
        Me.lblTotalData.Size = New System.Drawing.Size(85, 22)
        Me.lblTotalData.Text = "Total Record: 0"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(77, 22)
        Me.lblStatusFilter.Text = "Ditemukan: 0"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.dgvData)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 132)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1074, 419)
        Me.pnlMain.TabIndex = 3
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.Size = New System.Drawing.Size(1074, 419)
        Me.dgvData.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.AutoSize = True
        Me.pnlFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFooter.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFooter.Location = New System.Drawing.Point(0, 551)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1074, 42)
        Me.pnlFooter.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btnkelaur, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1074, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnkelaur
        '
        Me.btnkelaur.AutoSize = True
        Me.btnkelaur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnkelaur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnkelaur.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.logout_box_line
        Me.btnkelaur.Location = New System.Drawing.Point(992, 3)
        Me.btnkelaur.Name = "btnkelaur"
        Me.btnkelaur.Size = New System.Drawing.Size(79, 36)
        Me.btnkelaur.TabIndex = 1
        Me.btnkelaur.Text = "&Keluar"
        Me.btnkelaur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnkelaur.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnRefresh, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnHapus, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnUbah, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnTambah, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(350, 36)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = True
        Me.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRefresh.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.refresh_line
        Me.btnRefresh.Location = New System.Drawing.Point(261, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(86, 30)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.AutoSize = True
        Me.btnHapus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnHapus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHapus.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.delete_bin_7_line
        Me.btnHapus.Location = New System.Drawing.Point(176, 3)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(79, 30)
        Me.btnHapus.TabIndex = 2
        Me.btnHapus.Text = "&Hapus"
        Me.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnUbah
        '
        Me.btnUbah.AutoSize = True
        Me.btnUbah.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUbah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUbah.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.edit_box_line
        Me.btnUbah.Location = New System.Drawing.Point(97, 3)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New System.Drawing.Size(73, 30)
        Me.btnUbah.TabIndex = 1
        Me.btnUbah.Text = "&Ubah"
        Me.btnUbah.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUbah.UseVisualStyleBackColor = True
        '
        'btnTambah
        '
        Me.btnTambah.AutoSize = True
        Me.btnTambah.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTambah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTambah.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.add_line
        Me.btnTambah.Location = New System.Drawing.Point(3, 3)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(88, 30)
        Me.btnTambah.TabIndex = 0
        Me.btnTambah.Text = "&Tambah"
        Me.btnTambah.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsProgress, Me.slStatus, Me.slUser, Me.slLevel, Me.slDate, Me.slTime})
        Me.ssStatus.Location = New System.Drawing.Point(0, 593)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(1074, 22)
        Me.ssStatus.TabIndex = 2
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tsProgress
        '
        Me.tsProgress.Name = "tsProgress"
        Me.tsProgress.Size = New System.Drawing.Size(100, 16)
        Me.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tsProgress.Visible = False
        '
        'slStatus
        '
        Me.slStatus.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.checkbox_circle_line
        Me.slStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(690, 17)
        Me.slStatus.Spring = True
        Me.slStatus.Text = "Status: Ready"
        Me.slStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'slUser
        '
        Me.slUser.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.user_line
        Me.slUser.Name = "slUser"
        Me.slUser.Size = New System.Drawing.Size(76, 17)
        Me.slUser.Text = "User: Reza"
        '
        'slLevel
        '
        Me.slLevel.Name = "slLevel"
        Me.slLevel.Size = New System.Drawing.Size(113, 17)
        Me.slLevel.Text = "Level: Administrator"
        '
        'slDate
        '
        Me.slDate.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.calendar_2_line
        Me.slDate.Name = "slDate"
        Me.slDate.Size = New System.Drawing.Size(99, 17)
        Me.slDate.Text = "MM/DD/YYYY"
        '
        'slTime
        '
        Me.slTime.Image = Global.APK_Penjadwalan_Matakuliah_TRPL_OOP.My.Resources.Resources.time_line
        Me.slTime.Name = "slTime"
        Me.slTime.Size = New System.Drawing.Size(81, 17)
        Me.slTime.Text = "HH:MM:SS"
        '
        'FrmBaseData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 615)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.pnlNavigation)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "FrmBaseData"
        Me.Text = "FrmBaseData"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.flpSearchBase.ResumeLayout(False)
        Me.flpSearchBase.PerformLayout()
        Me.pnlNavigation.ResumeLayout(False)
        Me.pnlNavigation.PerformLayout()
        CType(Me.bnData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnData.ResumeLayout(False)
        Me.bnData.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents flpSearchBase As FlowLayoutPanel
    Friend WithEvents pnlNavigation As Panel
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents lblEntries As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents ssStatus As StatusStrip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnkelaur As Button
    Friend WithEvents lblHalaman As ToolStripLabel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnTambah As Button
    Protected WithEvents lblJudul As Label
    Protected WithEvents lblCari As Label
    Protected WithEvents dgvData As DataGridView
    Protected WithEvents bnData As BindingNavigator
    Protected WithEvents slStatus As ToolStripStatusLabel
    Protected WithEvents slTime As ToolStripStatusLabel
    Protected WithEvents slUser As ToolStripStatusLabel
    Protected WithEvents slLevel As ToolStripStatusLabel
    Protected WithEvents tsProgress As ToolStripProgressBar
    Protected WithEvents slDate As ToolStripStatusLabel
    Protected WithEvents cmbEntries As ToolStripComboBox
    Protected WithEvents pnlFilter As Panel
    Protected WithEvents txtCari As TextBox
    Protected WithEvents btnCari As Button
    Protected WithEvents pnlFilterSpesifik As Panel
    Protected WithEvents lblTotalData As ToolStripLabel
    Protected WithEvents lblStatusFilter As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Protected WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Protected WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Protected WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Protected WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class
