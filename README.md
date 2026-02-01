# APK Penjadwalan Matakuliah TRPL OOP

Aplikasi desktop Windows untuk manajemen penjadwalan matakuliah di Program Studi Teknologi Rekayasa Perangkat Lunak (TRPL), Politeknik Enjinering Indorama.

## 🎯 Fitur Utama

- **Data Master** - Kelola data Dosen, Matakuliah, Program Studi, Ruang Kelas, Hari, dan User
- **Transaksi** - Input dosen pengampu matakuliah dan penjadwalan kuliah
- **Laporan** - Cetak laporan data dosen, matakuliah, pengampu, dan jadwal kuliah
- **Deteksi Bentrok** - Otomatis mendeteksi konflik jadwal ruangan dan dosen

## 🛠️ Teknologi

| Komponen | Teknologi |
|----------|-----------|
| Bahasa | Visual Basic .NET |
| Framework | .NET Framework 4.8 |
| Database | MySQL |
| Report | Crystal Reports |
| IDE | Visual Studio 2022 |

## 📁 Struktur Proyek

```
APK_Penjadwalan_Matakuliah_TRPL_OOP/
├── Entities/          # Domain models dengan validasi
│   ├── Base/          # Abstract base class
│   └── Interfaces/    # Interface definitions
├── Forms/             # Windows Forms UI
│   ├── Master/        # Form data master
│   ├── Transaksi/     # Form transaksi
│   ├── Laporan/       # Form cetak laporan
│   └── Sistem/        # Form sistem (Login, Menu)
├── Modules/           # Helper modules
├── Repositories/      # Data access layer
├── Reports/           # Crystal Reports (.rpt)
└── Resources/         # Icons dan gambar
```

## 🚀 Instalasi

### Prasyarat
1. Visual Studio 2022 dengan workload ".NET Desktop Development"
2. MySQL Server 8.0+
3. Crystal Reports Runtime

### Langkah Instalasi
1. Clone repository ini
2. Buka `APK_Penjadwalan_Matakuliah_TRPL_OOP.sln` di Visual Studio
3. Konfigurasi koneksi database di `App.config`
4. Import schema database dari folder `Database/`
5. Build dan jalankan aplikasi

## ⚙️ Konfigurasi Database

Edit file `App.config` dan sesuaikan connection string:

```xml
<connectionStrings>
    <add name="MySqlConnection" 
         connectionString="server=localhost;database=db_jadwal;uid=root;pwd=password" />
</connectionStrings>
```

## 📖 Arsitektur

Aplikasi ini menggunakan arsitektur **OOP (Object-Oriented Programming)** dengan pola:

- **Entity Pattern** - Domain models dengan built-in validation
- **Repository Pattern** - Abstraksi akses database
- **Base Form Pattern** - Reusable form components
- **Module Pattern** - Utility functions terpisah

## 👤 Default Login

| Username | Password | Level |
|----------|----------|-------|
| admin | admin | Administrator |

## 📄 Lisensi

Proyek ini dibuat untuk keperluan akademik di Politeknik Enjinering Indorama.

---
*Dikembangkan dengan ❤️ menggunakan VB.NET*
