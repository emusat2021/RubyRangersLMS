using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TeacherViewModel>> GetTeachers()
        {
            var teachers = TeachersFakeData.Current.Teachers;
            var response = teachers.Select(t => new TeacherViewModel
            {
                Id = t.Id,
                UserName = t.UserName,
                FullName = t.FullName,
                Email = t.Email,

            }).ToList();

            return Ok(response);
        }
    }
}
