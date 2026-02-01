# Base

Folder ini berisi **abstract base class** untuk semua entity dalam sistem.

## 📄 EntityBase.vb

`EntityBase` adalah kelas abstrak yang menjadi fondasi untuk semua domain entity.

### Fitur

- Implementasi interface `IEntity`
- Sistem validasi dengan kumpulan error messages
- Helper methods untuk validasi umum

### Abstract Members (Wajib Di-Override)

```vb
' Property yang harus diimplementasikan
Public MustOverride Property Kode As String
Public MustOverride ReadOnly Property DisplayName As String

' Method yang harus diimplementasikan
Protected MustOverride Sub ValidateEntity()
```

### Helper Methods

| Method | Fungsi |
|--------|--------|
| `AddError(message)` | Menambah pesan error ke list |
| `ValidateRequired(value, fieldName)` | Validasi field wajib diisi |
| `ValidateRange(value, min, max, fieldName)` | Validasi nilai dalam rentang |
| `ValidateNonNegative(value, fieldName)` | Validasi nilai tidak negatif |

### Contoh Penggunaan

```vb
Public Class DosenEntity
    Inherits EntityBase
    
    Public Overrides Property Kode As String
    Public Property NamaDosen As String
    
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return NamaDosen
        End Get
    End Property
    
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(Kode, "Kode Dosen")
        ValidateRequired(NamaDosen, "Nama Dosen")
    End Sub
End Class
```

## 🔗 Terkait

- [../Interfaces/](../Interfaces/) - Interface `IEntity`
- [../](../) - Semua entity implementations
