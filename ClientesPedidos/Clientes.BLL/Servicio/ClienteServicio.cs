using AutoMapper;
using Clientes.DAL;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace Clientes.BLL
{
    public class ClienteServicio : IClienteServicio //Lógica de Negocio
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }


        public async Task<MostrarClienteDTO> Actualizar(int? id, CreacionClienteDTO modelo)
        {
            modelo.FechaHoraActualizacion = DateTime.Now;
            return await _clienteRepositorio.Actualizar(id, modelo);
        }


        public async Task<bool> Eliminar(int id)
        {
           return await _clienteRepositorio.Eliminar(id);
        }


        public async Task<MostrarClienteDTO> ObtenerPorId(int id)
        {
            return await _clienteRepositorio.ObtenerPorId(id);
        }


        public async Task<List<MostrarClienteDTO>> ObtenerTodos()
        {
            var queryClientes =  await _clienteRepositorio.ObtenerTodos();

            var listaClientes = await queryClientes.ToListAsync();

            return _mapper.Map<List<MostrarClienteDTO>>(listaClientes);
        }


        public async Task<MostrarClienteDTO> Registrar(CreacionClienteDTO modelo)
        {
            
            modelo.FechaHoraActualizacion = DateTime.Now;
            return await _clienteRepositorio.Insertar(modelo);
        }
    }
}
