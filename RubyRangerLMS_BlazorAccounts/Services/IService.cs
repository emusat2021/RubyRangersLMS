namespace RubyRangerLMS_BlazorAccounts.Services
{
    public interface IService <T>
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(Guid id, T entity);
        void DeleteAsync(Guid id);
    }
}
