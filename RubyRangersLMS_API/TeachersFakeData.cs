using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API
{
    public class TeachersFakeData
    {
        public List<Teacher> Teachers {  get; set; }
        public static TeachersFakeData Current { get; } = new TeachersFakeData();

        public TeachersFakeData()
        {
            Teachers = new List<Teacher>()
            {

                new Teacher()
                {
                    Id = Guid.NewGuid(),
                    UserName = "teacher1",
                    FullName = "John Smith",
                    Email = "john.smith@example.com",
                },
            };

        }

    }
}
