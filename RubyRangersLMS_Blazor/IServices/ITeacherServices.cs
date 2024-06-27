using RubyRangersLMS_Blazor.Models;

namespace RubyRangersLMS_Blazor.IServices
{
    public interface ITeacherServices
    {
        Task<IEnumerable<TeacherViewModel>> GetTeachersAsync();
        Task<bool> CreateTeachersAsync(TeacherCreateModel teacherCreateModel);
        Task<bool> DeleteTeachersAsync(Guid id);
    }




}
