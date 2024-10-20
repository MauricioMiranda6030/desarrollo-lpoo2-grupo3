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
    /// Interaction logic for dialogBox.xaml
    /// </summary>
    public partial class dialogBox : Window
    {
        public dialogBox(string message)
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

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
