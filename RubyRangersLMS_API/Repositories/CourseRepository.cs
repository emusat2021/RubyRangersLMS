using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly LMSContext _context;
        public CourseRepository(IDbContextFactory<LMSContext> dBFactory)
        {
            _context = dBFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(c => c.Modules).ThenInclude(m => m.Activities).ToListAsync();
        }

        public async Task<Course> GetAsync(Guid guid)
        {
            return await _context.Courses
                .Where(c => c.Id == guid)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Activities)
                .FirstOrDefaultAsync();
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
        }

        // Not a must, leave it as a not-needed thing to do
        public void Remove(Course course)
        {
            _context.Remove(course);
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await _context.Courses.AnyAsync(s => s.Id == id);
        }
    }
}