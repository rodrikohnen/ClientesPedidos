using Clientes.APIWEB.Models;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

namespace Clientes.APIWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _serviciosAPI;

        public HomeController(IServicio_API servicios_API)
        {
            _serviciosAPI = servicios_API;
        }
      
        public async Task<IActionResult> Index()
        {
            List<MostrarClienteDTO> lista = await _serviciosAPI.ListarClientes();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult>Cliente(int idCliente)
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

        [HttpPost]
        public async Task<IActionResult> ActualizarClienteView (CreacionClienteDTO modelo)
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
        public async Task<IActionResult>Eliminar(int idCliente)
        {
            var respuesta = await _serviciosAPI.BorrarCliente(idCliente);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else return NoContent();

        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registrar(CreacionClienteDTO modelo)
        {

            return View(modelo);
        }

        [HttpGet]
        public IActionResult ActualizarCliente(int idCliente)
        {
            CreacionClienteDTO modelo = new CreacionClienteDTO();

            modelo.Id = idCliente;

            return View(modelo);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
