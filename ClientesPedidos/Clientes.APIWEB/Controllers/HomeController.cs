using Clientes.APIWEB.Models;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Globalization;
using NuGet.Protocol;

namespace Clientes.APIWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _serviciosAPI;
        private readonly IServiciosAPIproductos _serviciosAPIProductos;

        public HomeController(IServicio_API servicios_API, IServiciosAPIproductos serviciosAPIproductos)
        {
            _serviciosAPI = servicios_API;
            _serviciosAPIProductos = serviciosAPIproductos;
        }

        public async Task<IActionResult> Index()
        {
            List<MostrarClienteDTO> lista = await _serviciosAPI.ListarClientes();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Cliente(int idCliente)
        {
            MostrarClienteDTO objeto = new MostrarClienteDTO();

            ViewBag.Accion = "Nuevo Cliente";

            if (idCliente != 0)
            {
                objeto = await _serviciosAPI.ObtenerPorId(idCliente);
                ViewBag.Accion = "Editar Producto";
            }

            return View(objeto);
        }

        public async Task<IActionResult> Registrar(CreacionClienteDTO modelo)
        {

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente(CreacionClienteDTO modelo)
        {
            bool respuesta = false;

            respuesta = await _serviciosAPI.GuardarCliente(modelo);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else return NoContent();

        }

        [HttpGet]
        public IActionResult ActualizarCliente(int idCliente)
        {
            CreacionClienteDTO modelo = new CreacionClienteDTO();

            modelo.Id = idCliente;

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarClienteView(CreacionClienteDTO modelo)
        {
            bool respuesta = false;

            respuesta = await _serviciosAPI.EditarCliente(modelo);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int idCliente)
        {
            var respuesta = await _serviciosAPI.BorrarCliente(idCliente);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else return NoContent();

        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }


        //Productos

        public async Task<IActionResult> Productos()
        {
            List<MostrarProductoDTO> lista = new List<MostrarProductoDTO>();
            lista = await _serviciosAPIProductos.ListarProductos();
            return View(lista);
        }


        public async Task<IActionResult> RegistrarProducto(CrearProductoServiciosModel modelo)
        {            
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProductoView(CrearProductoServiciosModel modelo)
        {
            bool respuesta = false;

            CreacionProductoDTO modeloPeticion = new CreacionProductoDTO();
            
            modeloPeticion.Codigo = modelo.Codigo;
            modeloPeticion.Descripcion = modelo.Descripcion;
            modeloPeticion.Unidad = modelo.Unidad;
            modelo.PrecioUnidad = modelo.PrecioUnidad ?? "0";                                
            modeloPeticion.PrecioUnidad = decimal.Parse(modelo.PrecioUnidad!, CultureInfo.InvariantCulture);


            respuesta = await _serviciosAPIProductos.Guardar(modeloPeticion);

            if (respuesta)
            {
                return RedirectToAction("Productos");
            }
            else return NoContent();

        }


        [HttpGet]
        public IActionResult ActualizarProducto(int idProducto)
        {
            CrearProductoServiciosModel modelo = new CrearProductoServiciosModel();

            modelo.Id = idProducto;            
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarProductoView(CrearProductoServiciosModel modelo)
        {
            bool respuesta = false;

            CreacionProductoDTO modeloPeticion = new CreacionProductoDTO();

            modeloPeticion.Id = modelo.Id;
            modeloPeticion.Codigo = modelo.Codigo;
            modeloPeticion.Descripcion = modelo.Descripcion;
            modeloPeticion.Unidad = modelo.Unidad;
            modelo.PrecioUnidad = modelo.PrecioUnidad ?? "0";            
            modeloPeticion.PrecioUnidad = decimal.Parse(modelo.PrecioUnidad!, CultureInfo.InvariantCulture);
            

            respuesta = await _serviciosAPIProductos.Editar(modeloPeticion);

            if (respuesta)
            {
                return RedirectToAction("Productos");
            }
            else return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> EliminarProducto(int idProducto)
        {
            var respuesta = await _serviciosAPIProductos.Borrar(idProducto);
            if (respuesta)
            {
                return RedirectToAction("Productos");
            }
            else return NoContent();

        }

        //Pedidos

        public async Task<IActionResult> Pedidos(int? idCliente, string? Name, int? Nro, string? Tipo)
        {         
            CrearPedidoModel model = new CrearPedidoModel()
            {
                ClienteId = idCliente,
                ClienteName = Name,
                ClienteNroDocumento = Nro,
                ClienteTipoDeDocumento = Tipo,
            };            

            return View(model);
        }

        public async Task<IActionResult> AgregarPedido(int? idCliente, string? Name, int? Nro, string? Tipo)
        {
            PedidoModel modelo = new PedidoModel();            
            var lista = await _serviciosAPIProductos.ListarProductos();
            foreach (var pedido in lista)
            {
                var listaPedido = new MostrarProductoPedidoDTO
                {
                    Id = pedido.Id,
                    Codigo = pedido.Codigo,
                    Descripcion = pedido.Descripcion,
                    Unidad = pedido.Unidad,
                    PrecioUnidad = pedido.PrecioUnidad,
                    Cantidad = 0,
                    Subtotal = 0
                };
                modelo.RenglonesPedidos!.Add(listaPedido);
            }
            
            return View(modelo);
        }

        public async Task<IActionResult> AgregarProductoPedido(int? idProducto, string? Codigo, string? Descripcion, string? Unidad, decimal? Precio, int? idCliente, string? Name, int? Nro, string? Tipo)
        {
            CrearPedidoModel modelo = new CrearPedidoModel()
            {
                ClienteId = idCliente,
                ClienteName = Name,
                ClienteNroDocumento = Nro,
                ClienteTipoDeDocumento = Tipo,
                ProductoId = idProducto,
                ProductoCodigo = Codigo,
                ProductoDescripcion = Descripcion,
                ProductoUnidad = Unidad,
                ProductoPrecio = Precio/1000,
                ProductoCantidad = 0,                
            };
          
            return View(modelo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
