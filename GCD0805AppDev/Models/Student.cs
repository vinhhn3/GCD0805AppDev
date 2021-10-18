using System;

namespace GCD0805AppDev.Models
{
  public class Student : ApplicationUser
  {
    public string Education { get; set; }
    public DateTime DoB { get; set; }
  }
}