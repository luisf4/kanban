public class TaskData : ITaskData
{
    private List<Tasks> lista = new List<Tasks>();

    public List<Tasks> Read()
    {
        return lista;
    }

    public List<Tasks> Read(string search)
    {
        var result = from l in lista
                    where l.Title.ToLower().Contains(search.ToLower())
                    select l;

        return result.ToList();
    }

    public void Create(Tasks task) 
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

    public Tasks Read(int id)
    {
        return lista.FirstOrDefault(task => task.TaskId == id);
    }

    public void Update(int id, Tasks task)
    {
        Tasks taskToUpdate = lista.First(task => task.TaskId == id);
        taskToUpdate.Title = task.Title;
        taskToUpdate.Description = task.Description;
        taskToUpdate.Points = task.Points;
        taskToUpdate.Priority = task.Priority;
    }
}