
using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Exeception;
using static Infraestructure.Exeception.NotFoundExeception;

namespace Infraestructure.Repositories.ClienteRepositoryMock
{
    public class ClienteRepositoryMock : IClienteRepository
    {
        private readonly List<Cliente> _clienteList;


        public ClienteRepositoryMock()
        {
            _clienteList = new List<Cliente>();
        }

        //paso
        public async Task Add(Cliente entity)
        {
            if (entity == null ||
                 string.IsNullOrWhiteSpace(entity.Nombre) ||
                 string.IsNullOrWhiteSpace(entity.Email) ||
                 string.IsNullOrWhiteSpace(entity.Telefono))
            {
                throw new ArgumentException("El cliente no puede estar vacío o contener campos nulos", nameof(entity));
            }
            _clienteList.Add(entity);
            await Task.CompletedTask;
        }

        public async Task AddList(List<Cliente> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentException("La lista de clientes no puede estar vacía");
            }
            
            _clienteList.AddRange(entities);
            await Task.CompletedTask;   
        }

        public Task Delete(int id)
        {
            var cliente = _clienteList.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                throw new NotFoundException($"No se puede eliminar el cliente con ID {id} porque no existe en la lista");
            }

            _clienteList.Remove(cliente);
            return Task.CompletedTask;
        }
        
        public Task<List<Cliente>> GetAll()
        {
            if (_clienteList.Count == 0)
            {
                 throw new NotFoundException("La lista de clientes no puede estar vacía");
               
            }

            return Task.FromResult(_clienteList);
        }

        public Task<Cliente> GetById(int id)
        {
            var cliente = _clienteList.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                throw new NotFoundException($"No se puede encontrar el cliente con ID {id}");
            }

            return Task.FromResult(cliente);
        }

        public Task Save()
        {
            // No hace nada en la implementación mock
            return Task.CompletedTask;
        }

        public Task Update(Cliente entity)
        {
            if (entity == null)
            {
                throw new NotFoundException("el usuario no puede actualizar un usuario vacio");
            }

            var existingCliente = _clienteList.FirstOrDefault(c => c.Id == entity.Id);
            if (existingCliente == null)
            {
                throw new NotFoundException($"No se puede actualizar el cliente con ID {entity.Id} porque no existe en la lista");
            }

            // Actualizar el cliente en la lista
            existingCliente.Nombre = entity.Nombre;
            existingCliente.Telefono = entity.Telefono;
            existingCliente.Email = entity.Email;

            return Task.CompletedTask;
        }
    }
}
