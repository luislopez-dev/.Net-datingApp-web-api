﻿using AutoMapper;
using clone1.Core.Interfaces;
using clone1.Data;
using clone1.Infrastructure.Data;

namespace clone1.Infrastructure.Repositories;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
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