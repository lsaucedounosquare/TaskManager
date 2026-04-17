using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.Entities
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public TaskItemStatus Status { get;set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
