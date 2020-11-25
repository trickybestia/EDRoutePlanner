using Newtonsoft.Json;
using System;

namespace EDRoutePlanner.SpanshApi.Data.Plotter
{
    internal class JobQueueingResponse
    {
        [JsonProperty("job")]
        public Guid Job { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
