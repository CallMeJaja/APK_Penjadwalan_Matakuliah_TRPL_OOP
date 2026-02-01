Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Hari.
''' </summary>
Public Class HariRepository
    Inherits RepositoryBase(Of HariEntity)

    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_hari"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_hari"
        End Get
    End Property

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM tbl_hari ORDER BY id_hari"
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As HariEntity
        Dim entity As New HariEntity()
        Try
            entity.Kode = NullToString(row("id_hari"))
            entity.NamaHari = NullToString(row("nama_hari"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_hari (id_hari, nama_hari) VALUES (@id, @nama)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_hari SET nama_hari = @nama WHERE id_hari = @id"
    End Function

    Protected Overrides Function GetParameters(entity As HariEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaHari)
        }
    End Function
End Class
