using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTest
{
  class Program
  {
    static void Main()
    {
      var apiCallTask = ApiHelper.ApiCall("addAPIkeyhere");
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