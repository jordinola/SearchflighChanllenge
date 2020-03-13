using Searchfight.IServices.SearchEngineApis;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;

namespace Searchfight.Services.SearchEngineApis
{
    public class GoogleApiResultService : IGoogleApiResultService
    {
        private readonly IGoogleSearchEngineClient _googleSearchEngineClient;
        private readonly ISearchEngineMatchMapper _mapper;

        public GoogleApiResultService(
            IGoogleSearchEngineClient googleSearchEngineClient,
            ISearchEngineMatchMapper searchEngineResultServiceMapper)
        {
            _googleSearchEngineClient = googleSearchEngineClient;
            _mapper = searchEngineResultServiceMapper;
        }

        public SearchEngineMatch GetSearchEngineMatch(string searchValue)
        {
            var googleSearchEngineResult = _googleSearchEngineClient.Search(searchValue);
            return _mapper.MapFromGoogleSearchEngineResponse(googleSearchEngineResult);
        }
    }
}
