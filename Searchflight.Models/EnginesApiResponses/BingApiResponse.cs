namespace Searchfight.Models.EnginesApiResponses
{
    public class BingApiResponse
    {
        public WebPages WebPages { get; set; }
    }

    public class WebPages
    {
        public long TotalEstimatedMatches { get; set; }
    }
}
