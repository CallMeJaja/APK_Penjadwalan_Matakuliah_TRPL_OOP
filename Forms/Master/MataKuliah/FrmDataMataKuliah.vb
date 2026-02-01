Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Mata Kuliah.
''' Kolom database: kd_matkul, nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul, kd_prodi
''' </summary>
Public Class FrmDataMataKuliah

#Region "Override Properties"
    ''' <summary>
    ''' Nama tabel mata kuliah di database.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_matakuliah"
        End Get
    End Property

    ''' <summary>
    ''' Primary key tabel mata kuliah.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_matkul"
        End Get
    End Property

    ''' <summary>
    ''' Nama modul mata kuliah.
    ''' </summary>
    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Mata Kuliah"
        End Get
    End Property

    ''' <summary>
    ''' Kolom pencarian untuk mata kuliah.
    ''' </summary>
    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_matkul", "nama_matkul"}
        End Get
    End Property
#End Region

#Region "Override Methods - Data Source (Repository Pattern)"
    ''' <summary>
    ''' Mengambil data melalui MatakuliahRepository.
    ''' </summary>
    Protected Overrides Function GetDataTableFromSource() As DataTable
        Dim repo As New MatakuliahRepository()
        Return repo.GetAllDataTable()
    End Function

    ''' <summary>
    ''' Eksekusi hapus menggunakan Repository.
    ''' </summary>
    Protected Overrides Function ExecuteDelete(recordId As String) As Boolean
        Dim repo As New MatakuliahRepository()
        Return repo.Delete(recordId)
    End Function
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Inisialisasi filter ComboBox untuk Prodi, Tipe Semester, dan Semester.
    ''' </summary>
    Protected Overrides Sub InitializeFilters()
        IsiComboBox(cmbFilterProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi",
                    "nama_prodi", "kd_prodi", "-- Semua Prodi --")
        AutoWidthDropDown(cmbFilterProdi)

        IsiComboBoxManual(cmbFilterTipeSemester, {"Ganjil", "Genap"}, "-- Semua --")
        AutoWidthDropDown(cmbFilterTipeSemester)

        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        AutoWidthDropDown(cmbFilterSemester)

        AutoWidthComboBox(cmbFilterProdi)
        AutoWidthComboBox(cmbFilterTipeSemester)
        AutoWidthComboBox(cmbFilterSemester)
    End Sub

    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk Mata Kuliah.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("kd_matkul") Then
                .Columns("kd_matkul").HeaderText = "Kode"
                .Columns("kd_matkul").Width = 100
            End If

            If .Columns.Contains("nama_matkul") Then
                .Columns("nama_matkul").HeaderText = "Nama Mata Kuliah"
                .Columns("nama_matkul").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("nama_prodi") Then
                .Columns("nama_prodi").HeaderText = "Program Studi"
                .Columns("nama_prodi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("teori_matkul") Then
                .Columns("teori_matkul").HeaderText = "Teori"
                .Columns("teori_matkul").Width = 60
                .Columns("teori_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("praktek_matkul") Then
                .Columns("praktek_matkul").HeaderText = "Praktek"
                .Columns("praktek_matkul").Width = 70
                .Columns("praktek_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("sks_matkul") Then
                .Columns("sks_matkul").HeaderText = "Total SKS"
                .Columns("sks_matkul").Width = 80
                .Columns("sks_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("semester_matkul") Then
                .Columns("semester_matkul").HeaderText = "Smt"
                .Columns("semester_matkul").Width = 50
                .Columns("semester_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("tipe_semester") Then
                .Columns("tipe_semester").HeaderText = "Tipe Semester"
                .Columns("tipe_semester").Width = 100
                .Columns("tipe_semester").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        End With
    End Sub

    ''' <summary>
    ''' Reset filter Prodi, Tipe Semester, dan Semester serta reload data.
    ''' </summary>
    Protected Overrides Sub ResetFiltersAndReload()
        If cmbFilterProdi.Items.Count > 0 Then cmbFilterProdi.SelectedIndex = 0
        If cmbFilterTipeSemester.Items.Count > 0 Then cmbFilterTipeSemester.SelectedIndex = 0
        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        txtCari.Clear()
        MyBase.ResetFiltersAndReload()
    End Sub

    ''' <summary>
    ''' Buat instance form input MataKuliah.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputMataKuliah()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah ada pengampu yang terkait.
    ''' </summary>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_dosen_pengampu_matkul", "kd_matkul", recordId) Then
            ShowWarning("Mata Kuliah tidak dapat dihapus karena masih ada data Pengampu yang terkait!")
            Return False
        End If

        If HasChildRecords("tbl_jadwal_matkul", "kd_pengampu", recordId) Then
            ShowWarning("Mata Kuliah tidak dapat dihapus karena masih ada data Jadwal yang terkait!")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Build filter expression untuk Prodi, Tipe Semester, dan Semester.
    ''' </summary>
    Protected Overrides Function BuildFilterExpression() As String
        Dim conditions As New List(Of String)

        Dim searchText As String = txtCari.Text.Trim()
        If Not String.IsNullOrEmpty(searchText) Then
            Dim searchConditions As New List(Of String)
            Dim escapedSearch As String = searchText.Replace("'", "''")
            For Each col As String In SearchColumns
                searchConditions.Add($"[{col}] LIKE '%{escapedSearch}%'")
            Next
            conditions.Add($"({String.Join(" OR ", searchConditions)})")
        End If

        If cmbFilterProdi.SelectedIndex > 0 Then
            Dim prodiNama As String = ""

            If TypeOf cmbFilterProdi.SelectedItem Is DataRowView Then
                prodiNama = CType(cmbFilterProdi.SelectedItem, DataRowView)("nama_prodi").ToString()
            ElseIf cmbFilterProdi.SelectedItem IsNot Nothing Then
                prodiNama = cmbFilterProdi.SelectedItem.ToString()
            End If

            If Not String.IsNullOrEmpty(prodiNama) Then
                conditions.Add($"[nama_prodi] = '{prodiNama.Replace("'", "''")}'")
            End If
        End If

        If cmbFilterSemester.SelectedIndex > 0 Then
            Dim semester As String = cmbFilterSemester.SelectedItem.ToString()
            conditions.Add($"[semester_matkul] = {semester}")
        ElseIf cmbFilterTipeSemester.SelectedIndex > 0 Then
            Dim tipeSemester As String = cmbFilterTipeSemester.SelectedItem.ToString()
            If tipeSemester = "Ganjil" Then
                conditions.Add("[semester_matkul] IN (1, 3, 5, 7)")
            ElseIf tipeSemester = "Genap" Then
                conditions.Add("[semester_matkul] IN (2, 4, 6, 8)")
            End If
        End If

        Return String.Join(" AND ", conditions)
    End Function
#End Region

#Region "Filter Events"
    ''' <summary>
    ''' Event handler untuk filter Prodi.
    ''' </summary>
    Private Sub cmbFilterProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterProdi.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterProdi)
    End Sub

    ''' <summary>
    ''' Event handler untuk filter Tipe Semester - update pilihan Semester.
    ''' </summary>
    Private Sub cmbFilterTipeSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterTipeSemester.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        UpdateSemesterFilter()
        ApplyFilter()
        AutoWidthComboBox(cmbFilterTipeSemester)
    End Sub

    ''' <summary>
    ''' Update ComboBox Semester berdasarkan Tipe Semester yang dipilih.
    ''' </summary>
    Private Sub UpdateSemesterFilter()
        cmbFilterSemester.Items.Clear()
        cmbFilterSemester.Items.Add("-- Semua --")

        Select Case cmbFilterTipeSemester.SelectedIndex
            Case 0
                For i As Integer = 1 To 8
                    cmbFilterSemester.Items.Add(i.ToString())
                Next
            Case 1
                cmbFilterSemester.Items.Add("1")
                cmbFilterSemester.Items.Add("3")
                cmbFilterSemester.Items.Add("5")
                cmbFilterSemester.Items.Add("7")
            Case 2
                cmbFilterSemester.Items.Add("2")
                cmbFilterSemester.Items.Add("4")
                cmbFilterSemester.Items.Add("6")
                cmbFilterSemester.Items.Add("8")
        End Select

        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        AutoWidthDropDown(cmbFilterSemester)
    End Sub

    ''' <summary>
    ''' Event handler untuk filter Semester.
    ''' </summary>
    Private Sub cmbFilterSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterSemester.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterSemester)
    End Sub
#End Region

End Class
