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
    /// Lógica de interacción para AtletaWindow.xaml
    /// </summary>
    public partial class AtletaWindow : Window
    {
        public AtletaWindow()
        {
            InitializeComponent();
            cmbAtleta.Items.Add("Masculino");
            cmbAtleta.Items.Add("Femenino");
            
        }

        private void btnAgregarAtleta_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("¿Desea agregar éste Atleta?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Atleta oAtleta = new Atleta();
                oAtleta.DNI = txtDniAtleta.Text;
                oAtleta.Apellido = txtApellidoAtleta.Text;
                oAtleta.Nombre = txtNombreAtleta.Text;
                oAtleta.Nacionalidad = txtNacionalidadAtleta.Text;
                oAtleta.Entrenador = txtEntrenadorAtleta.Text;
                oAtleta.Genero = cmbAtleta.Text;
                oAtleta.Altura = double.Parse(txtAlturaAtleta.Text);       
                oAtleta.Peso = double.Parse(txtPesoAtleta.Text);
                // Convertir Fecha de Nacimiento
                if (dpNacimientoAtleta.SelectedDate.HasValue)
                {
                    oAtleta.FechaNacimiento = dpNacimientoAtleta.SelectedDate.Value;
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fecha válida.");
                    return; // Salir del método si la fecha no es válida
                }
                oAtleta.Direccion = txtDireccionAtleta.Text;
                oAtleta.Email = txtEmailAtleta.Text;





                MessageBox.Show(
                    "DNI: " + oAtleta.DNI + "\n" +
                     "Apellido: " + oAtleta.Apellido + "\n" +
                     "Nombre: " + oAtleta.Nombre + "\n" +
                     "Nacionalidad: " + oAtleta.Nacionalidad + "\n" +
                     "Entrenador: " + oAtleta.Entrenador + "\n" +
                     "Género: " + oAtleta.Genero + "\n" +
                     "Altura: " + oAtleta.Altura + " m\n" +
                     "Peso: " + oAtleta.Peso + " kg\n" +
                     "Fecha de Nacimiento: " + oAtleta.FechaNacimiento.ToString("dd/MM/yyyy") + "\n" +
                     "Dirección: " + oAtleta.Direccion + "\n" +
                     "Email: " + oAtleta.Email
               );

            }
        }

        private void btnCancelarAtleta_Click(object sender, RoutedEventArgs e)
        {
            
            WindowUtil.openWindow(this, new HomeWindow());
        }
    }
}
