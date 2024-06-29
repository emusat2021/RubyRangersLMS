using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly LMSContext _context;

        public StudentRepository(LMSContext context)
        {
            _context = context;
        }
        public StudentRepository(IDbContextFactory<LMSContext> context)
        {
            _context = context.CreateDbContext();
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await _context.Students.FindAsync(id) ?? new Student();
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Remove(Student student)
        {
            _context.Remove(student);
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }
    }
}