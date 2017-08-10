using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Telerik.XamarinForms.DataControls.ListView;
using Aviation.Views;

namespace Aviation
{
	public partial class HomeView : ContentPage
	{
		BizJetsViewModel BZVM;

		public HomeView()
		{
			InitializeComponent();

			BZVM = new BizJetsViewModel();
			this.FetchViewData();
		}

		private async void FetchViewData()
		{
			await BZVM.GetAllBizJets();
			this.BizJetsList.ItemsSource = BZVM.BizJetsCollection;
		}

		async void BizJet_Selected(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
		{
			BizJets selectedBizJet = (BizJets)e.Item;

			await Navigation.PushAsync(new BizJetDetailView(selectedBizJet));
		}

		private void BizJetsList_RefreshRequested(object sender, PullToRefreshRequestedEventArgs e)
		{
			this.FetchViewData();
			this.BizJetsList.EndRefresh();
		}

		private async void Book_BizJet(object sender, EventArgs e)
		{
			try
			{
				var locator = Plugin.Geolocator.CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;

				var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
				if (position == null)
					return;

                var answer = await DisplayAlert("Select Airport?", "Would you like to fly out from near (" + position.Latitude + "," + position.Longitude + ")", "Yes", "No");
			}
            catch (Exception)
			{
				// Catch exceptions here.
			}
		}

		private void BizJetsList_LoadOnDemand(object sender, EventArgs e)
		{
			BizJets lodBizJet = new BizJets();
			lodBizJet.AircraftName = "Load on Demand Aircraft";
			lodBizJet.AircraftCapacity = "N/A";
			(this.BizJetsList.ItemsSource as ObservableCollection<BizJets>).Add(lodBizJet);
		}

		async void SpeedCheck_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SpeedView());
		}

		async void SupersonicJet_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SuperSonicJets());
		}

		async void SupersonicSpeed_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SpeedSeries());
		}

		void BizJet_Clicked(object sender, System.EventArgs e)
		{
			this.HomeDrawer.IsOpen = false;
		}
	}
}
