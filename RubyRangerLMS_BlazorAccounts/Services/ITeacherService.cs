namespace RubyRangerLMS_BlazorAccounts.Services
{
    public interface ITeacherService<Teacher>
    {
        Task<List<Teacher>> GetAllAsync();
        Task<bool> CreateAsync(Teacher entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
