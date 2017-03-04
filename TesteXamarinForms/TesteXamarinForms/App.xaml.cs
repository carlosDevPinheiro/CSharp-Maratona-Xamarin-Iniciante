
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace TesteXamarinForms
{
    public partial class App : Application
    {
        private MainPage _mainPage;

        public App()
        {          

            InitializeComponent();

            _mainPage = new TesteXamarinForms.MainPage();
            MainPage = _mainPage;
        }

        protected override  void OnStart()
        {            
            _mainPage.Load();
        }
        #region Sem o uso do Http.Client
        //protected override async void OnStart()
        //{
        //    var client = new Services.Restclient();

        //    var json = client.Serialize();

        //    await MainPage.DisplayAlert("Json", json, "Ok");
        //} 
        #endregion

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
