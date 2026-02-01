Imports MySql.Data.MySqlClient

Public Class FrmInputPengampuMataKuliah
    Inherits FrmBaseInput

    Private _kdDosen As String = ""
    Private _kdMatkul As String = ""

    Protected Overrides Sub InitializeForm()
        lblJudul.Text = If(IsEditMode, "UBAH PENGAMPU MATA KULIAH", "TAMBAH PENGAMPU MATA KULIAH")

        txtKodePengampu.ReadOnly = True
        txtNidn.ReadOnly = True
        txtNamaDosen.ReadOnly = True
        txtKodeMatkul.ReadOnly = True
        txtNamaMatkul.ReadOnly = True
        txtTotalSKS.ReadOnly = True
        txtSKSTeori.ReadOnly = True
        txtSKSPraktek.ReadOnly = True
        txtSemester.ReadOnly = True

        ModDbCrud.IsiComboBox(cmbProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi", "nama_prodi", "kd_prodi")
        AutoWidthDropDown(cmbProdi)
        
        txtTahunAkademik.Text = "2024/2025"
        
        cmbTipeSemester.Items.AddRange({"Ganjil", "Genap"})
        cmbTipeSemester.SelectedIndex = 0

        cmbJenisKelas.Items.Clear()
        cmbJenisKelas.Items.AddRange({"Reguler", "Karyawan"})
        cmbJenisKelas.SelectedIndex = 0

        If IsEditMode Then
            LoadFormData()
        Else
            txtKodePengampu.Text = ModAutoId.GenerateKodePengampu()
        End If
    End Sub

    Protected Overrides Sub LoadFormData()
        ' Ambil data via Repository
        Dim repo As New DosenPengampuRepository()
        Dim d As PengampuEntity = repo.GetById(RecordId)

        If d IsNot Nothing Then
            txtKodePengampu.Text = d.Kode
            _kdDosen = d.KdDosen
            _kdMatkul = d.KdMatkul
            txtTahunAkademik.Text = d.TahunAkademik
            cmbJenisKelas.SelectedItem = d.NamaKelas

            ' Ambil detail Dosen & Matkul untuk display (menggunakan modDatabase)
            Dim dtDosen As DataTable = ModDbCrud.LoadDataWithParams("SELECT nama_dosen, nidn_dosen FROM tbl_dosen WHERE kd_dosen = @id", New MySqlParameter("@id", d.KdDosen))
            If dtDosen.Rows.Count > 0 Then
                txtCariDosen.Text = dtDosen.Rows(0)("nama_dosen").ToString()
                txtNidn.Text = dtDosen.Rows(0)("nidn_dosen").ToString()
                txtNamaDosen.Text = dtDosen.Rows(0)("nama_dosen").ToString()
            End If

            Dim dtMatkul As DataTable = ModDbCrud.LoadDataWithParams("SELECT nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul FROM tbl_matakuliah WHERE kd_matkul = @id", New MySqlParameter("@id", d.KdMatkul))
            If dtMatkul.Rows.Count > 0 Then
                Dim rowM = dtMatkul.Rows(0)
                txtCariMatkul.Text = rowM("nama_matkul").ToString()
                txtKodeMatkul.Text = d.KdMatkul
                txtNamaMatkul.Text = rowM("nama_matkul").ToString()
                txtTotalSKS.Text = rowM("sks_matkul").ToString()
                txtSKSTeori.Text = rowM("teori_matkul").ToString()
                txtSKSPraktek.Text = rowM("praktek_matkul").ToString()
                txtSemester.Text = rowM("semester_matkul").ToString()
            End If
        End If
    End Sub

    Private Sub btnCariDosen_Click(sender As Object, e As EventArgs) Handles btnCariDosen.Click
        Dim query As String = "SELECT kd_dosen, nama_dosen, nidn_dosen, kd_prodi FROM tbl_dosen"
        Dim frm As New FrmLookup(query, "TENTUKAN DOSEN", "kd_dosen", {"nama_dosen", "nidn_dosen", "kd_dosen"}, txtCariDosen.Text.Trim())

        If frm.ShowDialog() = DialogResult.OK Then
            Dim row As DataRowView = frm.SelectedRow
            _kdDosen = frm.SelectedValue
            txtCariDosen.Text = row("nama_dosen").ToString()
            txtNidn.Text = row("nidn_dosen").ToString()
            txtNamaDosen.Text = row("nama_dosen").ToString()

            If cmbProdi.SelectedIndex <= 0 Then
                cmbProdi.SelectedValue = row("kd_prodi").ToString()
            End If
        End If
    End Sub

    Private Sub txtCariDosen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariDosen.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCariDosen.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub btnCariMatkul_Click(sender As Object, e As EventArgs) Handles btnCariMatkul.Click
        Dim query As String = "SELECT kd_matkul, nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul FROM tbl_matakuliah"
        Dim frm As New FrmLookup(query, "TENTUKAN MATA KULIAH", "kd_matkul", {"nama_matkul", "kd_matkul"}, txtCariMatkul.Text.Trim())

        If frm.ShowDialog() = DialogResult.OK Then
            Dim row As DataRowView = frm.SelectedRow
            _kdMatkul = frm.SelectedValue
            txtCariMatkul.Text = row("nama_matkul").ToString()
            txtKodeMatkul.Text = row("kd_matkul").ToString()
            txtNamaMatkul.Text = row("nama_matkul").ToString()
            txtTotalSKS.Text = row("sks_matkul").ToString()
            txtSKSTeori.Text = row("teori_matkul").ToString()
            txtSKSPraktek.Text = row("praktek_matkul").ToString()
            txtSemester.Text = row("semester_matkul").ToString()
        End If
    End Sub

    Private Sub txtCariMatkul_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariMatkul.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCariMatkul.PerformClick()
            e.Handled = True
        End If
    End Sub

    Protected Overrides Function ValidateInput() As Boolean
        Dim pengampu As New PengampuEntity()

        Try
            pengampu.Kode = txtKodePengampu.Text.Trim()
            pengampu.KdDosen = _kdDosen
            pengampu.KdMatkul = _kdMatkul
            pengampu.NamaKelas = cmbJenisKelas.Text
            pengampu.TahunAkademik = txtTahunAkademik.Text.Trim()
        Catch ex As ArgumentException
            ShowWarning(ex.Message)
            Return False
        End Try

        If Not pengampu.IsValid() Then
            ShowWarning(String.Join(vbCrLf, pengampu.GetValidationErrors()))
            Return False
        End If

        Dim condition As String = "kd_dosen = @dosen AND kd_matkul = @matkul AND nama_kelas = @kelas AND tahun_akademik = @tahun"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@dosen", _kdDosen),
            New MySqlParameter("@matkul", _kdMatkul),
            New MySqlParameter("@kelas", cmbJenisKelas.Text),
            New MySqlParameter("@tahun", txtTahunAkademik.Text.Trim())
        }

        If IsEditMode Then
            condition &= " AND kd_pengampu <> @id"
            params.Add(New MySqlParameter("@id", RecordId))
        End If

        If ModValidasi.IsDuplicate("tbl_dosen_pengampu_matkul", condition, params.ToArray()) Then
            ShowWarning("Data Pengampu ini sudah ada (Dosen, Matkul, Kelas, dan Tahun Akademik yang sama)!")
            Return False
        End If

        Return True
    End Function

#Region "Override Methods - Save Execution (Repository Pattern)"
    ''' <summary>
    ''' Eksekusi simpan menggunakan DosenPengampuRepository.
    ''' </summary>
    Protected Overrides Function ExecuteSave() As Boolean
        Dim repo As New DosenPengampuRepository()
        Dim p As PengampuEntity = New PengampuEntity()
        p.Kode = txtKodePengampu.Text.Trim()
        p.KdDosen = _kdDosen
        p.KdMatkul = _kdMatkul
        p.NamaKelas = cmbJenisKelas.Text
        p.TahunAkademik = txtTahunAkademik.Text.Trim()

        If IsEditMode Then
            Return repo.Update(p)
        Else
            Return repo.Insert(p)
        End If
    End Function
#End Region

#Region "Override Methods - Query (Removed in favor of Repository)"
    ' Logika SQL dipindahkan ke DosenPengampuRepository.vb
#End Region
End Class
