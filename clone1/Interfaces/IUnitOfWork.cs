using AutoMapper;
using clone1.Data;
using clone1.Repositories;

namespace clone1.Interfaces;

public interface IUnitOfWork
{
    UserRepository UserRepository { get; }
    Task<bool> CompleteAsync();
    bool HasChanges();
}