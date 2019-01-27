using Xamarin.Essentials;

namespace DVTWeather.Helpers.Connectivity
{
    public class Connectivity : IConnectivity
    {
        public bool IsConnected()
        {
            var current = Xamarin.Essentials.Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
    }
}
