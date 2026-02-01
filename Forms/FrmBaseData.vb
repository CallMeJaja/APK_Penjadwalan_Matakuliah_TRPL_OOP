Imports MySql.Data.MySqlClient

''' <summary>
''' Base class untuk form daftar data (Data Grid).
''' Menyediakan fungsionalitas umum seperti load data, filter, pagination, dan CRUD operations.
''' Child class harus override properties dan methods yang diperlukan.
''' </summary>
Public Class FrmBaseData

#Region "Overridable Properties"
    ''' <summary>
    ''' Nama tabel utama di database. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property TableName As String
        Get
            Return ""
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property PrimaryKey As String
        Get
            Return ""
        End Get
    End Property

    ''' <summary>
    ''' Nama modul untuk ditampilkan di judul dan label. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property ModuleName As String
        Get
            Return "Data"
        End Get
    End Property

    ''' <summary>
    ''' Kolom yang digunakan untuk pencarian. Override untuk custom.
    ''' Default: menggunakan primary key
    ''' </summary>
    Protected Overridable ReadOnly Property SearchColumns As String()
        Get
            Return {PrimaryKey}
        End Get
    End Property
#End Region

#Region "Private Variables"
    Protected _dataSource As DataTable
    Protected _filteredData As DataView
    Protected _currentPage As Integer = 1
    Protected _pageSize As Integer = 25
    Protected _totalRecords As Integer = 0
    Protected _totalPages As Integer = 0

    ''' <summary>
    ''' Flag untuk mencegah event loops saat perubahan internal.
    ''' </summary>
    Protected _isInternalChange As Boolean = False
#End Region

#Region "Form Events"
    Private Sub FrmBaseData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Exit Sub

        If Me.MdiParent IsNot Nothing Then
            Me.WindowState = FormWindowState.Maximized
        End If

        InitializeForm()
        InitializeFilters()
        LoadData()
    End Sub

    Private Sub FrmBaseData_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCari.Focus()
    End Sub
#End Region

#Region "Initialization"
    ''' <summary>
    ''' Inisialisasi form: set judul, label, status bar, dll.
    ''' </summary>
    Private Sub InitializeForm()
        Me.Text = $"Data {ModuleName}"
        lblJudul.Text = $"DAFTAR DATA {ModuleName.ToUpper()}"
        lblCari.Text = $"Cari {ModuleName}"

        UpdateStatusBar()
        StartStatusTimer()

        InitializePagination()

        InitializeNavigation()

        dgvData.DoubleBuffered(True)

        SetupDataGridViewStyle()
    End Sub

    ''' <summary>
    ''' Setup styling DataGridView: Font Segoe UI, Header Bold 10pt MiddleCenter, Content 10pt.
    ''' </summary>
    Private Sub SetupDataGridViewStyle()
        With dgvData
            .DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .DefaultCellStyle.Padding = New Padding(3, 2, 3, 2)

            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 35
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248)

            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215)
            .DefaultCellStyle.SelectionForeColor = Color.White

            .RowTemplate.Height = 28
            .AllowUserToResizeRows = False

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

    ''' <summary>
    ''' Inisialisasi navigation buttons - disconnect dari BindingSource default.
    ''' </summary>
    Private Sub InitializeNavigation()
        bnData.BindingSource = Nothing
        bnData.MoveFirstItem = Nothing
        bnData.MovePreviousItem = Nothing
        bnData.MoveNextItem = Nothing
        bnData.MoveLastItem = Nothing
        bnData.PositionItem = Nothing
        bnData.CountItem = Nothing

        BindingNavigatorMoveFirstItem.Enabled = True
        BindingNavigatorMovePreviousItem.Enabled = True
        BindingNavigatorMoveNextItem.Enabled = True
        BindingNavigatorMoveLastItem.Enabled = True
    End Sub

    ''' <summary>
    ''' Update enabled state navigation buttons berdasarkan posisi halaman.
    ''' </summary>
    Protected Sub UpdateNavigationButtons()
        BindingNavigatorMoveFirstItem.Enabled = _currentPage > 1
        BindingNavigatorMovePreviousItem.Enabled = _currentPage > 1
        BindingNavigatorMoveNextItem.Enabled = _currentPage < _totalPages
        BindingNavigatorMoveLastItem.Enabled = _currentPage < _totalPages
    End Sub

    ''' <summary>
    ''' Inisialisasi ComboBox pagination (jumlah entries per halaman).
    ''' </summary>
    Private Sub InitializePagination()
        cmbEntries.Items.Clear()
        cmbEntries.Items.AddRange({"5", "10", "25", "50", "100", "Semua"})
        cmbEntries.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Inisialisasi filter spesifik. Override di child class untuk filter custom.
    ''' </summary>
    Protected Overridable Sub InitializeFilters()
        ' Override di child class jika ada filter spesifik (ComboBox, dll)
    End Sub
#End Region

#Region "Data Loading"
    ''' <summary>
    ''' Load data dari database ke DataGridView.
    ''' </summary>
    Public Overridable Sub LoadData()
        Try
            Cursor = Cursors.WaitCursor
            slStatus.Text = "Memuat data..."

            ' Ambil data dari source (Default: GetSelectQuery() atau Override: Repository)
            _dataSource = GetDataTableFromSource()

            If _dataSource IsNot Nothing Then
                _totalRecords = _dataSource.Rows.Count

                ApplyFilter()

                HandleEmptyData()
            Else
                ShowEmptyDataMessage()
            End If

            slStatus.Text = "Data berhasil dimuat"
        Catch ex As Exception
            ShowError($"Gagal memuat data: {ex.Message}")
            slStatus.Text = "Gagal memuat data"
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Mendapatkan data dari sumber (DataTable).
    ''' Secara default menjalankan GetSelectQuery().
    ''' Override di child class untuk menggunakan Repository.GetAllDataTable().
    ''' </summary>
    Protected Overridable Function GetDataTableFromSource() As DataTable
        Return ModDbCrud.LoadData(GetSelectQuery())
    End Function

    ''' <summary>
    ''' Query SELECT utama. Override untuk custom query (JOIN, dll).
    ''' </summary>
    Protected Overridable Function GetSelectQuery() As String
        Return $"SELECT * FROM {TableName}"
    End Function

    ''' <summary>
    ''' Handle data kosong - tampilkan pesan ke user.
    ''' </summary>
    Private Sub HandleEmptyData()
        If dgvData.Rows.Count = 0 Then
            ShowEmptyDataMessage()
        End If
    End Sub

    ''' <summary>
    ''' Tampilkan pesan bahwa data kosong.
    ''' </summary>
    Private Sub ShowEmptyDataMessage()
        lblStatusFilter.Text = $"Tidak ada data {ModuleName} yang ditemukan"
    End Sub
#End Region

#Region "Row Number Column"
    ''' <summary>
    ''' Tambahkan kolom No di paling kiri untuk nomor urut.
    ''' </summary>
    Protected Sub AddRowNumberColumn()
        If dgvData.DataSource Is Nothing OrElse dgvData.Rows.Count = 0 Then Exit Sub

        If dgvData.Columns.Contains("No") Then
            dgvData.Columns.Remove("No")
        End If

        Dim noColumn As New DataGridViewTextBoxColumn()
        noColumn.Name = "No"
        noColumn.HeaderText = "No"
        noColumn.ReadOnly = True
        noColumn.Frozen = True
        noColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        noColumn.SortMode = DataGridViewColumnSortMode.NotSortable
        noColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        noColumn.MinimumWidth = 45

        dgvData.Columns.Insert(0, noColumn)

        UpdateRowNumbers()
    End Sub

    ''' <summary>
    ''' Update nomor urut di kolom No.
    ''' </summary>
    Protected Sub UpdateRowNumbers()
        If Not dgvData.Columns.Contains("No") Then Exit Sub
        If dgvData.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To dgvData.Rows.Count - 1
            If Not dgvData.Rows(i).IsNewRow Then
                Dim rowNum As Integer = ((_currentPage - 1) * _pageSize) + i + 1
                ' Jika show all
                If _pageSize = 0 Then rowNum = i + 1
                dgvData.Rows(i).Cells("No").Value = rowNum
            End If
        Next
    End Sub
#End Region

#Region "Filtering"
    ''' <summary>
    ''' Terapkan filter ke data.
    ''' </summary>
    Protected Overridable Sub ApplyFilter()
        If _dataSource Is Nothing Then Exit Sub

        Try
            Dim filterExpression As String = BuildFilterExpression()

            _filteredData = New DataView(_dataSource)
            If Not String.IsNullOrEmpty(filterExpression) Then
                _filteredData.RowFilter = filterExpression
            End If

            ' Apply pagination
            ApplyPagination()

        Catch ex As Exception
            ' Jika filter error, tampilkan semua data
            dgvData.DataSource = _dataSource
        End Try
    End Sub

    ''' <summary>
    ''' Build filter expression untuk DataView.RowFilter.
    ''' Override untuk filter custom.
    ''' </summary>
    Protected Overridable Function BuildFilterExpression() As String
        Dim searchText As String = txtCari.Text.Trim()
        If String.IsNullOrEmpty(searchText) Then Return ""

        ' Build OR condition untuk setiap kolom pencarian
        Dim conditions As New List(Of String)
        Dim escapedSearch As String = searchText.Replace("'", "''")
        For Each col As String In SearchColumns
            conditions.Add($"[{col}] LIKE '%{escapedSearch}%'")
        Next

        Return String.Join(" OR ", conditions)
    End Function

    ''' <summary>
    ''' Terapkan pagination ke filtered data.
    ''' </summary>
    Protected Sub ApplyPagination()
        If _filteredData Is Nothing Then Exit Sub

        Dim filteredCount As Integer = _filteredData.Count

        If _pageSize = 0 OrElse _pageSize >= filteredCount Then
            ' Show all
            dgvData.DataSource = _filteredData
            _totalPages = 1
        Else
            ' Paginate
            _totalPages = CInt(Math.Ceiling(filteredCount / _pageSize))
            If _currentPage > _totalPages Then _currentPage = _totalPages
            If _currentPage < 1 Then _currentPage = 1

            Dim startIndex As Integer = (_currentPage - 1) * _pageSize
            Dim pageData As New DataTable()

            ' Clone structure
            pageData = _dataSource.Clone()

            ' Copy rows for current page
            For i As Integer = startIndex To Math.Min(startIndex + _pageSize - 1, filteredCount - 1)
                pageData.ImportRow(_filteredData(i).Row)
            Next

            dgvData.DataSource = pageData
        End If

        ' Configure columns AFTER data bound
        ConfigureGridColumns()

        ' Tambahkan kolom No
        AddRowNumberColumn()

        UpdatePaginationInfo()
        UpdateNavigationButtons()
        UpdateFilterStatus(filteredCount)
    End Sub

    ''' <summary>
    ''' Update info pagination di BindingNavigator.
    ''' </summary>
    Protected Sub UpdatePaginationInfo()
        lblTotalData.Text = $"Total Record: {_totalRecords}"
        BindingNavigatorPositionItem.Text = _currentPage.ToString()
        BindingNavigatorCountItem.Text = $"dari {_totalPages}"
    End Sub

    ''' <summary>
    ''' Update status filter.
    ''' </summary>
    Protected Sub UpdateFilterStatus(filteredCount As Integer)
        If filteredCount = 0 Then
            lblStatusFilter.Text = "Tidak ada data yang ditemukan"

            ' Tampilkan info satu kali jika bukan perubahan internal/reset
            If Not _isInternalChange Then
                ClearDataGrid()
                ShowInfo($"Tidak ada data {ModuleName} yang ditemukan.")
                txtCari.Clear()
                ResetFiltersAndReload()
            End If
        ElseIf filteredCount = _totalRecords Then
            lblStatusFilter.Text = ""
        Else
            lblStatusFilter.Text = $"Ditemukan: {filteredCount}"
        End If
    End Sub

    ''' <summary>
    ''' Reset semua filter dan reload data.
    ''' </summary>
    Protected Overridable Sub ResetFiltersAndReload()
        ' Gunakan flag untuk mencegah recursion
        If _isInternalChange Then Exit Sub

        Try
            _isInternalChange = True
            ' Override di child class untuk reset filter spesifik
            LoadData()
        Finally
            _isInternalChange = False
        End Try
    End Sub

    ''' <summary>
    ''' Bersihkan DataGridView termasuk semua kolom dan header agar benar-benar kosong.
    ''' </summary>
    Protected Sub ClearDataGrid()
        dgvData.DataSource = Nothing
        dgvData.Columns.Clear()
        If dgvData.Rows.Count > 0 Then dgvData.Rows.Clear()
        lblStatusFilter.Text = "Tidak ada data"
    End Sub
#End Region

#Region "Grid Configuration"
    ''' <summary>
    ''' Konfigurasi kolom DataGridView (header, width, visible).
    ''' Override untuk custom configuration.
    ''' </summary>
    Protected Overridable Sub ConfigureGridColumns()
        With dgvData
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
        End With
    End Sub
#End Region

#Region "CRUD Operations"
    ''' <summary>
    ''' Buka form input untuk tambah data baru.
    ''' </summary>
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        OpenInputForm(False, "")
    End Sub

    ''' <summary>
    ''' Buka form input untuk edit data yang dipilih.
    ''' </summary>
    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        Dim selectedId As String = GetSelectedRecordId()
        If String.IsNullOrEmpty(selectedId) Then
            ShowWarning("Pilih data yang akan diubah!")
            Return
        End If
        OpenInputForm(True, selectedId)
    End Sub

    ''' <summary>
    ''' Hapus data yang dipilih.
    ''' </summary>
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim selectedId As String = GetSelectedRecordId()
        If String.IsNullOrEmpty(selectedId) Then
            ShowWarning("Pilih data yang akan dihapus!")
            Return
        End If

        ' Validasi sebelum hapus
        If Not ValidateBeforeDelete(selectedId) Then Return

        If ShowConfirm($"Yakin ingin menghapus data {ModuleName} ini?") Then
            PerformDelete(selectedId)
        End If
    End Sub

    ''' <summary>
    ''' Validasi sebelum hapus (cek FK constraint).
    ''' Override untuk custom validation.
    ''' </summary>
    Protected Overridable Function ValidateBeforeDelete(recordId As String) As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Eksekusi hapus data.
    ''' </summary>
    Protected Overridable Sub PerformDelete(recordId As String)
        Try
            If ExecuteDelete(recordId) Then
                ShowSuccess($"Data {ModuleName} berhasil dihapus!")
                LoadData()
            End If
        Catch ex As Exception
            ShowError($"Gagal menghapus data: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Inti dari proses penghapusan data.
    ''' Secara default menggunakan query DELETE manual (Backward Compatibility).
    ''' Override di child class untuk menggunakan Repository.Delete().
    ''' </summary>
    Protected Overridable Function ExecuteDelete(recordId As String) As Boolean
        Dim query As String = $"DELETE FROM {TableName} WHERE {PrimaryKey} = @id"
        Dim param As New MySqlParameter("@id", recordId)
        Return ExecuteQuery(query, param)
    End Function

    ''' <summary>
    ''' Buka form input. Override untuk custom input form.
    ''' </summary>
    Protected Overridable Sub OpenInputForm(isEditMode As Boolean, recordId As String)
        Dim inputForm As FrmBaseInput = CreateInputForm()
        If inputForm Is Nothing Then
            ShowError("Form input belum dikonfigurasi!")
            Return
        End If

        inputForm.IsEditMode = isEditMode
        inputForm.RecordId = recordId
        inputForm.ShowDialog()

        ' Refresh data setelah form ditutup
        If inputForm.DialogResult = DialogResult.OK Then
            LoadData()
        End If
    End Sub

    ''' <summary>
    ''' Buat instance form input. Wajib di-override.
    ''' </summary>
    Protected Overridable Function CreateInputForm() As FrmBaseInput
        Return Nothing
    End Function

    ''' <summary>
    ''' Ambil ID record yang dipilih di DataGridView.
    ''' </summary>
    Protected Function GetSelectedRecordId() As String
        Return GetSelectedCellValue(dgvData, PrimaryKey)
    End Function
#End Region

#Region "Search and Refresh"
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        _currentPage = 1
        ApplyFilter()
        ' Tambahkan kembali nomor urut setelah filter
        If dgvData.Columns.Contains("No") Then
            UpdateRowNumbers()
        Else
            AddRowNumberColumn()
        End If
    End Sub

    Private Sub txtCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCari.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnCari.PerformClick()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtCari.Clear()
        _currentPage = 1
        LoadData()
    End Sub
#End Region

#Region "Pagination Navigation"
    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        _currentPage = 1
        ApplyPagination()
        UpdateRowNumbers()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        If _currentPage > 1 Then
            _currentPage -= 1
            ApplyPagination()
            UpdateRowNumbers()
        End If
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        If _currentPage < _totalPages Then
            _currentPage += 1
            ApplyPagination()
            UpdateRowNumbers()
        End If
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        _currentPage = _totalPages
        ApplyPagination()
        UpdateRowNumbers()
    End Sub

    Private Sub BindingNavigatorPositionItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BindingNavigatorPositionItem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Dim newPage As Integer
            If Integer.TryParse(BindingNavigatorPositionItem.Text, newPage) Then
                If newPage >= 1 AndAlso newPage <= _totalPages Then
                    _currentPage = newPage
                    ApplyPagination()
                    UpdateRowNumbers()
                Else
                    BindingNavigatorPositionItem.Text = _currentPage.ToString()
                End If
            End If
        End If
    End Sub

    Private Sub cmbEntries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEntries.SelectedIndexChanged
        Select Case cmbEntries.SelectedItem.ToString()
            Case "Semua"
                _pageSize = 0
            Case Else
                Integer.TryParse(cmbEntries.SelectedItem.ToString(), _pageSize)
        End Select
        _currentPage = 1
        ApplyFilter()
        ' Tambahkan kembali nomor urut
        If dgvData.Columns.Contains("No") Then
            UpdateRowNumbers()
        Else
            AddRowNumberColumn()
        End If
    End Sub
#End Region

#Region "DataGridView Events"
    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnUbah.PerformClick()
        End If
    End Sub

    Private Sub dgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvData.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            btnUbah.PerformClick()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            btnHapus.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' Handle DataGridView Sorted event - update row numbers after sorting.
    ''' </summary>
    Private Sub dgvData_Sorted(sender As Object, e As EventArgs) Handles dgvData.Sorted
        UpdateRowNumbers()
    End Sub

    ''' <summary>
    ''' Handle DataBindingComplete to ensure row numbers are generated after data is bound.
    ''' </summary>
    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        UpdateRowNumbers()
    End Sub
#End Region

#Region "Status Bar"
    Private WithEvents tmrStatus As New Timer()

    Private Sub StartStatusTimer()
        tmrStatus.Interval = 1000
        tmrStatus.Start()
    End Sub

    Private Sub tmrStatus_Tick(sender As Object, e As EventArgs) Handles tmrStatus.Tick
        UpdateStatusBar()
    End Sub

    Private Sub UpdateStatusBar()
        slUser.Text = $"User: {If(IsLoggedIn(), CurrentUserName, "-")}"
        slLevel.Text = $"Level: {If(IsLoggedIn(), CurrentLevel, "-")}"
        slDate.Text = FormatTanggal(DateTime.Now)
        slTime.Text = FormatWaktuLengkap(DateTime.Now)
    End Sub
#End Region

#Region "Form Close"
    Private Sub btnKelaur_Click(sender As Object, e As EventArgs) Handles btnkelaur.Click
        Me.Close()
    End Sub

    Private Sub FrmBaseData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrStatus.Stop()
    End Sub
#End Region

#Region "ComboBox Auto Width"
    ''' <summary>
    ''' Set ComboBox width berdasarkan konten terpanjang.
    ''' </summary>
    Protected Sub AutoSizeComboBox(cmb As ComboBox)
        If cmb Is Nothing OrElse cmb.Items.Count = 0 Then Exit Sub

        Dim maxWidth As Integer = cmb.Width
        Using g As Graphics = cmb.CreateGraphics()
            For Each item As Object In cmb.Items
                Dim itemText As String = ""
                If TypeOf item Is DataRowView Then
                    itemText = CType(item, DataRowView)(cmb.DisplayMember).ToString()
                Else
                    itemText = item.ToString()
                End If
                Dim itemWidth As Integer = CInt(g.MeasureString(itemText, cmb.Font).Width) + 30
                If itemWidth > maxWidth Then maxWidth = itemWidth
            Next
        End Using

        cmb.DropDownWidth = maxWidth
    End Sub
#End Region

End Class

#Region "Extension Methods"
''' <summary>
''' Extension untuk enable double buffering pada DataGridView.
''' </summary>
Module DataGridViewExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DoubleBuffered(dgv As DataGridView, setting As Boolean)
        Dim dgvType As Type = dgv.GetType()
        Dim pi As System.Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub
End Module
#End Region