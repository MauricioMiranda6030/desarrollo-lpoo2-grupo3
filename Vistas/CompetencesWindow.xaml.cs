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
    /// Interaction logic for CompetencesWindow.xaml
    /// </summary>
    public partial class CompetencesWindow : Window
    {
        public CompetencesWindow()
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
