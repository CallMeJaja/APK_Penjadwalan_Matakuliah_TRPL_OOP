# Master

Folder ini berisi form untuk mengelola **data master** aplikasi.

## 📁 Struktur

```
Master/
├── Dosen/
│   ├── FrmMasterDosen.vb          # Form utama data dosen
│   └── FrmInputDosen.vb           # Form input dosen
├── Hari/
│   ├── FrmMasterHari.vb           # Form data hari
│   └── FrmInputHari.vb            # Form input hari
├── MataKuliah/
│   ├── FrmMasterMatakuliah.vb     # Form data matakuliah
│   └── FrmInputMatakuliah.vb      # Form input matakuliah
├── ProgramStudi/
│   ├── FrmMasterProdi.vb          # Form data program studi
│   └── FrmInputProdi.vb           # Form input prodi
├── Ruang/
│   ├── FrmMasterRuang.vb          # Form data ruang kelas
│   └── FrmInputRuang.vb           # Form input ruang
└── User/
    ├── FrmMasterUser.vb           # Form data user
    └── FrmInputUser.vb            # Form input user
```

## 📝 Daftar Form Master

| Form | Tabel | Fungsi |
|------|-------|--------|
| FrmMasterDosen | `tbl_dosen` | Kelola data dosen/pengajar |
| FrmMasterHari | `tbl_hari` | Kelola data hari kuliah |
| FrmMasterMatakuliah | `tbl_matakuliah` | Kelola data matakuliah |
| FrmMasterProdi | `tbl_prodi` | Kelola data program studi |
| FrmMasterRuang | `tbl_ruangkelas` | Kelola data ruang kelas |
| FrmMasterUser | `tbl_user` | Kelola data user login |

## ✨ Fitur Umum

Semua form master memiliki fitur:
- ➕ **Tambah** - Menambah data baru
- ✏️ **Edit** - Mengubah data yang dipilih
- 🗑️ **Hapus** - Menghapus data dengan konfirmasi
- 🔄 **Refresh** - Memuat ulang data
- 🔍 **Filter** - Mencari data berdasarkan kriteria
- 📄 **Paging** - Navigasi halaman data

## 🔗 Terkait

- [../](../) - Forms root dengan base classes
- [../../Entities/](../../Entities/) - Entity validations
- [../../Repositories/](../../Repositories/) - Data access layer
