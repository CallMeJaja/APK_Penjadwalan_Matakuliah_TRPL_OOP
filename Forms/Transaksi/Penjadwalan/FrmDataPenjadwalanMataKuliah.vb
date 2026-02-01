Imports MySql.Data.MySqlClient

Public Class FrmDataPenjadwalanMataKuliah
    Inherits FrmBaseData

    Public Sub New()
        InitializeComponent()
    End Sub

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_jadwal_matkul"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_pengampu"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Penjadwalan"
        End Get
    End Property
#End Region

#Region "Initialization"
    Protected Overrides Sub InitializeFilters()
        IsiComboBox(cmbFilterProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi", "nama_prodi", "kd_prodi", "Semua Prodi")

        cmbFilterTipeSemester.Items.Clear()
        cmbFilterTipeSemester.Items.AddRange({"Semua Tipe", "Ganjil", "Genap"})
        cmbFilterTipeSemester.SelectedIndex = 0

        cmbFilterSemester.Items.Clear()
        cmbFilterSemester.Items.Add("Semua Semester")
        For i As Integer = 1 To 8
            cmbFilterSemester.Items.Add(i.ToString())
        Next
        cmbFilterSemester.SelectedIndex = 0

        IsiComboBox(cmbFilterTahun, "SELECT DISTINCT tahun_akademik FROM tbl_dosen_pengampu_matkul ORDER BY tahun_akademik DESC", "tahun_akademik", "tahun_akademik", "Semua Tahun")

        pnlFilter.Controls.Add(flpFilterSpesifik)
        flpFilterSpesifik.Visible = True

        AddHandler dgvData.CellFormatting, AddressOf dgvData_CellFormatting
    End Sub
#End Region

#Region "Data Loading"
    Public Overrides Sub LoadData()
        Try
            Cursor = Cursors.WaitCursor

            Dim query As String = "SELECT p.kd_pengampu, p.tahun_akademik, h.nama_hari, " &
                                "CASE WHEN (m.semester_matkul % 2) != 0 THEN 'GANJIL' ELSE 'GENAP' END AS tipe_smt, " &
                                "j.jam_awal as jam_mulai, j.jam_akhir as jam_selesai, d.nama_dosen, " &
                                "m.semester_matkul as smt, m.kd_matkul, m.nama_matkul, " &
                                "m.sks_matkul, m.teori_matkul, m.praktek_matkul, r.nama_ruangan, pr.nama_prodi " &
                                "FROM tbl_dosen_pengampu_matkul p " &
                                "INNER JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                                "INNER JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                                "INNER JOIN tbl_prodi pr ON m.kd_prodi = pr.kd_prodi " &
                                "LEFT JOIN tbl_jadwal_matkul j ON p.kd_pengampu = j.kd_pengampu " &
                                "LEFT JOIN tbl_hari h ON j.id_hari = h.id_hari " &
                                "LEFT JOIN tbl_ruangkelas r ON j.kd_ruangan = r.kd_ruangan " &
                                "WHERE 1=1"

            Dim params As New List(Of MySqlParameter)

            If Not String.IsNullOrWhiteSpace(txtCari.Text) Then
                query &= " AND (d.nama_dosen LIKE @search OR m.nama_matkul LIKE @search OR r.nama_ruangan LIKE @search)"
                params.Add(New MySqlParameter("@search", $"%{txtCari.Text.Trim()}%"))
            End If

            If cmbFilterProdi.SelectedIndex > 0 Then
                query &= " AND pr.nama_prodi = @prodi"
                params.Add(New MySqlParameter("@prodi", cmbFilterProdi.Text))
            End If

            If cmbFilterTipeSemester.SelectedIndex = 1 Then
                query &= " AND m.semester_matkul MOD 2 <> 0"
            ElseIf cmbFilterTipeSemester.SelectedIndex = 2 Then
                query &= " AND m.semester_matkul MOD 2 = 0"
            End If

            If cmbFilterSemester.SelectedIndex > 0 Then
                query &= " AND m.semester_matkul = @semester"
                params.Add(New MySqlParameter("@semester", cmbFilterSemester.Text))
            End If

            If cmbFilterTahun.SelectedIndex > 0 Then
                query &= " AND p.tahun_akademik = @tahun"
                params.Add(New MySqlParameter("@tahun", cmbFilterTahun.Text))
            End If

            query &= " ORDER BY p.tahun_akademik DESC, h.nama_hari, j.jam_awal ASC"

            _dataSource = ModDbCrud.LoadDataWithParams(query, params.ToArray())
            
            If _dataSource IsNot Nothing Then
                _totalRecords = _dataSource.Rows.Count
                ApplyFilter()
            Else
                ClearDataGrid()
            End If

        Catch ex As Exception
            ShowError($"Gagal memuat data jadwal: {ex.Message}")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Protected Overrides Sub OpenInputForm(isEditMode As Boolean, recordId As String)
        If dgvData.CurrentRow IsNot Nothing Then
            Dim jamMulai = dgvData.CurrentRow.Cells("jam_mulai").Value
            Dim isBaru = (jamMulai Is DBNull.Value OrElse jamMulai Is Nothing)

            Dim actualMode = If(isBaru, False, isEditMode)
            MyBase.OpenInputForm(actualMode, recordId)
        End If
    End Sub

    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputPenjadwalanMataKuliah()
    End Function

    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()

        With dgvData
            If .ColumnCount > 0 Then
                If .Columns.Contains("kd_pengampu") Then
                    .Columns("kd_pengampu").HeaderText = "KODE PENGAMPU"
                    .Columns("kd_pengampu").Width = 120
                    .Columns("kd_pengampu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Columns("kd_pengampu").DisplayIndex = 1
                End If

                If .Columns.Contains("tahun_akademik") Then
                    .Columns("tahun_akademik").HeaderText = "TA. AKADEMIK"
                    .Columns("tahun_akademik").Width = 100
                    .Columns("tahun_akademik").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("tahun_akademik").DisplayIndex = 2
                End If

                If .Columns.Contains("nama_hari") Then
                    .Columns("nama_hari").HeaderText = "HARI"
                    .Columns("nama_hari").Width = 80
                    .Columns("nama_hari").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("nama_hari").DisplayIndex = 3
                End If

                If .Columns.Contains("tipe_smt") Then
                    .Columns("tipe_smt").HeaderText = "SMT"
                    .Columns("tipe_smt").Width = 80
                    .Columns("tipe_smt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("tipe_smt").DisplayIndex = 4
                End If

                If .Columns.Contains("jam_mulai") Then
                    .Columns("jam_mulai").HeaderText = "JAM AWAL"
                    .Columns("jam_mulai").Width = 90
                    .Columns("jam_mulai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("jam_mulai").DisplayIndex = 5
                End If

                If .Columns.Contains("jam_selesai") Then
                    .Columns("jam_selesai").HeaderText = "JAM AKHIR"
                    .Columns("jam_selesai").Width = 90
                    .Columns("jam_selesai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("jam_selesai").DisplayIndex = 6
                End If

                If .Columns.Contains("nama_dosen") Then
                    .Columns("nama_dosen").HeaderText = "NAMA DOSEN"
                    .Columns("nama_dosen").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns("nama_dosen").MinimumWidth = 150
                    .Columns("nama_dosen").DisplayIndex = 7
                End If

                If .Columns.Contains("smt") Then
                    .Columns("smt").HeaderText = "SMT"
                    .Columns("smt").Width = 50
                    .Columns("smt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("smt").DisplayIndex = 8
                End If

                If .Columns.Contains("kd_matkul") Then
                    .Columns("kd_matkul").HeaderText = "KODE MK"
                    .Columns("kd_matkul").Width = 100
                    .Columns("kd_matkul").DisplayIndex = 9
                End If

                If .Columns.Contains("nama_matkul") Then
                    .Columns("nama_matkul").HeaderText = "NAMA MATAKULIAH"
                    .Columns("nama_matkul").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Columns("nama_matkul").MinimumWidth = 200
                    .Columns("nama_matkul").DisplayIndex = 10
                End If

                If .Columns.Contains("sks_matkul") Then
                    .Columns("sks_matkul").HeaderText = "SKS"
                    .Columns("sks_matkul").Width = 45
                    .Columns("sks_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("sks_matkul").DisplayIndex = 11
                End If

                If .Columns.Contains("teori_matkul") Then
                    .Columns("teori_matkul").HeaderText = "TEORI"
                    .Columns("teori_matkul").Width = 60
                    .Columns("teori_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("teori_matkul").DisplayIndex = 12
                End If

                If .Columns.Contains("praktek_matkul") Then
                    .Columns("praktek_matkul").HeaderText = "PRAKTEK"
                    .Columns("praktek_matkul").Width = 80
                    .Columns("praktek_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("praktek_matkul").DisplayIndex = 13
                End If

                If .Columns.Contains("nama_ruangan") Then
                    .Columns("nama_ruangan").HeaderText = "NAMA RUANG"
                    .Columns("nama_ruangan").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    .Columns("nama_ruangan").MinimumWidth = 150
                    .Columns("nama_ruangan").DisplayIndex = 14
                End If

                If .Columns.Contains("nama_prodi") Then .Columns("nama_prodi").Visible = False
            End If
        End With
    End Sub

    ''' <summary>
    ''' Memberikan warna soft merah pada baris yang belum memiliki jadwal.
    ''' </summary>
    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        
        Dim row As DataGridViewRow = dgvData.Rows(e.RowIndex)
        If row.Cells("jam_mulai").Value Is DBNull.Value OrElse row.Cells("jam_mulai").Value Is Nothing Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230)
        Else
            row.DefaultCellStyle.BackColor = Color.Empty
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub Filter_Changed(sender As Object, e As EventArgs) Handles cmbFilterProdi.SelectedIndexChanged, 
                                                                        cmbFilterTipeSemester.SelectedIndexChanged, 
                                                                        cmbFilterSemester.SelectedIndexChanged, 
                                                                        cmbFilterTahun.SelectedIndexChanged
        If Not _isInternalChange Then LoadData()
    End Sub
#End Region

End Class
