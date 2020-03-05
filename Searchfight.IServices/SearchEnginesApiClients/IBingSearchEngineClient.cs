using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.IServices.SearchEnginesApiClients
{
    public interface IBingSearchEngineClient
    {
        public BingApiResponse Search(string searchValue);
    }
}
