# Entities

Folder ini berisi **domain entities** yang merepresentasikan objek bisnis dalam aplikasi penjadwalan matakuliah.

## 📐 Arsitektur

```
Entities/
├── Base/
│   └── EntityBase.vb      # Abstract base class
├── Interfaces/
│   └── IEntity.vb         # Interface kontrak entity
├── DosenEntity.vb         # Entity Dosen
├── HariEntity.vb          # Entity Hari
├── JadwalEntity.vb        # Entity Jadwal
├── MatakuliahEntity.vb    # Entity Matakuliah
├── PengampuEntity.vb      # Entity Dosen Pengampu
├── ProdiEntity.vb         # Entity Program Studi
├── RuangkelasEntity.vb    # Entity Ruang Kelas
└── UserEntity.vb          # Entity User
```

## 🔑 Konsep OOP yang Diterapkan

| Prinsip | Implementasi |
|---------|--------------|
| **Abstraction** | `EntityBase` sebagai `MustInherit` class |
| **Encapsulation** | Properties dengan getter/setter |
| **Inheritance** | Semua entity inherit dari `EntityBase` |
| **Polymorphism** | Override method `ValidateEntity()` |

## 📝 Entities

| Entity | Tabel Database | Fungsi |
|--------|----------------|--------|
| `DosenEntity` | `tbl_dosen` | Data dosen/pengajar |
| `HariEntity` | `tbl_hari` | Data hari kuliah |
| `JadwalEntity` | `tbl_jadwal_matkul` | Jadwal perkuliahan |
| `MatakuliahEntity` | `tbl_matakuliah` | Data matakuliah |
| `PengampuEntity` | `tbl_dosen_pengampu_matkul` | Relasi dosen-matakuliah |
| `ProdiEntity` | `tbl_prodi` | Program studi |
| `RuangkelasEntity` | `tbl_ruangkelas` | Ruang kelas |
| `UserEntity` | `tbl_user` | User login aplikasi |

## ✅ Validasi

Setiap entity memiliki validasi built-in melalui method `ValidateEntity()`:

```vb
Dim dosen As New DosenEntity()
dosen.NamaDosen = ""

If Not dosen.IsValid() Then
    For Each err In dosen.GetValidationErrors()
        Console.WriteLine(err)
    Next
End If
```

## 📂 Subfolder

- [Base/](./Base/) - Abstract base class `EntityBase`
- [Interfaces/](./Interfaces/) - Interface `IEntity`
