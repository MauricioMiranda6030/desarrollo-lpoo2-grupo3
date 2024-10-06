using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Vistas
{
    public static class WindowUtil
    {
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

    }
}
