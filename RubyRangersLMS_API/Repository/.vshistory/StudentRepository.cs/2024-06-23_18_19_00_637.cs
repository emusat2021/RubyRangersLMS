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
            context.Add<Student>(student);
        }

        public void Delete(int id)
        {
            Student student = context.Students.Single(s => s.Id.Equals(id));
            context.Remove<Student>(student);
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetById(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public void Update(Student user)
        {
            context.Entry(Student).State = EntityState.Modified;
        }
    }
}
