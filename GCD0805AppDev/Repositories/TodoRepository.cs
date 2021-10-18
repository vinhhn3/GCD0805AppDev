using GCD0805AppDev.Models;
using GCD0805AppDev.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GCD0805AppDev.Repositories
{
  public class TodoRepository : ITodoRepository
  {
    private ApplicationDbContext _context;
    public TodoRepository()
    {
      _context = new ApplicationDbContext();

    }
    public IEnumerable<Todo> GetTodoes(string searchString)
    {
      var todos = _context.Todos.Include(t => t.Category).ToList();
      if (!string.IsNullOrEmpty(searchString))
      {
        todos = todos
         .Where(t => t.Description.ToLower().Contains(searchString.ToLower())
             || t.Category.Description.ToLower().Contains(searchString.ToLower())
         ).ToList();
      }

      return todos;
    }
  }
}