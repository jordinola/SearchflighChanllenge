using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Deserializers;
using Searchflight.IServices.SearchEnginesApiClients;
using Searchflight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchflight.Services.SearchEnginesApiClients
{
    public class GoogleSearchEngineClient : RestClient, IGoogleSearchEngineClient
    {
        private readonly IConfiguration _configuration;

        public GoogleSearchEngineClient(IDeserializer serializer, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GoogleApiResponse Search(string searchValue)
        {
            var request = new RestRequest($"/customsearch/v1", Method.GET);
            request.AddQueryParameter("key", _configuration["googleKey"]);
            request.AddQueryParameter("cx", _configuration["googleCx"]);
            request.AddQueryParameter("q", searchValue);

            var response = Execute<GoogleApiResponse>(request);
            var result = new GoogleApiResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                result = response.Data;

            return result;
        }
    }
}
