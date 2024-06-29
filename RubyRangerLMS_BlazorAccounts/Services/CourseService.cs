using RubyRangerLMS_BlazorAccounts.Models;

namespace RubyRangerLMS_BlazorAccounts.Services
{
    public class CourseService
    {
        private readonly HttpClient httpClient;
        // Remember the url to the api sometimes changes.

        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> CreateCourseAsync(CreateCourseVM model)
        {
            var response = await httpClient.PostAsJsonAsync("api/update/", model);
            return response.IsSuccessStatusCode;
        }
    }
}
