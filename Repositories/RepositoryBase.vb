Imports MySql.Data.MySqlClient

''' <summary>
''' Base class abstrak untuk Repository.
''' Menyediakan implementasi umum untuk operasi database.
''' </summary>
Public MustInherit Class RepositoryBase(Of T As Class)
    Implements IRepository(Of T)

#Region "Abstract Properties"
    ''' <summary>
    ''' Nama tabel di database.
    ''' </summary>
    Protected MustOverride ReadOnly Property TableName As String

    ''' <summary>
    ''' Nama kolom primary key.
    ''' </summary>
    Protected MustOverride ReadOnly Property PrimaryKey As String
#End Region

#Region "Abstract Methods"
    ''' <summary>
    ''' Query SELECT untuk mengambil semua data.
    ''' </summary>
    ''' <returns>Query SELECT sebagai String.</returns>
    Protected MustOverride Function GetSelectQuery() As String

    ''' <summary>
    ''' Mengkonversi DataRow ke Entity.
    ''' </summary>
    ''' <param name="row">DataRow dari hasil query.</param>
    ''' <returns>Entity hasil konversi.</returns>
    Protected MustOverride Function MapToEntity(row As DataRow) As T

    ''' <summary>
    ''' Query INSERT untuk menyimpan entity baru (menggunakan parameter).
    ''' </summary>
    ''' <returns>Query INSERT sebagai String.</returns>
    Protected MustOverride Function GetInsertQuery() As String

    ''' <summary>
    ''' Query UPDATE untuk mengupdate entity (menggunakan parameter).
    ''' </summary>
    ''' <returns>Query UPDATE sebagai String.</returns>
    Protected MustOverride Function GetUpdateQuery() As String

    ''' <summary>
    ''' Mendapatkan array parameter untuk Insert/Update.
    ''' </summary>
    ''' <param name="entity">Entity yang akan disimpan/diupdate.</param>
    ''' <returns>Array MySqlParameter untuk query.</returns>
    Protected MustOverride Function GetParameters(entity As T) As MySqlParameter()
#End Region

#Region "IRepository Implementation"
    ''' <summary>
    ''' Mendapatkan semua data entity sebagai List(Of T).
    ''' </summary>
    ''' <returns>List berisi semua entity dari tabel.</returns>
    Public Function GetAll() As List(Of T) Implements IRepository(Of T).GetAll
        Dim result As New List(Of T)

        Try
            Dim dt As DataTable = GetAllDataTable()
            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    result.Add(MapToEntity(row))
                Next
            End If
        Catch ex As Exception
            ShowError("Gagal memuat data: " & ex.Message)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Mendapatkan semua data dalam bentuk DataTable untuk keperluan UI (Filter/Paging).
    ''' </summary>
    ''' <returns>DataTable berisi semua data dari query SELECT.</returns>
    Public Overridable Function GetAllDataTable() As DataTable
        Return LoadData(GetSelectQuery())
    End Function

    ''' <summary>
    ''' Mendapatkan entity berdasarkan ID.
    ''' </summary>
    ''' <param name="id">ID entity yang dicari.</param>
    ''' <returns>Entity jika ditemukan, Nothing jika tidak ada.</returns>
    Public Function GetById(id As String) As T Implements IRepository(Of T).GetById
        Try
            Dim query As String = $"SELECT * FROM {TableName} WHERE {PrimaryKey} = @id"
            Dim dt As DataTable = LoadDataWithParams(query, New MySqlParameter("@id", id))

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return MapToEntity(dt.Rows(0))
            End If
        Catch ex As Exception
            ShowError("Gagal memuat data: " & ex.Message)
        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' Menyimpan entity baru ke database.
    ''' </summary>
    ''' <param name="entity">Entity yang akan disimpan.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Public Function Insert(entity As T) As Boolean Implements IRepository(Of T).Insert
        Try
            Return ExecuteQuery(GetInsertQuery(), GetParameters(entity))
        Catch ex As Exception
            ShowError("Gagal menyimpan data: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Mengupdate entity di database.
    ''' </summary>
    ''' <param name="entity">Entity dengan data yang sudah diupdate.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Public Function Update(entity As T) As Boolean Implements IRepository(Of T).Update
        Try
            Return ExecuteQuery(GetUpdateQuery(), GetParameters(entity))
        Catch ex As Exception
            ShowError("Gagal mengupdate data: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Menghapus entity berdasarkan ID.
    ''' </summary>
    ''' <param name="id">ID entity yang akan dihapus.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Public Function Delete(id As String) As Boolean Implements IRepository(Of T).Delete
        Try
            Dim query As String = $"DELETE FROM {TableName} WHERE {PrimaryKey} = @id"
            BukaKoneksi()

            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", id)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            ShowError("Gagal menghapus data: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Mengecek apakah ID sudah ada di database.
    ''' </summary>
    ''' <param name="id">ID yang akan dicek.</param>
    ''' <returns>True jika ID sudah ada, False jika belum.</returns>
    Public Function Exists(id As String) As Boolean Implements IRepository(Of T).Exists
        Return IsIdExists(TableName, PrimaryKey, id)
    End Function
#End Region

#Region "Helper Methods"
    ''' <summary>
    ''' Helper untuk konversi DBNull ke String.
    ''' </summary>
    ''' <param name="value">Nilai yang akan dikonversi.</param>
    ''' <returns>String kosong jika null/DBNull, otherwise nilai ToString.</returns>
    Protected Function NullToString(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return ""
        Return value.ToString()
    End Function

    ''' <summary>
    ''' Helper untuk konversi DBNull ke Integer.
    ''' </summary>
    ''' <param name="value">Nilai yang akan dikonversi.</param>
    ''' <param name="defaultValue">Nilai default jika konversi gagal.</param>
    ''' <returns>Integer hasil konversi atau defaultValue jika gagal.</returns>
    Protected Function NullToInt(value As Object, Optional defaultValue As Integer = 0) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then Return defaultValue
        Dim result As Integer
        If Integer.TryParse(value.ToString(), result) Then Return result
        Return defaultValue
    End Function
#End Region

End Class

