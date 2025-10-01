# Configuration Guide (ASP.NET Core)

This guide shows how to use **appsettings.json** in ASP.NET Core with Razor Pages.

---

## 1. Add Settings in `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=WorkshopDB.db"
  },
  "MyAppSettings": {
    "ApiKey": "12345-ABCDE",
    "EnableFeatureX": true
  }
}
```

Here we have:

* A **database connection string** (`DefaultConnection`)
* Some custom settings (`MyAppSettings`)

---

## 2. Read the Connection String

In `Program.cs`, you can grab the connection like this:

```csharp
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connection);
```

---

## 3. Use Connection String with EF Core

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## 4. Use Settings in a Razor Page

You can inject the config directly into your Razor Page’s **PageModel**.

### `Pages/Index.cshtml.cs`

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IConfiguration _config;

    public string ApiKey { get; private set; }
    public string FeatureFlag { get; private set; }

    public IndexModel(IConfiguration config)
    {
        _config = config;
    }

    public void OnGet()
    {
        ApiKey = _config["MyAppSettings:ApiKey"];
        FeatureFlag = _config["MyAppSettings:EnableFeatureX"];
    }
}
```

---

### `Pages/Index.cshtml`

```html
@page
@model IndexModel

<h2>Configuration Example</h2>

<p>API Key: @Model.ApiKey</p>
<p>Enable Feature X: @Model.FeatureFlag</p>
```

---

## ✅ Summary

* Put your settings in `appsettings.json`.
* Use `builder.Configuration.GetConnectionString()` for database connections.
* Inject `IConfiguration` into Razor Pages (or services) to read values.
* Access values with `"Section:Key"` (example: `"MyAppSettings:ApiKey"`).