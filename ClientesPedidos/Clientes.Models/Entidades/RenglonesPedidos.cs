using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class RenglonesPedidos
    {
        public int? Id { get; set; }
        public int? Renglon { get; set; }
        public int? PedidoId { get; set; }
        public int? ProductoId { get; set; }
        public Producto? Producto { get; set; }     
        public int? Cantidad { get; set; }     
        [Precision(18, 3)]
        public decimal? Subtotal { get; set; }
    }
}
