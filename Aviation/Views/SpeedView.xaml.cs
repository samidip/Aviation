using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aviation
{
	public partial class SpeedView : ContentPage
	{
		public SpeedView()
		{
			InitializeComponent();
			VMDataBinding();
		}

		private void VMDataBinding()
		{
			SpeedViewModel SVM = new SpeedViewModel();
			this.autoCompleteSearchBox.ItemsSource = SVM.JetDataSource;
		}

		void SpeedButton_CLicked(object sender, System.EventArgs e)
		{
			JetData IndividualJet = null;

			if (this.autoCompleteSearchBox.Tokens != null)
			{
				foreach (JetData SelectedJet in this.autoCompleteSearchBox.Tokens)
				{
					if (SelectedJet != null)
					{
						IndividualJet = SelectedJet;
						break;
					}
				}

				if (IndividualJet != null)
				{
					this.SpeedIndicator.Value = IndividualJet.JetMaxSpeed;
				}
			}
		}
	}
}
