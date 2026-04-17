using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;

namespace TaskManager.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
