using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DVTWeather.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SlideBackground();
        }

        public async void SlideBackground()
        {
            await CurrentBackground.ScaleTo(1.1, 40000, Easing.SinIn);
        }
    }
}