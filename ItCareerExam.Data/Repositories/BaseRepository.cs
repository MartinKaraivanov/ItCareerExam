﻿using AutoMapper;
using ItCareerExam.Data.Models;
using System.Linq.Expressions;

namespace ItCareerExam.Data.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public BaseRepository(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<TEntity> Retrieve(Expression<Func<TEntity, bool>> where)
    {
        return _dbContext.Set<TEntity>().Where(where).ToList();
    }

    public int Count()
    {
        return _dbContext.Set<TEntity>().Count();
    }

    public IEnumerable<T> RetrieveMappedTo<T>(Expression<Func<TEntity, bool>> where) where T : class
    {
        return _mapper.ProjectTo<T>(_dbContext.Set<TEntity>().Where(where));
    }
}
