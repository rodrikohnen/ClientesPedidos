
using AutoMapper;
using Clientes.DAL.Contrato;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.BLL
{
    public class RenglonesPedidosServicios : IRenglonesPedidosServicio
    {
        private readonly IMapper _mapper;
        private readonly IRenglonesPedidosRepositorio _renglonesPedidosRepo;

        public RenglonesPedidosServicios(IMapper mapper, IRenglonesPedidosRepositorio renglonesPedidosRepositorio)
        {
            _mapper = mapper;
            _renglonesPedidosRepo = renglonesPedidosRepositorio;
        }
        public async Task<MostrarRenglonesPedidoDTO> Actualizar(int? id, CrearRenglonesPedidoDTO modelo)
        {
            return await _renglonesPedidosRepo.Actualizar(id, modelo);
        }

        public async Task<bool> Eliminar(int? id)
        {
            return await _renglonesPedidosRepo.Eliminar(id);
        }

        public async Task<MostrarRenglonesPedidoDTO> ObtenerPorId(int? id)
        {
            return await _renglonesPedidosRepo.ObtenerPorId(id);
        }

        public async Task<List<MostrarRenglonesPedidoDTO>> ObtenerTodos()
        {
            var query = await _renglonesPedidosRepo.ObtenerTodos();

            var lista = await query.ToListAsync();

            return _mapper.Map<List<MostrarRenglonesPedidoDTO>>(lista);
        }

        public async Task<MostrarRenglonesPedidoDTO> Registrar(CrearRenglonesPedidoDTO modelo)
        {
            return await _renglonesPedidosRepo.Insertar(modelo);
        }
    }
}
