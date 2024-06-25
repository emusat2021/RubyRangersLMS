﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.ViewModels;

namespace RubyRangersLMS_API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly LMSContext _context;

        public TeachersController(LMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherViewModel>> GetTeachers()
        {
            try
            {

                var teachers = _context.Teachers;
                var response = teachers.Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    UserName = t.UserName,
                    FullName = t.FullName,
                    Email = t.Email,

                }).ToList();

                if (response.Count == 0)
                {
                    return NotFound("No data Found...");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<TeacherCreateModel>> CreateTeacher(TeacherCreateModel teacherCreateModel)
        {
            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                UserName = teacherCreateModel.UserName,
                FullName = teacherCreateModel.FullName,
                Email = teacherCreateModel.Email,
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacherCreateModel);
        }
    }
}