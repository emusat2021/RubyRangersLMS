using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetTeachers()
        {
            return new JsonResult(
            new List<object>{
            new {id = 1, Name = "Teacher1"} });
        }
    }
}
