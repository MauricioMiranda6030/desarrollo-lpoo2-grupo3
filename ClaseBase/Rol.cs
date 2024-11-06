using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Rol
    {
        public int Codigo { get; set; }
        public String Descripcion { get; set; }

        public Rol() {}

        public Rol(int codigo, string descripcion)
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion;
        }
    }
}
