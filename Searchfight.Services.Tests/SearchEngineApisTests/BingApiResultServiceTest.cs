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
        private SearchEngineApiServiceMockBuilder _searchEngineApiServiceMockBuilder;
        private SearchEngineMatchMapperMockBuilder _searchEngineMatchMapperMockBuilder;

        public BingApiResultServiceTest()
        {
            _searchEngineApiServiceMockBuilder = new SearchEngineApiServiceMockBuilder();
            _searchEngineMatchMapperMockBuilder = new SearchEngineMatchMapperMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _service = new BingApiResultService(
                _searchEngineApiServiceMockBuilder.Build(), 
                _searchEngineMatchMapperMockBuilder.Build());
        }

        [Test]
        public void BingApiResultService_ValidValue_ReturnsBingSearchEngineMatch()
        {
            _searchEngineApiServiceMockBuilder.WithGetBingResult();
            _searchEngineMatchMapperMockBuilder.WithMapBingSearchEngineRespone();

            var result = _service.GetSearchEngineMatch("query");

            result.SearchEngineId.Should().Be((int)SearchEngineTypeEnums.Bing);
        }

    }
}
