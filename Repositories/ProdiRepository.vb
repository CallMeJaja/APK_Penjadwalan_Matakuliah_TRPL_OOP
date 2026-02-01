Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Prodi.
''' </summary>
Public Class ProdiRepository
    Inherits RepositoryBase(Of ProdiEntity)

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

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM tbl_prodi ORDER BY kd_prodi DESC"
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As ProdiEntity
        Dim entity As New ProdiEntity()
        Try
            entity.Kode = NullToString(row("kd_prodi"))
            entity.NamaProdi = NullToString(row("nama_prodi"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_prodi (kd_prodi, nama_prodi) VALUES (@id, @nama)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_prodi SET nama_prodi = @nama WHERE kd_prodi = @id"
    End Function

    Protected Overrides Function GetParameters(entity As ProdiEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaProdi)
        }
    End Function
End Class
