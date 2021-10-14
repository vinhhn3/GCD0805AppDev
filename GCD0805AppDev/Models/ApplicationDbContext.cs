using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GCD0805AppDev.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("gcd0808", throwIfV1Schema: false)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<UserTeam> UsersTeams { get; set; }
    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}