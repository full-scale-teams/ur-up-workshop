using StarterApp;


var builder = WebApplication.CreateBuilder(args);

StartupConfigurer.ConfigureServices(builder.Services);

var app = builder.Build();

StartupConfigurer.ConfigureHttpPipeline(app, app.Environment);

app.MapRazorPages();

app.Run();
