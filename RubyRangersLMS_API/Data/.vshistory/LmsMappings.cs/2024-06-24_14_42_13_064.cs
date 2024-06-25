using AutoMapper;
using RubyRangersLMS_API.Dtos;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LmsMappings
    {
        public LmsMappings()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
