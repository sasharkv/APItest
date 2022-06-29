using APItest.Models;
using Microsoft.EntityFrameworkCore;

// REMEMBER to use these commands in Package Manager Console:
// Add-Migration whateverMigrationName -o Data/Migrations
// Update-Database

namespace APItest.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options): base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; } // Make sure the DbSet is of a correct type if yo autofil with tab!
    }
}
