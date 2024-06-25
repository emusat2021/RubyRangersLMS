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
                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dto => dto.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dto => dto.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dto => dto.PhoneNumberConfirmed, opt => opt.MapFrom(src => src.PhoneNumberConfirmed))
                .ForMember(dto => dto.TwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled))
                .ForMember(dto => dto.LockoutEnabled, opt => opt.MapFrom(src => src.LockoutEnabled))
                .ForMember(dto => dto.AccessFailedCount, opt => opt.MapFrom(src => src.AccessFailedCount));

        }
    }
}
