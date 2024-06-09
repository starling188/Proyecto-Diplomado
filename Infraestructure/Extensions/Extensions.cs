

using Domain.Interface.Repository;
using Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Extensions
{
    public static class Extensions
    {

        public static void ExtensionRepository(this IServiceCollection services , IConfiguration configuration) {

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IDetallePedidoRepository, DetallePedidoRepository>();
            services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
            services.AddTransient<IFacturaRepository, FacturaRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IMesaRepository, MesaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }
    }
}
