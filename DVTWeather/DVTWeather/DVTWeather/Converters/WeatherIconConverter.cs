using System;
using System.Globalization;
using Xamarin.Forms;

namespace DVTWeather.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int code = (int)value;
                switch (code)
                {
                    case int n when (n >= 200 && n <= 232):
                        return "rain.png";
                    case int n when (n >= 300 && n <= 531):
                        return "rain.png";
                    case int n when (n >= 500 && n <= 531):
                        return "rain.png";
                    case int n when (n >= 600 && n <= 622):
                        return "rain.png";
                    case int n when (n >= 701 && n <= 781):
                        return "rain.png";
                    case 800:
                        return "clear.png";
                    case int n when (n >= 801 && n <= 804):
                        return "partlysunny.png";
                    default:
                        return "rain.png";
                }
            }
            return "quickslippending.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}