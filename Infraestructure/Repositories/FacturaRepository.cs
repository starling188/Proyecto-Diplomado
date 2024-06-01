
using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;

namespace Infraestructure.Repositories
{
    public class FacturaRepository : GenericRepositories<Factura>, IFacturaRepository
    {
        public FacturaRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
