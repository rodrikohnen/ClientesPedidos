using Clientes.BLL;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.APIWEB.Controllers
{

    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MostrarProductoDTO>> ListarporID(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producto = await _productoServicio.ObtenerPorId(id);

                    return Ok(producto);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }
            else return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<MostrarProductoDTO>>> Obtenertodos()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productos = await _productoServicio.ObtenerTodos();
                    return Ok(productos);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }
            else return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult<MostrarProductoDTO>> Registrar(CreacionProductoDTO creacionProducto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    creacionProducto.Id = null;

                    var producto = await _productoServicio.Registrar(creacionProducto);

                    return Ok(producto);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }
            else return BadRequest();

        }


        [HttpPut]
        public async Task<ActionResult<MostrarProductoDTO>> Actualizar(CreacionProductoDTO modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int? id = modelo.Id;
                    var producto = await _productoServicio.Actualizar(id, modelo);

                    return Ok(producto);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }
            else return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var resultado = await _productoServicio.Eliminar(id);

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

            }
            else return BadRequest();
        }

    }

}

