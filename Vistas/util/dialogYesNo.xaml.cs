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

namespace Vistas.util
{
    /// <summary>
    /// Interaction logic for dialogYesNo.xaml
    /// </summary>
    public partial class dialogYesNo : Window
    {
        public dialogYesNo(string message)
        {
            InitializeComponent();
            this.txtMessage.Text = message;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.MoveWindow(this);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;  // Devuelve true para indicar que el usuario hizo clic en "SÍ"
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Devuelve false para indicar que el usuario hizo clic en "NO"
            this.Close();
        }
    }
}
