using EDRoutePlanner.SpanshApi.Data.Plotter;
using System.Linq;

namespace EDRoutePlanner.SpanshApi.Extensions.Plotter
{
    public static class ResultExtensions
    {
        public static int GetTotalJumps(this Result result)
            => result.Jumps.Select(jump => jump.Jumps).Sum();
    }
}
