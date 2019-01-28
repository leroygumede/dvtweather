using System;
using DVTWeather.Models;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Prism.Services;
using System.Diagnostics;

namespace DVTWeather.Helpers.Geolocation
{
    public class Geolocation : IGeolocation
    {
        protected IPageDialogService _pageDialogService { get; set; }

        public Geolocation(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }
        public async Task<Coord> GetLastKnownLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return new Coord()
                    {
                        lat = location.Latitude,
                        lon = location.Longitude
                    };
                }
                throw new FeatureNotSupportedException();

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return await GetLocationAsync();
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions", "Please enable location permission to continue", "ok");
                Debug.WriteLine(fneEx);
                return new Coord();
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions", "Please enable location permission to continue", "ok");
                Debug.WriteLine(pEx);
                return new Coord();
                // Handle permission exception
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Location", "There was an error trying to fetch location, Please try again later", "ok");
                Debug.WriteLine(ex);
                return new Coord();
                // Unable to get location
            }
        }

        public async Task<Coord> GetLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return new Coord()
                    {
                        lat = location.Latitude,
                        lon = location.Longitude
                    };
                }
                throw new FeatureNotSupportedException();

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return await GetLocationAsync();
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions", "Please enable location permission to continue", "ok");
                Debug.WriteLine(fneEx);
                return new Coord();
            }
            catch (PermissionException pEx)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions", "Please enable location permission to continue", "ok");
                Debug.WriteLine(pEx);
                return new Coord();
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Location", "There was an error trying to fetch location, Please try again later", "ok");
                Debug.WriteLine(ex);
                return new Coord();
            }
        }
    }
}
