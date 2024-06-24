using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repository
{
    public class StudentRepository : IRepository
    {
        private readonly LMSContext context;

        public StudentRepository(LMSContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public Task<ActionResult<T>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<T>> Create(T user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }        

        public Task<IActionResult> Update(int id, T user)
        {
            throw new NotImplementedException();
        }
    }
}
