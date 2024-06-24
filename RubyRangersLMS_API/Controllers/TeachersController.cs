using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        [HttpGet("api/teachers")]
        public JsonResult GetTeachers()
        {
            return new JsonResult(
            new List<object>{
            new {id = 1, Name = "Teacher1"} });
        }
    }
}
