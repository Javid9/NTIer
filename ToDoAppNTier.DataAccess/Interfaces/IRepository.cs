﻿using System.Linq.Expressions;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.DataAccess.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAll();
    Task<T> Find(object id);
    Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking= false);
    IQueryable<T> GetQuery();
    Task Create(T entity);
    void Update(T entity, T unchanged);
    void Remove(T entity);
    

}