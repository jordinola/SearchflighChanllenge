using Searchfight.IServices;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;

namespace Searchfight.Services.SearchEngineApis
{
    public class GoogleApiResultService : IGoogleApiResultService
    {
        private readonly ISearchEngineApiService _searchEngineService;
        private readonly ISearchEngineMatchMapper _mapper;

        public GoogleApiResultService(
            ISearchEngineApiService searchEngineService,
            ISearchEngineMatchMapper searchEngineResultServiceMapper)
        {
            _searchEngineService = searchEngineService;
            _mapper = searchEngineResultServiceMapper;
        }

        public SearchEngineMatch GetSearchEngineMatch(string searchValue)
        {
            var googleSearchEngineResult = _searchEngineService.GetGoogleResult(searchValue);
            return _mapper.MapFromGoogleSearchEngineResponse(googleSearchEngineResult);
        }
    }
}
