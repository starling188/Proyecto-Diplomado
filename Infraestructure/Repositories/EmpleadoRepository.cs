using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;


namespace Infraestructure.Repositories
{
    public class EmpleadoRepository : GenericRepositories<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
