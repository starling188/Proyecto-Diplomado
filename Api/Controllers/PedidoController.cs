using Api.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;

using Domain.Models.Pedido;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedido, IClienteRepository cliente )
        {
            _pedidoRepository = pedido;
            _mapper = Automaper.Configure();
            _clienteRepository = cliente;
            

        }


        [Route("AddPedido")]
        [HttpPost]
        public async Task<ActionResult> AgregarPedido([FromBody] SavePedidoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo no puede ser nulo");
            }


            // Mapear el modelo al pedido y asignar el IdCliente
            var pedido = _mapper.Map<Pedido>(model);
          
            pedido.CreatedBy = "Vendedor";

            // Agregar el pedido y guardar cambios
            await _pedidoRepository.Add(pedido);
            await _pedidoRepository.Save();
            return Ok("Pedido agregado");
        }


        [Route("ObtenerPedidos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewPedidoModel>>> ObtenerPedidosActivos()
        {
            var pedidos = await _pedidoRepository.GetAll();
            var viewPedidos = _mapper.Map<IEnumerable<Pedido>, IEnumerable<ViewPedidoModel>>(pedidos);
            return Ok(viewPedidos);
        }


        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, [FromBody] UpdatePedidoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound("Cliente no encontrado");
            }

            _mapper.Map(model, pedido);

            await _pedidoRepository.Update(pedido);
            await _pedidoRepository.Save();
            return Ok("pedido Actualizado");
        }


        [Route("EmpleadoDesactivar/{id}")]
        [HttpPost]
        public async Task<ActionResult> DeleteIsActive(int id, DeletePedidoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            model.IdPedido = id;

            var pedido = _mapper.Map<Pedido>(model);

            await _pedidoRepository.Delete(pedido.Id);
            await _pedidoRepository.Save();
            return Ok("Se desactivo el pedido");

        }

    }
}
