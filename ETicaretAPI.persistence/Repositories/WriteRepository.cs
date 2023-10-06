using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretAPI.persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly ETicaretAPIProjectDbContext _context;

        public WriteRepository(ETicaretAPIProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            EntityEntry entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Delete(Guid id)
        {
            T entity = await Table.FindAsync(id);
            return Delete(entity);
        }

        public bool DeleteRange(List<T> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public bool UpdateAsync(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
