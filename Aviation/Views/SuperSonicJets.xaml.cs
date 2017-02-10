using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aviation
{
	public partial class SuperSonicJets : ContentPage
	{
		public SuperSonicJets()
		{
			InitializeComponent();
			VMDataBinding();
		}

		private void VMDataBinding()
		{
			SuperSonicJetsViewModel SSVM = new SuperSonicJetsViewModel();
			this.JetDataSeries.ItemsSource = SSVM.JetDataSource;
		}
	}
}
