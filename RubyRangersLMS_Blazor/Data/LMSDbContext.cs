using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_Blazor.Entities;

namespace RubyRangersLMS_Blazor.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurriculumEntity>().UseTpcMappingStrategy();
        }
            public DbSet<CurriculumEntity> CurriculumEntities { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Module> Modules { get; set; }
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Document> Documents { get; set; }
    }
}


