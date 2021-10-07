using GCD0805AppDev.Models;
using GCD0805AppDev.Utils;
using GCD0805AppDev.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{

  [Authorize(Roles = Role.Manager)]
  public class TeamsController : Controller
  {
    private ApplicationDbContext _context;
    public TeamsController()
    {
      _context = new ApplicationDbContext();
    }
    [HttpGet]
    public ActionResult Index()
    {
      List<TeamUsersViewModel> viewModel = _context.UsersTeams
        .GroupBy(i => i.Team)
        .Select(res => new TeamUsersViewModel
        {
          Team = res.Key,
          Users = res.Select(u => u.User).ToList()
        })
        .ToList();

      return View(viewModel);
    }

    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Team team)
    {
      if (!ModelState.IsValid)
      {
        return View(team);
      }

      var newTeam = new Team()
      {
        Name = team.Name
      };

      _context.Teams.Add(newTeam);
      _context.SaveChanges();

      return RedirectToAction("Index", "Teams");
    }

    [HttpGet]
    public ActionResult AddUser()
    {
      var role = _context.Roles.SingleOrDefault(m => m.Name == Role.User);
      var viewModel = new UsersTeamsViewModel
      {
        Teams = _context.Teams.ToList(),
        Users = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList()
      };

      return View(viewModel);
    }

    [HttpPost]
    public ActionResult AddUser(UsersTeamsViewModel viewModel)
    {
      var model = new UserTeam
      {
        TeamId = viewModel.TeamId,
        UserId = viewModel.UserId
      };

      _context.UsersTeams.Add(model);
      _context.SaveChanges();

      return RedirectToAction("Index", "Teams");

    }

  }
}