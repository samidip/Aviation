using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

using Aviation.Interfaces;
using Aviation.iOS;

[assembly: Dependency(typeof(DatabaseConnection_iOS))]

namespace Aviation.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public DatabaseConnection_iOS()
        {   
        }

        public SQLiteConnection DbConnection()
        {
            var dbName = "BizJetsDb.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
