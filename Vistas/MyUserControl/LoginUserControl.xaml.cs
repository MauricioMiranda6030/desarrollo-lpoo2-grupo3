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
                MessageBox.Show("Bienvenido/a " + usuario);

                Window home = Window.GetWindow(new HomeWindow());

                Window windowse = Window.GetWindow(this);
                home.Show();
                windowse.Close();
                
            }
            else
            {
                MessageBox.Show("El usuario " + txtUser.Text + " o la contraseña no coinciden con ningún administrador.");
            }
        }
    }
}
