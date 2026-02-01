Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Hari.
''' Inherit dari FrmBaseData dengan konfigurasi khusus untuk tbl_hari.
''' </summary>
Public Class FrmDataHari

#Region "Override Properties"
    ''' <summary>
    ''' Nama tabel hari di database.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_hari"
        End Get
    End Property

    ''' <summary>
    ''' Primary key tabel hari.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_hari"
        End Get
    End Property

    ''' <summary>
    ''' Nama modul hari.
    ''' </summary>
    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Hari"
        End Get
    End Property

    ''' <summary>
    ''' Kolom pencarian untuk hari.
    ''' </summary>
    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"id_hari", "nama_hari"}
        End Get
    End Property
#End Region

#Region "Override Methods - Data Source (Repository Pattern)"
    ''' <summary>
    ''' Mengambil data melalui HariRepository.
    ''' </summary>
    Protected Overrides Function GetDataTableFromSource() As DataTable
        Dim repo As New HariRepository()
        Return repo.GetAllDataTable()
    End Function

    ''' <summary>
    ''' Eksekusi hapus menggunakan Repository.
    ''' </summary>
    Protected Overrides Function ExecuteDelete(recordId As String) As Boolean
        Dim repo As New HariRepository()
        Return repo.Delete(recordId)
    End Function
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk Hari.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("id_hari") Then
                .Columns("id_hari").HeaderText = "Kode"
                .Columns("id_hari").Width = 100
                .Columns("id_hari").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End If

            If .Columns.Contains("nama_hari") Then
                .Columns("nama_hari").HeaderText = "Nama Hari"
                .Columns("nama_hari").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub

    ''' <summary>
    ''' Buat instance form input Hari.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputHari()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah ada jadwal yang terkait.
    ''' </summary>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_jadwal_matkul", "id_hari", recordId) Then
            ShowWarning("Hari tidak dapat dihapus karena masih ada Jadwal yang terdaftar!")
            Return False
        End If

        Return True
    End Function
#End Region

End Class
