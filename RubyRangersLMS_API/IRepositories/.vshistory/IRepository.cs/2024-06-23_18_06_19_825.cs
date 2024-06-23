
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository <T>
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<T>> Create(T user);
        Task<IActionResult> Update(int id, T user);
        Task<IActionResult> Delete(int id);
    }
}
