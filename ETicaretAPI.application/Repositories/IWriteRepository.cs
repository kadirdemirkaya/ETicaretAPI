namespace ETicaretAPI.application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entity);

        bool UpdateAsync(T entity);

        bool Delete(T entity);

        Task<bool> Delete(Guid id);

        bool DeleteRange(List<T> entity);

        Task SaveChangesAsync();
    }
}
