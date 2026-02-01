Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entity Dosen.
''' </summary>
Public Class DosenRepository
    Inherits RepositoryBase(Of DosenEntity)

    ''' <summary>
    ''' Nama tabel database untuk entitas Dosen.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen"
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key untuk entitas Dosen.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_dosen"
        End Get
    End Property

    ''' <summary>
    ''' Mengambil query SELECT dasar untuk Dosen dengan JOIN prodi.
    ''' </summary>
    ''' <returns>String query SQL.</returns>
    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT d.*, p.nama_prodi FROM tbl_dosen d " &
               "LEFT JOIN tbl_prodi p ON d.kd_prodi = p.kd_prodi " &
               "ORDER BY d.kd_dosen DESC"
    End Function

    ''' <summary>
    ''' Memetakan baris data ke entitas Dosen.
    ''' </summary>
    ''' <param name="row">Baris data dari DataTable.</param>
    ''' <returns>Entitas Dosen yang telah dipetakan.</returns>
    Protected Overrides Function MapToEntity(row As DataRow) As DosenEntity
        Dim entity As New DosenEntity()
        Try
            entity.Kode = NullToString(row("kd_dosen"))
            entity.KdProdi = NullToString(row("kd_prodi"))
            entity.NidnDosen = NullToString(row("nidn_dosen"))
            entity.NamaDosen = NullToString(row("nama_dosen"))
            entity.JkDosen = NullToString(row("jk_dosen"))
            entity.NoTelpDosen = NullToString(row("no_telp_dosen"))
            entity.EmailDosen = NullToString(row("email_dosen"))
        Catch ex As Exception
        End Try
        Return entity
    End Function

    ''' <summary>
    ''' Mengambil query INSERT untuk Dosen.
    ''' </summary>
    ''' <returns>String query SQL INSERT.</returns>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_dosen (kd_dosen, kd_prodi, nidn_dosen, nama_dosen, jk_dosen, no_telp_dosen, email_dosen) " &
               "VALUES (@id, @prodi, @nidn, @nama, @jk, @telp, @email)"
    End Function

    ''' <summary>
    ''' Mengambil query UPDATE untuk Dosen.
    ''' </summary>
    ''' <returns>String query SQL UPDATE.</returns>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_dosen SET kd_prodi = @prodi, nidn_dosen = @nidn, nama_dosen = @nama, " &
               "jk_dosen = @jk, no_telp_dosen = @telp, email_dosen = @email " &
               "WHERE kd_dosen = @id"
    End Function

    ''' <summary>
    ''' Menyiapkan parameter MySql dari entitas Dosen.
    ''' </summary>
    ''' <param name="entity">Entitas Dosen.</param>
    ''' <returns>Array MySqlParameter.</returns>
    Protected Overrides Function GetParameters(entity As DosenEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@id", entity.Kode),
            New MySqlParameter("@prodi", entity.KdProdi),
            New MySqlParameter("@nidn", entity.NidnDosen),
            New MySqlParameter("@nama", entity.NamaDosen),
            New MySqlParameter("@jk", entity.JkDosen),
            New MySqlParameter("@telp", entity.NoTelpDosen),
            New MySqlParameter("@email", entity.EmailDosen)
        }
    End Function

    ''' <summary>
    ''' Filter dosen berdasarkan prodi.
    ''' </summary>
    ''' <param name="kdProdi">Kode prodi untuk filter.</param>
    ''' <returns>List berisi dosen yang sesuai filter.</returns>
    Public Function GetByProdi(kdProdi As String) As List(Of DosenEntity)
        Dim result As New List(Of DosenEntity)

        Try
            Dim query As String = "SELECT d.*, p.nama_prodi FROM tbl_dosen d " &
                                 "LEFT JOIN tbl_prodi p ON d.kd_prodi = p.kd_prodi " &
                                 "WHERE d.kd_prodi = @prodi " &
                                 "ORDER BY d.kd_dosen DESC"
            
            Dim dt As DataTable = LoadDataWithParams(query, New MySqlParameter("@prodi", kdProdi))
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
End Class
