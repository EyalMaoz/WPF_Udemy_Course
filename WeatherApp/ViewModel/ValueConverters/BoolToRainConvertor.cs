using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class BoolToRainConvertor : IValueConverter
    {
        private const string RAIN_MESSAGE = "Currently Raining";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return RAIN_MESSAGE;
            }
            return "Not Raining";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((string)value).Equals(RAIN_MESSAGE));
        }
    }
}
