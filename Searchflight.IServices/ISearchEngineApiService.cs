using Searchflight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchflight.IServices
{
    public interface ISearchEngineApiService
    {
        BingApiResponse GetBingResult(string searchValue);
        GoogleApiResponse GetGoogleResult(string searchValue);
    }
}
