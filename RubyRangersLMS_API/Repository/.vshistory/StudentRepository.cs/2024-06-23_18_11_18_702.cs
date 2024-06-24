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
            context.Users.Add(user);
            context.SaveChangesAsync();
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Student>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(int id, Student user)
        {
            throw new NotImplementedException();
        }
    }
}
