using Microsoft.EntityFrameworkCore;
using PracticeForRestApi.Models;

namespace PracticeProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Practice> Practices { get; set; }
    }
}
