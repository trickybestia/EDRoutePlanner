using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EDRoutePlanner.SpanshApi.Data.Plotter
{
    public class Result
    {
        [JsonProperty("destination_system")]
        public string DestinationSystem { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("efficiency")]
        public int Efficiency { get; set; }
        [JsonProperty("job")]
        public Guid Job { get; set; }
        [JsonProperty("range")]
        public int Range { get; set; }
        [JsonProperty("source_system")]
        public string SourceSystem { get; set; }
        [JsonProperty("system_jumps")]
        public List<Jump> Jumps { get; set; }
        [JsonProperty("total_jumps")]
        public int JumpsCount { get; set; }
        [JsonProperty("via")]
        public List<object> Via { get; set; }
    }
}
