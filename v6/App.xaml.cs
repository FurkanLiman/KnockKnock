using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WebSocketSharp;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using Plugin.FirebasePushNotification;

namespace v6
{
    public partial class App : Application
    {
        public byte[] resim1;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginUI());
            //MainPage = new Images();

            CrossFirebasePushNotification.Current.Subscribe("all"); //Push Notification for All Devices and Types
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;


        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
