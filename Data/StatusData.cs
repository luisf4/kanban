public class StatusData : IStatusData
{
    private List<Status> lista = new List<Status>();

    public List<Status> Read()
    {
        return lista;
    }

    public List<Status> Read(string search)
    {
        // var result = lista
        //     .Where((status) => status.Name.ToLower().Contains(search.ToLower()))
        //     .ToList();

        // SELECT * FROM lista l WHERE l.Name LIKE "%search%"
        var result = from l in lista
                    where l.Name.ToLower().Contains(search.ToLower())
                    select l;

        return result.ToList();
    }

    public void Create(Status status) 
    {
        lista.Add(status);
    }

    public void Delete(int id)
    {
        foreach(var status in lista) 
        {
            if(status.StatusId == id)
            {
                lista.Remove(status);
                break;
            }
        }
    }

    public Status Read(int id)
    {
        return lista.FirstOrDefault(status => status.StatusId == id);
        // foreach(var status in lista)
        // {
        //     if(status.StatusId == id)
        //     {
        //         return status;
        //     }
        // }
    }

    public void Update(int id, Status status)
    {
        Status statusToUpdate = lista.First(status => status.StatusId == id);
        statusToUpdate.Name = status.Name;
    }

}