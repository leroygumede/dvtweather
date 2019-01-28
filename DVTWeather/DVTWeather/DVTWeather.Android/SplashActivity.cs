
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace DVTWeather.Droid
{
    [Activity(Label = "DVT",
              Icon = "@mipmap/ic_launcher",
              Theme = "@style/SplashTheme",
              MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(Application.Context, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}
