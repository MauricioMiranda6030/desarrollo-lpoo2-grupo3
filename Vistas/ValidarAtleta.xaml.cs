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
    /// Interaction logic for ValidarAtleta.xaml
    /// </summary>
    public partial class ValidarAtleta : Window
    {
        private Atleta _atleta;
        public ValidarAtleta()
        {
            InitializeComponent();
            _atleta = new Atleta();
            this.DataContext = _atleta;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
       {
            // Muestra los errores si los hay
            var properties = typeof(Atleta).GetProperties();
            foreach (var prop in properties)
            {
                var value = _atleta[prop.Name];
                if (!string.IsNullOrEmpty(value))
                {
                    MessageBox.Show(prop.Name + ":"+ value);
                }
            }
            MessageBox.Show("Validación completada.");
        }

        private void btnCancelarValidarAtleta_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new HomeWindow());
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
            Application.Current.Shutdown();

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
