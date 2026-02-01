Imports MySql.Data.MySqlClient

''' <summary>
''' Repository untuk entitas Jadwal Mata Kuliah.
''' </summary>
Public Class JadwalRepository
    Inherits RepositoryBase(Of JadwalEntity)

    ''' <summary>
    ''' Nama tabel database untuk entitas Jadwal.
    ''' </summary>
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_jadwal_matkul"
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key untuk entitas Jadwal.
    ''' </summary>
    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_pengampu"
        End Get
    End Property

    ''' <summary>
    ''' Mengambil query SELECT dasar untuk Jadwal (menggunakan view).
    ''' </summary>
    ''' <returns>String query SQL.</returns>
    Protected Overrides Function GetSelectQuery() As String
        Return "SELECT * FROM vw_jadwal_detail"
    End Function

    ''' <summary>
    ''' Ambil data jadwal dengan filter tertentu.
    ''' </summary>
    ''' <param name="prodi">Nama program studi untuk filter.</param>
    ''' <param name="tipeSmt">Tipe semester (Ganjil/Genap).</param>
    ''' <param name="semester">Nomor semester.</param>
    ''' <param name="tahun">Tahun akademik.</param>
    ''' <param name="search">Kata kunci pencarian.</param>
    ''' <returns>DataTable berisi hasil filter jadwal.</returns>
    Public Function GetAllWithFilters(prodi As String, tipeSmt As String, semester As String, tahun As String, search As String) As DataTable
        Dim query As String = GetSelectQuery() & " WHERE 1=1"
        Dim params As New List(Of MySqlParameter)

        If Not String.IsNullOrEmpty(search) Then
            query &= " AND (d.nama_dosen LIKE @s OR m.nama_matkul LIKE @s OR r.nama_ruangan LIKE @s)"
            params.Add(New MySqlParameter("@s", $"%{search}%"))
        End If

        If Not String.IsNullOrEmpty(prodi) AndAlso prodi <> "Semua Prodi" Then
            query &= " AND nama_prodi = @prodi"
            params.Add(New MySqlParameter("@prodi", prodi))
        End If

        If tipeSmt = "Ganjil" Then
            query &= " AND smt % 2 <> 0"
        ElseIf tipeSmt = "Genap" Then
            query &= " AND smt % 2 = 0"
        End If

        If Not String.IsNullOrEmpty(semester) AndAlso semester <> "Semua Semester" Then
            query &= " AND smt = @smt"
            params.Add(New MySqlParameter("@smt", semester))
        End If

        If Not String.IsNullOrEmpty(tahun) AndAlso tahun <> "Semua Tahun" Then
            query &= " AND tahun_akademik = @tahun"
            params.Add(New MySqlParameter("@tahun", tahun))
        End If
        
        query &= " ORDER BY tahun_akademik DESC, id_hari, jam_mulai ASC"

        Return LoadDataWithParams(query, params.ToArray())
    End Function

    ''' <summary>
    ''' Mengambil query INSERT untuk Jadwal.
    ''' </summary>
    ''' <returns>String query SQL INSERT.</returns>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_jadwal_matkul (kd_pengampu, id_hari, kd_ruangan, jam_awal, jam_akhir) " &
               "VALUES (@kd_p, @hari, @ruang, @awal, @akhir)"
    End Function

    ''' <summary>
    ''' Mengambil query UPDATE untuk Jadwal.
    ''' </summary>
    ''' <returns>String query SQL UPDATE.</returns>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_jadwal_matkul SET id_hari = @hari, kd_ruangan = @ruang, " &
               "jam_awal = @awal, jam_akhir = @akhir WHERE kd_pengampu = @kd_p"
    End Function

    ''' <summary>
    ''' Menyiapkan parameter MySql dari entitas Jadwal.
    ''' </summary>
    ''' <param name="entity">Entitas Jadwal.</param>
    ''' <returns>Array MySqlParameter.</returns>
    Protected Overrides Function GetParameters(entity As JadwalEntity) As MySqlParameter()
        Return {
            New MySqlParameter("@kd_p", entity.Kode),
            New MySqlParameter("@hari", entity.IdHari),
            New MySqlParameter("@ruang", entity.KdRuangan),
            New MySqlParameter("@awal", entity.JamAwal),
            New MySqlParameter("@akhir", entity.JamAkhir)
        }
    End Function

    ''' <summary>
    ''' Memetakan baris data ke entitas Jadwal.
    ''' </summary>
    ''' <param name="row">Baris data dari DataTable.</param>
    ''' <returns>Entitas Jadwal yang telah dipetakan.</returns>
    Protected Overrides Function MapToEntity(row As DataRow) As JadwalEntity
        Dim entity As New JadwalEntity()
        entity.Kode = row("kd_pengampu").ToString()
        entity.IdHari = row("id_hari").ToString()
        entity.KdRuangan = row("kd_ruangan").ToString()

        If row.Table.Columns.Contains("tahun_akademik") Then
            entity.TahunAkademik = row("tahun_akademik").ToString()
        End If
        If row.Table.Columns.Contains("kd_prodi") Then
            entity.KdProdi = row("kd_prodi").ToString()
        End If
        If row.Table.Columns.Contains("kd_dosen") Then
            entity.KdDosen = row("kd_dosen").ToString()
        End If

        If row.Table.Columns.Contains("jam_mulai") AndAlso row("jam_mulai") IsNot DBNull.Value Then
            entity.JamAwal = DirectCast(row("jam_mulai"), TimeSpan)
        ElseIf row.Table.Columns.Contains("jam_awal") AndAlso row("jam_awal") IsNot DBNull.Value Then
            entity.JamAwal = DirectCast(row("jam_awal"), TimeSpan)
        End If

        If row.Table.Columns.Contains("jam_selesai") AndAlso row("jam_selesai") IsNot DBNull.Value Then
            entity.JamAkhir = DirectCast(row("jam_selesai"), TimeSpan)
        ElseIf row.Table.Columns.Contains("jam_akhir") AndAlso row("jam_akhir") IsNot DBNull.Value Then
            entity.JamAkhir = DirectCast(row("jam_akhir"), TimeSpan)
        End If

        Return entity
    End Function

    ''' <summary>
    ''' Memeriksa apakah jadwal yang diajukan bentrok dengan jadwal yang sudah ada.
    ''' </summary>
    ''' <param name="entity">Entitas jadwal yang akan diperiksa.</param>
    ''' <returns>True jika bentrok, False jika aman.</returns>
    Public Function IsBentrok(entity As JadwalEntity) As Boolean
        Dim query As String = "SELECT kd_dosen, tahun_akademik FROM tbl_dosen_pengampu_matkul WHERE kd_pengampu = @id"
        Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, New MySqlParameter("@id", entity.KdPengampu))

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim kdDosen As String = dt.Rows(0)("kd_dosen").ToString()
            Dim tahun As String = dt.Rows(0)("tahun_akademik").ToString()

            Dim msg As String = ModValidasi.CheckJadwalBentrok(entity.IdHari, entity.JamAwal, entity.JamAkhir,
                                                              entity.IdRuangan, kdDosen, tahun, entity.KdPengampu)
            If Not String.IsNullOrEmpty(msg) Then
                ShowWarning(msg)
                Return True
            End If
        End If
        Return False
    End Function
End Class
