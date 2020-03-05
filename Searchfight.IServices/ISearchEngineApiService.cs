using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.IServices
{
    public interface ISearchEngineApiService
    {
        BingApiResponse GetBingResult(string searchValue);
        GoogleApiResponse GetGoogleResult(string searchValue);
    }
}
