using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace MonitorSystem.Utilities
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return Convert(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert(value, parameter);
        }

        private object Convert(object value, object parameter)
        {
            if (null == parameter)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return !(bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
