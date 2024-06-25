using RubyRangersLMS_API.Dtos;

namespace RubyRangersLMS_Blazor.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7085/api/student");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<StudentDto>>();
        }
    }

}
