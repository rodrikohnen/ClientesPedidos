using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Producto
    {   
        public int? Id { get; set; }
        public string? Codigo { get; set; }        
        public string? Descripcion { get; set; }
        public string? Unidad { get; set; }
        [Precision(18, 3)]
        public decimal? PrecioUnidad { get; set; }
    }
}
