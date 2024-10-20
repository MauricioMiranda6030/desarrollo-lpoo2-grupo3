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


    }
}
