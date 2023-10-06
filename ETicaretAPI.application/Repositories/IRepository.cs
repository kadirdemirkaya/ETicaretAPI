using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.application.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
