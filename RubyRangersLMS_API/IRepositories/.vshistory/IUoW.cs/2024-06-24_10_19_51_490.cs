﻿
namespace RubyRangersLMS_API.IRepositories
{
    public interface IUoW <T>
    {
        IRepository<T> entityRepository { get; }
        Task CompleteAsync();
    }
}
