﻿namespace InitMediaContentService.Domain.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(K id, CancellationToken cancellationToken);
        void Insert(T obj);
        void Update(T obj);
        Task DeleteAsync(K id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
