using FluentAssertions;
using NUnit.Framework;
using Searchfight.Services.Tests.ServiceMockBuilders;
using System.Collections.Generic;

namespace Searchfight.Services.Tests
{
    public class SearchEngineServiceTest
    {
        private SearchEngineService _service;
        private BingApiResultServiceMockBuilder _bingApiResultServiceMockBuilder;
        private GoogleApiResultServiceMockBuilder _googleApiResultServiceMockBuilder;

        public SearchEngineServiceTest()
        {
            _bingApiResultServiceMockBuilder = new BingApiResultServiceMockBuilder();
            _googleApiResultServiceMockBuilder = new GoogleApiResultServiceMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _service = new SearchEngineService(
                _bingApiResultServiceMockBuilder.Build(), 
                _googleApiResultServiceMockBuilder.Build());
        }

        [Test]
        public void GetResult_validValue_ReturnsSearchFightResult()
        {
            //Arrange
            _bingApiResultServiceMockBuilder.WithBingGetSearchEngineMatch();
            _googleApiResultServiceMockBuilder.WithGoogleGetSearchEngineMatch();

            //Action
            var result = _service.Search(new List<string> { "query1", "query2" });

            //Assert
            result.Should().NotBeNull();
        }
    }
}
