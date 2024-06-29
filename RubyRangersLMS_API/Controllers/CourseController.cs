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

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDtoGet>> GetCourse(Guid id)
        {
            var course = await _uow.CourseRepository.GetById(id);

            // All validation logic is left
            return Ok(_mapper.Map<CourseDtoGet>(course));
        }
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CourseDtoPost courseDtoPost)
        {
            var courseEntity = _mapper.Map<Course>(courseDtoPost);

            var modulesEntities = courseDtoPost.Modules.Select(moduleDtoPost =>
                _mapper.Map<Module>(moduleDtoPost)).ToList();
            var activitiesEntities = courseDtoPost.Modules.SelectMany(moduleDtoPost =>
                moduleDtoPost.Activities).Select(activityDtoPost =>
                _mapper.Map<Activity>(activityDtoPost)).ToList();

            foreach (var module in modulesEntities)
            {
                // Dates should be cloned from Course
            }

            foreach (var activity in activitiesEntities)
            {
                // Same here
            }

            _uow.CourseRepository.Create(courseEntity);

            // Complete the validation and dont forget doing the other APi's
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(new { message = "Course created successfully." });
        }
    }
}



