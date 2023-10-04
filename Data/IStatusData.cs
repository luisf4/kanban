public interface IStatusData
{
    public List<Status> Read();
    public List<Status> Read(string search);
    public Status Read(int id);
    public void Create(Status status);
    public void Update(int id, Status status);
    public void Delete(int id);
}