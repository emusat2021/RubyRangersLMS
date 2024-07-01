using Microsoft.AspNetCore.Components;
using RubyRangerLMS_BlazorAccounts.Models;
using RubyRangerLMS_BlazorAccounts.Services;

namespace RubyRangerLMS_BlazorAccounts.Components.Widgets
{
    public partial class TeacherCountWidget
    {
        [Inject]
        public ITeacherService<Teacher> TeacherService { get; set; }
        public int TeacherCounter { get; set; }
        public List<Teacher> Teachers { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Teachers = await TeacherService.GetAllAsync();
            TeacherCounter = Teachers.Count();
        }
    
    }
}
