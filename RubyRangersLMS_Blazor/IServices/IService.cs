
namespace RubyRangersLMS_Blazor.IServices
{
    public interface IService<T>
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}