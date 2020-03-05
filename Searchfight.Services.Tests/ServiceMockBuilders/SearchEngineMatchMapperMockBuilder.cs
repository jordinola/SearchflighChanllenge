using Moq;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Models;
using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class SearchEngineMatchMapperMockBuilder
    {
        private readonly Mock<ISearchEngineMatchMapper> _searchEngineMatchMapper;

        public SearchEngineMatchMapperMockBuilder()
        {
            _searchEngineMatchMapper = new Mock<ISearchEngineMatchMapper>();
        }

        public SearchEngineMatchMapperMockBuilder WithMapBingSearchEngineRespone()
        {
            _searchEngineMatchMapper.Setup(x => x.MapFromBingSearchEngineResponse(It.IsAny<BingApiResponse>()))
                .Returns(new SearchEngineMatch
                {
                    SearchEngineId = (int)SearchEngineTypeEnums.Bing,
                    SearchEngineName = SearchEngineTypeEnums.Bing.ToString(),
                    NumberMatches = 10000
                });

            return this;
        }

        public SearchEngineMatchMapperMockBuilder WithMapGoogleSearchEngineRespone()
        {
            _searchEngineMatchMapper.Setup(x => x.MapFromGoogleSearchEngineResponse(It.IsAny<GoogleApiResponse>()))
                .Returns(new SearchEngineMatch
                {
                    SearchEngineId = (int)SearchEngineTypeEnums.Google,
                    SearchEngineName = SearchEngineTypeEnums.Google.ToString(),
                    NumberMatches = 20000
                });

            return this;
        }

        public ISearchEngineMatchMapper Build()
        {
            return _searchEngineMatchMapper.Object;
        }
    }
}
