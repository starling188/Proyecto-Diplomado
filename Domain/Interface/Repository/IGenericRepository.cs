

namespace Domain.Interface.Repository
{
    public interface IGenericRepository <T> where T : class
    {
        //repo
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task Save();
    }
}
