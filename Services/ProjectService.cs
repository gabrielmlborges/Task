using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Services;
public class ProjectService : IProjectService
{
    private readonly AppDbContext _context;
    public ProjectService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.ToListAsync();
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        return project;
    }
    public async Task<Project> CreateProjectAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }
}