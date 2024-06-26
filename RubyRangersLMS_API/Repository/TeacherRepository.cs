using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        public LMSContext _context;

        public TeacherRepository(LMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherViewModel>> GetAll()
        {
            var teachers = _context.Teachers;
            if (teachers == null)
            {
                return null;
            }
            var response = teachers.Select(t => new TeacherViewModel
            {
                Id = t.Id,
                UserName = t.UserName,
                FullName = t.FullName,
                Email = t.Email,

            });
            return await response.ToListAsync();
        }

        public async Task<TeacherCreateModel> Add(TeacherCreateModel teacherCreateModel)
        {
            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                UserName = teacherCreateModel.UserName,
                FullName = teacherCreateModel.FullName,
                Email = teacherCreateModel.Email,
            };

            var result = _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return teacherCreateModel;
        }

        public async Task<bool> Delete(Guid id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return false;
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
