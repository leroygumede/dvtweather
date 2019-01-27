using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVTWeather.Models;

namespace DVTWeather.Services.Weather
{
    public interface IWeather
    {
        Task<IList<List>> GetWeather();
    }
}
