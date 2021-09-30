using GCD0805AppDev.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
  public class TodosController : Controller
  {
    private ApplicationDbContext _context;
    public TodosController()
    {
      _context = new ApplicationDbContext();
    }
    [HttpGet]
    public ActionResult Index()
    {
      var todos = _context.Todos.ToList();
      return View(todos);
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Todo todo)
    {
      var newTodo = new Todo()
      {
        Description = todo.Description,
        DueDate = todo.DueDate
      };

      _context.Todos.Add(newTodo);
      _context.SaveChanges();

      return RedirectToAction("Index", "Todos");
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
      var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      _context.Todos.Remove(todoInDb);
      _context.SaveChanges();

      return RedirectToAction("Index", "Todos");
    }
  }
}