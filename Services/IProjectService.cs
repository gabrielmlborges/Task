using Task.Models;

namespace Task.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> CreateProjectAsync(Project project);
    Task<Project?> GetProjectByIdAsync(int id);

}