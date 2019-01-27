using System;
namespace DVTWeather.Helpers
{
    public class AppConstants
    {
        public enum Environment : int
        {
            Development,
            Staging,
            Live
        }


        // Open Weather API
        public const string AppId = "3ab05b811e3515fd93e4a506ca2b1752";

        public const string BaseUrl = "http://api.openweathermap.org/data/2.5/";
        public const string CountryId = "953987";
        public const string Units = "metric";


        // http://api.openweathermap.org/data/2.5/

    }
}
