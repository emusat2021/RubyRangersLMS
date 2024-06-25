
namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> AnyAsync(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Remove(Guid id);
    }
}
