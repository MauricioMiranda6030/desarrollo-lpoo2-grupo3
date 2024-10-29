using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;


namespace ClaseBase
{
    public class TrabajarUsuario
    {
        public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();
            listaUsuario.Add(new Usuario ("rocio","123"));
            listaUsuario.Add(new Usuario("nico", "456"));

            return listaUsuario;
        }
    }
}
