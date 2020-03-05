using Microsoft.Extensions.Configuration;
using RestSharp;
using Searchflight.IServices.SearchEnginesApiClients;
using Searchflight.Models.EnginesApiResponses;

namespace Searchflight.Services.SearchEnginesApiClients
{
    public class GoogleSearchEngineClient : RestClient, IGoogleSearchEngineClient
    {
        private readonly IConfiguration _configuration;

        public GoogleSearchEngineClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GoogleApiResponse Search(string searchValue)
        {
            var request = new RestRequest($"https://www.googleapis.com/customsearch/v1", Method.GET);
            request.AddQueryParameter("key", _configuration["ApiKeys:GoogleApiKey"]);
            request.AddQueryParameter("cx", _configuration["ApiKeys:GoogleCx"]);
            request.AddQueryParameter("q", searchValue);

            var response = Execute<GoogleApiResponse>(request);
            var result = new GoogleApiResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                result = response.Data;

            return result;
        }
    }
}
