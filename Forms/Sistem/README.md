# Sistem

Folder ini berisi form untuk fungsi **sistem** aplikasi.

## 📁 Struktur

```
Sistem/
├── FrmLogin.vb         # Form login user
├── FrmMenuUtama.vb     # Menu utama (MDI Container)
└── FrmAbout.vb         # Form informasi aplikasi
```

## 📝 Daftar Form

### FrmLogin
Form autentikasi user:
- Input username dan password
- Validasi kredensial dari database
- Menyimpan sesi user yang login
- Redirect ke menu utama setelah berhasil login

### FrmMenuUtama
Form utama aplikasi (MDI Container):
- Menu navigasi ke semua form
- Mengelola form child (single instance)
- Informasi user yang sedang login
- Fungsi logout dan keluar aplikasi

**Menu Structure:**
```
├── Master
│   ├── Data Dosen
│   ├── Data Matakuliah
│   ├── Data Program Studi
│   ├── Data Ruang Kelas
│   ├── Data Hari
│   └── Data User
├── Transaksi
│   ├── Dosen Pengampu
│   └── Penjadwalan
├── Laporan
│   ├── Data Dosen
│   ├── Data Matakuliah
│   ├── Dosen Pengampu
│   └── Jadwal Kuliah
└── Sistem
    ├── About
    ├── Logout
    └── Keluar
```

### FrmAbout
Form informasi aplikasi:
- Nama dan versi aplikasi
- Logo institusi
- Informasi pengembang

## 🔗 Terkait

- [../../Modules/ModSesi.vb](../../Modules/ModSesi.vb) - Manajemen sesi user
- [../Master/](../Master/) - Form yang diakses dari menu
