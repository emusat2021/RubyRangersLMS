using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.Identity;


namespace RubyRangersLMS_API.Data
{
    public class LMSContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public LMSContext(DbContextOptions<LMSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CurriculumEntity>().UseTpcMappingStrategy();


            // Disable cascading delete for relationships involving Teachers and Courses
            //modelBuilder.Entity<Course>()
            //    .HasOne(c => c.Teacher)
            //    .WithMany(t => t.Courses)
            //    .HasForeignKey(c => c.TeacherId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CurriculumEntity> CurriculumEntities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}