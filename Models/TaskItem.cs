namespace Task.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public TaskStatus Status { get; set; } = TaskStatus.Open;

    public int? ActiveUserId { get; set; }
    public User? ActiveUser { get; set; }

    public int? ConcluedById { get; set; }
    public User? ConcluedBy { get; set; }

    public int ProjectId { get; set; }
}
