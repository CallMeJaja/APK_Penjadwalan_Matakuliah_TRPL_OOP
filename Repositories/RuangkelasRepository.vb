Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Ruangkelas.
''' </summary>
Public Class RuangkelasRepository
    Inherits RepositoryBase(Of RuangkelasEntity)

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

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM tbl_ruangkelas ORDER BY kd_ruangan DESC"
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As RuangkelasEntity
        Dim entity As New RuangkelasEntity()
        Try
            entity.Kode = NullToString(row("kd_ruangan"))
            entity.NamaRuangan = NullToString(row("nama_ruangan"))
            entity.Kapasitas = NullToInt(row("kapasitas"), 30)
        Catch ex As Exception
        End Try
        Return entity
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_ruangkelas (kd_ruangan, nama_ruangan, kapasitas) VALUES (@id, @nama, @kapasitas)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_ruangkelas SET nama_ruangan = @nama, kapasitas = @kapasitas WHERE kd_ruangan = @id"
    End Function

    Protected Overrides Function GetParameters(entity As RuangkelasEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaRuangan),
            New MySqlParameter("@kapasitas", entity.Kapasitas)
        }
    End Function
End Class
