Public Class FrmMenuUtama
    Private Sub FrmMenuUtama_Load(sender As Object, e As EventArgs) Handles Me.Load
        BukaKoneksi()
        ApplySecuritySettings()
    End Sub

    ''' <summary>
    ''' Menerapkan pengaturan keamanan (Role-Based Access Control) pada Menu.
    ''' </summary>
    Public Sub ApplySecuritySettings()
        Dim loggedIn As Boolean = IsLoggedIn()
        Dim isAdminRole As Boolean = IsAdmin()
        Dim isDosenRole As Boolean = IsDosen()

        LoginToolStripMenuItem.Enabled = Not loggedIn
        LogoutToolStripMenuItem.Enabled = loggedIn

        MasterToolStripMenuItem.Visible = isAdminRole
        TransaksiToolStripMenuItem.Visible = isAdminRole

        LaporanToolStripMenuItem.Visible = isAdminRole OrElse isDosenRole
        BantuanToolStripMenuItem.Visible = isAdminRole OrElse isDosenRole

        If loggedIn Then
            ToolStripStatusLabel1.Text = "User: " & CurrentUserName & " | Level: " & CurrentLevel & " | Host: " & Server & ":" & Port
        Else
            ToolStripStatusLabel1.Text = "Silakan Login Terlebih Dahulu | Host: " & Server & ":" & Port
        End If
    End Sub

    ''' <summary>
    ''' Helper untuk membuka form sebagai MDI Child.
    ''' Mencegah form terbuka double.
    ''' </summary>
    Private Sub BukaForm(Of T As {Form, New})()
        Dim formTujuan As T = Nothing
        Dim isOpen As Boolean = False

        For Each frm As Form In Me.MdiChildren
            If TypeOf frm Is T Then
                isOpen = True
                formTujuan = CType(frm, T)
                Exit For
            End If
        Next

        If isOpen Then
            formTujuan.Activate()
            formTujuan.BringToFront()
            If formTujuan.WindowState = FormWindowState.Minimized Then
                formTujuan.WindowState = FormWindowState.Normal
            End If
        Else
            formTujuan = New T()
            formTujuan.MdiParent = Me
            formTujuan.WindowState = FormWindowState.Maximized
            formTujuan.Show()
        End If
    End Sub

    Private Sub DataDosenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataDosenToolStripMenuItem.Click
        BukaForm(Of FrmDataDosen)()
    End Sub

    Private Sub DataMataKuliahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMataKuliahToolStripMenuItem.Click
        BukaForm(Of FrmDataMataKuliah)()
    End Sub

    Private Sub DataPenggunaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenggunaToolStripMenuItem.Click
        BukaForm(Of FrmDataUser)()
    End Sub

    Private Sub DataRuangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataRuangToolStripMenuItem.Click
        BukaForm(Of FrmDataRuang)()
    End Sub

    Private Sub DataHariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataHariToolStripMenuItem.Click
        BukaForm(Of FrmDataHari)()
    End Sub

    Private Sub DataJurusanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataJurusanToolStripMenuItem.Click
        BukaForm(Of FrmDataProdi)()
    End Sub

    Private Sub PengampuMataKuliahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengampuMataKuliahToolStripMenuItem.Click
        BukaForm(Of FrmDataPengampuMataKuliah)()
    End Sub

    Private Sub PenyusunanJadwalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenyusunanJadwalToolStripMenuItem.Click
        BukaForm(Of FrmDataPenjadwalanMataKuliah)()
    End Sub

    Private Sub LaporanDosenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LaporanDosenToolStripMenuItem1.Click
        BukaForm(Of FrmCetakLaporanDataDosen)()
    End Sub

    Private Sub LaporanMataKuliahGanjilGenapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanMataKuliahGanjilGenapToolStripMenuItem.Click
        BukaForm(Of FrmCetakLaporanDataDosenPengampu)()
    End Sub

    Private Sub LaporanPengampuTahunAkademikToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPengampuTahunAkademikToolStripMenuItem.Click
        BukaForm(Of FrmCetakLaporanDataMataKuliah)()
    End Sub

    Private Sub LaporanJadwalKuliahTahunAkademikToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanJadwalKuliahTahunAkademikToolStripMenuItem.Click
        BukaForm(Of FrmCetakLaporanDataPenjadwalanMataKuliah)()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        FrmLogin.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        If MessageBox.Show("Yakin ingin keluar aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If ShowConfirm("Yakin ingin logout?") Then
            ClearSession()
            ApplySecuritySettings()
            ShowInfo("Anda telah logout.")
            FrmLogin.Show()
        End If
    End Sub

    Private Sub TentangAplikasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TentangAplikasiToolStripMenuItem.Click
        BukaForm(Of FrmAbout)()
    End Sub
End Class