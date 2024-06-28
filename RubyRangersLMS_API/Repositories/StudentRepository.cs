using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly LMSContext _context;

        public StudentRepository(IDbContextFactory<LMSContext> dBFactory)
        {
            _context = dBFactory.CreateDbContext();
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetAsync(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
        }

        public async void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public async void Remove(Student student)
        {
            _context.Remove(student);
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }
    }
}