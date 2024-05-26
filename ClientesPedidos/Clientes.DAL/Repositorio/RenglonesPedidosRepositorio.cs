using AutoMapper;
using Clientes.DAL.Contrato;
using Clientes.DAL.Dbcontext;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL
{
    public class RenglonesPedidosRepositorio : IRenglonesPedidosRepositorio
    {
        private readonly AplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RenglonesPedidosRepositorio(AplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MostrarRenglonesPedidoDTO> Actualizar(int? id, CrearRenglonesPedidoDTO modelo)
        {
            try
            {
                var renglonesPedido = await _dbContext.RenglonesPedidos.Where(c => c.PedidoId == modelo.PedidoId).ToListAsync();

                if (renglonesPedido == null) throw new NotFoundException();

                foreach (var renglon in renglonesPedido)
                {
                    renglon.Id = id;

                    renglon.PedidoId = modelo.PedidoId;

                    renglon.Renglon = modelo.Renglon;

                    renglon.ProductoId = modelo.ProductoId;

                    renglon.Cantidad = modelo.Cantidad;                    

                    renglon.Subtotal = modelo.Subtotal;

                    _dbContext.Update(renglon);

                }
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<MostrarRenglonesPedidoDTO>(renglonesPedido);
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
                var renglonespedido = await _dbContext.RenglonesPedidos.Where(c => c.PedidoId == id).ToListAsync();

                if (renglonespedido == null) throw new NotFoundException();

                foreach (var renglon in renglonespedido)
                {
                    _dbContext.Remove(renglon);
                }
                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MostrarRenglonesPedidoDTO> Insertar(CrearRenglonesPedidoDTO modelo)
        {
            try
            {
                var renglonespedido = _mapper.Map<RenglonesPedidos>(modelo);
                _dbContext.Add(renglonespedido);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<MostrarRenglonesPedidoDTO>(renglonespedido);

            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<MostrarRenglonesPedidoDTO> ObtenerPorId(int? id)
        {

            var renglonespedido = await _dbContext.RenglonesPedidos.Where(c => c.PedidoId == id).OrderBy(c => c.Renglon).ToListAsync();

            if (renglonespedido == null) throw new NotFoundException();

            return _mapper.Map<MostrarRenglonesPedidoDTO>(renglonespedido);
        }

        public async Task<IQueryable<RenglonesPedidos>> ObtenerTodos()
        {
            try
            {
                IQueryable<RenglonesPedidos> queryReglonesPedido = _dbContext.RenglonesPedidos;
                return queryReglonesPedido;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
