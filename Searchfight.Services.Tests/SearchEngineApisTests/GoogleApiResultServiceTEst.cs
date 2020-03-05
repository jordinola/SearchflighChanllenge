using FluentAssertions;
using NUnit.Framework;
using Searchfight.Models;
using Searchfight.Services.SearchEngineApis;
using Searchfight.Services.Tests.ServiceMockBuilders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services.Tests.SearchEngineApisTests
{
    public class GoogleApiResultServiceTest
    {
        private GoogleApiResultService _service;
        private SearchEngineApiServiceMockBuilder _searchEngineApiServiceMockBuilder;
        private SearchEngineMatchMapperMockBuilder _searchEngineMatchMapperMockBuilder;

        public GoogleApiResultServiceTest()
        {
            _searchEngineApiServiceMockBuilder = new SearchEngineApiServiceMockBuilder();
            _searchEngineMatchMapperMockBuilder = new SearchEngineMatchMapperMockBuilder();
        }

        [SetUp]
        public void Setup()
        {
            _service = new GoogleApiResultService(
                _searchEngineApiServiceMockBuilder.Build(),
                _searchEngineMatchMapperMockBuilder.Build());
        }

        [Test]
        public void BingApiResultService_ValidValue_ReturnsGoogleSearchEngineMatch()
        {
            _searchEngineApiServiceMockBuilder.WithGetGoogleResult();
            _searchEngineMatchMapperMockBuilder.WithMapGoogleSearchEngineRespone();

            var result = _service.GetSearchEngineMatch("query");

            result.SearchEngineId.Should().Be((int)SearchEngineTypeEnums.Google);
        }
    }
}
