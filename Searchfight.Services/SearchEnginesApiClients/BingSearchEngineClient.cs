using Microsoft.Extensions.Configuration;
using RestSharp;
using Searchfight.IServices.Logger;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.Models.EnginesApiResponses;
using System;

namespace Searchfight.Services.SearchEnginesApiClients
{
    public class BingSearchEngineClient : RestClient, IBingSearchEngineClient
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceLogger _logger;

        public BingSearchEngineClient(IConfiguration configuration, IServiceLogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public BingApiResponse Search(string searchValue)
        {
            var url = $"https://jamesbingendpoint.cognitiveservices.azure.com/bing/v7.0/search";
            RestRequest request = new RestRequest(url, Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _configuration["ApiKeys:BingOcpApimSubscriptionKey"]);
            request.AddQueryParameter("q", searchValue);

            var response = Execute<BingApiResponse>(request);
            var result = new BingApiResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                result = response.Data;
            else
                _logger.LogRequestError(request, response);

            return result;
        }
    }
}