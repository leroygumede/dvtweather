using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DVTWeather.Services.Weather;
using System.Diagnostics;

namespace DVTWeather.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IWeather _weather;


        public MainPageViewModel(INavigationService navigationService, IWeather weather)
            : base(navigationService)
        {
            _weather = weather;


            Title = "Main Page";


        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var res = await _weather.GetWeather();
            Debug.WriteLine(res);
            foreach (var item in res)
            {
                Debug.WriteLine(item.clouds);
            }
        }


    }
}
