using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;
using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.Services.SearchEnginesMappers
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
