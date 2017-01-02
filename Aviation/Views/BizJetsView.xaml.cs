using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Telerik.XamarinForms.DataControls.ListView;
using System.Threading.Tasks;

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
	}
}
