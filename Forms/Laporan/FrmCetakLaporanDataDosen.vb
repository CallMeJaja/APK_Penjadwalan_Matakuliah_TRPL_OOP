Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

''' <summary>
''' Form untuk mencetak laporan data dosen.
''' Menyediakan filter berdasarkan jurusan/prodi dan menampilkan hasil dalam Crystal Report.
''' Refactor: Menggunakan SetDataSource (DataTable) sesuai referensi user.
''' </summary>
Public Class FrmCetakLaporanDataDosen

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
    ''' Event handler saat form dimuat.
    ''' </summary>
    Private Sub FrmCetakLaporanDataDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiComboProdi()
    End Sub

    ''' <summary>
    ''' Event handler untuk tombol Cetak Laporan.
    ''' Memvalidasi filter, mengambil data dari database, dan menampilkan report.
    ''' </summary>
    Private Sub BtnCetakLaporanDOsen_Click(sender As Object, e As EventArgs) Handles BtnCetakLaporanDOsen.Click
        Try
            If CbNamaJurusanCetakDosen.SelectedValue.ToString() = "0" Then
                ShowWarning("Silakan pilih jurusan terlebih dahulu!")
                Exit Sub
            End If

            Dim rpt As New rptDosen()
            ConfigureReportConnection(rpt)

            Dim query As String = "SELECT d.kd_dosen, d.kd_prodi, d.nidn_dosen, d.nama_dosen, d.jk_dosen, " &
                                  "d.no_telp_dosen, d.email_dosen, p.nama_prodi " &
                                  "FROM tbl_dosen d " &
                                  "JOIN tbl_prodi p ON d.kd_prodi = p.kd_prodi " &
                                  "WHERE d.kd_prodi = '" & CbNamaJurusanCetakDosen.SelectedValue.ToString() & "'"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        ShowInfo("Data dosen tidak ditemukan untuk jurusan yang dipilih.")
                        Exit Sub
                    End If

                    rpt.SetDataSource(dt)

                    Dim prodiName As String = CbNamaJurusanCetakDosen.Text
                    SetReportParam(rpt, "prmProdi", prodiName)

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
    Private Sub BtnKeluarCetakDosen_Click(sender As Object, e As EventArgs) Handles BtnKeluarCetakDosen.Click
        Me.Close()
    End Sub

End Class