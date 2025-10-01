using System.ComponentModel.DataAnnotations;

namespace StarterApp.Models.ViewModels
{
    public class ViewTodolist
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; } = null!;

        [Required, StringLength(50)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
