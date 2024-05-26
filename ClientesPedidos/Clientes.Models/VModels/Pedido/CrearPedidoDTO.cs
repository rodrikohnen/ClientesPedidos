using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class CrearPedidoDTO
    {
        public int? Id { get; set; }
        [Required]
        public int? ClienteId { get; set; }
        [Required]
        public Cliente? Cliente { get; set; }
        [Required]
        public List<RenglonesPedidos>? RenglonesPedidos { get; set; } = new List<RenglonesPedidos>();
        [Precision(18, 3)]
        [Required]
        public decimal? Total { get; set; }
    }
}

