﻿using GCD0805AppDev.Models;
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
  }
}