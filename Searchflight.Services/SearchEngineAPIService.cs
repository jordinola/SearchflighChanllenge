﻿using Searchflight.IServices;
using Searchflight.IServices.SearchEnginesApiClients;
using Searchflight.Models.EnginesApiResponses;

namespace Searchflight.Services
{
    public class SearchEngineApiService : ISearchEngineApiService
    {
        private readonly IBingSearchEngineClient _bingSearchEngineClient;
        private readonly IGoogleSearchEngineClient _googleSearchEngineClient;

        public SearchEngineApiService(
            IBingSearchEngineClient bingSearchEngineClient,
            IGoogleSearchEngineClient googleSearchEngineClient)
        {
            _bingSearchEngineClient = bingSearchEngineClient;
            _googleSearchEngineClient = googleSearchEngineClient;
        }

        public BingApiResponse GetBingResult(string searchValue)
        {
            return _bingSearchEngineClient.Search(searchValue);
        }

        public GoogleApiResponse GetGoogleResult(string searchValue)
        {
            return _googleSearchEngineClient.Search(searchValue);
        }
    }
}
