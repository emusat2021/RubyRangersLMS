using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LMSContext : DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurriculumEntity>().UseTpcMappingStrategy();
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


