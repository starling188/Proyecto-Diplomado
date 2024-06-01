using Domain.Entities;
using Domain.Interface.Repository;
using Infraestructure.Context;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetAll_ReturnsAllClientes()
        {
            // Configurar DbContext en memoria
            var options = new DbContextOptionsBuilder<RestaurantContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Agregar datos falsos a la base de datos en memoria
            using (var context = new RestaurantContext(options))
            {
                context.Clientes.Add(new Cliente { Id = 1, Nombre = "Cliente1" });
                context.Clientes.Add(new Cliente { Id = 2, Nombre = "Cliente2" });
                context.SaveChanges();
            }

            // Ejecutar el método que se va a probar
            List<Cliente> result;
            using (var context = new RestaurantContext(options))
            {
                var repository = new ClienteRepository(context);
                result = await repository.GetAll();
            }

            // Verificar el resultado
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Cliente1", result[0].Nombre);
            Assert.AreEqual("Cliente2", result[1].Nombre);
        }
    }
}