using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC5.Models;

namespace MVC5.Context
{
    public class MvcDbContext : IdentityDbContext
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options)
        : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
