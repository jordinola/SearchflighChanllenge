using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Models
{
    public class SearchEngineResult
    {
        public SearchEngineResult()
        {
            SearchMatchResults = new List<SearchEngineMatch>();
        }

        public string SearchValue { get; set; }
        public long? TotalMatches => SearchMatchResults.Select(x => x.NumberMatches).Sum();
        public IList<SearchEngineMatch> SearchMatchResults { get; set; }
    }
}
