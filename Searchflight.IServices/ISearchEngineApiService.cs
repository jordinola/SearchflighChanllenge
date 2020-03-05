using Searchfight.Models.EnginesApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight.IServices
{
    public interface ISearchEngineApiService
    {
        BingApiResponse GetBingResult(string searchValue);
        GoogleApiResponse GetGoogleResult(string searchValue);
    }
}
