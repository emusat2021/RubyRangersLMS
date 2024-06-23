
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository
    {
        public Task<ActionResult<IEnumerable<T>>> GetAll();
        public Task<ActionResult<T>> GetById(int id);
        public Task<ActionResult<T>> Create(T user);
        public Task<IActionResult> Update(int id, T user);
        public Task<IActionResult> Delete(int id);
    }
}
