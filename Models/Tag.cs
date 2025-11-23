using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tag name is required")]
        [StringLength(30, ErrorMessage = "Tag name cannot exceed 30 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(7, ErrorMessage = "Color must be a valid hex color")]
        public string Color { get; set; } = "#6c757d"; // Default gray

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
