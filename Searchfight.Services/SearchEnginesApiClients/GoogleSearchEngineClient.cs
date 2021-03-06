﻿using Microsoft.Extensions.Configuration;
using RestSharp;
using Searchfight.IServices.Logger;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.Services.SearchEnginesApiClients
{
    public class GoogleSearchEngineClient : RestClient, IGoogleSearchEngineClient
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceLogger _logger;

        public GoogleSearchEngineClient(IConfiguration configuration, IServiceLogger logger)
        {
            _configuration = configuration;
            _logger = logger;
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
            else
                _logger.LogRequestError(request, response);

            return result;
        }
    }
}
