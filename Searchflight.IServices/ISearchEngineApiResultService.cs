using Searchflight.Models;
using System.Collections.Generic;

namespace Searchflight.IServices
{
    public interface ISearchEngineApiResultService
    {
        IList<SearchEngineMatch> GetSearchEngineMatch(string searchValue);
    }
}
