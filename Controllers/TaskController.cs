using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

public class TaskController : Controller
{
    private ITaskData data;
    private IStatusData statusData;

    public TaskController(ITaskData data, IStatusData statusData)
    {
        this.data = data;
        this.statusData = statusData;
    }

    public ActionResult Index()
    {
        List<Kanban.Models.Task> lista = data.Read();
        List<Status> _status = statusData.Read();

        var tasks = lista.Select(t => 
            new Kanban.Models.Task() {
                TaskId = t.TaskId,
                Title = t.Title,
                Description = t.Description,
                Points = t.Points,
                Priority = t.Priority,
                Status = _status.FirstOrDefault(
                    (s) => s.StatusId == t.Status.StatusId)!
            });

        return View(tasks.ToList()); 
    }
    
    [HttpGet]
    public ActionResult Create() 
    {
        ViewBag.Status = statusData.Read();
        return View();
    }

    [HttpPost]
    public ActionResult Create(Kanban.Models.Task task)
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
        Kanban.Models.Task task = data.Read(id);

        if(task == null)
            return RedirectToAction("Index");

        return View(task);
    }

    [HttpPost]
    public ActionResult Update(int id, Kanban.Models.Task task)
    {
        data.Update(id, task);
        return RedirectToAction("Index");
    }
}