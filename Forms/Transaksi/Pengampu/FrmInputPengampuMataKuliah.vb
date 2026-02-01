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
        Dim query As String = "SELECT p.*, d.nama_dosen, d.nidn_dosen, m.nama_matkul, m.sks_matkul, m.teori_matkul, m.praktek_matkul, m.semester_matkul " &
                              "FROM tbl_dosen_pengampu_matkul p " &
                              "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                              "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                              "WHERE kd_pengampu = @id"
        
        Dim dt As DataTable = ModDbCrud.LoadDataWithParams(query, New MySqlParameter("@id", RecordId))
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            txtKodePengampu.Text = row("kd_pengampu").ToString()
            
            _kdDosen = row("kd_dosen").ToString()
            txtCariDosen.Text = row("nama_dosen").ToString()
            txtNidn.Text = row("nidn_dosen").ToString()
            txtNamaDosen.Text = row("nama_dosen").ToString()
            
            _kdMatkul = row("kd_matkul").ToString()
            txtCariMatkul.Text = row("nama_matkul").ToString()
            txtKodeMatkul.Text = _kdMatkul
            txtNamaMatkul.Text = row("nama_matkul").ToString()
            txtTotalSKS.Text = row("sks_matkul").ToString()
            txtSKSTeori.Text = row("teori_matkul").ToString()
            txtSKSPraktek.Text = row("praktek_matkul").ToString()
            txtSemester.Text = row("semester_matkul").ToString()

            txtTahunAkademik.Text = row("tahun_akademik").ToString()
            cmbJenisKelas.SelectedItem = row("nama_kelas").ToString()
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
        if e.KeyCode = Keys.Enter Then
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

    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_dosen_pengampu_matkul (kd_pengampu, kd_dosen, kd_matkul, nama_kelas, tahun_akademik) " &
               "VALUES (@id, @dosen, @matkul, @kelas, @tahun)"
    End Function

    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_dosen_pengampu_matkul SET kd_dosen = @dosen, kd_matkul = @matkul, " &
               "nama_kelas = @kelas, tahun_akademik = @tahun WHERE kd_pengampu = @id"
    End Function

    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Return {
            New MySqlParameter("@id", txtKodePengampu.Text.Trim()),
            New MySqlParameter("@dosen", _kdDosen),
            New MySqlParameter("@matkul", _kdMatkul),
            New MySqlParameter("@kelas", cmbJenisKelas.Text),
            New MySqlParameter("@tahun", txtTahunAkademik.Text.Trim())
        }
    End Function
End Class
