using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.Repository;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository repo;

        public StudentController(StudentRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await repo.GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await repo.GetById(id);

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
            repo.Create(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            var studentId = Int32.Parse(student.Id.ToString());
            if (id != studentId)
            {
                return BadRequest();
            }

            repo.Update(student);

            

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
