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
using System.Windows.Shapes;
using ClaseBase;
namespace Vistas
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
        }
        /**
         * Minimiza la ventana
         * */
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /**
         * Cierra la aplicación
         * */
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow HomeWindow = new HomeWindow();
            HomeWindow.Show();
            this.Hide();
            
        }

        /**
        * Mueve la ventana
        * */
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.windowDrag(this, e);
        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("¿Desea agregar ésta Categoria?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Categoria oCategoria = new Categoria();
                oCategoria.Nombre = txtNombreCategoria.Text;
                oCategoria.Descripcion = txtDescripcionCategoria.Text;

                MessageBox.Show("Nombre: " + oCategoria.Nombre + "\nDescripcion: " + oCategoria.Descripcion);
            }
        }

        private void btnCancelarCategoria_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreCategoria.Text = String.Empty;
            txtDescripcionCategoria.Text = String.Empty;
        }


    }
}
