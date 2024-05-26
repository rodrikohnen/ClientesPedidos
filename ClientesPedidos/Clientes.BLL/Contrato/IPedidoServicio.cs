
using Clientes.Models;

namespace Clientes.BLL
{
    public interface IPedidoServicio : IGenericoServicio<CrearPedidoDTO, MostrarPedidoDTO>
    {
        Task<IEnumerable<MostrarPedidoDTO>> misPedidos(int ClienteId);
    }
}
