using Microsoft.Extensions.Configuration;
using RestSharp;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.Models.EnginesApiResponses;
using System;

namespace Searchfight.Services.SearchEnginesApiClients
{
    public class BingSearchEngineClient : RestClient, IBingSearchEngineClient
    {
        private readonly IConfiguration _configuration;

        public BingSearchEngineClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BingApiResponse Search(string searchValue)
        {
            RestRequest request = new RestRequest($"https://jamesbingendpoint.cognitiveservices.azure.com/bing/v7.0/search", Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _configuration["ApiKeys:BingOcpApimSubscriptionKey"]);
            request.AddQueryParameter("q", searchValue);

            var response = Execute<BingApiResponse>(request);
            var result = new BingApiResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                result = response.Data;

            return result;
        }
    }
}