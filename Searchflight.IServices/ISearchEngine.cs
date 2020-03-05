using Searchflight.Models;
using System.Collections.Generic;

namespace Searchflight.IServices
{
    public interface ISearchEngine
    {
        SearchResult Search(IList<string> values);
    }
}
