using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;


namespace Infraestructure.Repositories
{
    public class PedidoRepository : GenericRepositories<Pedido>, IPedidoRepository
    {
        public PedidoRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
