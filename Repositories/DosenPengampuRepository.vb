Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entitas Dosen Pengampu Mata Kuliah.
''' </summary>
Public Class DosenPengampuRepository
    Inherits RepositoryBase(Of PengampuEntity)

    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen_pengampu_matkul"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_pengampu"
        End Get
    End Property

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM vw_pengampu_detail ORDER BY tahun_akademik DESC, nama_dosen ASC"
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_dosen_pengampu_matkul (kd_pengampu, kd_dosen, kd_matkul, nama_kelas, tahun_akademik) " &
               "VALUES (@kd_p, @kd_d, @kd_m, @kelas, @tahun)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_dosen_pengampu_matkul SET kd_dosen = @kd_d, kd_matkul = @kd_m, " &
               "nama_kelas = @kelas, tahun_akademik = @tahun WHERE kd_pengampu = @kd_p"
    End Function

    Protected Overrides Function GetParameters(entity As PengampuEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@kd_p", entity.Kode),
            New MySqlParameter("@kd_d", entity.KdDosen),
            New MySqlParameter("@kd_m", entity.KdMatkul),
            New MySqlParameter("@kelas", entity.NamaKelas),
            New MySqlParameter("@tahun", entity.TahunAkademik)
        }
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As PengampuEntity
        Dim entity As New PengampuEntity()
        entity.Kode = row("kd_pengampu").ToString()
        entity.KdDosen = row("kd_dosen").ToString()
        entity.KdMatkul = row("kd_matkul").ToString()
        entity.NamaKelas = row("nama_kelas").ToString()
        entity.TahunAkademik = row("tahun_akademik").ToString()
        Return entity
    End Function
End Class
