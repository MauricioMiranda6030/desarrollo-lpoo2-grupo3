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
using System.Collections.ObjectModel;
using ClaseBase;

namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        public ListView()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuarios;

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["list_usuario"];
            listaUsuarios = odp.Data as ObservableCollection<Usuario>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentBeforeFirst)
                Vista.MoveCurrentToLast();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
                Vista.MoveCurrentToLast();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }
    }
}
