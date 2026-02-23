namespace Task.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<User> Users { get; set; } = new();

    public List<TaskItem> Tasks { get; set; } = new();
}
