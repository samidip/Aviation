using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Telerik.Everlive.Sdk.Core;
using Xamarin.Forms;

namespace Aviation
{
	public class BizJetsViewModel
	{
		private string EverliveAppId = "lmplloffsq4t2dgt";
		private EverliveApp ELHandle;
        BizJetsLocalDBAccess localDBAccess = new BizJetsLocalDBAccess();

		public ObservableCollection<BizJets> BizJetsCollection { get; set; }

		public BizJetsViewModel()
		{
            EverliveAppSettings appSettings = new EverliveAppSettings() { AppId = EverliveAppId, UseHttps = true };
			ELHandle = new EverliveApp(appSettings);
		}

		public async Task<ObservableCollection<BizJets>> GetAllBizJets()
		{
			BizJetsCollection = new ObservableCollection<BizJets>();

            // Hydrate from local SQL DB:
            //if (localDBAccess.BizJetsLocalCollection.Count > 0)
            //{
            //    foreach (BizJetsLocal localBizJet in localDBAccess.BizJetsLocalCollection)
            //    {
            //        BizJets individualBizJet = new BizJets();
            //        individualBizJet.AircraftName = localBizJet.AircraftName;
            //        individualBizJet.AircraftCapacity = localBizJet.AircraftCapacity;
            //        individualBizJet.AircraftImageURL = localBizJet.AircraftImageURL;

            //        BizJetsCollection.Add(individualBizJet);
            //    }

            //    return BizJetsCollection;
            //}

            // Hydrate from Dictionary:
			if (Application.Current.Properties.ContainsKey("BizJetsCollection"))
			{
				BizJetsCollection = Application.Current.Properties["BizJetsCollection"] as ObservableCollection<BizJets>;
				return BizJetsCollection;
		    }

            // Fetch from Cloud:
			else
			{
				var bizJetsManager = ELHandle.WorkWith().Data<BizJets>();
				var allBizJets = await bizJetsManager.GetAll().ExecuteAsync();

				foreach (BizJets serializedBizJet in allBizJets)
				{
					BizJetsCollection.Add(serializedBizJet);

                    //BizJetsLocal bizJetsLocal = new BizJetsLocal();
                    //bizJetsLocal.AircraftName = serializedBizJet.AircraftName;
                    //bizJetsLocal.AircraftCapacity = serializedBizJet.AircraftCapacity;
                    //bizJetsLocal.AircraftImageURL = serializedBizJet.AircraftImageURL;

                    //localDBAccess.BizJetsLocalCollection.Add(bizJetsLocal);
				}

                // Stick into Dictionary:
				Application.Current.Properties["BizJetsCollection"] = BizJetsCollection;

                // Stick into SQL DB:
                //localDBAccess.SaveAllBizJetsLocally();

				return BizJetsCollection;
		    }
		}
	}
}
