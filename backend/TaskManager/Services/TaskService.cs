using Microsoft.EntityFrameworkCore;
using TaskManager.DTOs;
using TaskManager.Entities;
using TaskManager.Infrastructure;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext db;

        public TaskService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TaskDto>> GetAll(Enums.TaskItemStatus? status = null)
        {
            IQueryable<TaskItem> tasks = db.Tasks.Where(task => !task.IsDeleted);

            if (status != null)
                tasks = tasks.Where(task => task.Status == status.Value);

            return await tasks.Select(task => new TaskDto(task.Id, task.Title, task.Description, task.Status, task.CreatedAt)).ToArrayAsync();
        }

        public async Task<TaskDto?> GetById(Guid id)
        {
            var task = await db.Tasks.FindAsync(id);

            if (task == null)
                return null;

            return new TaskDto(task.Id, task.Title, task.Description, task.Status, task.CreatedAt);
        }

        public async Task<TaskDto> Add(CreateTaskDto task)
        {
            var entity = new TaskItem
            {
                Title = task.Title,
                Description = task.Description,
                CreatedAt = DateTime.Now,
                Status = Enums.TaskItemStatus.Todo
            };
            
            await db.AddAsync(entity);
            await db.SaveChangesAsync();

            return new TaskDto(entity.Id, entity.Title, entity.Description, entity.Status, entity.CreatedAt);
        }

        public async Task Update(Guid id, UpdateTaskDto task)
        {
            var taskToUpdate = await db.Tasks.FindAsync(id);

            if (taskToUpdate == null)
                return;

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.Status = task.Status;
            taskToUpdate.UpdatedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var task = await db.Tasks.FindAsync(id);

            if (task == null)
                return;

            task.IsDeleted = true;
            await db.SaveChangesAsync();
        }
    }
}
