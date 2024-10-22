using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace ClaseBase
{
    public class Atleta:IDataErrorInfo
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

        public string this[string columnName] {

            get {
                string result = null;
                switch (columnName) {
                   // case "id":
                       // if (Id <= 0)
                           // result = "ID es obligatorio y debe ser mayor a 0.";
                      //  break;
                    case "dni":
                        if (string.IsNullOrEmpty(DNI))
                            result = "DNI es obligatorio.";
                        break;
                    case "apellido":
                        if (string.IsNullOrEmpty(Apellido))
                            result = "Apellido es obligatorio.";
                        break;
                    case "nombre":
                        if (string.IsNullOrEmpty(Nombre))
                            result = "Nombre es obligatorio.";
                        break;
                    case "altura":
                        if (Altura <= 0)
                            result = "Altura es obligatoria y debe ser mayor a 0.";
                        break;
                    case "peso":
                        if (Peso <= 0)
                            result = "Peso es obligatorio y debe ser mayor a 0.";

                        break;
                }
                return result;
            }
        }



        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
