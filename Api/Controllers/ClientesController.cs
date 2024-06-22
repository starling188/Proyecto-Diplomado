using Api.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Models.Cliente;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository cliente   )
        {
            _clienteRepository = cliente;
            _mapper = Automaper.Configure();
        }

        [Route("AddCliente")]
        [HttpPost]
        public async Task<ActionResult> AgregarCliente([FromBody] SaveClienteModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }
            var cliente = _mapper.Map<Cliente>(model);
            cliente.CreatedBy = "Admin";
            await _clienteRepository.Add(cliente);
            await _clienteRepository.Save();
            return Ok("Cliente Agregado Correctamente");

        }

        [Route("ObtenerClientes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewClienteModel>>> ObtenerClientesActivos()
        {
            var clientes = await _clienteRepository.GetAll();
            var viewclientes = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ViewClienteModel>>(clientes);
            return Ok(viewclientes);
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, [FromBody] UpdateClienteModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            var cliente = await _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            _mapper.Map(model, cliente);

            await _clienteRepository.Update(cliente);
            await _clienteRepository.Save();
            return Ok("Cliente Actualizado");
        }

        [Route("ClienteDesactivar/{id}")]
        [HttpPost]
        public async Task<ActionResult> DeleteIsActive(int id , DeleteClienteModel model)
        {
           if (model == null)
                    {
                        return BadRequest("El modelo es nulo");
                    }

            model.IdCliente = id;

            var pedidodetalle = _mapper.Map<Cliente>(model);

            await _clienteRepository.Delete(pedidodetalle.Id);
            await _clienteRepository.Save();
            return Ok("Se Desactivo el cliente");

        }


    }

    
}
