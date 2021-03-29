using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiCallTask = ApiHelper.ApiCall("f76eb04f-dcbd-4b5a-82f8-ac0b28358088");
            var result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Console.WriteLine(jsonResponse["results"]);
        }
    }

    class ApiHelper
    {
        public static async Task<string> ApiCall(string apiKey)
        {
            RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
            RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}
