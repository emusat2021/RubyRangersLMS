using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RubyRangersLMS_API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RubyRangersLMS_API.Identity
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            // Define roles
            string[] roleNames = { "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
                }
            }

            // Seed a teacher user
            var teacherEmail = "teacher@example.com";
            var teacherUser = new Teacher { UserName = teacherEmail, Email = teacherEmail, EmailConfirmed = true };
            if (userManager.Users.All(u => u.Email != teacherEmail))
            {
                var result = await userManager.CreateAsync(teacherUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(teacherUser, "Teacher");
                }
            }

            // Seed a student user
            var studentEmail = "student@example.com";
            var studentUser = new Student { UserName = studentEmail, Email = studentEmail, EmailConfirmed = true };
            if (userManager.Users.All(u => u.Email != studentEmail))
            {
                var result = await userManager.CreateAsync(studentUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(studentUser, "Student");
                }
            }
        }
    }
}
