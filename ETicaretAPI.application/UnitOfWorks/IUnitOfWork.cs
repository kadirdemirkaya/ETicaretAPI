using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.application.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
    }
}
