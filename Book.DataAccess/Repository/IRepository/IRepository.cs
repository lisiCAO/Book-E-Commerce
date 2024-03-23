﻿using System;
using System.Linq.Expressions;

namespace Book.DataAccess.Repository.IRepository
{
	public interface IRepository
	{
        //T - Category
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
