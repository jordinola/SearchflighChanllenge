using Searchflight.Models;
using Searchflight.Models.EnginesApiResponses;

namespace Searchflight.IServices.SearchEnginesMappers
{
    public interface ISearchEngineMatchMapper
    {
        SearchEngineMatch MapFromBingSearchEngineResponse(BingApiResponse entity);
        SearchEngineMatch MapFromGoogleSearchEngineResponse(GoogleApiResponse entity);
    }
}
