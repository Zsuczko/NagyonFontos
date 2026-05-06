# WPF + Entity Framework Core + SQLite Setup

## 1. NuGet Packages

Install these three packages:

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools
```

---

## 2. Scaffold from Existing SQLite File

Run in **Package Manager Console**:

```powershell
Scaffold-DbContext "Data Source=.\your.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -ContextDir . -Force
```

- `-OutputDir Models` — entity classes go into the `Models` folder
- `-ContextDir .` — context file goes into the project root
- `-Force` — overwrites existing files

---

## 3. Fix the Connection String in the Context

Open the generated `YourContext.cs` and replace the `OnConfiguring` method:

```csharp
using System.IO;

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "your.db");
    optionsBuilder.UseSqlite($"Data Source={dbPath}");
}
```

> Don't forget `using System.IO;` at the top of the file!

---

## 4. Copy the .db File to Output Directory

In **Solution Explorer**, click the `.db` file, then in the **Properties panel** (F4):

```
Copy to Output Directory → Copy if newer
```

Or manually in the `.csproj`:

```xml
<ItemGroup>
  <Content Include="your.db">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```

---

## 5. Use the Context in MainWindow

### Simple (one-off query)

```csharp
using var db = new YourContext();
var items = db.YourTable.ToList();
MyDataGrid.ItemsSource = items;
```

### Recommended (reuse across methods)

```csharp
public partial class MainWindow : Window
{
    private readonly YourContext _db = new YourContext();

    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        var items = _db.YourTable.ToList();
        MyDataGrid.ItemsSource = items;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _db.YourTable.Add(new YourEntity { ... });
        _db.SaveChanges();
        LoadData(); // refresh UI
    }
}
```

> No dependency injection needed in WPF — just use `new YourContext()` directly.

---

## Common Mistakes

| Mistake | Fix |
|---|---|
| Context file not found after scaffold | Use `-ContextDir .` to place it in root |
| `Path` is underlined red | Add `using System.IO;` |
| App can't find `.db` at runtime | Set `Copy to Output Directory` on the `.db` file |
| Hardcoded path in `OnConfiguring` | Use `AppDomain.CurrentDomain.BaseDirectory` |
