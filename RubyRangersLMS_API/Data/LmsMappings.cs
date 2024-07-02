using AutoMapper;
using RubyRangersLMS_API.Dtos;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LmsMappings : Profile
    {
        public LmsMappings()
        {
            CreateMap<Student, StudentDto>()
                 .ForMember(dto => dto.CourseName, opt => opt.MapFrom(src => src.Course.Name));

            CreateMap<StudentDto, Student>();
        }
    }
}
