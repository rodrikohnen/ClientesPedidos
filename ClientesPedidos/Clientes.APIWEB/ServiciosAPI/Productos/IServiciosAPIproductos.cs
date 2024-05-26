using Clientes.Models;

namespace Clientes.APIWEB
{
    public interface IServiciosAPIproductos
    {
        Task<List<MostrarProductoDTO>> ListarProductos();

        Task<MostrarProductoDTO> ObtenerPorId(int idProducto);

        Task<bool> Guardar(CreacionProductoDTO modelo);

        Task<bool> Editar(CreacionProductoDTO modelo);

        Task<bool> Borrar(int idProducto);

    }
}