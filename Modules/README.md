# Modules

Folder ini berisi **helper modules** yang menyediakan fungsi utilitas untuk seluruh aplikasi.

## 📁 Daftar Modules

| File | Fungsi |
|------|--------|
| `ModKoneksi.vb` | Koneksi database MySQL |
| `ModDbCrud.vb` | Operasi CRUD database |
| `ModAutoId.vb` | Auto-generate ID/kode |
| `ModValidasi.vb` | Validasi input form |
| `ModSesi.vb` | Manajemen sesi user |
| `ModUmum.vb` | Fungsi umum/utilitas |
| `ModReport.vb` | Helper Crystal Reports |

---

## 📄 Detail Modules

### ModKoneksi.vb
Mengelola koneksi ke database MySQL:
```vb
Public Conn As MySqlConnection
Public Sub BukaKoneksi()
Public Sub TutupKoneksi()
```

### ModDbCrud.vb
Helper untuk operasi database:
- `LoadData()` - Ambil data dari query
- `LoadDataWithParams()` - Query dengan parameter
- `ExecuteQuery()` - Eksekusi INSERT/UPDATE/DELETE
- `IsiComboBox()` - Populate ComboBox dari database
- `IsiDataGridView()` - Populate DataGridView

### ModAutoId.vb
Generate ID otomatis untuk setiap tabel:
```vb
Public Function GenerateKdDosen() As String      ' Format: 13XXXX (Numeric)
Public Function GenerateKdMatakuliah() As String ' Format: TRPLXXX / MKUXXX (Alphanumeric)
Public Function GenerateKdPengampu() As String   ' Format: PMKXXXX
' Catatan: Jadwal menggunakan kd_pengampu sebagai Primary Key
```

### ModValidasi.vb
Validasi input pengguna:
- `ValidateEmail()` - Validasi format email
- `ValidateNIP()` - Validasi format NIP
- `ValidatePhone()` - Validasi nomor telepon
- `IsIdExists()` - Cek duplikasi ID di database

### ModSesi.vb
Manajemen sesi login:
```vb
Public CurrentUser As String
Public CurrentUserId As String
Public CurrentUserLevel As String
Public Sub SetSession(user As String, id As String, level As String)
Public Sub ClearSession()
```

### ModUmum.vb
Fungsi utilitas umum:
- `ShowInfo()` / `ShowError()` / `ShowWarning()` - MessageBox helpers
- `FormatRupiah()` - Format mata uang
- `FormatTanggal()` - Format tanggal Indonesia
- `ClearControls()` - Reset input controls

### ModReport.vb
Helper untuk Crystal Reports:
- Connection string untuk report
- Parameter passing helpers

## 🔗 Terkait

- [../Forms/](../Forms/) - Forms yang menggunakan modules ini
- [../Repositories/](../Repositories/) - Repository layer
