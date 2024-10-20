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
using System.Xml;
using ClaseBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for CompetitionStatesWindow.xaml
    /// </summary>
    public partial class CompetitionStatesWindow : Window
    {
        
        public CompetitionStatesWindow()
        {
            InitializeComponent();
            
        }     
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           //cmbCompetitionState.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cambio no guardado");
            WindowUtil.openWindow(this, new HomeWindow());
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cambio guardado");
            WindowUtil.openWindow(this, new HomeWindow());
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.windowDrag(this, e);
        }

    }
}
