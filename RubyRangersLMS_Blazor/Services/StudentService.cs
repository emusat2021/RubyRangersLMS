using RubyRangersLMS_Blazor.IServices;
using RubyRangersLMS_Blazor.Models;

namespace RubyRangersLMS_Blazor.Services
{
    public class StudentService : IService<Student>
    {
        private readonly HttpClient httpClient;

        public StudentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("api/student");
            return await response.Content.ReadFromJsonAsync<List<Student>>() ?? new List<Student>();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            var response = await httpClient.GetAsync($"api/student/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Student>() ?? new Student();
        }
        public async Task<Student> UpdateAsync(Guid id, Student student)
        {
            var response = await httpClient.PostAsJsonAsync($"api/student/update/{id}", student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Student>() ?? new Student();
        }

        public async void DeleteAsync(Guid id)
        {
            var response = await httpClient.DeleteAsync($"api/student/delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
