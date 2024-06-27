using RubyRangersLMS_Blazor.IServices;
using RubyRangersLMS_Blazor.Models;

namespace RubyRangersLMS_Blazor.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly HttpClient _httpClient;
        public TeacherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateTeachersAsync(TeacherCreateModel teacherCreateModel)
        {
            var response = await _httpClient.PostAsJsonAsync("teachers", teacherCreateModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTeachersAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"teachers/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<TeacherViewModel>> GetTeachersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeacherViewModel>>("teachers");
        }
    }
}
