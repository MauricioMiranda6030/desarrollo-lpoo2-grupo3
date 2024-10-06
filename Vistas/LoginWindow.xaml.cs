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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> usuarios = new Dictionary<string, string>()
        {
            { "administrador", "administrador" },
            { "operador", "operador" },
            { "vendedor", "vendedor" }
        };

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
            Application.Current.Shutdown();
        }

        ///** LOGIN */
        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    string usuario = txtUser.Text;
        //    string contrasenia = txtPass.Password;

        //    if (usuarios.ContainsKey(usuario) && usuarios[usuario] == contrasenia)
        //    {
        //        MessageBox.Show("Bienvenido/a " + usuario);
        //        WindowUtil.openWindow(this, new HomeWindow());
        //    }
        //    else
        //    {
        //        MessageBox.Show("El usuario " + txtUser.Text + " o la contraseña no coinciden con ningún administrador.");
        //    }
        //}

        /**
         * Mueve la ventana
         * */
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.windowDrag(this, e);
        }
    }
}
