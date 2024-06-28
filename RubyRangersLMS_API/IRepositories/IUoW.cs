using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IUoW
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepository { get; }
        Task SaveAsync();
    }
}
