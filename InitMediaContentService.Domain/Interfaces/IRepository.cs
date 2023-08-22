using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InitMediaContentService.Domain.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(K id, CancellationToken cancellationToken);
        EntityEntry<T> Insert(T obj);
        void Update(T obj);
        Task<bool> DeleteAsync(K id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
