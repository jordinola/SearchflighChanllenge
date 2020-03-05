using Searchflight.Models.EnginesApiResponses;

namespace Searchflight.IServices.SearchEnginesApiClients
{
    public interface IGoogleSearchEngineClient
    {
        public GoogleApiResponse Search(string searchValue);
    }
}
