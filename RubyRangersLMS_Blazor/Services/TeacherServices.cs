using RubyRangersLMS_Blazor.IServices;
using RubyRangersLMS_Blazor.Models;

namespace RubyRangersLMS_Blazor.Services
{
    public class TeacherServices : IService<TeacherViewModel>
    {
        private readonly HttpClient _httpClient;
        public TeacherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TeacherViewModel>>("api/teachers");
        }

        //public async Task<bool> CreateTeachersAsync(TeacherCreateModel teacherCreateModel)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("teachers", teacherCreateModel);
        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteTeachersAsync(Guid id)
        //{
        //    var response = await _httpClient.DeleteAsync($"teachers/{id}");
        //    return response.IsSuccessStatusCode;
        //}




        public Task<TeacherViewModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherViewModel> UpdateAsync(Guid id, TeacherViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

        
}
