using Microsoft.Extensions.DependencyInjection;
using StarterApp.Interfaces.Repositories;
using StarterApp.Interfaces.Services;
using StarterApp.MappingProfiles;
using StarterApp.Repositories;
using StarterApp.Services;

namespace StarterApp
{
    internal partial class StartupConfigurer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();

            // Automatically registers all profiles
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repository
            services.AddScoped<ITodolistRepository, TodolistRepository>();

            // Services
            services.AddScoped<ITodolistService, TodolistService>();
        }

        public static void ConfigureHttpPipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
        }
    }
}
