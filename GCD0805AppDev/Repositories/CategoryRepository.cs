using GCD0805AppDev.Models;
using GCD0805AppDev.Repositories.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace GCD0805AppDev.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private ApplicationDbContext _context;
    public CategoryRepository()
    {
      _context = new ApplicationDbContext();
    }
    public List<Category> GetAll()
    {
      return _context.Categories.ToList();
    }
  }
}