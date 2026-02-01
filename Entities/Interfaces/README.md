# Interfaces

Folder ini berisi **interface definitions** untuk entity dalam sistem.

## 📄 IEntity.vb

Interface kontrak yang harus diimplementasikan oleh semua entity.

### Method Signatures

```vb
Public Interface IEntity
    ' Memeriksa apakah entity valid
    Function IsValid() As Boolean
    
    ' Mengambil list pesan error validasi
    Function GetValidationErrors() As List(Of String)
    
    ' Menghasilkan informasi display untuk UI
    Function GetDisplayInfo() As String
End Interface
```

### Penggunaan

```vb
' Contoh penggunaan polymorphism dengan interface
Dim entity As IEntity = New DosenEntity()

If entity.IsValid() Then
    Console.WriteLine(entity.GetDisplayInfo())
Else
    For Each err In entity.GetValidationErrors()
        Console.WriteLine(err)
    Next
End If
```

## 🔗 Terkait

- [../Base/](../Base/) - `EntityBase` yang mengimplementasikan interface ini
