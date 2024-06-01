using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;


namespace Infraestructure.Repositories
{
    public class MesaRepository : GenericRepositories<Mesa>, IMesaRepository
    {
        public MesaRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
