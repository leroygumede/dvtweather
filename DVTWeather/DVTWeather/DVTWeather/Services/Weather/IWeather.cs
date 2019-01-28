using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVTWeather.Models;

namespace DVTWeather.Services.Weather
{
    public interface IWeather
    {
        Task<ServiceCurrentResult> GetCurrentWeather(bool RandomLocation = false);
        Task<IList<List>> GetForecastWeather(bool RandomLocation = false);
    }
}
