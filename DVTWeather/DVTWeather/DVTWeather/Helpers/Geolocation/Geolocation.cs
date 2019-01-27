using System;
using DVTWeather.Models;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace DVTWeather.Helpers.Geolocation
{
    public class Geolocation : IGeolocation
    {
        public Coord GetLastKnownLocationAsync()
        {
            throw new NotImplementedException();
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
                throw new FeatureNotSupportedException();
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                throw new FeatureNotSupportedException();
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                throw new PermissionException(pEx.Message);
                // Handle permission exception
            }
            catch (Exception ex)
            {
                throw new Exception();
                // Unable to get location
            }
        }
    }
}
