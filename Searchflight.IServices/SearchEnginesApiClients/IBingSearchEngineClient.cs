using Searchflight.Models.EnginesApiResponses;

namespace Searchflight.IServices.SearchEnginesApiClients
{
    public interface IBingSearchEngineClient
    {
        public BingApiResponse Search(string searchValue);
    }
}
