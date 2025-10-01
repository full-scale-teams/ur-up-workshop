using Microsoft.AspNetCore.Mvc.RazorPages;
using StarterApp.Interfaces.Services;
using StarterApp.Models.ViewModels;
using System.Collections.Generic;

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

        public void OnGet()
        {
            Todolists = _service.GetAllTodolist();
        }
    }
}
