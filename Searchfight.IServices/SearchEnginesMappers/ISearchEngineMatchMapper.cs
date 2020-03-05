using Searchfight.Models;
using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.IServices.SearchEnginesMappers
{
    public interface ISearchEngineMatchMapper
    {
        SearchEngineMatch MapFromBingSearchEngineResponse(BingApiResponse entity);
        SearchEngineMatch MapFromGoogleSearchEngineResponse(GoogleApiResponse entity);
    }
}
