using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public double Altura { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public double Peso { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto {
            get
            {
                return $"{Nombre} {Apellido}";
            }
        }
    }
}
