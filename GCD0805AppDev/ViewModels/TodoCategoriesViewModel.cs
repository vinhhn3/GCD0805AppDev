using GCD0805AppDev.Models;
using System.Collections.Generic;

namespace GCD0805AppDev.ViewModels
{
  public class TodoCategoriesViewModel
  {
    public Todo Todo { get; set; }
    public IEnumerator<Category> Categories { get; set; }
  }
}