namespace Searchflight.Models.EnginesApiResponses
{
    public class GoogleApiResponse
    {
        public SearchInformation SearchInformation { get; set; }
    }

    public class SearchInformation
    {
        public long TotalResults { get; set; }
    }
}
