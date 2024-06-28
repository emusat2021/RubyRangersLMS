using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherViewModel>>> GetTeachers()
        {
            var response = await _teacherRepository.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherCreateModel>> CreateTeacher(TeacherCreateModel teacherCreateModel)
        {
            
            var response = await _teacherRepository.Add(teacherCreateModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherDeleteModel>> DeleteTeacher(Guid id)
        {
            var success = await _teacherRepository.Delete(id);
            if (!success)
            {
                return NotFound($"Teacher not found with id {id}");
            }
            return Ok("Teacher deleted...");

        }
    }
}
