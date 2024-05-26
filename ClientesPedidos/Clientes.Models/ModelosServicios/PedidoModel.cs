using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class PedidoModel
    {
        public int? Id { get; set; }
        public int? ClienteId { get; set; }
        public string? ClienteName { get; set; }
        public int? ClienteNroDocumento { get; set; }
        public string? ClienteTipoDeDocumento { get; set; }
        public int? ProductoId { get; set; }
        public string? ProductoCodigo { get; set; }
        public string? ProductoDescripcion { get; set; }
        public string? ProductoUnidad { get; set; }
        [Precision(18, 3)]
        public decimal? ProductoPrecio { get; set; }
        [Precision(18, 3)]
        public decimal? ProductoSubtotal { get; set; }
        public int? ProductoCantidad { get; set; }
        [Precision(18, 3)]
        public decimal? Total { get; set; }
        public List<MostrarProductoPedidoDTO>? RenglonesPedidos { get; set; } = new List<MostrarProductoPedidoDTO>();

    }
}
