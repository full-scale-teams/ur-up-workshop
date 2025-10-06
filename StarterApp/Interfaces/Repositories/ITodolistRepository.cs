using StarterApp.Models.Entities;

namespace StarterApp.Interfaces.Repositories
{
    public interface ITodolistRepository
    {
        Task<IEnumerable<Todolist>> GetAllTodos();
        Task<Todolist?> GetById(int id);
    }
}
