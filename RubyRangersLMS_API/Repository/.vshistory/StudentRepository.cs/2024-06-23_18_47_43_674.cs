﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly LMSContext context;

        public StudentRepository(LMSContext context)
        {
            this.context = context;
        }

        public void Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            Student student = context.Students.Single(s => s.Id.Equals(id));
            context.Remove<Student>(student);
            await context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetById(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async void Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }
    }
}
