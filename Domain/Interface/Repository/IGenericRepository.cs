

namespace Domain.Interface.Repository
{
    public interface IGenericRepository <T> where T : class
    {
        //repo
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task AddList(List<T> entity);
        Task Update(T entity);
        Task Delete(int id);
        Task Save();
    }
}
