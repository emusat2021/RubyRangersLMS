using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Dtos.CourseDtos;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Repositories;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUoW _uow;
        private readonly IMapper _mapper;

        public CourseController(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDtoGet>>> GetAllCourses()
        {
            var courses = await _uow.CourseRepository.GetAll();

            if (courses == null || !courses.Any())
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<IEnumerable<CourseDtoGet>>(courses));
        }

        [HttpGet("{id}")] // [FromRoute]
        public async Task<ActionResult<CourseDtoGet>> GetCourse(Guid id)
        {
            var course = await _uow.CourseRepository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CourseDtoGet>(course));
        }
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CourseDtoPost courseDtoPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = _mapper.Map<Course>(courseDtoPost);

            foreach (var module in course.Modules)
            {
                module.CourseId = course.Id;
                foreach (var activity in module.Activities)
                {
                    activity.ModuleId = module.Id;
                }
            }

            _uow.CourseRepository.Create(course);

            await _uow.SaveAsync();

            var courseDtoGet = _mapper.Map<CourseDtoGet>(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, courseDtoGet);
        }
    }
}

//Testjson för Post
//{
//  "Id": "123e4567-e89b-12d3-a456-426614174000",
//  "Name": "Course Name",
//  "Description": "Course Description.",
//  "StartDate": "2024-07-01T00:00:00",
//  "EndDate": "2024-12-01T00:00:00",
//  "TeacherId": "1cae9ed4-c6ad-4979-a31f-db26570daee2",
//  "Modules": [
//    {
//        "Id": "223e4567-e89b-12d3-a456-426614174001",
//      "Name": "Module Name",
//      "Description": "Module Description.",
//      "StartDate": "2024-07-01T00:00:00",
//      "EndDate": "2024-08-01T00:00:00",
//      "CourseId": "123e4567-e89b-12d3-a456-426614174000",
//      "Activities": [
//        {
//            "Id": "323e4567-e89b-12d3-a456-426614174002",
//          "Name": "Activity Name",
//          "Description": "Activity Description",
//          "StartDate": "2024-07-01T00:00:00",
//          "EndDate": "2024-07-07T00:00:00",
//          "ModuleId": "223e4567-e89b-12d3-a456-426614174001"
//        }
//      ]
//    }
//  ]
//}

