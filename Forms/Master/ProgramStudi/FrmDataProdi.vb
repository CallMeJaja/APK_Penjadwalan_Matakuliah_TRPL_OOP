Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Program Studi.
''' Inherit dari FrmBaseData dengan konfigurasi khusus untuk tbl_prodi.
''' </summary>
Public Class FrmDataProdi

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_prodi"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_prodi"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Program Studi"
        End Get
    End Property

    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_prodi", "nama_prodi"}
        End Get
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Query SELECT custom untuk sorting berdasarkan Kode Prodi.
    ''' </summary>
    Protected Overrides Function GetSelectQuery() As String
        Return $"SELECT * FROM {TableName} ORDER BY kd_prodi"
    End Function

    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk Program Studi.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("kd_prodi") Then
                .Columns("kd_prodi").HeaderText = "Kode"
                .Columns("kd_prodi").Width = 100
                .Columns("kd_prodi").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End If

            If .Columns.Contains("nama_prodi") Then
                .Columns("nama_prodi").HeaderText = "Nama Program Studi"
                .Columns("nama_prodi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub

    ''' <summary>
    ''' Buat instance form input Prodi.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputProdi()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah ada dosen/matakuliah yang terkait.
    ''' </summary>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_dosen", "kd_prodi", recordId) Then
            ShowWarning("Program Studi tidak dapat dihapus karena masih ada Dosen yang terdaftar!")
            Return False
        End If

        If HasChildRecords("tbl_matakuliah", "kd_prodi", recordId) Then
            ShowWarning("Program Studi tidak dapat dihapus karena masih ada Mata Kuliah yang terdaftar!")
            Return False
        End If

        Return True
    End Function
#End Region

End Class
