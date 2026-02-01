''' <summary>
''' Module untuk fungsi-fungsi utility umum.
''' Menyediakan helper functions yang dapat digunakan di seluruh aplikasi.
''' </summary>
Module ModUmum

#Region "String Utilities"

    ''' <summary>
    ''' Convert DBNull atau Nothing ke empty string.
    ''' </summary>
    ''' <param name="value">Object yang akan dikonversi</param>
    ''' <returns>String value atau empty string</returns>
    Public Function NullToString(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return ""
        Return value.ToString()
    End Function

    ''' <summary>
    ''' Convert DBNull atau Nothing ke nilai integer default.
    ''' </summary>
    ''' <param name="value">Object yang akan dikonversi</param>
    ''' <param name="defaultValue">Nilai default jika null</param>
    ''' <returns>Integer value atau default</returns>
    Public Function NullToInt(value As Object, Optional defaultValue As Integer = 0) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then Return defaultValue
        Dim result As Integer
        If Integer.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return defaultValue
    End Function

    ''' <summary>
    ''' Capitalize first letter of each word.
    ''' </summary>
    ''' <param name="value">String yang akan diformat.</param>
    ''' <returns>String dengan huruf kapital di awal setiap kata.</returns>
    Public Function ToTitleCase(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        Return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower())
    End Function

    ''' <summary>
    ''' Truncate string jika melebihi panjang maksimum.
    ''' </summary>
    ''' <param name="value">String yang akan dipotong.</param>
    ''' <param name="maxLength">Panjang maksimum.</param>
    ''' <param name="suffix">Suffix yang ditambahkan jika dipotong.</param>
    ''' <returns>String yang sudah dipotong (jika perlu).</returns>
    Public Function Truncate(value As String, maxLength As Integer, Optional suffix As String = "...") As String
        If String.IsNullOrEmpty(value) OrElse value.Length <= maxLength Then Return value
        Return value.Substring(0, maxLength - suffix.Length) & suffix
    End Function
#End Region

#Region "Date/Time Formatting"
    ''' <summary>
    ''' Format tanggal ke dd/MM/yyyy.
    ''' </summary>
    ''' <param name="dt">Date yang akan diformat.</param>
    ''' <returns>String tanggal format dd/MM/yyyy.</returns>
    Public Function FormatTanggal(dt As Date) As String
        Return dt.ToString("dd/MM/yyyy")
    End Function

    ''' <summary>
    ''' Format tanggal ke format Indonesia (dd MMMM yyyy).
    ''' </summary>
    ''' <param name="dt">Date yang akan diformat.</param>
    ''' <returns>String tanggal format Indonesia.</returns>
    Public Function FormatTanggalPanjang(dt As Date) As String
        Return dt.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
    End Function

    ''' <summary>
    ''' Format waktu ke HH:mm.
    ''' </summary>
    ''' <param name="dt">Date/Time yang akan diformat.</param>
    ''' <returns>String waktu format HH:mm.</returns>
    Public Function FormatWaktu(dt As Date) As String
        Return dt.ToString("HH:mm")
    End Function

    ''' <summary>
    ''' Format waktu ke HH:mm:ss.
    ''' </summary>
    ''' <param name="dt">Date/Time yang akan diformat.</param>
    ''' <returns>String waktu format HH:mm:ss.</returns>
    Public Function FormatWaktuLengkap(dt As Date) As String
        Return dt.ToString("HH:mm:ss")
    End Function

    ''' <summary>
    ''' Format tanggal dan waktu lengkap.
    ''' </summary>
    ''' <param name="dt">Date/Time yang akan diformat.</param>
    ''' <returns>String tanggal-waktu format dd/MM/yyyy HH:mm:ss.</returns>
    Public Function FormatTanggalWaktu(dt As Date) As String
        Return dt.ToString("dd/MM/yyyy HH:mm:ss")
    End Function

    ''' <summary>
    ''' Mendapatkan nama hari dalam bahasa Indonesia.
    ''' </summary>
    ''' <param name="dt">Date yang akan diambil nama harinya.</param>
    ''' <returns>Nama hari dalam bahasa Indonesia (Senin, Selasa, dll).</returns>
    Public Function GetNamaHari(dt As Date) As String
        Return dt.ToString("dddd", New System.Globalization.CultureInfo("id-ID"))
    End Function
#End Region

#Region "Message Dialogs"
    ''' <summary>
    ''' Menampilkan pesan error dengan format standar.
    ''' </summary>
    ''' <param name="message">Pesan error</param>
    ''' <param name="title">Judul dialog (opsional)</param>
    Public Sub ShowError(message As String, Optional title As String = "Error")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Menampilkan pesan sukses dengan format standar.
    ''' </summary>
    ''' <param name="message">Pesan sukses</param>
    ''' <param name="title">Judul dialog (opsional)</param>
    Public Sub ShowSuccess(message As String, Optional title As String = "Sukses")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Menampilkan pesan warning dengan format standar.
    ''' </summary>
    ''' <param name="message">Pesan warning</param>
    ''' <param name="title">Judul dialog (opsional)</param>
    Public Sub ShowWarning(message As String, Optional title As String = "Peringatan")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ''' <summary>
    ''' Menampilkan pesan info dengan format standar.
    ''' </summary>
    ''' <param name="message">Pesan info</param>
    ''' <param name="title">Judul dialog (opsional)</param>
    Public Sub ShowInfo(message As String, Optional title As String = "Informasi")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Menampilkan dialog konfirmasi Yes/No.
    ''' </summary>
    ''' <param name="message">Pesan konfirmasi</param>
    ''' <param name="title">Judul dialog (opsional)</param>
    ''' <returns>True jika Yes, False jika No</returns>
    Public Function ShowConfirm(message As String, Optional title As String = "Konfirmasi") As Boolean
        Dim result As DialogResult = MessageBox.Show(message, title,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)
        Return result = DialogResult.Yes
    End Function

    ''' <summary>
    ''' Menampilkan dialog konfirmasi Yes/No/Cancel.
    ''' </summary>
    ''' <param name="message">Pesan konfirmasi.</param>
    ''' <param name="title">Judul dialog (opsional).</param>
    ''' <returns>DialogResult (Yes, No, atau Cancel).</returns>
    Public Function ShowConfirmCancel(message As String, Optional title As String = "Konfirmasi") As DialogResult
        Return MessageBox.Show(message, title,
                               MessageBoxButtons.YesNoCancel,
                               MessageBoxIcon.Question)
    End Function
#End Region

#Region "Form Utilities"
    ''' <summary>
    ''' Clear semua TextBox dalam sebuah container (Panel, GroupBox, Form).
    ''' </summary>
    ''' <param name="container">Container yang berisi TextBox.</param>
    Public Sub ClearTextBoxes(container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Clear()
            ElseIf ctrl.HasChildren Then
                ClearTextBoxes(ctrl)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Reset semua ComboBox ke index 0 dalam sebuah container.
    ''' </summary>
    ''' <param name="container">Container yang berisi ComboBox.</param>
    Public Sub ResetComboBoxes(container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).SelectedIndex = 0
            ElseIf ctrl.HasChildren Then
                ResetComboBoxes(ctrl)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Enable/Disable semua control dalam sebuah container.
    ''' </summary>
    ''' <param name="container">Container yang berisi controls.</param>
    ''' <param name="enabled">True untuk enable, False untuk disable.</param>
    Public Sub SetControlsEnabled(container As Control, enabled As Boolean)
        For Each ctrl As Control In container.Controls
            ctrl.Enabled = enabled
            If ctrl.HasChildren Then
                SetControlsEnabled(ctrl, enabled)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Focus ke control pertama yang enabled dalam container.
    ''' </summary>
    ''' <param name="container">Container yang berisi controls.</param>
    Public Sub FocusFirstControl(container As Control)
        For Each ctrl As Control In container.Controls
            If ctrl.Enabled AndAlso ctrl.CanFocus AndAlso
               (TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox) Then
                ctrl.Focus()
                Exit For
            ElseIf ctrl.HasChildren Then
                FocusFirstControl(ctrl)
            End If
        Next
    End Sub
#End Region

#Region "Numeric Utilities"
    ''' <summary>
    ''' Parse string ke integer dengan default value.
    ''' </summary>
    ''' <param name="value">String yang akan di-parse.</param>
    ''' <param name="defaultValue">Nilai default jika parse gagal.</param>
    ''' <returns>Integer hasil parse atau defaultValue.</returns>
    Public Function ParseInt(value As String, Optional defaultValue As Integer = 0) As Integer
        Dim result As Integer
        If Integer.TryParse(value, result) Then
            Return result
        End If
        Return defaultValue
    End Function

    ''' <summary>
    ''' Parse string ke decimal dengan default value.
    ''' </summary>
    ''' <param name="value">String yang akan di-parse.</param>
    ''' <param name="defaultValue">Nilai default jika parse gagal.</param>
    ''' <returns>Decimal hasil parse atau defaultValue.</returns>
    Public Function ParseDecimal(value As String, Optional defaultValue As Decimal = 0D) As Decimal
        Dim result As Decimal
        If Decimal.TryParse(value, result) Then
            Return result
        End If
        Return defaultValue
    End Function

    ''' <summary>
    ''' Format angka dengan separator ribuan.
    ''' </summary>
    ''' <param name="value">Nilai integer yang akan diformat.</param>
    ''' <returns>String angka dengan separator ribuan.</returns>
    Public Function FormatNumber(value As Integer) As String
        Return value.ToString("N0")
    End Function
#End Region

#Region "ComboBox Utilities"
    ''' <summary>
    ''' Set ComboBox dropdown width berdasarkan konten terpanjang.
    ''' Panggil setelah mengisi ComboBox dengan data.
    ''' </summary>
    ''' <param name="cmb">ComboBox yang akan diatur.</param>
    Public Sub AutoWidthDropDown(cmb As ComboBox)
        If cmb Is Nothing OrElse cmb.Items.Count = 0 Then Exit Sub

        Dim maxWidth As Integer = cmb.Width
        Using g As Graphics = cmb.CreateGraphics()
            For Each item As Object In cmb.Items
                Dim itemText As String = ""
                If TypeOf item Is DataRowView Then
                    If Not String.IsNullOrEmpty(cmb.DisplayMember) Then
                        itemText = CType(item, DataRowView)(cmb.DisplayMember).ToString()
                    Else
                        itemText = item.ToString()
                    End If
                Else
                    itemText = item.ToString()
                End If
                Dim itemWidth As Integer = CInt(g.MeasureString(itemText, cmb.Font).Width) + 30
                If itemWidth > maxWidth Then maxWidth = itemWidth
            Next
        End Using

        cmb.DropDownWidth = maxWidth
    End Sub

    ''' <summary>
    ''' Set ComboBox width berdasarkan item yang DIPILIH saat ini.
    ''' Panggil di event SelectedIndexChanged untuk resize otomatis.
    ''' </summary>
    ''' <param name="cmb">ComboBox yang akan diatur.</param>
    ''' <param name="minWidth">Lebar minimum.</param>
    ''' <param name="maxWidth">Lebar maksimum.</param>
    Public Sub AutoWidthComboBox(cmb As ComboBox, Optional minWidth As Integer = 100, Optional maxWidth As Integer = 400)
        If cmb Is Nothing Then Exit Sub

        Dim selectedText As String = ""

        If cmb.SelectedIndex >= 0 Then
            If cmb.SelectedItem IsNot Nothing Then
                If TypeOf cmb.SelectedItem Is DataRowView Then
                    If Not String.IsNullOrEmpty(cmb.DisplayMember) Then
                        selectedText = CType(cmb.SelectedItem, DataRowView)(cmb.DisplayMember).ToString()
                    Else
                        selectedText = cmb.SelectedItem.ToString()
                    End If
                Else
                    selectedText = cmb.SelectedItem.ToString()
                End If
            End If
        Else
            selectedText = cmb.Text
        End If

        Dim requiredWidth As Integer = minWidth
        If Not String.IsNullOrEmpty(selectedText) Then
            Using g As Graphics = cmb.CreateGraphics()
                requiredWidth = CInt(g.MeasureString(selectedText, cmb.Font).Width) + 35
            End Using
        End If

        If requiredWidth < minWidth Then requiredWidth = minWidth
        If requiredWidth > maxWidth Then requiredWidth = maxWidth

        cmb.Width = requiredWidth
    End Sub
#End Region

End Module
