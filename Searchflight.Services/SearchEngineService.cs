using Searchflight.IServices;
using Searchflight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchflight.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly ISearchEngineApiResultService _searchEngineResultService;

        public SearchEngineService(ISearchEngineApiResultService searchEngineResultService)
        {
            _searchEngineResultService = searchEngineResultService;
        }

        public SearchResult Search(IList<string> values)
        {
            var searchResult = new SearchResult
            {
                SearchEngineValueResults = SearchValues(values)
            };

            var engines = Enum.GetValues(typeof(SearchEngineTypeEnums));

            foreach (SearchEngineTypeEnums engine in engines)
            {
                var engineName = engine.ToString();
                searchResult.WinnerByEngine.Add(engineName, GetWinnerBySearchEngine(engineName, searchResult));
            }

            return searchResult;
        }

        private IList<SearchEngineResult> SearchValues(IList<string> values)
        {
            var searchEngineValueResults = new List<SearchEngineResult>();
            SearchEngineResult searchEngineValueResult;

            for (int i = 0; i < values.Count; i++)
            {
                searchEngineValueResult = new SearchEngineResult
                {
                    SearchValue = values[i],
                    SearchMatchResults = _searchEngineResultService.GetSearchEngineMatch(values[i])
                };

                searchEngineValueResults.Add(searchEngineValueResult);
            }

            return searchEngineValueResults;
        }

        private string GetWinnerBySearchEngine(string searchEngine, SearchResult searchResult)
        {
            var maxResult = searchResult.SearchEngineValueResults[0];

            for (int i = 1; i < searchResult.SearchEngineValueResults.Count; i++)
            {
                for (int j = 0; j < searchResult.SearchEngineValueResults[i].SearchMatchResults.Count; j++)
                {
                    if (searchResult.SearchEngineValueResults[i].SearchMatchResults[j].SearchEngineName == searchEngine)
                    {
                        if (searchResult.SearchEngineValueResults[i].SearchMatchResults[j].NumberMatches > GetMatchBySearchEngine(searchEngine, maxResult.SearchMatchResults).NumberMatches)
                        {
                            maxResult = searchResult.SearchEngineValueResults[i];
                        }
                    }
                }
            }

            return maxResult.SearchValue;
        }

        private SearchEngineMatch GetMatchBySearchEngine(string searchEngine, IList<SearchEngineMatch> searchEngineMatchResults)
        {
            return searchEngineMatchResults.Where(x => x.SearchEngineName == searchEngine).ToList()[0];
        }
    }
}
