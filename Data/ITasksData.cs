public interface ITaskData
{
    public List<Tasks> Read();
    public List<Tasks> Read(string search);
    public Tasks Read(int id);
    public void Create(Tasks task);
    public void Update(int id, Tasks task);
    public void Delete(int id);
}
 