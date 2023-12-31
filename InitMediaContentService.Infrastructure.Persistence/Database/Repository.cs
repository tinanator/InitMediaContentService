﻿using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{
    public class Repository<T, K> : IRepository<T, K> where T : class
    {
        private MediaContext _context;

        public Repository(MediaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> FindByIdAsync(K id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public EntityEntry<T> Insert(T obj)
        {
            return _context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task<bool> DeleteAsync(K id, CancellationToken cancellationToken)
        {
            T? existing = await _context.Set<T>().FindAsync(id, cancellationToken);

            if (existing == null)
            {
                return false;
            }

            _context.Set<T>().Remove(existing);

            return true;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

