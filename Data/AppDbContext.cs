using Microsoft.EntityFrameworkCore;
using NSS_API.Models;

namespace NSS_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ClassRoom> Classes { get; set; } // Table name 'Classes' in SQL
    }

    public class ClassRoom // Model for your 16 classes
    {
        public int ClassID { get; set; }
        public string CourseName { get; set; }
        public string Year { get; set; }
        public string SecretLeaderID { get; set; }
    }
}