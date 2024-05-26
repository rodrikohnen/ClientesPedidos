
namespace Clientes.Models
{
    public class ResultadoAPI
    {
        public List<MostrarClienteDTO>? Lista { get; set; }
        public MostrarClienteDTO? Objeto { get; set; }
        public string? Mensaje { get; set; }
    }
}
