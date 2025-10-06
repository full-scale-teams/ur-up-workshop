using Microsoft.EntityFrameworkCore;
using StarterApp;
using StarterApp.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

StartupConfigurer.ConfigureServices(builder.Services);

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ApplicationDBContext.SeedData(services);
}

StartupConfigurer.ConfigureHttpPipeline(app, app.Environment);

app.MapRazorPages();

app.Run();
