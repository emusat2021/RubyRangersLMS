using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LMSContext _context;
        public CourseRepository(IDbContextFactory<LMSContext> dBFactory)
        {
            _context = dBFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.Include(c => c.Modules).ThenInclude(m => m.Activities).ToListAsync();
        }

        public async Task<Course> GetCourse(Guid guid)
        {
            return await _context.Courses
                .Where(c => c.Id == guid)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Activities)
                .FirstOrDefaultAsync();
        }
    }
}