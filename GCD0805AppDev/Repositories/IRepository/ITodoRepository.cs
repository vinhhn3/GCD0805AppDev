﻿using GCD0805AppDev.Models;
using GCD0805AppDev.ViewModels;
using System.Collections.Generic;

namespace GCD0805AppDev.Repositories.IRepository
{
  public interface ITodoRepository
  {
    IEnumerable<Todo> GetTodoes(string searchString);
    void Create(TodoCategoriesViewModel model, string userId);

    bool Remove(int id, string userId);
  }
}