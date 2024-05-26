using AutoMapper;
using Clientes.DAL;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.BLL
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMapper _mapper;

        public ProductoServicio(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _productoRepositorio = productoRepositorio;
        }

        public async Task<MostrarProductoDTO> Actualizar(int? id, CreacionProductoDTO modelo)
        {
            return await _productoRepositorio.Actualizar(id, modelo);
        }

        public async Task<bool> Eliminar(int? id)
        {
            return await _productoRepositorio.Eliminar(id);
        }

        public async Task<MostrarProductoDTO> ObtenerPorId(int? id)
        {
            return await _productoRepositorio.ObtenerPorId(id);
        }

        public async Task<List<MostrarProductoDTO>> ObtenerTodos()
        {
            var queryProductos = await _productoRepositorio.ObtenerTodos();

            var listaProductos = await queryProductos.ToListAsync();

            return _mapper.Map<List<MostrarProductoDTO>>(listaProductos);
        }

        public async Task<MostrarProductoDTO> Registrar(CreacionProductoDTO modelo)
        {
            return await _productoRepositorio.Insertar(modelo);
        }
    }
}
