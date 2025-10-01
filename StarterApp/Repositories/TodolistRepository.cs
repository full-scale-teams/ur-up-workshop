using StarterApp.Interfaces.Repositories;
using StarterApp.Models.Entities;

namespace StarterApp.Repositories
{
    /// <summary>
    /// This is just a demo
    /// </summary>
    public class TodolistRepository : ITodolistRepository
    {
        private static readonly List<Todolist> todolists =
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
                Description = "Discuss project roadmap with the team",
                CreatedAt = DateTime.UtcNow
            }
        ];

        public IEnumerable<Todolist> GetAllTodos() => todolists;

        public Todolist? GetById(int id)
        {
            return todolists.FirstOrDefault(t => t.Id == id);
        }
    }
}
