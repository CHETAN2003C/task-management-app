using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "File name is required")]
        [StringLength(255, ErrorMessage = "File name cannot exceed 255 characters")]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(500, ErrorMessage = "File path cannot exceed 500 characters")]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Content type cannot exceed 100 characters")]
        public string ContentType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;

        // Navigation property
        public TaskItem Task { get; set; } = null!;
    }
}
