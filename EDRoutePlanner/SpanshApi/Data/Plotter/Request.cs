using System;

namespace EDRoutePlanner.SpanshApi.Data.Plotter
{
    public class Request
    {
        public int Range { get; }
        public int Efficiency { get; }
        public string SourceSystem { get; }
        public string DestinationSystem { get; }

        public Request(int range, int efficiency, string sourceSystem, string destinationSystem)
        {
            if (range <= 0)
                throw new ArgumentException($"{nameof(range)} must be greater than 0.");
            if (efficiency <= 0 || efficiency > 100)
                throw new ArgumentException($"{nameof(efficiency)} must be greater than 0 and lesser or equal to 100.");
            Range = range;
            Efficiency = efficiency;
            SourceSystem = sourceSystem.Replace(" ", "%20");
            DestinationSystem = destinationSystem.Replace(" ", "%20");
        }
        public string ToQuery()
            => $"?efficiency={Efficiency}&from={SourceSystem}&range={Range}&to={DestinationSystem}";
    }
}
