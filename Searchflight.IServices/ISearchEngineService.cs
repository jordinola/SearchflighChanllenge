using Searchflight.Models;
using System.Collections.Generic;

namespace Searchflight.IServices
{
    public interface ISearchEngineService
    {
        SearchResult Search(IList<string> values);
    }
}
