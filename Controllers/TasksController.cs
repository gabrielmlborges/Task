using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null) return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
    {
        if (task == null) return BadRequest("Invalid data");

        var createdTask = await _taskService.CreateTaskAsync(task);

        return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
    }
}
