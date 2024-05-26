using Clientes.BLL;
using Clientes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.APIWEB.Controllers
{

    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MostrarClienteDTO>> ListarporID(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _clienteServicio.ObtenerPorId(id);

                    return Ok(cliente);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<MostrarClienteDTO>>> Obtenertodos()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientes = await _clienteServicio.ObtenerTodos();
                    return Ok(clientes);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult<MostrarClienteDTO>> Registrar(CreacionClienteDTO creacionCliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    creacionCliente.Id = null;

                    var cliente = await _clienteServicio.Registrar(creacionCliente);

                    return Ok(cliente);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            } else return BadRequest();

        }

    
        [HttpPut]
        public async Task<ActionResult<MostrarClienteDTO>> Actualizar(CreacionClienteDTO modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int? id = modelo.Id;
                    var cliente = await _clienteServicio.Actualizar(id, modelo);

                    return Ok(cliente);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var resultado = await _clienteServicio.Eliminar(id);

                    return NoContent();
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }
        
    }

}

