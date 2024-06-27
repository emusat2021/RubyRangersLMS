
namespace RubyRangersLMS_Blazor.IServices
{
    public interface IService<T>
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
