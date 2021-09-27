using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    public class TodosController : Controller
    {
        // GET: Todos
        public ActionResult Index()
        {
            return View();
        }
    }
}