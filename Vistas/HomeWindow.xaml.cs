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
using Vistas.View;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowUtil.SetDateTimeLabels(dateLabel, timeLabel);
            WindowUtil.StartTimer(timeLabel);
            WindowUtil.OpenUserControl(ContenArea, new MainView());
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowUtil.MoveWindow(this);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            WindowUtil.MaximizeWindow(this);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (WindowUtil.messageYesNo("¿Seguro que queres salir?"))
            {
                Application.Current.Shutdown();
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.maximizeMinimizeWindow(this);
        }

        private void btnMinize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.OpenUserControl(ContenArea, new MainView());
        }

        private void btnCompetencia_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.OpenUserControl(ContenArea, new CompetenceView());
        }

        private void btnAtleta_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.OpenUserControl(ContenArea, new atletaView());
        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btbDisciplina_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEvento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.openWindow(this, new LoginWindow());
        }


    }
}
