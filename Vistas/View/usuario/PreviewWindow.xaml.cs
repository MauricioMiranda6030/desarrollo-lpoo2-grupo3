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
using System.Collections.ObjectModel; 

namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private ObservableCollection<Usuario> listaUsuarios;  // Declaramos la variable listaUsuarios

        public PreviewWindow(ObservableCollection<Usuario> usuarios)
        {
            InitializeComponent();
            listaUsuarios = usuarios;
            CargarVistaPrevia();
        }
        // Cargar los usuarios en un FlowDocument
        private void CargarVistaPrevia()
        {
            FlowDocument doc = new FlowDocument();
            Paragraph title = new Paragraph(new Run("Listado de Usuarios"))
            {
                FontSize = 18,
                FontWeight = System.Windows.FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            };
            doc.Blocks.Add(title);

            foreach (var usuario in listaUsuarios)
            {
                // Asegúrate de que Rol no sea null antes de acceder a Descripcion
                string rolDescripcion = usuario.Rol != null ? usuario.Rol.Descripcion : "Desconocido";

                Paragraph p = new Paragraph();
                p.Inlines.Add(new Run("Username: " + usuario.Nickname + ", Nombre Completo: " + usuario.NombreCompleto + ", Rol: " + rolDescripcion));
                doc.Blocks.Add(p);
            }

            docReader.Document = doc;
        }

        // Método de impresión
        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Imprimir el FlowDocument que contiene la vista previa
                printDialog.PrintDocument(((IDocumentPaginatorSource)docReader.Document).DocumentPaginator, "Vista Previa de Impresión");
            }
        }
    }
}
