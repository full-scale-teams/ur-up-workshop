using Microsoft.AspNetCore.Mvc.RazorPages;
using StarterApp.Interfaces.Services;
using StarterApp.Models.ViewModels;

namespace StarterApp.Pages.Todolist
{
    public class IndexModel : PageModel
    {
        private readonly ITodolistService _service;
        
        public IndexModel(ITodolistService service)
        {
            _service = service;
        }

        public IEnumerable<ViewTodolist> Todolists { get; set; }

        public async Task OnGet()
        {
            Todolists = await _service.GetAllTodolist();
        }
    }
}
