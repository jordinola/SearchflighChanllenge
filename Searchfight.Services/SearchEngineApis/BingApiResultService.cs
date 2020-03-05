using Searchfight.IServices;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;

namespace Searchfight.Services.SearchEngineApis
{
    public class BingApiResultService : IBingApiResultService
    {
        private readonly ISearchEngineApiService _searchEngineService;
        private readonly ISearchEngineMatchMapper _mapper;

        public BingApiResultService(
            ISearchEngineApiService searchEngineService,
            ISearchEngineMatchMapper searchEngineResultServiceMapper)
        {
            _searchEngineService = searchEngineService;
            _mapper = searchEngineResultServiceMapper;
        }

        public SearchEngineMatch GetSearchEngineMatch(string searchValue)
        {
            var bingSearchEngineResult = _searchEngineService.GetBingResult(searchValue);
            return _mapper.MapFromBingSearchEngineResponse(bingSearchEngineResult);
        }
    }
}
