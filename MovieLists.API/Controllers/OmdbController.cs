using Microsoft.AspNetCore.Mvc;
using MovieLists.API.DTO;
using MovieLists.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLists.API.Controllers
{
    [Route("api/[controller]")]
    public class OmdbController : Controller
    {
        private IOmdbRepository _omdbRepository;

        public OmdbController(IOmdbRepository omdbRepository) => _omdbRepository = omdbRepository;
        
        [HttpGet("[action]")]
        public async Task<IActionResult> Search(string query)
        {
            try
            {
                var searchRequest = new OmdbSearchRequestDTO
                {
                    SearchQuery = query
                };
                var results = await _omdbRepository.Search(searchRequest);
                return Ok(results);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetSingle(string movieImdbId, Guid userId)
        {
            try
            {
                var movie = new MovieDTO
                {
                    ImdbId = movieImdbId
                };

                var user = new UserDTO
                {
                    Id = userId
                };

                var result = _omdbRepository.GetOne(movie, user);
                return Ok(result);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }
    }
}
