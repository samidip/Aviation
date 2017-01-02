using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Telerik.Everlive.Sdk.Core;

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
			var bizJetsManager = ELHandle.WorkWith().Data<BizJets>();
			var allBizJets = await bizJetsManager.GetAll().ExecuteAsync();

			BizJetsCollection = new ObservableCollection<BizJets>();
			foreach (BizJets serializedBizJet in allBizJets)
			{
				BizJetsCollection.Add(serializedBizJet);
			}

			return BizJetsCollection;
		}
	}
}
