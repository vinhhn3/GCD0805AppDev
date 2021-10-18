using GCD0805AppDev.Repositories.IRepository;
using GCD0805AppDev.Utils;
using GCD0805AppDev.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
  [Authorize(Roles = Role.User)]
  public class TodosController : Controller
  {
    private ITodoRepository _repos;
    private ICategoryRepository _categoryRepos;
    public TodosController(ITodoRepository repos, ICategoryRepository categoryRepos)
    {
      _repos = repos;
      _categoryRepos = categoryRepos;

    }

    [HttpGet]
    public ActionResult Index(string searchString)
    {
      var userId = User.Identity.GetUserId();
      var todos = _repos.GetTodoes(searchString, userId);
      return View(todos);
    }
    [HttpGet]
    public ActionResult Create()
    {
      var categories = _categoryRepos.GetAll();
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
          Categories = _categoryRepos.GetAll()
        };
        return View(viewModel);
      }

      var userId = User.Identity.GetUserId();

      _repos.Create(model, userId);

      return RedirectToAction("Index", "Todos");
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
      var userId = User.Identity.GetUserId();

      if (!_repos.Remove(id, userId))
      {
        return HttpNotFound();
      }

      return RedirectToAction("Index", "Todos");
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
      var userId = User.Identity.GetUserId();

      var todoInDb = _repos.GetById(id, userId);

      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      return View(todoInDb);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var userId = User.Identity.GetUserId();


      var todoInDb = _repos.GetById(id, userId);
      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      var viewModel = new TodoCategoriesViewModel
      {
        Todo = todoInDb,
        Categories = _categoryRepos.GetAll()
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
          Categories = _categoryRepos.GetAll()
        };
        return View(viewModel);

      }
      var userId = User.Identity.GetUserId();

      var todoInDb = _repos.GetById(model.Todo.Id, userId);
      if (todoInDb == null)
      {
        return HttpNotFound();
      }

      _repos.Update(model, userId);

      return RedirectToAction("Index", "Todos");
    }

    [HttpGet]
    public ActionResult Stats()
    {
      var userId = User.Identity.GetUserId();

      var stats = _repos.GetStats(userId);

      return View(stats);
    }

    [HttpGet]
    public ActionResult Belong()
    {
      var userId = User.Identity.GetUserId();
      var teams = _repos.GetTeamsBelongTo(userId);

      return View(teams);
    }
  }
}