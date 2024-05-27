using Clientes.BLL;
using Clientes.DAL;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.APIWEB.APIController
{   
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoServicio _pedidoService;
        private readonly IRenglonesPedidosServicio _renglonService;


        public PedidosController(IPedidoServicio pedidoService, IRenglonesPedidosServicio renglonService)
        {
            _pedidoService = pedidoService;
            _renglonService = renglonService;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<MostrarPedidoDTO>> ListarporID(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObtenerPorId(id);

                return Ok(pedido);
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
        
        [HttpGet("MisPedidos")]
        public async Task<ActionResult<List<MostrarPedidoDTO>>> Listar(int idCliente)
        {
            try
            {
                var pedidos = await _pedidoService.misPedidos(idCliente);

                return Ok(pedidos);
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

        [HttpPost]
        public async Task<ActionResult<MostrarPedidoDTO>> Registrar(CrearPedidoDTO modelo)
        {
            try
           {          
                var pedidoFinal = await _pedidoService.Registrar(modelo);
                return Ok(pedidoFinal);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }

        }
        
        [HttpPut]
        public async Task<ActionResult<MostrarPedidoDTO>> Actualizar(int id, CrearRenglonesPedidoDTO modelo)
        {
            try
            {
                var datos = await _renglonService.Actualizar(id, modelo);

                return Ok(datos);
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

        
        [HttpDelete]
        public async Task<IActionResult> EliminarPedidoTotal(int id)
        {
            try
            {
                var resultado = await _pedidoService.Eliminar(id);


                await _renglonService.Eliminar(id);

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
        */
    }
}
