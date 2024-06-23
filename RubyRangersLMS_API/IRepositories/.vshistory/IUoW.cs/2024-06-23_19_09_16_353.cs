using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IUoW
    {
        IRepository<Student> tournamentRepository { get; }
        Task CompleteAsync();
    }
}
