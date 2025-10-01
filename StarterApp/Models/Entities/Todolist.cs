
using System.ComponentModel.DataAnnotations;

namespace StarterApp.Models.Entities
{
    /// <summary>
    /// Demo entity
    /// </summary>
    public class Todolist
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; } = null!;

        [Required, StringLength(50)]
        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
