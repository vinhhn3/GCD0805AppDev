﻿using GCD0805AppDev.Models;
using GCD0805AppDev.Utils;
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
      var teams = _context.Teams.ToList();
      return View(teams);
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

  }
}