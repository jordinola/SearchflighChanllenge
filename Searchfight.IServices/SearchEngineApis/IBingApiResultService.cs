using Searchfight.Models;

namespace Searchfight.IServices.SearchEngineApis
{
    public interface IBingApiResultService
    {
        SearchEngineMatch GetSearchEngineMatch(string searchValue);
    }
}
