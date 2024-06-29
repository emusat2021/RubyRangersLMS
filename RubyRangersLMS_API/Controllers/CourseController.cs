using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Dtos.CourseDtos;
using RubyRangersLMS_API.IRepositories;

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

            // Implement all validation logic
            return Ok(_mapper.Map<CourseDtoGet>(course));
        }
    }
}