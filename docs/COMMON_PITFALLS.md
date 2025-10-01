# Common Issues & Fixes — ASP.NET Core + EF Core

This file summarizes frequent issues encountered during development and how to fix them.

## 1. dotnet-ef Not Found

**Issue:** Running EF Core commands fails with `dotnet-ef not found`.

**Fix:**

```bash
dotnet tool install --global dotnet-ef
```

## 2. SQLite Lock

**Issue:** Running migrations or accessing the database fails with a `SQLite is locked` error.

**Fix:**

1. Stop the running application.
2. Delete the database file (e.g., `app.db`).
3. Re-run the migration:

```bash
dotnet ef database update
```

## 3. HTTPS Development Certificate (Windows)

**Issue:** Local development with HTTPS fails or the browser shows certificate warnings.

**Fix:**

```bash
dotnet dev-certs https --trust
```

## 4. Nullable Reference Warnings

**Issue:** Compiler warnings about nullable references or possible `null` values.

**Fix:**

- Initialize strings or other non-nullable types:

```c#
public string Name { get; set; } = "";
```


## 5. DbContext Dependency Injection

**Issue:** DbContext is not injected correctly; errors occur in constructors or services.

**Fix:**

- Ensure your `Program.cs` contains:

```c#
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```
