using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Vistas.util;
using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    public static class WindowUtil
    {

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /**
         * Mueve la ventana
         * */
        public static void windowDrag(Window window, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
            }
        }

        /**
         * Abrir Ventanas
         * */
        public static void openWindow(Window windowCurrent, Window windowNew)
        {
            windowNew.Show();
            windowCurrent.Close();
        }

        /** Mueve la ventana completa
         * 
         * */
        public static void MoveWindow(Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        /**
        * Mostrar mensaje personalizado aceptar
        * */
        public static void customMessage(string message)
        {
            dialogBox dialog = new dialogBox(message);
            dialog.ShowDialog();
        }

        /**
         * Mostrar mensaje personalizado yes no
         * */
        public static bool messageYesNo(string message)
        {
            var dialog = new dialogYesNo(message);
            bool? result = dialog.ShowDialog();
            return result ?? false;
        }

        /**
         * Maximiza la pantalla
         * */
        public static void MaximizeWindow(Window window)
        {
            window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        /**
         * Maximiza y Minimiza la pantalla
         * */
        public static void maximizeMinimizeWindow(Window window)
        {
            if (window.WindowState == WindowState.Normal)
                window.WindowState = WindowState.Maximized;
            else window.WindowState = WindowState.Normal;
        }

        /**
         * Setea la hora y fecha
         * */
        public static void SetDateTimeLabels(Label dateLabel, Label timeLabel)
        {
            dateLabel.Content = DateTime.Now.ToString("dd/MM/yyyy");
            timeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        /**
         * Cambia el contador de segundos
         * */
        public static void StartTimer(Label timeLabel)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (sender, e) =>
            {
                // Actualizar la hora cada segundo
                timeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }

        /// <summary>
        /// Abre un UserControl en el área especificada y cierra el UserControl actual.
        /// </summary>
        public static void OpenUserControl(ContentControl contentArea, UserControl userControl)
        {
            // Cerrar el UserControl actual
            contentArea.Content = null; // O también puedes manejarlo de otra manera si necesitas ejecutar código al cerrar

            // Abrir el nuevo UserControl
            contentArea.Content = userControl;
        }

    }
}
