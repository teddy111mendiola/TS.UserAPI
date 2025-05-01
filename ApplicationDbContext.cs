using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Buffers.Text;
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

        // add-migration "initial one": generates a migration file based on the current state of your data models compared to the database schema.
        //update-database: applies the migration to your database, creating or altering tables, columns, or relationships as defined in the migration file.
    }
}
