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
    /// Lógica de interacción para DisciplinaWindow.xaml
    /// </summary>
    public partial class DisciplinaWindow : Window
    {
        public DisciplinaWindow()
        {
            InitializeComponent();
        }

       

        private void btnAgregarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("¿Desea agregar ésta Disciplina?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Disciplina oDisciplina = new Disciplina();
                oDisciplina.Name = txtNombreDisciplina.Text;
                oDisciplina.Description = txtDescripcionDiscplina.Text;

                MessageBox.Show("Nombre: " + oDisciplina.Name + "\nDescripcion: " + oDisciplina.Description);
            }

        }

        private void btnCancelarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new HomeWindow());
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreDisciplina.Text = String.Empty;
            txtDescripcionDiscplina.Text = String.Empty;
        }
    }
}
