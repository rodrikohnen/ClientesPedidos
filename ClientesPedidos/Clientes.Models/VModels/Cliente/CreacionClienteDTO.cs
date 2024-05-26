using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class CreacionClienteDTO
    {
        public int? Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$", ErrorMessage = "Caracteres no permitidos.")]
        public string? NameLastname { get; set; }

        [Required]
        [Range(1, 2147483640, ErrorMessage = "El valor para {0} tiene que ser entre {1} y {2}")]
        public int? NroDocumento { get; set; }

        [Required]
        [Documento("cedula", "pasaporte")]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$", ErrorMessage = "Caracteres no permitidos.")]
        public string? TipoDeDocumento { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "El formato de fecha debe ser DD/MM/AAAA")]
        [DateRange]
        public string? FechadeNacimiento { get; set; }

        
        public DateTime? FechaHoraActualizacion { get; set; } = DateTime.Now;
    }
}
