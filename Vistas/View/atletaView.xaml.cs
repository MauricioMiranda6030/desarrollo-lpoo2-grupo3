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
using System.Data;
using System.Data.SqlClient;

namespace Vistas.View
{
    /// <summary>
    /// Interaction logic for atletaView.xaml
    /// </summary>
    public partial class atletaView : UserControl
    {
        int idModificar = 0;

        public atletaView()
        {
            InitializeComponent();
            loadAthletes();
            this.DataContext = new Atleta(); 
        }

        public void loadAthletes() {
            DataTable athletes = TrabajarAtletas.listAtletas();
            dataGridAtletas.ItemsSource = athletes.DefaultView;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Convertir el texto del campo de búsqueda a entero (ID)
            if (isNumber(txtSearch.Text))
            {
                // Obtener el atleta por su ID
                Atleta atleta = TrabajarAtletas.GetAtletaById(int.Parse(txtSearch.Text));

                // Si se encontró el atleta, llenar los campos
                if (atleta != null)
                {
                    txtNombre.Text = atleta.Nombre;
                    txtApellido.Text = atleta.Apellido;
                    txtDni.Text = atleta.DNI;
                    txtNacionalidad.Text = atleta.Nacionalidad;
                    txtEntrenador.Text = atleta.Entrenador;
                    txtGenero.SelectedValue = atleta.Genero; 
                    txtAltura.Text = atleta.Altura.ToString();
                    txtPeso.Text = atleta.Peso.ToString();
                    txtFechaNac.SelectedDate = atleta.FechaNacimiento; 
                    txtDireccion.Text = atleta.Direccion;
                    txtEmail.Text = atleta.Email;

                    idModificar = int.Parse(txtSearch.Text);
                    
                }
                else
                {
                    MessageBox.Show("No se encontró el atleta con ese ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            txtSearch.Text = null;
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
                ClaseBase.TrabajarAtletas.addAtleta(addAtleta(oAtleta));
                mostrarAtleta(oAtleta);
                loadAthletes();
                cleanup();
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
            Atleta oAtleta = (Atleta)this.DataContext;

            if (!ValidarAtleta(oAtleta))
            {
                WindowUtil.customMessage("Por favor, completa todos los campos obligatorios correctamente.");
                return;
            }
            if (WindowUtil.messageYesNo("¿Seguro que quieres modificar al Atleta?"))
            {
                addAtleta(oAtleta);
                oAtleta.Id = idModificar;
                ClaseBase.TrabajarAtletas.updateAtleta(oAtleta);
                mostrarAtleta(oAtleta);
                loadAthletes();
                idModificar = 0;
                cleanup();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (idModificar == 0)
            {
                WindowUtil.customMessage("Por favor, Selecciona un usuario a eliminar");
                return;
            }
            if (WindowUtil.messageYesNo("¿Seguro que quieres ELIMINAR al Atleta?"))
            {
                ClaseBase.TrabajarAtletas.deleteAtleta(idModificar);
                loadAthletes();
                idModificar = 0;
                cleanup();
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cleanup();
        }

        public bool isNumber(String number) {
            try
            {
                int.Parse(number);
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public void cleanup() {

            txtNombre.Text = null;
            txtApellido.Text = null;
            txtDni.Text = null;
            txtNacionalidad.Text = null;
            txtEntrenador.Text = null;
            txtGenero.SelectedValue = null;
            txtAltura.Text = null;
            txtPeso.Text = null;
            txtFechaNac.SelectedDate = null;
            txtDireccion.Text = null;
            txtEmail.Text = null;
        }
        
    }
}
