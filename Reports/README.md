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
- Parameter: `prmProdi` (filter program studi)
- Kolom: Kode Dosen, Nama, NIP, Email, Telepon, Prodi

### rptMatkul
**Laporan Data Matakuliah**
- Parameter: `prmProdi`, `prmSemester`
- Kolom: Kode MK, Nama MK, SKS Teori, SKS Praktek, Semester

### rptDosenPengampu
**Laporan Dosen Pengampu Matakuliah**
- Parameter: `prmProdi`, `prmTahunAkademik`
- Kolom: Kode Pengampu, Nama Dosen, Matakuliah, Kelas

### rptJadwalMatkul
**Laporan Jadwal Kuliah**
- Parameter: `prmProdi`, `prmSemester`, `prmTahunAkademik`, `prmJenisKelas`
- Kolom: Hari, Jam, Matakuliah, Dosen, Ruangan, Kelas

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
