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
    public class MovieListsController : Controller
    {
        private IMovieListRepository _movieListRepository;

        public MovieListsController(IMovieListRepository movieListRepository) => _movieListRepository = movieListRepository;

        [HttpPost]
        public async Task<IActionResult> Create(MovieListDTO movieList)
        {
            try
            {
                var newMovieList = await _movieListRepository.Insert(movieList);
                return Ok(newMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllMovieLists()
        {
            try
            {
                var movieLists = _movieListRepository.GetAll();
                return Ok(movieLists);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet("{id:Guid}", Name = "GetSingleMovieList")]
        public IActionResult GetSingle(Guid id)
        {
            try
            {
                var movieList = _movieListRepository.Get(id);
                return Ok(movieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deletedMovieList = _movieListRepository.Delete(id);
                return Ok(deletedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Update(Guid id, MovieListDTO movieList)
        {
            try
            {
                var editedMovieList = _movieListRepository.Update(movieList);
                return Ok(editedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut("[action]/{id:Guid}")]
        public IActionResult AddMovie(Guid id, MovieDTO movie)
        {
            try
            {
                var movieList = new MovieListDTO
                {
                    Id = id
                };
                var editedMovieList = _movieListRepository.AddMovie(movieList, movie);
                return Ok(editedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut("[action]/{id:Guid}")]
        public IActionResult RemoveMovie(Guid id, MovieDTO movie)
        {
            try
            {
                var movieList = new MovieListDTO
                {
                    Id = id
                };
                var editedMovieList = _movieListRepository.RemoveMovie(movieList, movie);
                return Ok(editedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

    }
}
