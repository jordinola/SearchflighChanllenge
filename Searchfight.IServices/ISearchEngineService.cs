using Searchfight.Models;
using System.Collections.Generic;

namespace Searchfight.IServices
{
    public interface ISearchEngineService
    {
        SearchResult Search(IList<string> values);
    }
}
