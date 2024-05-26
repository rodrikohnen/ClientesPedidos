using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class MostrarRenglonesPedidoDTO
    {
        public int? Id { get; set; }
        public int? Renglon { get; set; }
        public int? PedidoId { get; set; }
        public int? ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int? Cantidad { get; set; }
        [Precision(18, 2)]
        public decimal? Subtotal { get; set; }
    }
}