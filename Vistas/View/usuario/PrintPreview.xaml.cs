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
using System.Collections.ObjectModel;
using ClaseBase;

namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for PrintPreview.xaml
    /// </summary>
    public partial class PrintPreview : Window
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }
        public PrintPreview(ObservableCollection<Usuario> usuarios)
        {
            InitializeComponent();
            // Asignar la lista de usuarios a la propiedad
             Usuarios = usuarios;

            // Establecer el DataContext de la ventana para el binding
            this.DataContext = this;
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
               printDialog.PrintDocument(((IDocumentPaginatorSource)DocReader.Document).DocumentPaginator, "Vista Previa de Impresión");
            }
        }
    }
}
