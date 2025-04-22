using Bill_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Bill_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Bill> bills { get; set; }
    }
}
