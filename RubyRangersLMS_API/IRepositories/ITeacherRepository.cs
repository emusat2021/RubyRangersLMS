using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.IRepositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherViewModel>> GetAll();
        Task<TeacherCreateModel> Add(TeacherCreateModel teacherCreateModel);
        Task<bool> Delete(Guid id);
    }
}