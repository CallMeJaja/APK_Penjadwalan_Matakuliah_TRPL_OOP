# Reports

Folder ini berisi **Crystal Reports** untuk cetak laporan aplikasi.

## 📁 Daftar Reports

| File | Deskripsi |
|------|-----------|
| `rptDosen.rpt` | Template laporan data dosen |
| `rptDosen.vb` | Class wrapper untuk report |
| `rptMatkul.rpt` | Template laporan matakuliah |
| `rptMatkul.vb` | Class wrapper untuk report |
| `rptDosenPengampu.rpt` | Template laporan dosen pengampu |
| `rptDosenPengampu.vb` | Class wrapper untuk report |
| `rptJadwalMatkul.rpt` | Template laporan jadwal |
| `rptJadwalMatkul.vb` | Class wrapper untuk report |

## 📊 Detail Reports

### rptDosen
**Laporan Data Dosen**
- Source: `vw_plotting_dosen` / `tbl_dosen`
- Parameter: `prmProdi` (filter program studi)
- Kolom: Kode Dosen, Nama, NIP, Email, Telepon, Prodi

### rptMatkul
**Laporan Data Matakuliah**
- Parameter: `prmProdi`, `prmSemester`
- Kolom: Kode MK, Nama MK, SKS Teori, SKS Praktek, Semester

### rptDosenPengampu
**Laporan Dosen Pengampu Matakuliah**
- Source: `vw_plotting_dosen`
- Parameter: `prmProdi`, `prmTahunAkademik`
- Kolom: Kode Pengampu, Nama Dosen, Matakuliah, Kelas

### rptJadwalMatkul
**Laporan Jadwal Kuliah**
- Source: `vw_jadwal_cetak`
- Parameter: `prmProdi`, `prmSemester`, `prmTahunAkademik`, `prmJenisKelas`
- Kolom: Hari, Jam, Matakuliah, Dosen, Ruangan, Kelas

## 🔍 Database Views

Sistem menggunakan SQL Views untuk mempermudah pengambilan data yang kompleks:

1. **vw_jadwal_cetak**
   Menggabungkan jadwal, pengampu, matakuliah, dosen, hari, ruangan, dan prodi. Digunakan oleh `rptJadwalMatkul`.

2. **vw_plotting_dosen**
   Menggabungkan data dosen, pengampu, dan matakuliah. Digunakan untuk analisis beban kerja dosen dan laporan pengampu.

## ⚙️ Cara Modifikasi Report

1. Buka file `.rpt` di Crystal Reports Designer
2. Modifikasi layout, field, atau formula
3. Save file
4. Rebuild project di Visual Studio

## 📤 Export Format

Reports mendukung export ke:
- 📄 PDF
- 📊 Excel
- 📝 Word
- 🖨️ Print langsung

## 🔗 Terkait

- [../Forms/Laporan/](../Forms/Laporan/) - Form yang menggunakan reports ini
- [../Modules/ModReport.vb](../Modules/ModReport.vb) - Helper module
