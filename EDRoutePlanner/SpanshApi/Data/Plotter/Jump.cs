using Newtonsoft.Json;

namespace EDRoutePlanner.SpanshApi.Data.Plotter
{
    public class Jump
    {
        [JsonProperty("distance_jumped")]
        public double Distance { get; set; }
        [JsonProperty("distance_left")]
        public double DistanceLeft { get; set; }
        [JsonProperty("id64")]
        public ulong Id { get; set; }
        [JsonProperty("jumps")]
        public int Jumps { get; set; }
        [JsonProperty("neutron_star")]
        public bool IsNeutronStar { get; set; }
        [JsonProperty("system")]
        public string SystemName { get; set; }
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonProperty("z")]
        public double Z { get; set; }
    }
}
