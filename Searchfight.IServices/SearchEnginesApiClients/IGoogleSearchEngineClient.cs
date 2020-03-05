using Searchfight.Models.EnginesApiResponses;

namespace Searchfight.IServices.SearchEnginesApiClients
{
    public interface IGoogleSearchEngineClient
    {
        public GoogleApiResponse Search(string searchValue);
    }
}
