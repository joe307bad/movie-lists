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
    public class RatingsController : Controller
    {
        private IRatingRepository _ratingsRepository;

        public RatingsController(IRatingRepository ratingsRepository) => _ratingsRepository = ratingsRepository;
        
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]RatingDTO rating, UserDTO user)
        {
            try
            {
                var newRating = await _ratingsRepository.Insert(rating, user);
                return Ok(newRating);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut, Route("[action]/{id}")]
        public IActionResult Update(RatingDTO rating, UserDTO user)
        {
            try
            {
                var editRating = _ratingsRepository.Update(rating, user);
                return Ok(editRating);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

    }
}
