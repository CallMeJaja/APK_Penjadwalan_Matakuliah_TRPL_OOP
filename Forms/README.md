# Forms

Folder ini berisi semua **Windows Forms** untuk antarmuka pengguna aplikasi.

## 📐 Struktur

```
Forms/
├── FrmBaseData.vb          # Base class untuk form data master
├── FrmBaseInput.vb         # Base class untuk form input popup
├── Master/                 # Form data master
├── Transaksi/              # Form transaksi
├── Laporan/                # Form cetak laporan
└── Sistem/                 # Form sistem
```

## 🏗️ Base Forms

### FrmBaseData

Base class untuk form yang menampilkan data dalam DataGridView dengan fitur:
- Paging (navigasi halaman)
- Pencarian/filter
- CRUD operations
- Toolbar standar (Tambah, Edit, Hapus, Refresh)

### FrmBaseInput

Base class untuk form input popup dengan fitur:
- Mode Add/Edit
- Validasi input
- Tombol Simpan dan Batal

## 📁 Subfolder

| Folder | Deskripsi |
|--------|-----------|
| [Master/](./Master/) | Form kelola data master (Dosen, Matakuliah, dll) |
| [Transaksi/](./Transaksi/) | Form input transaksi (Pengampu, Jadwal) |
| [Laporan/](./Laporan/) | Form cetak laporan ke Crystal Reports |
| [Sistem/](./Sistem/) | Form login, menu utama, dan about |

## 🔑 Pola Inheritance

```
FrmBaseData (Base)
├── FrmMasterDosen
├── FrmMasterMatakuliah
├── FrmMasterProdi
├── FrmMasterRuang
├── FrmMasterHari
├── FrmMasterUser
├── FrmTransaksiPengampu
└── FrmTransaksiJadwal
```

## 🔗 Terkait

- [../Modules/](../Modules/) - Helper modules yang digunakan forms
- [../Entities/](../Entities/) - Domain entities untuk validasi
