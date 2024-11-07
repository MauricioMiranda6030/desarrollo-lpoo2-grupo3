using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ClaseBase;
namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for ListOrder.xaml
    /// </summary>
    public partial class ListOrder : UserControl
    {
        TrabajarUsuario trabajarUsuario = new TrabajarUsuario();

        public ListOrder()
        {
            InitializeComponent();
            cargarUsuario();
        }

        public void cargarUsuario()
        {
            ObservableCollection<Usuario> listaUsuarios = trabajarUsuario.getUserOrder();
            dgUsuarios.ItemsSource = listaUsuarios;
        }

        private void aplicarFiltro(string filtro)
        {
            ObservableCollection<Usuario> listaUsuarios = trabajarUsuario.getUserOrder();
            var usuariosFiltrados = new ObservableCollection<Usuario>();
            foreach (var usuario in listaUsuarios)
            {
                if (usuario.Nickname.ToLower().Contains(filtro))
                {
                    usuariosFiltrados.Add(usuario);
                }
            }

            dgUsuarios.ItemsSource = usuariosFiltrados;
        }

        private void txtFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txtFiltro.Text.ToLower();

            // Verificamos si el filtro solo contiene letras
            if (string.IsNullOrEmpty(filtro))
            {
                // Si no contiene letras o está vacío, mostramos todos los usuarios
                cargarUsuario();
            }
            else
            {
                // Si contiene letras, aplicamos el filtro
                aplicarFiltro(filtro);
            }
        }
    }
}
