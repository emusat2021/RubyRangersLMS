using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repository
{
    public class UoW : IUoW
    {
        private LMSContext dbContext;
        public UoW()
        {
            this.dbContext = dbContext;
            studentRepository = new StudentRepository(dbContext);

        }
        public IRepository<Student> studentRepository => throw new NotImplementedException();

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
