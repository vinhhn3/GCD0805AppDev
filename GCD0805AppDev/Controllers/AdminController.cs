using GCD0805AppDev.Models;
using GCD0805AppDev.Utils;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
  [Authorize(Roles = Role.Admin)]
  public class AdminController : Controller
  {
    private ApplicationDbContext _context;
    public AdminController()
    {
      _context = new ApplicationDbContext();
    }
    // GET: Admin
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult CreateManager()
    {
      return View();
    }
  }
}