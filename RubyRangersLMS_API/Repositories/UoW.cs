using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repositories
{
    public class UoW : IUoW
    {
        private readonly IDbContextFactory<LMSContext> _context;

        public IRepository<Student> StudentRepository { get; private set; }
        public IRepository<Course> CourseRepository { get; private set; }

        public UoW(IDbContextFactory<LMSContext> context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            CourseRepository = new CourseRepository(_context);
        }

        public async Task SaveAsync()
        {
            using var context = _context.CreateDbContext();
            await context.SaveChangesAsync();
        }
    }
}
