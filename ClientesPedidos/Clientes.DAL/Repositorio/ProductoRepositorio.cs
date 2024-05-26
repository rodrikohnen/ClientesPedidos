using AutoMapper;
using Clientes.DAL.Dbcontext;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;


namespace Clientes.DAL
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductoRepositorio(AplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MostrarProductoDTO> Actualizar(int? id, CreacionProductoDTO modelo)
        {
            var producto = await _dbContext.Productos.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (producto == null) throw new NotFoundException();

            producto.Id = id;
            producto.Codigo = modelo.Codigo;
            producto.Descripcion = modelo.Descripcion;
            producto.Unidad = modelo.Unidad;
            producto.PrecioUnidad = modelo.PrecioUnidad;
          
            _dbContext.Update(producto);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MostrarProductoDTO>(producto);
        }

        public async Task<bool> Eliminar(int? id)
        {
            var producto = await _dbContext.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (producto == null) throw new NotFoundException();
            _dbContext.Remove(producto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<MostrarProductoDTO> Insertar(CreacionProductoDTO modelo)
        {
            try
            {
                var productoAdd = _mapper.Map<Producto>(modelo);                
                _dbContext.Add(productoAdd);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<MostrarProductoDTO>(productoAdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MostrarProductoDTO> ObtenerPorId(int? id)
        {
            var producto = await _dbContext.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (producto == null) throw new NotFoundException();
            return _mapper.Map<MostrarProductoDTO>(producto);
        }

        public async Task<IQueryable<Producto>> ObtenerTodos()
        {
            try
            {
                IQueryable<Producto> queryProductos = _dbContext.Productos;
                return queryProductos;
            }
            catch
            {
                throw new BadRequestException();
            }
        }
    }
}
