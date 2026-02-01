Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Dosen.
''' Inherit dari FrmBaseData dengan filter by Prodi dan Gender.
''' </summary>
Public Class FrmDataDosen

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_dosen"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Dosen"
        End Get
    End Property

    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_dosen", "nidn_dosen", "nama_dosen", "email_dosen"}
        End Get
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Query SELECT dengan JOIN ke tbl_prodi untuk menampilkan nama prodi.
    ''' </summary>
    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT d.kd_dosen, d.nidn_dosen, d.nama_dosen, p.nama_prodi, d.jk_dosen, d.no_telp_dosen, d.email_dosen " &
               "FROM tbl_dosen d " &
               "LEFT JOIN tbl_prodi p ON d.kd_prodi = p.kd_prodi " &
               "ORDER BY d.nama_dosen"
    End Function

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
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_dosen_pengampu_matkul", "kd_dosen", recordId) Then
            ShowWarning("Dosen tidak dapat dihapus karena masih ada data Pengampu Mata Kuliah yang terkait!")
            Return False
        End If

        Return True
    End Function

    Protected Overrides Sub ResetFiltersAndReload()
        If cmbFilterProdi.Items.Count > 0 Then cmbFilterProdi.SelectedIndex = 0
        If cmbFilterGender.Items.Count > 0 Then cmbFilterGender.SelectedIndex = 0
        txtCari.Clear()
        MyBase.ResetFiltersAndReload()
    End Sub
#End Region

#Region "Filter Events"
    Private Sub cmbFilterProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterProdi.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterProdi)
    End Sub

    Private Sub cmbFilterGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterGender.SelectedIndexChanged
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        AutoWidthComboBox(cmbFilterGender)
    End Sub

    Private Sub FrmDataDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class
