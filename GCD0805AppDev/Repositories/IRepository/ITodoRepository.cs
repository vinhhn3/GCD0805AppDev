using GCD0805AppDev.Models;
using System.Collections.Generic;

namespace GCD0805AppDev.Repositories.IRepository
{
  public interface ITodoRepository
  {
    IEnumerable<Todo> GetTodoes(string searchString);
  }
}