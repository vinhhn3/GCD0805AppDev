using GCD0805AppDev.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace GCD0805AppDev.Controllers.Api
{
  public class TodosController : ApiController
  {
    private ApplicationDbContext _context;
    //public TodosController()
    //{
    //  _context = new ApplicationDbContext();
    //}

    public TodosController()
    {

      _context = new ApplicationDbContext();
    }
    [HttpGet]
    public IHttpActionResult GetAll()
    {
      var todos = _context.Todos
        .Include(t => t.Category)
        .Include(t => t.User)
        .ToList();
      return Ok(todos);
    }

    [HttpGet]
    public IHttpActionResult GetById(int id)
    {
      var todo = _context.Todos
        .Include(t => t.Category)
        .Include(t => t.User)
        .SingleOrDefault(t => t.Id == id);
      if (todo == null) return NotFound();
      else return Ok(todo);
    }

    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
      var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
      if (todo == null) return NotFound();

      _context.Todos.Remove(todo);
      _context.SaveChanges();
      return Ok($"Todo with Id: {todo.Id} is removed ...");
    }

    [HttpPost]
    public IHttpActionResult Create([FromBody] Todo model)
    {
      var todo = new Todo
      {
        CategoryId = model.CategoryId,
        Description = model.Description,
        DueDate = model.DueDate,
        UserId = model.UserId
      };

      _context.Todos.Add(todo);
      _context.SaveChanges();
      return Content(HttpStatusCode.Created, $"New Todo with Id: {todo.Id} and " +
        $"description: {todo.Description} is created");
    }

    [HttpPut]
    public IHttpActionResult Replace(int id, [FromBody] Todo model)
    {
      var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
      if (todo == null) return NotFound();
      todo.UserId = model.UserId;
      todo.CategoryId = model.CategoryId;
      todo.Description = model.Description;
      todo.DueDate = model.DueDate;

      _context.SaveChanges();
      return Ok();
    }
  }
}
