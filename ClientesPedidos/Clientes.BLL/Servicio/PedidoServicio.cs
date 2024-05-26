using AutoMapper;
using Clientes.DAL;
using Clientes.DAL.Dbcontext;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.BLL.Servicio
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IMapper _mapper;
        private readonly AplicationDbContext _dbContext;
        private readonly IProductoServicio _productoServicio;
        private readonly IRenglonesPedidosServicio _renglonesServicio;

        public PedidoServicio(IPedidoRepositorio pedidoRepositorio, IMapper mapper, AplicationDbContext dbContext, IProductoServicio productoServicio, IRenglonesPedidosServicio renglonesServicio)
        {
            _mapper = mapper;
            _pedidoRepositorio = pedidoRepositorio;
            _dbContext = dbContext;
            _productoServicio = productoServicio;
            _renglonesServicio = renglonesServicio;
            
        }
        public async Task<MostrarPedidoDTO> Actualizar(int? id, CrearPedidoDTO modelo)
        {
            return await _pedidoRepositorio.Actualizar(id, modelo);
        }

        public async Task<bool> Eliminar(int? id)
        {
            return await _pedidoRepositorio.Eliminar(id);
        }

        public async Task<IEnumerable<MostrarPedidoDTO>> misPedidos(int ClienteId)
        {
            var query = await _pedidoRepositorio.ObtenerTodos();

            var lista = await query
                .Include(p => p.RenglonesPedidos!)
                    .ThenInclude(r => r.Producto)                        
                .Where(p => p.ClienteId == ClienteId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<MostrarPedidoDTO>>(lista);
        }

        public async Task<MostrarPedidoDTO> ObtenerPorId(int? id)
        {
            return await _pedidoRepositorio.ObtenerPorId(id);
        }

        public async Task<List<MostrarPedidoDTO>> ObtenerTodos()
        {
            var query = await _pedidoRepositorio.ObtenerTodos();

            var lista = await query.ToListAsync();

            return _mapper.Map<List<MostrarPedidoDTO>>(lista);
        }

        public async Task<MostrarPedidoDTO> Registrar(CrearPedidoDTO pedido)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                pedido.Total = 0;
                
                var pedidoCreado = await _pedidoRepositorio.Insertar(pedido);

                int indice = 1;
                decimal? total = 0;
                foreach (var renglon in pedido.RenglonesPedidos!)
                {                                      
                    var producto = await _productoServicio.ObtenerPorId(renglon.ProductoId);
                    if (producto == null) throw new BadRequestException($"El producto con id: {renglon.ProductoId} no existe");

                    var renglonPedido = new CrearRenglonesPedidoDTO
                    {
                        Renglon = indice,
                        PedidoId = pedidoCreado.Id,
                        ProductoId = renglon.ProductoId,
                        Cantidad = renglon.Cantidad,
                        Subtotal = producto.PrecioUnidad * renglon.Cantidad,                       
                    };                                   
                    total += renglon.Subtotal;
                  
                    await _renglonesServicio.Registrar(renglonPedido);                                    

                    indice++;
                }

                await transaction.CommitAsync();

                CrearPedidoDTO creacionpedido = new CrearPedidoDTO()
                {
                    Total = total,                                    

                    ClienteId = pedidoCreado.ClienteId

                };

                var pedidofinal = await Actualizar(pedidoCreado.Id, creacionpedido);                

                return pedidofinal;

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
