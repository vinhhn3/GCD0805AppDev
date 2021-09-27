using GCD0805AppDev.Models;
using System;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
  public class TodosController : Controller
  {
    // GET: Todos
    public ActionResult Index()
    {
      Todo todo = new Todo()
      {
        Id = 1,
        Description = "Kill Bill",
        DueDate = new DateTime(2008, 12, 20)
      };
      return View(todo);
    }
  }
}