using Microsoft.EntityFrameworkCore;
using web_dev_assignment.Models;

namespace web_dev_assignment.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Users { get; set; } // Example DbSet
    }
}
