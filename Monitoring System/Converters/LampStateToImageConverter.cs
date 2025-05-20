using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Monitoring_System.Converters
{
    public class LampStateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool state)
            {
                return state ? "buttonon.png" : "buttonoff.png";
            }
            return "buttondie.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}