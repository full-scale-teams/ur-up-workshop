# StarterApp - Todo List Demo

A simple Razor Pages project demonstrating **EF Core migrations**, **SQLite integration**, and **database seeding**.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Project Setup](#project-setup)
3. [Database Configuration](#database-configuration)
4. [Applying Migrations](#applying-migrations)
5. [Seeding the Database](#seeding-the-database)
6. [Updating the Schema: Adding IsDone Column](#updating-the-schema-adding-isdone-column)

---

## Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [SQLite](https://www.sqlite.org/download.html) (optional, EF Core can create the file automatically)
* IDE or Editor (Visual Studio, Rider, VS Code, etc.)

---

## Project Setup

1. Install required NuGet packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

> These packages enable EF Core and SQLite support.

---

## Database Configuration

1. Open `appsettings.json` and set the SQLite connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=todo.db"
  }
}
```

> The SQLite database file `todo.db` will be created in the project root.

2. Create `ApplicationDBContext` in `Data/ApplicationDBContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using StarterApp.Models.Entities;

namespace StarterApp.Data
{
    /// <summary>
    /// Configure DbContext here
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        // Define DbSet for Todo list
        public DbSet<Todolist> Todolists { get; set; }

        // Constructor for DbContext
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        // Seed sample data
        public static async Task SeedData(IServiceProvider sp)
        {
            await using var db = sp.GetRequiredService<ApplicationDBContext>();
            await db.Database.EnsureCreatedAsync();

            if (!db.Todolists.Any())
            {
                var todolists = new List<Todolist>
                {
                    new()
                    {
                        Title = "Buy groceries",
                        Description = "Milk, eggs, bread, and fruits",
                        CreatedAt = DateTime.UtcNow.AddDays(-2)
                    },
                    new()
                    {
                        Title = "Workout",
                        Description = "Go for a 30-minute run",
                        CreatedAt = DateTime.UtcNow.AddDays(-1)
                    },
                    new()
                    {
                        Title = "Project meeting",
                        Description = "Discuss project roadmap with the team",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                db.Todolists.AddRange(todolists);
                await db.SaveChangesAsync();
            }
        }
    }
}
```

3. Register the `ApplicationDBContext` in `Program.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using StarterApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## Applying Migrations

1. Create the first migration:

```bash
dotnet ef migrations add InitialCreate
```

* This generates a `Migrations` folder with scripts to create the `Todolists` table.

2. Apply the migration to create the database:

```bash
dotnet ef database update
```

* After this, `todo.db` exists with the `Todolists` table.

---

## Seeding the Database

1. Invoke the seeding logic in `Program.cs` after building the app:

```csharp
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ApplicationDBContext.SeedData(services);
}
```

> This ensures the database is created and populated with initial todo items at first run.

---

## Updating the Schema: Adding `IsDone` Column

1. **Update the `Todolist` model** (`Models/Entities/Todolist.cs`) to include the new column:

```csharp
public class Todolist
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Title { get; set; } = null!;

    [Required, StringLength(50)]
    public string Description { get; set; } = null!;

    // New column to track completion
    public bool IsDone { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
```

---

2. **Create a new migration** to reflect the schema change:

```bash
dotnet ef migrations add AddIsDoneColumn
```

* This generates a migration file that will add the `IsDone` column to the `Todolists` table.

---

3. **Apply the migration** to update the database:

```bash
dotnet ef database update
```

* The existing `todo.db` file will now include the new `IsDone` column.
* Any previously seeded records remain intact.

---

4. **Optional: Update seeding logic** to include `IsDone` values for new entries:

```csharp
var todolists = new List<Todolist>
{
    new()
    {
        Title = "Buy groceries",
        Description = "Milk, eggs, bread, and fruits",
        IsDone = false,
        CreatedAt = DateTime.UtcNow.AddDays(-2)
    },
    new()
    {
        Title = "Workout",
        Description = "Go for a 30-minute run",
        IsDone = true,
        CreatedAt = DateTime.UtcNow.AddDays(-1)
    }
};
```

> This step is optional; existing rows will have `IsDone = false` by default.