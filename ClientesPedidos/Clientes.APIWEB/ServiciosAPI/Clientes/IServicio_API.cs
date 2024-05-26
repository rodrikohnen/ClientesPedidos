using Clientes.Models;

namespace Clientes.APIWEB
{
    public interface IServicio_API
    {
        Task<List<MostrarClienteDTO>> ListarClientes();

        Task<MostrarClienteDTO> ObtenerPorId(int idCliente);

        Task<bool> GuardarCliente(CreacionClienteDTO modelo);

        Task<bool> EditarCliente(CreacionClienteDTO modelo);

        Task<bool> BorrarCliente(int idCliente);

    }
}
