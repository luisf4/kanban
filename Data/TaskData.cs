using Kanban.Models;

public class TaskData : ITaskData
{
    private List<Kanban.Models.Task> lista = new List<Kanban.Models.Task>();

    public List<Kanban.Models.Task> Read()
    {
        return lista;
    }

    public void Create(Kanban.Models.Task task) 
    {
        lista.Add(task);
    }

    public void Delete(int id)
    {
        foreach(var task in lista) 
        {
            if(task.TaskId == id)
            {
                lista.Remove(task);
                break;
            }
        }
    }

    public Kanban.Models.Task Read(int id)
    {
        return lista.FirstOrDefault(task => task.TaskId == id);
    }

    public void Update(int id, Kanban.Models.Task Task)
    {
        Kanban.Models.Task TaskToUpdate = lista.First(task => task.TaskId == id);
        TaskToUpdate.Title = Task.Title;
    }
}