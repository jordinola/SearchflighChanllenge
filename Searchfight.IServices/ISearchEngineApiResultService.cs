using Searchfight.Models;
using System.Collections.Generic;

namespace Searchfight.IServices
{
    public interface ISearchEngineApiResultService
    {
        IList<SearchEngineMatch> GetSearchEngineMatch(string searchValue);
    }
}
