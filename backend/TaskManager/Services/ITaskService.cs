using TaskManager.DTOs;
using TaskManager.Entities;
using TaskManager.Enums;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        Task<TaskDto> Add(CreateTaskDto task);
        Task Delete(Guid id);
        Task<IEnumerable<TaskDto>> GetAll(TaskItemStatus? status = null);
        Task<TaskDto?> GetById(Guid id);
        Task Update(Guid id, UpdateTaskDto task);
    }
}