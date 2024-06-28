
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> AnyAsync(Guid id);
    }
}
