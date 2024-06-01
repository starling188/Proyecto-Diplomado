

using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;

namespace Infraestructure.Repositories
{
    public class MenuRepository : GenericRepositories<Menu>, IMenuRepository
    {
        public MenuRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
