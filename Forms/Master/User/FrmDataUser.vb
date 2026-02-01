Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data User.
''' Kolom database: id_user, nama_user, pass_user, level_user
''' </summary>
Public Class FrmDataUser

#Region "Override Properties"
    ''' <summary>
    ''' Nama tabel user di database.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_user"
        End Get
    End Property

    ''' <summary>
    ''' Primary key tabel user.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_user"
        End Get
    End Property

    ''' <summary>
    ''' Nama modul user.
    ''' </summary>
    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "User"
        End Get
    End Property

    ''' <summary>
    ''' Kolom pencarian untuk user.
    ''' </summary>
    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"id_user", "nama_user", "level_user"}
        End Get
    End Property
#End Region

#Region "Override Methods - Data Source (Repository Pattern)"
    ''' <summary>
    ''' Mengambil data melalui UserRepository (Tanpa Password).
    ''' </summary>
    Protected Overrides Function GetDataTableFromSource() As DataTable
        Dim repo As New UserRepository()
        Return repo.GetAllDataTable()
    End Function

    ''' <summary>
    ''' Eksekusi hapus menggunakan Repository.
    ''' </summary>
    Protected Overrides Function ExecuteDelete(recordId As String) As Boolean
        Dim repo As New UserRepository()
        Return repo.Delete(recordId)
    End Function
#End Region

#Region "Override Methods"

    ''' <summary>
    ''' Inisialisasi filter ComboBox untuk Level User.
    ''' </summary>
    Protected Overrides Sub InitializeFilters()
        IsiComboBoxManual(cmbFilterLevelUser, {"Administrator", "Dosen"}, "-- Semua Level --")
        AutoWidthDropDown(cmbFilterLevelUser)
    End Sub

    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk User.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("id_user") Then
                .Columns("id_user").HeaderText = "ID"
                .Columns("id_user").Width = 80
            End If

            If .Columns.Contains("nama_user") Then
                .Columns("nama_user").HeaderText = "Nama User"
                .Columns("nama_user").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("level_user") Then
                .Columns("level_user").HeaderText = "Level"
                .Columns("level_user").Width = 120
            End If
        End With
    End Sub

    ''' <summary>
    ''' Buat instance form input User.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputUser()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah user yang login tidak bisa dihapus.
    ''' </summary>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If recordId = CurrentUserId Then
            ShowWarning("Anda tidak dapat menghapus akun Anda sendiri!")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Build filter expression untuk Level User.
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

        If cmbFilterLevelUser.SelectedIndex > 0 Then
            Dim level As String = cmbFilterLevelUser.SelectedItem.ToString()
            conditions.Add($"[level_user] = '{level}'")
        End If

        Return String.Join(" AND ", conditions)
    End Function

    ''' <summary>
    ''' Reset filter Level User dan reload data.
    ''' </summary>
    Protected Overrides Sub ResetFiltersAndReload()
        cmbFilterLevelUser.SelectedIndex = 0
        txtCari.Clear()
        MyBase.ResetFiltersAndReload()
    End Sub
#End Region

#Region "Filter Events"
    Private Sub cmbFilterLevelUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterLevelUser.SelectedIndexChanged
        ApplyFilter()
        AutoWidthComboBox(cmbFilterLevelUser)
    End Sub
#End Region

End Class
