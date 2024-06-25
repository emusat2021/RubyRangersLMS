using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IUoW <T>
    {
        IRepository<T> studentRepository { get; }
        Task CompleteAsync();
    }
}
