using Microsoft.EntityFrameworkCore;
using UserPortal.Models.Entities;

namespace UserPortal
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
