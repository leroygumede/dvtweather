using Xamarin.Essentials;

namespace DVTWeather.Helpers.Preference
{
    public class Preference : IPreference
    {
        public void ClearAllValues(string key)
        {
            Preferences.Clear();
        }

        public bool GetValue(string key)
        {
            var res = Preferences.Get(key, false);
            return res;
        }

        public bool RemoveValue(string key)
        {
            Preferences.Remove(key);
            return true;
        }

        public void SetValue(string key, bool value)
        {
            Preferences.Set(key, value);
        }
    }
}
