using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class Pedido
    {
        public int? Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }             
        public List<RenglonesPedidos>? RenglonesPedidos { get; set; } = new List<RenglonesPedidos>();
        [Precision(18, 2)]
        public decimal? Total { get; set; }

    }
}
