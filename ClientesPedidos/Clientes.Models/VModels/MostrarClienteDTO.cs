namespace Clientes.Models
{
    public class MostrarClienteDTO
    {
        public int? Id { get; set; }
        public string? NameLastname { get; set; }
        public int? NroDocumento { get; set; }
        public string? TipoDeDocumento { get; set; }
        public DateTime? FechadeNacimiento { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }
    }
}
