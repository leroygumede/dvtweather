using System;
using System.Collections;
using System.Collections.Generic;

namespace DVTWeather.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public IList<IList> list { get; set; }
    }
}
