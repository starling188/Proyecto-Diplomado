using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;
using static Infraestructure.Exeception.NotFoundExeception;



namespace Infraestructure.Repositories
{
    public class ClienteRepository : GenericRepositories<Cliente>, IClienteRepository
    {
        public ClienteRepository(RestaurantContext context) : base(context)
        {

        }

        //paso
        public override async Task Add(Cliente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo");
            }

            await base.Add(entity);
        }


        public override async Task<List<Cliente>> GetAll()
        {
            var cliente = await base.GetAll();
            if(cliente == null)
            {
                throw new NotFoundException("La lista de clientes está vacía");
            }

            return cliente;
        }


        public override async Task AddList(List<Cliente> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentException("La lista de clientes no puede estar vacía");
            }

            await base.AddList(entities);
        }


        public override async Task Delete(int id)
        {
            var existingCliente = await GetById(id);
            if (existingCliente == null)
            {
                throw new NotFoundException($"El cliente con ID {id} no existe en la base de datos");
            }

            await base.Delete(id);
        }

        public override async Task<Cliente> GetById(int id)
        {
            var cliente = await base.GetById(id);
            if (cliente == null)
            {
                throw new NotFoundException($"El cliente con ID {id} no existe en la base de datos");
            }

            return cliente;
        }

        public override async Task Update(Cliente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo");
            }

            var existingCliente = await GetById(entity.Id);
            if (existingCliente == null)
            {
                throw new NotFoundException($"No se puede actualizar el cliente con ID {entity.Id} porque no existe en la base de datos");
            }

            await base.Update(entity);
        }
        public override Task Save()
        {
            return base.Save();
        }
    }

}
