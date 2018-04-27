using Aviation.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Aviation
{
    public class BizJetsLocalDBAccess
    {
        private SQLiteConnection database;

        public ObservableCollection<BizJetsLocal> BizJetsLocalCollection { get; set; }

        public BizJetsLocalDBAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<BizJetsLocal>();
            this.BizJetsLocalCollection = new ObservableCollection<BizJetsLocal>(database.Table<BizJetsLocal>());
        }

        // LINQ Get All
        public IEnumerable<BizJetsLocal> GetLocalBizJets()
        {
            var query = from bizjets in database.Table<BizJetsLocal>() select bizjets;
            return query.AsEnumerable();
        }

        // SQL Get All
        public IEnumerable<BizJetsLocal> GetLocalBizJetsAnotherWay()
        {   
            return database.Query<BizJetsLocal>("SELECT * FROM BizJetsLocal").AsEnumerable();
        }

        // Get
        public BizJetsLocal GetSpecificLocalBizJet(int BizJetID)
        {
            return database.Table<BizJetsLocal>().FirstOrDefault(BizJetsLocal => BizJetsLocal.AircraftID == BizJetID);
        }

        // Implement PUT/POST/DLETE

        public void SaveAllBizJetsLocally()
        {
            foreach (var bizJetInstance in this.BizJetsLocalCollection)
            {
                if (bizJetInstance.AircraftID != 0)
                {
                    database.Update(bizJetInstance);
                }
                else
                {
                    database.Insert(bizJetInstance);
                }
            }
        }
    }
}
