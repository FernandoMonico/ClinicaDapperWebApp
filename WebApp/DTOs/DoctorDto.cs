using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "Campor requerido")]
        public string Especialidad { get; set; }
    }
}
