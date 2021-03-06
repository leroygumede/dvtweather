﻿using Prism;
using Prism.Ioc;
using DVTWeather.ViewModels;
using DVTWeather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Prism.Logging;
using DVTWeather.Services.Weather;
using DVTWeather.Services.Service;
using DVTWeather.Helpers.Connectivity;
using DVTWeather.Helpers.Geolocation;
using DVTWeather.Helpers.Preference;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DVTWeather
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Preference preference = new Preference();
            if (preference.GetValue("FirstTimeLoad") == true)
            {
                Debug.WriteLine("1");
                await NavigationService.NavigateAsync("SplashScreenPage");
                preference.SetValue("FirstTimeLoad", false);
            }
            else
            {
                Debug.WriteLine("2");
                await NavigationService.NavigateAsync("MainPage");
            }


        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.RegisterServices(containerRegistry);

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SplashScreenPage, SplashScreenPageViewModel>();

        }

        public void RegisterServices(IContainerRegistry container)
        {
            // Services
            container.RegisterSingleton<IWeather, Weather>();
            container.RegisterSingleton<IService, Services.Service.Services>();
            container.RegisterSingleton<IPreference, Preference>();

            // Xamarin Essentails
            container.RegisterSingleton<IConnectivity, Connectivity>();
            container.RegisterSingleton<IGeolocation, Geolocation>();
        }

        private void LogUnobservedTaskExceptions()
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Container.Resolve<ILoggerFacade>().Log(e.Exception.ToString(), Category.Exception, Priority.None);
            };
        }
    }
}
