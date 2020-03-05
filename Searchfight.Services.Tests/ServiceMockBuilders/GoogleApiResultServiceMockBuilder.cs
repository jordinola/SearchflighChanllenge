using Moq;
using NUnit.Framework;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.Services.Tests.ServiceMockBuilders
{
    public class GoogleApiResultServiceMockBuilder
    {
        private Mock<IGoogleApiResultService> _googleApiResultServiceMockBuilder;

        public GoogleApiResultServiceMockBuilder()
        {
            _googleApiResultServiceMockBuilder = new Mock<IGoogleApiResultService>();
        }

        public GoogleApiResultServiceMockBuilder WithGoogleGetSearchEngineMatch()
        {
            _googleApiResultServiceMockBuilder.Setup(x => x.GetSearchEngineMatch(It.IsAny<string>()))
               .Returns(new SearchEngineMatch
               {
                   SearchEngineId = (int)SearchEngineTypeEnums.Google,
                   SearchEngineName = SearchEngineTypeEnums.Google.ToString(),
                   NumberMatches = 20000
               });

            return this;
        }

        public IGoogleApiResultService Build()
        {
            return _googleApiResultServiceMockBuilder.Object;
        }
    }
}
