using GCD0805AppDev.Models;
using GCD0805AppDev.Repositories.IRepository;
using GCD0805AppDev.ViewModels;
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

    public void Create(TodoCategoriesViewModel model, string userId)
    {
      var newTodo = new Todo()
      {
        Description = model.Todo.Description,
        DueDate = model.Todo.DueDate,
        CategoryId = model.Todo.CategoryId,
        UserId = userId
      };

      _context.Todos.Add(newTodo);
      _context.SaveChanges();
    }

    public IEnumerable<Todo> GetTodoes(string searchString, string userId)
    {
      var todos = _context.Todos.Include(t => t.Category)
        .Where(t => t.UserId == userId)
        .ToList();
      if (!string.IsNullOrEmpty(searchString))
      {
        todos = todos
         .Where(t => t.Description.ToLower().Contains(searchString.ToLower())
             || t.Category.Description.ToLower().Contains(searchString.ToLower())
         ).ToList();
      }

      return todos;
    }

    public bool Remove(int id, string userId)
    {
      var todoInDb = _context.Todos
        .SingleOrDefault(t => t.Id == id && t.UserId == userId);
      if (todoInDb == null)
      {
        return false;
      }

      _context.Todos.Remove(todoInDb);
      _context.SaveChanges();

      return true;
    }
  }
}