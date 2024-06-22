
using Domain.Entities;
using Domain.Interface.Repository;

using Infraestructure.Repositories.Mock.DetallePedidos;
using static Infraestructure.Exeception.NotFoundExeception;




namespace RestaurantUnit.Test.DetallesPedidos
{
    public class DetallePedidoTest
    {
        private readonly IDetallePedidoRepository _repository;

        public DetallePedidoTest()
        {
            _repository = new DetallePedidoRepositoryMock();
        }

        [Fact]
        public async void AgregarDetalleNull()
        {
            //averrage
            DetallePedido detallePedido = null;

            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Add(detallePedido));
        }

        [Fact]
        public async void AgregarDetallesLista()
        {
            var detallespedido = new List<DetallePedido>();

            await Assert.ThrowsAsync<ArgumentException>(() => _repository.AddList(detallespedido));
        }

        [Fact]
        public async void EliminarDetalles()
        {
            var id = 5;
              _repository.Delete(id);

            await Assert.ThrowsAsync<NotFoundException>(() => _repository.Delete(id));
        }

        [Fact]
        public async void Getall()
        {
          

            await Assert.ThrowsAsync<NotFoundException>(() => _repository.GetAll());
        }

        [Fact]
        public async void GetById()
        {
            var id = 500;

            await Assert.ThrowsAsync<NotFoundException>(() => _repository.GetById(id));

            
        }

        [Fact]
        public async void Update()
        {
            DetallePedido detalle = null;
            var depedido = new DetallePedido();


            await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Update(detalle));
            await Assert.ThrowsAsync<NotFoundException>(() => _repository.Update(depedido));
        }

    }
}
