
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository <T>
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
