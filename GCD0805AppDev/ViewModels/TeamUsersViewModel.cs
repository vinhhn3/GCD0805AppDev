using GCD0805AppDev.Models;
using System.Collections.Generic;

namespace GCD0805AppDev.ViewModels
{
  public class TeamUsersViewModel
  {
    public Team Team { get; set; }
    public List<ApplicationUser> Users { get; set; }
  }
}