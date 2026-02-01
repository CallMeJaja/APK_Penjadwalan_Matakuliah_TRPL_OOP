Imports MySql.Data.MySqlClient

Public Class FrmLookup
    Private _sourceTable As DataTable
    Private _filteredView As DataView
    Private _returnColumn As String
    Private _searchColumns As String()
    Private _params As MySqlParameter()

    Public Property SelectedValue As String
    Public Property SelectedRow As DataRowView

    ''' <summary>
    ''' Constructor untuk inisialisasi Lookup Form.
    ''' </summary>
    ''' <param name="query">Query SELECT untuk mengambil data.</param>
    ''' <param name="title">Judul form.</param>
    ''' <param name="returnColumn">Nama kolom yang nilainya akan diambil (SelectedValue).</param>
    ''' <param name="searchColumns">Array nama kolom untuk pencarian.</param>
    ''' <param name="initialSearch">Kata kunci awal untuk pencarian (opsional).</param>
    ''' <param name="params">Array parameter untuk query (opsional).</param>
    Public Sub New(query As String, title As String, returnColumn As String, searchColumns As String(),
                  Optional initialSearch As String = "", Optional params As MySqlParameter() = Nothing)
        InitializeComponent()

        lblHeader.Text = title
        lblInstruksi.Text = $"Cari data berdasarkan {String.Join(" atau ", searchColumns)}..."

        _returnColumn = returnColumn
        _searchColumns = searchColumns
        _params = params

        LoadData(query)

        If Not String.IsNullOrEmpty(initialSearch) Then
            txtCari.Text = initialSearch
            txtCari.SelectionStart = txtCari.Text.Length
        End If
    End Sub

    Private Sub LoadData(query As String)
        Try
            If _params IsNot Nothing AndAlso _params.Length > 0 Then
                _sourceTable = ModDbCrud.LoadDataWithParams(query, _params)
            Else
                _sourceTable = ModDbCrud.LoadData(query)
            End If

            If _sourceTable IsNot Nothing AndAlso _sourceTable.Columns.Count > 0 Then
                _filteredView = New DataView(_sourceTable)
                DataGridView1.DataSource = _filteredView

                With DataGridView1
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .MultiSelect = False
                    .ReadOnly = True
                    .AllowUserToAddRows = False
                    .RowHeadersVisible = False
                End With
            Else
                DataGridView1.DataSource = Nothing
                _filteredView = Nothing
            End If
        Catch ex As Exception
            ShowError($"Gagal memuat data lookup: {ex.Message}")
            _filteredView = Nothing
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If _filteredView Is Nothing Then Exit Sub

        Dim searchText As String = txtCari.Text.Trim()
        If String.IsNullOrEmpty(searchText) Then
            _filteredView.RowFilter = ""
        Else
            Dim conditions As New List(Of String)
            Dim escapedSearch As String = searchText.Replace("'", "''")
            For Each col As String In _searchColumns
                conditions.Add($"[{col}] LIKE '%{escapedSearch}%'")
            Next
            _filteredView.RowFilter = String.Join(" OR ", conditions)
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        txtCari_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub PilihData()
        If DataGridView1.CurrentRow IsNot Nothing Then
            Dim row As DataRowView = CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView)
            
            SelectedRow = row
            SelectedValue = row(_returnColumn).ToString()
            
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        PilihData()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PilihData()
            e.Handled = True
        End If
    End Sub
End Class