﻿
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Entities;

namespace RubyRangersLMS_API.IRepositories
{
    public interface IRepository<T>
    {
        //Task<ActionResult<IEnumerable<T>>> GetAll();
        List<Student> GetAll();
        Task<ActionResult<T>> GetById(Guid id);
        Task<bool> AnyAsync(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Remove(Guid id);
    }
}
