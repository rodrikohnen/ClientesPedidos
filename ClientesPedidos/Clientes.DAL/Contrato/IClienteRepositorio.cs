using Clientes.Models;

namespace Clientes.DAL
{
    public interface IClienteRepositorio : IGenericoRepositorio <CreacionClienteDTO, MostrarClienteDTO, Cliente>
    {
    }
}
