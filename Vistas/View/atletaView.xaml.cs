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
using ClaseBase;

namespace Vistas.View
{
    /// <summary>
    /// Interaction logic for atletaView.xaml
    /// </summary>
    public partial class atletaView : UserControl
    {
        public atletaView()
        {
            InitializeComponent();
            this.DataContext = new Atleta(); 
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {            
            Atleta oAtleta = (Atleta)this.DataContext;

            if (!ValidarAtleta(oAtleta))
            {
                WindowUtil.customMessage("Por favor, completa todos los campos obligatorios correctamente.");
                return;
            }
            if (WindowUtil.messageYesNo("¿Seguro que quieres guardar al Atleta?"))
            {            
                addAtleta(oAtleta);
                mostrarAtleta(oAtleta);
            }
        }

        private bool ValidarAtleta(Atleta atleta)
        {            
            foreach (var property in typeof(Atleta).GetProperties())
            {
                string error = atleta[property.Name];
                if (!string.IsNullOrEmpty(error))
                {                    
                    return false;
                }
            }
            return true;
        }

        public Atleta addAtleta(Atleta oAtleta)
        {
            oAtleta.DNI = txtDni.Text;
            oAtleta.Apellido = txtApellido.Text;
            oAtleta.Nombre = txtNombre.Text;
            oAtleta.Nacionalidad = txtNacionalidad.Text;
            oAtleta.Entrenador = txtEntrenador.Text;
            oAtleta.Genero = txtGenero.Text;
            oAtleta.Altura = double.Parse(txtAltura.Text);
            oAtleta.Peso = double.Parse(txtPeso.Text);
            oAtleta.FechaNacimiento = txtFechaNac.SelectedDate.Value;
            oAtleta.Direccion = txtDireccion.Text;
            oAtleta.Email = txtEmail.Text;
            return oAtleta;
        }

        public void mostrarAtleta(Atleta oAtleta)
        {
            MessageBox.Show(
                    "ID: " + oAtleta.Id + "\n"+
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //En construcción...
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
