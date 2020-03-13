using FluentAssertions;
using NUnit.Framework;
using Searchfight.Models;
using Searchfight.Services.SearchEngineApis;
using Searchfight.Services.Tests.ServiceMockBuilders;

namespace Searchfight.Services.Tests.SearchEngineApisTests
{
    public class GoogleApiResultServiceTest
    {
        private GoogleApiResultService _service;
        private GoogleSearchEngineClientMockBuilder _googleSearchEngineClientMockBuilder;
        private SearchEngineMatchMapperMockBuilder _searchEngineMatchMapperMockBuilder;

        public GoogleApiResultServiceTest()
        {
            _googleSearchEngineClientMockBuilder = new GoogleSearchEngineClientMockBuilder();
            _searchEngineMatchMapperMockBuilder = new SearchEngineMatchMapperMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _service = new GoogleApiResultService(
                _googleSearchEngineClientMockBuilder.Build(),
                _searchEngineMatchMapperMockBuilder.Build());
        }

        [Test]
        public void BingApiResultService_ValidValue_ReturnsGoogleSearchEngineMatch()
        {
            _googleSearchEngineClientMockBuilder.WithSearch();
            _searchEngineMatchMapperMockBuilder.WithMapGoogleSearchEngineRespone();

            var result = _service.GetSearchEngineMatch("query");

            result.SearchEngineId.Should().Be((int)SearchEngineTypeEnums.Google);
        }
    }
}
