using AutoMapper;
using RubyRangersLMS_API.Dtos;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LmsMappings : Profile
    {
        public LmsMappings()
        {
            CreateMap<List<Student>, List<StudentDto>>();
            //CreateMap<Student, StudentDto>();
        }
    }
}
