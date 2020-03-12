using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Models
{
    public class SearchResultOnly
    {
        public SearchResultOnly()
        {
            WinnerByEngine = new Dictionary<string, string>();
            MatchesByWord = new Dictionary<string, long?>();
        }

        public string TotalWinner { get; set; }
        public Dictionary<string, string> WinnerByEngine { get; set; }
        public Dictionary<string, long?> MatchesByWord { get; set; }
    }
}
