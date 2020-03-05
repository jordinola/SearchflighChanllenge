using Searchfight.IServices;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services
{
    public class SearchEngineApiResultService : ISearchEngineApiResultService
    {
        private readonly ISearchEngineApiService _searchEngineService;
        private readonly ISearchEngineMatchMapper _mapper;

        public SearchEngineApiResultService(
            ISearchEngineApiService searchEngineService,
            ISearchEngineMatchMapper searchEngineResultServiceMapper)
        {
            _searchEngineService = searchEngineService;
            _mapper = searchEngineResultServiceMapper;
        }

        public IList<SearchEngineMatch> GetSearchEngineMatch(string searchValue)
        {
            var searchEngineResults = new List<SearchEngineMatch>();

            var bingSearchEngineResult = _searchEngineService.GetBingResult(searchValue);
            searchEngineResults.Add(_mapper.MapFromBingSearchEngineResponse(bingSearchEngineResult));

            var googleSearchEngineResult = _searchEngineService.GetGoogleResult(searchValue);
            searchEngineResults.Add(_mapper.MapFromGoogleSearchEngineResponse(googleSearchEngineResult));

            return searchEngineResults;
        }
    }
}
