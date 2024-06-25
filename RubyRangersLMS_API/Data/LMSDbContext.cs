using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LMSContext : IdentityDbContext<IdentityUser>
    {
        // public class LMSContext : DbContext
        // public class LMSContext : IdentityDbContext<IdentityUser>
        public LMSContext(DbContextOptions<LMSContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurriculumEntity>().UseTpcMappingStrategy();

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasMany(e => e.OwnedDocuments)
                    .WithOne(d => d.Owner)
                    .HasForeignKey(d => d.OwnerId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Students)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasMany(e => e.OwnedDocuments)
                    .WithOne(d => d.Owner)
                    .HasForeignKey(d => d.OwnerId);

                entity.HasMany(e => e.Courses)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey(c => c.TeacherId);
            });
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


