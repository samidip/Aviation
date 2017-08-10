using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aviation.Views
{
    public partial class SpeedSeries : ContentPage
    {
        public SpeedSeries()
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
