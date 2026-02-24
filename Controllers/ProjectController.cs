using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers;


[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {  var task = await _projectService.GetProjectByIdAsync(id)}
    retunr Ok(Project);

    [HttpPost]
    
    public async Task<IactionResult> CreateProject([fromBody] Project project)
    {
        if (project == null) return BadRequest("invalid data");
        var createdProject = await _projectService.CreateProjectAsync(project);
        return CreatedAtAction(nameof(GetById), new { id = createdProject.Id }, createdProject);
    }
}
