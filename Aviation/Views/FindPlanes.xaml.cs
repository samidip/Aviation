using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Net.Http;

namespace Aviation.Views
{
    public partial class FindPlanes : ContentPage
    {
        private const string AzureFunctionsURL = "https://aviationfunction.azurewebsites.net/api/findplanes/airport/{airport}?code=9VGSNvsObD2azgAshedaNaxVgpxsdk08bLCnlpYNaiNzgwuguoCtGA==";
        private HttpClient Client = new HttpClient();

        private async void GoFindPlanes()
        {
            try
            {
                var cloudURL = AzureFunctionsURL.Replace("{airport}", this.Airport.Text);
                var functionResponse = await Client.GetStringAsync(cloudURL);
                this.AvailablePlanes.Text = functionResponse.ToString();
            }
            catch (Exception)
            {
                // Do stuff here.
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            GoFindPlanes();
        }

        public FindPlanes()
        {
            InitializeComponent();
        }
    }
}
