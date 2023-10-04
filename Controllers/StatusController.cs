using Microsoft.AspNetCore.Mvc;

public class StatusController : Controller
{
    private IStatusData data;

    public StatusController(IStatusData data)
    {
        this.data = data;
    }

    public ActionResult Index()
    {
        List<Status> lista = data.Read();
        return View(lista); 
    }

    public ActionResult Search(IFormCollection form)
    {
        string search = form["search"]; // <input name="search" />
        
        List<Status> lista = data.Read(search);
        return View("Index", lista);
    }

    [HttpGet]
    public ActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Status status)
    {
        data.Create(status);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) 
    {
        data.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Status status = data.Read(id);

        if(status == null)
            return RedirectToAction("Index");

        return View(status);
    }

    [HttpPost]
    public ActionResult Update(int id, Status status)
    {
        data.Update(id, status);
        return RedirectToAction("Index");
    }
}