using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;



namespace Infraestructure.Repositories
{
    public class ClienteRepository : GenericRepositories<Cliente>, IClienteRepository
    {
        public ClienteRepository(RestaurantContext context) : base(context)
        {

        }

       
      
    }
}
