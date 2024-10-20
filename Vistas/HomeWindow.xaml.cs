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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }


        /**
         * Minimiza la ventana
         * */
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /**
         * Cierra la aplicación
         * */
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /**
        * Mueve la ventana
        * */
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.windowDrag(this, e);
        }

        /**
         * Modulos Principales de la aplicación
         * */
        private void btnSistema_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnParticipantes_Click(object sender, RoutedEventArgs e)
        {
            ParticipantsWindow partWin = new ParticipantsWindow();
            partWin.Show();
        }

        private void btnCompetencia_Click(object sender, RoutedEventArgs e)
        {
            CompetencesWindow compWin = new CompetencesWindow();
            compWin.Show();
        }

        private void btnEventos_Click(object sender, RoutedEventArgs e)
        {
            EventWindow eventWin = new EventWindow();
            eventWin.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("¿Cerrar Sesión?", "Logout", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == res)
            {
                LoginWindow frm = new LoginWindow();
                frm.Show();
                this.Close();
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new CategoryWindow());
            /*CategoryWindow catWin = new CategoryWindow();
            catWin.Show();*/
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new DisciplinaWindow());
            /*DisciplinaWindow disWin = new DisciplinaWindow();
            disWin.Show();*/
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new AtletaWindow());
            /*AtletaWindow atlWin = new AtletaWindow();
            atlWin.Show();*/
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new CompetitionStatesWindow());
        }




    }
}
