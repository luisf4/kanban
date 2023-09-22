using Microsoft.AspNetCore.Mvc;

public class StatusController : Controller
{
    public ActionResult Index()
    {
        StatusData data = new StatusData();
        List<Status> lista = data.Read();
        return View(lista); 
    }

    public ActionResult Search(IFormCollection form)
    {
        string search = form["search"]; // <input name="search" />
        // criar um método em StatusData para realizar a pesquisa
        // de status por parte do nome.
        // Exemplo: search = "do"
        // Retorno List<Status> ("to do", "doing", "done")
        // "xpto".Contains("xp") => true

        StatusData data = new StatusData();
        List<Status> lista = data.Read(search);
        return View("Index", lista);
    }
}