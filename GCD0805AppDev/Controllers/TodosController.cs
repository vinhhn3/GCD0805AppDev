using GCD0805AppDev.Models;
using GCD0805AppDev.ViewModels;
using System.Data.Entity;
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
      var todos = _context.Todos
        .Include(t => t.Category)
        .ToList();

      return View(todos);
    }
    [HttpGet]
    public ActionResult Create()
    {
      var categories = _context.Categories.ToList();
      var viewModel = new TodoCategoriesViewModel()
      {
        Categories = categories
      };
      return View(viewModel);


    }

    [HttpPost]
    public ActionResult Create(TodoCategoriesViewModel model)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new TodoCategoriesViewModel
        {
          Todo = model.Todo,
          Categories = _context.Categories.ToList()
        };
        return View(viewModel);
      }

      var newTodo = new Todo()
      {
        Description = model.Todo.Description,
        DueDate = model.Todo.DueDate,
        CategoryId = model.Todo.CategoryId
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

    [HttpGet]
    public ActionResult Details(int id)
    {
      var todoInDb = _context.Todos
        .Include(t => t.Category)
        .SingleOrDefault(t => t.Id == id);

      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      return View(todoInDb);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      var viewModel = new TodoCategoriesViewModel
      {
        Todo = todoInDb,
        Categories = _context.Categories.ToList()
      };

      return View(viewModel);
    }

    [HttpPost]
    public ActionResult Edit(TodoCategoriesViewModel model)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new TodoCategoriesViewModel
        {
          Todo = model.Todo,
          Categories = _context.Categories.ToList()
        };
        return View(viewModel);
      }
      var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == model.Todo.Id);
      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      todoInDb.Description = model.Todo.Description;
      todoInDb.DueDate = model.Todo.DueDate;
      todoInDb.CategoryId = model.Todo.CategoryId;
      _context.SaveChanges();

      return RedirectToAction("Index", "Todos");
    }
  }
}