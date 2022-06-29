using APItest.Models;
using Microsoft.EntityFrameworkCore;

namespace APItest.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options): base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
