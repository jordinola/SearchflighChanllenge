using AutoMapper;
using Searchfight.Models;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Mappers
{
    public class SearchResultOnlyMapper : Profile
    {
        public SearchResultOnlyMapper()
        {
            CreateMap<SearchResult, SearchResultOnly>()
                .AfterMap((src, dest) =>
                {
                    foreach (var result in src.SearchEngineValueResults)
                    {
                        dest.MatchesByWord.Add(result.SearchValue, result.TotalMatches);
                    }
                });
        }
    }
}
