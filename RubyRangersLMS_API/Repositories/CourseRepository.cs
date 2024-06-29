using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly LMSContext _context;

        /*
         * Alternativ: Injecerar inte direkt, blir mer modulärt (lättare att testa).
         *
         *      private readonly LMSContext _context;
         *      public CourseRepository(IDbContextFactory<LMSContext> context)
         *      {
         *          _context = context.CreateDbContext();
         *      }
         */

        public CourseRepository(LMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.Include(c => c.Modules).ThenInclude(m => m.Activities).ToListAsync();
        }

        public async Task<Course> GetById(Guid id)
        {
            return await _context.Courses
                .Where(c => c.Id == id)
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