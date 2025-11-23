using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string? Description { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Color must be a valid hex color")]
        public string Color { get; set; } = "#4a90e2"; // Default blue

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
