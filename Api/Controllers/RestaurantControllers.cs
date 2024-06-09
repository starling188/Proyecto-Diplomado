using Domain.Interface.Repository;
using Domain.Models.Cliente;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantControllers : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public RestaurantControllers(IClienteRepository cliente)
        {
            _clienteRepository = cliente;
        }

        //// GET: api/<RestaurantControllers>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<RestaurantControllers>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RestaurantControllers>
       
        //[HttpPost]
        //[Route("addCliente")]
        //public async Task<ActionResult> AgregarCLiente ([FromBody] SaveClienteModel model)
        //{

        //    if (model == null)
        //    {
        //        return BadRequest("Cliente no puede ser nulo");
        //    }

        //    await _clienteRepository.Add(model);
        //    await _clienteRepository.Save();
        //    return Ok("Cliente agregado exitosamente");
        //}

        //// PUT api/<RestaurantControllers>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<RestaurantControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
