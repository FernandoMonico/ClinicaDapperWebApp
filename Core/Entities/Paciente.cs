using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
