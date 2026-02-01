Imports MySql.Data.MySqlClient

Public Class FrmDataPengampuMataKuliah
    Inherits FrmBaseData

    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen_pengampu_matkul"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_pengampu"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Pengampu Mata Kuliah"
        End Get
    End Property

    Protected Overrides ReadOnly Property SearchColumns As String()
        Get
            Return {"kd_pengampu", "nama_dosen", "nama_matkul", "nama_kelas", "tahun_akademik"}
        End Get
    End Property
    
    Protected Overrides Function GetSelectQuery() As String
        Dim query As String = "SELECT p.kd_pengampu, d.kd_dosen, d.nidn_dosen, d.nama_dosen, pr.nama_prodi, " &
                              "m.kd_matkul, m.nama_matkul, m.sks_matkul, m.teori_matkul, m.praktek_matkul, " &
                              "m.semester_matkul, p.tahun_akademik, " &
                              "CASE WHEN (m.semester_matkul % 2) != 0 THEN 'Ganjil' ELSE 'Genap' END AS tipe_semester, " &
                              "p.nama_kelas, d.kd_prodi " &
                              "FROM tbl_dosen_pengampu_matkul p " &
                              "JOIN tbl_dosen d ON p.kd_dosen = d.kd_dosen " &
                              "JOIN tbl_matakuliah m ON p.kd_matkul = m.kd_matkul " &
                              "JOIN tbl_prodi pr ON d.kd_prodi = pr.kd_prodi "

        Return query & "ORDER BY p.tahun_akademik DESC, d.nama_dosen ASC"
    End Function

    Protected Overrides Sub ConfigureGridColumns()
        MyBase.ConfigureGridColumns()
        With dgvData
            If .Columns.Contains("kd_pengampu") Then
                .Columns("kd_pengampu").HeaderText = "Kode"
                .Columns("kd_pengampu").Width = 80
            End If

            If .Columns.Contains("kd_dosen") Then
                .Columns("kd_dosen").HeaderText = "ID Dosen"
                .Columns("kd_dosen").Width = 80
            End If
            If .Columns.Contains("nidn_dosen") Then
                .Columns("nidn_dosen").HeaderText = "NIDN"
                .Columns("nidn_dosen").Width = 100
            End If
            If .Columns.Contains("nama_dosen") Then
                .Columns("nama_dosen").HeaderText = "Dosen Pengampu"
                .Columns("nama_dosen").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            If .Columns.Contains("nama_prodi") Then
                .Columns("nama_prodi").HeaderText = "Program Studi"
                .Columns("nama_prodi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("kd_matkul") Then
                .Columns("kd_matkul").HeaderText = "Kode MK"
                .Columns("kd_matkul").Width = 80
            End If
            If .Columns.Contains("nama_matkul") Then
                .Columns("nama_matkul").HeaderText = "Mata Kuliah"
                .Columns("nama_matkul").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If .Columns.Contains("sks_matkul") Then
                .Columns("sks_matkul").HeaderText = "SKS"
                .Columns("sks_matkul").Width = 40
                .Columns("sks_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("teori_matkul") Then
                .Columns("teori_matkul").HeaderText = "T"
                .Columns("teori_matkul").Width = 30
                .Columns("teori_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("praktek_matkul") Then
                .Columns("praktek_matkul").HeaderText = "P"
                .Columns("praktek_matkul").Width = 30
                .Columns("praktek_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("semester_matkul") Then
                .Columns("semester_matkul").HeaderText = "Smt"
                .Columns("semester_matkul").Width = 40
                .Columns("semester_matkul").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("tahun_akademik") Then
                .Columns("tahun_akademik").HeaderText = "Tahun Akademik"
                .Columns("tahun_akademik").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("tahun_akademik").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("tipe_semester") Then
                .Columns("tipe_semester").HeaderText = "Tipe"
                .Columns("tipe_semester").Width = 60
                .Columns("tipe_semester").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("nama_kelas") Then
                .Columns("nama_kelas").HeaderText = "Kelas"
                .Columns("nama_kelas").Width = 80
                .Columns("nama_kelas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If .Columns.Contains("kd_prodi") Then
                .Columns("kd_prodi").Visible = False
            End If
        End With
    End Sub



    Protected Overrides Sub InitializeFilters()
        IsiComboBox(cmbFilterProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi",
                    "nama_prodi", "kd_prodi", "-- Semua Prodi --")
        AutoWidthDropDown(cmbFilterProdi)

        cmbFilterTipeSemester.Items.Clear()
        cmbFilterTipeSemester.Items.Add("-- Semua --")
        cmbFilterTipeSemester.Items.AddRange({"Ganjil", "Genap"})
        cmbFilterTipeSemester.SelectedIndex = 0
        AutoWidthDropDown(cmbFilterTipeSemester)

        AddHandler cmbFilterProdi.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler cmbFilterTipeSemester.SelectedIndexChanged, AddressOf TipeSemesterChanged
        AddHandler cmbFilterSemester.SelectedIndexChanged, AddressOf FilterChanged

        UpdateSemesterFilter()

        AutoWidthComboBox(cmbFilterProdi)
        AutoWidthComboBox(cmbFilterTipeSemester)
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        If _isInternalChange Then Exit Sub
        ApplyFilter()
        If sender IsNot Nothing AndAlso TypeOf sender Is ComboBox Then
            AutoWidthComboBox(DirectCast(sender, ComboBox))
        End If
    End Sub

    Private Sub TipeSemesterChanged(sender As Object, e As EventArgs)
        If _isInternalChange Then Exit Sub
        UpdateSemesterFilter()
        ApplyFilter()
        AutoWidthComboBox(cmbFilterTipeSemester)
    End Sub

    Private Sub UpdateSemesterFilter()
        cmbFilterSemester.Items.Clear()
        cmbFilterSemester.Items.Add("-- Semua --")

        Select Case cmbFilterTipeSemester.SelectedIndex
            Case 0
                For i As Integer = 1 To 8
                    cmbFilterSemester.Items.Add(i.ToString())
                Next
            Case 1
                cmbFilterSemester.Items.Add("1")
                cmbFilterSemester.Items.Add("3")
                cmbFilterSemester.Items.Add("5")
                cmbFilterSemester.Items.Add("7")
            Case 2
                cmbFilterSemester.Items.Add("2")
                cmbFilterSemester.Items.Add("4")
                cmbFilterSemester.Items.Add("6")
                cmbFilterSemester.Items.Add("8")
        End Select

        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        AutoWidthDropDown(cmbFilterSemester)
    End Sub

    Protected Overrides Function BuildFilterExpression() As String
        Dim filters As New List(Of String)

        Dim baseFilter As String = MyBase.BuildFilterExpression()
        If Not String.IsNullOrEmpty(baseFilter) Then filters.Add($"({baseFilter})")

        If cmbFilterProdi.SelectedIndex > 0 Then
            filters.Add($"kd_prodi = '{cmbFilterProdi.SelectedValue}'")
        End If

        If cmbFilterSemester.SelectedIndex > 0 Then
            Dim semester As String = cmbFilterSemester.SelectedItem.ToString()
            filters.Add($"m.semester_matkul = {semester}")
        ElseIf cmbFilterTipeSemester.SelectedIndex > 0 Then
            Dim tipe As String = cmbFilterTipeSemester.SelectedItem.ToString()
            If tipe = "Ganjil" Then
                filters.Add("m.semester_matkul % 2 <> 0")
            ElseIf tipe = "Genap" Then
                filters.Add("m.semester_matkul % 2 = 0")
            End If
        End If

        Return String.Join(" AND ", filters)
    End Function

    Protected Overrides Sub ResetFiltersAndReload()
        If cmbFilterProdi.Items.Count > 0 Then cmbFilterProdi.SelectedIndex = 0
        If cmbFilterTipeSemester.Items.Count > 0 Then cmbFilterTipeSemester.SelectedIndex = 0
        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        txtCari.Clear()
        MyBase.ResetFiltersAndReload()
    End Sub

    Protected Overrides Function CreateInputForm() As FrmBaseInput
        Return New FrmInputPengampuMataKuliah()
    End Function

    Protected Overrides Function ValidateBeforeDelete(recordId As String) As Boolean
        If HasChildRecords("tbl_jadwal_matkul", "kd_pengampu", recordId) Then
            ShowWarning("Data Pengampu tidak dapat dihapus karena sudah ada Jadwal yang terkait!")
            Return False
        End If
        Return True
    End Function
End Class
