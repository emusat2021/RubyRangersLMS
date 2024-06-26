using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repository
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
            return await context.Students.FindAsync(id);
        }

        public void Create(Student student)
        {
            context.Students.Add(student);
        }

        public async void Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public async void Remove(Student student)
        {
            context.Remove<Student>(student);
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await context.Students.AnyAsync(s => s.Id == id);
        }
    }
}