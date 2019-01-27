using System;
using System.Globalization;
using Xamarin.Forms;

namespace DVTWeather.Converters
{
    public class BackgroundImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int code = (int)value;
                switch (code)
                {
                    case int n when (n >= 200 && n <= 232):
                        return "forest_rainy.png";
                    case int n when (n >= 300 && n <= 531):
                        return "forest_rainy.png";
                    case int n when (n >= 500 && n <= 531):
                        return "forest_rainy.png";
                    case int n when (n >= 600 && n <= 622):
                        return "forest_rainy.png";
                    case int n when (n >= 701 && n <= 781):
                        return "forest_rainy.png";
                    case 800:
                        return "forest_sunny.png";
                    case int n when (n >= 801 && n <= 804):
                        return "forest_cloudy.png";
                    default:
                        return "forest_rainy.png";
                }
            }
            return "forest_rainy.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}