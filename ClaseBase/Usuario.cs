using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nickname { get; set; }
        public String Password { get; set; }
        public String NombreCompleto { get; set; }
        public int RolCodigo { get; set; }

        public Usuario() {}
    }
}
