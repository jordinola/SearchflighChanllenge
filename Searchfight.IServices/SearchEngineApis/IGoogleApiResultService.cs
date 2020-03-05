using Searchfight.Models;

namespace Searchfight.IServices.SearchEngineApis
{
    public interface IGoogleApiResultService
    {
        SearchEngineMatch GetSearchEngineMatch(string searchValue);
    }
}
