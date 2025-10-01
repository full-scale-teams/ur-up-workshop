using StarterApp.Models.Entities;

namespace StarterApp.Interfaces.Repositories
{
    public interface ITodolistRepository
    {
        IEnumerable<Todolist> GetAllTodos();
        Todolist? GetById(int id);
    }
}
