using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Aviation.Views;
using Telerik.XamarinForms.DataControls.ListView;
using System.Threading.Tasks;

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

		private async void BizJetsList_RefreshRequested(object sender, PullToRefreshRequestedEventArgs e)
		{
			this.FetchViewData();
           
            await Task.Delay(5000);
			this.BizJetsList.EndRefresh();
		}

		private async void Book_BizJet(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new CustomerView());
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
