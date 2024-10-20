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
using Vistas.util;

namespace Vistas.MyUserControl
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> usuarios = new Dictionary<string, string>()
        {
            { "administrador", "administrador" },
            { "operador", "operador" },
            { "vendedor", "vendedor" }
        };

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUser.Text;
            string contrasenia = txtPass.Password;

            if (usuarios.ContainsKey(usuario) && usuarios[usuario] == contrasenia)
            {
                WindowUtil.customMessage("Bienvenido/a: " + txtUser.Text);
                Window windowse = Window.GetWindow(this);
                WindowUtil.openWindow(windowse, new HomeWindow());
            }
            else
            {
                lblError.Visibility = Visibility.Visible;
            }
        }
    }
}
