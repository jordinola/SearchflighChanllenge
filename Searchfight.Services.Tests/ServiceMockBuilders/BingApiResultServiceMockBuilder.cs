using Moq;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.Models;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class BingApiResultServiceMockBuilder
    {
        private Mock<IBingApiResultService> _bingApiResultServiceMockBuilder;

        public BingApiResultServiceMockBuilder()
        {
            _bingApiResultServiceMockBuilder = new Mock<IBingApiResultService>();
        }

        public BingApiResultServiceMockBuilder WithBingGetSearchEngineMatch()
        {
            _bingApiResultServiceMockBuilder.Setup(x => x.GetSearchEngineMatch(It.IsAny<string>()))
                .Returns(new SearchEngineMatch {
                    SearchEngineId = (int)SearchEngineTypeEnums.Bing,
                    SearchEngineName = SearchEngineTypeEnums.Bing.ToString(),
                    NumberMatches = 10000
                });

            return this;
        }

        public IBingApiResultService Build()
        {
            return _bingApiResultServiceMockBuilder.Object;
        }

    }
}
