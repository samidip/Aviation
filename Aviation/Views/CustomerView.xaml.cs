using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Aviation.Views;

namespace Aviation
{
    public partial class CustomerView : ContentPage
    {
        CustomerViewModel CustomerVM;

        public CustomerView()
        {
            InitializeComponent();

            CustomerVM = new CustomerViewModel();
            this.CustomerDataForm.Source = CustomerVM.GetSelectedCustomer();

            this.GetClosestAirport();
        }

        private async void GetClosestAirport()
        {
            try
            {
                var locator = Plugin.Geolocator.CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                if (position == null)
                    return;

                var answer = await DisplayAlert("Closest Airport?", "Looks like your present location is (" + position.Latitude + "," + position.Longitude + ")", "Yes", "No");
            }
            catch (Exception)
            {
                // Do stuff.
            }
        }
    }
}
