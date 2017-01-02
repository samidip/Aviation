using System;
using Telerik.Everlive.Sdk.Core;

using Telerik.Everlive.Sdk.Core.Model.Base;
using Telerik.Everlive.Sdk.Core.Serialization;

namespace Aviation
{
	[ServerType("BizJets")]
	public class BizJets : DataItem
	{
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
	}
}