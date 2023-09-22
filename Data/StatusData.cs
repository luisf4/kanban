public class StatusData
{
    private List<Status> lista = new List<Status>();

    public StatusData()
    {
        lista.Add(new Status { StatusId = 1, Name = "To do"});
        lista.Add(new Status { StatusId = 2, Name = "Doing"});
        lista.Add(new Status { StatusId = 3, Name = "Done"});
    }

    public List<Status> Read()
    {
        return lista;
    }

    public List<Status> Read(string search)
    {
        List<Status> result = new List<Status>();

        foreach(var status in lista)
        {
            if(status.Name.ToLower().Contains(search.ToLower()))
            {
                result.Add(status);
            }
        }

        return result;
    }

}