# Laporan

Folder ini berisi form untuk **cetak laporan** menggunakan Crystal Reports.

## 📁 Struktur

```
Laporan/
├── FrmCetakLaporanDataDosen.vb              # Laporan data dosen
├── FrmCetakLaporanDataMataKuliah.vb         # Laporan data matakuliah
├── FrmCetakLaporanDataDosenPengampu.vb      # Laporan dosen pengampu
└── FrmCetakLaporanDataPenjadwalanMataKuliah.vb  # Laporan jadwal
```

## 📝 Daftar Laporan

| Form | Report | Deskripsi |
|------|--------|-----------|
| FrmCetakLaporanDataDosen | `rptDosen.rpt` | Daftar data dosen per prodi |
| FrmCetakLaporanDataMataKuliah | `rptMatkul.rpt` | Daftar matakuliah per prodi dan semester |
| FrmCetakLaporanDataDosenPengampu | `rptDosenPengampu.rpt` | Daftar dosen pengampu matakuliah |
| FrmCetakLaporanDataPenjadwalanMataKuliah | `rptJadwalMatkul.rpt` | Jadwal kuliah lengkap |

## 🎛️ Filter yang Tersedia

| Laporan | Filter |
|---------|--------|
| Data Dosen | Prodi |
| Data Matakuliah | Prodi, Semester |
| Dosen Pengampu | Prodi, Tahun Akademik |
| Jadwal | Prodi, Semester, Tahun Akademik, Jenis Kelas |

## 📄 Alur Cetak Laporan

1. User memilih filter (prodi, semester, dll)
2. Klik tombol "Cetak"
3. Sistem membangun query dengan filter
4. Data dimuat ke Crystal Report
5. Preview laporan ditampilkan di CrystalReportViewer
6. User dapat print atau export ke PDF

## 🔗 Terkait

- [../../Reports/](../../Reports/) - Template Crystal Reports (.rpt)
- [../../Modules/ModReport.vb](../../Modules/ModReport.vb) - Helper report
