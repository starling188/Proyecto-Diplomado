using Domain.Entities;
using Domain.Models.Cliente;
using AutoMapper;
using Domain.Models.Empleado;
using Domain.Models.Pedido;
using Domain.Models.DetallePedido;

namespace Api.DTOs
{
    public class Automaper 
    {

        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //mapping for clientes
                cfg.CreateMap<SaveClienteModel, Cliente>();
                cfg.CreateMap<Cliente, ViewClienteModel>().
                ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.Id));
                cfg.CreateMap<UpdateClienteModel, Cliente>();
                cfg.CreateMap<DeleteClienteModel, Cliente>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCliente));

                //mapping for Empleados
                cfg.CreateMap<SaveEmpleadoModel, Empleado>();
                cfg.CreateMap<Empleado, ViewEmpleadoModel>().
                ForMember(des => des.IdEmpleado, op => op.MapFrom(sr => sr.Id));
                cfg.CreateMap<UpdateEmpleadoModel, Empleado>();
                cfg.CreateMap<DeleteEmpleadoModel, Empleado>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEmpleado));

                //mapping for pedidos
                cfg.CreateMap<SavePedidoModel, Pedido>()
      .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdDelCliente))
      .ForMember(dest => dest.IdMesa, opt => opt.MapFrom(src => src.IdDeLaMesa));

                cfg.CreateMap<Pedido, ViewPedidoModel>().ForMember(de => de.IdPedido , opi => opi.MapFrom(src => src.Id)).
                ForMember(de => de.IdDelCliente , op => op.MapFrom(src => src.IdCliente));
                cfg.CreateMap<UpdatePedidoModel, Pedido>();
                cfg.CreateMap<DeletePedidoModel, Pedido>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdPedido));


                //mapping for detallepedido
                cfg.CreateMap<SaveDetallePedidoModel, DetallePedido>()
                     .ForMember(dest => dest.IdPedido, opt => opt.MapFrom(src => src.IdPedido))
                     .ForMember(dest => dest.IdPlato, opt => opt.MapFrom(src => src.IdDelPlato))
                     .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
                     .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal));

                cfg.CreateMap<DetallePedido, ViewDetallePedidoModel>().ForMember(co => co.IdDetallePedido, op => op.MapFrom(src => src.Id))
                .ForMember(co => co.IdDelPlato, op => op.MapFrom(src => src.IdPlato));

                cfg.CreateMap<DeleteDetallePedidoModel, DetallePedido>().ForMember(co => co.Id, po => po.MapFrom(src => src.IdDetallePedido));

            });

            return config.CreateMapper();
        }
    }
}
