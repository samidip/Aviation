using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Telerik.Everlive.Sdk.Core;
using Xamarin.Forms;

namespace Aviation
{
	public class BizJetsViewModel
	{
		private string BSAppId = "lmplloffsq4t2dgt";
		private EverliveApp ELHandle;

		public ObservableCollection<BizJets> BizJetsCollection { get; set; }

		public BizJetsViewModel()
		{
			EverliveAppSettings appSettings = new EverliveAppSettings() { AppId = BSAppId, UseHttps = true };
			ELHandle = new EverliveApp(appSettings);
		}

		public async Task<ObservableCollection<BizJets>> GetAllBizJets()
		{
			BizJetsCollection = new ObservableCollection<BizJets>();

			if (Application.Current.Properties.ContainsKey("BizJetsCollection"))
			{
				BizJetsCollection = Application.Current.Properties["BizJetsCollection"] as ObservableCollection<BizJets>;
				return BizJetsCollection;
		    }
			 else
			{
				var bizJetsManager = ELHandle.WorkWith().Data<BizJets>();
				var allBizJets = await bizJetsManager.GetAll().ExecuteAsync();

				foreach (BizJets serializedBizJet in allBizJets)
				{
					BizJetsCollection.Add(serializedBizJet);
				}

				Application.Current.Properties["BizJetsCollection"] = BizJetsCollection;
				return BizJetsCollection;
		    }
		}
	}
}
