using Clientes.Models;

namespace Clientes.DAL
{
    public interface IProductoRepositorio : IGenericoRepositorio <CreacionProductoDTO, MostrarProductoDTO, Producto>
    {
    }
}
