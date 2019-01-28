using System;
namespace DVTWeather.Helpers.Preference
{
    public interface IPreference
    {
        void SetValue(string key, bool value);
        bool GetValue(string key);
        bool RemoveValue(string key);
        void ClearAllValues(string key);
    }
}
