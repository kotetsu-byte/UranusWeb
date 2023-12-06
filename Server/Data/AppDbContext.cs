using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<PartVideo> PartVideos { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
