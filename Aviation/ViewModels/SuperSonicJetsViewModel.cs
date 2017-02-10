using System;
using System.Collections.Generic;

namespace Aviation
{
	public class SuperSonicJetsViewModel
	{
		public List<SuperSonicJetData> JetDataSource;

		public SuperSonicJetsViewModel()
		{
			InitializeJetData();
		}

		private void InitializeJetData()
		{
			JetDataSource = new List<SuperSonicJetData>()
			{
				new SuperSonicJetData("SU-27",2.35),
				new SuperSonicJetData("F-15",2.6),
				new SuperSonicJetData("XB-70",3),
				new SuperSonicJetData("MiG-25",3.2),
				new SuperSonicJetData("SR-71",3.5)
			};
		}
	}

	public class SuperSonicJetData
	{
		public string JetName { get; set; }
		public double JetMaxSpeed { get; set; }

		public SuperSonicJetData(string Name, double MaxSpeed)
		{
			this.JetName = Name;
			this.JetMaxSpeed = MaxSpeed;
		}
	}
}
