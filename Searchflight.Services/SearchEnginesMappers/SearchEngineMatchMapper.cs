using Searchflight.IServices.SearchEnginesMappers;
using Searchflight.Models;
using Searchflight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchflight.Services.SearchEnginesMappers
{
    public class SearchEngineMatchMapper : ISearchEngineMatchMapper
    {
        public SearchEngineMatch MapFromBingSearchEngineResponse(BingApiResponse entity)
        {
            return new SearchEngineMatch
            {
                SearchEngineId = (int)SearchEngineTypeEnums.Bing,
                SearchEngineName = SearchEngineTypeEnums.Bing.ToString(),
                NumberMatches = entity?.WebPages?.TotalEstimatedMatches
            };
        }

        public SearchEngineMatch MapFromGoogleSearchEngineResponse(GoogleApiResponse entity)
        {
            return new SearchEngineMatch
            {
                SearchEngineId = (int)SearchEngineTypeEnums.Google,
                SearchEngineName = SearchEngineTypeEnums.Google.ToString(),
                NumberMatches = entity?.SearchInformation?.TotalResults
            };
        }
    }
}
