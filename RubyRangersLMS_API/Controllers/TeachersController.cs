using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            return Ok(TeachersFakeData.Current.Teachers);
        }
    }
}
