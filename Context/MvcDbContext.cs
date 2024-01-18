using Microsoft.EntityFrameworkCore;
using MVC5.Models;

namespace MVC5.Context
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options)
        : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
    }
}
