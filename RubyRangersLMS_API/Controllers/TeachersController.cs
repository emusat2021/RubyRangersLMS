using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly LMSContext _context;

        public TeachersController(LMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<TeacherViewModel>>> GetTeachers()
        {
            try
            {

                var teachers = _context.Teachers;
                if (teachers == null)
                {
                    return NotFound();
                }
                var response = teachers.Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    UserName = t.UserName,
                    FullName = t.FullName,
                    Email = t.Email,

                }).ToList();

                if (response.Count == 0)
                {
                    return NotFound("No data Found...");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<TeacherCreateModel>> CreateTeacher(TeacherCreateModel teacherCreateModel)
        {
            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                UserName = teacherCreateModel.UserName,
                FullName = teacherCreateModel.FullName,
                Email = teacherCreateModel.Email,
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacherCreateModel);
        }

        [HttpDelete]
        public async Task<ActionResult<TeacherDeleteModel>> DeleteTeacher(Guid id)
        {
            try
            {
                var teacher = _context.Teachers.Find(id);
                if (teacher == null)
                {
                    return NotFound($"Teacher is not found with id{id}");
                }
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return Ok("Teacher deleted...");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
