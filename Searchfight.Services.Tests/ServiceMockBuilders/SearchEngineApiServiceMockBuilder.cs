using Moq;
using Searchfight.IServices;
using Searchfight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class SearchEngineApiServiceMockBuilder
    {
        private readonly Mock<ISearchEngineApiService> _searchEngineApiService;

        public SearchEngineApiServiceMockBuilder()
        {
            _searchEngineApiService = new Mock<ISearchEngineApiService>();
        }

        public SearchEngineApiServiceMockBuilder WithGetBingResult()
        {
            _searchEngineApiService.Setup(x => x.GetBingResult(It.IsAny<string>()))
                .Returns(new BingApiResponse());

            return this;
        }

        public SearchEngineApiServiceMockBuilder WithGetGoogleResult()
        {
            _searchEngineApiService.Setup(x => x.GetGoogleResult(It.IsAny<string>()))
                .Returns(new GoogleApiResponse());

            return this;
        }

        public ISearchEngineApiService Build()
        {
            return _searchEngineApiService.Object;
        }
    }
}
