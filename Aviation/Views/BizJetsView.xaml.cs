using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Telerik.XamarinForms.DataControls.ListView;


namespace Aviation
{
	public partial class BizJetsView : ContentPage
	{
		BizJetsViewModel BZVM;

		public BizJetsView()
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

		private void BizJet_Selected(object sender, ItemTapEventArgs e)
		{
			// Do stuff here.
		}

		private void BizJetsList_RefreshRequested(object sender, PullToRefreshRequestedEventArgs e)
		{
			this.FetchViewData();
			this.BizJetsList.EndRefresh();
		}

		void Book_BizJet(object sender, EventArgs e)
		{
			// Do stuff here.
		}

		private void BizJetsList_LoadOnDemand(object sender, EventArgs e)
		{
			BizJets lodBizJet = new BizJets();
			lodBizJet.AircraftName = "Load on Demand Aircraft";
			lodBizJet.AircraftCapacity = "N/A";
			(this.BizJetsList.ItemsSource as ObservableCollection<BizJets>).Add(lodBizJet);
		}
	}
}
