using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using System.IO;
using Xamarin.Essentials;

namespace v6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Images : ContentPage
    {
        
        public byte[] resim1 = { };
        
        WebSocket ws = new WebSocket("ws://"+LoginUI.baglantilink+":65080");

        public Images(string wslink)
        {

            InitializeComponent();
            WebSocket ws = new WebSocket("ws://"+wslink+":65080");

            ws.Connect();
            ws.OnMessage += Ws_OnMessage;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            var stream1 = new MemoryStream(resim1);
            
            App.Current.Resources["foto"] = ImageSource.FromStream(() => stream1);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            
            ws.Connect();
            ws.OnMessage += Ws_OnMessage1;
        }



        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {

            resim1 = e.RawData;

            var stream1 = new MemoryStream(resim1);
            
          

        }
        private void Ws_OnMessage1(object sender, MessageEventArgs e)
        {

            resim1 = e.RawData;

            var stream1 = new MemoryStream(resim1);

            App.Current.Resources["foto"] = ImageSource.FromStream(() => stream1);


        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            ws.Close();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {

            Uri b = new Uri("https://api.thingspeak.com/update?api_key=9R96U5S5O9KSEGHV&field1=1");
            OpenBrowser(b);
        }
        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}