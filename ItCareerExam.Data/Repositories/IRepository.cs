﻿using ItCareerExam.Data.Models;
using System.Linq.Expressions;

namespace ItCareerExam.Data.Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    IEnumerable<TEntity> Retrieve(Expression<Func<TEntity, bool>> where);
    int Count();
    IEnumerable<T> RetrieveMappedTo<T>(Expression<Func<TEntity, bool>> where) where T : class;
    Task<TEntity> EditAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}
