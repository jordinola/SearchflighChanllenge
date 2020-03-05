using FluentAssertions;
using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.Tests.ServiceMockBuilders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services.Tests
{
    public class SearchEngineApiServiceTest
    {
        private SearchEngineApiService _searchEngineApiService;
        private BingSearchEngineClientMockBuilder _bingSearchEngineClientMockBuilder;
        private GoogleSearchEngineClientMockBuilder _googleSearchEngineClientMockBuilder;

        public SearchEngineApiServiceTest()
        {
            _bingSearchEngineClientMockBuilder = new BingSearchEngineClientMockBuilder();
            _googleSearchEngineClientMockBuilder = new GoogleSearchEngineClientMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _searchEngineApiService = new SearchEngineApiService(_bingSearchEngineClientMockBuilder.Build(), _googleSearchEngineClientMockBuilder.Build());
        }

        [Test]
        public void GetBingResult_ValidValue_ReturnBingSearchEngineResponse()
        {
            //Arrange
            _bingSearchEngineClientMockBuilder.WithSearch();

            //Action
            var result = _searchEngineApiService.GetBingResult("SearchValue");

            //Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void GetGoogleResult_ValidValue_GoogleSearchEngineResponse()
        {
            //Arrange
            _googleSearchEngineClientMockBuilder.WithSearch();

            //Action
            var result = _searchEngineApiService.GetGoogleResult("SearchValue");

            //Assert
            result.Should().NotBeNull();
        }
    }
}
