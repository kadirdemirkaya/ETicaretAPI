using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.persistence.Data;
using ETicaretAPI.persistence.Repositories;

namespace ETicaretAPI.persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ETicaretAPIProjectDbContext _context;

        public UnitOfWork(ETicaretAPIProjectDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IReadRepository<T> GetReadRepository<T>() where T : class, new()
        {
            return new ReadRepository<T>(_context);
        }

        public IWriteRepository<T> GetWriteRepository<T>() where T : class, new()
        {
            return new WriteRepository<T>(_context);
        }
    }
}
