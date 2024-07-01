using RubyRangerLMS_BlazorAccounts.Models;

namespace RubyRangerLMS_BlazorAccounts.Services
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

        public async void CreateAsync(Student student)
        {
            student.EmailConfirmed = true;
            student.PhoneNumberConfirmed = true;
            student.TwoFactorEnabled = false;
            student.LockoutEnabled = false;
            student.AccessFailedCount = 0;
            student.CourseId = Guid.Parse("1cae9ed4-c6ad-4979-a31f-db26570daee2");

            var response = await httpClient.PostAsJsonAsync($"api/student/add", student);
            response.EnsureSuccessStatusCode();
        }

        public async void UpdateAsync(Student student)
        {
            var response = await httpClient.PutAsJsonAsync($"api/student/update/{student.Id}", student);
            response.EnsureSuccessStatusCode();
        }

        public async void DeleteAsync(Guid id)
        {
            var response = await httpClient.DeleteAsync($"api/student/delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
