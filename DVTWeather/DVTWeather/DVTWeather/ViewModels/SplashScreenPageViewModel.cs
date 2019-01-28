using Prism.Navigation;
using DVTWeather.Services.Weather;
using System.Diagnostics;
using System.Threading.Tasks;
using DVTWeather.Models;
using System.Collections.ObjectModel;
using DVTWeather.Helpers.Geolocation;
using Prism.Services;

namespace DVTWeather.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {
        private readonly IGeolocation _geolocation;

        public string Status { get; set; }

        public SplashScreenPageViewModel(INavigationService navigationService, IGeolocation geolocation, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            _geolocation = geolocation;

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                Status = "Fetching location...";
                var res = await _geolocation.GetLocationAsync();

                if (res != null)
                {
                    await _navigationService.NavigateAsync("MainPage");
                }
                else
                {
                    Status = "Unable to fetch location";
                }
            }
            catch (System.Exception ex)
            {
                Status = "Unable to fetch location";
                Debug.WriteLine(ex);
            }

        }
    }
}
