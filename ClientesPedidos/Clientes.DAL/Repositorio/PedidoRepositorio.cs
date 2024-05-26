using AutoMapper;
using Clientes.DAL.Dbcontext;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PedidoRepositorio(AplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MostrarPedidoDTO> Actualizar(int? id, CrearPedidoDTO modelo)
        {
            try
            {
                var pedido = await _dbContext.Pedidos.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (pedido == null) throw new NotFoundException();

                pedido.Id = id;

                pedido.ClienteId = modelo.ClienteId;              

                pedido.Total = modelo.Total;                

                _dbContext.Update(pedido);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<MostrarPedidoDTO>(pedido);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int? id)
        {
            try
            {
                var pedido = await _dbContext.Pedidos.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (pedido == null) throw new NotFoundException();

                _dbContext.Remove(pedido);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MostrarPedidoDTO> Insertar(CrearPedidoDTO modelo)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(modelo);

                _dbContext.Add(pedido);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<MostrarPedidoDTO>(pedido);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MostrarPedidoDTO> ObtenerPorId(int? id)
        {
            var pedido = await _dbContext.Pedidos.Where(c => c.Id == id).Include(c => c.RenglonesPedidos!).ThenInclude(p => p.Producto).FirstOrDefaultAsync();

            if (pedido == null) throw new NotFoundException();

            return _mapper.Map<MostrarPedidoDTO>(pedido);
        }

        public async Task<IQueryable<Pedido>> ObtenerTodos()
        {
            try
            {
                IQueryable<Pedido> queryPedido = _dbContext.Pedidos.Include(c => c.RenglonesPedidos).ThenInclude(p => p.Producto);
                return queryPedido;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
