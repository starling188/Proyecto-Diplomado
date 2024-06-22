using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using static Infraestructure.Exeception.NotFoundExeception;

namespace Infraestructure.Repositories
{
    public class DetallePedidoRepository : GenericRepositories<DetallePedido>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(RestaurantContext context) : base(context)
        {
        }



        public override async Task Add(DetallePedido entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El detalle del pedido no puede ser nulo");
            }

            await base.Add(entity);
        }


        public override async Task<List<DetallePedido>> GetAll()
        {
            var entity = await _context.Set<DetallePedido>()
                                .Where(e => e.IsActive)
                                .ToListAsync();

            if (entity == null || !entity.Any())
            {
                throw new NotFoundException("No hay detalles de pedidos activos");
            }

            return entity;
        }

        public override async Task AddList(List<DetallePedido> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentException("La lista de para agregar varios detalles de pedido no puede ser nula");
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
            _context.Update(entity); // Asegúrate de tener acceso a tu DbContext

        }

        public override async Task<DetallePedido> GetById(int id)
        {
            var cliente = await base.GetById(id);
            if (cliente == null)
            {
                throw new NotFoundException($"el detalle del pedido con el id {id} no puede ser nulo");
            }

            return cliente;
        }

        public override async Task Update(DetallePedido entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El detalle del pedido no puede ser nulo");
            }

            var existingCliente = await GetById(entity.Id);
            if (existingCliente == null)
            {
                throw new NotFoundException($"el detalle del pedido con el id{existingCliente} no se puede actualizar ya que no existe ");
            }

            await base.Update(entity);
        }

        public override async Task Save()
        {
            await base.Save();
        }

    }
}
