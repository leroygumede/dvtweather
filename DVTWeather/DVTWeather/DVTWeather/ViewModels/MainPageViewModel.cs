using Prism.Navigation;
using DVTWeather.Services.Weather;
using System.Threading.Tasks;
using DVTWeather.Models;
using System.Collections.ObjectModel;
using Prism.Services;
using DVTWeather.Helpers.Connectivity;
using System.Collections.Generic;
using System.Diagnostics;
using Prism.Commands;

namespace DVTWeather.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IWeather _weather;
        private readonly IConnectivity _connectivity;
        public DelegateCommand GenerateRandomLocation { get; set; }

        public ServiceCurrentResult CurrentConditions { get; set; }
        public ObservableCollection<List> ForeCastConditions { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IConnectivity connectivity, IWeather weather)
            : base(navigationService, pageDialogService)
        {
            _weather = weather;
            _connectivity = connectivity;

            NoInternet();

            GenerateRandomLocation = new DelegateCommand(async () => await GetWeatherConditions(true));

        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

            await GetWeatherConditions();
        }

        public async Task GetWeatherConditions(bool GenerateLocation = false)
        {
            try
            {
                if (_connectivity.IsConnected())
                {
                    var CurrentResult = await _weather.GetCurrentWeather(GenerateLocation);

                    if (CurrentResult != null)
                    {
                        CurrentConditions = CurrentResult;
                    }
                    else
                    {
                        await _pageDialogService.DisplayAlertAsync("Error", "Unable to fetch Current Location, please make sure location is enabled", "OK");
                        NoInternet();
                    }

                    var ForeCastResult = await _weather.GetForecastWeather(GenerateLocation);
                    if (ForeCastResult != null)
                    {
                        ForeCastConditions = new ObservableCollection<List>(ForeCastResult);
                    }
                    else
                    {
                        await _pageDialogService.DisplayAlertAsync("Error", "Unable to fetch forecast , please make sure location is enabled", "OK");
                        NoInternet();
                    }
                }
                else
                {
                    await Task.Delay(100);
                    await _pageDialogService.DisplayAlertAsync("Internet", "Please enable internet and restart app to continue", "OK");
                    NoInternet();
                }
            }
            catch (System.Exception ex)
            {
                await Task.Delay(100);
                Debug.WriteLine(ex);
                await _pageDialogService.DisplayAlertAsync("Internet", "Unknow error, please try again later", "OK");
                NoInternet();
            }

        }

        public void NoInternet()
        {
            CurrentConditions = new ServiceCurrentResult
            {
                weather = new List<Models.Weather>()
                    {
                        new Models.Weather(){
                        id = 500
                        }
                    },
                main = new Main
                {
                    temp = 0
                }
            };
        }
    }
}
