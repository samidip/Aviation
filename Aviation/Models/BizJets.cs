using System;
using Newtonsoft.Json;
using Kinvey;

namespace Aviation
{
    [JsonObject(MemberSerialization.OptIn)]	
    public class BizJets : Entity
	{
        [JsonProperty("AircraftName")]
        public string AircraftName { get; set; }

        [JsonProperty("AircraftCapacity")]
        public string AircraftCapacity { get; set; }

        [JsonProperty("AircraftImageURL")]
        public string AircraftImageURL { get; set; }
	}
}