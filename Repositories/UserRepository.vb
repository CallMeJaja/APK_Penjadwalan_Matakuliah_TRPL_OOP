Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity User.
''' </summary>
Public Class UserRepository
    Inherits RepositoryBase(Of UserEntity)

    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_user"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_user"
        End Get
    End Property

    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM tbl_user ORDER BY id_user DESC"
    End Function

    Protected Overrides Function MapToEntity(row As DataRow) As UserEntity
        Dim entity As New UserEntity()
        Try
            entity.Kode = NullToString(row("id_user"))
            entity.NamaUser = NullToString(row("nama_user"))
            entity.LevelUser = NullToString(row("level_user"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_user (id_user, nama_user, pass_user, level_user) " &
               "VALUES (@id, @nama, @pass, @level)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_user SET nama_user = @nama, " &
               "pass_user = IF(@pass = '' OR @pass IS NULL, pass_user, @pass), " &
               "level_user = @level WHERE id_user = @id"
    End Function

    Protected Overrides Function GetParameters(entity As UserEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaUser),
            New MySqlParameter("@pass", If(entity.PassUser, "")),
            New MySqlParameter("@level", entity.LevelUser)
        }
    End Function

End Class
