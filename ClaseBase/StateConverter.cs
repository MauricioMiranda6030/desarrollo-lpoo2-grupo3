using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data; 
using System.Windows.Media;

namespace ClaseBase
{
    public class StateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var estado = value as string;
            
            if (estado != null)
            {
                switch (estado)
                {
                    case "Programado":
                        return Brushes.Green;
                    case "Postergado":
                        return Brushes.Orange;
                    case "Reprogramado":
                        return Brushes.Yellow;
                    case "Cancelado":
                        return Brushes.Red;
                    default:
                        return Brushes.Gray;
                }
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
