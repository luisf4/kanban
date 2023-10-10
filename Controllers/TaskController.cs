using Microsoft.AspNetCore.Mvc;

public class TaskController : Controller
{
    private ITaskData data;

    public TaskController(ITaskData data)
    {
        this.data = data;
    }

    public ActionResult Index()
    {
        List<Tasks> lista = data.Read();
        return View(lista); 
    }

    public ActionResult Search(IFormCollection form)
    {
        string search = form["search"]; // <input name="search" />
        
        List<Tasks> lista = data.Read(search);
        return View("Index", lista);
    }

    [HttpGet]
    public ActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Tasks task)
    {
        data.Create(task);
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
        Tasks task = data.Read(id);

        if(task == null)
            return RedirectToAction("Index");

        return View(task);
    }

    [HttpPost]
    public ActionResult Update(int id, Tasks task)
    {
        data.Update(id, task);
        return RedirectToAction("Index");
    }
}