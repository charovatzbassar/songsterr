using Microsoft.EntityFrameworkCore;
using Project_Task.Models;

namespace Project_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Song> Songs { get; set; } // Example table
    }
}