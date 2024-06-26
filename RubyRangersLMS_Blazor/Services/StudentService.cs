﻿using RubyRangersLMS_Blazor.IServices;
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
            return await response.Content.ReadFromJsonAsync<List<Student>>();
        }

        public async Task<Student> GetAsync(int id)
        {
            return null;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var response = await httpClient.GetAsync("https://localhost:7085/api/student/id");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Student>();
        }
    }
}