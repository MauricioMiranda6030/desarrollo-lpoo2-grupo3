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

           
            if (string.IsNullOrEmpty(filtro))
            {
               
                cargarUsuario();
            }
            else
            {
                
                aplicarFiltro(filtro);
            }
        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
               
                usuarios = trabajarUsuario.getUserOrder();
            }
            else
            {
               
                string filtro = txtFiltro.Text.ToLower();
                foreach (var usuario in trabajarUsuario.getUserOrder())
                {
                    if (usuario.Nickname.ToLower().Contains(filtro))
                    {
                        usuarios.Add(usuario);
                    }
                }
            }

           
            PrintPreview printPreview = new PrintPreview(usuarios);
            printPreview.ShowDialog();  

        }//fin

    }
}
