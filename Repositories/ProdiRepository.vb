Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Prodi.
''' </summary>
Public Class ProdiRepository
    Inherits RepositoryBase(Of ProdiEntity)

    ''' <summary>
    ''' Nama tabel database untuk entitas Prodi.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_prodi"
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key untuk entitas Prodi.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_prodi"
        End Get
    End Property

    ''' <summary>
    ''' Mengambil query SELECT dasar untuk Prodi.
    ''' </summary>
    ''' <returns>String query SQL.</returns>
    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM tbl_prodi ORDER BY kd_prodi DESC"
    End Function

    ''' <summary>
    ''' Memetakan baris data ke entitas Prodi.
    ''' </summary>
    ''' <param name="row">Baris data dari DataTable.</param>
    ''' <returns>Entitas Prodi yang telah dipetakan.</returns>
    Protected Overrides Function MapToEntity(row As DataRow) As ProdiEntity
        Dim entity As New ProdiEntity()
        Try
            entity.Kode = NullToString(row("kd_prodi"))
            entity.NamaProdi = NullToString(row("nama_prodi"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    ''' <summary>
    ''' Mengambil query INSERT untuk Prodi.
    ''' </summary>
    ''' <returns>String query SQL INSERT.</returns>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_prodi (kd_prodi, nama_prodi) VALUES (@id, @nama)"
    End Function

    ''' <summary>
    ''' Mengambil query UPDATE untuk Prodi.
    ''' </summary>
    ''' <returns>String query SQL UPDATE.</returns>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_prodi SET nama_prodi = @nama WHERE kd_prodi = @id"
    End Function

    ''' <summary>
    ''' Menyiapkan parameter MySql dari entitas Prodi.
    ''' </summary>
    ''' <param name="entity">Entitas Prodi.</param>
    ''' <returns>Array MySqlParameter.</returns>
    Protected Overrides Function GetParameters(entity As ProdiEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@nama", entity.NamaProdi)
        }
    End Function
End Class
