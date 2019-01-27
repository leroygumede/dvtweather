using System.Collections.Generic;

namespace DVTWeather.Models
{
    public class ServiceForecastResult
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public IList<List> list { get; set; }
        public City city { get; set; }
    }
}
