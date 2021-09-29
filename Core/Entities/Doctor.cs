using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
    }
}
