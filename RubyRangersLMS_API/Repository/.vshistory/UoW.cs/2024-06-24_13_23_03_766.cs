using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;

namespace RubyRangersLMS_API.Repository
{
    public class UoW : IUoW
    {
        private LMSDBContext dbContext;
        public UoW(LMSDBContext dbContext)
        {
            this.dbContext = dbContext;
            studentRepository = new StudentRepository(dbContext);

        }
        public IRepository<Student> studentRepository { get; set; }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
