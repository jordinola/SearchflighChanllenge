using Microsoft.AspNetCore.Mvc;
using Searchflight.IServices;
using System.Linq;

namespace Searchflight.Controllers
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
        public ActionResult Get([FromQuery]string programmingLanguages)
        {
            if (string.IsNullOrEmpty(programmingLanguages))
                return Ok();


            var searchValue = programmingLanguages.Split(',').ToList();

            return Ok(_searchEngineService.Search(searchValue));
        }
    }
}
