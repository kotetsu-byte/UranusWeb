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
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .HasOne(c => c.Course)
                .WithMany(l => l.Lessons)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasOne(c => c.Course)
                .WithMany(t => t.Tests)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<About>()
                .HasOne(c => c.Course)
                .WithOne(a => a.About)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doc>()
                .HasOne(l => l.Lesson)
                .WithMany(d => d.Docs)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Homework>()
                .HasOne(l => l.Lesson)
                .WithMany(h => h.Homeworks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
                .HasOne(l => l.Lesson)
                .WithMany(v => v.Videos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(h => h.Homework)
                .WithMany(m => m.Materials)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FAQ>()
                .HasOne(a => a.About)
                .WithMany(f => f.FAQs)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartVideo>()
                .HasOne(a => a.About)
                .WithOne(pv => pv.PartVideo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne(a => a.About)
                .WithMany(r => r.Results)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(a => a.About)
                .WithMany(r => r.Reviews)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });
        }
    }
}
