using System;

namespace Aviation
{
	public class BizJetsDetailViewModel
	{
		private static readonly BizJetsDetailViewModel SingletonBJDVM = new BizJetsDetailViewModel();
		private BizJets IndividualBizJet;

		private BizJetsDetailViewModel()
		{
		}

		public static void SetBJDViewModel(BizJets SelectedBizJet)
		{
			SingletonBJDVM.IndividualBizJet = SelectedBizJet;
		}

		public static BizJets GetIndividualBizJet()
		{
			return SingletonBJDVM.IndividualBizJet;
		}
	}
}
