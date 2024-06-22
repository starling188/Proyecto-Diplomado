using Api.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Models.Cliente;
using Domain.Models.DetallePedido;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public DetallePedidoController(IDetallePedidoRepository repo , IMenuRepository menuRepository)
        {
            _mapper = Automaper.Configure();
            _repository = repo;
            _menuRepository = menuRepository;

        }


        [Route("AddDetallePedido")]
        [HttpPost]
        public async Task<ActionResult> AgregarCliente([FromBody] SaveDetallePedidoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            var plato = await _menuRepository.GetIdByName(model.NombrePlato);
            if(plato == null)
            {
                return BadRequest("el plato es describio no existe");
            }

            model.IdDelPlato = plato.Id;
            

            var detallepedido = _mapper.Map<DetallePedido>(model);
            detallepedido.CreatedBy = "Vendedor";
           
            await _repository.Add(detallepedido);
            await _repository.Save();
            return Ok("El detalle del pedido se a agregado correctamente");
        }


        [Route("ObtenerDetallesPedido")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewDetallePedidoModel>>> ObtenerClientesActivos()
        {
            var detallepedido = await _repository.GetAll();
            var viewdetalle = _mapper.Map<IEnumerable<DetallePedido>, IEnumerable<ViewDetallePedidoModel>>(detallepedido);
            return Ok(viewdetalle);
        }




        [Route("DesactivarDetallePedido/{id}")]
        [HttpPost]
        public async Task<ActionResult> DeleteIsActive(int id, DeleteDetallePedidoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            model.IdDetallePedido = id;

            var cliente = _mapper.Map<DetallePedido>(model);

            await _repository.Delete(cliente.Id);
            await _repository.Save();
            return Ok("Se Desactivo el cliente");

        }


    }
}
