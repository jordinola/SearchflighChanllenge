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
        public ActionResult Get([FromQuery]string search)
        {
            if (string.IsNullOrEmpty(search))
                return Ok();


            var searchValue = search.Split(',').ToList();

            return Ok(_searchEngineService.Search(searchValue));
        }
    }
}
