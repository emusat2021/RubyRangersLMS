
using Microsoft.AspNetCore.Mvc;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository
    {
        public async Task<ActionResult<IEnumerable<T>>> GetAll();

        public async Task<ActionResult<T>> GetById(int id);

        public async Task<ActionResult<T>> Create(T user);

        public async Task<IActionResult> Update(int id, User user)

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
    }
}
