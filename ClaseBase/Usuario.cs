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
        //public int RolCodigo { get; set; }
        private Rol rol;

        public Rol Rol
        {
            get { return rol; }
            set
            {
                rol = value;
                Notificador("Rol");
            }
        }

        public Usuario() {}

        public Usuario(string pNickname, string pNombreCompleto, Rol rol)
        {
            this.Nickname = pNickname;
            this.NombreCompleto = pNombreCompleto;
            Rol = rol;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notificador(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
