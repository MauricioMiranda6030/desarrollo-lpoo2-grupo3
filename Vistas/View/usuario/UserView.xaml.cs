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

namespace Vistas.View.usuario
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void UserView_Loaded(object sender, RoutedEventArgs e)
        {

            WindowUtil.OpenUserControl(subContenArea, new ListView());
        }

        private void btnGestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrdenamiento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.OpenUserControl(subContenArea, new ListView());
        }
    }
}
