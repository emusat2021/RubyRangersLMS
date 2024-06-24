using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Repository;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUoW uow;

        public StudentController(IUoW uow)
        {
            this.uow = uow;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await uow.studentRepository.GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await uow.studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public Task<ActionResult<Student>> PostStudent(Student student)
        {
            uow.studentRepository.Create(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            uow.studentRepository.Update(student);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.Students.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = uow.studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            uow.studentRepository.Remove(student);

            try
            {
                await uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return (!GameExists(id)) ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }
    }
}
