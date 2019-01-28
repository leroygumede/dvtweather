using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVTWeather.Helpers.Connectivity;
using DVTWeather.Models;
using DVTWeather.Services.Service;
using System.Diagnostics;
using DVTWeather.Helpers;
using DVTWeather.Helpers.Geolocation;

namespace DVTWeather.Services.Weather
{
    public class Weather : IWeather
    {
        private readonly IConnectivity _connectivity;
        private readonly IService _service;
        private readonly IGeolocation _geolocation;

        public Weather(IConnectivity connectivity, IService service, IGeolocation geolocation)
        {
            _connectivity = connectivity;
            _service = service;
            _geolocation = geolocation;
        }

        public async Task<ServiceCurrentResult> GetCurrentWeather(bool RandomLocation = false)
        {
            try
            {
                if (_connectivity.IsConnected())
                {

                    var location = RandomLocation == true ? GetRandomLocation() : await GetUserLocation();

                    var payload = new { location.lat, location.lon };

                    var responseCalls = await _service.GetAsync<ServiceCurrentResult>("weather", payload);

                    return responseCalls;

                }

                return new ServiceCurrentResult();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public async Task<IList<List>> GetForecastWeather(bool RandomLocation = false)
        {
            try
            {
                if (_connectivity.IsConnected())
                {
                    var location = RandomLocation == true ? GetRandomLocation() : await GetUserLocation();

                    var payload = new { cnt = 5, location.lat, location.lon };
                    var responseCalls = await _service.GetAsync<ServiceForecastResult>("forecast", payload);

                    return responseCalls.list;

                }

                return new List<List>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public async Task<Coord> GetUserLocation()
        {
            return await _geolocation.GetLastKnownLocationAsync();
        }

        public Coord GetRandomLocation()
        {
            Random rnd = new Random();
            int item = rnd.Next(1, 4);

            switch (item)
            {
                case 1:
                    return new Coord { lat = -75.790250, lon = 56.025037 };
                case 2:
                    return new Coord { lat = 76.799427, lon = -41.633193 };
                case 3:
                    return new Coord { lat = 23.395228, lon = 27.407292 };
                case 4:
                    return new Coord { lat = -11.459757, lon = -58.263191 };
                default:
                    return new Coord { lat = -75.790250, lon = 56.025037 };
                    break;
            }
        }
    }
}
