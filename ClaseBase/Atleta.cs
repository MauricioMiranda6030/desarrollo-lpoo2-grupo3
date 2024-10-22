using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClaseBase
{
    public class Atleta : IDataErrorInfo
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

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "DNI":
                        if (string.IsNullOrEmpty(DNI))
                            result = "El DNI es obligatorio.";
                        break;
                    case "Apellido":
                        if (string.IsNullOrEmpty(Apellido))
                            result = "El Apellido es obligatorio.";
                        break;
                    case "Altura":
                        if (Altura <= 0)
                            result = "La altura debe ser mayor a cero.";
                        break;
                    case "Peso":
                        if (Peso <= 0)
                            result = "El peso debe ser mayor a cero.";
                        break;
                }
                return result;
            }
        }
    }
}
