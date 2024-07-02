using RubyRangerLMS_BlazorAccounts.Models;

namespace RubyRangerLMS_BlazorAccounts.Services
{
    public class CourseService
    {
        private readonly HttpClient httpClient;
        // Remember the url to the api sometimes changes.
        // Needs Fixing!
        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:53192/");
        }

        public async Task<bool> CreateCourseAsync(CreateCourseVM model)
        {
            var response = await httpClient.PostAsJsonAsync("api/course/", model);
            return response.IsSuccessStatusCode;
        }
    }
}
