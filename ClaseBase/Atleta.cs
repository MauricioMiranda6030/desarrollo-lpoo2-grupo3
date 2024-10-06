using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Atleta
    {
        public int Id { get; set; }
        public String DNI { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Nacionalidad { get; set; }
        public String Entrenador { get; set; }
        public String Genero { get; set; }
        public Double Altura { get; set; }
        public Double Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }

        public Atleta() { }
    }
}
