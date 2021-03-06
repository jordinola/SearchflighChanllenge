﻿using Searchfight.IServices;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly IBingApiResultService _bingApiResultService;
        private readonly IGoogleApiResultService _googleApiResultService;

        public SearchEngineService(IBingApiResultService bingApiResultService, IGoogleApiResultService googleApiResultService)
        {
            _bingApiResultService = bingApiResultService;
            _googleApiResultService = googleApiResultService;
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

            searchResult.TotalWinner = GetTotalWinner(searchResult);

            return searchResult;
        }

        private IList<SearchEngineResult> SearchValues(IList<string> values)
        {
            var searchEngineValueResults = new List<SearchEngineResult>();
            SearchEngineResult searchEngineValueResult;

            for (int i = 0; i < values.Count; i++)
            {
                var searchValue = values[i].TrimStart().TrimEnd();

                searchEngineValueResult = new SearchEngineResult
                {
                    SearchValue = searchValue,
                    SearchMatchResults = new List<SearchEngineMatch> {
                        _bingApiResultService.GetSearchEngineMatch(searchValue),
                        _googleApiResultService.GetSearchEngineMatch(searchValue)
                    }
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
                    if (searchResult.SearchEngineValueResults[i].SearchMatchResults[j].SearchEngineName == searchEngine 
                        && searchResult.SearchEngineValueResults[i].SearchMatchResults[j].NumberMatches > GetMatchBySearchEngine(searchEngine, maxResult.SearchMatchResults).NumberMatches)
                    {
                            maxResult = searchResult.SearchEngineValueResults[i];
                    }
                }
            }

            return maxResult.SearchValue;
        }

        private SearchEngineMatch GetMatchBySearchEngine(string searchEngine, IList<SearchEngineMatch> searchEngineMatchResults)
        {
            return searchEngineMatchResults.Where(x => x.SearchEngineName == searchEngine).ToList()[0];
        }

        private string GetTotalWinner(SearchResult searchResult)
        {
            var totalWinner = searchResult.SearchEngineValueResults.Aggregate((i1, i2) => i1.TotalMatches > i2.TotalMatches ? i1 : i2);

            return totalWinner.SearchValue;
        }
    }
}
