Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

''' <summary>
''' Form untuk mencetak laporan data penjadwalan mata kuliah.
''' Menyediakan filter lengkap: Prodi, Semester, Tahun Akademik, dan Jenis Kelas.
''' Refactor: Menggunakan SetDataSource (DataTable) sesuai referensi user.
''' </summary>
Public Class FrmCetakLaporanDataPenjadwalanMataKuliah

    ''' <summary>
    ''' Mengisi ComboBox Prodi dari database.
    ''' </summary>
    Private Sub IsiComboProdi()
        Try
            Dim sql As String = "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi ASC"
            BukaKoneksi()
            Using cmd As New MySqlCommand(sql, Conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    Dim row As DataRow = dt.NewRow()
                    row("kd_prodi") = "0"
                    row("nama_prodi") = "- PILIH JURUSAN -"
                    dt.Rows.InsertAt(row, 0)

                    cmbProdi.DataSource = dt
                    cmbProdi.DisplayMember = "nama_prodi"
                    cmbProdi.ValueMember = "kd_prodi"
                    cmbProdi.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            ShowError("Gagal memuat data prodi: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    ''' <summary>
    ''' Mengisi ComboBox TA dari tabel transaksi.
    ''' </summary>
    Private Sub IsiComboTA()
        Try
            Dim sql As String = "SELECT DISTINCT tahun_akademik FROM tbl_dosen_pengampu_matkul ORDER BY tahun_akademik DESC"
            BukaKoneksi()
            Using cmd As New MySqlCommand(sql, Conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    Dim row As DataRow = dt.NewRow()
                    row("tahun_akademik") = "- PILIH TA -"
                    dt.Rows.InsertAt(row, 0)

                    cmbTahunAkademik.DataSource = dt
                    cmbTahunAkademik.DisplayMember = "tahun_akademik"
                    cmbTahunAkademik.ValueMember = "tahun_akademik"
                    cmbTahunAkademik.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            ShowError("Gagal memuat data TA: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub IsiNamaSemester()
        cmbNamaSemester.Items.Clear()
        cmbNamaSemester.Items.Add("--- PILIH NAMA SEMESTER ---")
        cmbNamaSemester.Items.Add("Ganjil")
        cmbNamaSemester.Items.Add("Genap")
        cmbNamaSemester.SelectedIndex = 0
    End Sub

    Private Sub IsiJenisKelas()
        cmbJenisKelas.Items.Clear()
        cmbJenisKelas.Items.Add("--- PILIH JENIS KELAS---")
        cmbJenisKelas.Items.Add("Reguler")
        cmbJenisKelas.Items.Add("Karyawan")
        cmbJenisKelas.SelectedIndex = 0
    End Sub

    Private Sub FrmCetakLaporanDataPenjadwalanMataKuliah_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsiComboProdi()
        IsiComboTA()
        IsiJenisKelas()
        IsiNamaSemester()
    End Sub

    Private Function ValidasiInput() As Boolean
        If cmbProdi.SelectedIndex = 0 Or cmbTahunAkademik.SelectedIndex = 0 Or
           cmbNamaSemester.SelectedIndex = 0 Or cmbJenisKelas.SelectedIndex = 0 Then
            ShowWarning("Mohon lengkapi semua kriteria pencarian (Prodi, TA, Semester, dan Kelas).")
            Return False
        End If
        Return True
    End Function

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            If Not ValidasiInput() Then Exit Sub

            Dim rpt As New rptJadwalMatkul()
            ConfigureReportConnection(rpt)

            Dim query As String = "SELECT j.kd_pengampu, d.tahun_akademik, d.nama_kelas as jenis_kelas, " &
                                  "m.nama_matkul, m.kd_matkul, dos.nidn_dosen as nidn, dos.nama_dosen, " &
                                  "h.nama_hari, j.jam_awal as jam_mulai, j.jam_akhir as jam_selesai, j.kd_ruangan, " &
                                  "r.nama_ruangan, pr.nama_prodi, " &
                                  "m.semester_matkul as smt, m.semester_matkul as semester, m.semester_matkul as semester_matkul, " &
                                  "m.sks_matkul as sks_total, m.sks_matkul as sks_matkul " &
                                  "FROM tbl_jadwal_matkul j " &
                                  "INNER JOIN tbl_dosen_pengampu_matkul d ON j.kd_pengampu = d.kd_pengampu " &
                                  "INNER JOIN tbl_matakuliah m ON d.kd_matkul = m.kd_matkul " &
                                  "INNER JOIN tbl_dosen dos ON d.kd_dosen = dos.kd_dosen " &
                                  "INNER JOIN tbl_hari h ON j.id_hari = h.id_hari " &
                                  "INNER JOIN tbl_ruangkelas r ON j.kd_ruangan = r.kd_ruangan " &
                                  "INNER JOIN tbl_prodi pr ON m.kd_prodi = pr.kd_prodi " &
                                  "WHERE pr.nama_prodi = @prodi " &
                                  "AND d.tahun_akademik = @ta " &
                                  "AND d.nama_kelas = @kelas"

            Dim semesterFilter As String = cmbNamaSemester.Text
            If semesterFilter = "Ganjil" Then
                query &= " AND m.semester_matkul % 2 <> 0 "
            ElseIf semesterFilter = "Genap" Then
                query &= " AND m.semester_matkul % 2 = 0 "
            End If

            query &= " ORDER BY h.id_hari ASC, j.jam_awal ASC, m.nama_matkul ASC"

            Dim params As MySqlParameter() = {
                New MySqlParameter("@prodi", cmbProdi.Text),
                New MySqlParameter("@ta", cmbTahunAkademik.Text),
                New MySqlParameter("@kelas", cmbJenisKelas.Text)
            }

            Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, params)

            If dt.Rows.Count = 0 Then
                ShowInfo("Data penjadwalan tidak ditemukan untuk filter yang dipilih.")
                Exit Sub
            End If

            rpt.SetDataSource(dt)

            SetReportParam(rpt, "prmProdi", cmbProdi.Text)
            SetReportParam(rpt, "prmSmt", semesterFilter)
            SetReportParam(rpt, "prmTA", cmbTahunAkademik.Text)
            SetReportParam(rpt, "prmKelas", cmbJenisKelas.Text)

            CrystalReportViewer1.ReportSource = rpt

        Catch ex As Exception
            ShowError("Gagal mencetak laporan: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class