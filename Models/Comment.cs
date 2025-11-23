using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Comment text is required")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        public string Author { get; set; } = "Anonymous";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public TaskItem Task { get; set; } = null!;
    }
}
