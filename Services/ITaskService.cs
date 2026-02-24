using Task.Models;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem> CreateTaskAsync(TaskItem task);
    Task<TaskItem?> GetTaskByIdAsync(int id);
}
