using System;
using System.Globalization;
using Xamarin.Forms;

namespace DVTWeather.Converters
{
    public class WeatherColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int code = (int)value;
                switch (code)
                {
                    case int n when (n >= 200 && n <= 232):
                        return "#57575D";
                    case int n when (n >= 300 && n <= 531):
                        return "#57575D";
                    case int n when (n >= 500 && n <= 531):
                        return "#57575D";
                    case int n when (n >= 600 && n <= 622):
                        return "#57575D";
                    case int n when (n >= 701 && n <= 781):
                        return "#57575D";
                    case 800:
                        return "47AB2F";
                    case int n when (n >= 801 && n <= 804):
                        return "#54717A";
                    default:
                        return "#57575D";
                }
            }
            return "#57575D";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}