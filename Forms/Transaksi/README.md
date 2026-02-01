# Transaksi

Folder ini berisi form untuk **input transaksi** penjadwalan.

## 📁 Struktur

```
Transaksi/
├── FrmLookup.vb                   # Form pencarian data (popup)
├── Pengampu/
│   ├── FrmTransaksiPengampu.vb    # Form daftar dosen pengampu
│   └── FrmInputPengampu.vb        # Form input pengampu
└── Penjadwalan/
    ├── FrmTransaksiJadwal.vb      # Form daftar jadwal
    └── FrmInputJadwal.vb          # Form input jadwal
```

## 📝 Daftar Form

### FrmLookup
Form popup untuk pencarian dan pemilihan data:
- Digunakan saat memilih dosen pengampu di form jadwal
- Mendukung pencarian dan filter
- Mengembalikan data yang dipilih ke form pemanggil

### FrmTransaksiPengampu
Form untuk menetapkan dosen pengampu matakuliah:
- Relasi dosen dengan matakuliah
- Filter berdasarkan prodi dan semester
- Auto-generate kode pengampu (PMKXXXX)

### FrmTransaksiJadwal
Form untuk input jadwal perkuliahan:
- Pilih pengampu, hari, ruangan, dan waktu
- **Deteksi bentrok** otomatis untuk:
  - Ruangan yang sama di waktu yang sama
  - Dosen yang sama di waktu yang sama
- Kalkulasi durasi otomatis berdasarkan SKS

## ⚠️ Validasi Bentrok

Sistem secara otomatis mengecek:
1. **Bentrok Ruangan** - Ruangan tidak bisa dipakai di waktu yang sama
2. **Bentrok Dosen** - Dosen tidak bisa mengajar di 2 tempat bersamaan

## 🔗 Terkait

- [../Master/](../Master/) - Data master yang digunakan
- [../../Modules/ModValidasi.vb](../../Modules/ModValidasi.vb) - Validasi input
