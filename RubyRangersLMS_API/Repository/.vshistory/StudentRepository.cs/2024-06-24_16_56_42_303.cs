using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;
using AutoMapper;

namespace RubyRangersLMS_API.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(LMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
        }

        public async void Remove(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Remove<Student>(student);
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetById(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }
    }
}
