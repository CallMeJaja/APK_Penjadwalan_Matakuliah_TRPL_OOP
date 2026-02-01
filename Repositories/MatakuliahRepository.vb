Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Matakuliah.
''' </summary>
Public Class MatakuliahRepository
    Inherits RepositoryBase(Of MatakuliahEntity)

    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_matakuliah"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_matkul"
        End Get
    End Property

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT m.*, p.nama_prodi FROM tbl_matakuliah m " &
               "LEFT JOIN tbl_prodi p ON m.kd_prodi = p.kd_prodi " &
               "ORDER BY m.kd_matkul DESC"
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As MatakuliahEntity
        Dim entity As New MatakuliahEntity()
        Try
            entity.Kode = NullToString(row("kd_matkul"))
            entity.NamaMatkul = NullToString(row("nama_matkul"))
            entity.TeoriMatkul = NullToInt(row("teori_matkul"))
            entity.PraktekMatkul = NullToInt(row("praktek_matkul"))
            entity.SemesterMatkul = NullToInt(row("semester_matkul"), 1)
            entity.KdProdi = NullToString(row("kd_prodi"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_matakuliah (kd_matkul, nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul, kd_prodi) " &
               "VALUES (@id, @nama, @sks, @teori, @praktek, @semester, @prodi)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_matakuliah SET nama_matkul = @nama, sks_matkul = @sks, teori_matkul = @teori, " &
               "praktek_matkul = @praktek, semester_matkul = @semester, kd_prodi = @prodi " &
               "WHERE kd_matkul = @id"
    End Function

    Protected Overrides Function GetParameters(entity As MatakuliahEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaMatkul),
            New MySqlParameter("@sks", entity.SksMatkul),
            New MySqlParameter("@teori", entity.TeoriMatkul),
            New MySqlParameter("@praktek", entity.PraktekMatkul),
            New MySqlParameter("@semester", entity.SemesterMatkul),
            New MySqlParameter("@prodi", entity.KdProdi)
        }
    End Function
End Class
