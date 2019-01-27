using System;
using System.Threading.Tasks;
using DVTWeather.Models;
namespace DVTWeather.Helpers.Geolocation
{
    public interface IGeolocation
    {
        // Fast way to get location
        Coord GetLastKnownLocationAsync();

        Task<Coord> GetLocationAsync();
    }
}
