using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PruebaXamarinFroms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PruebaXamarinFroms.MainPage();
            MainPage.Padding = Device.OnPlatform<Thickness>(                
                new Thickness(0,20,0,0),
                new Thickness(0,0,0,0),
                new Thickness(0,20,0,0)
                );
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
