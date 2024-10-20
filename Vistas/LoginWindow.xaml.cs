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
            if (WindowUtil.messageYesNo("¿Seguro que queres salir?"))
            {
                Application.Current.Shutdown();
            }
        }

        /**
         * Mueve la ventana
         * */
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.windowDrag(this, e);
        }
    }
}
