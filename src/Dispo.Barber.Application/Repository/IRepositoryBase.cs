﻿using System.Linq.Expressions;
using Dispo.Barber.Domain.Entities;

namespace Dispo.Barber.Application.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task AddAsync(CancellationToken cancellationToken, T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<T?> GetAsync(CancellationToken cancellationToken, long id);

        Task<List<T>> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<T> GetFirstAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> expression);
    }
}