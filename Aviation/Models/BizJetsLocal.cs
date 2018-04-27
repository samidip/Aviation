using System;
using SQLite;
using System.ComponentModel;

namespace Aviation
{
    [Table("BizJetsLocal")]
    public class BizJetsLocal : INotifyPropertyChanged
    {
        private int aircraftID;
        [PrimaryKey, AutoIncrement]
        public int AircraftID
        {
            get
            {
                return aircraftID;
            }
            set
            {
                this.aircraftID = value;
                OnPropertyChanged(nameof(aircraftID));
            }
        }

        private string aircraftName;
        public string AircraftName
        {
            get
            {
                return this.aircraftName;
            }
            set
            {
                this.aircraftName = value;
                this.OnPropertyChanged("AircraftName");
            }
        }

        private string aircraftCapacity;
        public string AircraftCapacity
        {
            get
            {
                return this.aircraftCapacity;
            }
            set
            {
                this.aircraftCapacity = value;
                this.OnPropertyChanged("AircraftCapacity");
            }
        }

        private string aircraftImageURL;
        public string AircraftImageURL
        {
            get
            {
                return this.aircraftImageURL;
            }
            set
            {
                this.aircraftImageURL = value;
                this.OnPropertyChanged("AircraftImageURL");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
