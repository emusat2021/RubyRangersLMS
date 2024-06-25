using AutoMapper;
using RubyRangersLMS_API.Dtos;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LmsMappings : Profile
    {
        public LmsMappings()
        {
            //CreateMap<StudentDto, Student>()
            //    .ForMember(dest => dest.UserName, src => src.Ignore())
            //    .ForMember(dest => dest.NormalizedUserName, src => src.Ignore())
            //    .ForMember(dest => dest.NormalizedEmail, src => src.Ignore())
            //    .ForMember(dest => dest.PasswordHash, src => src.Ignore())
            //    .ForMember(dest => dest.SecurityStamp, src => src.Ignore())
            //    .ForMember(dest => dest.ConcurrencyStamp, src => src.Ignore())
            //    .ForMember(dest => dest.LockoutEnd, src => src.Ignore());

            CreateMap<Student, StudentDto>();

        }
    }
}
