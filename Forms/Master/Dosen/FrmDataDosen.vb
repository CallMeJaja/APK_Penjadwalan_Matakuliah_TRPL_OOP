Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Dosen.
''' Inherit dari FrmBaseData dengan filter by Prodi dan Gender.
''' </summary>
Public Class FrmDataDosen

#Region "Override Properties"
    ''' <summary>
    ''' Nama tabel database untuk Dosen.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen"
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key untuk Dosen.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_dosen"
        End Get
    End Property

    ''' <summary>
    ''' Nama modul untuk identifikasi di UI/Pesan.
    ''' </summary>
    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Dosen"
        End Get
    End Property

    ''' <summary>
    ''' Daftar kolom yang digunakan untuk pencarian.
    ''' </summary>
    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_dosen", "nidn_dosen", "nama_dosen", "email_dosen"}
        End Get
    End Property
#End Region

#Region "Override Methods - Data Source (Repository Pattern)"
    ''' <summary>
    ''' Mengambil data melalui DosenRepository.
    ''' Memastikan query terpusat di satu tempat (Repository).
    ''' </summary>
    Protected Overrides Function GetDataTableFromSource() As DataTable
        Dim repo As New DosenRepository()
        Return repo.GetAllDataTable()
    End Function

    ''' <summary>
    ''' Eksekusi hapus menggunakan Repository.
    ''' </summary>
    Protected Overrides Function ExecuteDelete(recordId As String) As Boolean
        Dim repo As New DosenRepository()
        Return repo.Delete(recordId)
    End Function

    ' Method GetSelectQuery lama dihapus karena sudah ditangani oleh GetDataTableFromSource
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Inisialisasi filter ComboBox untuk Prodi dan Gender.
    ''' </summary>
    Protected Overrides Sub InitializeFilters()
        IsiComboBox(cmbFilterProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi",
                    "nama_prodi", "kd_prodi", "-- Semua Prodi --")
        AutoWidthDropDown(cmbFilterProdi)

        IsiComboBoxManual(cmbFilterGender, {"LAKI-LAKI", "PEREMPUAN"}, "-- Semua --")
        AutoWidthDropDown(cmbFilterGender)
    End Sub

    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk Dosen.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("kd_dosen") Then
                .Columns("kd_dosen").HeaderText = "Kode"
                .Columns("kd_dosen").Width = 80
            End If

            If .Columns.Contains("nidn_dosen") Then
                .Columns("nidn_dosen").HeaderText = "NIDN"
                .Columns("nidn_dosen").Width = 100
            End If

            If .Columns.Contains("nama_dosen") Then
                .Columns("nama_dosen").HeaderText = "Nama Dosen"
                .Columns("nama_dosen").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("nama_prodi") Then
                .Columns("nama_prodi").HeaderText = "Program Studi"
                .Columns("nama_prodi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("jk_dosen") Then
                .Columns("jk_dosen").HeaderText = "Jenis Kelamin"
                .Columns("jk_dosen").Width = 100
            End If

            If .Columns.Contains("no_telp_dosen") Then
                .Columns("no_telp_dosen").HeaderText = "No. Telepon"
                .Columns("no_telp_dosen").Width = 120
            End If

            If .Columns.Contains("email_dosen") Then
                .Columns("email_dosen").HeaderText = "Email"
                .Columns("email_dosen").Width = 180
            End If
        End With
    End Sub

    ''' <summary>
    ''' Build filter expression termasuk filter spesifik (Prodi dan Gender).
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
            Else
                prodiNama = cmbFilterProdi.Text
            End If
            If Not String.IsNullOrEmpty(prodiNama) Then
                conditions.Add($"[nama_prodi] = '{prodiNama.Replace("'", "''")}'")
            End If
        End If

        If cmbFilterGender.SelectedIndex > 0 Then
            Dim gender As String = cmbFilterGender.SelectedItem.ToString()
            conditions.Add($"[jk_dosen] = '{gender}'")
        End If

        Return String.Join(" AND ", conditions)
    End Function

    ''' <summary>
    ''' Buat instance form input Dosen.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputDosen()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah ada pengampu yang terkait.
    ''' </summary>
    ''' <param name="recordId">ID dosen yang akan dihapus.</param>
    ''' <returns>True jika valid untuk dihapus, False jika tidak.</returns>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_dosen_pengampu_matkul", "kd_dosen", recordId) Then
            ShowWarning("Dosen tidak dapat dihapus karena masih ada data Pengampu Mata Kuliah yang terkait!")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Mereset filter dan memuat ulang data.
    ''' </summary>
    Protected Overrides Sub ResetFiltersAndReload()
        If cmbFilterProdi.Items.Count > 0 Then cmbFilterProdi.SelectedIndex = 0
        If cmbFilterGender.Items.Count > 0 Then cmbFilterGender.SelectedIndex = 0
        txtCari.Clear()
        MyBase.ResetFiltersAndReload()
    End Sub
#End Region

#Region "Filter Events"
    ''' <summary>
    ''' Handler saat pilihan filter Prodi berubah.
    ''' </summary>
    Private Sub cmbFilterProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterProdi.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterProdi)
    End Sub

    ''' <summary>
    ''' Handler saat pilihan filter Gender berubah.
    ''' </summary>
    Private Sub cmbFilterGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterGender.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterGender)
    End Sub

    ''' <summary>
    ''' Handler saat form dimuat.
    ''' </summary>
    Private Sub FrmDataDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class
