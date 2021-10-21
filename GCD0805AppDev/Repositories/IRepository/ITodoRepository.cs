using GCD0805AppDev.Models;
using GCD0805AppDev.ViewModels;
using System.Collections.Generic;

namespace GCD0805AppDev.Repositories.IRepository
{
  public interface ITodoRepository
  {
    IEnumerable<Todo> GetTodoes(string searchString, string userId);
    IEnumerable<Todo> GetTodoes();

    void Create(TodoCategoriesViewModel model, string userId);
    bool Remove(int id, string userId);
    Todo GetById(int id, string userId);
    void Update(TodoCategoriesViewModel model, string userId);

    IEnumerable<Stats> GetStats(string userId);
    IEnumerable<Team> GetTeamsBelongTo(string userId);
  }
}