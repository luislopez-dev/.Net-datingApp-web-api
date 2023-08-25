using clone1.Infrastructure.Repositories;

namespace clone1.Core.Interfaces;

public interface IUnitOfWork
{
    UserRepository UserRepository { get; }
    Task<bool> CompleteAsync();
    bool HasChanges();
}