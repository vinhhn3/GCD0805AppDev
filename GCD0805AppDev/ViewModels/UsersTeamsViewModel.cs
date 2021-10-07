using GCD0805AppDev.Models;
using System.Collections.Generic;

namespace GCD0805AppDev.ViewModels
{
  public class UsersTeamsViewModel
  {
    public int TeamId { get; set; }
    public List<Team> Teams { get; set; }
    public string UserId { get; set; }
    public List<ApplicationUser> Users { get; set; }
  }
}