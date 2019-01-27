using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DVTWeather.Services.Weather;
using System.Diagnostics;
using System.Threading.Tasks;
using DVTWeather.Models;
using System.Collections.ObjectModel;

namespace DVTWeather.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IWeather _weather;

        public ServiceCurrentResult CurrentConditions { get; set; }
        public ObservableCollection<DVTWeather.Models.List> ForeCastConditions { get; set; }

        public MainPageViewModel(INavigationService navigationService, IWeather weather)
            : base(navigationService)
        {
            _weather = weather;

        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

            await GetWeatherConditions();
        }

        public async Task GetWeatherConditions()
        {
            CurrentConditions = await _weather.GetCurrentWeather();
            ForeCastConditions = new ObservableCollection<List>(await _weather.GetForecastWeather());


            Debug.WriteLine(ForeCastConditions);
        }
    }
}
