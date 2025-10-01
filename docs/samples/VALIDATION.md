# Validation — Sample Guide

This file provides a **quick reference** for basic input validation in ASP.NET Core Razor Pages.

```csharp
[BindProperty]
public Student Input { get; set; } = new();

public async Task<IActionResult> OnPostAsync()
{
    if (string.IsNullOrWhiteSpace(Input.Name) ||
        string.IsNullOrWhiteSpace(Input.Email))
    {
        ModelState.AddModelError(string.Empty, "Name and Email are required.");
        return Page();
    }

    _db.Add(Input);
    await _db.SaveChangesAsync();

    return RedirectToPage("Index");
}
```