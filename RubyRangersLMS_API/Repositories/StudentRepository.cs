using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly LMSContext context;

        public StudentRepository(LMSContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await context.Students.FindAsync(id) ?? new Student();
        }

        public void Create(Student student)
        {
            context.Students.Add(student);
        }

        public void Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Remove(Student student)
        {
            context.Remove(student);
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await context.Students.AnyAsync(s => s.Id == id);
        }
    }
}