using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using static Infraestructure.Exeception.NotFoundExeception;


namespace Infraestructure.Repositories
{
    public class PedidoRepository : GenericRepositories<Pedido>, IPedidoRepository
    {
        public PedidoRepository(RestaurantContext context) : base(context)
        {
        }
        public override async Task Add(Pedido entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo");
            }

            await base.Add(entity);
        }


        public override async Task<List<Pedido>> GetAll()
        {
            var cliente = await _context.Pedidos.Where(c => c.IsActive).ToListAsync();
            if (cliente == null)
            {
                throw new NotFoundException("La lista de clientes está vacía");
            }

            return cliente;
        }

        public override async Task AddList(List<Pedido> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentException("La lista de clientes no puede estar vacía");
            }

            await base.AddList(entities);
        }

        public override async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new NotFoundException($"el detalle del pedido con el ID {id} no existe en la base de datos");
            }

            // Realiza la eliminación lógica marcando IsActive como false
            entity.IsActive = false;
            _context.Update(entity); // Asegúrate de tener acceso a tu DbCon
        }

        public override async Task<Pedido> GetById(int id)
        {
            var cliente = await base.GetById(id);
            if (cliente == null)
            {
                throw new NotFoundException($"El cliente con ID {id} no existe en la base de datos");
            }

            return cliente;
        }

        public override async Task Update(Pedido entity)
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

        public override async Task Save()
        {
            await base.Save();
        }
    }
}
