using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Cliente
    {
        public int? Id { get; set; }
        public string? NameLastname { get; set; }
        public int? NroDocumento { get; set; }
        public string? TipoDeDocumento { get; set; }
        public DateTime? FechadeNacimiento { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }        

    }
}
