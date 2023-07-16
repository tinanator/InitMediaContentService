namespace InitMediaContentService.Database
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(object id, CancellationToken cancellationToken);
        Task InsertAsync(T obj, CancellationToken cancellationToken);
        void Update(T obj);
        Task DeleteAsync(object id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
