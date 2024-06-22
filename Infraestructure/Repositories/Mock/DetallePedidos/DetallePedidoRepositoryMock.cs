
using Domain.Entities;
using Domain.Interface.Repository;

using static Infraestructure.Exeception.NotFoundExeception;

namespace Infraestructure.Repositories.Mock.DetallePedidos
{
    public class DetallePedidoRepositoryMock : IDetallePedidoRepository
    {
        private readonly List<DetallePedido> _context;

        public DetallePedidoRepositoryMock()
        {
            _context = new List<DetallePedido>();
        }

        public async Task Add(DetallePedido entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El detalle del pedido no puede ser nulo");
            }

            _context.Add(entity);
            await Task.CompletedTask;
        }

        public async Task AddList(List<DetallePedido> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentException("La lista de para agregar varios detalles de pedido no puede ser nula");
            }

            _context.AddRange(entities);
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var entity = _context.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new NotFoundException($"El detalle del pedido con el ID {id} no existe en la base de datos");
            }

            // Realiza la eliminación lógica marcando IsActive como false
            entity.IsActive = false;
            await Task.CompletedTask;
        }

        public  Task<List<DetallePedido>> GetAll()
        {
            var entity = _context.Where(e => e.IsActive).ToList();

            if (entity == null || !entity.Any())
            {
                throw new NotFoundException("No hay detalles de pedidos activos");
            }

            return Task.FromResult(entity);
        }

        public  Task<DetallePedido> GetById(int id)
        {
            var entity = _context.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new NotFoundException($"El detalle del pedido con el id {id} no puede ser nulo");
            }

            return Task.FromResult(entity);
        }

        public async Task Update(DetallePedido entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El detalle del pedido no puede ser nulo");
            }

            var existingEntity = _context.FirstOrDefault(e => e.Id == entity.Id);
            if (existingEntity == null)
            {
                throw new NotFoundException($"El detalle del pedido con el id {entity.Id} no se puede actualizar ya que no existe");
            }

            // Aquí actualizamos las propiedades del entity existente con las del nuevo entity
            existingEntity.Id = entity.Id;
            existingEntity.IdPlato = entity.IdPlato;
            existingEntity.Cantidad = entity.Cantidad;
            existingEntity.IdPedido = entity.IdPedido;
            existingEntity.Subtotal = entity.Subtotal;
            
            
            // Actualiza cualquier otra propiedad necesaria

            await Task.CompletedTask;
        }

        public Task Save()
        {
            // En un mock, generalmente no se necesita hacer nada aquí.
            return Task.CompletedTask;
        }
    }
}
