namespace InitMediaContentService.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(object id, CancellationToken cancellationToken);
        void InsertAsync(T obj);
        void Update(T obj);
        Task DeleteAsync(object id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
