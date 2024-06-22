
using Api.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;

using Domain.Models.Empleado;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IMapper _mapper;

        public EmpleadoController( IEmpleadoRepository empleadoRepository)
        {
            _repository = empleadoRepository;
            _mapper = Automaper.Configure();
        }


        [Route("Agregar Empleado")]
        [HttpPost]
        public async Task<ActionResult> AgregarEmpleado([FromBody] SaveEmpleadoModel model)
        {
            if (model == null)
            {
                return BadRequest("El Empleado no puede ser Nulo");
            }

            var empleado = _mapper.Map<Empleado>(model);
            empleado.CreatedBy = "Admin";
            await _repository.Add(empleado);
            await _repository.Save();
            return Ok("Empleado agregado correctamente");

        }


        [Route("ObtenerEmpleados")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewEmpleadoModel>>> ObtenerEmpleadosActivos()
        {
            var empleado = await _repository.GetAll();
            var viewEmpleado = _mapper.Map<IEnumerable<Empleado>, IEnumerable<ViewEmpleadoModel>>(empleado);
            return Ok(viewEmpleado);

        }


        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, [FromBody] UpdateEmpleadoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            var cliente = await _repository.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            _mapper.Map(model, cliente);

            await _repository.Update(cliente);
            await _repository.Save();
            return Ok("Empleado Actualizado");
        }


        [Route("EmpleadoDesactivar/{id}")]
        [HttpPost]
        public async Task<ActionResult> DeleteIsActive(int id, DeleteEmpleadoModel model)
        {
            if (model == null)
            {
                return BadRequest("El modelo es nulo");
            }

            model.IdEmpleado = id;

            var empleado = _mapper.Map<Empleado>(model);

            await _repository.Delete(empleado.Id);
            await _repository.Save();
            return Ok("Se Desactivo el cliente");

        }
    }
}
