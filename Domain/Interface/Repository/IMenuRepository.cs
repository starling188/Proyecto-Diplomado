using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<Menu> GetIdByName(string name);
    }
}
