Imports MySql.Data.MySqlClient

Public Class FrmInputPenjadwalanMataKuliah
    Inherits FrmBaseInput

    Private _kdPengampu As String = ""
    Private _kdDosen As String = ""
    Private _namaKelas As String = ""
    Private _tahunAkademik As String = ""

#Region "Override Methods - Initialization"
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

    Protected Overrides Sub SetupForm()
        AddHandler dtpJamMulai.ValueChanged, AddressOf HitungJamSelesai
    End Sub
#End Region

#Region "Load Data (Edit Mode)"
    Protected Overrides Sub LoadFormData()
        Dim query As String = "SELECT p.kd_pengampu, p.kd_dosen, p.kd_matkul, p.nama_kelas, p.tahun_akademik, " &
                              "j.id_hari, j.jam_awal, j.jam_akhir, j.kd_ruangan, " &
                              "d.nama_dosen, d.nidn_dosen, m.nama_matkul, m.sks_matkul, m.teori_matkul, " &
                              "m.praktek_matkul, m.semester_matkul, m.kd_prodi " &
                              "FROM tbl_dosen_pengampu_matkul p " &
                              "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                              "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                              "LEFT JOIN tbl_jadwal_matkul j ON p.kd_pengampu = j.kd_pengampu " &
                              "WHERE p.kd_pengampu = @id"

        Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, New MySqlParameter("@id", RecordId))

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            _kdPengampu = ""
            If Not String.IsNullOrEmpty(RecordId) Then
                ShowWarning("Informasi Pengampu tidak ditemukan di sistem!")
            End If
            Return
        End If

        Dim row As DataRow = dt.Rows(0)

        _kdPengampu = row("kd_pengampu").ToString()
        _kdDosen = row("kd_dosen").ToString()
        _namaKelas = row("nama_kelas").ToString()
        _tahunAkademik = row("tahun_akademik").ToString()

        SetComboBoxValue(cmbProdi, row("kd_prodi").ToString())
        SetComboBoxValue(cmbTahunAkademik, _tahunAkademik)

        Dim smt As Integer = ParseInt(row("semester_matkul").ToString())
        cmbTipeSemester.SelectedIndex = If(smt Mod 2 <> 0, 0, 1)

        If row("kd_ruangan") IsNot DBNull.Value Then cmbRuangan.SelectedValue = row("kd_ruangan").ToString()
        If row("id_hari") IsNot DBNull.Value Then cmbHari.SelectedValue = row("id_hari").ToString()

        If row("jam_awal") IsNot DBNull.Value Then
            dtpJamMulai.Value = DateTime.Today.Add(DirectCast(row("jam_awal"), TimeSpan))
        End If
        If row("jam_akhir") IsNot DBNull.Value Then
            dtpJamSelesai.Value = DateTime.Today.Add(DirectCast(row("jam_akhir"), TimeSpan))
        End If

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
    End Sub
#End Region

#Region "Duration Calculation"
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
            ' Ignore error during calculation
        End Try
    End Sub
#End Region

#Region "Lookup Pengampu"
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

    Private Sub txtCariPengampu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPengampu.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCariPengampu.PerformClick()
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Validation & Conflict Checks"
    Protected Overrides Function ValidateInput() As Boolean
        If String.IsNullOrEmpty(_kdPengampu) Then
            ShowWarning("Pilih Pengampu Mata Kuliah terlebih dahulu!")
            Return False
        End If

        If Not ValidateRequired(cmbHari, "Hari") Then Return False
        If Not ValidateRequired(cmbRuangan, "Ruangan") Then Return False

        Dim jadwal As New JadwalEntity()
        Try
            jadwal.Kode = _kdPengampu
            jadwal.IdHari = cmbHari.SelectedValue.ToString()
            jadwal.KdRuangan = cmbRuangan.SelectedValue.ToString()
            jadwal.JamAwal = dtpJamMulai.Value.TimeOfDay
            jadwal.JamAkhir = dtpJamSelesai.Value.TimeOfDay
        Catch ex As ArgumentException
            ShowWarning(ex.Message)
            Return False
        End Try

        If Not jadwal.IsValid() Then
            ShowWarning(String.Join(vbCrLf, jadwal.GetValidationErrors()))
            Return False
        End If

        If Not CekBentrokRuangan() Then Return False
        If Not CekBentrokDosen() Then Return False

        Return True
    End Function

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

#Region "Query Building"
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_jadwal_matkul (kd_pengampu, id_hari, jam_awal, jam_akhir, kd_ruangan) " &
               "VALUES (@id, @hari, @awal, @akhir, @ruang)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_jadwal_matkul SET id_hari = @hari, jam_awal = @awal, jam_akhir = @akhir, kd_ruangan = @ruang " &
               "WHERE kd_pengampu = @id"
    End Function

    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Return {
            New MySqlParameter("@id", _kdPengampu),
            New MySqlParameter("@hari", cmbHari.SelectedValue),
            New MySqlParameter("@awal", dtpJamMulai.Value.TimeOfDay),
            New MySqlParameter("@akhir", dtpJamSelesai.Value.TimeOfDay),
            New MySqlParameter("@ruang", cmbRuangan.SelectedValue)
        }
    End Function
#End Region

End Class
