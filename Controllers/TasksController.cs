using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers;

[ApiController] // Avisa que esta classe é uma API (ajuda com validações automáticas)
[Route("[controller]")] // Define a rota como /task
public class TasksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok("oi");
    }
}
