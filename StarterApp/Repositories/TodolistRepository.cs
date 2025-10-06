using Microsoft.EntityFrameworkCore;
using StarterApp.Data;
using StarterApp.Interfaces.Repositories;
using StarterApp.Models.Entities;

namespace StarterApp.Repositories
{
    /// <summary>
    /// This is just a demo
    /// </summary>
    public class TodolistRepository : ITodolistRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TodolistRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Todolist>> GetAllTodos()
        {
            return await _dbContext.Todolists.ToListAsync();
        }

        public async Task<Todolist?> GetById(int id)
        {
            return await _dbContext.Todolists.FirstOrDefaultAsync(t=> t.Id == id);
        }
    }
}
