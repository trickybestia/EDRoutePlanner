using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using EDRoutePlanner.SpanshApi.Data.Plotter;
using EDRoutePlanner.SpanshApi.Extensions.Plotter;
using Newtonsoft.Json;

namespace EDRoutePlanner.SpanshApi
{
    public static class Plotter
    {
        private const string REQUEST_API_URL = "https://spansh.co.uk/api/route";
        private const string RESULT_API_URL = "https://spansh.co.uk/api/results/";

        public static async Task<Response> GetResponse(Request request)
        {
            string requestPath = $"{REQUEST_API_URL}{request.ToQuery()}";
            JobQueueingResponse jobQueueingResponse;
            HttpWebRequest jobQueueingRequest = HttpWebRequest.CreateHttp(requestPath);
            using (var response = await jobQueueingRequest.GetResponseAsync())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                string responseJson = await reader.ReadToEndAsync();
                jobQueueingResponse = JsonConvert.DeserializeObject<JobQueueingResponse>(responseJson);
            }
            Response mainResponse = null;
            do
            {
                HttpWebRequest resultRequest = HttpWebRequest.CreateHttp($"{RESULT_API_URL}{jobQueueingResponse.Job.ToString().ToUpper()}");
                using (var response = await resultRequest.GetResponseAsync())
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    string responseJson = await reader.ReadToEndAsync();
                    mainResponse = JsonConvert.DeserializeObject<Response>(responseJson);
                }
                if (mainResponse.Status == "queued")
                    await Task.Delay(100);
            } while (mainResponse.Status == "queued");
            return mainResponse;
        }
        public static Task<Response> GetOptimalRoute(string sourceSystem, string destinationSystem, int range, IProgress<int> progress = null)
        {
            Task<Response>[] responses = new Task<Response>[100];
            int progressPercent = 0;
            for (int i = 0; i < 100; i++)
            {
                responses[i] = GetResponse(new Request(range, i + 1, sourceSystem, destinationSystem));
                if (progress is not null)
                {
                    responses[i].ContinueWith(response =>
                    {
                        progress.Report(++progressPercent);
                    });
                }
            }
            Task.WaitAll(responses);
            Response optimalRoute = null;
            for (int i = 0; i < responses.Length; i++)
            {

                Response response = responses[i].Result;
                if (optimalRoute is null || response.Result.GetTotalJumps() < optimalRoute.Result.GetTotalJumps())
                    optimalRoute = response;
            }
            return Task.FromResult(optimalRoute);
        }
    }
}
