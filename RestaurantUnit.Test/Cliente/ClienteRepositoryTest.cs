using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Repositories.ClienteRepositoryMock;
using Moq;
using static Infraestructure.Exeception.NotFoundExeception;


namespace RestaurantUnit.Test
    {
    public class ClienteRepositoryTest
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteRepositoryTest()
        {
            _clienteRepository = new ClienteRepositoryMock();
        }



        [Fact]
        public async void AgregarClienteRepository()
        {
            //averrage
            var cliente = new Cliente
            {
                Nombre = "",
                Email = "pepe@gmail",
                Telefono = "324234234"
            };
            //act

            //assert

            await Assert.ThrowsAsync<ArgumentException>(() => _clienteRepository.Add(cliente));

        }

        [Fact]
        public async void GetAllCliente() {

            var empty = new List<Cliente>();
            Mock<IClienteRepository> mockClienteRepository = new Mock<IClienteRepository>();

            // Configurando el repositorio para lanzar la excepción NotFoundException
            mockClienteRepository.Setup(repo => repo.GetAll()).ThrowsAsync(new Infraestructure.Exeception.NotFoundExeception.NotFoundException());

            // Assert
            await Assert.ThrowsAsync<Infraestructure.Exeception.NotFoundExeception.NotFoundException>(() => mockClienteRepository.Object.GetAll());

        }

        [Fact]
        public async void AgregarListaCliente()
        {

            var emptyClienteList = new List<Cliente>(); 
            Mock<IClienteRepository> mockClienteRepository = new Mock<IClienteRepository>();

            mockClienteRepository.Setup(repo => repo.AddList(It.IsAny<List<Cliente>>())).ThrowsAsync(new ArgumentException("La lista de clientes no puede estar vacía"));

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => mockClienteRepository.Object.AddList(emptyClienteList));


        }

        [Fact]
        public async void DeleteCliente()
        {
            int nonExistentId = 999; // Id de un cliente que no existe en la lista
            Mock<IClienteRepository> mockClienteRepository = new Mock<IClienteRepository>();

            // Configurando el repositorio para lanzar la excepción NotFoundException
            mockClienteRepository.Setup(repo => repo.Delete(nonExistentId)).ThrowsAsync(new Infraestructure.Exeception.NotFoundExeception.NotFoundException($"No se puede eliminar el cliente con ID {nonExistentId} porque no existe en la lista"));

            // Act & Assert
            await Assert.ThrowsAsync<Infraestructure.Exeception.NotFoundExeception.NotFoundException>(() => mockClienteRepository.Object.Delete(nonExistentId));
        }

        [Fact]
        public async void GetbyIdCliente()
        {
            var id = 999;

            await Assert.ThrowsAsync<NotFoundException>(() =>_clienteRepository.GetById(id));
        }

        [Fact]
        public async void UpdateClienteNull()
        {
            Cliente cliente = null;

            await Assert.ThrowsAsync<NotFoundException>(() => _clienteRepository.Update(cliente));

        }

        [Fact]
        public async void UpdateClienteNotExist()
        {
            Cliente cliente = new Cliente {
            
                Id = 444,
                Nombre= "oscar",
                Telefono = "3423423",
                Email = "Gonzalezmiranda@gmail.com"
            
            };
        }

    }
}