using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class CrearRenglonesPedidoDTO
    {
        public int? Id { get; set; }
        [Required]
        public int? Renglon { get; set; }
        [Required]
        public int? PedidoId { get; set; }
        [Required]
        public int? ProductoId { get; set; }
        [Required]
        public int? Cantidad { get; set; }
        [Required]
        [Precision(18, 3)]
        public decimal? Subtotal { get; set; }
    }
}