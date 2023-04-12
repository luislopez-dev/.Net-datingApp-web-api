using AutoMapper;
using clone1.Data;
using clone1.Interfaces;

namespace clone1.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UnitOfWork(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public UserRepository UserRepository => new UserRepository(_mapper, _context);
    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}