using Newtonsoft.Json;

namespace EDRoutePlanner.SpanshApi.Data.Plotter
{
    public class Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
