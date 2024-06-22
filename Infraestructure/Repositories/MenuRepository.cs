

using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using static Infraestructure.Exeception.NotFoundExeception;

namespace Infraestructure.Repositories
{
    public class MenuRepository : GenericRepositories<Menu>, IMenuRepository
    {
        public MenuRepository(RestaurantContext context) : base(context)
        {
        }

        public override async Task Add(Menu entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo");
            }

            await base.Add(entity);
        }


        public override async Task<List<Menu>> GetAll()
        {
            var entity = await base.GetAll();
            if (entity == null)
            {
                throw new NotFoundException("La lista de clientes está vacía");
            }

            return entity;
        }

        public override async Task AddList(List<Menu> entities)
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
                throw new NotFoundException($"El cliente con ID {id} no existe en la base de datos");
            }

            await base.Delete(id);
        }

        public override async Task<Menu> GetById(int id)
        {
            var cliente = await base.GetById(id);
            if (cliente == null)
            {
                throw new NotFoundException($"El cliente con ID {id} no existe en la base de datos");
            }

            return cliente;
        }

        public override async Task Update(Menu entity)
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

        public async Task<Menu> GetIdByName(string nombrePlato)
        {
            return await _context.Menus.FirstOrDefaultAsync(c => c.Nombre == nombrePlato);

        }
    }
}
