Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

''' <summary>
''' Form untuk mencetak laporan data mata kuliah.
''' Menyediakan filter berdasarkan jurusan/prodi dan semester.
''' Refactor: Menggunakan SetDataSource (DataTable) sesuai referensi user.
''' </summary>
Public Class FrmCetakLaporanDataDosenPengampu

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

                    CbNamaJurusanCetakDosen.DataSource = dt
                    CbNamaJurusanCetakDosen.DisplayMember = "nama_prodi"
                    CbNamaJurusanCetakDosen.ValueMember = "kd_prodi"
                    CbNamaJurusanCetakDosen.SelectedIndex = 0
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
        CbSemesterCetakMatkul.Items.Clear()
        CbSemesterCetakMatkul.Items.Add("- PILIH SEMESTER -")
        CbSemesterCetakMatkul.Items.Add("GANJIL")
        CbSemesterCetakMatkul.Items.Add("GENAP")
        CbSemesterCetakMatkul.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Event handler saat form dimuat.
    ''' </summary>
    Private Sub FrmCetakLaporanDataDosenPengampu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiComboProdi()
        IsiComboSemester()
    End Sub

    ''' <summary>
    ''' Event handler untuk tombol Cetak Laporan.
    ''' </summary>
    Private Sub BtnCetakDataMatkul_Click(sender As Object, e As EventArgs) Handles BtnCetakDataMatkul.Click
        Try
            If CbNamaJurusanCetakDosen.SelectedValue.ToString() = "0" Then
                ShowWarning("Silakan pilih jurusan terlebih dahulu!")
                Exit Sub
            End If

            If CbSemesterCetakMatkul.SelectedIndex = 0 Then
                ShowWarning("Silakan pilih semester terlebih dahulu!")
                Exit Sub
            End If

            Dim rpt As New rptMatkul()
            ConfigureReportConnection(rpt)

            Dim query As String = "SELECT m.kd_matkul, m.nama_matkul, " &
                                  "m.sks_matkul AS sks_total, " &
                                  "m.teori_matkul AS sks_teori, " &
                                  "m.praktek_matkul AS sks_praktek, " &
                                  "m.semester_matkul AS semester, " &
                                  "m.kd_prodi, p.nama_prodi " &
                                  "FROM tbl_matakuliah m " &
                                  "JOIN tbl_prodi p ON m.kd_prodi = p.kd_prodi " &
                                  "WHERE m.kd_prodi = '" & CbNamaJurusanCetakDosen.SelectedValue.ToString() & "'"

            Dim semFilter As String = CbSemesterCetakMatkul.Text
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
                        ShowInfo("Data matakuliah tidak ditemukan untuk filter yang dipilih.")
                        Exit Sub
                    End If

                    rpt.SetDataSource(dt)

                    SetReportParam(rpt, "prmProdi", CbNamaJurusanCetakDosen.Text)
                    SetReportParam(rpt, "prmSemester", semFilter)

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
    ''' Event handler untuk tombol Keluar.
    ''' </summary>
    Private Sub BtnKeluarCetakMatkul_Click(sender As Object, e As EventArgs) Handles BtnKeluarCetakMatkul.Click
        Me.Close()
    End Sub

End Class