using System.Collections.Generic;

namespace Searchflight.Models
{
    public class SearchResult
    {
        public SearchResult()
        {
            WinnerByEngine = new Dictionary<string, string>();
            SearchEngineValueResults = new List<SearchEngineResult>();
        }

        public string TotalWinner { get; set; }
        public Dictionary<string, string> WinnerByEngine { get; set; }
        public IList<SearchEngineResult> SearchEngineValueResults { get; set; }
    }
}
