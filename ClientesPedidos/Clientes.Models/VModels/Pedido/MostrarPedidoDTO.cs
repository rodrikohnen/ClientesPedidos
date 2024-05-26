using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class MostrarPedidoDTO
    {
        public int? Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }           
        public List<RenglonesPedidos>? RenglonesPedidos { get; set; } = new List<RenglonesPedidos>();
        [Precision(18, 3)]
        public decimal? Total { get; set; }
    }
}

