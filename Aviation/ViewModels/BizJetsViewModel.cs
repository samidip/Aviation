using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kinvey;
using Xamarin.Forms;

namespace Aviation
{
	public class BizJetsViewModel
	{
        private Client kinveyClient;
        public ObservableCollection<BizJets> BizJetsCollection { get; set; }

        // BizJetsLocalDBAccess localDBAccess = new BizJetsLocalDBAccess();

		public BizJetsViewModel()
		{
            InitializeKinvey();
		}

        private void InitializeKinvey()
        {
            Client.Builder builder = new Client.Builder("kid_HJCU4YBfG", "4aa3242bed234dda91936ef12490cbc0")
                                    .setFilePath(DependencyService.Get<ISQLite>().GetPath())
                                    .setOfflinePlatform(DependencyService.Get<ISQLite>().GetConnection());

            kinveyClient = builder.Build();
            PingKinvey();
        }

        protected async void PingKinvey()
        {
            try
            {
                PingResponse response = await kinveyClient.PingAsync();
            }
            catch (Exception)
            {
                // Do some error handling.
            }
        }

        public async Task<ObservableCollection<BizJets>> GetAllBizJets()
        {
            BizJetsCollection = new ObservableCollection<BizJets>();

            // Hydrate from Dictionary:
            if (Application.Current.Properties.ContainsKey("BizJetsCollection"))
            {
                BizJetsCollection = Application.Current.Properties["BizJetsCollection"] as ObservableCollection<BizJets>;
                return BizJetsCollection;
            }

            // Hydrate from local SQL DB:
            //else
            //{
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
            //}

            // Fetch from cloud:
            else
            {
                DataStore<BizJets> dataStore = DataStore<BizJets>.Collection("BizJets", DataStoreType.NETWORK);
                List<BizJets> dataFromCloud = new List<BizJets>();
                User implicitUser = await User.LoginAsync();
                dataFromCloud = await dataStore.FindAsync();

                foreach (BizJets BizJetFromCloud in dataFromCloud)
                {
                    BizJets BizJetForCollection = new BizJets();
                    BizJetForCollection.AircraftName = BizJetFromCloud.AircraftName;
                    BizJetForCollection.AircraftCapacity = BizJetFromCloud.AircraftCapacity;
                    BizJetForCollection.AircraftImageURL = BizJetFromCloud.AircraftImageURL;

                    BizJetsCollection.Add(BizJetForCollection);
                }

                // Stick into Dictionary
                Application.Current.Properties["BizJetsCollection"] = BizJetsCollection;

                // Stick into SQL DB:
                //foreach (BizJets serializedBizJet in BizJetsCollection)
                //{
                        //BizJetsLocal bizJetsLocal = new BizJetsLocal();
                        //bizJetsLocal.AircraftName = serializedBizJet.AircraftName;
                        //bizJetsLocal.AircraftCapacity = serializedBizJet.AircraftCapacity;
                        //bizJetsLocal.AircraftImageURL = serializedBizJet.AircraftImageURL;

                        //localDBAccess.BizJetsLocalCollection.Add(bizJetsLocal);
                //}
                // localDBAccess.SaveAllBizJetsLocally();

                return BizJetsCollection;
            }
        }
		
	}
}









