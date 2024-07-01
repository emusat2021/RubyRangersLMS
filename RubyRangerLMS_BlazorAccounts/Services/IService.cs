namespace RubyRangerLMS_BlazorAccounts.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        void UpdateAsync(T entity);
        void CreateAsync(T entity);
        void DeleteAsync(Guid id);
    }
}
