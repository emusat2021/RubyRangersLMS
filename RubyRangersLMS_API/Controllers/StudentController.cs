using AutoMapper;
using RubyRangersLMS_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Entities;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUoW uow;
        private readonly IMapper mapper;

        public StudentController(IUoW uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
        {
            var students = await uow.StudentRepository.GetAll();

            if (students == null)
                return NotFound();

            var studentsDto = mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentsDto);
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var student = await uow.StudentRepository.GetById(id);

            if (student == null)
                return NotFound();

            var studentDto = mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        // POST api/student
        [HttpPost("add")]
        public async Task<ActionResult> PostStudent(StudentDto studentDto)
        {
            var student = mapper.Map<Student>(studentDto);
            uow.StudentRepository.Create(student);

            try
            {
                await uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/student/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutStudent(Guid id, StudentDto studentDto)
        {
            var student = mapper.Map<Student>(studentDto);

            uow.StudentRepository.Update(student);

            try
            {
                await uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return (!GameExists(id)) ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }

        // DELETE api/student/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await uow.StudentRepository.GetById(id);

            if (student == null)
                return NotFound();

            uow.StudentRepository.Remove(student);

            try
            {
                await uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return (!GameExists(id)) ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }

        private bool GameExists(Guid id)
        {
            return uow.StudentRepository.AnyAsync(id).Result;
        }
    }
}