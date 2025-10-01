using StarterApp.Models.ViewModels;

namespace StarterApp.Interfaces.Services
{
    public interface ITodolistService
    {
        IEnumerable<ViewTodolist> GetAllTodolist();
        ViewTodolist GetViewTodolist(int id);
    }
}
