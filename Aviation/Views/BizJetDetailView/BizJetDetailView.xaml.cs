using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aviation
{
	public partial class BizJetDetailView : TabbedPage
	{
		public BizJetDetailView()
		{
			InitializeComponent();
		}

		public BizJetDetailView(BizJets SelectedBizJet)
		{
			BizJetsDetailViewModel.SetBJDViewModel(SelectedBizJet);

			InitializeComponent();
		}
	}
}
