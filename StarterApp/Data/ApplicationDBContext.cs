using Microsoft.EntityFrameworkCore;
using StarterApp.Models.Entities;

namespace StarterApp.Data
{
    /// <summary>
    /// Configure db context here
    /// </summary>
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Todolist> Todolists { get; set; }
        
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public static async Task SeedData(IServiceProvider sp)
        {
            await using var db = sp.GetRequiredService<ApplicationDBContext>();
            await db.Database.EnsureCreatedAsync();

            if (!db.Set<Todolist>().Any())
            {
                List<Todolist> todolists =
                [
                    new()
                    {
                        Id = 1,
                        Title = "Buy groceries",
                        Description = "Milk, eggs, bread, and fruits",
                        CreatedAt = DateTime.UtcNow.AddDays(-2)
                    },
                    new()
                    {
                        Id = 2,
                        Title = "Workout",
                        Description = "Go for a 30-minute run",
                        CreatedAt = DateTime.UtcNow.AddDays(-1)
                    },
                    new()
                    {
                        Id = 3,
                        Title = "Project meeting",
                        Description = " Discuss project roadmap with the team",
                        CreatedAt = DateTime.UtcNow
                    }
                ];
                
                db.Todolists.AddRange(todolists);
                await db.SaveChangesAsync();
            }
        }
    }
}