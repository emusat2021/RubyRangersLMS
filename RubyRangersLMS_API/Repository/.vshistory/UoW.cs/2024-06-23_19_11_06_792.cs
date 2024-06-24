using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repository
{
    public class UoW : IUoW
    {
        public IRepository<Student> studentRepository => throw new NotImplementedException();

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
