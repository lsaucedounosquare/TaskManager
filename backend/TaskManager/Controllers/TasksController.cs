using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs;
using TaskManager.Enums;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private ILogger<TasksController> logger;

        public TasksController(ITaskService taskService, ILogger<TasksController> logger)
        {
            this.taskService = taskService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TaskItemStatus? status = null)
        {
            try
            {
                var tasks = await this.taskService.GetAll(status);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var task = await this.taskService.GetById(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto createTaskDto)
        {
            try
            {
                var task = await this.taskService.Add(createTaskDto);
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, UpdateTaskDto updateTaskDto)
        {
            try
            {
                await this.taskService.Update(id, updateTaskDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await taskService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
