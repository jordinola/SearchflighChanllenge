using Searchfight.IServices.SearchEngineApis;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;

namespace Searchfight.Services.SearchEngineApis
{
    public class BingApiResultService : IBingApiResultService
    {
        private readonly IBingSearchEngineClient _bingSearchEngineClient;
        private readonly ISearchEngineMatchMapper _mapper;

        public BingApiResultService(
            IBingSearchEngineClient bingSearchEngineClient,
            ISearchEngineMatchMapper searchEngineResultServiceMapper)
        {
            _bingSearchEngineClient = bingSearchEngineClient;
            _mapper = searchEngineResultServiceMapper;
        }

        public SearchEngineMatch GetSearchEngineMatch(string searchValue)
        {
            var bingSearchEngineResult = _bingSearchEngineClient.Search(searchValue);
            return _mapper.MapFromBingSearchEngineResponse(bingSearchEngineResult);
        }
    }
}
