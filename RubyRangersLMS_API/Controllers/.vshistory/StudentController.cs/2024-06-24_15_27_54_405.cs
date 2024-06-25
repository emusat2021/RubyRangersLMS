﻿using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RubyRangersLMS_API.Dtos;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUoW uow;

        private readonly IMapper mapper;

        public StudentController(IUoW uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await uow.studentRepository.GetAll();

            if (students == null)
            {
                return NotFound();
            }

            var studentsDto = mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentsDto);
        }

        // GET api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await uow.studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            uow.studentRepository.Create(student);

            try
            {
                await uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            uow.studentRepository.Update(student);

            try
            {
                await uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return (!GameExists(id)) ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            uow.studentRepository.Remove(id);

            try
            {
                await uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return (!GameExists(id)) ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }

        private bool GameExists(Guid id)
        {
            return uow.studentRepository.AnyAsync(id).Result;
        }
    }
}
