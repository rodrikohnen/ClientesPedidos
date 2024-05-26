using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class MostrarProductoPedidoDTO
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Unidad { get; set; }
        [Precision(18, 3)]
        public decimal? PrecioUnidad { get; set; }
        public int? Cantidad { get; set; }
        [Precision(18, 3)]
        public decimal? Subtotal { get; set; }
    }
}