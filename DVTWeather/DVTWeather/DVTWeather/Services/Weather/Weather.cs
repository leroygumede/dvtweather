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

        public async Task<ServiceCurrentResult> GetCurrentWeather()
        {
            try
            {
                if (_connectivity.IsConnected())
                {

                    var location = await GetUserLocation();

                    var payload = new { location.lat, location.lon };

                    var responseCalls = await _service.GetAsync<ServiceCurrentResult>("weather", payload);

                    return responseCalls;

                }

                return new ServiceCurrentResult();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new ServiceCurrentResult();
            }
        }

        public async Task<IList<List>> GetForecastWeather()
        {
            try
            {
                if (_connectivity.IsConnected())
                {
                    var location = await GetUserLocation();

                    var payload = new { cnt = 5, location.lat, location.lon };
                    var responseCalls = await _service.GetAsync<ServiceForecastResult>("forecast", payload);

                    return responseCalls.list;

                }

                return new List<List>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<List>();
            }
        }

        public async Task<Coord> GetUserLocation()
        {
            return await _geolocation.GetLocationAsync();
        }
    }
}
