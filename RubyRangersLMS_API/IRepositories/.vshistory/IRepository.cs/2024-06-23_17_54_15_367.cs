
namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository
    {
        public IEnumerable<string> GetAll();
        public string GetById(int id);
        public void CreateEntity(string value);
        public void UpdateEntity(int id, string value);
        public void DeleteEntity(int id);
    }
}
