using RubyRangerLMS_BlazorAccounts.Models;

namespace RubyRangerLMS_BlazorAccounts.Services
{
    public class CourseService
    {
        private readonly HttpClient httpClient;
        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CreateCourseVM>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("api/course");
            return await response.Content.ReadFromJsonAsync<List<CreateCourseVM>>() ?? new List<CreateCourseVM>();
        }

        public async Task<bool> CreateCourseAsync(CreateCourseVM model)
        {
            var response = await httpClient.PostAsJsonAsync("api/course/", model);
            return response.IsSuccessStatusCode;
        }
    }
}
