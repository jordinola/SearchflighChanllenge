using Moq;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class GoogleSearchEngineClientMockBuilder
    {
        private readonly Mock<IGoogleSearchEngineClient> _googleSearchEngineClientMockBuilder;

        public GoogleSearchEngineClientMockBuilder()
        {
            _googleSearchEngineClientMockBuilder = new Mock<IGoogleSearchEngineClient>();
        }

        public GoogleSearchEngineClientMockBuilder WithSearch()
        {
            _googleSearchEngineClientMockBuilder.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(new GoogleApiResponse());

            return this;
        }

        public IGoogleSearchEngineClient Build()
        {
            return _googleSearchEngineClientMockBuilder.Object;
        }
    }
}
