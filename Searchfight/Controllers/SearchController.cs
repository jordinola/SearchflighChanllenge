using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Searchfight.IServices;
using Searchfight.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchEngineService _searchEngineService;
        private readonly IMapper _mapper;

        public SearchController(ISearchEngineService searchEngineService, IMapper mapper)
        {
            _searchEngineService = searchEngineService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]string query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok();

            var searchValue = query.Split(',').ToList();

            return Ok(_searchEngineService.Search(searchValue));
        }

        [HttpGet]
        [Route("get-results")]
        public ActionResult GetResults([FromQuery]string query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok();

            var searchValue = query.Split(',').ToList();

            return Ok(_mapper.Map<SearchResultOnly>(_searchEngineService.Search(searchValue)));
        }
    }
}
