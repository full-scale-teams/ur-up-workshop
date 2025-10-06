using StarterApp.Models.ViewModels;

namespace StarterApp.Interfaces.Services
{
    public interface ITodolistService
    {
        Task<IEnumerable<ViewTodolist>> GetAllTodolist();
        Task <ViewTodolist> GetViewTodolist(int id);
    }
}
