
namespace RubyRangersLMS_Blazor.IServices
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(Guid id, T entity);
        void DeleteAsync(Guid id);
    }
}
