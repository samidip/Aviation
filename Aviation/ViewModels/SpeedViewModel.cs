using System;
using System.Collections.Generic;

namespace Aviation
{
	public class SpeedViewModel
	{
		public List<JetData> JetDataSource;

		public SpeedViewModel()
		{
			InitializeJetData();
		}

		private void InitializeJetData()
		{
			JetDataSource = new List<JetData>()
			{
				new JetData("Boeing Business Jet",890),
				new JetData("Gulfstream V",965),
				new JetData("Citation X",1125),
				new JetData("Bombardier Challenger 604",882),
				new JetData("Embraer Legacy",834),
				new JetData("Bombardier Learjet 60",839),
				new JetData("Beech Jet 400A",866),
				new JetData("Hawker 800XP",829),
				new JetData("Citation V",932)
			};
		}
	}

	public class JetData
	{
		public string JetName { get; set; }
		public int JetMaxSpeed { get; set; }

		public JetData(string Name, int MaxSpeed)
		{
			this.JetName = Name;
			this.JetMaxSpeed = MaxSpeed;
		}
	}
}
