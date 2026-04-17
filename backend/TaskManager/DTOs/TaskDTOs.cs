using TaskManager.Enums;

namespace TaskManager.DTOs
{
    public record TaskDto(Guid Id, string Title, string? Description, TaskItemStatus Status, DateTime CreatedAt);
    public record CreateTaskDto(string Title, string Description);
    public record UpdateTaskDto(string Title, string Description, TaskItemStatus Status);
}
