using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aviation
{
	public partial class ImagePage : ContentPage
	{
		public ImagePage()
		{
			InitializeComponent();

			BizJets IndividualBizJet = BizJetsDetailViewModel.GetIndividualBizJet();

			BizJetName.Text = IndividualBizJet.AircraftName;
			BizJetImage.Source = new UriImageSource
			{
				Uri = new Uri(IndividualBizJet.AircraftImageURL),
				CachingEnabled = true,
				CacheValidity = new TimeSpan(5, 0, 0, 0)
			};

		}
	}
}
