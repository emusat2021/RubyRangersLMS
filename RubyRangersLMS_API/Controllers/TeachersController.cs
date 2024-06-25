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
        private readonly ITeacherRepository _teacherRepositoty;

        public TeachersController(ITeacherRepository teacherRepositoty)
        {
            _teacherRepositoty = teacherRepositoty;
        }

        //api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherViewModel>>> GetTeachers()
        {
            var response = await _teacherRepositoty.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherCreateModel>> CreateTeacher(TeacherCreateModel teacherCreateModel)
        {
            
            var response = await _teacherRepositoty.Add(teacherCreateModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherDeleteModel>> DeleteTeacher(Guid id)
        {
            var success = await _teacherRepositoty.Delete(id);
            if (!success)
            {
                return NotFound($"Teacher not found with id {id}");
            }
            return Ok("Teacher deleted...");

        }
    }
}
