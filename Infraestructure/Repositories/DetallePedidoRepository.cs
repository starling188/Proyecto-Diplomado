using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;

namespace Infraestructure.Repositories
{
    public class DetallePedidoRepository : GenericRepositories<DetallePedido>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
