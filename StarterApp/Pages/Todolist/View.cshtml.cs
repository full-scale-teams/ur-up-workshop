using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarterApp.Interfaces.Services;
using StarterApp.Models.ViewModels;
using StarterApp.Utils;

namespace StarterApp.Pages.Todolist
{
    public class ViewModel : PageModel
    {
        private readonly ITodolistService _service;
        private readonly ILogger<ViewModel> _logger;

        public ViewTodolist Todolist { get; set; }

        public ViewModel(ITodolistService service, ILogger<ViewModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                Todolist = await _service.GetViewTodolist(id);
                return Page();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
    }
}
