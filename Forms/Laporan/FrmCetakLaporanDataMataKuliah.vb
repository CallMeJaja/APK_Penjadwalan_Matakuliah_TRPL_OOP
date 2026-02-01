Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

''' <summary>
''' Form untuk mencetak laporan data dosen pengampu mata kuliah.
''' Menyediakan filter berdasarkan jurusan/prodi, semester, dan tahun akademik.
''' Refactor: Menggunakan SetDataSource (DataTable) sesuai referensi user.
''' </summary>
Public Class FrmCetakLaporanDataMataKuliah

    ''' <summary>
    ''' Mengisi ComboBox Prodi dengan data dari database.
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

                    CbProdi.DataSource = dt
                    CbProdi.DisplayMember = "nama_prodi"
                    CbProdi.ValueMember = "kd_prodi"
                    CbProdi.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            ShowError("Gagal memuat data prodi: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    ''' <summary>
    ''' Mengisi ComboBox Semester dengan opsi GANJIL dan GENAP.
    ''' </summary>
    Private Sub IsiComboSemester()
        CbSemester.Items.Clear()
        CbSemester.Items.Add("- PILIH SEMESTER -")
        CbSemester.Items.Add("GANJIL")
        CbSemester.Items.Add("GENAP")
        CbSemester.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Mengisi ComboBox Tahun Akademik dengan data unik dari tabel transaksi pengampu.
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

                    CbTa.DataSource = dt
                    CbTa.DisplayMember = "tahun_akademik"
                    CbTa.ValueMember = "tahun_akademik"
                    CbTa.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            ShowError("Gagal memuat data Tahun Akademik: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    ''' <summary>
    ''' Event handler saat form dimuat.
    ''' </summary>
    Private Sub FrmCetakLaporanDataMataKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiComboProdi()
        IsiComboSemester()
        IsiComboTA()
    End Sub

    ''' <summary>
    ''' Event handler untuk tombol Batal.
    ''' </summary>
    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Prosedur utama cetak laporan dengan logic filter dinamis.
    ''' </summary>
    Private Sub CetakLaporan(optional kdDosenFilter as String = "")
        Try
            If CbProdi.SelectedValue.ToString() = "0" Then
                ShowWarning("Silakan pilih jurusan terlebih dahulu!")
                Exit Sub
            End If

            If CbSemester.SelectedIndex = 0 Then
                ShowWarning("Silakan pilih semester terlebih dahulu!")
                Exit Sub
            End If

            If CbTa.SelectedIndex = 0 Then
                ShowWarning("Silakan pilih Tahun Akademik terlebih dahulu!")
                Exit Sub
            End If

            Dim rpt As New rptDosenPengampu()
            ConfigureReportConnection(rpt)

            Dim query As String = "SELECT dpm.kd_pengampu, dpm.kd_dosen, d.nidn_dosen, d.nama_dosen, " &
                                  "dpm.kd_matkul, m.nama_matkul, m.sks_matkul AS sks_total, " &
                                  "m.teori_matkul AS sks_teori, m.praktek_matkul AS sks_praktek, " &
                                  "m.semester_matkul, dpm.nama_kelas AS jenis_kelas, dpm.tahun_akademik, " &
                                  "p.nama_prodi " &
                                  "FROM tbl_dosen_pengampu_matkul dpm " &
                                  "JOIN tbl_dosen d ON dpm.kd_dosen = d.kd_dosen " &
                                  "JOIN tbl_matakuliah m ON dpm.kd_matkul = m.kd_matkul " &
                                  "JOIN tbl_prodi p ON m.kd_prodi = p.kd_prodi " &
                                  "WHERE m.kd_prodi = '" & CbProdi.SelectedValue.ToString() & "' " &
                                  "AND dpm.tahun_akademik = '" & CbTa.Text & "'"

            If Not String.IsNullOrEmpty(kdDosenFilter) Then
                query &= " AND dpm.kd_dosen = '" & kdDosenFilter & "'"
            End If

            Dim semFilter As String = CbSemester.Text
            If semFilter = "GANJIL" Then
                query &= " AND m.semester_matkul % 2 <> 0 "
            ElseIf semFilter = "GENAP" Then
                query &= " AND m.semester_matkul % 2 = 0 "
            End If

            query &= " ORDER BY m.semester_matkul ASC, m.nama_matkul ASC"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        ShowInfo("Data dosen pengampu tidak ditemukan untuk filter yang dipilih.")
                        Exit Sub
                    End If

                    If Not String.IsNullOrEmpty(kdDosenFilter) Then
                        txtNamaDosen.Text = dt.Rows(0)("nama_dosen").ToString()
                        txtNidnDosen.Text = dt.Rows(0)("nidn_dosen").ToString()
                    End If

                    rpt.SetDataSource(dt)

                    SetReportParam(rpt, "prmProdi", CbProdi.Text)
                    SetReportParam(rpt, "prmSemester", semFilter)
                    SetReportParam(rpt, "prmTA", CbTa.Text)

                    CrystalReportViewer1.ReportSource = rpt
                End Using
            End Using

        Catch ex As Exception
            ShowError("Gagal mencetak laporan: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    ''' <summary>
    ''' Tombol cetak per dosen (menggunakan kd_dosen dari textbox).
    ''' </summary>
    Private Sub BtnCetak_Click(sender As Object, e As EventArgs) Handles BtnCetak.Click
        If String.IsNullOrEmpty(txtKdDosen.Text) Then
            ShowWarning("Silahkan isi kode dosen terlebih dahulu!")
            Exit Sub
        End If
        CetakLaporan(txtKdDosen.Text)
    End Sub

    ''' <summary>
    ''' Tombol cetak semua dosen dalam satu TA/Prodi/Semester.
    ''' </summary>
    Private Sub BtnCetakTA_Click(sender As Object, e As EventArgs) Handles BtnCetakTA.Click
        CetakLaporan()
    End Sub

    Private Sub CbTa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbTa.SelectedIndexChanged
        If CbTa.SelectedIndex > 0 Then
            txtTahunAkademik.Text = CbTa.Text
        End If
    End Sub

End Class