using Moq;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class BingSearchEngineClientMockBuilder
    {
        private readonly Mock<IBingSearchEngineClient> _bingSearchEngineClientMockBuilder;

        public BingSearchEngineClientMockBuilder()
        {
            _bingSearchEngineClientMockBuilder = new Mock<IBingSearchEngineClient>();
        }

        public BingSearchEngineClientMockBuilder WithSearch()
        {
            _bingSearchEngineClientMockBuilder.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(new BingApiResponse());

            return this;
        }

        public IBingSearchEngineClient Build()
        {
            return _bingSearchEngineClientMockBuilder.Object;
        }
    }
}
