using System.Collections.Generic;

namespace Searchflight.Models
{
    public class SearchResult
    {
        public SearchResult()
        {
            SearchEngineValueResults = new List<SearchEngineResult>();
        }

        public string GoogleWinner { get; set; }
        public string BingWinner { get; set; }
        public string TotalWinner { get; set; }
        public IList<SearchEngineResult> SearchEngineValueResults { get; set; }
    }
}
