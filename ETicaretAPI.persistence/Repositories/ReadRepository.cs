using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ETicaretAPIProjectDbContext _context;

        public ReadRepository(ETicaretAPIProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.AnyAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.CountAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.CountAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await Table.FindAsync(id);
        }
    }
}
