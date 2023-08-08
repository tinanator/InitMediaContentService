using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MediaContext _context = null;

        private DbSet<T> dbSet = null;

        public Repository(MediaContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbSet.ToListAsync(cancellationToken);
        }

        public async Task<T?> FindByIdAsync(object id, CancellationToken cancellationToken)
        {
            return await dbSet.FindAsync(id, cancellationToken);
        }

        public void InsertAsync(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken)
        {
            T? existing = await dbSet.FindAsync(id, cancellationToken);

            if (existing == null)
            {
                return;
            }

            dbSet.Remove(existing);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

