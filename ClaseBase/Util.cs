using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public static class Util
    {
        public static Rol getRol(int rolCodigo)
        {
            switch (rolCodigo)
            {
                case 1:
                    return new Rol(1, "Administrador");
                case 2:
                    return new Rol(2, "Operador");
                case 3:
                    return new Rol(3, "Auditor");
                default:
                    return new Rol(0, "desconocido");
            }
        }
    }
}
