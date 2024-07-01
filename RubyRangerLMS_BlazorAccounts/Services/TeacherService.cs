using RubyRangerLMS_BlazorAccounts.Models;

namespace RubyRangerLMS_BlazorAccounts.Services
{
    public class TeacherService : ITeacherService<Teacher>
    {
        private readonly HttpClient _httpClient;
        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Teacher>>("api/teachers") ?? new List<Teacher>();
        }

        public async Task<bool> CreateAsync(Teacher teacher)
        {
            var response = await _httpClient.PostAsJsonAsync("teachers", teacher);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"teachers/{id}");
            return response.IsSuccessStatusCode;
        }

    }

}
