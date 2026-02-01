Imports MySql.Data.MySqlClient

''' <summary>
''' Form daftar data Ruang Kelas.
''' Inherit dari FrmBaseData dengan konfigurasi khusus untuk tbl_ruangkelas.
''' </summary>
Public Class FrmDataRuang

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_ruangkelas"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_ruangan"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Ruang Kelas"
        End Get
    End Property

    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_ruangan", "nama_ruangan"}
        End Get
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Konfigurasi kolom DataGridView untuk Ruang Kelas.
    ''' </summary>
    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .Columns.Contains("kd_ruangan") Then
                .Columns("kd_ruangan").HeaderText = "Kode"
                .Columns("kd_ruangan").Width = 80
                .Columns("kd_ruangan").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End If

            If .Columns.Contains("nama_ruangan") Then
                .Columns("nama_ruangan").HeaderText = "Nama Ruangan"
                .Columns("nama_ruangan").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("kapasitas") Then
                .Columns("kapasitas").HeaderText = "Kapasitas"
                .Columns("kapasitas").Width = 100
                .Columns("kapasitas").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Columns("kapasitas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        End With
    End Sub

    ''' <summary>
    ''' Buat instance form input Ruang.
    ''' </summary>
    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputRuang()
    End Function

    ''' <summary>
    ''' Validasi sebelum hapus: cek apakah ada jadwal yang terkait.
    ''' </summary>
    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_jadwal_matkul", "kd_ruangan", recordId) Then
            ShowWarning("Ruang Kelas tidak dapat dihapus karena masih ada Jadwal yang terdaftar!")
            Return False
        End If

        Return True
    End Function
#End Region

End Class
