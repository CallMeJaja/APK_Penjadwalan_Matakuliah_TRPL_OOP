# Repositories

Folder ini berisi **data access layer** yang mengimplementasikan Repository Pattern.

## 📐 Arsitektur

```
Repositories/
├── IRepository.vb           # Interface repository
├── RepositoryBase.vb        # Abstract base class
├── DosenRepository.vb       # Repository dosen
├── HariRepository.vb        # Repository hari
├── MatakuliahRepository.vb  # Repository matakuliah
├── ProdiRepository.vb       # Repository prodi
├── RuangkelasRepository.vb  # Repository ruang kelas
└── UserRepository.vb        # Repository user
```

## 🔑 Repository Pattern

Repository Pattern memisahkan logika akses data dari logika bisnis, menyediakan:
- Abstraksi akses database
- Kemudahan unit testing
- Konsistensi operasi CRUD

## 📄 IRepository Interface

```vb
Public Interface IRepository(Of T)
    Function GetAll() As List(Of T)
    Function GetById(id As String) As T
    Function Insert(entity As T) As Boolean
    Function Update(entity As T) As Boolean
    Function Delete(id As String) As Boolean
    Function Exists(id As String) As Boolean
End Interface
```

## 📄 RepositoryBase

Abstract class yang menyediakan implementasi dasar:

| Method | Fungsi |
|--------|--------|
| `GetAll()` | Ambil semua data sebagai List |
| `GetById()` | Ambil data berdasarkan ID |
| `Insert()` | Simpan data baru |
| `Update()` | Update data existing |
| `Delete()` | Hapus data berdasarkan ID |
| `Exists()` | Cek apakah ID sudah ada |

### Abstract Members (Wajib Di-Override)

```vb
Protected MustOverride ReadOnly Property TableName As String
Protected MustOverride ReadOnly Property PrimaryKey As String
Protected MustOverride Function GetSelectQuery() As String
Protected MustOverride Function MapToEntity(row As DataRow) As T
Protected MustOverride Function GetInsertQuery() As String
Protected MustOverride Function GetUpdateQuery() As String
Protected MustOverride Function GetParameters(entity As T) As MySqlParameter()
```

## 📝 Contoh Penggunaan

```vb
' Menggunakan DosenRepository
Dim repo As New DosenRepository()

' Get all
Dim listDosen = repo.GetAll()

' Get by id
Dim dosen = repo.GetById("DSN0001")

' Insert
Dim newDosen As New DosenEntity()
newDosen.KdDosen = "DSN0002"
newDosen.NamaDosen = "Dr. Budi"
repo.Insert(newDosen)

' Update
dosen.NamaDosen = "Dr. Budi Santoso"
repo.Update(dosen)

' Delete
repo.Delete("DSN0002")
```

## 🔗 Terkait

- [../Entities/](../Entities/) - Entity classes yang di-mapping
- [../Modules/ModDbCrud.vb](../Modules/ModDbCrud.vb) - Database operations
