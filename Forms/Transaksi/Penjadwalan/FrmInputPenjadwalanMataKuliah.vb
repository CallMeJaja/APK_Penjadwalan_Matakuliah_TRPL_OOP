Imports MySql.Data.MySqlClient
''' <summary>
''' Form input untuk data Penjadwalan Mata Kuliah.
''' Menangani mode tambah dan ubah jadwal dengan integrasi JadwalRepository.
''' </summary>
Public Class FrmInputPenjadwalanMataKuliah
    Inherits FrmBaseInput

    Private _kdPengampu As String = ""
    Private _kdDosen As String = ""
    Private _namaKelas As String = ""
    Private _tahunAkademik As String = ""
    Private _idHari As String = ""
    Private _idRuangan As String = ""
    Private _idTahunAkademik As String = ""

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi awal form, setup control, dan load data jika dalam mode edit.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        lblJudul.Text = If(IsEditMode, "UBAH JADWAL MATA KULIAH", "TAMBAH JADWAL MATA KULIAH")

        txtKodeDosen.ReadOnly = True
        txtNidn.ReadOnly = True
        txtNamaDosen.ReadOnly = True
        txtKodeMatkul.ReadOnly = True
        txtNamaMatkul.ReadOnly = True
        txtTotalSks.ReadOnly = True
        txtSksTeori.ReadOnly = True
        txtSksPraktek.ReadOnly = True
        txtSemester.ReadOnly = True

        IsiComboBox(cmbProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi", "nama_prodi", "kd_prodi")
        AutoWidthDropDown(cmbProdi)

        cmbTipeSemester.Items.Clear()
        cmbTipeSemester.Items.AddRange({"Ganjil", "Genap"})
        cmbTipeSemester.SelectedIndex = 0

        IsiComboBox(cmbTahunAkademik, "SELECT DISTINCT tahun_akademik, tahun_akademik as kd_tahun FROM tbl_dosen_pengampu_matkul ORDER BY tahun_akademik DESC", "tahun_akademik", "kd_tahun")

        IsiComboBox(cmbRuangan, "SELECT kd_ruangan, nama_ruangan FROM tbl_ruangkelas", "nama_ruangan", "kd_ruangan")
        AutoWidthDropDown(cmbRuangan)

        IsiComboBox(cmbHari, "SELECT id_hari, nama_hari FROM tbl_hari ORDER BY id_hari", "nama_hari", "id_hari")

        dtpJamMulai.Format = DateTimePickerFormat.Time
        dtpJamMulai.ShowUpDown = True
        dtpJamMulai.Value = DateTime.Today.AddHours(8)

        dtpJamSelesai.Format = DateTimePickerFormat.Time
        dtpJamSelesai.ShowUpDown = True
        dtpJamSelesai.Value = DateTime.Today.AddHours(10)
        dtpJamSelesai.Enabled = False

        If IsEditMode OrElse Not String.IsNullOrEmpty(RecordId) Then
            LoadFormData()
        End If
    End Sub

    ''' <summary>
    ''' Setup handler tambahan untuk form.
    ''' </summary>
    Protected Overrides Sub SetupForm()
        AddHandler dtpJamMulai.ValueChanged, AddressOf HitungJamSelesai
    End Sub
#End Region

#Region "Load Data (Edit Mode)"
    ''' <summary>
    ''' Memuat data jadwal atau pengampu ke dalam form.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim repo As New JadwalRepository()
        Dim j As JadwalEntity = repo.GetById(RecordId)

        If j IsNot Nothing Then
            _idHari = j.IdHari
            _idRuangan = j.IdRuangan
            _kdPengampu = j.KdPengampu
            _idTahunAkademik = j.IdTahunAkademik

            dtpJamMulai.Value = DateTime.Today.Add(j.JamAwal)
            dtpJamSelesai.Value = DateTime.Today.Add(j.JamAkhir)

            Dim query As String = "SELECT p.kd_pengampu, p.kd_dosen, p.kd_matkul, p.nama_kelas, p.tahun_akademik, " &
                                  "d.nama_dosen, d.nidn_dosen, m.nama_matkul, m.sks_matkul, m.teori_matkul, " &
                                  "m.praktek_matkul, m.semester_matkul, m.kd_prodi " &
                                  "FROM tbl_dosen_pengampu_matkul p " &
                                  "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                                  "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                                  "WHERE p.kd_pengampu = @id"

            ' Ambil detail pengampu menggunakan field dari JadwalEntity
            Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, New MySqlParameter("@id", _kdPengampu))

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                _kdDosen = row("kd_dosen").ToString()
                _namaKelas = row("nama_kelas").ToString()
                _tahunAkademik = row("tahun_akademik").ToString()

                SetComboBoxValue(cmbProdi, row("kd_prodi").ToString())
                SetComboBoxValue(cmbTahunAkademik, _tahunAkademik)

                Dim smt As Integer = ParseInt(row("semester_matkul").ToString())
                cmbTipeSemester.SelectedIndex = If(smt Mod 2 <> 0, 0, 1)

                If Not String.IsNullOrEmpty(_idRuangan) Then cmbRuangan.SelectedValue = _idRuangan
                If Not String.IsNullOrEmpty(_idHari) Then cmbHari.SelectedValue = _idHari

                txtKodeDosen.Text = row("kd_dosen").ToString()
                txtNidn.Text = row("nidn_dosen").ToString()
                txtNamaDosen.Text = row("nama_dosen").ToString()
                txtKodeMatkul.Text = row("kd_matkul").ToString()
                txtNamaMatkul.Text = row("nama_matkul").ToString()
                txtTotalSks.Text = row("sks_matkul").ToString()
                txtSksTeori.Text = row("teori_matkul").ToString()
                txtSksPraktek.Text = row("praktek_matkul").ToString()
                txtSemester.Text = row("semester_matkul").ToString()
            End If
        End If

        If j Is Nothing AndAlso Not String.IsNullOrEmpty(RecordId) Then
            _kdPengampu = RecordId
            Dim query As String = "SELECT p.kd_pengampu, p.kd_dosen, p.kd_matkul, p.nama_kelas, p.tahun_akademik, " &
                                  "d.nama_dosen, d.nidn_dosen, m.nama_matkul, m.sks_matkul, m.teori_matkul, " &
                                  "m.praktek_matkul, m.semester_matkul, m.kd_prodi " &
                                  "FROM tbl_dosen_pengampu_matkul p " &
                                  "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                                  "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                                  "WHERE p.kd_pengampu = @id"

            Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, New MySqlParameter("@id", _kdPengampu))

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                _kdDosen = row("kd_dosen").ToString()
                _namaKelas = row("nama_kelas").ToString()
                _tahunAkademik = row("tahun_akademik").ToString()

                SetComboBoxValue(cmbProdi, row("kd_prodi").ToString())
                SetComboBoxValue(cmbTahunAkademik, _tahunAkademik)

                Dim smt As Integer = ParseInt(row("semester_matkul").ToString())
                cmbTipeSemester.SelectedIndex = If(smt Mod 2 <> 0, 0, 1)

                txtKodeDosen.Text = row("kd_dosen").ToString()
                txtNidn.Text = row("nidn_dosen").ToString()
                txtNamaDosen.Text = row("nama_dosen").ToString()
                txtKodeMatkul.Text = row("kd_matkul").ToString()
                txtNamaMatkul.Text = row("nama_matkul").ToString()
                txtTotalSks.Text = row("sks_matkul").ToString()
                txtSksTeori.Text = row("teori_matkul").ToString()
                txtSksPraktek.Text = row("praktek_matkul").ToString()
                txtSemester.Text = row("semester_matkul").ToString()

                txtCariPengampu.Text = row("nama_dosen").ToString() & " - " & row("nama_matkul").ToString()
            Else
                _kdPengampu = ""
                ShowWarning("Informasi Pengampu tidak ditemukan di sistem!")
                Return
            End If
        End If

        HitungJamSelesai()
    End Sub
#End Region

#Region "Duration Calculation"
    ''' <summary>
    ''' Menghitung jam selesai secara otomatis berdasarkan total SKS teori dan praktek.
    ''' </summary>
    Private Sub HitungJamSelesai()
        If String.IsNullOrEmpty(txtSksTeori.Text) AndAlso String.IsNullOrEmpty(txtSksPraktek.Text) Then Exit Sub

        Try
            Dim teori As Integer = ParseInt(txtSksTeori.Text)
            Dim praktek As Integer = ParseInt(txtSksPraktek.Text)

            Dim totalMenit As Integer = (teori * 50) + (praktek * 170)

            If totalMenit > 0 Then
                dtpJamSelesai.Value = dtpJamMulai.Value.AddMinutes(totalMenit)
            End If
        Catch ex As Exception
            ' Abaikan error saat perhitungan otomatis
        End Try
    End Sub
#End Region

#Region "Lookup Pengampu"
    ''' <summary>
    ''' Event handler untuk membuka form lookup pemilihan pengampu mata kuliah.
    ''' </summary>
    Private Sub btnCariPengampu_Click(sender As Object, e As EventArgs) Handles btnCariPengampu.Click
        Dim query As String = "SELECT p.kd_pengampu, p.kd_dosen, d.nama_dosen, d.nidn_dosen, " &
                              "p.kd_matkul, m.nama_matkul, m.sks_matkul, m.teori_matkul, m.praktek_matkul, " &
                              "m.semester_matkul, p.nama_kelas, p.tahun_akademik " &
                              "FROM tbl_dosen_pengampu_matkul p " &
                              "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                              "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                              "WHERE 1=1"

        Dim params As New List(Of MySqlParameter)

        If cmbTahunAkademik.SelectedIndex >= 0 Then
            query &= " AND p.tahun_akademik = @tahun"
            params.Add(New MySqlParameter("@tahun", cmbTahunAkademik.Text))
        End If

        query &= " ORDER BY p.kd_pengampu DESC"

        Dim frm As New FrmLookup(query, "PILIH PENGAMPU", "kd_pengampu",
            {"nama_dosen", "nama_matkul", "nama_kelas", "tahun_akademik"}, txtCariPengampu.Text.Trim(), params.ToArray())

        If frm.ShowDialog() = DialogResult.OK Then
            Dim row As DataRowView = frm.SelectedRow
            _kdPengampu = frm.SelectedValue
            _kdDosen = row("kd_dosen").ToString()
            _namaKelas = row("nama_kelas").ToString()
            _tahunAkademik = row("tahun_akademik").ToString()
            _idTahunAkademik = row("tahun_akademik").ToString()

            txtKodeDosen.Text = row("kd_dosen").ToString()
            txtNidn.Text = row("nidn_dosen").ToString()
            txtNamaDosen.Text = row("nama_dosen").ToString()
            txtKodeMatkul.Text = row("kd_matkul").ToString()
            txtNamaMatkul.Text = row("nama_matkul").ToString()
            txtTotalSks.Text = row("sks_matkul").ToString()
            txtSksTeori.Text = row("teori_matkul").ToString()
            txtSksPraktek.Text = row("praktek_matkul").ToString()
            txtSemester.Text = row("semester_matkul").ToString()
            txtCariPengampu.Text = row("nama_dosen").ToString() & " - " & row("nama_matkul").ToString()

            HitungJamSelesai()
        End If
    End Sub

    ''' <summary>
    ''' Mendukung pencarian pengampu dengan menekan tombol Enter.
    ''' </summary>
    Private Sub txtCariPengampu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPengampu.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCariPengampu.PerformClick()
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Validation & Conflict Checks"
    ''' <summary>
    ''' Melakukan validasi input sebelum data disimpan, termasuk pengecekan field wajib.
    ''' </summary>
    ''' <returns>True jika valid, False jika tidak valid.</returns>
    Protected Overrides Function ValidateInput() As Boolean
        If String.IsNullOrEmpty(_kdPengampu) Then
            ShowWarning("Pilih Pengampu Mata Kuliah terlebih dahulu!")
            Return False
        End If

        If Not ValidateRequired(cmbHari, "Hari") Then Return False
        If Not ValidateRequired(cmbRuangan, "Ruangan") Then Return False

        _idHari = cmbHari.SelectedValue.ToString()
        _idRuangan = cmbRuangan.SelectedValue.ToString()

        Dim jadwal As New JadwalEntity()
        Try
            jadwal.IdHari = _idHari
            jadwal.KdRuangan = _idRuangan
            jadwal.KdPengampu = _kdPengampu
            jadwal.JamAwal = dtpJamMulai.Value.TimeOfDay
            jadwal.JamAkhir = dtpJamSelesai.Value.TimeOfDay
            jadwal.IdTahunAkademik = _tahunAkademik

            If IsEditMode Then
                jadwal.IdJadwal = RecordId
            End If

        Catch ex As ArgumentException
            ShowWarning(ex.Message)
            Return False
        End Try

        If Not jadwal.IsValid() Then
            ShowWarning(String.Join(vbCrLf, jadwal.GetValidationErrors()))
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Memeriksa apakah ruangan yang dipilih sudah digunakan pada waktu yang sama.
    ''' </summary>
    ''' <returns>True jika tidak bentrok, False jika bentrok.</returns>
    Private Function CekBentrokRuangan() As Boolean
        Dim query As String = "SELECT j.* FROM tbl_jadwal_matkul j " &
                            "JOIN tbl_dosen_pengampu_matkul p ON j.kd_pengampu = p.kd_pengampu " &
                            "WHERE j.kd_ruangan = @ruang AND j.id_hari = @hari " &
                            "AND p.tahun_akademik = @tahun " &
                            "AND ((j.jam_awal < @akhir AND j.jam_akhir > @awal))"

        Dim params As MySqlParameter() = {
            New MySqlParameter("@ruang", cmbRuangan.SelectedValue),
            New MySqlParameter("@hari", cmbHari.SelectedValue),
            New MySqlParameter("@tahun", _tahunAkademik),
            New MySqlParameter("@awal", dtpJamMulai.Value.TimeOfDay),
            New MySqlParameter("@akhir", dtpJamSelesai.Value.TimeOfDay)
        }

        If IsEditMode Then
            query &= " AND j.kd_pengampu <> @recordId"
            Array.Resize(params, params.Length + 1)
            params(params.Length - 1) = New MySqlParameter("@recordId", RecordId)
        End If

        Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, params)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ShowWarning("Jadwal bentrok! Ruangan sudah digunakan pada waktu tersebut.")
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Memeriksa apakah dosen yang bertugas sudah memiliki jadwal lain pada waktu yang sama.
    ''' </summary>
    ''' <returns>True jika tidak bentrok, False jika bentrok.</returns>
    Private Function CekBentrokDosen() As Boolean
        If String.IsNullOrEmpty(_kdDosen) Then Return True

        Dim query As String = "SELECT j.* FROM tbl_jadwal_matkul j " &
                            "JOIN tbl_dosen_pengampu_matkul p ON j.kd_pengampu = p.kd_pengampu " &
                            "WHERE p.kd_dosen = @dosen AND j.id_hari = @hari " &
                            "AND p.tahun_akademik = @tahun " &
                            "AND ((j.jam_awal < @akhir AND j.jam_akhir > @awal))"

        Dim params As MySqlParameter() = {
            New MySqlParameter("@dosen", _kdDosen),
            New MySqlParameter("@hari", cmbHari.SelectedValue),
            New MySqlParameter("@tahun", _tahunAkademik),
            New MySqlParameter("@awal", dtpJamMulai.Value.TimeOfDay),
            New MySqlParameter("@akhir", dtpJamSelesai.Value.TimeOfDay)
        }

        If IsEditMode Then
            query &= " AND j.kd_pengampu <> @recordId"
            Array.Resize(params, params.Length + 1)
            params(params.Length - 1) = New MySqlParameter("@recordId", RecordId)
        End If

        Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, params)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ShowWarning("Jadwal bentrok! Dosen sudah mengajar pada waktu tersebut.")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Override Methods - Save Execution (Repository Pattern)"
    ''' <summary>
    ''' Eksekusi simpan menggunakan JadwalRepository.
    ''' Proses simpan menangani pengecekan bentrok internal di repository.
    ''' </summary>
    ''' <returns>True jika berhasil disimpan, False jika gagal.</returns>
    Protected Overrides Function ExecuteSave() As Boolean
        Dim repo As New JadwalRepository()
        Dim j As New JadwalEntity()
        j.Kode = _kdPengampu
        j.IdHari = _idHari
        j.KdRuangan = _idRuangan
        j.JamAwal = dtpJamMulai.Value.TimeOfDay
        j.JamAkhir = dtpJamSelesai.Value.TimeOfDay

        If repo.IsBentrok(j) Then
            Return False
        End If

        If IsEditMode Then
            Return repo.Update(j)
        Else
            Return repo.Insert(j)
        End If
    End Function
#End Region

End Class
