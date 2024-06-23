
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository <T>
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
