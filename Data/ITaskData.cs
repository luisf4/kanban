using Kanban.Models;

public interface ITaskData
{
    public List<Kanban.Models.Task> Read();
    public Kanban.Models.Task Read(int id);
    public void Create(Kanban.Models.Task task);
    public void Update(int id, Kanban.Models.Task task);
    public void Delete(int id);
}