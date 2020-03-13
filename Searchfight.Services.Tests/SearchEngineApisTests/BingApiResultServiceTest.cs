using FluentAssertions;
using NUnit.Framework;
using Searchfight.Models;
using Searchfight.Services.SearchEngineApis;
using Searchfight.Services.Tests.ServiceMockBuilders;

namespace Searchfight.Services.Tests.SearchEngineApisTests
{
    public class BingApiResultServiceTest
    {
        private BingApiResultService _service;
        private BingSearchEngineClientMockBuilder _bingSearchEngineClientMockBuilder;
        private SearchEngineMatchMapperMockBuilder _searchEngineMatchMapperMockBuilder;

        public BingApiResultServiceTest()
        {
            _bingSearchEngineClientMockBuilder = new BingSearchEngineClientMockBuilder();
            _searchEngineMatchMapperMockBuilder = new SearchEngineMatchMapperMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _service = new BingApiResultService(
                _bingSearchEngineClientMockBuilder.Build(), 
                _searchEngineMatchMapperMockBuilder.Build());
        }

        [Test]
        public void BingApiResultService_ValidValue_ReturnsBingSearchEngineMatch()
        {
            _bingSearchEngineClientMockBuilder.WithSearch();
            _searchEngineMatchMapperMockBuilder.WithMapBingSearchEngineRespone();

            var result = _service.GetSearchEngineMatch("query");

            result.SearchEngineId.Should().Be((int)SearchEngineTypeEnums.Bing);
        }

    }
}
