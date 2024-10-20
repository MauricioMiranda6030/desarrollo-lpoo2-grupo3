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
            //DataContext = this;
        }
     
        private void cmbCompetitionState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verifica si hay un elemento seleccionado
            var selectedItem = cmbCompetitionState.SelectedItem;
            if (selectedItem != null)
            {
                // Muestra el estado seleccionado en un MessageBox
                var element = selectedItem as System.Xml.XmlElement;
                if (element != null)
                {                    
                   // MessageBox.Show("Estado de Competencia: " + element.GetAttribute("name"));
                }
            }
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

    }
}
