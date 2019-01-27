﻿using System;
using System.Collections.Generic;

namespace DVTWeather.Models
{
    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public IList<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public DateTime dt_txt { get; set; }
    }
}
