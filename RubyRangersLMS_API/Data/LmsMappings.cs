using AutoMapper;
using RubyRangersLMS_API.Dtos;
using RubyRangersLMS_API.Dtos.ActivityDtos;
using RubyRangersLMS_API.Dtos.CourseDtos;
using RubyRangersLMS_API.Dtos.ModuleDtos;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public class LmsMappings : Profile
    {
        public LmsMappings()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }

    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDtoGet>()
              .ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.Modules))
              .AfterMap((src, dest) =>
              {
                  foreach (var module in dest.Modules)
                  {
                      module.CourseId = src.Id; // Set the foreign key based on the association
                  }
              });

            CreateMap<CourseDtoPost, Course>();
            CreateMap<Course, CourseDtoPost>();
        }
    }

    public class ModuleMappingProfile : Profile
    {
        public ModuleMappingProfile()
        {
            CreateMap<Module, ModuleDtoGet>()
              .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities))
              .AfterMap((src, dest) =>
              {
                  foreach (var activity in dest.Activities)
                  {
                      activity.ModuleId = src.Id; // Set the foreign key based on the association
                  }
              });

            CreateMap<ModuleDtoGet, Module>();

            CreateMap<ModuleDtoPost, Module>()
              .ForMember(dest => dest.CourseId, opt => opt.Ignore()) // CourseId is automatically set already
              .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities));

            CreateMap<Module, ModuleDtoPost>();
        }
    }

    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            CreateMap<Activity, ActivityDtoGet>();

            CreateMap<ActivityDtoGet, Activity>();

            CreateMap<ActivityDtoPost, Activity>()
              .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.ModuleId));

            CreateMap<Activity, ActivityDtoPost>();
        }
    }
}