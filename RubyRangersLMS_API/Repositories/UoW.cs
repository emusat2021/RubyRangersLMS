using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repositories
{
    public class UoW : IUoW
    {
        private readonly LMSContext _context;

        public IRepository<Student> StudentRepository { get; private set; }
        public IRepository<Course> CourseRepository { get; private set; }

        public UoW(LMSContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            CourseRepository = new CourseRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}