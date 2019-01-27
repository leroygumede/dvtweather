using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DVTWeather.Models
{
    public class ServiceCurrentResult
    {
        public Coord coord { get; set; }
        public IList<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
