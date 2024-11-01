using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace ClaseBase
{
    public class Usuario : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public String Nickname { get; set; }
        public String Password { get; set; }
        public String NombreCompleto { get; set; }
        public int RolCodigo { get; set; }

        public Usuario() {}
        public Usuario(string pNickname, string pPassword) { }
        public Usuario(string pNickname, string pPassword, string pNombreCompleto, int RolCodigo) { }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
