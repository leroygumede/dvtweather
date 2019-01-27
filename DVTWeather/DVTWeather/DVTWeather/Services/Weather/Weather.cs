using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DVTWeather.Helpers.Connectivity;
using DVTWeather.Models;
using DVTWeather.Services.Service;
using System.Diagnostics;

namespace DVTWeather.Services.Weather
{
    public class Weather : IWeather
    {
        private readonly IConnectivity _connectivity;
        private readonly IService _service;

        public Weather(IConnectivity connectivity, IService service)
        {
            _connectivity = connectivity;
            _service = service;
        }

        public async Task<IList<List>> GetWeather()
        {
            try
            {
                if (_connectivity.IsConnected())
                {
                    var responseCalls = await _service.GetAsync("forecast");

                    return responseCalls.list;

                }

                return new List<List>();
            }
            catch (Exception ex)
            {
                return new List<List>();
            }
        }
    }
}
