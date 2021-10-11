using GCD0805AppDev.Models;
using GCD0805AppDev.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
  [Authorize(Roles = Role.Admin)]
  public class AdminController : Controller
  {
    private ApplicationDbContext _context;
    private ApplicationUserManager _userManager;
    public AdminController()
    {
      _context = new ApplicationDbContext();
    }
    public AdminController(ApplicationUserManager userManager)
    {
      _context = new ApplicationDbContext();
      UserManager = userManager;
    }

    public ApplicationUserManager UserManager
    {
      get
      {
        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
      }
      private set
      {
        _userManager = value;
      }
    }
    // GET: Admin
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult CreateManager()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateManager(RegisterViewModel viewModel)
    {
      if (ModelState.IsValid)
      {
        var user = new ApplicationUser { UserName = viewModel.Email, Email = viewModel.Email };
        var result = await UserManager.CreateAsync(user, viewModel.Password);
        if (result.Succeeded)
        {
          await UserManager.AddToRoleAsync(user.Id, Role.Manager);


          // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
          // Send an email with this link
          // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
          // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
          // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

          return RedirectToAction("Index", "Home");
        }
        AddErrors(result);
      }

      // If we got this far, something failed, redisplay form
      return View(viewModel);
    }

    [HttpGet]
    public ActionResult GetManagers()
    {
      var role = _context.Roles.SingleOrDefault(m => m.Name == Role.Manager);
      var managers = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();
      ViewBag.Title = "Get Managers";
      return View("AccountInfo", managers);
    }

    [HttpGet]
    public ActionResult GetUsers()
    {
      var role = _context.Roles.SingleOrDefault(m => m.Name == Role.User);
      var users = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();
      ViewBag.Title = "Get Users";
      return View("AccountInfo", users);
    }

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("", error);
      }
    }
  }
}