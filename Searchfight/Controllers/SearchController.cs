using Microsoft.AspNetCore.Mvc;
using Searchfight.IServices;
using System.Linq;

namespace Searchfight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchEngineService _searchEngineService;

        public SearchController(ISearchEngineService searchEngineService)
        {
            _searchEngineService = searchEngineService;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]string query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok();


            var searchValue = query.Split(',').ToList();

            return Ok(_searchEngineService.Search(searchValue));
        }
    }
}
