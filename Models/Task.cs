namespace Kanban.Models;

public class Task
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public string Priority { get; set; }
    public Status Status { get; set; }
}
