using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Data
{
    public static class SeedInitialData
    {
        public static async Task SeedFirstCourse(LMSContext context)
        {
            var teacher = new Teacher
            {
                Id = Guid.Parse("1cae9ed4-c6ad-4979-a31f-db26570daee2"),
                Email = "adam@adam.com",
                EmailConfirmed = true,
                PhoneNumber = "0707-112233",
                PhoneNumberConfirmed = true,
                AccessFailedCount = 5
            };

            var course = new Course
            {
                Id = Guid.Parse("553ec758-ae84-4972-a8bf-7e66c95be22f"),
                Name = "Course1",
                Description = "Text: Course1",
                EntityType = "Course",
                TeacherId = Guid.Parse("1cae9ed4-c6ad-4979-a31f-db26570daee2")
            };

            // Workaround to the annoying tracking issues.
            var moduleIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            var modules = new List<Module>
            {
                new() { Id = moduleIds[0], Name = "Module1", Description = "Text: Module1 -> Course1", EntityType = "Module", CourseId = Guid.Parse("553ec758-ae84-4972-a8bf-7e66c95be22f") },
                new() { Id = moduleIds[1], Name = "Module2", Description = "Text: Module2 -> Course1", EntityType = "Module", CourseId = Guid.Parse("553ec758-ae84-4972-a8bf-7e66c95be22f") }
            };

            var activities = new List<Activity>
            {
                new() { Name = "Activity1", Description = "Desc: Activity1 -> Module1 -> Course1", EntityType = "Activity", ModuleId = moduleIds[0] },
                new() { Name = "Activity2", Description = "Desc: Activity2 -> Module2 -> Course1", EntityType = "Activity", ModuleId = moduleIds[1] }
            };

            await context.Teachers.AddAsync(teacher);
            await context.Courses.AddAsync(course);
            await context.Modules.AddRangeAsync(modules);
            await context.Activities.AddRangeAsync(activities);

            await context.SaveChangesAsync();
        }
    }
}


