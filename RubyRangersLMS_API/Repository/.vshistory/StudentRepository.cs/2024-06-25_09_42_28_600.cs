using Microsoft.AspNetCore.Mvc;
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

        public void Create(Student student)
        {
            context.Students.Add(student);
        }

        public async void Remove(Guid id)
        {
            var student = await context.Students.FindAsync(id);
            context.Remove<Student>(student);
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetById(Guid id)
        {
            return await context.Students.FindAsync(id);
        }

        public async void Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await context.Students.AnyAsync(s => s.Id == id);
        }
    }
}
